namespace MEMORY_MATCH
{
    partial class Setting
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
            this.lbl_setting = new System.Windows.Forms.Label();
            this.lbl_sound = new System.Windows.Forms.Label();
            this.lbl_volume = new System.Windows.Forms.Label();
            this.rdb_on = new System.Windows.Forms.RadioButton();
            this.rdb_off = new System.Windows.Forms.RadioButton();
            this.volumetrackbar = new Guna.UI2.WinForms.Guna2TrackBar();
            this.btn_exit_setting = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // lbl_setting
            // 
            this.lbl_setting.AutoSize = true;
            this.lbl_setting.BackColor = System.Drawing.Color.Transparent;
            this.lbl_setting.Font = new System.Drawing.Font("Segoe Script", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_setting.Location = new System.Drawing.Point(152, 13);
            this.lbl_setting.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_setting.Name = "lbl_setting";
            this.lbl_setting.Size = new System.Drawing.Size(290, 87);
            this.lbl_setting.TabIndex = 0;
            this.lbl_setting.Text = "SETTING";
            // 
            // lbl_sound
            // 
            this.lbl_sound.AutoSize = true;
            this.lbl_sound.BackColor = System.Drawing.Color.Transparent;
            this.lbl_sound.Font = new System.Drawing.Font("Segoe Script", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sound.Location = new System.Drawing.Point(18, 104);
            this.lbl_sound.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_sound.Name = "lbl_sound";
            this.lbl_sound.Size = new System.Drawing.Size(196, 80);
            this.lbl_sound.TabIndex = 1;
            this.lbl_sound.Text = "Sound";
            // 
            // lbl_volume
            // 
            this.lbl_volume.AutoSize = true;
            this.lbl_volume.BackColor = System.Drawing.Color.Transparent;
            this.lbl_volume.Font = new System.Drawing.Font("Segoe Script", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_volume.Location = new System.Drawing.Point(18, 181);
            this.lbl_volume.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_volume.Name = "lbl_volume";
            this.lbl_volume.Size = new System.Drawing.Size(220, 80);
            this.lbl_volume.TabIndex = 2;
            this.lbl_volume.Text = "Volume";
            // 
            // rdb_on
            // 
            this.rdb_on.AutoSize = true;
            this.rdb_on.BackColor = System.Drawing.Color.Transparent;
            this.rdb_on.Font = new System.Drawing.Font("Segoe Script", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb_on.Location = new System.Drawing.Point(268, 108);
            this.rdb_on.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.rdb_on.Name = "rdb_on";
            this.rdb_on.Size = new System.Drawing.Size(130, 77);
            this.rdb_on.TabIndex = 3;
            this.rdb_on.TabStop = true;
            this.rdb_on.Text = "On";
            this.rdb_on.UseVisualStyleBackColor = false;
            this.rdb_on.CheckedChanged += new System.EventHandler(this.rdb_on_CheckedChanged);
            // 
            // rdb_off
            // 
            this.rdb_off.AutoSize = true;
            this.rdb_off.BackColor = System.Drawing.Color.Transparent;
            this.rdb_off.Font = new System.Drawing.Font("Segoe Script", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb_off.Location = new System.Drawing.Point(404, 108);
            this.rdb_off.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.rdb_off.Name = "rdb_off";
            this.rdb_off.Size = new System.Drawing.Size(133, 77);
            this.rdb_off.TabIndex = 4;
            this.rdb_off.TabStop = true;
            this.rdb_off.Text = "Off";
            this.rdb_off.UseVisualStyleBackColor = false;
            this.rdb_off.CheckedChanged += new System.EventHandler(this.rdb_off_CheckedChanged);
            // 
            // volumetrackbar
            // 
            this.volumetrackbar.BackColor = System.Drawing.Color.Transparent;
            this.volumetrackbar.Location = new System.Drawing.Point(268, 210);
            this.volumetrackbar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.volumetrackbar.Name = "volumetrackbar";
            this.volumetrackbar.Size = new System.Drawing.Size(286, 37);
            this.volumetrackbar.TabIndex = 5;
            this.volumetrackbar.ThumbColor = System.Drawing.Color.Green;
            this.volumetrackbar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.volumetrackbar_Scroll);
            // 
            // btn_exit_setting
            // 
            this.btn_exit_setting.BackColor = System.Drawing.Color.Transparent;
            this.btn_exit_setting.BorderRadius = 19;
            this.btn_exit_setting.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btn_exit_setting.BorderThickness = 2;
            this.btn_exit_setting.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_exit_setting.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_exit_setting.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_exit_setting.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_exit_setting.FillColor = System.Drawing.Color.OldLace;
            this.btn_exit_setting.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit_setting.ForeColor = System.Drawing.Color.Red;
            this.btn_exit_setting.Location = new System.Drawing.Point(510, 13);
            this.btn_exit_setting.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_exit_setting.Name = "btn_exit_setting";
            this.btn_exit_setting.Size = new System.Drawing.Size(72, 73);
            this.btn_exit_setting.TabIndex = 6;
            this.btn_exit_setting.Text = "X";
            this.btn_exit_setting.Click += new System.EventHandler(this.btn_exit_setting_Click);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(600, 312);
            this.Controls.Add(this.btn_exit_setting);
            this.Controls.Add(this.volumetrackbar);
            this.Controls.Add(this.rdb_off);
            this.Controls.Add(this.rdb_on);
            this.Controls.Add(this.lbl_volume);
            this.Controls.Add(this.lbl_sound);
            this.Controls.Add(this.lbl_setting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_setting;
        private System.Windows.Forms.Label lbl_sound;
        private System.Windows.Forms.Label lbl_volume;
        private System.Windows.Forms.RadioButton rdb_on;
        private System.Windows.Forms.RadioButton rdb_off;
        private Guna.UI2.WinForms.Guna2TrackBar volumetrackbar;
        private Guna.UI2.WinForms.Guna2Button btn_exit_setting;
    }
}