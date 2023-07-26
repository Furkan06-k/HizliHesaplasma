using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Hızlı_Hesaplaşma
{
    public partial class öneri : Form
    {
        private OleDbConnection baglanti = new OleDbConnection();

        public öneri()
        {
            InitializeComponent();
            pictureBox3.Parent = pictureBox1;
            pictureBox3.BackColor = Color.Transparent;
            toolTip1.ToolTipIcon = ToolTipIcon.Warning;
            toolTip1.ToolTipTitle = "UYARI"; //tooltipin başlık ismi
            toolTip1.AutomaticDelay = 200; //milisaniye sonra tooltiplerin görüntülenmesi. Varsayılan değeri =500ms
            toolTip1.SetToolTip(this.textBox1, "adınızı giriniz");
            toolTip1.SetToolTip(this.textBox2, "soyadınızı giriniz");
            toolTip1.SetToolTip(this.textBox3, "@ işaretini, büyük harf, küçük harflere dikkat ediniz");
            toolTip1.SetToolTip(this.textBox4, "şikayetinizi veya önerinizi yazınız.");

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            seviye kyt = new seviye();
            kyt.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                string konu = textBox1.Text;
                string soyad = textBox2.Text;
                string metin = textBox4.Text;
                string kimden = textBox3.Text;

                string connectionString = "";// veri tabanını bağlayınız  acces mdb uzatısını yazınız 
                baglanti.ConnectionString = connectionString;

                OleDbCommand kayit = new OleDbCommand("INSERT INTO Giris (ad, soyad, email,mesaj) VALUES (@ad,@soyad, @email, @mesaj)", baglanti);

                kayit.Parameters.AddWithValue("@ad", textBox1);
                kayit.Parameters.AddWithValue("@soyad", textBox2);
                kayit.Parameters.AddWithValue("@email", textBox3);
                kayit.Parameters.AddWithValue("@mesaj", textBox4);

                try
                {
                    // Veritabanı bağlantısını aç ve kaydı ekle
                    baglanti.Open();
                    int etkilenenSatirSayisi = kayit.ExecuteNonQuery();
                    if (etkilenenSatirSayisi > 0)
                    {
                        MessageBox.Show("Kayıt başarıyla oluşturuldu.");
                    }
                    else
                    {
                        MessageBox.Show("Kayıt oluşturulamadı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
                finally
                {
                    // Veritabanı bağlantısını kapat
                    baglanti.Close();
                }

                // E-posta gönderme işlemleri
                MailMessage message = new MailMessage();
                SmtpClient client = new SmtpClient();
                client.Credentials = new NetworkCredential("furkan215611006@outlook.com", "fur.ri2023");
                client.Port = 587;
                client.Host = "smtp.office365.com";
                client.EnableSsl = true;
                message.To.Add(kimden);
                message.From = new MailAddress("furkan215611006@outlook.com");
                message.Subject = konu;
                message.Body = metin;
                client.Send(message);
                MessageBox.Show("İletiniz gönderildi.");

                this.Hide();
                seviye svy = new seviye();
                svy.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }

        }


        
    }
}
