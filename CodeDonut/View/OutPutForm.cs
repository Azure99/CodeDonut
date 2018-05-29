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
            textBox_OutPut.Text = "";
        }
        public void SetText(string text)
        {
            textBox_OutPut.Text = text;
        }

        public void ShowForm()
        {
            if (textBox_OutPut.Text.Length > 0)
            {
                textBox_OutPut.SelectionStart = textBox_OutPut.Text.Length - 1;
            }

            this.Visible = true;
            this.Focus();
            textBox_OutPut.ScrollToCaret();
        }

        public void CloseForm()
        {
            this.Close();
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
