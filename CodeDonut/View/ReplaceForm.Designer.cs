namespace CodeDonut
{
    partial class ReplaceForm
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
            this.label_ReplaceWith = new System.Windows.Forms.Label();
            this.textBox_FindWhat = new System.Windows.Forms.TextBox();
            this.textBox_ReplaceWith = new System.Windows.Forms.TextBox();
            this.button_NextUp = new System.Windows.Forms.Button();
            this.button_NextDown = new System.Windows.Forms.Button();
            this.button_Replace = new System.Windows.Forms.Button();
            this.button_ReplaceAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_FindWhat
            // 
            this.label_FindWhat.AutoSize = true;
            this.label_FindWhat.Location = new System.Drawing.Point(33, 20);
            this.label_FindWhat.Name = "label_FindWhat";
            this.label_FindWhat.Size = new System.Drawing.Size(87, 15);
            this.label_FindWhat.TabIndex = 0;
            this.label_FindWhat.Text = "Find What:";
            this.label_FindWhat.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label_ReplaceWith
            // 
            this.label_ReplaceWith.AutoSize = true;
            this.label_ReplaceWith.Cursor = System.Windows.Forms.Cursors.Default;
            this.label_ReplaceWith.Location = new System.Drawing.Point(10, 62);
            this.label_ReplaceWith.Name = "label_ReplaceWith";
            this.label_ReplaceWith.Size = new System.Drawing.Size(111, 15);
            this.label_ReplaceWith.TabIndex = 1;
            this.label_ReplaceWith.Text = "Replace With:";
            this.label_ReplaceWith.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox_FindWhat
            // 
            this.textBox_FindWhat.Location = new System.Drawing.Point(126, 16);
            this.textBox_FindWhat.Name = "textBox_FindWhat";
            this.textBox_FindWhat.Size = new System.Drawing.Size(220, 25);
            this.textBox_FindWhat.TabIndex = 2;
            // 
            // textBox_ReplaceWith
            // 
            this.textBox_ReplaceWith.Location = new System.Drawing.Point(126, 59);
            this.textBox_ReplaceWith.Name = "textBox_ReplaceWith";
            this.textBox_ReplaceWith.Size = new System.Drawing.Size(220, 25);
            this.textBox_ReplaceWith.TabIndex = 3;
            // 
            // button_NextUp
            // 
            this.button_NextUp.Location = new System.Drawing.Point(20, 97);
            this.button_NextUp.Name = "button_NextUp";
            this.button_NextUp.Size = new System.Drawing.Size(125, 30);
            this.button_NextUp.TabIndex = 4;
            this.button_NextUp.Text = "<< Next";
            this.button_NextUp.UseVisualStyleBackColor = true;
            this.button_NextUp.Click += new System.EventHandler(this.button_NextUp_Click);
            // 
            // button_NextDown
            // 
            this.button_NextDown.Location = new System.Drawing.Point(215, 97);
            this.button_NextDown.Name = "button_NextDown";
            this.button_NextDown.Size = new System.Drawing.Size(125, 30);
            this.button_NextDown.TabIndex = 5;
            this.button_NextDown.Text = "Next >>";
            this.button_NextDown.UseVisualStyleBackColor = true;
            this.button_NextDown.Click += new System.EventHandler(this.button_NextDown_Click);
            // 
            // button_Replace
            // 
            this.button_Replace.Location = new System.Drawing.Point(20, 140);
            this.button_Replace.Name = "button_Replace";
            this.button_Replace.Size = new System.Drawing.Size(125, 30);
            this.button_Replace.TabIndex = 6;
            this.button_Replace.Text = "Replace";
            this.button_Replace.UseVisualStyleBackColor = true;
            this.button_Replace.Click += new System.EventHandler(this.button_Replace_Click);
            // 
            // button_ReplaceAll
            // 
            this.button_ReplaceAll.Location = new System.Drawing.Point(215, 140);
            this.button_ReplaceAll.Name = "button_ReplaceAll";
            this.button_ReplaceAll.Size = new System.Drawing.Size(125, 30);
            this.button_ReplaceAll.TabIndex = 7;
            this.button_ReplaceAll.Text = "ReplaceAll";
            this.button_ReplaceAll.UseVisualStyleBackColor = true;
            this.button_ReplaceAll.Click += new System.EventHandler(this.button_ReplaceAll_Click);
            // 
            // ReplaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 183);
            this.Controls.Add(this.button_ReplaceAll);
            this.Controls.Add(this.button_Replace);
            this.Controls.Add(this.button_NextDown);
            this.Controls.Add(this.button_NextUp);
            this.Controls.Add(this.textBox_ReplaceWith);
            this.Controls.Add(this.textBox_FindWhat);
            this.Controls.Add(this.label_ReplaceWith);
            this.Controls.Add(this.label_FindWhat);
            this.Name = "ReplaceForm";
            this.Text = "Replace";
            this.Load += new System.EventHandler(this.Form_Replace_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_FindWhat;
        private System.Windows.Forms.Label label_ReplaceWith;
        private System.Windows.Forms.TextBox textBox_FindWhat;
        private System.Windows.Forms.TextBox textBox_ReplaceWith;
        private System.Windows.Forms.Button button_NextUp;
        private System.Windows.Forms.Button button_NextDown;
        private System.Windows.Forms.Button button_Replace;
        private System.Windows.Forms.Button button_ReplaceAll;
    }
}