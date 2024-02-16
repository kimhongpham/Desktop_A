namespace MEMORY_MATCH
{
    partial class Exit
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
            this.lbl_exit = new System.Windows.Forms.Label();
            this.btn_exit = new Guna.UI2.WinForms.Guna2Button();
            this.btn_yes_exit = new Guna.UI2.WinForms.Guna2Button();
            this.btn_no_exit = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // lbl_exit
            // 
            this.lbl_exit.AutoSize = true;
            this.lbl_exit.BackColor = System.Drawing.Color.Transparent;
            this.lbl_exit.Font = new System.Drawing.Font("Segoe Script", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_exit.Location = new System.Drawing.Point(70, 28);
            this.lbl_exit.Name = "lbl_exit";
            this.lbl_exit.Size = new System.Drawing.Size(253, 92);
            this.lbl_exit.TabIndex = 0;
            this.lbl_exit.Text = "Do you want to\n quit the game?";
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.Transparent;
            this.btn_exit.BorderRadius = 19;
            this.btn_exit.BorderThickness = 2;
            this.btn_exit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_exit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_exit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_exit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_exit.FillColor = System.Drawing.Color.OldLace;
            this.btn_exit.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.ForeColor = System.Drawing.Color.Red;
            this.btn_exit.Location = new System.Drawing.Point(348, 12);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(40, 40);
            this.btn_exit.TabIndex = 1;
            this.btn_exit.Text = "X";
            // 
            // btn_yes_exit
            // 
            this.btn_yes_exit.BackColor = System.Drawing.Color.Transparent;
            this.btn_yes_exit.BorderRadius = 15;
            this.btn_yes_exit.BorderThickness = 2;
            this.btn_yes_exit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_yes_exit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_yes_exit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_yes_exit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_yes_exit.FillColor = System.Drawing.Color.Transparent;
            this.btn_yes_exit.Font = new System.Drawing.Font("Segoe Script", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_yes_exit.ForeColor = System.Drawing.Color.ForestGreen;
            this.btn_yes_exit.Location = new System.Drawing.Point(69, 135);
            this.btn_yes_exit.Name = "btn_yes_exit";
            this.btn_yes_exit.Size = new System.Drawing.Size(84, 40);
            this.btn_yes_exit.TabIndex = 2;
            this.btn_yes_exit.Text = "YES";
            // 
            // btn_no_exit
            // 
            this.btn_no_exit.BackColor = System.Drawing.Color.Transparent;
            this.btn_no_exit.BorderRadius = 15;
            this.btn_no_exit.BorderThickness = 2;
            this.btn_no_exit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_no_exit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_no_exit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_no_exit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_no_exit.FillColor = System.Drawing.Color.Transparent;
            this.btn_no_exit.Font = new System.Drawing.Font("Segoe Script", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_no_exit.ForeColor = System.Drawing.Color.ForestGreen;
            this.btn_no_exit.Location = new System.Drawing.Point(230, 135);
            this.btn_no_exit.Name = "btn_no_exit";
            this.btn_no_exit.Size = new System.Drawing.Size(84, 40);
            this.btn_no_exit.TabIndex = 3;
            this.btn_no_exit.Text = "NO";
            // 
            // Exit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.btn_no_exit);
            this.Controls.Add(this.btn_yes_exit);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.lbl_exit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Exit";
            this.Text = "Exit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_exit;
        private Guna.UI2.WinForms.Guna2Button btn_exit;
        private Guna.UI2.WinForms.Guna2Button btn_yes_exit;
        private Guna.UI2.WinForms.Guna2Button btn_no_exit;
    }
}