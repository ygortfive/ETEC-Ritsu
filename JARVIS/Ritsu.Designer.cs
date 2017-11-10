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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ritsu));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbl_rec = new System.Windows.Forms.Label();
            this.lbl_Ritsu = new System.Windows.Forms.Label();
            this.timerCOM = new System.Windows.Forms.Timer(this.components);
            this.PortCOM = new System.IO.Ports.SerialPort(this.components);
            this.recValidate = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.recValidate)).BeginInit();
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
            // lbl_rec
            // 
            this.lbl_rec.AutoSize = true;
            this.lbl_rec.BackColor = System.Drawing.Color.Transparent;
            this.lbl_rec.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_rec.ForeColor = System.Drawing.Color.White;
            this.lbl_rec.Location = new System.Drawing.Point(13, 56);
            this.lbl_rec.MaximumSize = new System.Drawing.Size(150, 200);
            this.lbl_rec.MinimumSize = new System.Drawing.Size(5, 0);
            this.lbl_rec.Name = "lbl_rec";
            this.lbl_rec.Size = new System.Drawing.Size(65, 29);
            this.lbl_rec.TabIndex = 2;
            this.lbl_rec.Text = "User:";
            this.lbl_rec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Ritsu
            // 
            this.lbl_Ritsu.AutoSize = true;
            this.lbl_Ritsu.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Ritsu.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Ritsu.ForeColor = System.Drawing.Color.DarkGray;
            this.lbl_Ritsu.Location = new System.Drawing.Point(13, 229);
            this.lbl_Ritsu.MaximumSize = new System.Drawing.Size(150, 200);
            this.lbl_Ritsu.MinimumSize = new System.Drawing.Size(5, 0);
            this.lbl_Ritsu.Name = "lbl_Ritsu";
            this.lbl_Ritsu.Size = new System.Drawing.Size(69, 29);
            this.lbl_Ritsu.TabIndex = 3;
            this.lbl_Ritsu.Text = "Ritsu:";
            this.lbl_Ritsu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerCOM
            // 
            this.timerCOM.Tick += new System.EventHandler(this.timerCOM_Tick);
            // 
            // PortCOM
            // 
            this.PortCOM.PortName = "COM6";
            // 
            // recValidate
            // 
            this.recValidate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.recValidate.BackColor = System.Drawing.Color.Transparent;
            this.recValidate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.recValidate.Enabled = false;
            this.recValidate.Location = new System.Drawing.Point(751, 321);
            this.recValidate.Name = "recValidate";
            this.recValidate.Size = new System.Drawing.Size(94, 82);
            this.recValidate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.recValidate.TabIndex = 4;
            this.recValidate.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(772, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Alterar ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Ritsu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(857, 415);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.recValidate);
            this.Controls.Add(this.lbl_Ritsu);
            this.Controls.Add(this.lbl_rec);
            this.Controls.Add(this.progressBar1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(653, 358);
            this.Name = "Ritsu";
            this.Text = "RITSU";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.recValidate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lbl_rec;
        private System.Windows.Forms.Label lbl_Ritsu;
        private System.Windows.Forms.Timer timerCOM;
        private System.IO.Ports.SerialPort PortCOM;
        private System.Windows.Forms.PictureBox recValidate;
        private System.Windows.Forms.Button button1;
    }
}

