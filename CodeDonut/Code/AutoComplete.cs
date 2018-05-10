using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using FastColoredTextBoxNS;
using System.Windows.Forms;

namespace CodeDonut
{
    class AutoComplete
    {
        /// <summary>
        /// 初始化代码补全
        /// </summary>
        /// <param name="autoCompleteRules">代码补全规则信息</param>
        /// <param name="acMenu">自动完成菜单</param>
        /// <param name="fctb">FCTB编辑框</param>
        /// <param name="imageList">图标列表</param>
        public static void InitAutoComplete(string autoCompleteRules,AutocompleteMenu acMenu, FastColoredTextBox fctb, ImageList imageList)
        {
            //解析代码补全数据
            List<string> t_Keywords = GetKeywordList(autoCompleteRules, "Keyword");
            List<string> t_functions = GetKeywordList(autoCompleteRules, "Functions");

            string[] keywords = new string[t_Keywords.Count + t_functions.Count];
            t_Keywords.CopyTo(keywords, 0);
            t_functions.CopyTo(keywords, t_Keywords.Count);


            string[] methods = GetKeywordList(autoCompleteRules, "Methods").ToArray();
            string[] snippets = GetKeywordList(autoCompleteRules, "Snippets").ToArray();
            string[] declarationSnippets = GetKeywordList(autoCompleteRules, "DeclarationSnippets").ToArray();
            string[] headers = GetKeywordList(autoCompleteRules, "Headers").ToArray();

            //初始化AutocompleteMenu
            acMenu.ImageList = imageList;
            acMenu.SearchPattern = @"[#\w\.:=!<>]";
            acMenu.AllowTabKey = true;

            //Build
            List<AutocompleteItem> items = new List<AutocompleteItem>();

            foreach (var item in snippets)
                items.Add(new SnippetAutocompleteItem(item) { ImageIndex = 1 });
            foreach (var item in declarationSnippets)
                items.Add(new DeclarationSnippet(item) { ImageIndex = 0 });
            foreach (var item in methods)
                items.Add(new MethodAutocompleteItem(item) { ImageIndex = 2 });
            foreach (var item in keywords)
                items.Add(new AutocompleteItem(item));
            foreach (var item in headers)
                items.Add(new HeaderAutocompleteItem(item));

            items.Add(new InsertSpaceSnippet());
            items.Add(new InsertSpaceSnippet(@"^(\w+)([=<>!:]+)(\w+)$"));
            items.Add(new InsertEnterSnippet());

            //set appear interval
            acMenu.AppearInterval = 100;
            //set as autocomplete source
            acMenu.Items.SetAutocompleteItems(items);


        }
        /// <summary>
        /// 提取一类关键字
        /// </summary>
        /// <param name="data">规则数据</param>
        /// <param name="key">关键字</param>
        /// <returns></returns>
        private static List<string> GetKeywordList(string data, string key)
        {
            List<string> keywordList = new List<string>();
            int startIndex = data.IndexOf(key + "===") + (key + "===").Length;
            int endIndex = data.IndexOf(key + "End;");

            string objData = data.Substring(startIndex, endIndex - startIndex);//从文件中提取出本类关键字的数据
            string[] keywordArr = Regex.Split(objData, "\r\n|\r|\n");

            foreach(string keyword in keywordArr)
            {
                if(keyword.StartsWith("##") || String.IsNullOrEmpty(keyword))//跳过#注释
                {
                    continue;
                }

                if (key.IndexOf("Snippets") == -1) 
                {
                    keywordList.Add(keyword);
                }
                else//针对Snippets特殊处理\n
                {
                    keywordList.Add(Regex.Replace(keyword, @"\\n", "\n"));
                }
            }

            return keywordList;
        }
    }
    
    class InsertSpaceSnippet : AutocompleteItem
    {
        string pattern;

        public InsertSpaceSnippet(string pattern) : base("")
        {
            this.pattern = pattern;
        }

        public InsertSpaceSnippet()
            : this(@"^(\d+)([a-zA-Z_]+)(\d*)$")
        {
        }

        public override CompareResult Compare(string fragmentText)
        {
            if (Regex.IsMatch(fragmentText, pattern))
            {
                Text = InsertSpaces(fragmentText);
                if (Text != fragmentText)
                    return CompareResult.Visible;
            }
            return CompareResult.Hidden;
        }

        public string InsertSpaces(string fragment)
        {
            var m = Regex.Match(fragment, pattern);
            if (m == null)
                return fragment;
            if (m.Groups[1].Value == "" && m.Groups[3].Value == "")
                return fragment;
            return (m.Groups[1].Value + " " + m.Groups[2].Value + " " + m.Groups[3].Value).Trim();
        }

        public override string ToolTipTitle
        {
            get
            {
                return Text;
            }
        }
    }
    class DeclarationSnippet : SnippetAutocompleteItem
    {
        public DeclarationSnippet(string snippet)
            : base(snippet)
        {
        }

        public override CompareResult Compare(string fragmentText)
        {
            var pattern = Regex.Escape(fragmentText);
            if (Regex.IsMatch(Text, "\\b" + pattern, RegexOptions.IgnoreCase))
                return CompareResult.Visible;
            return CompareResult.Hidden;
        }
    }
    class InsertEnterSnippet : AutocompleteItem
    {
        Place enterPlace = Place.Empty;

        public InsertEnterSnippet()
            : base("[Line break]")
        {
        }

        public override CompareResult Compare(string fragmentText)
        {
            var r = Parent.Fragment.Clone();
            while (r.Start.iChar > 0)
            {
                if (r.CharBeforeStart == '}')
                {
                    enterPlace = r.Start;
                    return CompareResult.Visible;
                }

                r.GoLeftThroughFolded();
            }

            return CompareResult.Hidden;
        }

        public override string GetTextForReplace()
        {
            //extend range
            Range r = Parent.Fragment;
            Place end = r.End;
            r.Start = enterPlace;
            r.End = r.End;
            //insert line break
            return Environment.NewLine + r.Text;
        }

        public override void OnSelected(AutocompleteMenu popupMenu, SelectedEventArgs e)
        {
            base.OnSelected(popupMenu, e);
            if (Parent.Fragment.tb.AutoIndent)
                Parent.Fragment.tb.DoAutoIndent();
        }
    }
    /// <summary>
    /// This autocomplete item appears after #
    /// </summary>
    public class HeaderAutocompleteItem : AutocompleteItem
    {
        string firstPart;
        string lowercaseText;

        public HeaderAutocompleteItem(string text)
            : base(text)
        {
            lowercaseText = Text.ToLower();
        }

        public override CompareResult Compare(string fragmentText)
        {
            int i = fragmentText.LastIndexOf('#');
            if (i < 0)
                return CompareResult.Hidden;
            string lastPart = fragmentText.Substring(i + 1);
            firstPart = fragmentText.Substring(0, i);

            if (lastPart == "") return CompareResult.Visible;
            if (Text.StartsWith(lastPart, StringComparison.InvariantCultureIgnoreCase))
                return CompareResult.VisibleAndSelected;
            if (lowercaseText.Contains(lastPart.ToLower()))
                return CompareResult.Visible;

            return CompareResult.Hidden;
        }
    }
}
