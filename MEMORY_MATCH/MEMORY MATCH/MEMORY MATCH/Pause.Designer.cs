namespace MEMORY_MATCH
{
    partial class Pause
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_playagain_pause = new Guna.UI2.WinForms.Guna2Button();
            this.btn_continue_pause = new Guna.UI2.WinForms.Guna2Button();
            this.btn_quit_pause = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "PAUSE";
            // 
            // btn_playagain_pause
            // 
            this.btn_playagain_pause.BackColor = System.Drawing.Color.Transparent;
            this.btn_playagain_pause.BorderRadius = 20;
            this.btn_playagain_pause.BorderThickness = 2;
            this.btn_playagain_pause.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_playagain_pause.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_playagain_pause.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_playagain_pause.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_playagain_pause.FillColor = System.Drawing.Color.OldLace;
            this.btn_playagain_pause.Font = new System.Drawing.Font("Segoe Script", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_playagain_pause.ForeColor = System.Drawing.Color.ForestGreen;
            this.btn_playagain_pause.Location = new System.Drawing.Point(32, 88);
            this.btn_playagain_pause.Name = "btn_playagain_pause";
            this.btn_playagain_pause.Size = new System.Drawing.Size(178, 44);
            this.btn_playagain_pause.TabIndex = 3;
            this.btn_playagain_pause.Text = "Play Again";
            // 
            // btn_continue_pause
            // 
            this.btn_continue_pause.BackColor = System.Drawing.Color.Transparent;
            this.btn_continue_pause.BorderRadius = 20;
            this.btn_continue_pause.BorderThickness = 2;
            this.btn_continue_pause.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_continue_pause.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_continue_pause.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_continue_pause.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_continue_pause.FillColor = System.Drawing.Color.OldLace;
            this.btn_continue_pause.Font = new System.Drawing.Font("Segoe Script", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_continue_pause.ForeColor = System.Drawing.Color.ForestGreen;
            this.btn_continue_pause.Location = new System.Drawing.Point(32, 150);
            this.btn_continue_pause.Name = "btn_continue_pause";
            this.btn_continue_pause.Size = new System.Drawing.Size(178, 44);
            this.btn_continue_pause.TabIndex = 4;
            this.btn_continue_pause.Text = "Continue";
            // 
            // btn_quit_pause
            // 
            this.btn_quit_pause.BackColor = System.Drawing.Color.Transparent;
            this.btn_quit_pause.BorderRadius = 20;
            this.btn_quit_pause.BorderThickness = 2;
            this.btn_quit_pause.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_quit_pause.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_quit_pause.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_quit_pause.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_quit_pause.FillColor = System.Drawing.Color.OldLace;
            this.btn_quit_pause.Font = new System.Drawing.Font("Segoe Script", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_quit_pause.ForeColor = System.Drawing.Color.ForestGreen;
            this.btn_quit_pause.Location = new System.Drawing.Point(32, 211);
            this.btn_quit_pause.Name = "btn_quit_pause";
            this.btn_quit_pause.Size = new System.Drawing.Size(178, 44);
            this.btn_quit_pause.TabIndex = 5;
            this.btn_quit_pause.Text = "Quit";
            // 
            // Pause
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(250, 300);
            this.Controls.Add(this.btn_quit_pause);
            this.Controls.Add(this.btn_continue_pause);
            this.Controls.Add(this.btn_playagain_pause);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Pause";
            this.Text = "Pause";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btn_playagain_pause;
        private Guna.UI2.WinForms.Guna2Button btn_continue_pause;
        private Guna.UI2.WinForms.Guna2Button btn_quit_pause;
    }
}