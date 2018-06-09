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
        /// 读文件文本，若出现异常则返回空白string
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public static string ReadAllTextWithDfEncode(string path)
        {
            try
            {
                return File.ReadAllText(path);
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 写文件，以返回值标志是否成功
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
                File.WriteAllText(path, text);
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
