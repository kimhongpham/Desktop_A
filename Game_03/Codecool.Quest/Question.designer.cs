namespace quizGame
{
    partial class Question
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.rad_A = new System.Windows.Forms.RadioButton();
            this.rad_B = new System.Windows.Forms.RadioButton();
            this.rad_C = new System.Windows.Forms.RadioButton();
            this.rad_D = new System.Windows.Forms.RadioButton();
            this.comboBoxMon = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Cornsilk;
            this.pictureBox1.Location = new System.Drawing.Point(22, 105);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(362, 214);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(407, 256);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 49);
            this.button1.TabIndex = 1;
            this.button1.Tag = "1";
            this.button1.Text = "Trả Lời";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ClickAnswerEvent);
            // 
            // lblQuestion
            // 
            this.lblQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion.Location = new System.Drawing.Point(18, 19);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(366, 56);
            this.lblQuestion.TabIndex = 2;
            this.lblQuestion.Text = "Câu hỏi";
            this.lblQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblQuestion.Click += new System.EventHandler(this.lblQuestion_Click);
            // 
            // rad_A
            // 
            this.rad_A.AutoSize = true;
            this.rad_A.Location = new System.Drawing.Point(407, 105);
            this.rad_A.Name = "rad_A";
            this.rad_A.Size = new System.Drawing.Size(85, 17);
            this.rad_A.TabIndex = 5;
            this.rad_A.TabStop = true;
            this.rad_A.Text = "radioButton1";
            this.rad_A.UseVisualStyleBackColor = true;
            this.rad_A.CheckedChanged += new System.EventHandler(this.rad_A_CheckedChanged);
            // 
            // rad_B
            // 
            this.rad_B.AutoSize = true;
            this.rad_B.Location = new System.Drawing.Point(407, 145);
            this.rad_B.Name = "rad_B";
            this.rad_B.Size = new System.Drawing.Size(85, 17);
            this.rad_B.TabIndex = 6;
            this.rad_B.TabStop = true;
            this.rad_B.Text = "radioButton2";
            this.rad_B.UseVisualStyleBackColor = true;
            // 
            // rad_C
            // 
            this.rad_C.AutoSize = true;
            this.rad_C.Location = new System.Drawing.Point(407, 187);
            this.rad_C.Name = "rad_C";
            this.rad_C.Size = new System.Drawing.Size(85, 17);
            this.rad_C.TabIndex = 7;
            this.rad_C.TabStop = true;
            this.rad_C.Text = "radioButton3";
            this.rad_C.UseVisualStyleBackColor = true;
            // 
            // rad_D
            // 
            this.rad_D.AutoSize = true;
            this.rad_D.Location = new System.Drawing.Point(407, 224);
            this.rad_D.Name = "rad_D";
            this.rad_D.Size = new System.Drawing.Size(85, 17);
            this.rad_D.TabIndex = 8;
            this.rad_D.TabStop = true;
            this.rad_D.Text = "radioButton4";
            this.rad_D.UseVisualStyleBackColor = true;
            // 
            // comboBoxMon
            // 
            this.comboBoxMon.FormattingEnabled = true;
            this.comboBoxMon.Items.AddRange(new object[] {
            "OOP",
            "Phát triển ứng dụng desktop"});
            this.comboBoxMon.Location = new System.Drawing.Point(562, 12);
            this.comboBoxMon.Name = "comboBoxMon";
            this.comboBoxMon.Size = new System.Drawing.Size(10, 21);
            this.comboBoxMon.TabIndex = 4;
            this.comboBoxMon.SelectedIndexChanged += new System.EventHandler(this.comboBoxMon_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Question
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 347);
            this.Controls.Add(this.rad_D);
            this.Controls.Add(this.rad_C);
            this.Controls.Add(this.rad_B);
            this.Controls.Add(this.rad_A);
            this.Controls.Add(this.comboBoxMon);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Question";
            this.Text = "Simple Quiz Game MOO ICT";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Question_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblQuestion;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RadioButton rad_A;
        private System.Windows.Forms.RadioButton rad_B;
        private System.Windows.Forms.RadioButton rad_C;
        private System.Windows.Forms.RadioButton rad_D;
        private System.Windows.Forms.ComboBox comboBoxMon;
        private System.Windows.Forms.Timer timer1;
    }
}

