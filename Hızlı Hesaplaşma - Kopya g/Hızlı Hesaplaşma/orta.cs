using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hızlı_Hesaplaşma
{
    public partial class orta : Form
    {
        int roadSpeed;
        int trafficSpeed;
        int playerSpeed = 12;
        int score;
        int carImage;
        int remainingLives = 3;
        Random rand = new Random();
        Random carPosition = new Random();

        bool goleft, goright;

        public orta()
        {
            InitializeComponent();
            label2.Text = remainingTime.ToString();
            timer1.Start();
            player.Click += player_Click;
            ResetGame();
            su.BackColor = Color.Transparent;
            su.Parent = panel1;

        }

        private void orta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
            }
        }

        private void orta_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + score;
            score++;

            benzin.Top += roadSpeed;
            su.Top += roadSpeed;

            if (benzin.Bounds.IntersectsWith(player.Bounds))
            {
                benzin.Visible = false; // Benzin resmini gizle
                remainingTime += 3; // Süreye +3 ekle
                label2.Text = remainingTime.ToString(); // Süreyi güncelle
                PlaceBenzin(); // Yeni bir benzin nesnesi yerleştir
            }

            if (su.Bounds.IntersectsWith(player.Bounds))
            {
                su.Visible = false;
                score -= 50; // Skordan 50 puan eksilt
                txtScore.Text = "Score: " + score; // Skoru güncelle
                PlaceBalcik(); // Yeni bir balcik nesnesi yerleştir
            }

            if (benzin.Top > this.ClientSize.Height)
            {
                PlaceBenzin(); // Eğer benzin nesnesi ekrandan geçtiyse, yeni bir konuma yerleştir
            }

            if (su.Top > this.ClientSize.Height)
            {
                PlaceBalcik(); // Eğer balcik nesnesi ekrandan geçtiyse, yeni bir konuma yerleştir
            }

            if (goleft == true && player.Left > 10)
            {
                player.Left -= playerSpeed;
            }
            if (goright == true && player.Left < 415)
            {
                player.Left += playerSpeed;
            }

            roadTrack1.Top += roadSpeed;
            roadTrack2.Top += roadSpeed;

            if (roadTrack2.Top > 519)
            {
                roadTrack2.Top = -519;
            }
            if (roadTrack1.Top > 519)
            {
                roadTrack1.Top = -519;
            }

            AI1.Top += trafficSpeed;
            AI2.Top += trafficSpeed;

            if (AI1.Top > 530)
            {
                changeAIcars(AI1);
            }

            if (AI2.Top > 530)
            {
                changeAIcars(AI2);
            }

            if (player.Bounds.IntersectsWith(AI1.Bounds) || player.Bounds.IntersectsWith(AI2.Bounds))
            {
                gameOver();
            }

            if (score > 40 && score < 500)
            {
                award.Image = Properties.Resources.SÜPER;
            }

            if (score > 500 && score < 2000)
            {
                award.Image = Properties.Resources.HARİKA;
                roadSpeed = 20;
                trafficSpeed = 22;
            }

            if (score > 2000)
            {
                award.Image = Properties.Resources.MUHTEŞEM;
                trafficSpeed = 27;
                roadSpeed = 25;
            }
        }
        private void changeAIcars(PictureBox tempCar)
        {

            carImage = rand.Next(1, 9);

            switch (carImage)
            {

                case 1:
                    tempCar.Image = Properties.Resources.ambulance;
                    break;
                case 2:
                    tempCar.Image = Properties.Resources.carGreen;
                    break;
                case 3:
                    tempCar.Image = Properties.Resources.carGrey;
                    break;
                case 4:
                    tempCar.Image = Properties.Resources.carOrange;
                    break;
                case 5:
                    tempCar.Image = Properties.Resources.carPink;
                    break;
                case 6:
                    tempCar.Image = Properties.Resources.CarRed;
                    break;
                case 7:
                    tempCar.Image = Properties.Resources.carYellow;
                    break;
                case 8:
                    tempCar.Image = Properties.Resources.TruckBlue;
                    break;
                case 9:
                    tempCar.Image = Properties.Resources.TruckWhite;
                    break;

            }


            tempCar.Top = carPosition.Next(100, 400) * -1;


            if ((string)tempCar.Tag == "carLeft")
            {
                tempCar.Left = carPosition.Next(5, 200);
            }
            if ((string)tempCar.Tag == "carRight")
            {
                tempCar.Left = carPosition.Next(245, 422);
            }
        }
        private void gameOver()
        {
            playSound();
            gameTimer.Stop();
            timer1.Stop();
            explosion.Visible = true;
            player.Controls.Add(explosion);
            explosion.Location = new Point(-8, 5);
            explosion.BackColor = Color.Transparent;

            award.Visible = true;
            award.BringToFront();

            remainingLives--; // Canları azalt

            if (remainingLives > 0)
            {
                // Canlar varsa oyunu sıfırla ve devam et
                ResetGame();
            }
            else
            {
                // Canlar tükenmişse oyunu tamamen sıfırla
                remainingLives = 3; // Canları başlangıç değerine geri yükle
                btnStart.Enabled = true;
            }

            // Canları güncelle
            UpdateRemainingLives();

        }
        private void UpdateRemainingLives()
        {
            // Canları güncelle
            can1.Visible = remainingLives >= 1;
            can2.Visible = remainingLives >= 2;
            can3.Visible = remainingLives >= 3;
        }
        private void ResetGame()
        {
            btnStart.Enabled = false;
            explosion.Visible = false;
            award.Visible = false;
            goleft = false;
            goright = false;
            award.Image = Properties.Resources.bronze;

            roadSpeed = 12;
            trafficSpeed = 15;

            AI1.Top = carPosition.Next(200, 500) * -1;
            AI1.Left = carPosition.Next(5, 200);

            AI2.Top = carPosition.Next(200, 500) * -1;
            AI2.Left = carPosition.Next(245, 422);

            label2.Text = remainingTime.ToString(); // Label'ı güncelle

            gameTimer.Start(); // Oyun süresini başlat
            timer1.Start(); // Geriye sayım süresini başlat
            can1.Visible = true;
            can2.Visible = true;
            can3.Visible = true;
            UpdateRemainingLives();
            PlaceBenzin(); // Yeni bir benzin nesnesi yerleştir
            PlaceBalcik(); // Yeni bir balcik nesnesi yerleştir
        }
        private int remainingTime = 60;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (remainingTime > 0)
            {
                remainingTime--;
                label2.Text = remainingTime.ToString();
            }
            else
            {
                timer1.Stop();
                MessageBox.Show("Geriye sayma tamamlandı!");
                // Yapılacak diğer işlemler
            }
        }
        private Random random = new Random();
        private void PlaceBenzin()
        {

            int x = random.Next(0, this.ClientSize.Width - benzin.Width);
            int y = random.Next(-1000, -100);

            benzin.Location = new Point(x, y);

            // benzin nesnesini gizle
            benzin.Visible = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void benzin_Click(object sender, EventArgs e)
        {
            if (player.Bounds.IntersectsWith(benzin.Bounds))
            {
                benzin.Visible = false; // Benzin resmini gizle
                su.Visible = true; // Su nesnesini göster
                timer2.Start(); // Timer2'yi başlat
            }
        }

        private void orta_Load(object sender, EventArgs e)
        {
            benzin.MouseDown += new MouseEventHandler(benzin_MouseClick);
            PlaceBenzin();
        }

        private void benzin_MouseClick(object sender, MouseEventArgs e)
        {
            if (player.Bounds.IntersectsWith(benzin.Bounds))
            {
                benzin.Visible = false; // benzin resmini gizle
                remainingTime += 5; // Süreye +5 ekle
                label2.Text = remainingTime.ToString(); // Süreyi güncelle
                PlaceBenzin();
            }
        }

        private void player_Click(object sender, EventArgs e)
        {
            if (player.Bounds.IntersectsWith(benzin.Bounds))
            {
                benzin.Visible = false; // benzin resmini gizle
            }
        }

        private void can1_Click(object sender, EventArgs e)
        {

            can1.Visible = false;
        }

        private void can2_Click(object sender, EventArgs e)
        {

            can2.Visible = false;
        }

        private void can3_Click(object sender, EventArgs e)
        {

            can3.Visible = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (remainingLives > 0)
            {
                ResetGame();
            }
            else
            {
                // Yeni bir oyuna başla
                remainingLives = 3; // Canları başlangıç değerine geri yükle
                ResetGame();
            }
        }
        private void PlaceBalcik()
        {
            int x = random.Next(0, this.ClientSize.Width - su.Width);
            int y = random.Next(-1000, -100);

            su.Location = new Point(x, y);

            // balcik nesnesini göster
            su.Visible = true;
        }

        private void playSound()
        {
           // System.Media.SoundPlayer playCrash = new System.Media.SoundPlayer(Properties.Resources.hit);
            //playCrash.Play();

        }

        private void orta_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Kapatma işlemi engellendi
            e.Cancel = true;

            // Diğer forma geçiş işlemini gerçekleştirin
            seviye svy = new seviye();
            svy.Show();

            // Mevcut formu gizleyin
            this.Hide();
        }

        private void award_Click(object sender, EventArgs e)
        {

        }
    }
}
