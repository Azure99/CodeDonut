namespace CodeDonut
{
    partial class ACMModeForm
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
            this.label_Path = new System.Windows.Forms.Label();
            this.textBox_Path = new System.Windows.Forms.TextBox();
            this.label_InPut = new System.Windows.Forms.Label();
            this.textBox_InPut = new System.Windows.Forms.TextBox();
            this.label_OutPut = new System.Windows.Forms.Label();
            this.textBox_OutPut = new System.Windows.Forms.TextBox();
            this.button_Run = new System.Windows.Forms.Button();
            this.label_Status = new System.Windows.Forms.Label();
            this.label_Time = new System.Windows.Forms.Label();
            this.label_Memory = new System.Windows.Forms.Label();
            this.label_TimeLimit = new System.Windows.Forms.Label();
            this.textBox_TimeLimit = new System.Windows.Forms.TextBox();
            this.panel_Info = new System.Windows.Forms.Panel();
            this.label_Judging = new System.Windows.Forms.Label();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.backgroundWorker_Main = new System.ComponentModel.BackgroundWorker();
            this.panel_Info.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Path
            // 
            this.label_Path.AutoSize = true;
            this.label_Path.Location = new System.Drawing.Point(10, 24);
            this.label_Path.Name = "label_Path";
            this.label_Path.Size = new System.Drawing.Size(47, 15);
            this.label_Path.TabIndex = 0;
            this.label_Path.Text = "Path:";
            // 
            // textBox_Path
            // 
            this.textBox_Path.Location = new System.Drawing.Point(65, 21);
            this.textBox_Path.Name = "textBox_Path";
            this.textBox_Path.Size = new System.Drawing.Size(400, 25);
            this.textBox_Path.TabIndex = 1;
            // 
            // label_InPut
            // 
            this.label_InPut.AutoSize = true;
            this.label_InPut.Location = new System.Drawing.Point(10, 65);
            this.label_InPut.Name = "label_InPut";
            this.label_InPut.Size = new System.Drawing.Size(55, 15);
            this.label_InPut.TabIndex = 2;
            this.label_InPut.Text = "InPut:";
            // 
            // textBox_InPut
            // 
            this.textBox_InPut.Location = new System.Drawing.Point(10, 99);
            this.textBox_InPut.MaxLength = 8388352;
            this.textBox_InPut.Multiline = true;
            this.textBox_InPut.Name = "textBox_InPut";
            this.textBox_InPut.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_InPut.Size = new System.Drawing.Size(455, 225);
            this.textBox_InPut.TabIndex = 3;
            // 
            // label_OutPut
            // 
            this.label_OutPut.AutoSize = true;
            this.label_OutPut.Location = new System.Drawing.Point(10, 340);
            this.label_OutPut.Name = "label_OutPut";
            this.label_OutPut.Size = new System.Drawing.Size(63, 15);
            this.label_OutPut.TabIndex = 4;
            this.label_OutPut.Text = "OutPut:";
            // 
            // textBox_OutPut
            // 
            this.textBox_OutPut.Location = new System.Drawing.Point(10, 370);
            this.textBox_OutPut.MaxLength = 8388352;
            this.textBox_OutPut.Multiline = true;
            this.textBox_OutPut.Name = "textBox_OutPut";
            this.textBox_OutPut.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_OutPut.Size = new System.Drawing.Size(455, 225);
            this.textBox_OutPut.TabIndex = 5;
            // 
            // button_Run
            // 
            this.button_Run.Location = new System.Drawing.Point(10, 611);
            this.button_Run.Name = "button_Run";
            this.button_Run.Size = new System.Drawing.Size(100, 25);
            this.button_Run.TabIndex = 6;
            this.button_Run.Text = "Run";
            this.button_Run.UseVisualStyleBackColor = true;
            this.button_Run.Click += new System.EventHandler(this.button_Run_Click);
            // 
            // label_Status
            // 
            this.label_Status.AutoSize = true;
            this.label_Status.ForeColor = System.Drawing.Color.Black;
            this.label_Status.Location = new System.Drawing.Point(118, 616);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(71, 15);
            this.label_Status.TabIndex = 7;
            this.label_Status.Text = "Unjudged";
            // 
            // label_Time
            // 
            this.label_Time.AutoSize = true;
            this.label_Time.Location = new System.Drawing.Point(276, 617);
            this.label_Time.Name = "label_Time";
            this.label_Time.Size = new System.Drawing.Size(71, 15);
            this.label_Time.TabIndex = 8;
            this.label_Time.Text = "Time:0ms";
            // 
            // label_Memory
            // 
            this.label_Memory.AutoSize = true;
            this.label_Memory.Location = new System.Drawing.Point(366, 617);
            this.label_Memory.Name = "label_Memory";
            this.label_Memory.Size = new System.Drawing.Size(63, 15);
            this.label_Memory.TabIndex = 9;
            this.label_Memory.Text = "Mem:0KB";
            // 
            // label_TimeLimit
            // 
            this.label_TimeLimit.AutoSize = true;
            this.label_TimeLimit.Location = new System.Drawing.Point(301, 65);
            this.label_TimeLimit.Name = "label_TimeLimit";
            this.label_TimeLimit.Size = new System.Drawing.Size(95, 15);
            this.label_TimeLimit.TabIndex = 10;
            this.label_TimeLimit.Text = "Time Limit:";
            // 
            // textBox_TimeLimit
            // 
            this.textBox_TimeLimit.Location = new System.Drawing.Point(400, 59);
            this.textBox_TimeLimit.Name = "textBox_TimeLimit";
            this.textBox_TimeLimit.Size = new System.Drawing.Size(65, 25);
            this.textBox_TimeLimit.TabIndex = 11;
            this.textBox_TimeLimit.Text = "1000";
            // 
            // panel_Info
            // 
            this.panel_Info.Controls.Add(this.label_Judging);
            this.panel_Info.Controls.Add(this.button_Cancel);
            this.panel_Info.Location = new System.Drawing.Point(65, 218);
            this.panel_Info.Name = "panel_Info";
            this.panel_Info.Size = new System.Drawing.Size(330, 180);
            this.panel_Info.TabIndex = 13;
            this.panel_Info.Visible = false;
            // 
            // label_Judging
            // 
            this.label_Judging.AutoSize = true;
            this.label_Judging.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Judging.ForeColor = System.Drawing.Color.OrangeRed;
            this.label_Judging.Location = new System.Drawing.Point(81, 44);
            this.label_Judging.Name = "label_Judging";
            this.label_Judging.Size = new System.Drawing.Size(162, 28);
            this.label_Judging.TabIndex = 1;
            this.label_Judging.Text = "Judging...";
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(93, 107);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(150, 45);
            this.button_Cancel.TabIndex = 0;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // backgroundWorker_Main
            // 
            this.backgroundWorker_Main.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_Main_DoWork);
            this.backgroundWorker_Main.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_Main_RunWorkerCompleted);
            // 
            // ACMModeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 653);
            this.Controls.Add(this.panel_Info);
            this.Controls.Add(this.textBox_TimeLimit);
            this.Controls.Add(this.label_TimeLimit);
            this.Controls.Add(this.label_Memory);
            this.Controls.Add(this.label_Time);
            this.Controls.Add(this.label_Status);
            this.Controls.Add(this.button_Run);
            this.Controls.Add(this.textBox_OutPut);
            this.Controls.Add(this.label_OutPut);
            this.Controls.Add(this.textBox_InPut);
            this.Controls.Add(this.label_InPut);
            this.Controls.Add(this.textBox_Path);
            this.Controls.Add(this.label_Path);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ACMModeForm";
            this.Text = "Run in ACM mode";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_ACMMode_FormClosed);
            this.Load += new System.EventHandler(this.Form_ACMMode_Load);
            this.panel_Info.ResumeLayout(false);
            this.panel_Info.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Path;
        private System.Windows.Forms.TextBox textBox_Path;
        private System.Windows.Forms.Label label_InPut;
        private System.Windows.Forms.TextBox textBox_InPut;
        private System.Windows.Forms.Label label_OutPut;
        private System.Windows.Forms.TextBox textBox_OutPut;
        private System.Windows.Forms.Button button_Run;
        private System.Windows.Forms.Label label_Status;
        private System.Windows.Forms.Label label_Time;
        private System.Windows.Forms.Label label_Memory;
        private System.Windows.Forms.Label label_TimeLimit;
        private System.Windows.Forms.TextBox textBox_TimeLimit;
        private System.Windows.Forms.Panel panel_Info;
        private System.Windows.Forms.Label label_Judging;
        private System.Windows.Forms.Button button_Cancel;
        private System.ComponentModel.BackgroundWorker backgroundWorker_Main;
    }
}