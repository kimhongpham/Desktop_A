namespace MEMORY_MATCH
{
    partial class GameOver
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_return = new Guna.UI2.WinForms.Guna2ImageButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "GAME OVER";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Script", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 46);
            this.label2.TabIndex = 1;
            this.label2.Text = "Score";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Script", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 46);
            this.label3.TabIndex = 2;
            this.label3.Text = "Level";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(58, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 33);
            this.label4.TabIndex = 3;
            this.label4.Text = "Record";
            this.label4.Click += new System.EventHandler(this.label4_Click);
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
            this.btn_return.Location = new System.Drawing.Point(221, 181);
            this.btn_return.Name = "btn_return";
            this.btn_return.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btn_return.Size = new System.Drawing.Size(67, 57);
            this.btn_return.TabIndex = 9;
            // 
            // GameOver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(300, 250);
            this.Controls.Add(this.btn_return);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameOver";
            this.Text = "GameOver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2ImageButton btn_return;
    }
}