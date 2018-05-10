using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace CodeDonut
{
    class ProcessHelper
    {
        /// <summary>
        /// 以无窗口方式运行程序，用于调用编译器
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="args">参数</param>
        /// <param name="readStdError">是否为读取标准错误流(默认读取标准输出流)</param>
        /// <param name="fixRelativePathToBaseDirectory">强制匹配相对路径为此程序所在基目录</param>
        /// <returns>执行结果</returns>
        public static string RunProcessWithNoWindow(string filePath, string args, bool readStdError = false, bool fixRelativePathToBaseDirectory = false)
        {
            try
            {
                string output;

                Process p = new Process();

                if (fixRelativePathToBaseDirectory) 
                {
                    filePath = IOHelper.GetBaseAbsolutePath(filePath);
                }
                Debug.WriteLine(filePath);

                p.StartInfo.FileName = filePath;
                p.StartInfo.Arguments = args;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;

                p.Start();
                if(readStdError)
                {
                    output = p.StandardError.ReadToEnd();
                }
                else
                {
                    output = p.StandardOutput.ReadToEnd();
                }

                p.WaitForExit();
                p.Close();

                return output;
            }
            catch
            {
                return "Unknown Error";
            }
        }

        public static void StartProcessIgnoreException(string filePath)
        {
            try
            {
                Process.Start(filePath);
            }
            catch { }
        }
    }
}
