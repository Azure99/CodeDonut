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
    public partial class ContestsForm : Form
    {
        private static ContestInfo[] contestInfos;
        public ContestsForm()
        {
            InitializeComponent();
        }

        private void ContestsForm_Load(object sender, EventArgs e)
        {
            InitContestsInfo();

            foreach (var item in contestInfos)
            {
                var child = listView_Main.Items.Add(item.OJ);
                child.SubItems.Add(item.Name);
                child.SubItems.Add(item.StartTime);
                child.SubItems.Add(item.Week);
                child.SubItems.Add(item.Access);
            }
        }

        public static void InitContestsInfo()
        {
            if (contestInfos == null || contestInfos.Length <= 1)
            {
                var fetcher = new ContestInfo.Fetcher();
                contestInfos = fetcher.GetContestInfos();
            }
        }

        private void listView_Main_DoubleClick(object sender, EventArgs e)
        {
            if(listView_Main.FocusedItem == null)
            {
                return;
            }

            int index = listView_Main.FocusedItem.Index;
            if (index < contestInfos.Length)
            {
                try
                {
                    System.Diagnostics.Process.Start(contestInfos[index].Link);
                }
                catch { }
            }
        }
    }
}
