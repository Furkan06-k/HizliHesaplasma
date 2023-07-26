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
    public partial class zor : Form
    {
        int roadSpeed; // Yol hızı
        int trafficSpeed; // Trafik araçlarının hızı
        int playerSpeed = 12; // Oyuncunun hızı
        int score; // Puan
        int carImage; // Araç resmi indeksi
        int remainingLives = 2; // Kalan can sayısı
        Random rand = new Random(); // Rastgele sayı üretmek için nesne
        Random carPosition = new Random(); // Araç pozisyonunu belirlemek için nesne

        bool goleft, goright; // Sol ve sağ yön tuşlarına basılı olup olmadığını tutan değişkenler


        public zor()
        {

            InitializeComponent();
            label2.Text = remainingTime.ToString(); // Kalan süreyi gösteren etiketi başlangıç değeriyle güncelle
            timer1.Start(); // Geriye sayım için zamanlayıcıyı başlat
            player.Click += player_Click; // Oyuncu resmine tıklama olayını tanımla
            ResetGame(); // Oyunu sıfırla
            su.BackColor = Color.Transparent; // Su resminin arka planını saydam yap
            su.Parent = panel1; // Su resmini panelin içine yerleştir
            award.BackColor = Color.Transparent; // Ödül resminin arka planını saydam yap
            award.Image = Properties.Resources.SÜPER; // Ödül resmini belirle
        }

        private void zor_KeyUp(object sender, KeyEventArgs e)
        {
            // Sol veya sağ yön tuşlarına basılmadığında ilgili değişkenleri false yap
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
        }

        private void zor_KeyDown(object sender, KeyEventArgs e)
        {
            // Sol veya sağ yön tuşlarına basıldığında ilgili değişkenleri true yap
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
            }

        }
        private int carSlowdownDuration = 30; // Arabanın yavaşlama süresi (tick sayısı)
        private int carSlowdownTick = 0; // Arabanın yavaşlama sayacı
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + score;
            score++;

            benzin.Top += roadSpeed;
            su.Top += roadSpeed;

            if (benzin.Bounds.IntersectsWith(player.Bounds))
            {
                benzin.Visible = false; // Benzin resmini gizle
                remainingTime += 2; // Süreye +2 ekle
                label2.Text = remainingTime.ToString(); // Süreyi güncelle
                PlaceBenzin(); // Yeni bir benzin nesnesi yerleştir
            }

            if (player.Bounds.IntersectsWith(su.Bounds))
            {
                su.Visible = false;
                score -= 50;
                txtScore.Text = "Score: " + score;
                PlaceBalcik();

                carSlowdownTick = carSlowdownDuration; // Arabanın yavaşlama süresini başlat
            }

            // Arabanın yavaşlama süresi boyunca hızını azalt
            if (carSlowdownTick > 0)
            {
                playerSpeed = 3; // Arabanın yavaşlama hızını belirle
                carSlowdownTick--; // Sayacı azalt
            }
            else
            {
                playerSpeed = 12; // Normal hıza geri dön
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
                roadSpeed = 26;
                trafficSpeed = 24;
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
                              // ...
            UpdateRemainingLives(); // Canları güncelle

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



        }
        private void UpdateRemainingLives()
        {
            // Canları güncelle
            can1.Visible = remainingLives >= 1;
            can2.Visible = remainingLives >= 2;
        }
      
        private void ResetGame()
        {
            btnStart.Enabled = false;
            // Başlat düğmesini devre dışı bırak

            explosion.Visible = false;
            // Patlama efektini gizle

            award.Visible = false;
            // Ödülü gizle

            goleft = false;
            // Sola git bayrağını false olarak ayarla

            goright = false;
            // Sağa git bayrağını false olarak ayarla

            award.Image = Properties.Resources.bronze;
            // Ödülün görüntüsünü bronz olarak ayarla

            roadSpeed = 18;
            // Yol hızını 18 olarak ayarla

            trafficSpeed = 23;
            // Trafik araçlarının hızını 23 olarak ayarla

            AI1.Top = carPosition.Next(200, 500) * -1;
            // AI1'in üst koordinatını rastgele belirle (-1 ile çarpılıyor çünkü yukarıdan aşağıya doğru hareket edecek)
            AI1.Left = carPosition.Next(5, 200);
            // AI1'in sol koordinatını rastgele belirle

            AI2.Top = carPosition.Next(200, 500) * -1;
            // AI2'nin üst koordinatını rastgele belirle (-1 ile çarpılıyor çünkü yukarıdan aşağıya doğru hareket edecek)
            AI2.Left = carPosition.Next(245, 422);
            // AI2'nin sol koordinatını rastgele belirle

            label2.Text = remainingTime.ToString();
            // Label2 üzerindeki metni güncelle, geriye kalan süreyi göster

            gameTimer.Start();
            // Oyun süresini başlat

            timer1.Start();
            // Geriye sayım süresini başlat

            can1.Visible = true;
            // Can1 nesnesini görünür yap

            can2.Visible = true;
            // Can2 nesnesini görünür yap

            UpdateRemainingLives();
            // Kalan canları güncelle

            PlaceBenzin();
            // Yeni bir benzin nesnesi yerleştir

            PlaceBalcik();
            // Yeni bir balçık nesnesi yerleştir
        }
        private int remainingTime = 60;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (remainingTime > 0)
            {
                remainingTime--;
                // Geriye kalan süreyi bir azalt
                label2.Text = remainingTime.ToString();
                // Label üzerindeki metni güncelle, geriye kalan süreyi göster
            }
            else
            {
                timer1.Stop();
                // Geriye sayım süresini durdur

                MessageBox.Show("Geriye sayma tamamlandı!");
                // Kullanıcıya bir ileti kutusu göster, geriye sayma tamamlandı mesajını görüntüle

                // Yapılacak diğer işlemler
                // Bu kısımda, geriye sayma tamamlandıktan sonra yapılması gereken diğer işlemler yer alabilir.
            }
        }
        private Random random = new Random();

        private void benzin_Click(object sender, EventArgs e)
        {
           
        }

        private void zor_Load(object sender, EventArgs e)
        {
            benzin.MouseDown += new MouseEventHandler(benzin_MouseClick);
            PlaceBenzin();
        }

        private void benzin_MouseClick(object sender, MouseEventArgs e)
        {
            if (player.Bounds.IntersectsWith(benzin.Bounds))
            {
                benzin.Visible = false; // Benzin resmini gizle
                su.Visible = true; // Su nesnesini göster
                timer2.Start(); // Timer2'yi başlat
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

        
        private void PlaceBenzin()
        {

            int x = random.Next(0, this.ClientSize.Width - benzin.Width);
            // X koordinatını rastgele bir değerle belirle. Değer, formun genişliği ile benzin nesnesinin genişliği arasında olmalıdır.

            int y = random.Next(-1000, -100);
            // Y koordinatını rastgele bir değerle belirle. Değer, -1000 ile -100 arasında olmalıdır. Bu, benzin nesnesinin formun üst kısmının üstünde başlamasını sağlar.

            benzin.Location = new Point(x, y);
            // benzin nesnesinin konumunu belirlenen x ve y koordinatlarına ayarla.

            benzin.Visible = true;
            // benzin nesnesini görünür yap, yani ekranda göster.
        }
        private void PlaceBalcik()
        {
            int x = random.Next(0, this.ClientSize.Width - su.Width);
            // X koordinatını rastgele bir değerle belirle. Değer, formun genişliği ile su nesnesinin genişliği arasında olmalıdır.

            int y = random.Next(-1000, -100);
            // Y koordinatını rastgele bir değerle belirle. Değer, -1000 ile -100 arasında olmalıdır. Bu, su nesnesinin formun üst kısmının üstünde başlamasını sağlar.

            su.Location = new Point(x, y);
            // su nesnesinin konumunu belirlenen x ve y koordinatlarına ayarla.

            su.Visible = true;
            // su nesnesini görünür yap, yani ekranda göster.
        }

        private void zor_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Kapatma işlemi engellendi
            e.Cancel = true;

            // Diğer forma geçiş işlemini gerçekleştirin
            seviye svy = new seviye();
            svy.Show();

            // Mevcut formu gizleyin
            this.Hide();
        }

        private void roadTrack2_Click(object sender, EventArgs e)
        {

        }

        private void playSound()
        {
           // System.Media.SoundPlayer playCrash = new System.Media.SoundPlayer(Properties.Resources.hit);
           // playCrash.Play();

        }
    }
}
