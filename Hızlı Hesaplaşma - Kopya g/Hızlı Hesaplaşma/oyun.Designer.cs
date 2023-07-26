
namespace Hızlı_Hesaplaşma
{
    partial class oyun
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(oyun));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.biz = new System.Windows.Forms.PictureBox();
            this.araba2 = new System.Windows.Forms.PictureBox();
            this.araba1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.carpma = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.biz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.araba2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.araba1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carpma)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1440, 603);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // biz
            // 
            this.biz.Image = ((System.Drawing.Image)(resources.GetObject("biz.Image")));
            this.biz.Location = new System.Drawing.Point(240, 237);
            this.biz.Name = "biz";
            this.biz.Size = new System.Drawing.Size(165, 97);
            this.biz.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.biz.TabIndex = 1;
            this.biz.TabStop = false;
            // 
            // araba2
            // 
            this.araba2.Image = ((System.Drawing.Image)(resources.GetObject("araba2.Image")));
            this.araba2.Location = new System.Drawing.Point(1017, 419);
            this.araba2.Name = "araba2";
            this.araba2.Size = new System.Drawing.Size(126, 104);
            this.araba2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.araba2.TabIndex = 2;
            this.araba2.TabStop = false;
            // 
            // araba1
            // 
            this.araba1.Image = ((System.Drawing.Image)(resources.GetObject("araba1.Image")));
            this.araba1.Location = new System.Drawing.Point(831, 80);
            this.araba1.Name = "araba1";
            this.araba1.Size = new System.Drawing.Size(165, 97);
            this.araba1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.araba1.TabIndex = 3;
            this.araba1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(38, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 148);
            this.button1.TabIndex = 4;
            this.button1.Text = "Başla";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // carpma
            // 
            this.carpma.Location = new System.Drawing.Point(418, 127);
            this.carpma.Name = "carpma";
            this.carpma.Size = new System.Drawing.Size(100, 50);
            this.carpma.TabIndex = 5;
            this.carpma.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // oyun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 603);
            this.Controls.Add(this.carpma);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.araba1);
            this.Controls.Add(this.araba2);
            this.Controls.Add(this.biz);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "oyun";
            this.Text = "oyun";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.biz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.araba2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.araba1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carpma)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox biz;
        private System.Windows.Forms.PictureBox araba2;
        private System.Windows.Forms.PictureBox araba1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox carpma;
        private System.Windows.Forms.Timer timer1;
    }
}