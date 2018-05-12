using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeDonut.Judger;

namespace CodeDonut
{
    public partial class MultipleCasesResultForm : Form
    {
        private List<JudgeResult> _judgeResultsList;
        public MultipleCasesResultForm()
        {
            InitializeComponent();
        }

        private void MultipleCasesResultForm_Load(object sender, EventArgs e)
        {
            _judgeResultsList = new List<JudgeResult>();
        }

        delegate void AddJudgeResultHandel(JudgeResult judgeResult);
        public void AddJudgeResult(JudgeResult judgeResult)
        {
            if(this.InvokeRequired)
            {
                this.Invoke(new AddJudgeResultHandel(AddJudgeResult), judgeResult);
                return;
            }
            var item = listView_Main.Items.Add(judgeResult.TestCaseName);
            item.SubItems.Add(judgeResult.TestCaseSize.ToString() + "B");
            item.SubItems.Add(judgeResult.Result.ToString());
            item.SubItems.Add(judgeResult.TimeCost.ToString() + "ms");
            item.SubItems.Add(judgeResult.MemoryCost.ToString() + "KB");

            
            Color color;
            switch(judgeResult.Result)
            {
                case ResultCode.Accepted:
                    color = Color.LightGreen;
                    break;
                case ResultCode.OutPut:
                    color = Color.LightGreen;
                    break;
                case ResultCode.RuntimeError:
                    color = Color.Orange;
                    break;
                default:
                    color = Color.PaleVioletRed;
                    break;
            }

            item.BackColor = color;
            _judgeResultsList.Add(judgeResult);
        }

        public void Clear()
        {
            foreach(ListViewItem item in listView_Main.Items)
            {
                item.Remove();
            }
            _judgeResultsList.Clear();
        }

        private void MultipleCasesResultForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
