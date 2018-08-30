using System.Diagnostics;

namespace CodeDonut.Utils
{
    public class ProcessRunner
    {
        /// <summary>
        /// 以无窗口方式运行程序
        /// </summary>
        /// <param name="readStdError">是否为读取标准错误流(默认读取标准输出流)</param>
        /// <returns>执行结果</returns>
        public string RunProcessWithNoWindow(string filePath, string args, string workingDirectory = "", bool readStdError = false)
        {
            try
            {
                string output;

                Process p = new Process();

                p.StartInfo.FileName = filePath;
                p.StartInfo.Arguments = args;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.WorkingDirectory = workingDirectory;

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

        /// <summary>
        /// 忽略异常地运行指定程序
        /// </summary>
        /// <param name="filePath">程序路径</param>
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
