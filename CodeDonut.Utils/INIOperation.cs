using System;
using System.Runtime.InteropServices;
using System.Text;

namespace CodeDonut
{
    /// <summary>
    /// Simple INI operation
    /// </summary>
    public static class INIOperation
    {

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        public static string ReadValue(string iniPath, string section, string key, string defaultString = "")
        {
            iniPath = GetBaseAbsolutePath(iniPath);
            StringBuilder sb = new StringBuilder(1024);
            GetPrivateProfileString(section, key, defaultString, sb, 1024, iniPath);
            return sb.ToString();
        }

        public static void WriteValue(string iniPath, string section, string key, string value)
        {
            iniPath = GetBaseAbsolutePath(iniPath);
            WritePrivateProfileString(section, key, value, iniPath);
        }

        private static string GetBaseAbsolutePath(string path)//调用的API不允许相对路径，因此使用前需要先进行判断
        {
            bool isAbsolutePath = path.IndexOf(":") == -1;
            if (path.StartsWith("\\"))
            {
                path = path.Substring(1, path.Length - 1);
            }
            path = AppDomain.CurrentDomain.BaseDirectory + path;
            return path;
        }
    }
}
