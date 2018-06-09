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
    public partial class CompileErrorInfoForm : Form
    {
        public CompileErrorInfoForm()
        {
            InitializeComponent();
        }

        private void Form_CompileErrorInfo_Load(object sender, EventArgs e)
        {
            I18N.InitControls(this);
            Form_CompileErrorInfo_SizeChanged(null, null);
        }

        private void Form_CompileErrorInfo_SizeChanged(object sender, EventArgs e)
        {
            listView_Main.Size = this.ClientSize;
            if ((listView_Main.Width - 70) < 300)
            {
                columnHeader_Info.Width = 300;
            }
            else
            {
                columnHeader_Info.Width = listView_Main.Width - columnHeader_Line.Width - 10;
            }
        }

        public void ClearErrorInfo()
        {
            foreach(ListViewItem lvi in listView_Main.Items)
            {
                lvi.Remove();
            }
        }

        public void AddErrorInfo(string line, string info, Color color)//添加错误信息
        {
            var item = listView_Main.Items.Add(line);
            item.SubItems.Add(info);
            item.ForeColor = color;
        }

        public void AdjustFormPosition()//自动调整窗口位置
        {
            this.Size = new Size(MainForm.FormMain.Width, 200);
            int h =  Screen.GetWorkingArea(this).Height;

            if (h - MainForm.FormMain.Location.Y - MainForm.FormMain.Height > 210) 
            {
                this.Location = new Point(MainForm.FormMain.Location.X, MainForm.FormMain.Location.Y + MainForm.FormMain.Height);
            }
            else
            {
                this.Location = new Point(MainForm.FormMain.Location.X, h - 210);
                MainForm.FormMain.Height = this.Location.Y - MainForm.FormMain.Location.Y;
            }
            this.TopMost = MainForm.FormMain.WindowState == FormWindowState.Maximized;
        }

        private void Form_CompileErrorInfo_FormClosing(object sender, FormClosingEventArgs e)//用隐藏窗口代替关闭窗口
        {
            this.Visible = false;
            e.Cancel = true;
        }

        private void listView_Main_DoubleClick(object sender, EventArgs e)
        {
            if(listView_Main.FocusedItem == null)
            {
                return;
            }

            var item = listView_Main.FocusedItem;

            if (item.Text == "-1")
            {
                return;
            }

            int line;
            Int32.TryParse(item.Text, out line);
            line--;
            //Form_Main.fastColoredTextBox.Selection.Start = new FastColoredTextBoxNS.Place(Form_Main.fastColoredTextBox.Lines[line].Length, line);
            MainForm.FCTB.Selection.Start = new FastColoredTextBoxNS.Place(0, line);
            MainForm.FCTB.SelectionLength = MainForm.FCTB.Lines[line].Length;
            MainForm.FCTB.DoSelectionVisible();
            MainForm.FCTB.Focus();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView_Main.FocusedItem == null)
            {
                return;
            }

            Clipboard.SetText(listView_Main.FocusedItem.SubItems[1].Text);
        }

        private void nextErrorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView_Main.FocusedItem == null)
            {
                return;
            }

            int index = listView_Main.FocusedItem.Index;
            if(index < listView_Main.Items.Count - 1)
            {
                listView_Main.FocusedItem = listView_Main.Items[index + 1];
                listView_Main_DoubleClick(null, null);
            }
        }

        private void previousErrorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView_Main.FocusedItem == null)
            {
                return;
            }

            int index = listView_Main.FocusedItem.Index;
            if (index > 0)
            {
                listView_Main.FocusedItem = listView_Main.Items[index - 1];
                listView_Main_DoubleClick(null, null);
            }
        }
    }
}
