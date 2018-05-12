namespace CodeDonut
{
    partial class MultipleCasesTestForm
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
            this.label_ProgramPath = new System.Windows.Forms.Label();
            this.label_InputPath = new System.Windows.Forms.Label();
            this.label_OutPutPath = new System.Windows.Forms.Label();
            this.textBox_ProgramPath = new System.Windows.Forms.TextBox();
            this.textBox_InputPath = new System.Windows.Forms.TextBox();
            this.textBox_OutputPath = new System.Windows.Forms.TextBox();
            this.button_SelectProgram = new System.Windows.Forms.Button();
            this.button_SelectInput = new System.Windows.Forms.Button();
            this.button_SelectOutput = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_TimeLimit = new System.Windows.Forms.TextBox();
            this.label_MS = new System.Windows.Forms.Label();
            this.button_FAQ = new System.Windows.Forms.Button();
            this.button_StartJudge = new System.Windows.Forms.Button();
            this.backgroundWorker_Main = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // label_ProgramPath
            // 
            this.label_ProgramPath.AutoSize = true;
            this.label_ProgramPath.Location = new System.Drawing.Point(12, 19);
            this.label_ProgramPath.Name = "label_ProgramPath";
            this.label_ProgramPath.Size = new System.Drawing.Size(111, 15);
            this.label_ProgramPath.TabIndex = 0;
            this.label_ProgramPath.Text = "Program Path:";
            // 
            // label_InputPath
            // 
            this.label_InputPath.AutoSize = true;
            this.label_InputPath.Location = new System.Drawing.Point(12, 89);
            this.label_InputPath.Name = "label_InputPath";
            this.label_InputPath.Size = new System.Drawing.Size(95, 15);
            this.label_InputPath.TabIndex = 1;
            this.label_InputPath.Text = "Input Path:";
            // 
            // label_OutPutPath
            // 
            this.label_OutPutPath.AutoSize = true;
            this.label_OutPutPath.Location = new System.Drawing.Point(12, 164);
            this.label_OutPutPath.Name = "label_OutPutPath";
            this.label_OutPutPath.Size = new System.Drawing.Size(103, 15);
            this.label_OutPutPath.TabIndex = 2;
            this.label_OutPutPath.Text = "Output Path:";
            // 
            // textBox_ProgramPath
            // 
            this.textBox_ProgramPath.Location = new System.Drawing.Point(15, 45);
            this.textBox_ProgramPath.Name = "textBox_ProgramPath";
            this.textBox_ProgramPath.Size = new System.Drawing.Size(455, 25);
            this.textBox_ProgramPath.TabIndex = 3;
            // 
            // textBox_InputPath
            // 
            this.textBox_InputPath.Location = new System.Drawing.Point(15, 120);
            this.textBox_InputPath.Name = "textBox_InputPath";
            this.textBox_InputPath.Size = new System.Drawing.Size(455, 25);
            this.textBox_InputPath.TabIndex = 4;
            this.textBox_InputPath.Text = "C:\\Users\\96152\\Downloads\\Compressed\\1058\\input";
            // 
            // textBox_OutputPath
            // 
            this.textBox_OutputPath.Location = new System.Drawing.Point(15, 195);
            this.textBox_OutputPath.Name = "textBox_OutputPath";
            this.textBox_OutputPath.Size = new System.Drawing.Size(455, 25);
            this.textBox_OutputPath.TabIndex = 5;
            this.textBox_OutputPath.Text = "C:\\Users\\96152\\Downloads\\Compressed\\1058\\output";
            // 
            // button_SelectProgram
            // 
            this.button_SelectProgram.Location = new System.Drawing.Point(370, 9);
            this.button_SelectProgram.Name = "button_SelectProgram";
            this.button_SelectProgram.Size = new System.Drawing.Size(100, 30);
            this.button_SelectProgram.TabIndex = 6;
            this.button_SelectProgram.Text = "Select";
            this.button_SelectProgram.UseVisualStyleBackColor = true;
            this.button_SelectProgram.Click += new System.EventHandler(this.button_SelectProgram_Click);
            // 
            // button_SelectInput
            // 
            this.button_SelectInput.Location = new System.Drawing.Point(370, 81);
            this.button_SelectInput.Name = "button_SelectInput";
            this.button_SelectInput.Size = new System.Drawing.Size(100, 30);
            this.button_SelectInput.TabIndex = 7;
            this.button_SelectInput.Text = "Select";
            this.button_SelectInput.UseVisualStyleBackColor = true;
            this.button_SelectInput.Click += new System.EventHandler(this.button_SelectInput_Click);
            // 
            // button_SelectOutput
            // 
            this.button_SelectOutput.Location = new System.Drawing.Point(370, 156);
            this.button_SelectOutput.Name = "button_SelectOutput";
            this.button_SelectOutput.Size = new System.Drawing.Size(100, 30);
            this.button_SelectOutput.TabIndex = 8;
            this.button_SelectOutput.Text = "Select";
            this.button_SelectOutput.UseVisualStyleBackColor = true;
            this.button_SelectOutput.Click += new System.EventHandler(this.button_SelectOutput_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "TimeLimit:";
            // 
            // textBox_TimeLimit
            // 
            this.textBox_TimeLimit.Location = new System.Drawing.Point(105, 240);
            this.textBox_TimeLimit.Name = "textBox_TimeLimit";
            this.textBox_TimeLimit.Size = new System.Drawing.Size(100, 25);
            this.textBox_TimeLimit.TabIndex = 10;
            this.textBox_TimeLimit.Text = "2000";
            // 
            // label_MS
            // 
            this.label_MS.AutoSize = true;
            this.label_MS.Location = new System.Drawing.Point(211, 243);
            this.label_MS.Name = "label_MS";
            this.label_MS.Size = new System.Drawing.Size(23, 15);
            this.label_MS.TabIndex = 11;
            this.label_MS.Text = "ms";
            // 
            // button_FAQ
            // 
            this.button_FAQ.Location = new System.Drawing.Point(395, 240);
            this.button_FAQ.Name = "button_FAQ";
            this.button_FAQ.Size = new System.Drawing.Size(75, 23);
            this.button_FAQ.TabIndex = 12;
            this.button_FAQ.Text = "FAQ";
            this.button_FAQ.UseVisualStyleBackColor = true;
            // 
            // button_StartJudge
            // 
            this.button_StartJudge.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_StartJudge.Location = new System.Drawing.Point(60, 305);
            this.button_StartJudge.Name = "button_StartJudge";
            this.button_StartJudge.Size = new System.Drawing.Size(360, 120);
            this.button_StartJudge.TabIndex = 13;
            this.button_StartJudge.Text = "Start Judge";
            this.button_StartJudge.UseVisualStyleBackColor = true;
            this.button_StartJudge.Click += new System.EventHandler(this.button_StartJudge_Click);
            // 
            // backgroundWorker_Main
            // 
            this.backgroundWorker_Main.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_Main_DoWork);
            this.backgroundWorker_Main.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_Main_RunWorkerCompleted);
            // 
            // MultipleCasesTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 453);
            this.Controls.Add(this.button_StartJudge);
            this.Controls.Add(this.button_FAQ);
            this.Controls.Add(this.label_MS);
            this.Controls.Add(this.textBox_TimeLimit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_SelectOutput);
            this.Controls.Add(this.button_SelectInput);
            this.Controls.Add(this.button_SelectProgram);
            this.Controls.Add(this.textBox_OutputPath);
            this.Controls.Add(this.textBox_InputPath);
            this.Controls.Add(this.textBox_ProgramPath);
            this.Controls.Add(this.label_OutPutPath);
            this.Controls.Add(this.label_InputPath);
            this.Controls.Add(this.label_ProgramPath);
            this.Name = "MultipleCasesTestForm";
            this.Text = "Multiple Cases Test";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MultipleCasesTestForm_FormClosed);
            this.Load += new System.EventHandler(this.MultipleCasesTestForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_ProgramPath;
        private System.Windows.Forms.Label label_InputPath;
        private System.Windows.Forms.Label label_OutPutPath;
        private System.Windows.Forms.TextBox textBox_ProgramPath;
        private System.Windows.Forms.TextBox textBox_InputPath;
        private System.Windows.Forms.TextBox textBox_OutputPath;
        private System.Windows.Forms.Button button_SelectProgram;
        private System.Windows.Forms.Button button_SelectInput;
        private System.Windows.Forms.Button button_SelectOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_TimeLimit;
        private System.Windows.Forms.Label label_MS;
        private System.Windows.Forms.Button button_FAQ;
        private System.Windows.Forms.Button button_StartJudge;
        private System.ComponentModel.BackgroundWorker backgroundWorker_Main;
    }
}