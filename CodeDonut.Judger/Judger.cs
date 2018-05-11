using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Timers;
using System.Text.RegularExpressions;

namespace CodeDonut.Judger
{
    public class Judger
    {
        public string FileName { get; set; }
        public int TimeLimit { get; set; }
        private Process NowProcess { get; set; }
        public Judger(string fileName, int timeLimit = 1000)
        {
            FileName = fileName;
            TimeLimit = timeLimit;
        }

        public JudgeResult Judge(string input, string output, string testCaseName = "")
        {
            Process process = new Process();
            NowProcess = process;

            RuntimeMonitor runtimeMonitor = new RuntimeMonitor(process, TimeLimit);
            runtimeMonitor.Start();

            string programOutput = null;
            JudgeResult judgeResult = new JudgeResult{
                Result = ResultCode.Accepted,
                TestCaseName = testCaseName,
                TestCaseSize = input.Length };

            try
            {
                programOutput = Run(process, input);
            }
            catch(RuntimeErrorException e)
            {
                judgeResult.Result = ResultCode.RuntimeError;
                if(runtimeMonitor.TimeCost >= TimeLimit)//被强制终止Exitcode不为1
                {
                    judgeResult.Result = ResultCode.TimeLimitExceeded;
                }
                else
                {
                    judgeResult.JudgeDetail = e.ErrorDetail;
                }
            }
            catch(Exception e)
            {
                judgeResult.Result = ResultCode.JudgeFailed;
                judgeResult.JudgeDetail = e.ToString();
                return judgeResult;
            }
            finally
            {
                runtimeMonitor.Dispose();
            }

            judgeResult.MemoryCost = runtimeMonitor.MemoryCost;
            judgeResult.TimeCost = (runtimeMonitor.TimeCost < TimeLimit) ? runtimeMonitor.TimeCost : TimeLimit;
            Console.WriteLine(judgeResult.Result);
            if (judgeResult.Result != ResultCode.Accepted)
            {
                return judgeResult;
            }

            
            if(string.IsNullOrEmpty(output))//测试数据无输出数据，将本次运行作为输出数据
            {
                judgeResult.Result = ResultCode.OutPut;
                judgeResult.OutPut = programOutput;
            }
            else//有测试输出
            {
                if (!JudgeAnswer(output, programOutput))
                {
                    judgeResult.Result = ResultCode.WrongAnswer;
                }
            }
            
            return judgeResult;
        }

        public string Run(Process process, string input)
        {
            process.StartInfo.FileName = FileName;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;

            process.Start();

            process.StandardInput.Write(Regex.Replace(input, "\r\n|\r|\n", "\n"));
            //process.StandardInput.Write("\n");
            process.StandardInput.Close();

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            //Console.WriteLine(output);

            if(!string.IsNullOrEmpty(error))//StdError有输出-RE
            {
                throw new RuntimeErrorException("Runtime Error: StdError is not null\n", error);
            }

            try
            {
                if (process.ExitCode != 0)//ExitCode不为0-RE
                {
                    throw new RuntimeErrorException("Runtime Error", "ExitCode is not 0");
                }
            }
            catch (InvalidOperationException) { }

            
            process.Close();

            return output;

        }

        public bool JudgeAnswer(string trueAnswer, string outputAnswer)
        {
            if(trueAnswer == outputAnswer)
            {
                return true;
            }

            trueAnswer = trueAnswer.Replace("\r\n", "\n").Replace("\r", "\n");
            outputAnswer = outputAnswer.Replace("\r\n", "\n").Replace("\r", "\n");
            if(trueAnswer == outputAnswer)
            {
                return true;
            }
            
            return false;
        }
    }
}
