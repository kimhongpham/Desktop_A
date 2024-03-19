namespace MEMORY_MATCH
{
    partial class MainGame
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
            this.panel_level = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_score = new Guna.UI2.WinForms.Guna2Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_times = new Guna.UI2.WinForms.Guna2Panel();
            this.lbl_time = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btn_setting = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btn_pause = new Guna.UI2.WinForms.Guna2ImageButton();
            this.panel_level.SuspendLayout();
            this.panel_score.SuspendLayout();
            this.panel_times.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_level
            // 
            this.panel_level.BackColor = System.Drawing.Color.Transparent;
            this.panel_level.BorderColor = System.Drawing.Color.Black;
            this.panel_level.BorderRadius = 20;
            this.panel_level.BorderThickness = 2;
            this.panel_level.Controls.Add(this.label1);
            this.panel_level.Location = new System.Drawing.Point(14, 19);
            this.panel_level.Margin = new System.Windows.Forms.Padding(4);
            this.panel_level.Name = "panel_level";
            this.panel_level.Size = new System.Drawing.Size(126, 129);
            this.panel_level.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 51);
            this.label1.TabIndex = 1;
            this.label1.Text = "Level: ";
            // 
            // panel_score
            // 
            this.panel_score.BackColor = System.Drawing.Color.Transparent;
            this.panel_score.BorderColor = System.Drawing.Color.Black;
            this.panel_score.BorderRadius = 19;
            this.panel_score.BorderThickness = 2;
            this.panel_score.Controls.Add(this.label2);
            this.panel_score.Location = new System.Drawing.Point(148, 19);
            this.panel_score.Margin = new System.Windows.Forms.Padding(4);
            this.panel_score.Name = "panel_score";
            this.panel_score.Size = new System.Drawing.Size(336, 62);
            this.panel_score.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 51);
            this.label2.TabIndex = 1;
            this.label2.Text = "Score: 0";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel_times
            // 
            this.panel_times.BackColor = System.Drawing.Color.Transparent;
            this.panel_times.BorderColor = System.Drawing.Color.Black;
            this.panel_times.BorderRadius = 19;
            this.panel_times.BorderThickness = 2;
            this.panel_times.Controls.Add(this.lbl_time);
            this.panel_times.Location = new System.Drawing.Point(148, 87);
            this.panel_times.Margin = new System.Windows.Forms.Padding(4);
            this.panel_times.Name = "panel_times";
            this.panel_times.Size = new System.Drawing.Size(336, 62);
            this.panel_times.TabIndex = 3;
            // 
            // lbl_time
            // 
            this.lbl_time.AutoSize = true;
            this.lbl_time.BackColor = System.Drawing.Color.Transparent;
            this.lbl_time.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_time.Location = new System.Drawing.Point(4, 8);
            this.lbl_time.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(121, 51);
            this.lbl_time.TabIndex = 1;
            this.lbl_time.Text = "Times";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.Location = new System.Drawing.Point(75, 185);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1150, 508);
            this.guna2Panel1.TabIndex = 4;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // btn_setting
            // 
            this.btn_setting.BackColor = System.Drawing.Color.Transparent;
            this.btn_setting.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btn_setting.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btn_setting.Image = global::MEMORY_MATCH.Properties.Resources.setting;
            this.btn_setting.ImageOffset = new System.Drawing.Point(0, 0);
            this.btn_setting.ImageRotate = 0F;
            this.btn_setting.ImageSize = new System.Drawing.Size(50, 50);
            this.btn_setting.Location = new System.Drawing.Point(1096, 13);
            this.btn_setting.Margin = new System.Windows.Forms.Padding(4);
            this.btn_setting.Name = "btn_setting";
            this.btn_setting.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btn_setting.Size = new System.Drawing.Size(84, 98);
            this.btn_setting.TabIndex = 5;
            this.btn_setting.Click += new System.EventHandler(this.btn_setting_Click);
            // 
            // btn_pause
            // 
            this.btn_pause.BackColor = System.Drawing.Color.Transparent;
            this.btn_pause.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btn_pause.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btn_pause.Image = global::MEMORY_MATCH.Properties.Resources.pause;
            this.btn_pause.ImageOffset = new System.Drawing.Point(0, 0);
            this.btn_pause.ImageRotate = 0F;
            this.btn_pause.ImageSize = new System.Drawing.Size(50, 50);
            this.btn_pause.Location = new System.Drawing.Point(1004, 19);
            this.btn_pause.Margin = new System.Windows.Forms.Padding(4);
            this.btn_pause.Name = "btn_pause";
            this.btn_pause.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btn_pause.Size = new System.Drawing.Size(84, 88);
            this.btn_pause.TabIndex = 6;
            this.btn_pause.Click += new System.EventHandler(this.btn_pause_Click);
            // 
            // MainGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.BackgroundImage = global::MEMORY_MATCH.Properties.Resources.hinhnen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1294, 767);
            this.Controls.Add(this.panel_level);
            this.Controls.Add(this.btn_pause);
            this.Controls.Add(this.btn_setting);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.panel_times);
            this.Controls.Add(this.panel_score);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainGame";
            this.Load += new System.EventHandler(this.MainGame_Load);
            this.panel_level.ResumeLayout(false);
            this.panel_level.PerformLayout();
            this.panel_score.ResumeLayout(false);
            this.panel_score.PerformLayout();
            this.panel_times.ResumeLayout(false);
            this.panel_times.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panel_level;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel panel_score;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Panel panel_times;
        private System.Windows.Forms.Label lbl_time;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2ImageButton btn_setting;
        private Guna.UI2.WinForms.Guna2ImageButton btn_pause;
    }
}