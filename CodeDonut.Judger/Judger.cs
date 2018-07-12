using System;
using System.Diagnostics;

namespace CodeDonut.Judger
{
    public class Judger
    {
        public string FileName { get; set; }
        public string WorkingDirectory { get; set; }
        public int TimeLimit { get; set; }
        public Process CurrentProcess { get; set; }

        public Judger(string fileName, int timeLimit = 1000, string workingDirectory = "")
        {
            FileName = fileName;
            TimeLimit = timeLimit;
            WorkingDirectory = workingDirectory;
        }

        public JudgeResult Judge(string inputData, string outputData, string testCaseName = "")
        {
            Process process = new Process();
            CurrentProcess = process;

            RuntimeMonitor runtimeMonitor = new RuntimeMonitor(process, TimeLimit);
            runtimeMonitor.Start();

            string programOutput = null;
            JudgeResult judgeResult = new JudgeResult{
                Result = ResultCode.Accepted,
                TestCaseName = testCaseName,
                TestCaseSize = inputData.Length };

            try
            {
                programOutput = Run(process, inputData);
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
            if (string.IsNullOrEmpty(outputData))//测试数据无输出数据，将本次运行作为输出数据
            {
                judgeResult.Result = ResultCode.OutPut;
            }
            else//有测试输出
            {
                string res = JudgeAnswer(outputData, programOutput);
                if (res == "wa")
                {
                    judgeResult.Result = ResultCode.WrongAnswer;
                }
                else if(res == "pe")
                {
                    judgeResult.Result = ResultCode.PresentationError;
                }
            }
            
            return judgeResult;
        }

        public string Run(Process process, string input)
        {
            process.StartInfo.FileName = FileName;
            process.StartInfo.WorkingDirectory = WorkingDirectory;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;

            input = input.Replace("\r\n", "\n").Replace("\r", "\n");

            process.Start();
            process.PriorityClass = ProcessPriorityClass.RealTime;

            process.StandardInput.WriteLine(input);
            process.StandardInput.Close();

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            //Console.WriteLine(output);

            if(!string.IsNullOrEmpty(error))//StdError流有输出-运行时错误
            {
                throw new RuntimeErrorException("Runtime Error: StdError is not null\n", error);
            }

            try
            {
                if (process.ExitCode != 0)//ExitCode不为0-运行时错误
                {
                    throw new RuntimeErrorException("Runtime Error", "ExitCode is not 0");
                }
            }
            catch (InvalidOperationException) { }

            process.Close();

            return output;

        }


        public string JudgeAnswer(string trueAnswer, string outputAnswer)
        {
            if(trueAnswer == outputAnswer)
            {
                return "ac";
            }

            trueAnswer = trueAnswer.Replace("\r\n", "\n").Replace("\r", "\n");
            outputAnswer = outputAnswer.Replace("\r\n", "\n").Replace("\r", "\n");
            if(trueAnswer == outputAnswer)
            {
                return "ac";
            }

            string[] trueArr = trueAnswer.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string[] outputArr = outputAnswer.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            if(trueArr.Length != outputArr.Length)
            {
                return "wa";
            }

            for (int i = 0; i < trueArr.Length; i++) 
            {
                if(trueArr[i].TrimEnd() != outputArr[i].TrimEnd())
                {
                    return "wa";
                }
            }
            
            return "pe";
        }
    }
}
