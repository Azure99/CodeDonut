namespace CodeDonut
{
    partial class FindForm
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
            this.label_FindWhat = new System.Windows.Forms.Label();
            this.textBox_FindWhat = new System.Windows.Forms.TextBox();
            this.button_NextUp = new System.Windows.Forms.Button();
            this.button_Count = new System.Windows.Forms.Button();
            this.button_NextDown = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_FindWhat
            // 
            this.label_FindWhat.AutoSize = true;
            this.label_FindWhat.Location = new System.Drawing.Point(12, 22);
            this.label_FindWhat.Name = "label_FindWhat";
            this.label_FindWhat.Size = new System.Drawing.Size(87, 15);
            this.label_FindWhat.TabIndex = 0;
            this.label_FindWhat.Text = "Find What:";
            // 
            // textBox_FindWhat
            // 
            this.textBox_FindWhat.Location = new System.Drawing.Point(105, 19);
            this.textBox_FindWhat.Name = "textBox_FindWhat";
            this.textBox_FindWhat.Size = new System.Drawing.Size(300, 25);
            this.textBox_FindWhat.TabIndex = 1;
            // 
            // button_NextUp
            // 
            this.button_NextUp.Location = new System.Drawing.Point(12, 71);
            this.button_NextUp.Name = "button_NextUp";
            this.button_NextUp.Size = new System.Drawing.Size(100, 30);
            this.button_NextUp.TabIndex = 2;
            this.button_NextUp.Text = "<<Next";
            this.button_NextUp.UseVisualStyleBackColor = true;
            this.button_NextUp.Click += new System.EventHandler(this.button_NextUp_Click);
            // 
            // button_Count
            // 
            this.button_Count.Location = new System.Drawing.Point(156, 71);
            this.button_Count.Name = "button_Count";
            this.button_Count.Size = new System.Drawing.Size(100, 30);
            this.button_Count.TabIndex = 3;
            this.button_Count.Text = "Count";
            this.button_Count.UseVisualStyleBackColor = true;
            this.button_Count.Click += new System.EventHandler(this.button_Count_Click);
            // 
            // button_NextDown
            // 
            this.button_NextDown.Location = new System.Drawing.Point(304, 71);
            this.button_NextDown.Name = "button_NextDown";
            this.button_NextDown.Size = new System.Drawing.Size(100, 30);
            this.button_NextDown.TabIndex = 4;
            this.button_NextDown.Text = "Next>>";
            this.button_NextDown.UseVisualStyleBackColor = true;
            this.button_NextDown.Click += new System.EventHandler(this.button_NextDown_Click);
            // 
            // FindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 113);
            this.Controls.Add(this.button_NextDown);
            this.Controls.Add(this.button_Count);
            this.Controls.Add(this.button_NextUp);
            this.Controls.Add(this.textBox_FindWhat);
            this.Controls.Add(this.label_FindWhat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FindForm";
            this.Text = "Find";
            this.Load += new System.EventHandler(this.Form_Find_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_FindWhat;
        private System.Windows.Forms.TextBox textBox_FindWhat;
        private System.Windows.Forms.Button button_NextUp;
        private System.Windows.Forms.Button button_Count;
        private System.Windows.Forms.Button button_NextDown;
    }
}