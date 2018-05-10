using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CodeDonut
{
    class FileManager
    {
        /// <summary>
        /// 取得上次打开的文件
        /// </summary>
        /// <returns></returns>
        public static string GetLastOpenFilePath()
        {
            string path = IOHelper.ReadAllTextWithDfEncode("LastOpen.dat");
            if (!String.IsNullOrEmpty(path))
            {
                if(File.Exists(path))
                {
                    return path;
                }
                else
                {
                    return FileManager.GetAvalibleFilePath() + ".cpp";
                }
            }
            else
            {
                return FileManager.GetAvalibleFilePath() + ".cpp";
            }
        }

        /// <summary>
        /// 新建源文件并打开
        /// </summary>
        /// <param name="isCpp">是否为C++文件</param>
        public static void CreatNewSourceFile(bool isCpp)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if(isCpp)
            {
                sfd.FileName = IOHelper.GetFileName(FileManager.GetAvalibleFilePath()) + ".cpp";
                sfd.Filter = "C++ files(*.cpp)|*.cpp";
            }
            else
            {
                sfd.FileName = IOHelper.GetFileName(FileManager.GetAvalibleFilePath()) + ".c";
                sfd.Filter = "C files(*.c)|*.c";
            }

            sfd.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "SourceFile";

            if(sfd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string defaultCode = isCpp ? CodeDonut.Properties.Resources.CppDefaultCode : CodeDonut.Properties.Resources.CDefaultCode;
            if (!IOHelper.WriteAllTextWithDfEncode(sfd.FileName, defaultCode)) 
            {
                MessageBox.Show("Can't creat new file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                System.Diagnostics.Process.Start(Application.ExecutablePath, sfd.FileName);
            }
        }

        /// <summary>
        /// 打开源文件对话框，返回文件路径
        /// </summary>
        /// <returns>文件路径</returns>
        public static string OpenSourceFileDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All files (*.*)|*.*";
            ofd.InitialDirectory = AppDomain.CurrentDomain + "SourceFile";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                return ofd.FileName;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 另存为...源文件
        /// </summary>
        /// <param name="oldPath">原目录</param>
        /// <returns></returns>
        public static string SaveSourceFileAsDialog(string oldPath)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = IOHelper.GetFileName(oldPath);
            sfd.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "SourceFile";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                return sfd.FileName;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 获取可用的文件路径(用于创建新文件)
        /// </summary>
        /// <returns></returns>
        public static string GetAvalibleFilePath()
        {
            try
            {
                string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "SourceFile");
                List<int> filesNum = new List<int>();
                filesNum.Add(-1);
                for (int i = 0; i < files.Length; i++)
                {
                    string nowFileName = IOHelper.GetFileName(files[i]);
                    if (nowFileName.StartsWith("unnamed"))
                    {
                        int p = nowFileName.IndexOf('.');
                        if (p == -1)
                        {
                            p = nowFileName.Length;
                        }
                        string withOutType = nowFileName.Substring(0, p);
                        int num;//文件unnamed编号
                        Int32.TryParse(withOutType.Substring("unnamed".Length, withOutType.Length - "unnamed".Length), out num);
                        filesNum.Add(num);

                    }
                }

                filesNum.Sort();
                int num2 = filesNum[filesNum.Count - 1] + 1;
                string fileName = "unnamed" + num2.ToString();
                return AppDomain.CurrentDomain.BaseDirectory + @"SourceFile\" + fileName;
            }
            catch
            {
                return AppDomain.CurrentDomain.BaseDirectory + @"SourceFile\unnamed";
            }
        }

        /// <summary>
        /// 检查当前目录下是否有SourceFile文件夹, 若没有则创建, 用于保存源文件
        /// </summary>
        public static void CheckSourceFileFolder()
        {
            if (!Directory.Exists("SourceFile"))
            {
                try
                {
                    Directory.CreateDirectory("SourceFile");
                }
                catch { }
            }
        }
    }
}
