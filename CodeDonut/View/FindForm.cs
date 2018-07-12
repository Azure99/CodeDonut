using CodeDonut.Controller;
using FastColoredTextBoxNS;
using System;
using System.Windows.Forms;

namespace CodeDonut
{
    public partial class FindForm : Form
    {
        private FastColoredTextBox _fctb;
        public FindForm(FastColoredTextBoxNS.FastColoredTextBox fctb)
        {
            InitializeComponent();
            _fctb = fctb;
        }

        private void Form_Find_Load(object sender, EventArgs e)
        {
            I18N.InitControls(this);
        }

        private enum FindType
        {
            Next,
            Last
        }

        private void button_NextUp_Click(object sender, EventArgs e)
        {
            Find(FindType.Last);
        }

        private void button_Count_Click(object sender, EventArgs e)
        {
            Count();
        }

        private void button_NextDown_Click(object sender, EventArgs e)
        {
            Find(FindType.Next);
        }


        private void Count()
        {
            if (String.IsNullOrEmpty(textBox_FindWhat.Text))
            {
                MessageBox.Show(I18N.GetValue("You must input something that you want to find!"));
                return;
            }

            int cnt = 0;
            int p = _fctb.Text.IndexOf(textBox_FindWhat.Text);
            while (p != -1) 
            {
                cnt++;
                p = _fctb.Text.IndexOf(textBox_FindWhat.Text, p + textBox_FindWhat.Text.Length);
            }
            MessageBox.Show(cnt.ToString(), "Count", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Find(FindType type)
        {
            if(String.IsNullOrEmpty(textBox_FindWhat.Text))
            {
                MessageBox.Show(I18N.GetValue(I18N.GetValue("You must input something that you want to find!")));
                return;
            }

            int startP, p;
            if (type == FindType.Last)
            {
                startP = _fctb.SelectionStart - 1;
                if (startP < 0)//防止起始位置小于0
                {
                    startP = 0;
                }
                p = _fctb.Text.LastIndexOf(textBox_FindWhat.Text, startP);
            }
            else
            {
                startP = _fctb.SelectionStart + _fctb.SelectionLength;
                p = _fctb.Text.IndexOf(textBox_FindWhat.Text, startP);
            }

            if (p == -1)
            {
                MessageBox.Show(I18N.GetValue("Can't find"), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _fctb.SelectionStart = p;
                _fctb.SelectionLength = textBox_FindWhat.Text.Length;
                _fctb.DoSelectionVisible();//调整滚动条位置
                _fctb.Focus();//切换焦点
            }
        }
    }
}
