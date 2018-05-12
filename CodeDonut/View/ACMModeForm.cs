using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Timers;

namespace CodeDonut
{
    struct JudgeResult2
    {
        public bool AnwserIsTrue;
        public int TimeUsed;
        public int ExitCode;
        public int MemoryUsed;
    }

    public partial class ACMModeForm : Form
    {
        
        private OutPutForm form_OutPut;//输出窗口
        Process process;
        public ACMModeForm(string path)
        {
            InitializeComponent();
            textBox_Path.Text = path;
        }

        private void Form_ACMMode_Load(object sender, EventArgs e)
        {
            I18N.InitControls(this);
            form_OutPut = new OutPutForm();
            form_OutPut.Show();
            form_OutPut.Visible = false;
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void button_Run_Click(object sender, EventArgs e)
        {
            string path = textBox_Path.Text;
            if (!File.Exists(path)) 
            {
                MessageBox.Show("File not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ChangeCtrlsStatus(true);

            backgroundWorker_Main.RunWorkerAsync();
        }

        private void backgroundWorker_Main_DoWork(object sender, DoWorkEventArgs e)
        {
            Run(e);
        }
        private void backgroundWorker_Main_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FinishJudge(e);
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            try
            {
                process.Kill();
            }
            catch { }
        }

        private void Form_ACMMode_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (form_OutPut != null && !form_OutPut.IsDisposed)
            {
                form_OutPut.CloseForm();
            }
        }

        /// <summary>
        /// 更改控件属性
        /// </summary>
        /// <param name="work">T-工作中, F-非工作中</param>
        private void ChangeCtrlsStatus(bool work)
        {
            panel_Info.Visible = work;
            button_Run.Enabled = !work;
            textBox_InPut.Enabled = !work;
            textBox_OutPut.Enabled = !work;
            textBox_Path.Enabled = !work;
            textBox_TimeLimit.Enabled = !work;
        }

        /// <summary>
        /// 运行程序并判题
        /// </summary>
        /// <param name="e"></param>
        private void Run(DoWorkEventArgs e)
        {
            string runResult = "";
            process = new Process();

            int timeLimit = 1000;
            Int32.TryParse(textBox_TimeLimit.Text, out timeLimit);
            int timeUsed = 0;
            long memoryUsed = 0;

            System.Timers.Timer timer = new System.Timers.Timer(20);
            timer.Elapsed += (object t_sender, System.Timers.ElapsedEventArgs t_e) =>
            {
                Debug.WriteLine(memoryUsed);
                try
                {
                    if (process.HasExited)
                    {
                        timer.Stop();
                        timer.Dispose();
                    }
                    else
                    {
                        if ((process.PeakPagedMemorySize64 / 1024) > memoryUsed)
                            memoryUsed = (process.PeakPagedMemorySize64 / 1024);

                        timeUsed = (int)(DateTime.Now - process.StartTime).TotalMilliseconds;
                        if (timeUsed > timeLimit)
                        {
                            process.Kill();
                        }
                    }
                }
                catch { }
            };

            try
            {
                process.StartInfo.FileName = textBox_Path.Text;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;

                process.Start();

                timer.Start();

                process.StandardInput.Write(Regex.Replace(textBox_InPut.Text, "\r\n|\r|\n", "\n") + "\n");
                process.StandardInput.AutoFlush = true;
                process.StandardInput.Close();

                runResult = process.StandardOutput.ReadToEnd();


                Int32.TryParse(textBox_TimeLimit.Text, out timeLimit);
                process.WaitForExit();

                JudgeResult2 judgeResult;
                judgeResult.AnwserIsTrue = JudgeAnswer(textBox_OutPut.Text, runResult);
                judgeResult.ExitCode = process.ExitCode;
                judgeResult.TimeUsed = (int)(DateTime.Now - process.StartTime).TotalMilliseconds;
                judgeResult.MemoryUsed = (int)memoryUsed;
                e.Result = judgeResult;
            }
            catch
            {

            }

            form_OutPut.Clear();
            form_OutPut.SetText(runResult);
            form_OutPut.ShowForm();
            process.Close();
        }

        /// <summary>
        /// 判断用户答案是否正确
        /// </summary>
        /// <param name="trueAnswer">正确答案</param>
        /// <param name="userAnswer">用户答案</param>
        /// <returns>T-正确, F-错误</returns>
        private bool JudgeAnswer(string trueAnswer, string userAnswer)
        {
            string[] trueAnswerLines = Regex.Split(trueAnswer, "\r\n|\r|\n");
            string[] userAnswerLines = Regex.Split(userAnswer, "\r\n|\r|\n");

            if (trueAnswerLines.Length > userAnswerLines.Length)
            {
                return false;
            }

            bool judgeResult = true;
            for (int i = 0; i < trueAnswerLines.Length; i++)
            {
                if (trueAnswerLines[i] != userAnswerLines[i])
                {
                    judgeResult = false;
                    break;
                }
            }
            return judgeResult;
        }

        private void FinishJudge(RunWorkerCompletedEventArgs e)
        {
            JudgeResult2 judgeResult = (JudgeResult2)e.Result;

            if (judgeResult.AnwserIsTrue)
            {
                label_Status.Text = "Accepted";
                label_Status.ForeColor = Color.Green;
            }
            else
            {
                label_Status.Text = "Wrong Answer";
                label_Status.ForeColor = Color.Red;
            }
            int timeLimit = 1000;
            Int32.TryParse(textBox_TimeLimit.Text, out timeLimit);

            if (judgeResult.ExitCode != 0)
            {
                label_Status.Text = "Runtime Error";
                label_Status.ForeColor = Color.Blue;
            }

            if (judgeResult.TimeUsed > timeLimit)
            {
                label_Status.Text = "Time Limit Exceeded";
                label_Time.Text = "Time:" + timeLimit.ToString() + "ms";
                label_Status.ForeColor = Color.Red;
            }
            else
            {
                label_Time.Text = "Time:" + judgeResult.TimeUsed.ToString() + "ms";
            }
            label_Memory.Text = "Mem:" + judgeResult.MemoryUsed.ToString() + "KB";

            backgroundWorker_Main.Dispose();
            ChangeCtrlsStatus(false);
        }
    }
}
