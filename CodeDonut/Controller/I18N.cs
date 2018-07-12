using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CodeDonut.Controller
{
    class I18N
    {
        private static Dictionary<string, string> _langDictionary = new Dictionary<string, string>();
        public static void InitLanguageData()//根据系统环境自动初始化语言数据
        {
            string lang = System.Globalization.CultureInfo.CurrentCulture.EnglishName;
            string langData;
            if (lang.IndexOf("Chinese") != -1)
            {
                langData = CodeDonut.Properties.Resources.Lang_zh_cn;
            }
            else
            {
                langData = "";
            }

            string[] langKeyValArr = Regex.Split(langData, "\r\n|\r|\n");

            foreach (string KeyVal in langKeyValArr)
            {
                if(KeyVal.StartsWith("#"))
                {
                    continue;
                }

                string[] tempArr = Regex.Split(KeyVal, "=");
                if (tempArr.Length == 2)
                {
                    _langDictionary[tempArr[0]] = tempArr[1];
                }
            }
        }

        /// <summary>
        /// 取得对应的当前语言字符串
        /// </summary>
        /// <param name="">键:默认语言</param>
        /// <returns>值:当前语言</returns>
        public static string GetValue(string key)
        {
            if (_langDictionary.ContainsKey(key))
            {
                return _langDictionary[key];
            }

            return key;
        }

        #region 多语言界面
        public static void InitControls(Control obj)
        {
            if (obj is Button || obj is Label || obj is Form)
            {
                obj.Text = GetValue(obj.Text);
            }

            foreach (Control ctrl in obj.Controls)
            {
                InitControls(ctrl);
            }
        }

        public static void InitToolStrip(ToolStrip ts)
        {
            for (int i = 0; i < ts.Items.Count; i++)
            {
                if (ts.Items[i] is ToolStripButton)
                {
                    ts.Items[i].Text = GetValue(ts.Items[i].Text);
                }
            }
        }

        public static void InitMenuStrip(MenuStrip ms)
        {
            for (int i = 0; i < ms.Items.Count; i++)
            {
                InitToolStripMenuItem(ms.Items[i]);
            }
        }

        public static void InitContextMenuStrip(ContextMenuStrip cms)
        {
            for (int i = 0; i < cms.Items.Count; i++) 
            {
                InitToolStripMenuItem(cms.Items[i]);
            }
        }

        public static void InitToolStripMenuItem<T>(T obj)
        {
            if (obj is ToolStripMenuItem)
            {
                ToolStripMenuItem item = obj as ToolStripMenuItem;
                item.Text = GetValue(item.Text);
                for (int i = 0; i < item.DropDownItems.Count; i++)
                {
                    InitToolStripMenuItem(item.DropDownItems[i] as ToolStripMenuItem);
                }
            }
        }
        #endregion
    }
}
