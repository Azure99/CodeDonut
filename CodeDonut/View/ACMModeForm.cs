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
using CodeDonut.Judger;

namespace CodeDonut
{
    public partial class ACMModeForm : Form
    {
        private OutPutForm _outputForm;//输出窗口
        Judger.Judger _judger;
        public ACMModeForm(string path)
        {
            InitializeComponent();
            textBox_Path.Text = path;
        }

        private void Form_ACMMode_Load(object sender, EventArgs e)
        {
            I18N.InitControls(this);
            _outputForm = new OutPutForm();
            _outputForm.Hide();

        }

        private void button_Run_Click(object sender, EventArgs e)
        {
            string path = textBox_Path.Text;
            if (!File.Exists(path)) 
            {
                MessageBox.Show(I18N.GetValue("File not found!"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(int.TryParse(textBox_TimeLimit.Text, out int timelimit) == false)
            {
                MessageBox.Show(I18N.GetValue("Time limit must be a integer!"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            _judger = new Judger.Judger(path, timelimit);

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
                _judger.CurrentProcess.Kill();
            }
            catch { }
        }

        private void Form_ACMMode_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_outputForm != null && !_outputForm.IsDisposed)
            {
                _outputForm.CloseForm();
            }
        }

        private void Run(DoWorkEventArgs e)
        {
            JudgeResult judgeResult = _judger.Judge(textBox_InPut.Text, textBox_OutPut.Text);
            e.Result = judgeResult;
        }

        private void FinishJudge(RunWorkerCompletedEventArgs e)
        {
            JudgeResult judgeResult = (JudgeResult)e.Result;

            label_Status.Text = judgeResult.Result.ToString();
            label_Time.Text = "Time:" + judgeResult.TimeCost.ToString() + "ms";
            label_Memory.Text = "Mem:" + judgeResult.MemoryCost.ToString() + "0KB";

            if(judgeResult.Result == ResultCode.Accepted || judgeResult.Result == ResultCode.OutPut)
            {
                label_Status.ForeColor = Color.DarkGreen;
            }
            else if(judgeResult.Result == ResultCode.RuntimeError)
            {
                label_Status.ForeColor = Color.DarkBlue;
            }
            else
            {
                label_Status.ForeColor = Color.Red;
            }

            _outputForm.Clear();
            _outputForm.SetText(judgeResult.OutPut);
            _outputForm.ShowForm();

            ChangeCtrlsStatus(false);
        }

        /// <summary>
        /// 更改控件禁用状态
        /// </summary>
        /// <param name="working">T-工作中, F-非工作中</param>
        private void ChangeCtrlsStatus(bool working)
        {
            panel_Info.Visible = working;
            button_Run.Enabled = !working;
            textBox_InPut.Enabled = !working;
            textBox_OutPut.Enabled = !working;
            textBox_Path.Enabled = !working;
            textBox_TimeLimit.Enabled = !working;
        }
    }
}
