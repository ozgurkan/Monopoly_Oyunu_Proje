using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Configuration;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Security.AccessControl;

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

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=veritabani.accdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter adp = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        DataTable tablo = new DataTable();

        void listele()
        {
            baglanti.Open();
            OleDbDataAdapter adp = new OleDbDataAdapter("select top 10, * from Puan order by OyuncuPuan desc", baglanti);
            adp.Fill(tablo);
            dataGridView1.DataSource = tablo;
            adp.Dispose();
            baglanti.Close();
        }


        private void AcilisFormu_Load(object sender, EventArgs e)
        {
            var klasor = new DirectoryInfo(Application.StartupPath);
            var klasorGuvenligi = klasor.GetAccessControl();
            var rule = new FileSystemAccessRule("Everyone", FileSystemRights.Write, InheritanceFlags.None | InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow);
            klasorGuvenligi.SetAccessRule(rule);
            klasor.SetAccessControl(klasorGuvenligi);
            MessageBox.Show(Application.StartupPath.ToString());



            listele();
            Rectangle ClientCozunurluk = new Rectangle();
            ClientCozunurluk = Screen.GetBounds(ClientCozunurluk);
            float OranWidth = ((float)ClientCozunurluk.Width / (float)SimdikiWidth);
            float OranHeight = ((float)ClientCozunurluk.Height / (float)SimdikiHeight);
            this.Scale(OranWidth, OranHeight);
        }

        public int OyuncuSayısı = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i = i + 1;
            label2.Text = "Oyun Yükleniyor:\n          %" + i;
            if (i >= 100)
            {
                timer1.Enabled = false;
                if(OyuncuSayısı==1){
                FrmOyunAlanı Yeni = new FrmOyunAlanı(txtOyuncu1.Text);
                 this.Hide();
                Yeni.Show();
                }else if(OyuncuSayısı==2){
                    FrmOyunAlanı1 Yeni = new FrmOyunAlanı1(txtOyuncu1.Text,txtOyuncu2.Text);
                    this.Hide();
                    Yeni.Show();
                }
               
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            if (radioButton1.Checked == true)
            {
                txtOyuncu2.Enabled = false;
                txtOyuncu2.Text = "Bilgisayar";
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                if (txtOyuncu1.Text == "")
                {
                    MessageBox.Show("Lütfen bir isim giriniz");
                }
                else
                {
                    pictureBox1.Visible = true;
                    timer1.Enabled = true;
                }
            }
            else if (radioButton2.Checked == true)
            {
                if (txtOyuncu1.Text == "" || txtOyuncu2.Text=="")
                {
                    MessageBox.Show("Lütfen bir isim giriniz");
                }
                else
                {
                    pictureBox1.Visible = true;
                    timer1.Enabled = true;
                }
            }           
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            i = 0;
            pictureBox1.Visible = false;
            label2.Text = "";
            panel1.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true; 
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            OyuncuSayısı = 1;
            txtOyuncu2.Enabled = false;
            txtOyuncu2.Text = "Bilgisayar";
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            OyuncuSayısı = 2;
            txtOyuncu2.Enabled = true;
            txtOyuncu2.Text = "";
        }

        private void AcilisFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            dataGridView1.Visible = true;
            btndatagridkapat.Visible = true;
        }

        private void btndatagridkapat_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            dataGridView1.Visible = false;
            btndatagridkapat.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Program Files (x86)\Monopoly V.1.0\yardım.docx");

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }




    }
}
