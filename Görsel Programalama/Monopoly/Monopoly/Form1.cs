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
    public partial class FrmOyunAlanı : Form
    {
        public FrmOyunAlanı(string ad)
        {
            InitializeComponent();
            string OyuncuAdı = ad;
        }
        int zar1, zar2, OyuncuHak, RakipHak, i = 0, i1 = 0;
        decimal OyuncuParaMiktarı = 300.000m, RakipParaMiktarı = 300.000m;
        string[][] SoruHavuzu1 ={
                                   new string[] {"Sinekli Bakkal romanının yazarı aşağıdakilerden hangisidir?","Reşat Nuri Güntekin","Halide Edip Adıvar","Ziya Gökalp","Ömer Seyfettin","Halide Edip Adıvar","0"},
                                   new string[] {"Aşağıda Verilen İlk Çağ Uygarlıklarından Hangisi Yazıyı İcat Etmiştir?","Hititler","Elamlar","Sümerler","Urartular","Sümerler","0"},
                                   new string[] {"Aspirinin Hammaddesi Nedir?","Söğüt","Köknar","Kavak","Meşe","Söğüt","0"},
                                   
                               };

        string[][] SansKartları ={
                                   new string[] {"Trafik borcunuzu ödeyiniz.(5.000 TL)"},
                                   new string[] {"Büyük dedenizden miras kaldı.(50.000 TL)"},
                                   new string[] {"Yol bakım çalışması için para ödeyiniz.(10.000 TL)"},                                   
                                   new string[] {"Milli Piyango kazandınız.(50.000 TL)"},
                                   new string[] {"Su borcunuzu ödeyiniz(2.500 TL)"},
                                   new string[] {"Yerde para buldun(5.000 TL)"},
                                   new string[] {"Trafik sigortası(7.500 TL)"},
                                   new string[] {"Sayısal loto kazandınız(10.000 TL)"},
                                   new string[] {"Doğalgaz borcunuzu ödeyiniz(5.000 TL)"},
                                   new string[] {"Yarışmayı kazandın(10.000 TL)"},                                   
                               };
        decimal[][] SansKartlarıParaMiktarı ={ 
                           new decimal[]{5.000m},
                           new decimal[]{50.000m},
                           new decimal[]{10.000m},
                           new decimal[]{50.000m},
                           new decimal[]{2.500m},
                           new decimal[]{5.000m},
                           new decimal[]{7.500m},
                           new decimal[]{10.000m},
                           new decimal[]{5.000m},                           
                           new decimal[]{10.000m},
                          };
        string[][] KamuFonuKartları ={
                                   new string[] {"Kamu fonu 1","2500"},
                                   new string[] {"Kamu fonu 2","5000"},
                                   new string[] {"Kamu fonu 3","50000"},
                                   new string[] {"Kamu fonu 4","2500"},
                                   new string[] {"Kamu fonu 5","2500"},
                                   new string[] {"Kamu fonu 6","2500"},
                                   new string[] {"Kamu fonu 7","2500"},
                                   new string[] {"Kamu fonu 8","2500"},
                                   new string[] {"Kamu fonu 9","2500"},
                                   new string[] {"Kamu fonu 10","2500"},                                   
                               };

        string[][] Yerler ={
                           new string[] {"","","",""},
                           new string[] {"","","",""},
                           new string[] {"Manav","75.000","1.500","0"},
                           new string[] {"Sirk","100.000","2.000","0"},
                           new string[] {"","","",""},
                           new string[] {"Stadyum","250.000","5.000","0"},
                           new string[] {"Taksi Durağı","150.000","2.000","0"},
                           new string[] {"","","",""},
                           new string[] {"","","",""},
                           new string[] {"Otel","100.000","10.000","0"},
                           new string[] {"","","",""},
                           new string[] {"","","",""},
                           new string[] {"Market","100.000","1.500","0"},
                           new string[] {"Müze","150.000","2.000","0"},
                           new string[] {"Çiftlik","250.000","1.000","0"},
                           new string[] {"Hastahane","100.000","1.500","0"},
                           new string[] {"","","",""},
                           new string[] {"Pansiyon","100.000","1.500","0"},
                          };
        decimal[][] YerlerParaMiktarı ={ 
                           new decimal[]{0m},
                           new decimal[]{0m},
                           new decimal[]{75.000m},
                           new decimal[]{100.000m},
                           new decimal[]{0m},
                           new decimal[]{250.000m},
                           new decimal[]{150.000m},
                           new decimal[]{0m},
                           new decimal[]{0m},
                           new decimal[]{100.000m},
                           new decimal[]{0m},
                           new decimal[]{0m},
                           new decimal[]{100.000m},
                           new decimal[]{100.000m},
                           new decimal[]{150.000m},
                           new decimal[]{100.000m},
                           new decimal[]{0m},
                           new decimal[]{100.000m},
                          };
        
        public int[] Koordinatlar(int i)
        {
            int[][] kordinat = {
                                         new int[] {Kart1.Left+60,Kart1.Top+60},
                                         new int[] {Kart2.Left+20,Kart1.Top+50}, 
                                         new int[] {Kart3.Left+20,Kart1.Top+50}, 
                                         new int[] {Kart4.Left+20,Kart1.Top+50}, 
                                         new int[] {Kart5.Left+20,Kart1.Top+50}, 
                                         new int[] {Kart6.Left+20,Kart1.Top+50}, 
                                         new int[] {Kart7.Left+20,Kart1.Top+50}, 
                                         new int[] {Kart8.Left+20,Kart1.Top+50}, 
                                         new int[] {Kart9.Left+20,Kart1.Top+50}, 
                                         new int[] {Kart10.Left+60,Kart1.Top+60},
 
                                         new int[] {Kart11.Left+50,Kart11.Top+10}, 
                                         new int[] {Kart12.Left+50,Kart12.Top+10}, 
                                         new int[] {Kart13.Left+50,Kart13.Top+10}, 
                                         new int[] {Kart14.Left+50,Kart14.Top+10}, 
                                         new int[] {Kart15.Left+50,Kart15.Top+10}, 
                                         new int[] {Kart16.Left+50,Kart16.Top+10}, 
                                         new int[] {Kart17.Left+50,Kart17.Top+10}, 
                                         new int[] {Kart18.Left+50,Kart18.Top+10}, 
                                         new int[] {Kart19.Left+60,Kart19.Top+60},



                                         new int[] {Kart20.Left+20,Kart20.Top+50},
                                         new int[] {Kart21.Left+20,Kart21.Top+50}, 
                                         new int[] {Kart22.Left+20,Kart22.Top+50}, 
                                         new int[] {Kart23.Left+20,Kart23.Top+50}, 
                                         new int[] {Kart24.Left+20,Kart24.Top+50}, 
                                         new int[] {Kart25.Left+20,Kart25.Top+50}, 
                                         new int[] {Kart26.Left+20,Kart26.Top+50}, 
                                         new int[] {Kart27.Left+20,Kart27.Top+50}, 
                                         new int[] {Kart28.Left+60,Kart28.Top+60}, 

                                         new int[] {Kart29.Left+50,Kart29.Top+10}, 
                                         new int[] {Kart30.Left+50,Kart30.Top+10}, 
                                         new int[] {Kart31.Left+50,Kart31.Top+10}, 
                                         new int[] {Kart32.Left+50,Kart32.Top+10}, 
                                         new int[] {Kart33.Left+50,Kart33.Top+10}, 
                                         new int[] {Kart34.Left+50,Kart34.Top+10}, 
                                         new int[] {Kart35.Left+50,Kart35.Top+10}, 
                                         new int[] {Kart36.Left+50,Kart36.Top+10}, 


                                };
            return new int[] { kordinat[i][0], kordinat[i][1] };

        }

        public void KartKontrol(int deger)
        {
            if (deger == 1)
            {
                this.pcboxGelenKart.Image = global::Monopoly.Properties.Resources.k2;
                YerKontrol(deger);
            }
            else if (deger == 2)
            {
                this.pcboxGelenKart.Image = global::Monopoly.Properties.Resources.k3;
                YerKontrol(deger);
            }
            else if (deger == 3 || deger == 10 || deger == 19 || deger == 35)
            {
                lblAcıklama.Visible = true;
                Random kamufonukartı = new Random();
                int KartNo = kamufonukartı.Next(0, 10);
                pcboxGelenKart.Visible = false;
                pcboxArkaPlan.Visible = true;

                pnlKontrol.Visible = true;
                this.pcboxArkaPlan.Image = global::Monopoly.Properties.Resources.KamuFonuArkaplan;
                lblAcıklama.Text = KamuFonuKartları[KartNo][0];
            }
            else if (deger == 4)
            {
                this.pcboxGelenKart.Image = global::Monopoly.Properties.Resources.k5;
                YerKontrol(deger);
            }
            else if (deger == 5)
            {
                this.pcboxGelenKart.Image = global::Monopoly.Properties.Resources.k6;
                YerKontrol(deger);
            }
            else if (deger == 6 || deger == 28)
            {
                lblYerAdı.Visible = false;
                lblAlısFiyatı.Visible = true;
                lblAlısFiyatı.Left = 160;
                lblAcıklama.Text = "Yanlış yere park ettin dostum :)";
                btnSatınAl.Visible = false;
                lblKiraGeliri.Visible = false;
                pcboxArkaPlan.Visible = false;
                pcboxGelenKart.Visible = true;
                lblAcıklama.Visible = false;
                pnlKontrol.Visible = true;
                this.pcboxGelenKart.Image = global::Monopoly.Properties.Resources.k7;
                OyuncuParaMiktarı = OyuncuParaMiktarı - 2.000m;
                lblOyuncuParaMiktarı.Text = OyuncuParaMiktarı.ToString()+"  TL";
            }
            else if (deger == 7 || deger == 23)
            {
                MadenArastırma(deger);
            }
            else if (deger == 8)
            {
                this.pcboxGelenKart.Image = global::Monopoly.Properties.Resources.k9;
                YerKontrol(deger);
            }
            else if (deger == 9)
            {
                pnlKontrol.Visible = true;                
                lblAcıklama.Text = "Bir tur bekleme cezası.";
            }
            else if (deger == 11)
            {
                Bitmap drawBitmap;// Bitmap türünde bir değişken tanımladık.              
                drawBitmap = (Bitmap)Kart12.Image;// Bu değişkene pictureBox1in resmini atıyoruz.
                drawBitmap.RotateFlip(RotateFlipType.Rotate270FlipXY); // Ve en önemli yer olan resmimizi çevirme kısmı. Biz 90 derece çevirdik ama farklı seçeneklerde var. (270,180 derece vs...)
                pcboxGelenKart.Image = drawBitmap;// Bir üst satırda değişkenimize gönderdiğimiz resmi çevirmiştik, yani pictureBoxımızdaki resmi değil. Bu yüzden alttaki satırı yapmamız gerekiyor.
                YerKontrol(deger);
            }
            else if (deger == 12)
            {
                Bitmap drawBitmap;// Bitmap türünde bir değişken tanımladık.              
                drawBitmap = (Bitmap)Kart13.Image;// Bu değişkene pictureBox1in resmini atıyoruz.
                drawBitmap.RotateFlip(RotateFlipType.Rotate270FlipXY); // Ve en önemli yer olan resmimizi çevirme kısmı. Biz 90 derece çevirdik ama farklı seçeneklerde var. (270,180 derece vs...)
                pcboxGelenKart.Image = drawBitmap;// Bir üst satırda değişkenimize gönderdiğimiz resmi çevirmiştik, yani pictureBoxımızdaki resmi değil. Bu yüzden alttaki satırı yapmamız gerekiyor.
                YerKontrol(deger);
            }
            else if (deger == 13)
            {
                Bitmap drawBitmap;// Bitmap türünde bir değişken tanımladık.              
                drawBitmap = (Bitmap)Kart14.Image;// Bu değişkene pictureBox1in resmini atıyoruz.
                drawBitmap.RotateFlip(RotateFlipType.Rotate270FlipXY); // Ve en önemli yer olan resmimizi çevirme kısmı. Biz 90 derece çevirdik ama farklı seçeneklerde var. (270,180 derece vs...)
                pcboxGelenKart.Image = drawBitmap;// Bir üst satırda değişkenimize gönderdiğimiz resmi çevirmiştik, yani pictureBoxımızdaki resmi değil. Bu yüzden alttaki satırı yapmamız gerekiyor.
                YerKontrol(deger);
            }
            else if (deger == 14)
            {
                Bitmap drawBitmap;// Bitmap türünde bir değişken tanımladık.              
                drawBitmap = (Bitmap)Kart15.Image;// Bu değişkene pictureBox1in resmini atıyoruz.
                drawBitmap.RotateFlip(RotateFlipType.Rotate270FlipXY); // Ve en önemli yer olan resmimizi çevirme kısmı. Biz 90 derece çevirdik ama farklı seçeneklerde var. (270,180 derece vs...)
                pcboxGelenKart.Image = drawBitmap;// Bir üst satırda değişkenimize gönderdiğimiz resmi çevirmiştik, yani pictureBoxımızdaki resmi değil. Bu yüzden alttaki satırı yapmamız gerekiyor.
                YerKontrol(deger);
            }

            else if (deger == 15 || deger == 30)
            {
                lblAcıklama.Visible = true;
                lblAcıklama.Left = 170;
                Random sanskartı = new Random();
                int KartNo = sanskartı.Next(0, 10);
                pcboxGelenKart.Visible = false;
                pcboxArkaPlan.Visible = true;

                pnlKontrol.Visible = true;
                this.pcboxArkaPlan.Image = global::Monopoly.Properties.Resources.şasnkartlarıarkaplan;
                lblAcıklama.Text = SansKartları[KartNo][0];
                if (KartNo == 0 || KartNo == 2 || KartNo == 4 || KartNo == 6 || KartNo == 8)
                {
                    OyuncuParaMiktarı = OyuncuParaMiktarı - SansKartlarıParaMiktarı[KartNo][0];
                    lblOyuncuParaMiktarı.Text = OyuncuParaMiktarı.ToString() + "  TL";
                }
                else if (KartNo == 1 || KartNo == 3 || KartNo == 5 || KartNo == 7 || KartNo == 9)
                {
                    OyuncuParaMiktarı = OyuncuParaMiktarı + SansKartlarıParaMiktarı[KartNo][0];
                    lblOyuncuParaMiktarı.Text = OyuncuParaMiktarı.ToString() + "  TL";
                }
            }
            else if (deger == 16)
            {
                Bitmap drawBitmap;// Bitmap türünde bir değişken tanımladık.              
                drawBitmap = (Bitmap)Kart17.Image;// Bu değişkene pictureBox1in resmini atıyoruz.
                drawBitmap.RotateFlip(RotateFlipType.Rotate270FlipXY); // Ve en önemli yer olan resmimizi çevirme kısmı. Biz 90 derece çevirdik ama farklı seçeneklerde var. (270,180 derece vs...)
                pcboxGelenKart.Image = drawBitmap;// Bir üst satırda değişkenimize gönderdiğimiz resmi çevirmiştik, yani pictureBoxımızdaki resmi değil. Bu yüzden alttaki satırı yapmamız gerekiyor.
                YerKontrol(deger);
            }

        }

        public void YerKontrol(int i)
        {
            pcboxArkaPlan.Visible = false;
            pcboxGelenKart.Visible = true;
            lblAcıklama.Visible = false;
            pnlKontrol.Visible = true;
            lblYerAdı.Visible = true;
            lblAlısFiyatı.Visible = true;
            lblKiraGeliri.Visible = true;
            lblYerAdı.Text = Yerler[i + 1][0];
            lblAlısFiyatı.Text = "Alış Fiyatı:" + Yerler[i + 1][1] + "  TL";
            lblKiraGeliri.Text = "Kira Geliri:" + Yerler[i + 1][2] + "  TL";
            if (Yerler[i + 1][3] == "0")
            {
                btnSatınAl.Visible = true;
            }
            else
            {
                btnSatınAl.Visible = false;
            }

        }
        public void MadenArastırma(int i)
        {
            pcboxGelenKart.Visible = false;
            lblYerAdı.Visible = false;
            lblAlısFiyatı.Visible = false;
            lblKiraGeliri.Visible = false;
            pnlKontrol.Visible = true;
            pcboxArkaPlan.Visible = true;
            this.pcboxArkaPlan.Image = global::Monopoly.Properties.Resources.MadenArastırmaArkaplan;
            btnArastır.Visible = true;
            lblAcıklama.Left = 320;
            lblAcıklama.Width = 150;
            lblAcıklama.Text = "Maden Araştırması için 25.000 TL ödeme yapmalısınız";
        }

        private void btnZarAt_Click(object sender, EventArgs e)
        {
            btnZarAt.Visible = false;
            PcboxZar1.Visible = false;
            PcboxZar2.Visible = false;
            PcboxDonenZar.Visible = true;
            tmrOyuncuZarAt.Enabled = true;
        }

        private void tmrOyuncuZarAt_Tick(object sender, EventArgs e)
        {
            PcboxZar1.Visible = true;
            PcboxZar2.Visible = true;
            /*1. zar*/
            Random rnd1 = new Random();
            zar1 = rnd1.Next(1, 7);
            if (zar1 == 1)
            {
                this.PcboxZar1.Image = global::Monopoly.Properties.Resources.bir;
            }
            else if (zar1 == 2)
            {
                this.PcboxZar1.Image = global::Monopoly.Properties.Resources.iki;
            }
            else if (zar1 == 3)
            {
                this.PcboxZar1.Image = global::Monopoly.Properties.Resources.uc;
            }
            else if (zar1 == 4)
            {
                this.PcboxZar1.Image = global::Monopoly.Properties.Resources.dort;
            }
            else if (zar1 == 5)
            {
                this.PcboxZar1.Image = global::Monopoly.Properties.Resources.bes;
            }
            else if (zar1 == 6)
            {
                this.PcboxZar1.Image = global::Monopoly.Properties.Resources.altı;
            }

            /*2. zar*/
            Random rnd2 = new Random();
            zar2 = rnd1.Next(1, 7);
            if (zar2 == 1)
            {
                this.PcboxZar2.Image = global::Monopoly.Properties.Resources.bir;
            }
            else if (zar2 == 2)
            {
                this.PcboxZar2.Image = global::Monopoly.Properties.Resources.iki;
            }
            else if (zar2 == 3)
            {
                this.PcboxZar2.Image = global::Monopoly.Properties.Resources.uc;
            }
            else if (zar2 == 4)
            {
                this.PcboxZar2.Image = global::Monopoly.Properties.Resources.dort;
            }
            else if (zar2 == 5)
            {
                this.PcboxZar2.Image = global::Monopoly.Properties.Resources.bes;
            }
            else if (zar2 == 6)
            {
                this.PcboxZar2.Image = global::Monopoly.Properties.Resources.altı;
            }
            tmrOyuncuZarAt.Enabled = false;
            PcboxDonenZar.Visible = false;
            OyuncuHak = zar1 + zar2;
            tmrOyuncuHareket.Enabled = true;
        }
        private void tmrOyuncuHareket_Tick(object sender, EventArgs e)
        {
            i = i + 1;
            if (i >= 0 && i < 36)
            {
                int[] dizi = Koordinatlar(i);
                Oyuncu.Left = dizi[0];
                Oyuncu.Top = dizi[1];
            }
            else if (i >= 36)
            {
                i = 0;
                OyuncuParaMiktarı = OyuncuParaMiktarı + 2.000m;
                lblOyuncuParaMiktarı.Text = OyuncuParaMiktarı.ToString() + "  TL";
                int[] dizi = Koordinatlar(i);
                Oyuncu.Left = dizi[0];
                Oyuncu.Top = dizi[1];
            }
            OyuncuHak = OyuncuHak - 1;
            if (OyuncuHak == 0)
            {
                tmrOyuncuHareket.Enabled = false;
                KartKontrol(i);
            }
        }

        private void tmrRakipZarAt_Tick(object sender, EventArgs e)
        {
            PcboxZar1.Visible = true;
            PcboxZar2.Visible = true;
            /*1. zar*/
            Random rnd1 = new Random();
            zar1 = rnd1.Next(1, 7);
            if (zar1 == 1)
            {
                this.PcboxZar1.Image = global::Monopoly.Properties.Resources.bir;
            }
            else if (zar1 == 2)
            {
                this.PcboxZar1.Image = global::Monopoly.Properties.Resources.iki;
            }
            else if (zar1 == 3)
            {
                this.PcboxZar1.Image = global::Monopoly.Properties.Resources.uc;
            }
            else if (zar1 == 4)
            {
                this.PcboxZar1.Image = global::Monopoly.Properties.Resources.dort;
            }
            else if (zar1 == 5)
            {
                this.PcboxZar1.Image = global::Monopoly.Properties.Resources.bes;
            }
            else if (zar1 == 6)
            {
                this.PcboxZar1.Image = global::Monopoly.Properties.Resources.altı;
            }

            /*2. zar*/
            Random rnd2 = new Random();
            zar2 = rnd1.Next(1, 7);
            if (zar2 == 1)
            {
                this.PcboxZar2.Image = global::Monopoly.Properties.Resources.bir;
            }
            else if (zar2 == 2)
            {
                this.PcboxZar2.Image = global::Monopoly.Properties.Resources.iki;
            }
            else if (zar2 == 3)
            {
                this.PcboxZar2.Image = global::Monopoly.Properties.Resources.uc;
            }
            else if (zar2 == 4)
            {
                this.PcboxZar2.Image = global::Monopoly.Properties.Resources.dort;
            }
            else if (zar2 == 5)
            {
                this.PcboxZar2.Image = global::Monopoly.Properties.Resources.bes;
            }
            else if (zar2 == 6)
            {
                this.PcboxZar2.Image = global::Monopoly.Properties.Resources.altı;
            }
            tmrRakipZarAt.Enabled = false;
            PcboxDonenZar.Visible = false;
            RakipHak = zar1 + zar2;
            tmrRakipHareket.Enabled = true;
        }
        private void tmrRakipHareket_Tick(object sender, EventArgs e)
        {
            i1 = i1 + 1;
            if (i1 >= 0 && i1 < 36)
            {
                int[] dizi = Koordinatlar(i1);
                Rakip.Left = dizi[0];
                Rakip.Top = dizi[1];
            }
            else if (i1 >= 36)
            {
                i1 = 0;
                RakipParaMiktarı = RakipParaMiktarı + 2.000m;
                lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                int[] dizi = Koordinatlar(i1);
                Rakip.Left = dizi[0];
                Rakip.Top = dizi[1];
            }
            RakipHak = RakipHak - 1;
            if (RakipHak == 0)
            {
                tmrRakipHareket.Enabled = false;
                //KartKontrol(i1);
                PcboxZar1.Visible = false;
                PcboxZar2.Visible = false;
                btnZarAt.Visible = true;
            }
        }
        
        private void btnArastır_Click(object sender, EventArgs e)
                {
                    btnArastır.Visible = false;
                    pictureBox42.Visible = true;
                    lblArastırma.Visible = true;
                    OyuncuParaMiktarı = OyuncuParaMiktarı - 25.000m;
                    lblOyuncuParaMiktarı.Text = OyuncuParaMiktarı.ToString();
                    tmrArastırma.Enabled = true;
                }
        private void tmrArastırma_Tick(object sender, EventArgs e)
        {
            Random maden = new Random();
            int sayi = maden.Next(0, 2);
            if (sayi == 0)
            {
                tmrArastırma.Enabled = false;
                pictureBox42.Visible = false;
                lblArastırma.Visible = false;
                MessageBox.Show("Maden Araştırması başarısız");
            }
            else if (sayi == 1)
            {
                tmrArastırma.Enabled = false;
                pictureBox42.Visible = false;
                lblArastırma.Visible = false;
                MessageBox.Show("Maden Araştırması başarılı 100.000 TL kazandınız");
                OyuncuParaMiktarı = OyuncuParaMiktarı + 100.000m;
                lblOyuncuParaMiktarı.Text = OyuncuParaMiktarı.ToString();
            }
        }

        private void btnSatınAl_Click(object sender, EventArgs e)
            {
                if (OyuncuParaMiktarı >= YerlerParaMiktarı[i + 1][0])
                {
                    MessageBox.Show("Satın Alındı");
                    btnSatınAl.Visible = false;
                    Yerler[i + 1][3] = "1";
                    OyuncuParaMiktarı = OyuncuParaMiktarı - YerlerParaMiktarı[i + 1][0];
                    lblOyuncuParaMiktarı.Text = OyuncuParaMiktarı.ToString() + "  TL";
                    if (i == 1)
                    {
                        lblManav.BackColor = Color.LightBlue;
                        lblManav.Text = "Oyuncu";
                    }
                    else if (i == 2)
                    {
                        lblSirk.BackColor = Color.LightBlue;
                        lblSirk.Text = "Oyuncu";
                    }
                    else if (i == 4)
                    {
                        lblStadyum.BackColor = Color.LightBlue;
                        lblStadyum.Text = "Oyuncu";
                    }
                    else if (i == 5)
                    {
                        lblTaksiDuragı.BackColor = Color.LightBlue;
                        lblTaksiDuragı.Text = "Oyuncu";
                    }
                    else if (i == 8)
                    {
                        lblOtel.BackColor = Color.LightBlue;
                        lblOtel.Text = "Oyuncu";
                    }
                    else if (i == 11)
                    {
                        lblMarket.BackColor = Color.LightBlue;
                        lblMarket.Text = "Oyuncu";
                    }
                    else if (i == 12)
                    {
                        lblMüze.BackColor = Color.LightBlue;
                        lblMüze.Text = "Oyuncu";
                    }
                    else if (i == 13)
                    {
                        lblCiftlik.BackColor = Color.LightBlue;
                        lblCiftlik.Text = "Oyuncu";
                    }
                    else if (i == 14)
                    {
                        lblHastahane.BackColor = Color.LightBlue;
                        lblHastahane.Text = "Oyuncu";
                    }
                    else if (i == 16)
                    {
                        lblPansiyon.BackColor = Color.LightBlue;
                        lblPansiyon.Text = "Oyuncu";
                    }
                }
                else
                {
                    MessageBox.Show("Paranız Yetersiz");
                }
            }
        private void btnTamam_Click(object sender, EventArgs e)
        {
            lblYerAdı.Visible = false;
            lblAlısFiyatı.Visible = false;
            lblKiraGeliri.Visible = false;
            pcboxGelenKart.Visible = false;
            pcboxArkaPlan.Visible = false;
            lblAcıklama.Visible = false;
            btnArastır.Visible = false;
            lblArastırma.Visible = false;
            pictureBox42.Visible = false;        
            pnlKontrol.Visible = false;
            PcboxZar1.Visible = false;
            PcboxZar2.Visible = false;
            PcboxDonenZar.Visible = true;
            tmrRakipZarAt.Enabled = true;
        }
        

         private void FrmOyunAlanı_Load(object sender, EventArgs e)
                {
                    lblOyuncuParaMiktarı.Text = OyuncuParaMiktarı.ToString() + "  TL";
                    lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "   TL";
                }

         private void FrmOyunAlanı_FormClosing(object sender, FormClosingEventArgs e)
         {
             Application.Exit();
         }

         

        

    }
}
