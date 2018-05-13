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
        private Process CurrentProcess { get; set; }
        public Judger(string fileName, int timeLimit = 1000)
        {
            FileName = fileName;
            TimeLimit = timeLimit;
        }

        public JudgeResult Judge(string input, string output, string testCaseName = "")
        {
            Process process = new Process();
            CurrentProcess = process;

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

            judgeResult.OutPut = programOutput;
            if (string.IsNullOrEmpty(output))//测试数据无输出数据，将本次运行作为输出数据
            {
                judgeResult.Result = ResultCode.OutPut;
            }
            else//有测试输出
            {
                int res = JudgeAnswer(output, programOutput);
                if (res == 1)
                {
                    judgeResult.Result = ResultCode.WrongAnswer;
                }
                else if(res == 2)
                {
                    judgeResult.Result = ResultCode.PresentationError;
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

            input = input.Replace("\r\n", "\n").Replace("\r", "\n");

            process.Start();

            process.StandardInput.WriteLine(input);
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

        /// <returns>0AC-1WA-2PE</returns>
        public int JudgeAnswer(string trueAnswer, string outputAnswer)
        {
            if(trueAnswer == outputAnswer)
            {
                return 0;
            }

            trueAnswer = trueAnswer.Replace("\r\n", "\n").Replace("\r", "\n");
            outputAnswer = outputAnswer.Replace("\r\n", "\n").Replace("\r", "\n");
            if(trueAnswer == outputAnswer)
            {
                return 0;
            }

            string[] trueArr = trueAnswer.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string[] outputArr = outputAnswer.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            if(trueArr.Length != outputArr.Length)
            {
                return 1;
            }

            for (int i = 0; i < trueArr.Length; i++) 
            {
                if(trueArr[i].TrimEnd() != outputArr[i].TrimEnd())
                {
                    return 1;
                }
            }
            
            return 2;
        }
    }
}
