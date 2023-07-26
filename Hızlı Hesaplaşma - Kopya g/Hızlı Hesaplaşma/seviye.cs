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
    public partial class seviye : Form
    {
        public seviye()
        {
            InitializeComponent();
            pictureBox3.Parent = pictureBox1;
            pictureBox3.BackColor = Color.Transparent;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void hakkımızdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Hakkımızda kyt = new Hakkımızda();
            kyt.Show();
            this.Hide();
        }

        private void nasılOynanırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nasıloynanır kyt = new nasıloynanır();
            kyt.Show();
            this.Hide();
        }

        private void öneriVeŞikayetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            öneri kyt = new öneri();
            kyt.Show();
            this.Hide();
        }

        private void kolay_Click(object sender, EventArgs e)
        {
            kolay kly = new kolay();
            kly.Show();
            this.Hide();
        }

        private void orta_Click(object sender, EventArgs e)
        {
            orta ort = new orta();
            ort.Show();
            this.Hide();
        }

        private void zor_Click(object sender, EventArgs e)
        {
           zor zr = new zor();
            zr.Show();
            this.Hide();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
           skor skr = new skor();
           skr.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Hide();
            this.Close();
        }
    }
}
