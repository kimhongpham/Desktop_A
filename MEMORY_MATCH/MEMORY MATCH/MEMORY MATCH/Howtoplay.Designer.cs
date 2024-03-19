namespace MEMORY_MATCH
{
    partial class Howtoplay
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
            this.btn_exit_htp = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "HOW TO PLAY";
            // 
            // btn_exit_htp
            // 
            this.btn_exit_htp.BackColor = System.Drawing.Color.Transparent;
            this.btn_exit_htp.BorderRadius = 19;
            this.btn_exit_htp.BorderThickness = 2;
            this.btn_exit_htp.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_exit_htp.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_exit_htp.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_exit_htp.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_exit_htp.FillColor = System.Drawing.Color.OldLace;
            this.btn_exit_htp.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit_htp.ForeColor = System.Drawing.Color.Red;
            this.btn_exit_htp.Location = new System.Drawing.Point(398, 12);
            this.btn_exit_htp.Name = "btn_exit_htp";
            this.btn_exit_htp.Size = new System.Drawing.Size(40, 40);
            this.btn_exit_htp.TabIndex = 1;
            this.btn_exit_htp.Text = "X";
            // 
            // Howtoplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(450, 250);
            this.Controls.Add(this.btn_exit_htp);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Howtoplay";
            this.Text = "Howtoplay";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btn_exit_htp;
    }
}