using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Data.OleDb;
using System.Configuration;

namespace Monopoly
{
    public partial class FrmOyunAlanı : Form
    {
       public string OyuncuAdı;
        public FrmOyunAlanı(string ad)
        {
            InitializeComponent();
            OyuncuAdı = ad;            
        }
        int zar1, zar2, OyuncuHak, RakipHak, i = 0, i1 = 0;
        decimal OyuncuParaMiktarı = 50.000m, RakipParaMiktarı = 50.000m;
        string[][] SoruHavuzu1 ={
                                   new string[] {"Galatasaray uefa kupasını 17 Mayıs 2000 tarihinde almıştır.","evet"},
                                   new string[] {"İstanbul 19 Nisan 1453 tarihinde feth edilmiştir","hayır"},
                                   new string[] {"Fenerbahçe spor kulübü 3 Mayıs 1907 tarihinde kurulmuştur.","evet"},
                                   new string[] {"Galatasaray spor kulübü 30 Ekim 1905 tarihinde kurulmuştur","evet"},
                                   new string[] {"Cumhuriyet 29 Ekim 1923 tarihinde ilan edilmiştir.","evet"},
                                   new string[] {"Birinci dünya savaşı 28 Temmuz 1914'de başlamış ve 11 Kasım 1917'de sona ermiştir.","hayır"},
                                   new string[] {"İlk osmanlı padişahı I. Orhan'dır.","hayır"},
                                   new string[] {"Ali Kuşçu astronomi ve matematik ile ün salmıştır.","evet"},
                                   new string[] {"Seyahatname,Evliya Çelebi tarafından 17. yüzyılda yazılmış olan çok ünlü bir gezi yazısı kitabıdır. 10 ciltten oluşur.","evet"},
                                   new string[] {"Piri Reis Haritası günümüze kalan, Amerika kıtasını gösteren en eski haritalardan biridir.","evet"},
                                   new string[] {"Kurtuluş Savaşı, 24 Temmuz 1923'te imzalanan Lozan Antlaşması'yla sonuçlandı.","evet"},
                                   new string[] {"3 Mart 1925'te TBMM'de kabul edilen bir kanunla halifelik kaldırılmıştır.","hayır"},
                                   new string[] {"17 Şubat 1928 tarihinde Aşar Vergisi kaldırılmıştır.","hayır"},
                                   new string[] {"25 Kasım 1925'te Şapka Kanunu kabul edildi.","evet"},
                                   new string[] {"12 Temmuz 1932'de Atatürk'ün talimatıyla Türk Dili Tetkik Cemiyeti kurulmuştur.","evet"},                              
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
                                   new string[] {"Kredi borcunuzu ödeyiniz.(50.000 TL)"},
                                   new string[] {"Devlet yardımı kazandınız.(10.000 TL)"},
                                   new string[] {"Kredi borcunuzu ödeyiniz.(15.000 TL)"},
                                   new string[] {"Devlet yardımı kazandınız.(50.000 TL)"},
                                   new string[] {"Kredi borcunuzu ödeyiniz.(5.500 TL)"},
                                   new string[] {"Devlet yardımı kazandınız.(8.000 TL)"},
                                   new string[] {"Kredi borcunuzu ödeyiniz.(7.500 TL)"},
                                   new string[] {"Devlet yardımı kazandınız.(20.000 TL)"},
                                   new string[] {"Kredi borcunuzu ödeyiniz.(14.000 TL)"},
                                   new string[] {"Devlet yardımı kazandınız.(19.000 TL)"},                                   
                               };
        decimal[][] KamuFonuKartlarıParaMiktarı ={ 
                           new decimal[]{50.000m},
                           new decimal[]{10.000m},
                           new decimal[]{15.000m},
                           new decimal[]{50.000m},
                           new decimal[]{5.500m},
                           new decimal[]{8.000m},
                           new decimal[]{7.500m},
                           new decimal[]{20.000m},
                           new decimal[]{14.000m},                           
                           new decimal[]{19.000m},
                          };

        string[][] Yerler ={
                           new string[] {"","","",""},
                           new string[] {"","","",""},
                           new string[] {"Manav","75.000","5.000","0"},
                           new string[] {"Sirk","100.000","8.000","0"},
                           new string[] {"","","",""},
                           new string[] {"Stadyum","100.000","10.000","0"},
                           new string[] {"Taksi Durağı","10.000","2.000","0"},
                           new string[] {"","","",""},
                           new string[] {"","","",""},
                           new string[] {"Otel","100.000","10.000","0"},
                           new string[] {"","","",""},
                           new string[] {"","","",""},
                           new string[] {"Market","100.000","10.500","0"},
                           new string[] {"Müze","150.000","20.000","0"},
                           new string[] {"Çiftlik","250.000","50.000","0"},
                           new string[] {"Hastahane","100.000","5.500","0"},
                           new string[] {"","","",""},
                           new string[] {"Pansiyon","100.000","10.500","0"},
                           new string[] {"Tamirci","125.000","15.500","0"},
                           new string[] {"","","",""},
                           new string[] {"","","",""},
                           new string[] {"Restaurant","250.000","28.500","0"},
                           new string[] {"Galeri","350.000","50.500","0"},
                           new string[] {"Sinema","220.000","26.500","0"},
                           new string[] {"","","",""},
                           new string[] {"","","",""},
                           new string[] {"İş Merkezi","100.000","12.500","0"},
                           new string[] {"Terzi","25.000","4.500","0"},
                           new string[] {"","","",""},
                           new string[] {"","","",""},
                           new string[] {"Balıkçı","50.000","7.500","0"},
                           new string[] {"","","",""},
                           new string[] {"A.V.M","100.000","9.500","0"},
                           new string[] {"Fırın","45.000","10.500","0"},
                           new string[] {"Pizzacı","65.000","6.500","0"},
                           new string[] {"Dondurmacı","65.000","16.500","0"},
                           new string[] {"","","",""},
                           };
        decimal[][] YerlerParaMiktarı ={ 
                           new decimal[]{0m,0m},
                           new decimal[]{0m,0m},
                           new decimal[]{75.000m,5.000m},
                           new decimal[]{100.000m,8.000m},
                           new decimal[]{0m,0m},
                           new decimal[]{100.000m,10.000m},
                           new decimal[]{10.000m,2.000m},
                           new decimal[]{0m,0m},
                           new decimal[]{0m,0m},
                           new decimal[]{100.000m,10.000m},
                           new decimal[]{0m,0m},
                           new decimal[]{0m,0m},
                           new decimal[]{100.000m,10.500m},
                           new decimal[]{150.000m,20.000m},
                           new decimal[]{250.000m,50.000m},
                           new decimal[]{100.000m,5.500m},
                           new decimal[]{0m,0m},
                           new decimal[]{100.000m,10.500m},
                           new decimal[]{125.000m,15.500m},
                           new decimal[]{0m,0m},
                           new decimal[]{0m,0m},
                           new decimal[]{250.000m,28.500m},
                           new decimal[]{350.000m,50.500m},
                           new decimal[]{220.000m,26.500m},
                           new decimal[]{0m,0m},
                           new decimal[]{0m,0m},
                           new decimal[]{100.000m,12.500m},
                           new decimal[]{25.000m,4.500m},
                           new decimal[]{0m,0m},
                           new decimal[]{0m,0m},
                           new decimal[]{50.000m,7.500m},
                           new decimal[]{0m,0m},
                           new decimal[]{100.000m,9.500m},
                           new decimal[]{45.000m,10.500m},
                           new decimal[]{65.000m,6.500m},
                           new decimal[]{65.000m,16.500m},
                           new decimal[]{0m,0m},
                          };

        public int[] Koordinatlar(int i)
        {
            int[][] kordinat = {
                                         new int[] {Kart1.Left+60,Kart1.Top+60},
                                         new int[] {pnlManav.Left+20,Kart1.Top+50}, 
                                         new int[] {pnlSirk.Left+20,Kart1.Top+50}, 
                                         new int[] {pnlKamuFonu1.Left+20,Kart1.Top+50}, 
                                         new int[] {pnlStadyum.Left+20,Kart1.Top+50},
                                         new int[] {pnlTaksiDuragı.Left+20,Kart1.Top+50},                                         
                                         new int[] {pnlParkCezası1.Left+20,Kart1.Top+50}, 
                                         new int[] {pnlMadenArastırması1.Left+20,Kart1.Top+50}, 
                                         new int[] {pnlOtel.Left+20,Kart1.Top+50}, 
                                         new int[] {Kart10.Left+60,Kart1.Top+60},
 
                                         new int[] {Kart11.Left+50,pnlKamuFonu2.Top+10}, 
                                         new int[] {Kart12.Left+50,pnlMarket.Top+10}, 
                                         new int[] {Kart13.Left+50,pnlMuze.Top+10}, 
                                         new int[] {Kart14.Left+50,pnlCiftlik.Top+10}, 
                                         new int[] {Kart15.Left+50,pnlHastahane.Top+10}, 
                                         new int[] {Kart16.Left+50,pnlSansKartı1.Top+10}, 
                                         new int[] {Kart17.Left+50,pnlPansiyon.Top+10}, 
                                         new int[] {Kart18.Left+50,pnlTamirci.Top+10}, 
                                         new int[] {Kart19.Left+60,Kart19.Top+60},



                                         new int[] {pnlKamuFonu3.Left+20,Kart20.Top+50},
                                         new int[] {pnlRestaurant.Left+20,Kart21.Top+50}, 
                                         new int[] {pnlGaleri.Left+20,Kart22.Top+50}, 
                                         new int[] {pnlSinema.Left+20,Kart23.Top+50}, 
                                         new int[] {pnlMadenArastırması2.Left+20,Kart24.Top+50}, 
                                         new int[] {pnlSansKartı2.Left+20,Kart25.Top+50}, 
                                         new int[] {pnlİsMerkezi.Left+20,Kart26.Top+50}, 
                                         new int[] {pnlTerzi.Left+20,Kart27.Top+50}, 
                                         new int[] {Kart28.Left+60,Kart28.Top+60}, 

                                         new int[] {pnlParkCezası2.Left+50,pnlParkCezası2.Top+10}, 
                                         new int[] {pnlBalikci.Left+50,pnlBalikci.Top+10}, 
                                         new int[] {pnlSansKartı3.Left+50,pnlSansKartı3.Top+10}, 
                                         new int[] {pnlAvm.Left+50,pnlAvm.Top+10}, 
                                         new int[] {pnlFirin.Left+50,pnlFirin.Top+10}, 
                                         new int[] {pnlPizzaci.Left+50,pnlPizzaci.Top+10}, 
                                         new int[] {pnlDondurmaci.Left+50,pnlDondurmaci.Top+10}, 
                                         new int[] {pnlKamuFonu4.Left+50,pnlKamuFonu4.Top+10}, 


                                };
            return new int[] { kordinat[i][0], kordinat[i][1] };

        }

        public void KartKontrol(int deger)
        {
            if(deger==0){
                PcboxZar1.Visible = false;
                PcboxZar2.Visible = false;
                PcboxDonenZar.Visible = true;
                tmrRakipZarAt.Enabled = true;
            }
            else if (deger == 1)
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
                lblAcıklama.Left = 140;
                lblAcıklama.Visible = true;
                btnSatınAl.Visible = false;
                Random kamufonukartı = new Random();
                int KartNo = kamufonukartı.Next(0, 10);
                pcboxGelenKart.Visible = false;
                pcboxArkaPlan.Visible = true;
                pnlKontrol.Visible = true;
                this.pcboxArkaPlan.Image = global::Monopoly.Properties.Resources.KamuFonuArkaplan;
                lblAcıklama.Text = KamuFonuKartları[KartNo][0];

                if (KartNo == 0 || KartNo == 2 || KartNo == 4 || KartNo == 6 || KartNo == 8)
                {
                    SoundPlayer muzikcal = new SoundPlayer();
                    muzikcal.Stream = Properties.Resources.sanskartıbasarısız;
                    muzikcal.Play();
                    OyuncuParaMiktarı = OyuncuParaMiktarı - KamuFonuKartlarıParaMiktarı[KartNo][0];
                    lblOyuncuParaMiktarı.Text = OyuncuParaMiktarı.ToString() + "  TL";
                }
                else if (KartNo == 1 || KartNo == 3 || KartNo == 5 || KartNo == 7 || KartNo == 9)
                {
                    SoundPlayer muzikcal = new SoundPlayer();
                    muzikcal.Stream = Properties.Resources.sanskartıbasarılı;
                    muzikcal.Play();
                    OyuncuParaMiktarı = OyuncuParaMiktarı + KamuFonuKartlarıParaMiktarı[KartNo][0];
                    lblOyuncuParaMiktarı.Text = OyuncuParaMiktarı.ToString() + "  TL";
                }
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
                lblAlısFiyatı.Visible = false;  
                lblKiraGeliri.Visible = false;
                pcboxArkaPlan.Visible = false;
                lblAcıklama.Visible = true;
                lblAcıklama.Left = 300;
                lblAcıklama.Text = "Yanlış yere park ettin dostum :)";
                btnSatınAl.Visible = false;
                pcboxGelenKart.Visible = true;                
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
                MessageBox.Show("oyuncu bir tur bekleme cezası aldı");
                PcboxZar1.Visible = false;
                PcboxZar2.Visible = false;
                tmrRakipZarAt.Enabled = true;
            }
            else if (deger == 11)
            {
                Bitmap drawBitmap;// Bitmap türünde bir değişken tanımladık.              
                drawBitmap = (Bitmap)Kart12.Image;// Bu değişkene pictureBox1in resmini atıyoruz.
                drawBitmap.RotateFlip(RotateFlipType.Rotate270FlipXY); // Ve en önemli yer olan resmimizi çevirme kısmı. Biz 90 derece çevirdik ama farklı seçeneklerde var. (270,180 derece vs...)
                pcboxGelenKart.Image = drawBitmap; // Bir üst satırda değişkenimize gönderdiğimiz resmi çevirmiştik, yani pictureBoxımızdaki resmi değil. Bu yüzden alttaki satırı yapmamız gerekiyor.          
                this.Kart12.Image = global::Monopoly.Properties.Resources.k12;
                YerKontrol(deger);
            }
            else if (deger == 12)
            {
                Bitmap drawBitmap;// Bitmap türünde bir değişken tanımladık.              
                drawBitmap = (Bitmap)Kart13.Image;// Bu değişkene pictureBox1in resmini atıyoruz.
                drawBitmap.RotateFlip(RotateFlipType.Rotate270FlipXY); // Ve en önemli yer olan resmimizi çevirme kısmı. Biz 90 derece çevirdik ama farklı seçeneklerde var. (270,180 derece vs...)
                pcboxGelenKart.Image = drawBitmap;// Bir üst satırda değişkenimize gönderdiğimiz resmi çevirmiştik, yani pictureBoxımızdaki resmi değil. Bu yüzden alttaki satırı yapmamız gerekiyor.
                this.Kart13.Image = global::Monopoly.Properties.Resources.k13;
                YerKontrol(deger);
            }
            else if (deger == 13)
            {
                Bitmap drawBitmap;// Bitmap türünde bir değişken tanımladık.              
                drawBitmap = (Bitmap)Kart14.Image;// Bu değişkene pictureBox1in resmini atıyoruz.
                drawBitmap.RotateFlip(RotateFlipType.Rotate270FlipXY); // Ve en önemli yer olan resmimizi çevirme kısmı. Biz 90 derece çevirdik ama farklı seçeneklerde var. (270,180 derece vs...)
                pcboxGelenKart.Image = drawBitmap;// Bir üst satırda değişkenimize gönderdiğimiz resmi çevirmiştik, yani pictureBoxımızdaki resmi değil. Bu yüzden alttaki satırı yapmamız gerekiyor.
                this.Kart14.Image = global::Monopoly.Properties.Resources.k14;
                YerKontrol(deger);
            }
            else if (deger == 14)
            {
                Bitmap drawBitmap;// Bitmap türünde bir değişken tanımladık.              
                drawBitmap = (Bitmap)Kart15.Image;// Bu değişkene pictureBox1in resmini atıyoruz.
                drawBitmap.RotateFlip(RotateFlipType.Rotate270FlipXY); // Ve en önemli yer olan resmimizi çevirme kısmı. Biz 90 derece çevirdik ama farklı seçeneklerde var. (270,180 derece vs...)
                pcboxGelenKart.Image = drawBitmap;// Bir üst satırda değişkenimize gönderdiğimiz resmi çevirmiştik, yani pictureBoxımızdaki resmi değil. Bu yüzden alttaki satırı yapmamız gerekiyor.
                this.Kart15.Image = global::Monopoly.Properties.Resources.k15;
                YerKontrol(deger);
            }

            else if (deger == 15||deger==24 || deger == 30)
            {
                lblAcıklama.Left = 140;
                lblAcıklama.Visible = true;
                btnSatınAl.Visible = false;
                Random sanskartı = new Random();
                int KartNo = sanskartı.Next(0, 10);
                pcboxGelenKart.Visible = false;
                pcboxArkaPlan.Visible = true;

                pnlKontrol.Visible = true;
                this.pcboxArkaPlan.Image = global::Monopoly.Properties.Resources.şasnkartlarıarkaplan;
                lblAcıklama.Text = SansKartları[KartNo][0];
                if (KartNo == 0 || KartNo == 2 || KartNo == 4 || KartNo == 6 || KartNo == 8)
                {
                    SoundPlayer muzikcal = new SoundPlayer();
                    muzikcal.Stream = Properties.Resources.sanskartıbasarısız;
                    muzikcal.Play();
                    OyuncuParaMiktarı = OyuncuParaMiktarı - SansKartlarıParaMiktarı[KartNo][0];
                    lblOyuncuParaMiktarı.Text = OyuncuParaMiktarı.ToString() + "  TL";
                }
                else if (KartNo == 1 || KartNo == 3 || KartNo == 5 || KartNo == 7 || KartNo == 9)
                {
                    SoundPlayer muzikcal = new SoundPlayer();
                    muzikcal.Stream = Properties.Resources.sanskartıbasarılı;
                    muzikcal.Play();
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
                this.Kart17.Image = global::Monopoly.Properties.Resources.k17;
                YerKontrol(deger);
            }
            else if (deger == 17)
            {
                Bitmap drawBitmap;// Bitmap türünde bir değişken tanımladık.              
                drawBitmap = (Bitmap)Kart18.Image;// Bu değişkene pictureBox1in resmini atıyoruz.
                drawBitmap.RotateFlip(RotateFlipType.Rotate270FlipXY); // Ve en önemli yer olan resmimizi çevirme kısmı. Biz 90 derece çevirdik ama farklı seçeneklerde var. (270,180 derece vs...)
                pcboxGelenKart.Image = drawBitmap;// Bir üst satırda değişkenimize gönderdiğimiz resmi çevirmiştik, yani pictureBoxımızdaki resmi değil. Bu yüzden alttaki satırı yapmamız gerekiyor.
                this.Kart18.Image = global::Monopoly.Properties.Resources.k18;
                YerKontrol(deger);
            }
            else if (deger == 18)
            { 
                Random soruhavuzu = new Random();
                int SoruNo = soruhavuzu.Next(0, 15);
                DialogResult cevap = new DialogResult();
                cevap = MessageBox.Show(SoruHavuzu1[SoruNo][0], "SORU", MessageBoxButtons.YesNo);
                if (cevap == DialogResult.Yes) {
                    if (SoruHavuzu1[SoruNo][1] == "evet") {
                        MessageBox.Show("Tebrikler doğru.10.000 TL kazandınız");
                        OyuncuParaMiktarı = OyuncuParaMiktarı + 10.000m;
                        lblOyuncuParaMiktarı.Text = OyuncuParaMiktarı.ToString()+"  TL";
                        PcboxZar1.Visible = false;
                        PcboxZar2.Visible = false;
                        PcboxDonenZar.Visible = true;
                        tmrRakipZarAt.Enabled = true;
                    }
                    else if (SoruHavuzu1[SoruNo][1] == "hayır")
                    {
                        MessageBox.Show("Yanlış cevap. 10.000 TL kaybettiniz.");
                        OyuncuParaMiktarı = OyuncuParaMiktarı - 10.000m;
                        lblOyuncuParaMiktarı.Text = OyuncuParaMiktarı.ToString() + "  TL";
                        PcboxZar1.Visible = false;
                        PcboxZar2.Visible = false;
                        PcboxDonenZar.Visible = true;
                        tmrRakipZarAt.Enabled = true;
                    }
                }
                else if (cevap == DialogResult.No) {
                    if (SoruHavuzu1[SoruNo][1] == "hayır")
                    {
                        MessageBox.Show("Tebrikler doğru.10.000 TL kazandınız");
                        OyuncuParaMiktarı = OyuncuParaMiktarı + 10.000m;
                        lblOyuncuParaMiktarı.Text = OyuncuParaMiktarı.ToString() + "  TL";
                        PcboxZar1.Visible = false;
                        PcboxZar2.Visible = false;
                        PcboxDonenZar.Visible = true;
                        tmrRakipZarAt.Enabled = true;
                    }
                    else if (SoruHavuzu1[SoruNo][1] == "evet")
                    {
                        MessageBox.Show("Yanlış cevap. 10.000 TL kaybettiniz.");
                        OyuncuParaMiktarı = OyuncuParaMiktarı - 10.000m;
                        lblOyuncuParaMiktarı.Text = OyuncuParaMiktarı.ToString() + "  TL";
                        PcboxZar1.Visible = false;
                        PcboxZar2.Visible = false;
                        PcboxDonenZar.Visible = true;
                        tmrRakipZarAt.Enabled = true;
                    }
                }
            }
            else if (deger == 20)
            {
                this.pcboxGelenKart.Image = global::Monopoly.Properties.Resources.k21;
                YerKontrol(deger);
            }
            else if (deger == 21)
            {
                this.pcboxGelenKart.Image = global::Monopoly.Properties.Resources.k22;
                YerKontrol(deger);
            }
            else if (deger == 22)
            {
                this.pcboxGelenKart.Image = global::Monopoly.Properties.Resources.k23;
                YerKontrol(deger);
            }
            else if (deger == 25)
            {
                this.pcboxGelenKart.Image = global::Monopoly.Properties.Resources.k26;
                YerKontrol(deger);
            }
            else if (deger == 26)
            {
                this.pcboxGelenKart.Image = global::Monopoly.Properties.Resources.k27;
                YerKontrol(deger);
            }
            else if (deger == 27)
            {
                Random geri = new Random();
                int gerigel = geri.Next(1, 5);
                i = i - gerigel;MessageBox.Show(gerigel.ToString()+" kare geri gel.");
                int[] dizi = Koordinatlar(i);
                Oyuncu.Left = dizi[0];
                Oyuncu.Top = dizi[1];
                if (gerigel== 1)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart27.PointToClient(pos);
                    Oyuncu.Parent = Kart27;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;
                    this.pcboxGelenKart.Image = global::Monopoly.Properties.Resources.k27;
                    YerKontrol(i);
                }
                else if (gerigel == 2)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart26.PointToClient(pos);
                    Oyuncu.Parent = Kart26;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;
                    this.pcboxGelenKart.Image = global::Monopoly.Properties.Resources.k26;
                    YerKontrol(i);

                }
                else if (gerigel == 3)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart25.PointToClient(pos);
                    Oyuncu.Parent = Kart25;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;
                    lblAcıklama.Visible = true;
                    Random sanskartı = new Random();
                    int KartNo = sanskartı.Next(0, 10);
                    pcboxGelenKart.Visible = false;
                    pcboxArkaPlan.Visible = true;

                    pnlKontrol.Visible = true;
                    this.pcboxArkaPlan.Image = global::Monopoly.Properties.Resources.şasnkartlarıarkaplan;
                    lblAcıklama.Text = SansKartları[KartNo][0];
                    if (KartNo == 0 || KartNo == 2 || KartNo == 4 || KartNo == 6 || KartNo == 8)
                    {
                        SoundPlayer muzikcal = new SoundPlayer();
                        muzikcal.Stream = Properties.Resources.sanskartıbasarısız;
                        muzikcal.Play();
                        OyuncuParaMiktarı = OyuncuParaMiktarı - SansKartlarıParaMiktarı[KartNo][0];
                        lblOyuncuParaMiktarı.Text = OyuncuParaMiktarı.ToString() + "  TL";
                    }
                    else if (KartNo == 1 || KartNo == 3 || KartNo == 5 || KartNo == 7 || KartNo == 9)
                    {
                        SoundPlayer muzikcal = new SoundPlayer();
                        muzikcal.Stream = Properties.Resources.sanskartıbasarılı;
                        muzikcal.Play();
                        OyuncuParaMiktarı = OyuncuParaMiktarı + SansKartlarıParaMiktarı[KartNo][0];
                        lblOyuncuParaMiktarı.Text = OyuncuParaMiktarı.ToString() + "  TL";
                    }
                }
                else if (gerigel == 4)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart24.PointToClient(pos);
                    Oyuncu.Parent = Kart24;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;
                    MadenArastırma(i);

                }
                else if (gerigel == 5)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart23.PointToClient(pos);
                    Oyuncu.Parent = Kart23;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;
                    this.pcboxGelenKart.Image = global::Monopoly.Properties.Resources.k23;
                    YerKontrol(i);
                }

                
                
            }
            else if (deger == 29)
            {
                Bitmap drawBitmap;// Bitmap türünde bir değişken tanımladık.              
                drawBitmap = (Bitmap)Kart30.Image;// Bu değişkene pictureBox1in resmini atıyoruz.
                drawBitmap.RotateFlip(RotateFlipType.Rotate270FlipXY); // Ve en önemli yer olan resmimizi çevirme kısmı. Biz 90 derece çevirdik ama farklı seçeneklerde var. (270,180 derece vs...)
                pcboxGelenKart.Image = drawBitmap;// Bir üst satırda değişkenimize gönderdiğimiz resmi çevirmiştik, yani pictureBoxımızdaki resmi değil. Bu yüzden alttaki satırı yapmamız gerekiyor.
                this.Kart30.Image = global::Monopoly.Properties.Resources.k30;
                YerKontrol(deger);
            }
            else if (deger == 31)
            {
                Bitmap drawBitmap;// Bitmap türünde bir değişken tanımladık.              
                drawBitmap = (Bitmap)Kart32.Image;// Bu değişkene pictureBox1in resmini atıyoruz.
                drawBitmap.RotateFlip(RotateFlipType.Rotate270FlipXY); // Ve en önemli yer olan resmimizi çevirme kısmı. Biz 90 derece çevirdik ama farklı seçeneklerde var. (270,180 derece vs...)
                pcboxGelenKart.Image = drawBitmap;// Bir üst satırda değişkenimize gönderdiğimiz resmi çevirmiştik, yani pictureBoxımızdaki resmi değil. Bu yüzden alttaki satırı yapmamız gerekiyor.
                this.Kart32.Image = global::Monopoly.Properties.Resources.k32;
                YerKontrol(deger);
            }
            else if (deger == 32)
            {
                Bitmap drawBitmap;// Bitmap türünde bir değişken tanımladık.              
                drawBitmap = (Bitmap)Kart33.Image;// Bu değişkene pictureBox1in resmini atıyoruz.
                drawBitmap.RotateFlip(RotateFlipType.Rotate270FlipXY); // Ve en önemli yer olan resmimizi çevirme kısmı. Biz 90 derece çevirdik ama farklı seçeneklerde var. (270,180 derece vs...)
                pcboxGelenKart.Image = drawBitmap;// Bir üst satırda değişkenimize gönderdiğimiz resmi çevirmiştik, yani pictureBoxımızdaki resmi değil. Bu yüzden alttaki satırı yapmamız gerekiyor.
                this.Kart33.Image = global::Monopoly.Properties.Resources.k33;
                YerKontrol(deger);
            }
            else if (deger == 33)
            {
                Bitmap drawBitmap;// Bitmap türünde bir değişken tanımladık.              
                drawBitmap = (Bitmap)Kart34.Image;// Bu değişkene pictureBox1in resmini atıyoruz.
                drawBitmap.RotateFlip(RotateFlipType.Rotate270FlipXY); // Ve en önemli yer olan resmimizi çevirme kısmı. Biz 90 derece çevirdik ama farklı seçeneklerde var. (270,180 derece vs...)
                pcboxGelenKart.Image = drawBitmap;// Bir üst satırda değişkenimize gönderdiğimiz resmi çevirmiştik, yani pictureBoxımızdaki resmi değil. Bu yüzden alttaki satırı yapmamız gerekiyor.
                this.Kart34.Image = global::Monopoly.Properties.Resources.k34;
                YerKontrol(deger);
            }
            else if (deger == 34)
            {
                Bitmap drawBitmap;// Bitmap türünde bir değişken tanımladık.              
                drawBitmap = (Bitmap)Kart35.Image;// Bu değişkene pictureBox1in resmini atıyoruz.
                drawBitmap.RotateFlip(RotateFlipType.Rotate270FlipXY); // Ve en önemli yer olan resmimizi çevirme kısmı. Biz 90 derece çevirdik ama farklı seçeneklerde var. (270,180 derece vs...)
                pcboxGelenKart.Image = drawBitmap;// Bir üst satırda değişkenimize gönderdiğimiz resmi çevirmiştik, yani pictureBoxımızdaki resmi değil. Bu yüzden alttaki satırı yapmamız gerekiyor.
                this.Kart35.Image = global::Monopoly.Properties.Resources.k35;
                YerKontrol(deger);
            }

        }
        public void RakipKartKontrol(int deger)
        {
            if (deger == 1 && Yerler[i1 + 1][3] == "0" && RakipParaMiktarı>=YerlerParaMiktarı[i1+1][0])
            {
                MessageBox.Show("Rakip Tarafından Satın Alındı");
                Yerler[i1 + 1][3] = "2";
                RakipParaMiktarı=RakipParaMiktarı-YerlerParaMiktarı[i1 + 1][0];
                lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                this.pnlManav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
                BilgisayarSatınAlınanlar("Manav");
            }
            else if (deger == 2 && Yerler[i1 + 1][3] == "0" && RakipParaMiktarı >= YerlerParaMiktarı[i1 + 1][0])
            {
                MessageBox.Show("Rakip Tarafından Satın Alındı");
                Yerler[i1 + 1][3] = "2";
                RakipParaMiktarı = RakipParaMiktarı - YerlerParaMiktarı[i1 + 1][0];
                lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                this.pnlSirk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
                BilgisayarSatınAlınanlar("Sirk");
            }
            else if (deger == 3 || deger == 10 || deger == 19 || deger == 35)
            {
                Random kamufonukartı = new Random();
                int KartNo = kamufonukartı.Next(0, 8);
                if (KartNo == 0) {
                    RakipParaMiktarı = RakipParaMiktarı - 5.000m;
                    lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL"; 
                }else if(KartNo==1){
                    RakipParaMiktarı = RakipParaMiktarı + 5.000m;
                    lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL"; 
                }
                else if (KartNo == 2)
                {
                    RakipParaMiktarı = RakipParaMiktarı + 10.000m;
                    lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL"; 
                }
                else if (KartNo == 3)
                {
                    RakipParaMiktarı = RakipParaMiktarı + 15.000m;
                    lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL"; 
                }
                else if (KartNo == 4)
                {
                    RakipParaMiktarı = RakipParaMiktarı - 15.000m;
                    lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL"; 
                }
                else if (KartNo == 5)
                {
                    RakipParaMiktarı = RakipParaMiktarı + 25.000m;
                    lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL"; 
                }
                else if (KartNo == 6)
                {
                    RakipParaMiktarı = RakipParaMiktarı + 50.000m;
                    lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                }
                else if (KartNo == 7)
                {
                    RakipParaMiktarı = RakipParaMiktarı -20.000m;
                    lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                }

            }
            else if (deger == 4 && Yerler[i1 + 1][3] == "0" && RakipParaMiktarı >= YerlerParaMiktarı[i1 + 1][0])
            {
                MessageBox.Show("Rakip Tarafından Satın Alındı");
                Yerler[i1 + 1][3] = "2";
                RakipParaMiktarı = RakipParaMiktarı - YerlerParaMiktarı[i1 + 1][0];
                lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                this.pnlStadyum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
                BilgisayarSatınAlınanlar("Stadyum");
            }
            else if (deger == 5 && Yerler[i1 + 1][3] == "0" && RakipParaMiktarı >= YerlerParaMiktarı[i1 + 1][0])
            {
                MessageBox.Show("Rakip Tarafından Satın Alındı");
                Yerler[i1 + 1][3] = "2";
                RakipParaMiktarı = RakipParaMiktarı - YerlerParaMiktarı[i1 + 1][0];
                lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                this.pnlTaksiDuragı.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
                BilgisayarSatınAlınanlar("Taksi Durağı");
            }
            else if (deger == 6 || deger == 28)
            {
                RakipParaMiktarı = RakipParaMiktarı - 2.000m;
                lblRakipParaMiktarı.Text =RakipParaMiktarı.ToString() + "  TL";
            }
            else if (deger == 7 || deger == 23)
            {
                if (RakipParaMiktarı >= 50.000m)
                {
                    MessageBox.Show("Rakip maden araştırması başlattı.");
                    Random arastır = new Random();
                    int aramasayı = arastır.Next(0, 2);
                    if (aramasayı == 0)
                    {
                        MessageBox.Show("Rakip maden araştırması başarısız.");
                        RakipParaMiktarı = RakipParaMiktarı - 25.000m;
                        lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                    }
                    else if (aramasayı == 1)
                    {
                        MessageBox.Show("Rakip maden araştırması başarılı.");
                        RakipParaMiktarı = RakipParaMiktarı + 100.000m;
                        lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                    }
                }
                else {
                    MessageBox.Show("Rakip maden araştırması yapmadı.");
                }
            }
            else if (deger == 8 && Yerler[i1 + 1][3] == "0" && RakipParaMiktarı >= YerlerParaMiktarı[i1 + 1][0])
            {
                MessageBox.Show("Rakip Tarafından Satın Alındı");
                Yerler[i1 + 1][3] = "2";
                RakipParaMiktarı = RakipParaMiktarı - YerlerParaMiktarı[i1 + 1][0];
                lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                this.pnlOtel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
                BilgisayarSatınAlınanlar("Otel");
            }
            else if (deger == 9)
            {
                MessageBox.Show("Rakip 1 tur bekleme cezası aldı.");
               
            }
            else if (deger == 11 && Yerler[i1 + 1][3] == "0" && RakipParaMiktarı >= YerlerParaMiktarı[i1 + 1][0])
            {
                MessageBox.Show("Rakip Tarafından Satın Alındı");
                Yerler[i1 + 1][3] = "2";
                RakipParaMiktarı = RakipParaMiktarı - YerlerParaMiktarı[i1 + 1][0];
                lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                this.pnlMarket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
                BilgisayarSatınAlınanlar("Market");
            }
            else if (deger == 12 && Yerler[i1 + 1][3] == "0" && RakipParaMiktarı >= YerlerParaMiktarı[i1 + 1][0])
            {
                MessageBox.Show("Rakip Tarafından Satın Alındı");
                Yerler[i1 + 1][3] = "2";
                RakipParaMiktarı = RakipParaMiktarı - YerlerParaMiktarı[i1 + 1][0];
                lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                this.pnlMuze.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
                BilgisayarSatınAlınanlar("Müze");
            }
            else if (deger == 13 && Yerler[i1 + 1][3] == "0" && RakipParaMiktarı >= YerlerParaMiktarı[i1 + 1][0])
            {
                MessageBox.Show("Rakip Tarafından Satın Alındı");
                Yerler[i1 + 1][3] = "2";
                RakipParaMiktarı = RakipParaMiktarı - YerlerParaMiktarı[i1 + 1][0];
                lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                this.pnlCiftlik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
                BilgisayarSatınAlınanlar("Çiftlik");
            }
            else if (deger == 14 && Yerler[i1 + 1][3] == "0" && RakipParaMiktarı >= YerlerParaMiktarı[i1 + 1][0])
            {
                MessageBox.Show("Rakip Tarafından Satın Alındı");
                Yerler[i1 + 1][3] = "2";
                RakipParaMiktarı = RakipParaMiktarı - YerlerParaMiktarı[i1 + 1][0];
                lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                this.pnlHastahane.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
                BilgisayarSatınAlınanlar("Hastahane");
            }

            else if (deger == 15 || deger==24 || deger == 30)
            {
                Random sanskartı = new Random();
                int KartNo = sanskartı.Next(0, 8);
                if (KartNo == 0)
                {
                    RakipParaMiktarı = RakipParaMiktarı - 5.000m;
                    lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                }
                else if (KartNo == 1)
                {
                    RakipParaMiktarı = RakipParaMiktarı + 5.000m;
                    lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                }
                else if (KartNo == 2)
                {
                    RakipParaMiktarı = RakipParaMiktarı + 10.000m;
                    lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                }
                else if (KartNo == 3)
                {
                    RakipParaMiktarı = RakipParaMiktarı + 15.000m;
                    lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                }
                else if (KartNo == 4)
                {
                    RakipParaMiktarı = RakipParaMiktarı - 150.000m;
                    lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                }
                else if (KartNo == 5)
                {
                    RakipParaMiktarı = RakipParaMiktarı + 25.000m;
                    lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                }
                else if (KartNo == 6)
                {
                    RakipParaMiktarı = RakipParaMiktarı + 75.000m;
                    lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                }
                else if (KartNo == 7)
                {
                    RakipParaMiktarı = RakipParaMiktarı - 80.000m;
                    lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                }
            }
            else if (deger == 16 && Yerler[i1 + 1][3] == "0" && RakipParaMiktarı >= YerlerParaMiktarı[i1 + 1][0])
            {
                MessageBox.Show("Rakip Tarafından Satın Alındı");
                Yerler[i1 + 1][3] = "2";
                RakipParaMiktarı = RakipParaMiktarı - YerlerParaMiktarı[i1 + 1][0];
                lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                this.pnlPansiyon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
                BilgisayarSatınAlınanlar("Pansiyon");
            }
            else if (deger == 17 && Yerler[i1 + 1][3] == "0" && RakipParaMiktarı >= YerlerParaMiktarı[i1 + 1][0])
            {
                MessageBox.Show("Rakip Tarafından Satın Alındı");
                Yerler[i1 + 1][3] = "2";
                RakipParaMiktarı = RakipParaMiktarı - YerlerParaMiktarı[i1 + 1][0];
                lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                this.pnlTamirci.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
                BilgisayarSatınAlınanlar("Tamirci");
            }
            else if (deger == 18)
            {
                RakipParaMiktarı = RakipParaMiktarı + 10.000m;
                lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString()+"  TL";
            }
            else if (deger == 20 && Yerler[i1 + 1][3] == "0" && RakipParaMiktarı >= YerlerParaMiktarı[i1 + 1][0])
            {
                MessageBox.Show("Rakip Tarafından Satın Alındı");
                Yerler[i1 + 1][3] = "2";
                RakipParaMiktarı = RakipParaMiktarı - YerlerParaMiktarı[i1 + 1][0];
                lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                this.pnlRestaurant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
                BilgisayarSatınAlınanlar("Restaurant");
            }
            else if (deger == 21 && Yerler[i1 + 1][3] == "0" && RakipParaMiktarı >= YerlerParaMiktarı[i1 + 1][0])
            {
                MessageBox.Show("Rakip Tarafından Satın Alındı");
                Yerler[i1 + 1][3] = "2";
                RakipParaMiktarı = RakipParaMiktarı - YerlerParaMiktarı[i1 + 1][0];
                lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                this.pnlGaleri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
                BilgisayarSatınAlınanlar("Galeri");
            }
            else if (deger == 22 && Yerler[i1 + 1][3] == "0" && RakipParaMiktarı >= YerlerParaMiktarı[i1 + 1][0])
            {
                MessageBox.Show("Rakip Tarafından Satın Alındı");
                Yerler[i1 + 1][3] = "2";
                RakipParaMiktarı = RakipParaMiktarı - YerlerParaMiktarı[i1 + 1][0];
                lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                this.pnlSinema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
                BilgisayarSatınAlınanlar("Sinema");
            }
            else if (deger == 25 && Yerler[i1 + 1][3] == "0" && RakipParaMiktarı >= YerlerParaMiktarı[i1 + 1][0])
            {
                MessageBox.Show("Rakip Tarafından Satın Alındı");
                Yerler[i1 + 1][3] = "2";
                RakipParaMiktarı = RakipParaMiktarı - YerlerParaMiktarı[i1 + 1][0];
                lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                this.pnlİsMerkezi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
                BilgisayarSatınAlınanlar("İş Merkezi");
            }
            else if (deger == 26 && Yerler[i1 + 1][3] == "0" && RakipParaMiktarı >= YerlerParaMiktarı[i1 + 1][0])
            {
                MessageBox.Show("Rakip Tarafından Satın Alındı");
                Yerler[i1 + 1][3] = "2";
                RakipParaMiktarı = RakipParaMiktarı - YerlerParaMiktarı[i1 + 1][0];
                lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                this.pnlTerzi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
                BilgisayarSatınAlınanlar("Terzi");
            }
            else if (deger == 27)
            {
                Random geri = new Random();
                int gerigel = geri.Next(1, 5);
                i1 = i1 - gerigel; MessageBox.Show("Rakip "+gerigel.ToString()+" kare geri gelicek.");
                int[] dizi = Koordinatlar(i1);
                Rakip.Left = dizi[0];
                Rakip.Top = dizi[1];
                if (gerigel == 1)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart27.PointToClient(pos);
                    Rakip.Parent = Kart27;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;
                    RakipKartKontrol(i1);
                }
                else if (gerigel == 2)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart26.PointToClient(pos);
                    Rakip.Parent = Kart26;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;
                    RakipKartKontrol(i1);
                }
                else if (gerigel == 3)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart25.PointToClient(pos);
                    Rakip.Parent = Kart25;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;
                   
                }
                else if (gerigel == 4)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart24.PointToClient(pos);
                    Rakip.Parent = Kart24;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;
                    if (RakipParaMiktarı >= 50.000m)
                    {
                        MessageBox.Show("Rakip maden araştırması başlattı.");
                        Random arastır = new Random();
                        int aramasayı = arastır.Next(0, 2);
                        if (aramasayı == 0)
                        {
                            MessageBox.Show("Rakip maden araştırması başarısız.");
                            RakipParaMiktarı = RakipParaMiktarı - 25.000m;
                            lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                        }
                        else if (aramasayı == 1)
                        {
                            MessageBox.Show("Rakip maden araştırması başarılı.");
                            RakipParaMiktarı = RakipParaMiktarı + 100.000m;
                            lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Rakip maden araştırması yapmadı.");
                    }
                }
                else if (gerigel == 5)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart23.PointToClient(pos);
                    Rakip.Parent = Kart23;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;
                    RakipKartKontrol(i1);
                }
            }


            else if (deger == 29 && Yerler[i1 + 1][3] == "0" && RakipParaMiktarı >= YerlerParaMiktarı[i1 + 1][0])
            {
                MessageBox.Show("Rakip Tarafından Satın Alındı");
                Yerler[i1 + 1][3] = "2";
                RakipParaMiktarı = RakipParaMiktarı - YerlerParaMiktarı[i1 + 1][0];
                lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                this.pnlBalikci.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
                BilgisayarSatınAlınanlar("Balıkçı");
            }
            else if (deger == 31 && Yerler[i1 + 1][3] == "0" && RakipParaMiktarı >= YerlerParaMiktarı[i1 + 1][0])
            {
                MessageBox.Show("Rakip Tarafından Satın Alındı");
                Yerler[i1 + 1][3] = "2";
                RakipParaMiktarı = RakipParaMiktarı - YerlerParaMiktarı[i1 + 1][0];
                lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                this.pnlAvm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
                BilgisayarSatınAlınanlar("A.V.M");
            }
            else if (deger == 32 && Yerler[i1 + 1][3] == "0" && RakipParaMiktarı >= YerlerParaMiktarı[i1 + 1][0])
            {
                MessageBox.Show("Rakip Tarafından Satın Alındı");
                Yerler[i1 + 1][3] = "2";
                RakipParaMiktarı = RakipParaMiktarı - YerlerParaMiktarı[i1 + 1][0];
                lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                this.pnlFirin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
                BilgisayarSatınAlınanlar("Fırın");
            }
            else if (deger == 33 && Yerler[i1 + 1][3] == "0" && RakipParaMiktarı >= YerlerParaMiktarı[i1 + 1][0])
            {
                MessageBox.Show("Rakip Tarafından Satın Alındı");
                Yerler[i1 + 1][3] = "2";
                RakipParaMiktarı = RakipParaMiktarı - YerlerParaMiktarı[i1 + 1][0];
                lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                this.pnlPizzaci.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
                BilgisayarSatınAlınanlar("Pizzacı");
            }
            else if (deger == 34 && Yerler[i1 + 1][3] == "0" && RakipParaMiktarı >= YerlerParaMiktarı[i1 + 1][0])
            {
                MessageBox.Show("Rakip Tarafından Satın Alındı");
                Yerler[i1 + 1][3] = "2";
                RakipParaMiktarı = RakipParaMiktarı - YerlerParaMiktarı[i1 + 1][0];
                lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                this.pnlDondurmaci.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
                BilgisayarSatınAlınanlar("Dondurmacı");
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
            else if (Yerler[i + 1][3] == "2")
            {
                pnlKontrol.Visible = false;

                if (MessageBox.Show("Yer rakip tarafından satın alınmış.Lütfen kira bedeli ödeyiniz.", "", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    SoundPlayer muzikcal = new SoundPlayer();
                    muzikcal.Stream = Properties.Resources.para;
                    muzikcal.Play();
                    OyuncuParaMiktarı = OyuncuParaMiktarı - YerlerParaMiktarı[i + 1][1];
                    lblOyuncuParaMiktarı.Text = OyuncuParaMiktarı.ToString() + "  TL";
                    RakipParaMiktarı = RakipParaMiktarı + YerlerParaMiktarı[i + 1][1];
                    lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                    btnSatınAl.Visible = false;
                    PcboxZar1.Visible = false;
                    PcboxZar2.Visible = false;
                    PcboxDonenZar.Visible = true;
                    tmrRakipZarAt.Enabled = true;
                }                               
            }

        }
        public void MadenArastırma(int i)
        {
            pcboxGelenKart.Visible = false;
            lblYerAdı.Visible = false;
            lblAlısFiyatı.Visible = false;
            lblKiraGeliri.Visible = false;
            lblAcıklama.Visible = false;
            pnlKontrol.Visible = true;
            pcboxArkaPlan.Visible = true;
            this.pcboxArkaPlan.Image = global::Monopoly.Properties.Resources.MadenArastırmaArkaplan;
            btnArastır.Visible = true;
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
            zar1 = rnd1.Next(1,7);
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
            zar2 = rnd1.Next(1,7);
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
                if (i == 0)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart1.PointToClient(pos);
                    Oyuncu.Parent = Kart1;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;
                }
                else if (i == 1)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart2.PointToClient(pos);
                    Oyuncu.Parent = Kart2;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;
                }
                else if (i == 2)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart3.PointToClient(pos);
                    Oyuncu.Parent = Kart3;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;

                }
                else if (i == 3)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart4.PointToClient(pos);
                    Oyuncu.Parent = Kart4;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;
                }
                else if (i == 4)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart5.PointToClient(pos);
                    Oyuncu.Parent = Kart5;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;

                }
                else if (i == 5)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart6.PointToClient(pos);
                    Oyuncu.Parent = Kart6;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;
                }
                else if (i == 6)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart7.PointToClient(pos);
                    Oyuncu.Parent = Kart7;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;

                }
                else if (i == 7)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart8.PointToClient(pos);
                    Oyuncu.Parent = Kart8;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;
                }
                else if (i == 8)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart9.PointToClient(pos);
                    Oyuncu.Parent = Kart9;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;

                }
                else if (i == 9)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart10.PointToClient(pos);
                    Oyuncu.Parent = Kart10;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;

                }
                else if (i == 10)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart11.PointToClient(pos);
                    Oyuncu.Parent = Kart11;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;
                }
                else if (i == 11)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart12.PointToClient(pos);
                    Oyuncu.Parent = Kart12;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;

                }
                else if (i == 12)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart13.PointToClient(pos);
                    Oyuncu.Parent = Kart13;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;
                }
                else if (i == 13)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart14.PointToClient(pos);
                    Oyuncu.Parent = Kart14;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;

                }
                else if (i == 14)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart15.PointToClient(pos);
                    Oyuncu.Parent = Kart15;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;
                }
                else if (i == 15)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart16.PointToClient(pos);
                    Oyuncu.Parent = Kart16;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;

                }
                else if (i == 16)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart17.PointToClient(pos);
                    Oyuncu.Parent = Kart17;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;
                }
                else if (i == 17)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart18.PointToClient(pos);
                    Oyuncu.Parent = Kart18;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;

                }
                else if (i == 18)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart19.PointToClient(pos);
                    Oyuncu.Parent = Kart19;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;

                }
                else if (i == 19)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart20.PointToClient(pos);
                    Oyuncu.Parent = Kart20;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;

                }
                else if (i == 20)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart21.PointToClient(pos);
                    Oyuncu.Parent = Kart21;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;

                }
                else if (i == 21)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart22.PointToClient(pos);
                    Oyuncu.Parent = Kart22;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;

                }
                else if (i == 22)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart23.PointToClient(pos);
                    Oyuncu.Parent = Kart23;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;

                }
                else if (i == 23)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart24.PointToClient(pos);
                    Oyuncu.Parent = Kart24;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;

                }
                else if (i == 24)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart25.PointToClient(pos);
                    Oyuncu.Parent = Kart25;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;

                }
                else if (i == 25)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart26.PointToClient(pos);
                    Oyuncu.Parent = Kart26;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;

                }
                else if (i == 26)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart27.PointToClient(pos);
                    Oyuncu.Parent = Kart27;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;

                }
                else if (i == 27)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart28.PointToClient(pos);
                    Oyuncu.Parent = Kart28;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;

                }
                else if (i == 28)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart29.PointToClient(pos);
                    Oyuncu.Parent = Kart29;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;

                }
                else if (i == 29)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart30.PointToClient(pos);
                    Oyuncu.Parent = Kart30;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;

                }
                else if (i == 30)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart31.PointToClient(pos);
                    Oyuncu.Parent = Kart31;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;

                }
                else if (i == 31)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart32.PointToClient(pos);
                    Oyuncu.Parent = Kart32;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;

                }
                else if (i == 32)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart33.PointToClient(pos);
                    Oyuncu.Parent = Kart33;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;

                }
                else if (i == 33)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart34.PointToClient(pos);
                    Oyuncu.Parent = Kart34;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;

                }
                else if (i == 34)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart35.PointToClient(pos);
                    Oyuncu.Parent = Kart35;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;

                }
                else if (i == 35)
                {
                    Point pos = this.PointToScreen(Oyuncu.Location);
                    pos = Kart36.PointToClient(pos);
                    Oyuncu.Parent = Kart36;
                    Oyuncu.Location = pos;
                    Oyuncu.BackColor = Color.Transparent;

                }
            }
            else if (i >= 36)
            {
                
                i = 0;
                OyuncuParaMiktarı = OyuncuParaMiktarı + 2.000m;
                lblOyuncuParaMiktarı.Text = OyuncuParaMiktarı.ToString() + "  TL";
                int[] dizi = Koordinatlar(i);
                Oyuncu.Left = dizi[0];
                Oyuncu.Top = dizi[1];
                Point pos = this.PointToScreen(Oyuncu.Location);
                pos = Kart1.PointToClient(pos);
                Oyuncu.Parent = Kart1;
                Oyuncu.Location = pos;
                Oyuncu.BackColor = Color.Transparent;
                if(OyuncuParaMiktarı<=0){
                    tmrOyuncuHareket.Enabled = false;
                    tmrRakipHareket.Enabled = false;
                 
                    MessageBox.Show("oyunu biti.Kaybettiniz");
                    this.Close();
                }
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
            zar1 = rnd1.Next(1,7);
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
                if (i1 == 0)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart1.PointToClient(pos);
                    Rakip.Parent = Kart1;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;
                }
                else if (i1 == 1)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart2.PointToClient(pos);
                    Rakip.Parent = Kart2;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;
                }
                else if (i1 == 2)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart3.PointToClient(pos);
                    Rakip.Parent = Kart3;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;

                }
                else if (i1 == 3)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart4.PointToClient(pos);
                    Rakip.Parent = Kart4;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;
                }
                else if (i1 == 4)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart5.PointToClient(pos);
                    Rakip.Parent = Kart5;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;

                }
                else if (i1 == 5)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart6.PointToClient(pos);
                    Rakip.Parent = Kart6;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;
                }
                else if (i1 == 6)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart7.PointToClient(pos);
                    Rakip.Parent = Kart7;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;

                }
                else if (i1 == 7)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart8.PointToClient(pos);
                    Rakip.Parent = Kart8;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;
                }
                else if (i1 == 8)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart9.PointToClient(pos);
                    Rakip.Parent = Kart9;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;

                }
                else if (i1 == 9)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart10.PointToClient(pos);
                    Rakip.Parent = Kart10;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;

                }
                else if (i1 == 10)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart11.PointToClient(pos);
                    Rakip.Parent = Kart11;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;
                }
                else if (i1 == 11)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart12.PointToClient(pos);
                    Rakip.Parent = Kart12;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;

                }
                else if (i1 == 12)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart13.PointToClient(pos);
                    Rakip.Parent = Kart13;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;
                }
                else if (i1 == 13)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart14.PointToClient(pos);
                    Rakip.Parent = Kart14;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;

                }
                else if (i1 == 14)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart15.PointToClient(pos);
                    Rakip.Parent = Kart15;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;
                }
                else if (i1 == 15)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart16.PointToClient(pos);
                    Rakip.Parent = Kart16;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;

                }
                else if (i1 == 16)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart17.PointToClient(pos);
                    Rakip.Parent = Kart17;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;
                }
                else if (i1 == 17)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart18.PointToClient(pos);
                    Rakip.Parent = Kart18;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;

                }
                else if (i1 == 18)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart19.PointToClient(pos);
                    Rakip.Parent = Kart19;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;

                }
                else if (i1 == 19)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart20.PointToClient(pos);
                    Rakip.Parent = Kart20;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;

                }
                else if (i1 == 20)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart21.PointToClient(pos);
                    Rakip.Parent = Kart21;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;

                }
                else if (i1 == 21)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart22.PointToClient(pos);
                    Rakip.Parent = Kart22;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;
                }
                else if (i1 == 22)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart23.PointToClient(pos);
                    Rakip.Parent = Kart23;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;
                }
                else if (i1 == 23)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart24.PointToClient(pos);
                    Rakip.Parent = Kart24;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;
                }
                else if (i1 == 24)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart25.PointToClient(pos);
                    Rakip.Parent = Kart25;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;
                }
                else if (i1 == 25)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart26.PointToClient(pos);
                    Rakip.Parent = Kart26;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;
                }
                else if (i1 == 26)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart27.PointToClient(pos);
                    Rakip.Parent = Kart27;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;
                }
                else if (i1 == 27)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart28.PointToClient(pos);
                    Rakip.Parent = Kart28;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;
                }
                else if (i1 == 28)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart29.PointToClient(pos);
                    Rakip.Parent = Kart29;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;
                }
                else if (i1 == 29)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart30.PointToClient(pos);
                    Rakip.Parent = Kart30;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;
                }
                else if (i1 == 30)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart31.PointToClient(pos);
                    Rakip.Parent = Kart31;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;
                }
                else if (i1 == 31)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart32.PointToClient(pos);
                    Rakip.Parent = Kart32;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;
                }
                else if (i1 == 32)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart33.PointToClient(pos);
                    Rakip.Parent = Kart33;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;
                }
                else if (i1 == 33)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart34.PointToClient(pos);
                    Rakip.Parent = Kart34;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;
                }
                else if (i1 == 34)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart35.PointToClient(pos);
                    Rakip.Parent = Kart35;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;
                }
                else if (i1 == 35)
                {
                    Point pos = this.PointToScreen(Rakip.Location);
                    pos = Kart36.PointToClient(pos);
                    Rakip.Parent = Kart36;
                    Rakip.Location = pos;
                    Rakip.BackColor = Color.Transparent;
                }

            }
            else if (i1 >= 36)
            {
                i1 = 0;
                RakipParaMiktarı = RakipParaMiktarı + 2.000m;
                lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "  TL";
                int[] dizi = Koordinatlar(i1);
                Rakip.Left = dizi[0];
                Rakip.Top = dizi[1];
                Point posRakip = this.PointToScreen(Rakip.Location);
                posRakip = Kart1.PointToClient(posRakip);
                Rakip.Parent = Kart1;
                Rakip.Location = posRakip;
                Rakip.BackColor = Color.Transparent;
                if (RakipParaMiktarı <= 0)
                {
                    tmrOyuncuHareket.Enabled = false;
                    tmrRakipHareket.Enabled = false;

                    MessageBox.Show("oyunu biti.Kazandınız.");
                    OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=veritabani.accdb");
                    OleDbCommand cmd = new OleDbCommand();
                    OleDbDataAdapter adp = new OleDbDataAdapter();
                    DataSet ds = new DataSet();
                    DataTable tablo = new DataTable();
                    baglanti.Open(); //ilk olarak bağlantıyı yani veri tabanımızı açıyoruz.
                    cmd.Connection = baglanti; //komutumuzun bağlantısını öğreniyoruz.
                    cmd.CommandText = "INSERT INTO Puan(OyuncuAdi,OyuncuPuan) VALUES ('" + OyuncuAdı + "','" + Convert.ToInt32(OyuncuParaMiktarı) + "')"; //sql kodumuzu yazıyoruz.
                    cmd.ExecuteNonQuery(); //yazılan sql kodunu gerçekleştiriyoruz.
                    cmd.Dispose(); //Burayı yazmak zorunda değilsiniz.Yazmazsanızda çalışır.Komutu kullanım dışı bırakıyor.
                    baglanti.Close(); //Bağlantıyı kapatıyoruz.
                    this.Close();
                }
            }
            RakipHak = RakipHak - 1;
            if (RakipHak == 0)
            {
                tmrRakipHareket.Enabled = false;
                RakipKartKontrol(i1);
                PcboxZar1.Visible = false;
                PcboxZar2.Visible = false;
                btnZarAt.Visible = true;
            }
        }
        
        private void btnArastır_Click(object sender, EventArgs e)
                {
                    if (OyuncuParaMiktarı < 25.000m)
                    {
                        MessageBox.Show("Maden araştırması için yeterli paranız yok.");
                    }
                    else
                    {
                        SoundPlayer muzikcal = new SoundPlayer();
                        muzikcal.Stream = Properties.Resources.maden;
                        muzikcal.Play();
                        btnArastır.Visible = false;
                        pictureBox42.Visible = true;
                        lblArastırma.Visible = true;
                        OyuncuParaMiktarı = OyuncuParaMiktarı - 25.000m;
                        lblOyuncuParaMiktarı.Text = OyuncuParaMiktarı.ToString() + "  TL";
                        tmrArastırma.Enabled = true;
                    }
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
                SoundPlayer muzikcal = new SoundPlayer();
                muzikcal.Stream = Properties.Resources.madenbasarısız;
                muzikcal.Play();
                if (MessageBox.Show("Maden Araştırması başarısız.", "", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    muzikcal.Stop();
                }
            }
            else if (sayi == 1)
            {
                tmrArastırma.Enabled = false;
                pictureBox42.Visible = false;
                lblArastırma.Visible = false;
                SoundPlayer muzikcal = new SoundPlayer();
                muzikcal.Stream = Properties.Resources.madenbasarılı;
                muzikcal.Play();
                if (MessageBox.Show("Maden Araştırması başarılı 100.000 TL kazandınız.", "", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    muzikcal.Stop();
                }
                OyuncuParaMiktarı = OyuncuParaMiktarı + 100.000m;
                lblOyuncuParaMiktarı.Text = OyuncuParaMiktarı.ToString() + "  TL";
            }
        }

        private void btnSatınAl_Click(object sender, EventArgs e)
            {
                if (OyuncuParaMiktarı >= YerlerParaMiktarı[i + 1][0])
                {
                    SoundPlayer muzikcal = new SoundPlayer();
                    muzikcal.Stream = Properties.Resources.para;
                    muzikcal.Play();
                    MessageBox.Show("Satın Alındı");
                    btnSatınAl.Visible = false;
                    Yerler[i + 1][3] = "1";
                    OyuncuParaMiktarı = OyuncuParaMiktarı - YerlerParaMiktarı[i + 1][0];
                    lblOyuncuParaMiktarı.Text = OyuncuParaMiktarı.ToString() + "  TL";
                    if (i == 1)
                    {
                      this.pnlManav.BackColor=System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
                      SatınAlınanlar("Manav");
                    }
                    else if (i == 2)
                    {
                        this.pnlSirk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
                        SatınAlınanlar("Sirk");
                    }
                    else if (i == 4)
                    {
                        this.pnlStadyum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
                        SatınAlınanlar("Stadyum");
                    }
                    else if (i == 5)
                    {
                        this.pnlTaksiDuragı.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
                        SatınAlınanlar("Taksi Durağı");
                    }
                    else if (i == 8)
                    {
                        this.pnlOtel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
                        SatınAlınanlar("Otel");
                    }
                    else if (i == 11)
                    {
                        this.pnlMarket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
                        SatınAlınanlar("Market");
                    }
                    else if (i == 12)
                    {
                        this.pnlMuze.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
                        SatınAlınanlar("Müze");
                    }
                    else if (i == 13)
                    {
                        this.pnlCiftlik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
                        SatınAlınanlar("Çiftlik");
                    }
                    else if (i == 14)
                    {
                        this.pnlHastahane.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
                        SatınAlınanlar("Hastahane");
                    }
                    else if (i == 16)
                    {
                        this.pnlPansiyon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
                        SatınAlınanlar("Pansiyon");
                    }
                    else if (i == 17)
                    {
                        this.pnlTamirci.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
                        SatınAlınanlar("Tamirci");
                    }
                    else if (i == 20)
                    {
                        this.pnlRestaurant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
                        SatınAlınanlar("Restaurant");
                    }
                    else if (i == 21)
                    {
                        this.pnlGaleri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
                        SatınAlınanlar("Galeri");
                    }
                    else if (i == 22)
                    {
                        this.pnlSinema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
                        SatınAlınanlar("Sinema");
                    }
                    else if (i == 25)
                    {
                        this.pnlİsMerkezi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
                        SatınAlınanlar("İş Merkezi");
                    }
                    else if (i == 26)
                    {
                        this.pnlTerzi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
                        SatınAlınanlar("Terzi");
                    }
                    else if (i == 29)
                    {
                        this.pnlBalikci.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
                        SatınAlınanlar("Balıkçı");
                    }
                    else if (i == 31)
                    {
                        this.pnlAvm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
                        SatınAlınanlar("A.V.M");
                    }
                    else if (i == 32)
                    {
                        this.pnlFirin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
                        SatınAlınanlar("Fırın");
                    }
                    else if (i == 33)
                    {
                        this.pnlPizzaci.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
                        SatınAlınanlar("Pizzacı");
                    }
                    else if (i == 34)
                    {
                        this.pnlDondurmaci.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
                        SatınAlınanlar("Dondurmacı");
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

        int SimdikiWidth = 1920;
        int SimdikiHeight = 1080;
         private void FrmOyunAlanı_Load(object sender, EventArgs e)
                {
                    Rectangle ClientCozunurluk = new Rectangle();
                    ClientCozunurluk = Screen.GetBounds(ClientCozunurluk);
                    float OranWidth = ((float)ClientCozunurluk.Width / (float)SimdikiWidth);
                    float OranHeight = ((float)ClientCozunurluk.Height / (float)SimdikiHeight);
                    this.Scale(OranWidth, OranHeight); 


                    Point posOyuncu = this.PointToScreen(Oyuncu.Location);
                    posOyuncu = Kart1.PointToClient(posOyuncu);
                    Oyuncu.Parent = Kart1;
                    Oyuncu.Location = posOyuncu;
                    Oyuncu.BackColor = Color.Transparent;

                    Point posRakip = this.PointToScreen(Rakip.Location);
                    posRakip = Kart1.PointToClient(posRakip);
                    Rakip.Parent = Kart1;
                    Rakip.Location = posRakip;
                    Rakip.BackColor = Color.Transparent;

                    lblAd.Text = OyuncuAdı;
                    lblOyuncuParaMiktarı.Text = OyuncuParaMiktarı.ToString() + "  TL";
                    lblRakipParaMiktarı.Text = RakipParaMiktarı.ToString() + "   TL";
                }

        int  sol = 10; //formun sol tarafından atanan değer
        int  alt = 10;
        int sol1=10; 
        int alt1=10;
        public void BilgisayarSatınAlınanlar(string yeradı)
        {
            CheckBox btn = new CheckBox();
            btn.Name = yeradı;
            btn.Text = yeradı;
            btn.AutoSize = true;
            btn.Location = new Point(sol1, alt1);
            btn.Enabled = false;
            btn.Checked = true;
            this.pnlBilgisayarSatınAlınanlar.Controls.Add(btn);
            sol1 += btn.Width + 5;
            //if (sol1 > 370)
            //{
            //    sol1 = 10;
            //    alt1 = this.Height + 10;
            //}
            
        }

         public void SatınAlınanlar(string yeradı) {
             CheckBox btn = new CheckBox();
             btn.Name = yeradı;
             btn.Text = yeradı;
             btn.AutoSize = true;
             btn.Location = new Point(sol, alt);
             btn.Checked = true;
             this.pnlSatınAlınanlar.Controls.Add(btn);
             sol += btn.Width + 5;
             //if(sol>=50){
             //    sol = 10;
             //    alt = this.Height + 100;
             //}
             btn.Click += new EventHandler(dinamikMetod);
         }
         DialogResult sonuc;
         
         protected void dinamikMetod(object sender, EventArgs e)
         {
             CheckBox dinamikButon = (sender as CheckBox);
            sonuc=MessageBox.Show(dinamikButon.Text + " satmak istiyormusunuz","Uyarı", MessageBoxButtons.OKCancel);
            if (sonuc == DialogResult.OK)
            {
                this.pnlSatınAlınanlar.Controls.Remove(dinamikButon);
                //sol = dinamikButon.Left;
                //alt = dinamikButon.Top;
                for (int i = 0; i <= 35; i++) {
                    if (Yerler[i][0]==dinamikButon.Text && Yerler[i][3]=="1") {
                        Yerler[i][3] = "0";
                        decimal eksilt=5.000m;
                        OyuncuParaMiktarı = OyuncuParaMiktarı + (YerlerParaMiktarı[i][0]-eksilt);
                        //MessageBox.Show(Convert.ToDecimal((Convert.ToInt32(YerlerParaMiktarı[i][0]*1000)/100)*20).ToString());
                        lblOyuncuParaMiktarı.Text = OyuncuParaMiktarı.ToString()+"   TL";
                        if (i == 2)
                        {
                            this.pnlManav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
                            break;                            
                        }
                        else if (i == 3)
                        {
                            this.pnlSirk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
                            break;
                        }
                        else if (i == 5)
                        {
                            this.pnlStadyum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
                            break;
                        }
                        else if (i == 6)
                        {
                            this.pnlTaksiDuragı.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
                            break;
                        }
                        else if (i == 9)
                        {
                            this.pnlOtel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
                            break;
                        }
                        else if (i == 12)
                        {
                            this.pnlMarket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
                            break;
                        }
                        else if (i == 13)
                        {
                            this.pnlMuze.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
                            break;
                        }
                        else if (i == 14)
                        {
                            this.pnlCiftlik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
                            break;
                        }
                        else if (i == 15)
                        {
                            this.pnlHastahane.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
                            break;
                        }
                        else if (i == 17)
                        {
                            this.pnlPansiyon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
                            break;
                        }
                        else if (i == 18)
                        {
                            this.pnlTamirci.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
                            break;
                        }
                        else if (i == 21)
                        {
                            this.pnlRestaurant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
                            break;
                        }
                        else if (i == 22)
                        {
                            this.pnlGaleri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
                            break;
                        }
                        else if (i == 23)
                        {
                            this.pnlSinema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
                            break;
                        }
                        else if (i == 26)
                        {
                            this.pnlİsMerkezi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
                            break;
                        }
                        else if (i == 27)
                        {
                            this.pnlTerzi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
                            break;
                        }
                        else if (i == 30)
                        {
                            this.pnlBalikci.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
                            break;
                        }
                        else if (i == 32)
                        {
                            this.pnlAvm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
                            break;
                        }
                        else if (i == 33)
                        {
                            this.pnlFirin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
                            break;
                        }
                        else if (i == 34)
                        {
                            this.pnlPizzaci.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
                            break;
                        }
                        else if (i == 35)
                        {
                            this.pnlDondurmaci.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
                            break;
                        }
                    }               
                }
            }
            else {
                dinamikButon.Checked = true;
            }
         }

         private void FrmOyunAlanı_FormClosing(object sender, FormClosingEventArgs e)
         {
             this.Hide();
             AcilisFormu frm = new AcilisFormu();
             frm.Show();
         }


        

    }
}
