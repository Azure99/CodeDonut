using CodeDonut.Controller;
using FastColoredTextBoxNS;
using System;
using System.Windows.Forms;

namespace CodeDonut
{
    public partial class ReplaceForm : Form
    {
        private FastColoredTextBox _fctb;
        public ReplaceForm(FastColoredTextBox fctb)
        {
            InitializeComponent();
            _fctb = fctb;
        }

        private void Form_Replace_Load(object sender, EventArgs e)
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

        private void button_NextDown_Click(object sender, EventArgs e)
        {
            Find(FindType.Next);
        }

        private void button_Replace_Click(object sender, EventArgs e)
        {
            Replace();
        }

        private void button_ReplaceAll_Click(object sender, EventArgs e)
        {
            ReplaceAll();
        }

        private void Find(FindType type)//0Next_Up 1Next_Down
        {
            if (String.IsNullOrEmpty(textBox_FindWhat.Text))
            {
                MessageBox.Show(I18N.GetValue("You must input something that you want to find!"));
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

        private void Replace()
        {
            if (_fctb.SelectionLength == 0)
            {
                MessageBox.Show(I18N.GetValue("You must select something before replace!"));
                return;
            }

            int selStart = _fctb.SelectionStart;

            string newText = _fctb.Text.Substring(0, _fctb.SelectionStart) + 
                textBox_ReplaceWith.Text + 
                _fctb.Text.Substring(_fctb.SelectionStart +  _fctb.SelectionLength, (_fctb.TextLength - _fctb.SelectionStart - _fctb.SelectionLength));

            _fctb.Text = newText;
            _fctb.SelectionStart = selStart;
            _fctb.DoSelectionVisible();
        }

        private void ReplaceAll()
        {
            if (String.IsNullOrEmpty(textBox_FindWhat.Text))
            {
                MessageBox.Show(I18N.GetValue("You must input something that you want to find!"));
                return;
            }
            _fctb.Text = _fctb.Text.Replace(textBox_FindWhat.Text, textBox_ReplaceWith.Text);
        }
    }
}
