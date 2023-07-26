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
    public partial class oyun : Form
    {
        public oyun()
        {
            InitializeComponent();
            basla(); // Form yüklenirken "basla" metodunu çağırıyoruz.
        }
        int kazanılan_puan = 0; // Başlangıçta kazanılan puanı sıfıra eşitliyoruz.
        int yol_hizi = 5; // Yol hızı değişkenini 5 olarak başlatıyoruz.
        int araba_hizi = 5; // Araba hızı değişkenini 5 olarak başlatıyoruz.
        bool sol_yon = false; // Sol yön değişkenini başlangıçta false olarak tanımlıyoruz.
        bool sag_yon = false; // Sağ yön değişkenini başlangıçta false olarak tanımlıyoruz.
        int diger_araba_hızı = -5; // Diğer arabaların hızı değişkenini -5 olarak başlatıyoruz.
        Random rnd = new Random(); // Rastgele sayılar üretmek için Random sınıfını kullanıyoruz.

        private void basla()
        {
            button1.Enabled = false; // "button1" adlı butonu başlangıçta devre dışı bırakıyoruz.
            carpma.Visible = false; // "carpma" adlı resmi başlangıçta görünmez yapıyoruz.

            diger_araba_hızı = 5; // Diğer arabaların hızını 5 olarak ayarlıyoruz.
            yol_hizi = 5; // Yol hızını 5 olarak ayarlıyoruz.

            biz.Top = 293; // "biz" adlı arabayı yüksekliği 293 olan yere yerleştiriyoruz.
            biz.Left = 166; // "biz" adlı arabayı 166 birim sola yerleştiriyoruz.

            sol_yon = false; // Sol yön değişkenini false olarak ayarlıyoruz.
            sag_yon = false; // Sağ yön değişkenini false olarak ayarlıyoruz.

            araba1.Top = 66; // "araba1" adlı arabayı yüksekliği 66 olan yere yerleştiriyoruz.
            araba1.Left = -120; // "araba1" adlı arabayı -120 birim sola yerleştiriyoruz.
            araba2.Top = 294; // "araba2" adlı arabayı yüksekliği 294 olan yere yerleştiriyoruz.
            araba2.Left = -185; // "araba2" adlı arabayı -185 birim sola yerleştiriyoruz.

            pictureBox1.Top = -3; // "pictureBox1" adlı resmi yüksekliği -3 olan yere yerleştiriyoruz.
            pictureBox1.Left = -222; // "pictureBox1" adlı resmi -222 birim sola yerleştiriyoruz.

            timer1.Start(); // "timer1" adlı timer'ı başlatıyoruz.
        }

        private void oyunbitt()
        {
            timer1.Stop();
            button1.Enabled = true;
            carpma.Visible = true;
            biz.Controls.Add(carpma);
            carpma.BringToFront();
            carpma.BackColor = Color.Transparent;
            MessageBox.Show("Kaza Yaptınız");
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            basla();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Left += yol_hizi;
            if (pictureBox1.Left > 623)
                pictureBox1.Left = 630;
            if (sol_yon) biz.Top -= araba_hizi;
            if (sag_yon) biz.Top += araba_hizi;
            if (biz.Top < 1)
            {
                sol_yon = false;
            }
            else if (biz.Top + biz.Height > 400)
            {
                sag_yon = false;
            }
            araba1.Left += diger_araba_hızı;
            araba2.Left += diger_araba_hızı;
            if (araba1.Left > pictureBox1.Width)
            {
                araba1.Top = rnd.Next(185, 387);
                araba1.Left = rnd.Next(100, 200) * -1;
            }
            if (araba2.Left > pictureBox1.Width)
            {
                araba2.Top = rnd.Next(185, 387);
                araba2.Left = rnd.Next(100, 200) * -1;
            }
            if (biz.Bounds.IntersectsWith(araba1.Bounds) || biz.Bounds.IntersectsWith(araba2.Bounds))
            {
                oyunbitt();
            }
        }
    }
}