using System;
using System.Windows.Forms;

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
            this.l87_htp = new System.Windows.Forms.Label();
            this.lbl_htp2 = new System.Windows.Forms.Label();
            this.lbl_htp3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 44);
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
            this.btn_exit_htp.Location = new System.Drawing.Point(300, 10);
            this.btn_exit_htp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_exit_htp.Name = "btn_exit_htp";
            this.btn_exit_htp.Size = new System.Drawing.Size(37, 41);
            this.btn_exit_htp.TabIndex = 1;
            this.btn_exit_htp.Text = "X";
            this.btn_exit_htp.Click += new System.EventHandler(this.btn_exit_htp_Click);
            // 
            // l87_htp
            // 
            this.l87_htp.AutoSize = true;
            this.l87_htp.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.l87_htp.Location = new System.Drawing.Point(59, 81);
            this.l87_htp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l87_htp.Name = "l87_htp";
            this.l87_htp.Size = new System.Drawing.Size(267, 24);
            this.l87_htp.TabIndex = 2;
            this.l87_htp.Text = "Hãy sử dụng chuột để lật hình ";
            this.l87_htp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_htp2
            // 
            this.lbl_htp2.AutoSize = true;
            this.lbl_htp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_htp2.Location = new System.Drawing.Point(42, 115);
            this.lbl_htp2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_htp2.Name = "lbl_htp2";
            this.lbl_htp2.Size = new System.Drawing.Size(302, 24);
            this.lbl_htp2.TabIndex = 3;
            this.lbl_htp2.Text = "và tìm những cặp hình giống nhau ";
            // 
            // lbl_htp3
            // 
            this.lbl_htp3.AutoSize = true;
            this.lbl_htp3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_htp3.Location = new System.Drawing.Point(52, 147);
            this.lbl_htp3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_htp3.Name = "lbl_htp3";
            this.lbl_htp3.Size = new System.Drawing.Size(278, 24);
            this.lbl_htp3.TabIndex = 4;
            this.lbl_htp3.Text = "để vượt qua tất cả các màn nhé.";
            // 
            // Howtoplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(361, 213);
            this.Controls.Add(this.lbl_htp3);
            this.Controls.Add(this.lbl_htp2);
            this.Controls.Add(this.l87_htp);
            this.Controls.Add(this.btn_exit_htp);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Howtoplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Howtoplay";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
       
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btn_exit_htp;
        private Label l87_htp;
        private Label lbl_htp2;
        private Label lbl_htp3;
    }
}