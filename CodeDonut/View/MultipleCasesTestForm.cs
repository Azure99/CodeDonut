using CodeDonut.Controller;
using CodeDonut.Judger;
using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CodeDonut
{
    public partial class MultipleCasesTestForm : Form
    {
        private MultipleCasesResultForm _resultForm;
        public MultipleCasesTestForm(string programPath)
        {
            InitializeComponent();

            textBox_ProgramPath.Text = programPath;
        }

        private void MultipleCasesTestForm_Load(object sender, EventArgs e)
        {
            I18N.InitControls(this);
            _resultForm = new MultipleCasesResultForm();
        }

        private void MultipleCasesTestForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _resultForm.Close();
            _resultForm.Dispose();
        }

        private void button_SelectProgram_Click(object sender, EventArgs e)
        {
            if (SelectProgram(out string path)) 
            {
                textBox_ProgramPath.Text = path;
            }
        }

        private void button_SelectInput_Click(object sender, EventArgs e)
        {
            if(SelectFolder(out string path))
            {
                textBox_InputPath.Text = path;
            }
        }

        private void button_SelectOutput_Click(object sender, EventArgs e)
        {
            if (SelectFolder(out string path))
            {
                textBox_OutputPath.Text = path;
            }
        }

        private void button_StartJudge_Click(object sender, EventArgs e)
        {
            if(!CheckRunConfig())//检查参数是否正确
            {
                return;
            }
            _resultForm.Show();
            _resultForm.Clear();
            
            backgroundWorker_Main.RunWorkerAsync();
            button_StartJudge.Enabled = false;
        }

        private void button_FAQ_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(I18N.GetValue("MultipleCasesTest is a function for ACMer and  OIer."));
            sb.AppendLine(I18N.GetValue("You can use it to test your program like Online Judge or produce test data. And it can show judge details for you."));
            sb.AppendLine("");
            sb.AppendLine("Tips:");
            sb.AppendLine(I18N.GetValue("1.Test data should be saved in folder."));
            sb.AppendLine(I18N.GetValue("2.CodeDonut will write the runtime output to out file if output file not in folder."));
            MessageBox.Show(sb.ToString(), "FAQ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //判题核心
        private void backgroundWorker_Main_DoWork(object sender, DoWorkEventArgs e)
        {
            MultipleJudgeController controller = new MultipleJudgeController(
                textBox_ProgramPath.Text,
                textBox_InputPath.Text,
                textBox_OutputPath.Text,
                int.Parse(textBox_TimeLimit.Text));

            while(controller.HasNextCase())
            {
                JudgeResult judgeResult = controller.JudgeNext();
                _resultForm.AddJudgeResult(judgeResult);
            }
        }

        private void backgroundWorker_Main_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button_StartJudge.Enabled = true;
        }


        #region 方法
        private bool SelectFolder(out string path)
        {
            path = "";
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                path = folderDialog.SelectedPath;

                return true;
            }
            return false;
        }

        private bool SelectProgram(out string path)
        {
            path = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Program(*.exe) | *.exe";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;

                return true;
            }
            return false;
        }

        private bool CheckRunConfig()
        {
            if(!File.Exists(textBox_ProgramPath.Text))
            {
                MessageBox.Show(I18N.GetValue("Program not found!"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if(!Directory.Exists(textBox_InputPath.Text))
            {
                MessageBox.Show(I18N.GetValue("Input folder not found!"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (!Directory.Exists(textBox_OutputPath.Text))
            {
                MessageBox.Show(I18N.GetValue("Output folder not found!"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if(textBox_InputPath.Text == textBox_OutputPath.Text)
            {
                MessageBox.Show(I18N.GetValue("Input equals Output!"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if(!int.TryParse(textBox_TimeLimit.Text, out int timeLimit))
            {
                MessageBox.Show(I18N.GetValue("Invalid time limit!"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true ;
        }


        #endregion
    }
}
