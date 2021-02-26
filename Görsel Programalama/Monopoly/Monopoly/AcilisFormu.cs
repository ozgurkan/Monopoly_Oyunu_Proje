using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Monopoly
{
    public partial class AcilisFormu : Form
    {
        public AcilisFormu()
        {
            InitializeComponent();
        }

        int SimdikiWidth = 1920;
        int SimdikiHeight = 1080;
        int i = 0;




        private void AcilisFormu_Load(object sender, EventArgs e)
        {
            Rectangle ClientCozunurluk = new Rectangle();
            ClientCozunurluk = Screen.GetBounds(ClientCozunurluk);
            float OranWidth = ((float)ClientCozunurluk.Width / (float)SimdikiWidth);
            float OranHeight = ((float)ClientCozunurluk.Height / (float)SimdikiHeight);
            this.Scale(OranWidth, OranHeight);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen bir isim giriniz");
            }
            else
            {
                pictureBox1.Visible = true;
                timer1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i = i + 1;
            label2.Text = "Oyun Yükleniyor:\n          %" + i;
            if (i >= 100)
            {
                timer1.Enabled = false;
                FrmOyunAlanı Yeni = new FrmOyunAlanı(textBox1.Text);
                this.Hide();
                Yeni.Show();
            }
        }
    }
}
