using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace CodeDonut
{
    class IOHelper
    {
        /// <summary>
        /// 以默认编码读文件，失败返回空
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public static string ReadAllTextWithDfEncode(string path)
        {
            try
            {
                StreamReader sr = new StreamReader(path, Encoding.Default);
                string res = sr.ReadToEnd();
                sr.Close();
                return res;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 以默认编码写文件，失败返回false
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="text">内容</param>
        /// <returns></returns>
        public static bool WriteAllTextWithDfEncode(string path, string text)
        {
            if (path.Contains("SourceFile"))//确保SourceFile文件夹存在
            {
                FileManager.CheckSourceFileFolder();
            }
            try
            {
                FileStream fs = new FileStream(path, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                sw.Write(text);
                sw.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }



        /// <summary>
        /// 从路径中取出文件名
        /// </summary>
        /// <param name="path">文件名</param>
        /// <returns></returns>
        public static string GetFileName(string path)
        {
            string[] temp = path.Split('\\');
            if (temp.Length == 0)//不合法
            {
                return path;
            }
            else
            {
                return temp[temp.Length - 1];
            }
        }

        /// <summary>
        /// 获取文件类型
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public static string GetFileType(string path)
        {
            int p = path.LastIndexOf(".");
            if (p != -1)
            {
                return path.Substring(p + 1, path.Length - p - 1);
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 获取当前程序下，而不是当前工作目录下的绝对路径
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public static string GetBaseAbsolutePath(string path)
        {
            if(path.IndexOf(":") != -1)
            {
                return path;
            }

            if (path.StartsWith("\\"))
            {
                path = path.Substring(1, path.Length - 1);
            }
            path = AppDomain.CurrentDomain.BaseDirectory + path;
            return path;
        }
    }
}
