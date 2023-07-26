
namespace Hızlı_Hesaplaşma
{
    partial class zor
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtScore = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.su = new System.Windows.Forms.PictureBox();
            this.benzin = new System.Windows.Forms.PictureBox();
            this.AI2 = new System.Windows.Forms.PictureBox();
            this.AI1 = new System.Windows.Forms.PictureBox();
            this.award = new System.Windows.Forms.PictureBox();
            this.explosion = new System.Windows.Forms.PictureBox();
            this.player = new System.Windows.Forms.PictureBox();
            this.roadTrack2 = new System.Windows.Forms.PictureBox();
            this.roadTrack1 = new System.Windows.Forms.PictureBox();
            this.can2 = new System.Windows.Forms.PictureBox();
            this.can1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.su)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.benzin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AI2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AI1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.award)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.explosion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadTrack2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadTrack1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.can2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.can1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(335, 622);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 34);
            this.label1.TabIndex = 13;
            this.label1.Text = "Süre:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(370, 622);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 34);
            this.label2.TabIndex = 10;
            this.label2.Text = "label2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtScore
            // 
            this.txtScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScore.Location = new System.Drawing.Point(307, 585);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(180, 37);
            this.txtScore.TabIndex = 9;
            this.txtScore.Text = "Score: 0";
            this.txtScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(193, 596);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(99, 41);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "RestStart";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.su);
            this.panel1.Controls.Add(this.benzin);
            this.panel1.Controls.Add(this.AI2);
            this.panel1.Controls.Add(this.AI1);
            this.panel1.Controls.Add(this.award);
            this.panel1.Controls.Add(this.explosion);
            this.panel1.Controls.Add(this.player);
            this.panel1.Controls.Add(this.roadTrack2);
            this.panel1.Controls.Add(this.roadTrack1);
            this.panel1.Location = new System.Drawing.Point(10, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(475, 571);
            this.panel1.TabIndex = 7;
            // 
            // su
            // 
            this.su.BackColor = System.Drawing.Color.Transparent;
            this.su.Image = global::Hızlı_Hesaplaşma.Properties.Resources.su;
            this.su.Location = new System.Drawing.Point(76, 213);
            this.su.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.su.Name = "su";
            this.su.Size = new System.Drawing.Size(76, 71);
            this.su.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.su.TabIndex = 7;
            this.su.TabStop = false;
            // 
            // benzin
            // 
            this.benzin.Image = global::Hızlı_Hesaplaşma.Properties.Resources.benzin;
            this.benzin.Location = new System.Drawing.Point(345, 368);
            this.benzin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.benzin.Name = "benzin";
            this.benzin.Size = new System.Drawing.Size(52, 59);
            this.benzin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.benzin.TabIndex = 6;
            this.benzin.TabStop = false;
            this.benzin.Click += new System.EventHandler(this.benzin_Click);
            this.benzin.MouseClick += new System.Windows.Forms.MouseEventHandler(this.benzin_MouseClick);
            // 
            // AI2
            // 
            this.AI2.Image = global::Hızlı_Hesaplaşma.Properties.Resources.carGrey;
            this.AI2.Location = new System.Drawing.Point(422, 62);
            this.AI2.Name = "AI2";
            this.AI2.Size = new System.Drawing.Size(50, 100);
            this.AI2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.AI2.TabIndex = 5;
            this.AI2.TabStop = false;
            this.AI2.Tag = "carRight";
            // 
            // AI1
            // 
            this.AI1.Image = global::Hızlı_Hesaplaşma.Properties.Resources.carGreen;
            this.AI1.Location = new System.Drawing.Point(76, 62);
            this.AI1.Name = "AI1";
            this.AI1.Size = new System.Drawing.Size(50, 101);
            this.AI1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.AI1.TabIndex = 5;
            this.AI1.TabStop = false;
            this.AI1.Tag = "carLeft";
            // 
            // award
            // 
            this.award.Image = global::Hızlı_Hesaplaşma.Properties.Resources.SÜPER;
            this.award.Location = new System.Drawing.Point(130, 168);
            this.award.Name = "award";
            this.award.Size = new System.Drawing.Size(225, 194);
            this.award.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.award.TabIndex = 5;
            this.award.TabStop = false;
            // 
            // explosion
            // 
            this.explosion.Image = global::Hızlı_Hesaplaşma.Properties.Resources.explosion;
            this.explosion.Location = new System.Drawing.Point(76, 375);
            this.explosion.Name = "explosion";
            this.explosion.Size = new System.Drawing.Size(64, 64);
            this.explosion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.explosion.TabIndex = 5;
            this.explosion.TabStop = false;
            // 
            // player
            // 
            this.player.Image = global::Hızlı_Hesaplaşma.Properties.Resources.carYellow;
            this.player.Location = new System.Drawing.Point(215, 402);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(50, 99);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.player.TabIndex = 5;
            this.player.TabStop = false;
            this.player.Click += new System.EventHandler(this.player_Click);
            // 
            // roadTrack2
            // 
            this.roadTrack2.Image = global::Hızlı_Hesaplaşma.Properties.Resources.roadTrack;
            this.roadTrack2.Location = new System.Drawing.Point(0, 0);
            this.roadTrack2.Name = "roadTrack2";
            this.roadTrack2.Size = new System.Drawing.Size(475, 571);
            this.roadTrack2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.roadTrack2.TabIndex = 4;
            this.roadTrack2.TabStop = false;
            this.roadTrack2.Click += new System.EventHandler(this.roadTrack2_Click);
            // 
            // roadTrack1
            // 
            this.roadTrack1.Location = new System.Drawing.Point(0, -519);
            this.roadTrack1.Name = "roadTrack1";
            this.roadTrack1.Size = new System.Drawing.Size(475, 519);
            this.roadTrack1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.roadTrack1.TabIndex = 0;
            this.roadTrack1.TabStop = false;
            // 
            // can2
            // 
            this.can2.Image = global::Hızlı_Hesaplaşma.Properties.Resources.cannn;
            this.can2.Location = new System.Drawing.Point(10, 583);
            this.can2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.can2.Name = "can2";
            this.can2.Size = new System.Drawing.Size(64, 54);
            this.can2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.can2.TabIndex = 12;
            this.can2.TabStop = false;
            this.can2.Click += new System.EventHandler(this.can2_Click);
            // 
            // can1
            // 
            this.can1.Image = global::Hızlı_Hesaplaşma.Properties.Resources.cannn;
            this.can1.Location = new System.Drawing.Point(97, 583);
            this.can1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.can1.Name = "can1";
            this.can1.Size = new System.Drawing.Size(64, 54);
            this.can1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.can1.TabIndex = 11;
            this.can1.TabStop = false;
            this.can1.Click += new System.EventHandler(this.can1_Click);
            // 
            // zor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 781);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.can2);
            this.Controls.Add(this.can1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "zor";
            this.Text = "zor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.zor_FormClosing);
            this.Load += new System.EventHandler(this.zor_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.zor_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.zor_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.su)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.benzin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AI2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AI1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.award)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.explosion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadTrack2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadTrack1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.can2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.can1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox can2;
        private System.Windows.Forms.PictureBox can1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox roadTrack1;
        private System.Windows.Forms.PictureBox roadTrack2;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.PictureBox explosion;
        private System.Windows.Forms.PictureBox award;
        private System.Windows.Forms.PictureBox AI1;
        private System.Windows.Forms.PictureBox AI2;
        private System.Windows.Forms.PictureBox benzin;
        private System.Windows.Forms.PictureBox su;
        private System.Windows.Forms.Panel panel1;
    }
}