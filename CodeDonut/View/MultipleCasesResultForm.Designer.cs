namespace CodeDonut
{
    partial class MultipleCasesResultForm
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
            this.columnHeader_CaseName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_CaseSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Result = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Memory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView_Main
            // 
            this.listView_Main.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_CaseName,
            this.columnHeader_CaseSize,
            this.columnHeader_Result,
            this.columnHeader_Time,
            this.columnHeader_Memory});
            this.listView_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Main.FullRowSelect = true;
            this.listView_Main.Location = new System.Drawing.Point(0, 0);
            this.listView_Main.Name = "listView_Main";
            this.listView_Main.Size = new System.Drawing.Size(632, 450);
            this.listView_Main.TabIndex = 0;
            this.listView_Main.UseCompatibleStateImageBehavior = false;
            this.listView_Main.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_CaseName
            // 
            this.columnHeader_CaseName.Text = "CaseName";
            this.columnHeader_CaseName.Width = 90;
            // 
            // columnHeader_CaseSize
            // 
            this.columnHeader_CaseSize.Text = "CaseSize";
            this.columnHeader_CaseSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_CaseSize.Width = 100;
            // 
            // columnHeader_Result
            // 
            this.columnHeader_Result.Text = "Result";
            this.columnHeader_Result.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_Result.Width = 200;
            // 
            // columnHeader_Time
            // 
            this.columnHeader_Time.Text = "Time";
            this.columnHeader_Time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_Time.Width = 100;
            // 
            // columnHeader_Memory
            // 
            this.columnHeader_Memory.Text = "Memory";
            this.columnHeader_Memory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_Memory.Width = 120;
            // 
            // MultipleCasesResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 450);
            this.Controls.Add(this.listView_Main);
            this.Name = "MultipleCasesResultForm";
            this.Text = "Multiple Cases Result";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MultipleCasesResultForm_FormClosing);
            this.Load += new System.EventHandler(this.MultipleCasesResultForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView_Main;
        private System.Windows.Forms.ColumnHeader columnHeader_CaseName;
        private System.Windows.Forms.ColumnHeader columnHeader_CaseSize;
        private System.Windows.Forms.ColumnHeader columnHeader_Result;
        private System.Windows.Forms.ColumnHeader columnHeader_Time;
        private System.Windows.Forms.ColumnHeader columnHeader_Memory;
    }
}