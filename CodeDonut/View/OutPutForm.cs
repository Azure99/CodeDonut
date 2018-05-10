using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeDonut
{
    public partial class OutPutForm : Form
    {
        private delegate void ClearHandler();
        private delegate void SetTextHandler(string text);
        private delegate void ShowOrCloseFormHandler();

        public OutPutForm()
        {
            InitializeComponent();
        }

        private void Form_OutPut_Load(object sender, EventArgs e)
        {
            Form_OutPut_SizeChanged(null, null);
        }

        public void Clear()
        {
            if (this.textBox_OutPut.InvokeRequired)
            {
                ClearHandler clear = new ClearHandler(Clear);
                this.Invoke(clear);
            }
            else
            {
                textBox_OutPut.Text = "";
            }
        }
        public void SetText(string text)
        {
            if(this.textBox_OutPut.InvokeRequired)
            {
                SetTextHandler setText = new SetTextHandler(SetText);
                this.Invoke(setText, new object[] { text });
            }
            else
            {
                textBox_OutPut.Text = text;
            }
        }

        public void ShowForm()
        {
            if(this.InvokeRequired)
            {
                ShowOrCloseFormHandler show = new ShowOrCloseFormHandler(ShowForm);
                this.Invoke(show);
            }
            else
            {
                if (textBox_OutPut.Text.Length > 0) 
                {
                    textBox_OutPut.SelectionStart = textBox_OutPut.Text.Length - 1;
                }
                
                this.Visible = true;
                this.Focus();
                textBox_OutPut.ScrollToCaret();
            }
        }

        public void CloseForm()
        {
            if (this.InvokeRequired)
            {
                ShowOrCloseFormHandler close = new ShowOrCloseFormHandler(CloseForm);
                this.Invoke(close);
            }
            else
            {
                this.Close();
            }
        }

        public string ReadAllLine()
        {
            return textBox_OutPut.Text;
        }

        private void Form_OutPut_SizeChanged(object sender, EventArgs e)
        {
            textBox_OutPut.Size = this.ClientSize;
        }

        private void Form_OutPut_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
