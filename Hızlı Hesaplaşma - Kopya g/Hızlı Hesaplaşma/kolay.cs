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
    public partial class kolay : Form
    {

        int roadSpeed; // Yol hızı
        int trafficSpeed; // Trafik hızı
        int playerSpeed = 12; // Oyuncu hızı
        int score; // Skor
        int carImage; // Araba resmi
        int remainingLives = 3; // Kalan can sayısı
        Random rand = new Random(); // Rastgele sayı üretmek için kullanılan nesne
        Random carPosition = new Random(); // Arabaların başlangıç konumunu belirlemek için kullanılan rastgele sayı nesnesi
        private int remainingTime = 60; // Kalan süre
        bool goleft, goright; // Oyuncunun sola ve sağa gitme durumu


        public kolay()
        {
            InitializeComponent();
            label2.Text = remainingTime.ToString(); // Kalan süreyi etikete yazdır
            timer1.Start(); // Geriye sayım süresini başlat
            player.Click += player_Click; // Oyuncu resmine tıklanıldığında gerçekleşecek olaya metodu ata
            ResetGame(); // Oyunu sıfırla

        }

     

        private void kolay_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Left)
            {
                goleft = true; // Sol tuşa basıldığında sola gitme durumunu aktifleştir
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true; // Sağ tuşa basıldığında sağa gitme durumunu aktifleştir
            }
        }

        private void kolay_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false; // Sol tuş bırakıldığında sola gitme durumunu devre dışı bırak
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false; // Sağ tuş bırakıldığında sağa gitme durumunu devre dışı bırak
            }
        }


        private void changeAIcars(PictureBox tempCar)
        {
            carImage = rand.Next(1, 9); // 1 ile 9 arasında rastgele bir sayı al

            switch (carImage)
            {
                case 1:
                    tempCar.Image = Properties.Resources.ambulance; // Araba resmini ambulans olarak değiştir
                    break;
                case 2:
                    tempCar.Image = Properties.Resources.carGreen; // Araba resmini yeşil araba olarak değiştir
                    break;
                case 3:
                    tempCar.Image = Properties.Resources.carGrey; // Araba resmini gri araba olarak değiştir
                    break;
                case 4:
                    tempCar.Image = Properties.Resources.carOrange; // Araba resmini turuncu araba olarak değiştir
                    break;
                case 5:
                    tempCar.Image = Properties.Resources.carPink; // Araba resmini pembe araba olarak değiştir
                    break;
                case 6:
                    tempCar.Image = Properties.Resources.CarRed; // Araba resmini kırmızı araba olarak değiştir
                    break;
                case 7:
                    tempCar.Image = Properties.Resources.carYellow; // Araba resmini sarı araba olarak değiştir
                    break;
                case 8:
                    tempCar.Image = Properties.Resources.TruckBlue; // Araba resmini mavi kamyon olarak değiştir
                    break;
                case 9:
                    tempCar.Image = Properties.Resources.TruckWhite; // Araba resmini beyaz kamyon olarak değiştir
                    break;
            }

            tempCar.Top = carPosition.Next(100, 400) * -1; // Arabanın başlangıç konumunu rastgele belirle

            if ((string)tempCar.Tag == "carLeft")
            {
                tempCar.Left = carPosition.Next(5, 200); // Sol tarafta giden arabaların başlangıç konumunu rastgele belirle
            }
            if ((string)tempCar.Tag == "carRight")
            {
                tempCar.Left = carPosition.Next(245, 422); // Sağ tarafta giden arabaların başlangıç konumunu rastgele belirle
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (remainingTime > 0)
            {
                remainingTime--; // Kalan süreyi azalt
                label2.Text = remainingTime.ToString(); // Etikete kalan süreyi yazdır
            }
            else
            {
                timer1.Stop(); // Geriye sayım süresini durdur
                MessageBox.Show("Geriye sayma tamamlandı!"); // Geriye sayım tamamlandığında mesaj kutusu göster
                // Yapılacak diğer işlemler
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + score; // Skoru metin kutusuna yazdır
            score++; // Skoru arttır

            benzin.Top += roadSpeed; // Benzin nesnesini yol hızına göre aşağı kaydır

            if (benzin.Bounds.IntersectsWith(player.Bounds))
            {
                benzin.Visible = false; // Benzin resmini gizle
                remainingTime += 5; // Süreye 5 ekle
                label2.Text = remainingTime.ToString(); // Etiketi güncelle
                PlaceBenzin(); // Benzin nesnesini yeni bir konuma yerleştir
            }

            // Eğer benzin nesnesi aşağıdan geçtiyse ve ekran dışına çıktıysa, yeni bir konuma yerleştir
            if (benzin.Top > this.ClientSize.Height)
            {
                PlaceBenzin();
            }

            if (goleft == true && player.Left > 10)
            {
                player.Left -= playerSpeed; // Oyuncuyu sola hareket ettir
            }
            if (goright == true && player.Left < 415)
            {
                player.Left += playerSpeed; // Oyuncuyu sağa hareket ettir
            }

            roadTrack1.Top += roadSpeed; // Yol parçasını yol hızına göre aşağı kaydır
            roadTrack2.Top += roadSpeed; // Yol parçasını yol hızına göre aşağı kaydır

            if (roadTrack2.Top > 519)
            {
                roadTrack2.Top = -519; // Yol parçasının konumunu sıfırla
            }
            if (roadTrack1.Top > 519)
            {
                roadTrack1.Top = -519; // Yol parçasının konumunu sıfırla
            }

            AI1.Top += trafficSpeed; // AI arabalarını trafik hızına göre aşağı kaydır
            AI2.Top += trafficSpeed; // AI arabalarını trafik hızına göre aşağı kaydır

            if (AI1.Top > 530)
            {
                changeAIcars(AI1); // AI arabasının konumunu değiştir
            }

            if (AI2.Top > 530)
            {
                changeAIcars(AI2); // AI arabasının konumunu değiştir
            }

            if (player.Bounds.IntersectsWith(AI1.Bounds) || player.Bounds.IntersectsWith(AI2.Bounds))
            {
                gameOver(); // Oyunu bitir
            }

            if (score > 40 && score < 500)
            {
                award.Image = Properties.Resources.SÜPER; // Ödül resmini "SÜPER" olarak değiştir
            }

            if (score > 500 && score < 2000)
            {
                award.Image = Properties.Resources.HARİKA; // Ödül resmini "HARİKA" olarak değiştir
                roadSpeed = 20; // Yol hızını arttır
                trafficSpeed = 22; // Trafik hızını arttır
            }

            if (score > 2000)
            {
                award.Image = Properties.Resources.MUHTEŞEM; // Ödül resmini "MUHTEŞEM" olarak değiştir
                trafficSpeed = 27; // Trafik hızını arttır
                roadSpeed = 25; // Yol hızını arttır
            }

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (remainingLives > 0)
            {
                ResetGame(); // Oyunu sıfırla
            }
            else
            {
                remainingLives = 3; // Canları başlangıç değerine geri yükle
                ResetGame(); // Yeni bir oyuna başla
            }
        }

        private void can1_Click(object sender, EventArgs e)
        {
            can1.Visible = false; // Canı gizle
        }

        private void can2_Click(object sender, EventArgs e)
        {
            can2.Visible = false; // Canı gizle
        }

        private void can3_Click(object sender, EventArgs e)
        {
            can3.Visible = false; // Canı gizle
        }


        private Random random = new Random();
        private void PlaceBenzin()
        {
            int x = random.Next(0, this.ClientSize.Width - benzin.Width); // X koordinatını rastgele belirle
            int y = random.Next(0, this.ClientSize.Height - benzin.Height); // Y koordinatını rastgele belirle

            benzin.Location = new Point(x, y); // Benzin nesnesini yeni konumuna yerleştir
            benzin.Visible = true; // Benzin nesnesini görünür yap
        }
        private void benzin_Click(object sender, EventArgs e)
        {
            if (player.Bounds.IntersectsWith(benzin.Bounds))
            {
                benzin.Visible = false; // Benzin resmini gizle
            }
        }

        private void player_Click(object sender, EventArgs e)
        {
            if (player.Bounds.IntersectsWith(benzin.Bounds))
            {
                benzin.Visible = false; // Benzin resmini gizle
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

        private void kolay_Load(object sender, EventArgs e)
        {
            benzin.MouseDown += new MouseEventHandler(benzin_MouseClick);
            PlaceBenzin();
        }

        private void benzin_MouseClick(object sender, MouseEventArgs e)
        {
            if (player.Bounds.IntersectsWith(benzin.Bounds))
            {
                benzin.Visible = false; // Benzin resmini gizle
                remainingTime += 5; // Süreye +5 ekle
                label2.Text = remainingTime.ToString(); // Süreyi güncelle
                PlaceBenzin();
            }
        }

        private void ResetGame()
        {
            btnStart.Enabled = false;
            explosion.Visible = false;
            award.Visible = false;
            goleft = false;
            goright = false;
            award.Image = Properties.Resources.SÜPER;

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
        }

        private void txtScore_Click(object sender, EventArgs e)
        {

        }

        private void kolay_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Kapatma işlemi engellendi
            e.Cancel = true;

            // Diğer forma geçiş işlemini gerçekleştirin
            seviye svy = new seviye();
            svy.Show();

            // Mevcut formu gizleyin
            this.Hide();
        }

        private void playSound()
        {
            // Ses çalma işlemi
            // System.Media.SoundPlayer playCrash = new System.Media.SoundPlayer(Properties.Resources.hit);
            // playCrash.Play();
        }
    }
}