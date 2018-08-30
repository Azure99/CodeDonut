using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using CodeDonut.Utils;

namespace CodeDonut.Compiler
{
    public class GccCompiler : ICompiler
    {
        public string CompilerPath { get; }
        public string CompileArgs { get; set; }

        private string nowSourceFile;
        public GccCompiler(string compilerPath, string compileArgs)
        {
            CompilerPath = compilerPath;
            CompileArgs = compileArgs;
            nowSourceFile = "";
        }

        public CompileResult Compile(string sourceFile)
        {
            nowSourceFile = sourceFile;
            string resultText = StartCompiler(sourceFile);
            return ParseResult(resultText);
        }


        private string StartCompiler(string sourceFile)//调用编译器
        {
            ProcessRunner pr = new ProcessRunner();

            string compilerPath = FileHelper.GetBaseAbsolutePath(CompilerPath);
            string workDir = Path.GetDirectoryName(CompilerPath);

            sourceFile = "\"" + sourceFile + "\"";//参数中的路径要用""，否则会被作为参数分隔
            string args = CompileArgs + " " + sourceFile + " -o " + sourceFile + ".exe";
            return pr.RunProcessWithNoWindow(compilerPath, args, workDir, true);

        }

        private CompileResult ParseResult(string resultText)
        {
            List<CompileErrorInfo> errorInfos = new List<CompileErrorInfo>();

            int error = 0, warning = 0, note = 0;

            if (String.IsNullOrEmpty(resultText))//若无返回信息则是编译成功
            {
                return new CompileResult(CompileResultCode.Successful, "Compile successful");
            }
            else if (resultText == "Unknown Error")
            {
                return new CompileResult(CompileResultCode.UnknownError, "Can't Run Compiler!");
            }
            else
            {
                resultText = Regex.Replace(resultText, Regex.Escape(nowSourceFile), "");//去除编译结果中的文件路径
                string[] messages = Regex.Split(resultText, "\r\n|\r|\n");

                foreach (string message in messages)
                {
                    if (message.StartsWith(": In function"))//编译信息所在函数
                    {
                        errorInfos.Add(new CompileErrorInfo(-1, message.Substring(1, message.Length - 1), Color.Black));
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

                        int lineInt;
                        Int32.TryParse(line, out lineInt);

                        if (type == "erro" || type == "fata")
                        {
                            error++;

                            if (message.IndexOf("error: expected ';' before") != -1)//分号丢失的错误，上移一行
                            {
                                lineInt--;
                            }
                            errorInfos.Add(new CompileErrorInfo(lineInt, info, Color.Red));
                        }
                        else if (type == "warn")
                        {
                            warning++;
                            errorInfos.Add(new CompileErrorInfo(lineInt, info, Color.Blue));
                        }
                        else
                        {
                            note++;
                            errorInfos.Add(new CompileErrorInfo(lineInt, info, Color.Black));
                        }
                    }
                }
            }

            CompileResultCode resultCode = CompileResultCode.Failed;
            string compileMessage = "Compile failed!";
            if(error == 0 && warning == 0 && note == 0)
            {
                resultCode = CompileResultCode.UnknownError;
                compileMessage = "Unknow Error";
            }

            CompileResult result = new CompileResult(
                resultCode, 
                compileMessage, 
                error, warning, note, 
                errorInfos.ToArray());

            return result;
        }

    }
}
