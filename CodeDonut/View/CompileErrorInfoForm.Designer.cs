namespace CodeDonut
{
    partial class CompileErrorInfoForm
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
            this.columnHeader_Line = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Info = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView_Main
            // 
            this.listView_Main.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_Line,
            this.columnHeader_Info});
            this.listView_Main.FullRowSelect = true;
            this.listView_Main.Location = new System.Drawing.Point(0, 0);
            this.listView_Main.MultiSelect = false;
            this.listView_Main.Name = "listView_Main";
            this.listView_Main.Size = new System.Drawing.Size(493, 144);
            this.listView_Main.TabIndex = 0;
            this.listView_Main.UseCompatibleStateImageBehavior = false;
            this.listView_Main.View = System.Windows.Forms.View.Details;
            this.listView_Main.DoubleClick += new System.EventHandler(this.listView_Main_DoubleClick);
            // 
            // columnHeader_Line
            // 
            this.columnHeader_Line.Text = "Line";
            // 
            // columnHeader_Info
            // 
            this.columnHeader_Info.Text = "Information";
            this.columnHeader_Info.Width = 300;
            // 
            // CompileErrorInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 153);
            this.Controls.Add(this.listView_Main);
            this.Name = "CompileErrorInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compile Information";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_CompileErrorInfo_FormClosing);
            this.Load += new System.EventHandler(this.Form_CompileErrorInfo_Load);
            this.SizeChanged += new System.EventHandler(this.Form_CompileErrorInfo_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView_Main;
        private System.Windows.Forms.ColumnHeader columnHeader_Line;
        private System.Windows.Forms.ColumnHeader columnHeader_Info;
    }
}