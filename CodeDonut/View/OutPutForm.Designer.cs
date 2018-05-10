namespace CodeDonut
{
    partial class OutPutForm
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
            this.textBox_OutPut = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_OutPut
            // 
            this.textBox_OutPut.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox_OutPut.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox_OutPut.Location = new System.Drawing.Point(0, 0);
            this.textBox_OutPut.MaxLength = 8388352;
            this.textBox_OutPut.Multiline = true;
            this.textBox_OutPut.Name = "textBox_OutPut";
            this.textBox_OutPut.ReadOnly = true;
            this.textBox_OutPut.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_OutPut.Size = new System.Drawing.Size(511, 282);
            this.textBox_OutPut.TabIndex = 0;
            // 
            // OutPutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 366);
            this.Controls.Add(this.textBox_OutPut);
            this.Name = "OutPutForm";
            this.Text = "OutPut";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_OutPut_FormClosing);
            this.Load += new System.EventHandler(this.Form_OutPut_Load);
            this.SizeChanged += new System.EventHandler(this.Form_OutPut_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_OutPut;
    }
}