namespace CodeDonut
{
    partial class ContestsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView_Main = new System.Windows.Forms.ListView();
            this.columnHeader_OJ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_StartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Week = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Access = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label_About = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView_Main
            // 
            this.listView_Main.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_OJ,
            this.columnHeader_Name,
            this.columnHeader_StartTime,
            this.columnHeader_Week,
            this.columnHeader_Access});
            this.listView_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Main.FullRowSelect = true;
            this.listView_Main.Location = new System.Drawing.Point(0, 0);
            this.listView_Main.MultiSelect = false;
            this.listView_Main.Name = "listView_Main";
            this.listView_Main.Size = new System.Drawing.Size(782, 453);
            this.listView_Main.TabIndex = 0;
            this.listView_Main.UseCompatibleStateImageBehavior = false;
            this.listView_Main.View = System.Windows.Forms.View.Details;
            this.listView_Main.DoubleClick += new System.EventHandler(this.listView_Main_DoubleClick);
            // 
            // columnHeader_OJ
            // 
            this.columnHeader_OJ.Text = "OJ";
            this.columnHeader_OJ.Width = 100;
            // 
            // columnHeader_Name
            // 
            this.columnHeader_Name.Text = "Name";
            this.columnHeader_Name.Width = 300;
            // 
            // columnHeader_StartTime
            // 
            this.columnHeader_StartTime.Text = "StartTime";
            this.columnHeader_StartTime.Width = 200;
            // 
            // columnHeader_Week
            // 
            this.columnHeader_Week.Text = "Week";
            this.columnHeader_Week.Width = 80;
            // 
            // columnHeader_Access
            // 
            this.columnHeader_Access.Text = "Access";
            this.columnHeader_Access.Width = 80;
            // 
            // label_About
            // 
            this.label_About.AutoSize = true;
            this.label_About.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_About.Location = new System.Drawing.Point(0, 438);
            this.label_About.Name = "label_About";
            this.label_About.Size = new System.Drawing.Size(463, 15);
            this.label_About.TabIndex = 1;
            this.label_About.Text = "DataSource: contests.acmicpc.info / fast mirror by Rainng";
            // 
            // ContestsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.label_About);
            this.Controls.Add(this.listView_Main);
            this.MaximizeBox = false;
            this.Name = "ContestsForm";
            this.Text = "Contests";
            this.Load += new System.EventHandler(this.ContestsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView_Main;
        private System.Windows.Forms.ColumnHeader columnHeader_OJ;
        private System.Windows.Forms.ColumnHeader columnHeader_Name;
        private System.Windows.Forms.ColumnHeader columnHeader_StartTime;
        private System.Windows.Forms.ColumnHeader columnHeader_Week;
        private System.Windows.Forms.ColumnHeader columnHeader_Access;
        private System.Windows.Forms.Label label_About;
    }
}