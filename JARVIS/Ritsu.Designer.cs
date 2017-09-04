namespace RITSU
{
    partial class Ritsu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ritsu));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_rec = new System.Windows.Forms.Label();
            this.lbl_Ritsu = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.Control;
            this.progressBar1.Location = new System.Drawing.Point(12, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(161, 22);
            this.progressBar1.TabIndex = 0;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.MediumBlue;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(29, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Status";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // lbl_rec
            // 
            this.lbl_rec.AutoSize = true;
            this.lbl_rec.BackColor = System.Drawing.Color.MediumBlue;
            this.lbl_rec.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_rec.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_rec.Location = new System.Drawing.Point(13, 56);
            this.lbl_rec.MaximumSize = new System.Drawing.Size(150, 200);
            this.lbl_rec.MinimumSize = new System.Drawing.Size(5, 0);
            this.lbl_rec.Name = "lbl_rec";
            this.lbl_rec.Size = new System.Drawing.Size(46, 20);
            this.lbl_rec.TabIndex = 2;
            this.lbl_rec.Text = "User:";
            this.lbl_rec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Ritsu
            // 
            this.lbl_Ritsu.AutoSize = true;
            this.lbl_Ritsu.BackColor = System.Drawing.Color.MediumBlue;
            this.lbl_Ritsu.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Ritsu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_Ritsu.Location = new System.Drawing.Point(13, 143);
            this.lbl_Ritsu.MaximumSize = new System.Drawing.Size(150, 200);
            this.lbl_Ritsu.MinimumSize = new System.Drawing.Size(5, 0);
            this.lbl_Ritsu.Name = "lbl_Ritsu";
            this.lbl_Ritsu.Size = new System.Drawing.Size(48, 20);
            this.lbl_Ritsu.TabIndex = 3;
            this.lbl_Ritsu.Text = "Ritsu:";
            this.lbl_Ritsu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(681, 319);
            this.Controls.Add(this.lbl_Ritsu);
            this.Controls.Add(this.lbl_rec);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(653, 358);
            this.Name = "Form1";
            this.Text = "RITSU";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_rec;
        private System.Windows.Forms.Label lbl_Ritsu;
    }
}

