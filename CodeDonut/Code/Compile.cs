using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace CodeDonut
{
    class Compile
    {
        public static bool CompileFile(string filePath)//编译文件
        {
            MainForm.FormCompileErrorInfo.Visible = false;//隐藏编译信息窗口
            string compileResult = StartCompiler(filePath);//调用编译器
            int error = 0, warning = 0, note = 0;
            if (String.IsNullOrEmpty(compileResult))//若无返回信息则是编译成功
            {
                MessageBox.Show(I18N.GetValue("Compile successful"), "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (compileResult == "Unknown Error")
            {
                MessageBox.Show(I18N.GetValue("Can't Run Compiler!"), I18N.GetValue("Compile Failed"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                compileResult = Regex.Replace(compileResult, Regex.Escape(filePath), "");//去除编译结果中的文件路径
                string[] messages = Regex.Split(compileResult, "\r\n|\r|\n");
                MainForm.FormCompileErrorInfo.ClearErrorInfo();

                foreach(string message in messages)
                {
                    if (message.StartsWith(": In function"))//编译信息所在函数
                    {
                        MainForm.FormCompileErrorInfo.AddErrorInfo("-1", message.Substring(1, message.Length - 1), System.Drawing.Color.Black);
                    }
                    else if (message.StartsWith(":")) //单条编译信息
                    {
                        int p1 = 0;
                        int p2 = message.IndexOf(":", 1);
                        int p3 = message.IndexOf(":", p2 + 1);
                        if (!(p3 > p2 && p2 > p1)) //行列信息不正确，跳过
                        {
                            continue;
                        }

                        string type = message.Substring(p3 + 2, 4);
                        string line = message.Substring(1, p2 - 1);
                        string info = message.Substring(p3 + 1, message.Length - p3 - 1);
                        if (type == "erro" || type == "fata") 
                        {
                            error++;

                            if (message.IndexOf("error: expected ';' before") != -1)//分号丢失的错误，上移一行
                            {
                                int lineInt;
                                Int32.TryParse(line, out lineInt);
                                lineInt--;
                                line = lineInt.ToString();
                            }

                            MainForm.FormCompileErrorInfo.AddErrorInfo(line, info, System.Drawing.Color.Red);
                        }
                        else if (type == "warn") 
                        {
                            warning++;
                            MainForm.FormCompileErrorInfo.AddErrorInfo(line, info, System.Drawing.Color.Blue);
                        }
                        else
                        {
                            note++;
                            MainForm.FormCompileErrorInfo.AddErrorInfo(line, info, System.Drawing.Color.Black);
                        }
                    }
                }

                if (error == 0 && warning == 0 && note == 0)  //有错误信息却无法统计到任何类型的错误
                {
                    MessageBox.Show(compileResult, I18N.GetValue("Unknow Info"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                MainForm.FormCompileErrorInfo.Text = I18N.GetValue("Compile Information ") + error.ToString() + I18N.GetValue("-Error ") + warning.ToString() + I18N.GetValue("-Warning ") + note.ToString() + I18N.GetValue("-note");
                MainForm.FormCompileErrorInfo.AdjustFormPosition();
                MainForm.FormCompileErrorInfo.Visible = true;
                MainForm.FormCompileErrorInfo.Focus();
            }
            
            return error == 0;
        }

        private static string StartCompiler(string filePath)//调用编译器
        {
            bool isCppFile = IOHelper.GetFileType(filePath) != "c";
            string compiler;
            string args;

            if(isCppFile)
            {
                compiler = Config.Cpp_Compiler;
                args = Config.Cpp_Args;
            }
            else
            {
                compiler = Config.C_Compiler;
                args = Config.C_Args;
            }

            compiler = IOHelper.GetBaseAbsolutePath(compiler);
            string workDir = System.IO.Path.GetDirectoryName(compiler);

            filePath = "\"" + filePath + "\"";//参数中的路径要用""，否则会被作为参数分隔
            args += " " + filePath + " -o " + filePath + ".exe";
            return ProcessHelper.RunProcessWithNoWindow(compiler, args, workDir, true);
        }
    }
}
