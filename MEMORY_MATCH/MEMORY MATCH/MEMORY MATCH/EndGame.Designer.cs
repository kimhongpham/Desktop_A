namespace MEMORY_MATCH
{
    partial class EndGame
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
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_mainoption = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btn_return = new Guna.UI2.WinForms.Guna2ImageButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "CONGRACULATIONS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Script", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(53, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 46);
            this.label2.TabIndex = 2;
            this.label2.Text = "Score";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(101, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 33);
            this.label4.TabIndex = 4;
            this.label4.Text = "Record";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Script", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(53, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 46);
            this.label3.TabIndex = 5;
            this.label3.Text = "Level";
            // 
            // btn_mainoption
            // 
            this.btn_mainoption.BackColor = System.Drawing.Color.Transparent;
            this.btn_mainoption.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btn_mainoption.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btn_mainoption.Image = global::MEMORY_MATCH.Properties.Resources.home;
            this.btn_mainoption.ImageOffset = new System.Drawing.Point(0, 0);
            this.btn_mainoption.ImageRotate = 0F;
            this.btn_mainoption.ImageSize = new System.Drawing.Size(55, 55);
            this.btn_mainoption.Location = new System.Drawing.Point(118, 188);
            this.btn_mainoption.Name = "btn_mainoption";
            this.btn_mainoption.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btn_mainoption.Size = new System.Drawing.Size(60, 60);
            this.btn_mainoption.TabIndex = 7;
            // 
            // btn_return
            // 
            this.btn_return.BackColor = System.Drawing.Color.Transparent;
            this.btn_return.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btn_return.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btn_return.Image = global::MEMORY_MATCH.Properties.Resources._return;
            this.btn_return.ImageOffset = new System.Drawing.Point(0, 0);
            this.btn_return.ImageRotate = 0F;
            this.btn_return.ImageSize = new System.Drawing.Size(55, 55);
            this.btn_return.Location = new System.Drawing.Point(208, 191);
            this.btn_return.Name = "btn_return";
            this.btn_return.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btn_return.Size = new System.Drawing.Size(68, 57);
            this.btn_return.TabIndex = 8;
            // 
            // EndGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(400, 260);
            this.Controls.Add(this.btn_return);
            this.Controls.Add(this.btn_mainoption);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EndGame";
            this.Text = "EndGame";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ImageButton btn_mainoption;
        private Guna.UI2.WinForms.Guna2ImageButton btn_return;
    }
}