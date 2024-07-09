using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form3 : Form
    {
        public Form1 form1;


        public List<string> statikAnormalGurultu= new List<string>()
        {
            "Cihaz zemini düz bir yere yerleştirilmiş mi?",
            "Ayarlı Ayaklar Ayarlı mı?",
            "Kompresör ayakları gevşek mi?",
            "Kondanser yada Fan motoru sabitlemesi normal mi?",
            "Kılcal ve arka kısımdaki borular bir yere değiyor mu?",
            "Kılcalın üzerinde ve kılcalın eşanjörden ayrıldığı yerde bitüm var mı?",
            "Kompresör çalışma sesi normal mi?",
        };

        public Dictionary<string, string[]> diyagramSonuclar = new Dictionary<string, string[]>()
        {
            { "Cihaz zemini düz bir yere yerleştirilmiş mi?", new string[] { "", "DÜZELT" } },
            { "Ayarlı Ayaklar Ayarlı mı?", new string[] { "", "DÜZELT" } },
            { "Kompresör ayakları gevşek mi?", new string[] { "DÜZELT", "" } },
            { "Kondanser yada Fan motoru sabitlemesi normal mi?", new string[] { "", "DÜZELT" } },
            { "Kılcal ve arka kısımdaki borular bir yere değiyor mu?", new string[] { "DÜZELT", "" } },
            { "Kılcalın üzerinde ve kılcalın eşanjörden ayrıldığı yerde bitüm var mı?", new string[] { "", "Kılcalın üzerine ve kılcalın eşanjörden ayrıldığı yere bitüm sar." } },
            { "Kompresör çalışma sesi normal mi?", new string[] { "Sistemi vakumla ve tekrar gaz bas", "Komprasör değiştir.Drayer değiştir, sistemi vakumla ve tekrar gaz bas." } },
        };


        private void statikGurultuNo()
        {
            int currentStep = statikAnormalGurultu.IndexOf(label2.Text);
            if (currentStep >= 0)
            {
                string[] sonuclar = diyagramSonuclar[label2.Text];
                //label2.Text = statikAnormalGurultu[currentStep - 1];
                if (label2.Text == "Kompresör ayakları gevşek mi?")
                {
                    label2.Text = statikAnormalGurultu[currentStep + 1];
                }
                if (label2.Text == "Kılcal ve arka kısımdaki borular bir yere değiyor mu?")
                {
                    label2.Text = statikAnormalGurultu[currentStep + 1];
                }
                label5.Text = sonuclar[1];
            }

        }

        private void statikGurultuYes()
        {
            int currentStep = statikAnormalGurultu.IndexOf(label2.Text);
            if (currentStep <= statikAnormalGurultu.Count - 1)
            {
                string[] sonuclar = diyagramSonuclar[label2.Text];
                if (label2.Text == "Cihaz zemini düz bir yere yerleştirilmiş mi?")
                {
                    label2.Text = statikAnormalGurultu[currentStep + 1];
                }
                if (label2.Text == "Ayarlı Ayaklar Ayarlı mı?")
                {
                    label2.Text = statikAnormalGurultu[currentStep + 1];
                }
                if (label2.Text == "Kondanser yada Fan motoru sabitlemesi normal mi?")
                {
                    label2.Text = statikAnormalGurultu[currentStep + 1];
                }
                if (label2.Text == "Kılcalın üzerinde ve kılcalın eşanjörden ayrıldığı yerde bitüm var mı?")
                {
                    label2.Text = statikAnormalGurultu[currentStep + 1];
                }
                if (label2.Text == "Kompresör çalışma sesi normal mi?")
                {
                    label5.Text = "Sistemi vakumla ve tekrar gaz bas"; // "Sistemi vakumla ve tekrar gaz bas" mesajı yazdırıldı

                }

                else
                {
                    label5.Text = "Sistemi vakumla ve tekrar gaz bas";
                }

                label5.Text = sonuclar[0];
            }
        }

        private void statikGurultuRestart()
        {
            label2.Text = "Cihaz zemini düz bir yere yerleştirilmiş mi?";
            label5.Text = "";
        }


        // Statik Gaz Akış Sesi

        public List<string> statikGazAkisSesi = new List<string>()
        {
            "Ses dondurucu evaparatör kısmında ve gaz akış sesi şeklinde mi?",
        };

        public Dictionary<string, string[]> diyagramSonuclar1 = new Dictionary<string, string[]>()
        {
            { "Ses dondurucu evaparatör kısmında ve gaz akış sesi şeklinde mi?", new string[] { "Sistem vakumlanarak plakette yer alan gaz miktarından 5 gr daha az gaz basılacak", "Kompresör \r\nkısmında, kılcalın \r\nüzerine ve kılcalın eşanjörden ayrıldığı yere bitüm sar" } },
        };


        private void statikGazAkisSesiNo()
        {
            int currentStep = statikGazAkisSesi.IndexOf(label2.Text);
            if (currentStep >= 0)
            {
                string[] sonuclar = diyagramSonuclar1[label2.Text];
                //label2.Text = statikAnormalGurultu[currentStep - 1];

                label5.Text = sonuclar[1];
            }

        }

        private void statikGazAkisSesiYes()
        {
            int currentStep = statikGazAkisSesi.IndexOf(label2.Text);
            if (currentStep <= statikGazAkisSesi.Count - 1)
            {
                string[] sonuclar = diyagramSonuclar1[label2.Text];


                label5.Text = sonuclar[0];
            }
        }

        private void statikGazAkisSesiRestart()
        {
            label2.Text = "Ses dondurucu evaparatör kısmında ve gaz akış sesi şeklinde mi?";
            label5.Text = "";
        }

        //Statik Soğutmuyor Ya da Yetersiz Soğutma 

        public List<string> statikSogutmuyor = new List<string>()
        {
            "Prizde enerji var mı? Şebeke enerji kontrolü yap (220-240v)",
            "Kompresör çalışıyor mu?",
            "Kompresöre gelen uçlardaki gerilimi ölçün Voltaj var mı? (220-240v)",
            "Termostat sağlam mı?",
            "Röle-Termik grubu sağlam mı?",
            "(***)Komp. uçları arasındaki omaj normal mi?",
            "(*)Sistemde gaz kaçağı var mı?",
            "Kondanser fan motoru çalışıyor mu?",
            "Soğutma gazını boşalt (**) Sisteme tekrar gaz şarjı yap",
            "Cihaz normale döndü mü?",
        };

        public Dictionary<string, string[]> diyagramSonuclar2 = new Dictionary<string, string[]>()
        {
            { "Prizde enerji var mı? Şebeke enerji kontrolü yap (220-240v)", new string[] { "", "Müşteriye Bilgi Ver" } },
            { "Kompresör çalışıyor mu?", new string[] { "", "" } },
            { "Kompresöre gelen uçlardaki gerilimi ölçün Voltaj var mı? (220-240v)", new string[] { "", "" } },
            { "Termostat sağlam mı?", new string[] { "Termostat Ayarlarını Kontrol Et", "DEĞİŞTİR" } },
            { "Röle-Termik grubu sağlam mı?", new string[] { "", "Röle-Termik Grubunu Değiştir" } },
            { "(***)Komp. uçları arasındaki omaj normal mi?", new string[] { "", "Kompresörü Kontrol Et Gerekirse Değiştir" } },
            { "(*)Sistemde gaz kaçağı var mı?", new string[] { "Sistemi tamamen boşalt Kaçağı gider(**) sisteme tekrar gaz bas", "" } },
            { "Kondanser fan motoru çalışıyor mu?", new string[] { "Soğutma gazını boşalt (**) Sisteme tekrar gaz şarjı yap", "Bağlantıları Kontrol Et" } },
            { "Soğutma gazını boşalt (**) Sisteme tekrar gaz şarjı yap", new string[] { "", "Soğutma gazını boşalt (**) Sisteme tekrar gaz şarjı yap" } },
            { "Cihaz normale döndü mü?", new string[] { "Gözle görünmeyen iç kısımlarda gaz kaçağı olabilir.Gerekirse \n sabun köpüğü ile kontrol et", "Kompresörü Kontrol Et Gerekirse Değiştir" } },
        };


        private void statikSogutmuyorNo()
        {
            int currentStep = statikSogutmuyor.IndexOf(label2.Text);
            if (currentStep >= 0)
            {
                string[] sonuclar = diyagramSonuclar2[label2.Text];

                if (label2.Text == "Kompresör çalışıyor mu?")
                {
                    label2.Text = statikSogutmuyor[currentStep + 1];
                    label6.Text = "";
                }
                else if (label2.Text == "Kompresöre gelen uçlardaki gerilimi ölçün Voltaj var mı? (220-240v)")
                {
                    label2.Text = statikSogutmuyor[currentStep + 1];
                    label6.Text = "";

                }
                else if (label2.Text == "(*)Sistemde gaz kaçağı var mı?")
                {
                    label2.Text = statikSogutmuyor[currentStep + 1];
                    label6.Text = "";

                }
                else if (label2.Text == "(***)Komp. uçları arasındaki omaj normal mi?")
                {
                    label6.Text = "(***) Kompresör ana sargı 10Ω yardımcı sargı ise 15Ω civarında olmalıdır. (25C ortam sıcaklığında)";
                }
                else if (label2.Text == "Soğutma gazını boşalt (**) Sisteme tekrar gaz şarjı yap")
                {
                    label6.Text = "(**) Sisteme gaz şarzı yapmadan önce mutlaka drayeri değiştirip en az 30 dakika vakum yaptıktan sonra, etiket değeri kadar soğutma\ngazı şarz yapın.";
                }

                else
                {
                    label6.Text = "";

                }
                label5.Text = sonuclar[1];
            }

        }

        private void statikSogutmuyorYes()
        {
            int currentStep = statikSogutmuyor.IndexOf(label2.Text);
            if (currentStep <= statikSogutmuyor.Count - 1)
            {
                string[] sonuclar = diyagramSonuclar2[label2.Text];


                if (label2.Text == "Prizde enerji var mı? Şebeke enerji kontrolü yap (220-240v)")
                {
                    label2.Text = statikSogutmuyor[currentStep + 1];
                    label6.Text = "";

                }
                else if (label2.Text == "Kompresör çalışıyor mu?")
                {
                    label2.Text = label2.Text = statikSogutmuyor[currentStep + 5];
                    label6.Text = "(* ) Gözle görülebilir tüm boru ve kaynak noktalarında gaz kaçağı olup olmadığını kontrol et.";
                }
                else if (label2.Text == "Kompresöre gelen uçlardaki gerilimi ölçün Voltaj var mı? (220-240v)")
                {
                    label2.Text = statikSogutmuyor[currentStep + 2];
                    label6.Text = "";

                }
                else if (label2.Text == "Röle-Termik grubu sağlam mı?")
                {
                    label2.Text = statikSogutmuyor[currentStep + 1];
                    label6.Text = "";

                }
                else if (label2.Text == "(***)Komp. uçları arasındaki omaj normal mi?")
                {
                    label2.Text = "Kompresöre gelen uçlardaki gerilimi ölçün Voltaj var mı? (220-240v)";
                    label6.Text = "";

                }
                else if (label2.Text == "Kondanser fan motoru çalışıyor mu?")
                {
                    label2.Text = statikSogutmuyor[currentStep + 1];
                    label6.Text = "(**) Sisteme gaz şarzı yapmadan önce mutlaka drayeri değiştirip en az 30 dakika vakum yaptıktan sonra, etiket değeri kadar soğutma\ngazı şarz yapın.";
                }
               else if (label2.Text == "Soğutma gazını boşalt (**) Sisteme tekrar gaz şarjı yap")
                {
                    label2.Text = statikSogutmuyor[currentStep + 1];
                    label6.Text = "";

                }
                else
                {
                    label6.Text = "";

                }



                label5.Text = sonuclar[0];

            }
        }

        private void statikSogutmuyorRestart()
        {
            label2.Text = "Prizde enerji var mı? Şebeke enerji kontrolü yap (220-240v)"; 
            label5.Text = "";
            label6.Text = "";
        }


        //Statik Aşırı Soğutma  

        public List<string> statikAsiriSogutma = new List<string>()
        {
            "Termostat konumu mevsim şartlarına uygun mu?",
            "Termostat bulb montajında boşluk var mı? Kontrol et.",
            "Sıcaklık değerlerini kontrol et.(Testo ile) Değerler normal mi?",
        };

        public Dictionary<string, string[]> diyagramSonuclar3 = new Dictionary<string, string[]>()
        {
            { "Termostat konumu mevsim şartlarına uygun mu?", new string[] { "", "Termostat Konumunu Değiştir" } },
            { "Termostat bulb montajında boşluk var mı? Kontrol et.", new string[] { "Termostat bulbunda boşluk kalmayacak şekilde montajını yap", "" } },
            { "Sıcaklık değerlerini kontrol et.(Testo ile) Değerler normal mi?", new string[] { "Müşteriye Bilgi Ver", "Termostatı Değiştir" } },
        };


        private void statikAsiriSogutmaNo()
        {
            int currentStep = statikAsiriSogutma.IndexOf(label2.Text);
            if (currentStep >= 0)
            {
                string[] sonuclar = diyagramSonuclar3[label2.Text];

                if (label2.Text == "Termostat bulb montajında boşluk var mı? Kontrol et.")
                {
                    label2.Text = statikAsiriSogutma[currentStep + 1];

                }

                label5.Text = sonuclar[1];
            }

        }

        private void statikAsiriSogutmaYes()
        {
            int currentStep = statikAsiriSogutma.IndexOf(label2.Text);
            if (currentStep <= statikAsiriSogutma.Count - 1)
            {
                string[] sonuclar = diyagramSonuclar3[label2.Text];


                if (label2.Text == "Termostat konumu mevsim şartlarına uygun mu?")
                {
                    label2.Text = statikAsiriSogutma[currentStep + 1];

                }
 

                label5.Text = sonuclar[0];

            }
        }

        private void statikAsiriSogutmaRestart()
        {
            label2.Text = "Termostat konumu mevsim şartlarına uygun mu?";
            label5.Text = "";

        }


        //Statik Top Şeklinde Buzlanma   

        public List<string> statikBuzlanma = new List<string>()
        {
            "Üründe gaz kaçağı var mı? Kontrol et.",
            "Yaz/Kış buton konumu mevsime uygun mu?",
            "Termostat sağlam mı?",
        };

        public Dictionary<string, string[]> diyagramSonuclar4 = new Dictionary<string, string[]>()
        {
            { "Üründe gaz kaçağı var mı? Kontrol et.", new string[] { "Gaz Kaçağını Giderin", "" } },
            { "Yaz/Kış buton konumu mevsime uygun mu?", new string[] { "", " Düzelt. Müşteriye buton konumu hakkında bilgi verin." } },
            { "Termostat sağlam mı?", new string[] { " Servis çözümü olarak 5.5C sıcak set değerli termostat kullanın.", "Termostatı Değiştir" } },
        };


        private void statikBuzlanmaNo()
        {
            int currentStep = statikBuzlanma.IndexOf(label2.Text);
            if (currentStep >= 0)
            {
                string[] sonuclar = diyagramSonuclar4[label2.Text];

                if (label2.Text == "Üründe gaz kaçağı var mı? Kontrol et.")
                {
                    label2.Text = statikBuzlanma[currentStep + 1];
                    label6.Text = "";

                }

                else
                {
                    label6.Text = "";
                }

                label5.Text = sonuclar[1];
            }

        }

        private void statikBuzlanmaYes()
        {
            int currentStep = statikBuzlanma.IndexOf(label2.Text);
            if (currentStep <= statikBuzlanma.Count - 1)
            {
                string[] sonuclar = diyagramSonuclar4[label2.Text];


                if (label2.Text == "Yaz/Kış buton konumu mevsime uygun mu?")
                {
                    label2.Text = statikBuzlanma[currentStep + 1];
                    label6.Text = "";

                }

                else if(label2.Text == "Termostat sağlam mı?")
                {
                    label6.Text = "TERMOSTAT KODU : 30016341-DNFS077B6705";
                }

                else
                {
                    label6.Text = "";
                }

                label5.Text = sonuclar[0];

            }
        }

        private void statikBuzlanmaRestart()
        {
            label2.Text = "Üründe gaz kaçağı var mı? Kontrol et.";
            label5.Text = "";
            label6.Text = "";

        }


        //Statik Koku Yapıyor  

        public List<string> statikKoku = new List<string>()
        {
            "Koku yiyeceklerden mi geliyor?",
            "Sodalı su veya sirke ile dolabın iç plastiğini temizle.",
            "Koku giderildi mi?",
        };

        public Dictionary<string, string[]> diyagramSonuclar5 = new Dictionary<string, string[]>()
        {
            { "Koku yiyeceklerden mi geliyor?", new string[] { "Dolabı boşaltıp müşteriye kokunun yiyeceklerden olduğunu izah edin.", "Sodalı su veya sirke ile dolabın iç plastiğini temizle." } },
            { "Sodalı su veya sirke ile dolabın iç plastiğini temizle.", new string[] { "", "Sodalı su veya sirke ile dolabın iç plastiğini temizle." } },
            { "Koku giderildi mi?", new string[] { "Gıdaların dolap içerisine kapalı kaplarda konulması için müşteriyi uyarın.", " Dolabın içerisine mangal kömürü konulacak." } },
        };


        private void statikKokuNo()
        {
            int currentStep = statikKoku.IndexOf(label2.Text);
            if (currentStep >= 0)
            {
                string[] sonuclar = diyagramSonuclar5[label2.Text];

                if (label2.Text == "Koku yiyeceklerden mi geliyor?")
                {
                    label2.Text = statikKoku[currentStep + 1];
                }



                label5.Text = sonuclar[1];
            }

        }

        private void statikKokuYes()
        {
            int currentStep = statikKoku.IndexOf(label2.Text);
            if (currentStep <= statikKoku.Count - 1)
            {
                string[] sonuclar = diyagramSonuclar5[label2.Text];


                if (label2.Text == "Sodalı su veya sirke ile dolabın iç plastiğini temizle.")
                {
                    label2.Text = statikKoku[currentStep + 1];

                }

                label5.Text = sonuclar[0];

            }
        }

        private void statikKokuRestart()
        {
            label2.Text = "Koku yiyeceklerden mi geliyor?";
            label5.Text = "";
            label6.Text = "";

        }


        //Statik Soğutucu kapıda düşme ve sol üst köşede açıklık (Statik)


        public List<string> statikDusme = new List<string>()
        {
            "Cihaz, zemini düz bir yere mi yerleştirilmiş?",
            "Ayarlı ayaklar ayarlı mı?",
            "Menteşe eksenlerinde kaçıklık, vidalarda gevşeklik var mı?",
            "Conta formunda bozulma var mı?",
            "Saç kurutma makinası ile ısıtma uygulaması yapın.Conta kapanıyor mu?",
            "Servis çözümü olarak\r\nalt kapı altına 3 adet pul ve alt menteşe destek plastiği koy.",
            "Problem çözüldü mü ?",
        };

        public Dictionary<string, string[]> diyagramSonuclar6 = new Dictionary<string, string[]>()
        {
            { "Cihaz, zemini düz bir yere mi yerleştirilmiş?", new string[] { "", "DÜZELT" } },
            { "Ayarlı ayaklar ayarlı mı?", new string[] { "", "DÜZELT" } },
            { "Menteşe eksenlerinde kaçıklık, vidalarda gevşeklik var mı?", new string[] { "DÜZELT", "" } },
            { "Conta formunda bozulma var mı?", new string[] { "", "" } },
            { "Saç kurutma makinası ile ısıtma uygulaması yapın.Conta kapanıyor mu?", new string[] { "", " Sökülebilir conta ise contayı değiştir. Değilse kapıyı değiştir." } },
            { "Servis çözümü olarak\r\nalt kapı altına 3 adet pul ve alt menteşe destek plastiği koy.", new string[] { "", "alt kapı altına 3 adet pul ve alt menteşe destek plastiği koy." } },
            { "Problem çözüldü mü ?", new string[] { "Teknik Arıza Çözülmüştür.", " Gövdede çarpılma kontrolü yap. Problem giderilemiyorsa, ürün değişimi yap" } },

        };


        private void statikDusmeNo()
        {
            int currentStep = statikDusme.IndexOf(label2.Text);
            if (currentStep >= 0)
            {
                string[] sonuclar = diyagramSonuclar6[label2.Text];

                if (label2.Text == "Menteşe eksenlerinde kaçıklık, vidalarda gevşeklik var mı?")
                {
                    label2.Text = statikDusme[currentStep + 1];
                }

                else if (label2.Text == "Conta formunda bozulma var mı?")
                {
                    label2.Text = statikDusme[currentStep + 2];
                }



                label5.Text = sonuclar[1];
            }

        }

        private void statikDusmeYes()
        {
            int currentStep = statikDusme.IndexOf(label2.Text);
            if (currentStep <= statikDusme.Count - 1)
            {
                string[] sonuclar = diyagramSonuclar6[label2.Text];


                if (label2.Text == "Cihaz, zemini düz bir yere mi yerleştirilmiş?")
                {
                    label2.Text = statikDusme[currentStep + 1];

                }

                else if (label2.Text == "Ayarlı ayaklar ayarlı mı?")
                {
                    label2.Text = statikDusme[currentStep + 1];

                }

                else if (label2.Text == "Conta formunda bozulma var mı?")
                {
                    label2.Text = statikDusme[currentStep + 1];

                }

                else if(label2.Text == "Saç kurutma makinası ile ısıtma uygulaması yapın.Conta kapanıyor mu?")
                {
                    label2.Text = "Conta formunda bozulma var mı?";
                }

                else if (label2.Text == "Servis çözümü olarak\r\nalt kapı altına 3 adet pul ve alt menteşe destek plastiği koy.")
                {
                    label2.Text = statikDusme[currentStep + 1];

                }



                label5.Text = sonuclar[0];

            }
        }

        private void statikDusmeRestart()
        {
            label2.Text = "Cihaz, zemini düz bir yere mi yerleştirilmiş?";
            label5.Text = "";
            label6.Text = "";

        }


        //Mekanik No Frost Soğutmuyor Ya da Yetersiz Soğutma 

        public List<string> mekanikSogutmuyor = new List<string>()
        {
            "Soğutma ayarları doğrumu?",
            "Kompresör çalışıyor mu?",
            "Kompresöre gelen uçlardaki gerilimi ölçün Voltaj var mı? (220-240v)",
            "Röle-Termik grubu sağlam mı?",
            "Dondurucu ve soğutucu kapı siviç bağlantıları normal mı?",
            "Fan motoru çalışıyormu?",
            "Termostatlar sağlam mı?(**)",
            "(**)Sistemde gaz kaçağı var mı?",
        };

        public Dictionary<string, string[]> diyagramSonuclar7 = new Dictionary<string, string[]>()
        {
            { "Soğutma ayarları doğrumu?", new string[] { "", "Müşteriye Bilgi Ver" } },
            { "Kompresör çalışıyor mu?", new string[] { "", "" } },
            { "Kompresöre gelen uçlardaki gerilimi ölçün Voltaj var mı? (220-240v)", new string[] { "", " Soket bağlantılarını kontrol et gerekirse Elektronik Timeri değiştir." } },
            { "Röle-Termik grubu sağlam mı?", new string[] { "Komp. uçları arasındaki omajı kontrol et. Gerekirse komprasör değiştir.", "Röle-Termik Grubunu Değiştir" } },
            { "Dondurucu ve soğutucu kapı siviç bağlantıları normal mı?", new string[] { "", "DÜZELT" } },
            { "Fan motoru çalışıyormu?", new string[] { "", "DEĞİŞTİR" } },
            { "Termostatlar sağlam mı?(**)", new string[] { "", "DEĞİŞTİR" } },
            { "(**)Sistemde gaz kaçağı var mı?", new string[] { " Sistemi tamamen boşalt Kaçağı gider", " Soket bağlantılarını kontol et gerekirse Elektronik Timeri değiştir." } },
        };


        private void mekanikSogutmuyorNo()
        {
            int currentStep = mekanikSogutmuyor.IndexOf(label2.Text);
            if (currentStep >= 0)
            {
                string[] sonuclar = diyagramSonuclar7[label2.Text];

                if (label2.Text == "Kompresör çalışıyor mu?")
                {
                    label2.Text = mekanikSogutmuyor[currentStep + 1];
                    label6.Text = "";
                }


                else
                {
                    label6.Text = "";

                }
                label5.Text = sonuclar[1];
            }

        }

        private void mekanikSogutmuyorYes()
        {
            int currentStep = mekanikSogutmuyor.IndexOf(label2.Text);
            if (currentStep <= mekanikSogutmuyor.Count - 1)
            {
                string[] sonuclar = diyagramSonuclar7[label2.Text];


                if (label2.Text == "Soğutma ayarları doğrumu?")
                {
                    label2.Text = mekanikSogutmuyor[currentStep + 1];
                    label6.Text = "";

                }
                else if (label2.Text == "Kompresör çalışıyor mu?")
                {
                    label2.Text = label2.Text = mekanikSogutmuyor[currentStep + 3];
                }
                else if (label2.Text == "Kompresöre gelen uçlardaki gerilimi ölçün Voltaj var mı? (220-240v)")
                {
                    label2.Text = mekanikSogutmuyor[currentStep + 1];
                    label6.Text = "";

                }
                else if (label2.Text == "Röle-Termik grubu sağlam mı?")
                {
                    label6.Text = "(*)Kompresör ana sargı 10Ω yardımcı sargı ise 15Ω civarında olmalıdır. (25C ortam sıcaklığında)";

                }
                else if (label2.Text == "Dondurucu ve soğutucu kapı siviç bağlantıları normal mı?")
                {
                    label2.Text = mekanikSogutmuyor[currentStep + 1];
                    label6.Text = "";

                }
                else if (label2.Text == "Fan motoru çalışıyormu?")
                {
                    label2.Text = mekanikSogutmuyor[currentStep + 1];
                    label6.Text = "";
                }
                else if (label2.Text == "Termostatlar sağlam mı?(**)")
                {
                    label2.Text = mekanikSogutmuyor[currentStep + 1];
                    label6.Text = "(**)Gözle görülebilir tüm boru ve kaynak noktalarında gaz kaçağı olup olmadığını kontrol et.";

                }
                else if (label2.Text == "(**)Sistemde gaz kaçağı var mı?")
                {
                    label6.Text = "(***)Sisteme gaz şarzı yapmadan önce mutlaka dryeri değiştirip en az 30 dakika vakum yaptıktan sonra, \r\netiket değeri kadar soğutma gazı şarz yapın.\r\n";

                }


                
                else
                {
                    label6.Text = "";

                }



                label5.Text = sonuclar[0];

            }
        }

        private void mekanikSogutmuyorRestart()
        {
            label2.Text = "Soğutma ayarları doğrumu?";
            label5.Text = "";
            label6.Text = "";
        }


        //Mekanik Soğutucu kapıda düşme ve sol üst köşede açıklık (Mekanik)


        public List<string> MekanikDusme = new List<string>()
        {
            "Cihaz, zemini düz bir yere mi yerleştirilmiş?",
            "Ayarlı ayaklar ayarlı mı?",
            "Menteşe eksenlerinde kaçıklık, vidalarda gevşeklik var mı?",
            "Conta formunda bozulma var mı?",
            "Saç kurutma makinası ile ısıtma uygulaması yapın.Conta kapanıyor mu?",
            "Servis çözümü olarak\r\n Servis merkezinden gönderilen 37008602 Kodlu \"Kapı Ayar Servis Kiti (CE)\" uygulanmalıdır",
            "Problem çözüldü mü ?",
        };

        public Dictionary<string, string[]> diyagramSonuclar8 = new Dictionary<string, string[]>()
        {
            { "Cihaz, zemini düz bir yere mi yerleştirilmiş?", new string[] { "", "DÜZELT" } },
            { "Ayarlı ayaklar ayarlı mı?", new string[] { "", "DÜZELT" } },
            { "Menteşe eksenlerinde kaçıklık, vidalarda gevşeklik var mı?", new string[] { "DÜZELT", "" } },
            { "Conta formunda bozulma var mı?", new string[] { "", "" } },
            { "Saç kurutma makinası ile ısıtma uygulaması yapın.Conta kapanıyor mu?", new string[] { "", " Sökülebilir conta ise contayı değiştir. Değilse kapıyı değiştir." } },
            { "Servis çözümü olarak\r\n Servis merkezinden gönderilen 37008602 Kodlu \"Kapı Ayar Servis Kiti (CE)\" uygulanmalıdır", new string[] { "", "Servis merkezinden gönderilen 37008602 Kodlu \"Kapı Ayar Servis Kiti (CE)\" uygulanmalıdır" } },
            { "Problem çözüldü mü ?", new string[] { "Teknik Arıza Çözülmüştür.", " Gövdede çaprazlık kontrolü yap. Problem giderilemiyorsa, ürün değişimi yap" } },

        };


        private void MekanikDusmeNo()
        {
            int currentStep = MekanikDusme.IndexOf(label2.Text);
            if (currentStep >= 0)
            {
                string[] sonuclar = diyagramSonuclar8[label2.Text];

                if (label2.Text == "Menteşe eksenlerinde kaçıklık, vidalarda gevşeklik var mı?")
                {
                    label2.Text = MekanikDusme[currentStep + 1];
                }

                else if (label2.Text == "Conta formunda bozulma var mı?")
                {
                    label2.Text = MekanikDusme[currentStep + 2];
                }



                label5.Text = sonuclar[1];
            }

        }

        private void MekanikDusmeYes()
        {
            int currentStep = MekanikDusme.IndexOf(label2.Text);
            if (currentStep <= MekanikDusme.Count - 1)
            {
                string[] sonuclar = diyagramSonuclar8[label2.Text];


                if (label2.Text == "Cihaz, zemini düz bir yere mi yerleştirilmiş?")
                {
                    label2.Text = MekanikDusme[currentStep + 1];

                }

                else if (label2.Text == "Ayarlı ayaklar ayarlı mı?")
                {
                    label2.Text = MekanikDusme[currentStep + 1];

                }

                else if (label2.Text == "Conta formunda bozulma var mı?")
                {
                    label2.Text = MekanikDusme[currentStep + 1];

                }

                else if (label2.Text == "Saç kurutma makinası ile ısıtma uygulaması yapın.Conta kapanıyor mu?")
                {
                    label2.Text = "Conta formunda bozulma var mı?";
                }

                else if (label2.Text == "Servis çözümü olarak\r\n Servis merkezinden gönderilen 37008602 Kodlu \"Kapı Ayar Servis Kiti (CE)\" uygulanmalıdır")
                {
                    label2.Text = MekanikDusme[currentStep + 1];

                }



                label5.Text = sonuclar[0];

            }
        }

        private void MekanikDusmeRestart()
        {
            label2.Text = "Cihaz, zemini düz bir yere mi yerleştirilmiş?";
            label5.Text = "";
            label6.Text = "";

        }


        //Mekanik Gaz Akış Sesi  

        public List<string> mekanikGaz = new List<string>()
        {
            "Ses dondurucu evaparatör kısmında ve gaz akış sesi şeklinde mi?",

        };

        public Dictionary<string, string[]> diyagramSonuclar9 = new Dictionary<string, string[]>()
        {
            { "Ses dondurucu evaparatör kısmında ve gaz akış sesi şeklinde mi?", new string[] { "Sistem vakumlanarak plakette yer alan gaz miktarından 5 gr daha az gaz basılmalıdır.\r\n(drayer değişimi de mutlaka yapılmalıdır)", " Kompresör kısmında, kılcalın üzerine ve kılcalın eşanjörden ayrıldığı yere bitüm sar." } },

        };


        private void mekanikGazNo()
        {
            int currentStep = mekanikGaz.IndexOf(label2.Text);
            if (currentStep >= 0)
            {
                string[] sonuclar = diyagramSonuclar9[label2.Text];


                label5.Text = sonuclar[1];
            }

        }

        private void mekanikGazYes()
        {
            int currentStep = mekanikGaz.IndexOf(label2.Text);
            if (currentStep <= mekanikGaz.Count - 1)
            {
                string[] sonuclar = diyagramSonuclar9[label2.Text];

                label5.Text = sonuclar[0];

            }
        }

        private void mekanikGazRestart()
        {
            label2.Text = "Ses dondurucu evaparatör kısmında ve gaz akış sesi şeklinde mi?";
            label5.Text = "";
            label6.Text = "";

        }


        //Mekanik Aşırı Soğutma

        public List<string> mekanikSogutma = new List<string>()
        {
            "Damper termostat ayarı maksimumda mı?",
            "Damper termostatta buzlanma var mı?",

        };

        public Dictionary<string, string[]> diyagramSonuclar10 = new Dictionary<string, string[]>()
        {
            { "Damper termostat ayarı maksimumda mı?", new string[] { " Damper termostat ayarını yap.", "" } },
            { "Damper termostatta buzlanma var mı?", new string[] { " Buzlanmayı gider. İzolasyonu kontrol et. Termostat ayarını yap.", " Damper termostatın sağlamlığını kontrol et." } },


        };


        private void mekanikSogutmaNo()
        {
            int currentStep = mekanikSogutma.IndexOf(label2.Text);
            if (currentStep >= 0)
            {
                string[] sonuclar = diyagramSonuclar10[label2.Text];

            if (label2.Text == "Damper termostat ayarı maksimumda mı?")
            {
                    label2.Text = mekanikSogutma[currentStep + 1];

            }

                label5.Text = sonuclar[1];
            }

        }

        private void mekanikSogutmaYes()
        {
            int currentStep = mekanikSogutma.IndexOf(label2.Text);
            if (currentStep <= mekanikSogutma.Count - 1)
            {
                string[] sonuclar = diyagramSonuclar10[label2.Text];

                label5.Text = sonuclar[0];

            }
        }

        private void mekanikSogutmaRestart()
        {
            label2.Text = "Damper termostat ayarı maksimumda mı?";
            label5.Text = "";
            label6.Text = "";

        }



        //Mekanik Ara Bölme Buzlanma

        public List<string> mekanikBuzlanma = new List<string>()
        {
            "Fin evabı açın. Ara bölmede buzlanma var mı?",
            "Dondurucu fan motoru çalışıyor mu?",
            "Buzları erit. Ara bölme ve Fin evap rezistansları sağlam mı?",

        };

        public Dictionary<string, string[]> diyagramSonuclar11 = new Dictionary<string, string[]>()
        {
            { "Fin evabı açın. Ara bölmede buzlanma var mı?", new string[] { "", "" } },
            { "Dondurucu fan motoru çalışıyor mu?", new string[] { " Damper termostatın sağlamlığını kontrol et. Gerekirse değiştir.", "DEĞİŞTİR" } },
            { "Buzları erit. Ara bölme ve Fin evap rezistansları sağlam mı?", new string[] { " *Ekim 2006 öncesi ürünler için :\r\n- Kulaksız dondurucu  \r\n- Hava kanal kapağı takın. \r\n- Elektronik timer takın.\r\n *Ekim 2006 sonrası ürünler için : \r\n- Elektronik timer takın.", "Fin evap rezistansı arızalı ise evaparatör komple değiştir. Ara bölme rezistansı arızalı ise aşağıda \r\nverilen parça koduna göre rezistansı değiştir" } },

        };


        private void mekanikBuzlanmaNo()
        {
            int currentStep = mekanikBuzlanma.IndexOf(label2.Text);
            if (currentStep >= 0)
            {
                string[] sonuclar = diyagramSonuclar11[label2.Text];

                if (label2.Text == "Fin evabı açın. Ara bölmede buzlanma var mı?")
                {
                    label2.Text = mekanikBuzlanma[currentStep + 1];
                    label6.Text = "";
                }

                else if (label2.Text == "Buzları erit. Ara bölme ve Fin evap rezistansları sağlam mı?")
                {
                    label6.Text = "* Mavi servis kartının kodu: 32003046 - ANA KART / 640(SERVİS)\r\n 32006243      ARA BÖLME REZ.GR./ 640M - 540M(MLT SOKET ÖNCE)\r\n 32006244      ARA BÖLME REZ.GR./ 465M - 565M(MLT SOKET ÖNCE)\r\n 32006025      ARA BÖLME REZ.GR./ 465 - 565 - 570(MULTI SOKET) \r\n 32006037 ARA BÖLME REZ.GR./ 640 - 540(MULTI SOKET)";
                }

                else
                {
                    label6.Text = "";
                }
                
                label5.Text = sonuclar[1];
            }
        }
        private void mekanikBuzlanmaYes()
        {
            int currentStep = mekanikBuzlanma.IndexOf(label2.Text);
            if (currentStep <= mekanikBuzlanma.Count - 1)
            {
                string[] sonuclar = diyagramSonuclar11[label2.Text];
                if (label2.Text == "Fin evabı açın. Ara bölmede buzlanma var mı?")
                {
                    label2.Text = mekanikBuzlanma[currentStep + 2];
                    label6.Text = "";
                }

                else
                {
                    label6.Text = "";
                }
                label5.Text = sonuclar[0];
            }
        }
        private void mekanikBuzlanmaRestart()
        {
            label2.Text = "Fin evabı açın. Ara bölmede buzlanma var mı?";
            label5.Text = "";
            label6.Text = "";
        }


        //Mekanik Soğutucu hava kanalı ile tavanın birleşim noktasında terleme 

        public List<string> mekanikTerleme = new List<string>()
        {
            "Soğutucu hava kanal strafor grubunu sökün",
            "Strafor üzerindeki epidem süngerleri kontrol et. Sağlam mı?",

        };

        public Dictionary<string, string[]> diyagramSonuclar12 = new Dictionary<string, string[]>()
        {
            { "Soğutucu hava kanal strafor grubunu sökün", new string[] { "", "Soğutucu hava kanal strafor grubunu sökün" } },
            { "Strafor üzerindeki epidem süngerleri kontrol et. Sağlam mı?", new string[] { "Soğutucu hava kanal grubunu hava kaçağı olmayacak şekilde sıkıca monte edin. (*)", " Strafor üzerindeki epidem süngerleri değiştirin" } },

        };


        private void mekanikTerlemeNo()
        {
            int currentStep = mekanikTerleme.IndexOf(label2.Text);
            if (currentStep >= 0)
            {
                string[] sonuclar = diyagramSonuclar12[label2.Text];
                label6.Text = "";


                label5.Text = sonuclar[1];
            }
        }
        private void mekanikTerlemeYes()
        {
            int currentStep = mekanikTerleme.IndexOf(label2.Text);
            if (currentStep <= mekanikTerleme.Count - 1)
            {
                string[] sonuclar = diyagramSonuclar12[label2.Text];
                if (label2.Text == "Soğutucu hava kanal strafor grubunu sökün")
                {
                    label2.Text = mekanikTerleme[currentStep + 1];
                    label6.Text = "";

                }

                else if (label2.Text == "Strafor üzerindeki epidem süngerleri kontrol et. Sağlam mı?")
                {
                    label6.Text = "(*) 640 modellerde sızdırmazlık contası çift parçalı ve iki parçalı ise tek parçalı conta ile değiştirin.";
                }

                else
                {
                    label6.Text = "";
                }

                
                label5.Text = sonuclar[0];
            }
        }
        private void mekanikTerlemeRestart()
        {
            label2.Text = "Soğutucu hava kanal strafor grubunu sökün";
            label5.Text = "";
            label6.Text = "";
        }



        //Elektronik No Frost Soğutmuyor Ya da Yetersiz Soğutma 

        public List<string> elektronikSogutmuyor = new List<string>()
        {
            "Soğutma ayarları doğrumu?",
            "Kompresör çalışıyor mu?",
            "Kompresöre gelen uçlardaki gerilimi ölçün Voltaj var mı? (220-240v)",
            "Röle-Termik grubu sağlam mı?",
            "Dondurucu ve soğutucu kapı siviç bağlantıları normal mı?",
            "Fan motoru çalışıyormu?",
            "Damper motor sağlam mı?(**)",
            "(**)Sistemde gaz kaçağı var mı?",
            "Sensörler sağlam mı? Değerlerini kontrol et",
        };

        public Dictionary<string, string[]> diyagramSonuclar13 = new Dictionary<string, string[]>()
        {
            { "Soğutma ayarları doğrumu?", new string[] { "", "Müşteriye Bilgi Ver" } },
            { "Kompresör çalışıyor mu?", new string[] { "", "" } },
            { "Kompresöre gelen uçlardaki gerilimi ölçün Voltaj var mı? (220-240v)", new string[] { "", " Soket bağlantılarını kontrol et gerekirse Anakart değiştir." } },
            { "Röle-Termik grubu sağlam mı?", new string[] { "Komp. uçları arasındaki omajı kontrol et. Gerekirse komprasör değiştir.", "Röle-Termik Grubunu Değiştir" } },
            { "Dondurucu ve soğutucu kapı siviç bağlantıları normal mı?", new string[] { "", "DÜZELT" } },
            { "Fan motoru çalışıyormu?", new string[] { "", "DEĞİŞTİR" } },
            { "Damper motor sağlam mı?(**)", new string[] { "", "DEĞİŞTİR" } },
            { "(**)Sistemde gaz kaçağı var mı?", new string[] { " Sistemi tamamen boşalt Kaçağı gider", "" } },
            { "Sensörler sağlam mı? Değerlerini kontrol et", new string[] { "Soket bağlantılarını kontrol et gerekirse Anakart değiştir", "DEĞİŞTİR" } },


        };


        private void elektronikSogutmuyorNo()
        {
            int currentStep = elektronikSogutmuyor.IndexOf(label2.Text);
            if (currentStep >= 0)
            {
                string[] sonuclar = diyagramSonuclar13[label2.Text];

                if (label2.Text == "Kompresör çalışıyor mu?")
                {
                    label2.Text = elektronikSogutmuyor[currentStep + 1];
                    label6.Text = "";
                }

                if (label2.Text == "(**)Sistemde gaz kaçağı var mı?")
                {
                    label2.Text = elektronikSogutmuyor[currentStep + 1];
                    label6.Text = "";
                }


                else
                {
                    label6.Text = "";

                }
                label5.Text = sonuclar[1];
            }

        }

        private void elektronikSogutmuyorYes()
        {
            int currentStep = elektronikSogutmuyor.IndexOf(label2.Text);
            if (currentStep <= elektronikSogutmuyor.Count - 1)
            {
                string[] sonuclar = diyagramSonuclar13[label2.Text];


                if (label2.Text == "Soğutma ayarları doğrumu?")
                {
                    label2.Text = elektronikSogutmuyor[currentStep + 1];
                    label6.Text = "";

                }
                else if (label2.Text == "Kompresör çalışıyor mu?")
                {
                    label2.Text = label2.Text = elektronikSogutmuyor[currentStep + 3];
                }
                else if (label2.Text == "Kompresöre gelen uçlardaki gerilimi ölçün Voltaj var mı? (220-240v)")
                {
                    label2.Text = elektronikSogutmuyor[currentStep + 1];
                    label6.Text = "";

                }
                else if (label2.Text == "Röle-Termik grubu sağlam mı?")
                {
                    label6.Text = "(*)Kompresör ana sargı 10Ω yardımcı sargı ise 15Ω civarında olmalıdır. (25C ortam sıcaklığında)";

                }
                else if (label2.Text == "Dondurucu ve soğutucu kapı siviç bağlantıları normal mı?")
                {
                    label2.Text = elektronikSogutmuyor[currentStep + 1];
                    label6.Text = "";

                }
                else if (label2.Text == "Fan motoru çalışıyormu?")
                {
                    label2.Text = elektronikSogutmuyor[currentStep + 1];
                    label6.Text = "";
                }
                else if (label2.Text == "Damper motor sağlam mı?(**)")
                {
                    label2.Text = elektronikSogutmuyor[currentStep + 1];
                    label6.Text = "(**)Gözle görülebilir tüm boru ve kaynak noktalarında gaz kaçağı olup olmadığını kontrol et.";

                }
                else if (label2.Text == "(**)Sistemde gaz kaçağı var mı?")
                {
                    label6.Text = "(***)Sisteme gaz şarzı yapmadan önce mutlaka dryeri değiştirip en az 30 dakika vakum yaptıktan sonra, \r\netiket değeri kadar soğutma gazı şarz yapın.\r\n";

                }



                else
                {
                    label6.Text = "";

                }



                label5.Text = sonuclar[0];

            }
        }

        private void elektronikSogutmuyorRestart()
        {
            label2.Text = "Soğutma ayarları doğrumu?";
            label5.Text = "";
            label6.Text = "";
        }


        //Elektronik Aşırı Soğutma

        public List<string> elektronikSogutma = new List<string>()
        {
            "Soğutma konumunu kontrol et. Normal mi?",
            "Dolabı servis moduna al. Damper açma/kapama yapıyor mu",
            "Damper motoru sağlam mı?",
            "Bağlantı soketleri normal mi?",

        };

        public Dictionary<string, string[]> diyagramSonuclar14 = new Dictionary<string, string[]>()
        {
            { "Soğutma konumunu kontrol et. Normal mi?", new string[] { "", "Ayar yapılıp müşteriye bilgi verilmelidir." } },
            { "Dolabı servis moduna al. Damper açma/kapama yapıyor mu", new string[] { "Sensör konumlarını kontrol et", "" } },
            { "Damper motoru sağlam mı?", new string[] { "", "Damper termostatı değiştir." } },
            { "Bağlantı soketleri normal mi?", new string[] { "Ana kartı değiştirin", "Soket bağlantılarını yapın" } },



        };


        private void elektronikSogutmaNo()
        {
            int currentStep = elektronikSogutma.IndexOf(label2.Text);
            if (currentStep >= 0)
            {
                string[] sonuclar = diyagramSonuclar14[label2.Text];

                if (label2.Text == "Dolabı servis moduna al. Damper açma/kapama yapıyor mu")
                {
                    label2.Text = elektronikSogutma[currentStep + 1];

                }

                label5.Text = sonuclar[1];
            }

        }

        private void elektronikSogutmaYes()
        {
            int currentStep = elektronikSogutma.IndexOf(label2.Text);
            if (currentStep <= elektronikSogutma.Count - 1)
            {
                string[] sonuclar = diyagramSonuclar14[label2.Text];

                if (label2.Text == "Soğutma konumunu kontrol et. Normal mi?")
                {
                    label2.Text = elektronikSogutma[currentStep + 1];

                }

                else if (label2.Text == "Damper motoru sağlam mı?")
                {
                    label2.Text = elektronikSogutma[currentStep + 1];

                }

                label5.Text = sonuclar[0];

            }
        }

        private void elektronikSogutmaRestart()
        {
            label2.Text = "Soğutma konumunu kontrol et. Normal mi?";
            label5.Text = "";
            label6.Text = "";

        }


        //Elektronik Ara Bölme Buzlanma

        public List<string> elektronikBuzlanma = new List<string>()
        {
            "Fin evabı açın. Ara bölmede buzlanma var mı?",
            "Dondurucu fan motoru çalışıyor mu?",
            "Buzları erit. Ara bölme ve Fin evap rezistansları sağlam mı?",

        };

        public Dictionary<string, string[]> diyagramSonuclar15 = new Dictionary<string, string[]>()
        {
            { "Fin evabı açın. Ara bölmede buzlanma var mı?", new string[] { "", "" } },
            { "Dondurucu fan motoru çalışıyor mu?", new string[] { "Damper motorun açma/kapama yaptığını kontrol et. Gerekirse değiştir", "DEĞİŞTİR" } },
            { "Buzları erit. Ara bölme ve Fin evap rezistansları sağlam mı?", new string[] { " *Ekim 2006 öncesi ürünler için :\r\n- Kulaksız dondurucu  \r\n- Hava kanal kapağı takın. \r\n- Servis kartı (mavi kart) takın (*).\r\n *Ekim 2006 sonrası ürünler için : \r\n- Servis kartı (mavi kart) takın (*).", "Fin evap rezistansı arızalı ise evaparatör komple değiştir. Ara bölme rezistansı arızalı ise aşağıda \r\nverilen parça koduna göre rezistansı değiştir" } },

        };


        private void elektronikBuzlanmaNo()
        {
            int currentStep = elektronikBuzlanma.IndexOf(label2.Text);
            if (currentStep >= 0)
            {
                string[] sonuclar = diyagramSonuclar15[label2.Text];

                if (label2.Text == "Fin evabı açın. Ara bölmede buzlanma var mı?")
                {
                    label2.Text = elektronikBuzlanma[currentStep + 1];
                    label6.Text = "";
                }

                else if (label2.Text == "Buzları erit. Ara bölme ve Fin evap rezistansları sağlam mı?")
                {
                    label6.Text = "* Mavi servis kartının kodu: 32003046 - ANA KART / 640(SERVİS)\r\n 32006243      ARA BÖLME REZ.GR./ 640M - 540M(MLT SOKET ÖNCE)\r\n 32006244      ARA BÖLME REZ.GR./ 465M - 565M(MLT SOKET ÖNCE)\r\n 32006025      ARA BÖLME REZ.GR./ 465 - 565 - 570(MULTI SOKET) \r\n 32006037 ARA BÖLME REZ.GR./ 640 - 540(MULTI SOKET)";
                }

                else
                {
                    label6.Text = "";
                }

                label5.Text = sonuclar[1];
            }
        }
        private void elektronikBuzlanmaYes()
        {
            int currentStep = elektronikBuzlanma.IndexOf(label2.Text);
            if (currentStep <= elektronikBuzlanma.Count - 1)
            {
                string[] sonuclar = diyagramSonuclar15[label2.Text];
                if (label2.Text == "Fin evabı açın. Ara bölmede buzlanma var mı?")
                {
                    label2.Text = elektronikBuzlanma[currentStep + 2];
                    label6.Text = "";
                }

                else
                {
                    label6.Text = "";
                }
                label5.Text = sonuclar[0];
            }
        }
        private void elektronikBuzlanmaRestart()
        {
            label2.Text = "Fin evabı açın. Ara bölmede buzlanma var mı?";
            label5.Text = "";
            label6.Text = "";
        }




        //Elektronik Soğutucu kısımda yetersiz Soğutma

        public List<string> elektronikYetersiz = new List<string>()
        {
            "Fin evabı açın. Ara bölmede buzlanma var mı?",
            "Buzları erit. Ara bölme ve Fin evap rezistanslarını kontrol et",

        };

        public Dictionary<string, string[]> diyagramSonuclar16 = new Dictionary<string, string[]>()
        {
            { "Fin evabı açın. Ara bölmede buzlanma var mı?", new string[] { "", "Damper motoru kontrol et. Buzlanma oluşmuş ise erit. Gerekirse damper motoru değiştir." } },
            { "Buzları erit. Ara bölme ve Fin evap rezistanslarını kontrol et", new string[] { " - Elektronik servis kartı takın. \r\n- Kulaksız dondurucu Hava kanal kapağı takın. \r\n- Problem çözülemez ise ürün değişimi yapılacak - .", "Fin evap rezistansı arızalı ise evaparatör komple değiştir. Ara bölme rezistansı arızalı ise aşağıda \r\nverilen parça koduna göre rezistansı değiştir" } },

        };


        private void elektronikYetersizNo()
        {
            int currentStep = elektronikYetersiz.IndexOf(label2.Text);
            if (currentStep >= 0)
            {
                string[] sonuclar = diyagramSonuclar16[label2.Text];


                if (label2.Text == "Buzları erit. Ara bölme ve Fin evap rezistanslarını kontrol et")
                {
                    label6.Text = "32006243      ARA BÖLME REZ.GR./ 640M - 540M(MLT SOKET ÖNCE)\r\n 32006244      ARA BÖLME REZ.GR./ 465M - 565M(MLT SOKET ÖNCE)\r\n 32006025      ARA BÖLME REZ.GR./ 465 - 565 - 570(MULTI SOKET) \r\n 32006037 ARA BÖLME REZ.GR./ 640 - 540(MULTI SOKET)";
                }

                else
                {
                    label6.Text = "";
                }

                label5.Text = sonuclar[1];
            }
        }
        private void elektronikYetersizYes()
        {
            int currentStep = elektronikYetersiz.IndexOf(label2.Text);
            if (currentStep <= elektronikYetersiz.Count - 1)
            {
                string[] sonuclar = diyagramSonuclar16[label2.Text];
                if (label2.Text == "Fin evabı açın. Ara bölmede buzlanma var mı?")
                {
                    label2.Text = elektronikYetersiz[currentStep + 1];
                    label6.Text = "";
                }

                else
                {
                    label6.Text = "";
                }
                label5.Text = sonuclar[0];
            }
        }
        private void elektronikYetersizRestart()
        {
            label2.Text = "Fin evabı açın. Ara bölmede buzlanma var mı?";
            label5.Text = "";
            label6.Text = "";
        }


        // Sensör Kart Hataları FE - 01 

        public List<string> Sensor1 = new List<string>()
        {
            "Dondurucu sensör bağlantı ve soketleri normal mi?",
            "Dondurucu sensörü sağlam mı?",

        };

        public Dictionary<string, string[]> diyagramSonuclar17 = new Dictionary<string, string[]>()
        {
            { "Dondurucu sensör bağlantı ve soketleri normal mi?", new string[] { "", "DÜZELT" } },
            { "Dondurucu sensörü sağlam mı?", new string[] { "Güç kartını değiştir", "Sensörü değiştir" } },

        };


        private void Sensor1No()
        {
            int currentStep = Sensor1.IndexOf(label2.Text);
            if (currentStep >= 0)
            {
                string[] sonuclar = diyagramSonuclar17[label2.Text];



                label5.Text = sonuclar[1];
            }
        }
        private void Sensor1Yes()
        {
            int currentStep = Sensor1.IndexOf(label2.Text);
            if (currentStep <= Sensor1.Count - 1)
            {
                string[] sonuclar = diyagramSonuclar17[label2.Text];
                if (label2.Text == "Dondurucu sensör bağlantı ve soketleri normal mi?")
                {
                    label2.Text = Sensor1[currentStep + 1];
                }

                label5.Text = sonuclar[0];
            }
        }
        private void Sensor1Restart()
        {
            label2.Text = "Dondurucu sensör bağlantı ve soketleri normal mi?";
            label5.Text = "";
            label6.Text = "";
        }



        // Sensör Kart Hataları FE - 02 

        public List<string> Sensor2 = new List<string>()
        {
            "Soğutucu sensör bağlantı ve soketleri normal mi?",
            "Soğutucu sensörü sağlam mı?",

        };

        public Dictionary<string, string[]> diyagramSonuclar18 = new Dictionary<string, string[]>()
        {
            { "Soğutucu sensör bağlantı ve soketleri normal mi?", new string[] { "", "DÜZELT" } },
            { "Soğutucu sensörü sağlam mı?", new string[] { "Güç kartını değiştir", "Sensörü değiştir" } },

        };


        private void Sensor2No()
        {
            int currentStep = Sensor2.IndexOf(label2.Text);
            if (currentStep >= 0)
            {
                string[] sonuclar = diyagramSonuclar18[label2.Text];



                label5.Text = sonuclar[1];
            }
        }
        private void Sensor2Yes()
        {
            int currentStep = Sensor2.IndexOf(label2.Text);
            if (currentStep <= Sensor2.Count - 1)
            {
                string[] sonuclar = diyagramSonuclar18[label2.Text];
                if (label2.Text == "Soğutucu sensör bağlantı ve soketleri normal mi?")
                {
                    label2.Text = Sensor2[currentStep + 1];
                }

                label5.Text = sonuclar[0];
            }
        }
        private void Sensor2Restart()
        {
            label2.Text = "Soğutucu sensör bağlantı ve soketleri normal mi?";
            label5.Text = "";
            label6.Text = "";
        }


        // Sensör Kart Hataları FE - 03 

        public List<string> Sensor3 = new List<string>()
        {
            "Defrost sensör bağlantı ve soketleri normal mi?",
            "Defrost sensörü sağlam mı?",

        };

        public Dictionary<string, string[]> diyagramSonuclar19 = new Dictionary<string, string[]>()
        {
            { "Defrost sensör bağlantı ve soketleri normal mi?", new string[] { "", "DÜZELT" } },
            { "Defrost sensörü sağlam mı?", new string[] { "Güç kartını değiştir", "Sensörü değiştir" } },

        };


        private void Sensor3No()
        {
            int currentStep = Sensor3.IndexOf(label2.Text);
            if (currentStep >= 0)
            {
                string[] sonuclar = diyagramSonuclar19[label2.Text];



                label5.Text = sonuclar[1];
            }
        }
        private void Sensor3Yes()
        {
            int currentStep = Sensor3.IndexOf(label2.Text);
            if (currentStep <= Sensor3.Count - 1)
            {
                string[] sonuclar = diyagramSonuclar19[label2.Text];
                if (label2.Text == "Defrost sensör bağlantı ve soketleri normal mi?")
                {
                    label2.Text = Sensor3[currentStep + 1];
                }

                label5.Text = sonuclar[0];
            }
        }
        private void Sensor3Restart()
        {
            label2.Text = "Defrost sensör bağlantı ve soketleri normal mi?";
            label5.Text = "";
            label6.Text = "";
        }


        // Sensör Kart Hataları FE - 04 

        public List<string> Sensor4 = new List<string>()
        {
            "Ortam termistöründe soğuk lehim var mı?",

        };

        public Dictionary<string, string[]> diyagramSonuclar20 = new Dictionary<string, string[]>()
        {
            { "Ortam termistöründe soğuk lehim var mı?", new string[] { "Güç kartını değiştirin", "DÜZELT" } },

        };


        private void Sensor4No()
        {
            int currentStep = Sensor4.IndexOf(label2.Text);
            if (currentStep >= 0)
            {
                string[] sonuclar = diyagramSonuclar20[label2.Text];



                label5.Text = sonuclar[1];
            }
        }
        private void Sensor4Yes()
        {
            int currentStep = Sensor4.IndexOf(label2.Text);
            if (currentStep <= Sensor4.Count - 1)
            {
                string[] sonuclar = diyagramSonuclar20[label2.Text];

                label5.Text = sonuclar[0];
            }
        }
        private void Sensor4Restart()
        {
            label2.Text = "Ortam termistöründe soğuk lehim var mı?";
            label5.Text = "";
            label6.Text = "";
        }



        // Sensör Kart Hataları F0 - 05 (Soğutma Yetersiz)

        public List<string> Sensor5 = new List<string>()
        {
            "Kompresör çalışıyor mu?",
            "(*)Sistemde gaz kaçağı var mı?",
            "Ara bölme ve Fin evap rezistanslarını kontrol et",
            "Soğutma gazını boşalt. (**)Sisteme tekrar gaz şarjı yap",
            "Cihaz normale döndümü?",
            "Kompresöre gelen siyah ve mavi uçtaki gerilimi ölçün, voltaj var mı?",
            "Kablo soket bağlantıları normal mi?",
            "Röle-Termik grubu sağlam mı?",
            "(***)Komp. uçları arasındaki omaj normal mi?",
            "Kablo Soket bağlantıları normal mi?",


        };

        public Dictionary<string, string[]> diyagramSonuclar21 = new Dictionary<string, string[]>()
        {
            { "Kompresör çalışıyor mu?", new string[] { "", "" } },
            { "(*)Sistemde gaz kaçağı var mı?", new string[] { "Yağ sızıntısının olduğu yerde gaz kaçağı vardır.Sistemi tamamen boşalt Kaçağı gider.\r\n(**)sisteme tekrar gaz bas.", "" } },
            { "Ara bölme ve Fin evap rezistanslarını kontrol et", new string[] { "", "Ara bölme ve Fin evap rezistanslarını kontrol et" } },
            { "Soğutma gazını boşalt. (**)Sisteme tekrar gaz şarjı yap", new string[] { "", "Soğutma gazını boşalt. (**)Sisteme tekrar gaz şarjı yap." } },
            { "Cihaz normale döndümü?", new string[] { "Gözle görünmeyen iç kısımlarda gaz kaçağı olabilir. Gerekirse gaz kaçak dedektörü \r\nve sabun köpüğü ile kontrol et", "Kompresörü kontrol et gerekirse değiştir." } },
            { "Kompresöre gelen siyah ve mavi uçtaki gerilimi ölçün, voltaj var mı?", new string[] { "", "" } },
            { "Kablo soket bağlantıları normal mi?", new string[] { "", "Bağlantı ve soketleri düzelt." } },
            { "Röle-Termik grubu sağlam mı?", new string[] { "", "Röle termik grubunu değiştir." } },
            { "(***)Komp. uçları arasındaki omaj normal mi?", new string[] { "", "Kompresörü kontrol et gerekirse değiştir." } },
            { "Kablo Soket bağlantıları normal mi?", new string[] { "Güç kartını değiştir", "Bağlantı ve soketleri düzelt." } },



        };


        private void Sensor5No()
        {
            int currentStep = Sensor5.IndexOf(label2.Text);
            if (currentStep >= 0)
            {
                string[] sonuclar = diyagramSonuclar21[label2.Text];

                if (label2.Text == "Kompresör çalışıyor mu?")
                {
                    label2.Text = Sensor5[currentStep + 5];
                    label6.Text = "";
                }

                else if (label2.Text == "Kompresöre gelen siyah ve mavi uçtaki gerilimi ölçün, voltaj var mı?")
                {
                    label2.Text = Sensor5[currentStep + 4];
                    label6.Text = "";
                }

                else if (label2.Text == "(*)Sistemde gaz kaçağı var mı?")
                {
                    label2.Text = Sensor5[currentStep + 1];
                    label6.Text = "";
                }

                else if (label2.Text == "Soğutma gazını boşalt. (**)Sisteme tekrar gaz şarjı yap")
                {
                    label6.Text = "(**)Sisteme gaz şarzı yapmadan önce mutlaka dryeri değiştirip en az 30 dakika vakum yaptıktan sonra, etiket değeri kadar soğutma gazı \r\nşarz yapın.";
                }



                else
                {
                    label6.Text = "";
                }




                label5.Text = sonuclar[1];
            }
        }
        private void Sensor5Yes()
        {
            int currentStep = Sensor5.IndexOf(label2.Text);
            if (currentStep <= Sensor5.Count - 1)
            {
                string[] sonuclar = diyagramSonuclar21[label2.Text];

                if (label2.Text == "Kompresör çalışıyor mu?")
                {
                    label2.Text = Sensor5[currentStep + 1];
                    label6.Text = "(*)Gözle görülebilir tüm boru ve kaynak noktalarında gaz kaçağı olup olmadığını kontrol et.";
                }

                else if (label2.Text == "Ara bölme ve Fin evap rezistanslarını kontrol et")
                {
                    label2.Text = Sensor5[currentStep + 1];
                    label6.Text = "(**)Sisteme gaz şarzı yapmadan önce mutlaka dryeri değiştirip en az 30 dakika vakum yaptıktan sonra, etiket değeri kadar soğutma gazı \r\nşarz yapın.";
                }

                else if (label2.Text == "Soğutma gazını boşalt. (**)Sisteme tekrar gaz şarjı yap")
                {
                    label2.Text = Sensor5[currentStep + 1];
                    label6.Text = "";
                }

                else if (label2.Text == "Kompresöre gelen siyah ve mavi uçtaki gerilimi ölçün, voltaj var mı?")
                {
                    label2.Text = Sensor5[currentStep + 1];
                    label6.Text = "";
                }

                else if (label2.Text == "Kablo soket bağlantıları normal mi?")
                {
                    label2.Text = Sensor5[currentStep + 1];
                    label6.Text = "";
                }

                else if (label2.Text == "Röle-Termik grubu sağlam mı?")
                {
                    label2.Text = Sensor5[currentStep + 1];
                    label6.Text = "(***) Kompresör ana sargı 10Ω yardımcı sargı ise 15Ω civarında olmalıdır. (25C ortam sıcaklığında)";
                }

                else if (label2.Text == "(***)Komp. uçları arasındaki omaj normal mi?")
                {
                    label2.Text = "Kompresöre gelen siyah ve mavi uçtaki gerilimi ölçün, voltaj var mı?";
                    label6.Text = "";
                }

                else if (label2.Text == "(*)Sistemde gaz kaçağı var mı?")
                {
                    label6.Text = "(**)Sisteme gaz şarzı yapmadan önce mutlaka dryeri değiştirip en az 30 dakika vakum yaptıktan sonra, etiket değeri kadar soğutma \r\ngazı şarz yapın.";
                }

                else
                {
                    label6.Text = "";
                }

                label5.Text = sonuclar[0];
            }
        }
        private void Sensor5Restart()
        {
            label2.Text = "Kompresör çalışıyor mu?";
            label5.Text = "";
            label6.Text = "";
        }
        public Form3()
        {
            InitializeComponent();
        }
        public void no_Click(object sender, EventArgs e)
        {
            if (label4.Text == "Sınıf = " + "Statik" && label3.Text == "Arıza = " + "Anormal Gürültü")
            {
                statikGurultuNo();  // Statik Gürültü    
            }
            if (label4.Text == "Sınıf = " + "Statik" && label3.Text == "Arıza = " + "Gaz Akış Sesi")
            {
                statikGazAkisSesiNo();  // Statik Gaz Akış Sesi

            }

            if(label4.Text == "Sınıf = " + "Statik" && label3.Text == "Arıza = " + "Soğutmuyor Ya da Yetersiz Soğutma")
            {
                statikSogutmuyorNo();  // Statik soğutmuyor yada yetersiz soğutma
            }

            if (label4.Text == "Sınıf = " + "Statik" && label3.Text == "Arıza = " + "Aşırı Soğutma")
            {
                statikAsiriSogutmaNo();  // Statik Aşırı Soğutma
            }

            if (label4.Text == "Sınıf = " + "Statik" && label3.Text == "Arıza = " + "Soğutucu Bölümde Top Şeklinde Buzlanma")
            {
                statikBuzlanmaNo();  // Statik Buzlanma
            }

            if (label4.Text == "Sınıf = " + "Statik" && label3.Text == "Arıza = " + "Koku Yapıyor")
            {
                statikKokuNo();  // Statik Koku Yapıyor
            }

            if (label4.Text == "Sınıf = " + "Statik" && label3.Text == "Arıza = " + "Soğutucu kapıda düşme ve sol üst köşede açıklık")
            {
                statikDusmeNo();  // Statik Koku Yapıyor
            }

            if (label4.Text == "Sınıf = " + "MekanikNoFrost" && label3.Text == "Arıza = " + "Anormal Gürültü")
            {

                statikGurultuNo();  // MekanikNoFrost Gürültü    
            }

            if (label4.Text == "Sınıf = " + "MekanikNoFrost" && label3.Text == "Arıza = " + "Soğutmuyor Ya da Yetersiz Soğutma")
            {

                mekanikSogutmuyorNo();  // MekanikNoFrost Soğutmuyor   
            }

            if (label4.Text == "Sınıf = " + "MekanikNoFrost" && label3.Text == "Arıza = " + "Koku Yapıyor")
            {

                statikKokuNo();  // MekanikNoFrost Koku Yapıyor  
            }

            if (label4.Text == "Sınıf = " + "MekanikNoFrost" && label3.Text == "Arıza = " + "Soğutucu kapıda düşme ve sol üst köşede açıklık")
            {

                MekanikDusmeNo();  // MekanikNoFrost Düşme 
            }

            if (label4.Text == "Sınıf = " + "MekanikNoFrost" && label3.Text == "Arıza = " + "Gaz akış sesi")
            {

                mekanikGazNo();  // MekanikNoFrost Gaz Akış Sesi 
            }

            if (label4.Text == "Sınıf = " + "MekanikNoFrost" && label3.Text == "Arıza = " + "Aşırı Soğutma")
            {

                mekanikSogutmaNo();  // MekanikNoFrost Aşırı Soğutma
            }

            if (label4.Text == "Sınıf = " + "MekanikNoFrost" && label3.Text == "Arıza = " + "Ara Bölme Buzlanma")
            {

                mekanikBuzlanmaNo();  // MekanikNoFrost Ara Bölme Buzlanma
            }

            if (label4.Text == "Sınıf = " + "MekanikNoFrost" && label3.Text == "Arıza = " + "Soğutucu hava kanalı ile tavanın birleşim noktasında terleme")
            {

                mekanikTerlemeNo();  // MekanikNoFrost Terleme
            }

            if (label4.Text == "Sınıf = " + "ElektronikNoFrost" && label3.Text == "Arıza = " + "Anormal Gürültü")
            {

                statikGurultuNo();  // Elektronik No Frost Anormal Gürültü 
            }


            if (label4.Text == "Sınıf = " + "ElektronikNoFrost" && label3.Text == "Arıza = " + "Gaz akış sesi ")
            {

                mekanikGazNo();  // Gaz akış sesi
            }

            if (label4.Text == "Sınıf = " + "ElektronikNoFrost" && label3.Text == "Arıza = " + "Soğutmuyor yada Yetersiz Soğutma")
            {

                elektronikSogutmuyorNo();  // Elektronik Soğutmuyor
            }

            if (label4.Text == "Sınıf = " + "ElektronikNoFrost" && label3.Text == "Arıza = " + "Koku")
            {

                statikKokuNo();  // Elektronik Koku
            }

            if (label4.Text == "Sınıf = " + "ElektronikNoFrost" && label3.Text == "Arıza = " + "Soğutucu kapıda düşme ve sol üst köşede açıklık")
            {

                MekanikDusmeNo();  // Elektronik Soğutucu kapıda düşme ve sol üst köşede açıklık
            }

            if (label4.Text == "Sınıf = " + "ElektronikNoFrost" && label3.Text == "Arıza = " + "Aşırı Soğutma")
            {

                elektronikSogutmaNo();  // Elektronik Aşırı Soğutma
            }

            if (label4.Text == "Sınıf = " + "ElektronikNoFrost" && label3.Text == "Arıza = " + "Ara Bölme Buzlanma")
            {

                elektronikBuzlanmaNo();  // Elektronik Ara Bölme Buzlanma
            }

            if (label4.Text == "Sınıf = " + "ElektronikNoFrost" && label3.Text == "Arıza = " + "Soğutucu kısımda yetersiz soğutma")
            {

                elektronikYetersizNo();  // Elektronik Yetersiz Soğutma
            }

            if (label4.Text == "Sınıf = " + "SensorHatalari" && label3.Text == "Arıza = " + "FE 01")
            {

                Sensor1No();  // FE 01 
            }

            if (label4.Text == "Sınıf = " + "SensorHatalari" && label3.Text == "Arıza = " + "FE 02")
            {

                Sensor2No();  // FE 02
            }

            if (label4.Text == "Sınıf = " + "SensorHatalari" && label3.Text == "Arıza = " + "FE 03")
            {

                Sensor3No();  // FE 03 
            }

            if (label4.Text == "Sınıf = " + "SensorHatalari" && label3.Text == "Arıza = " + "FE 04")
            {

                Sensor4No();  // FE 04 
            }

            if (label4.Text == "Sınıf = " + "SensorHatalari" && label3.Text == "Arıza = " + "F0 05 ( Soğutma Yetersiz )")
            {

                Sensor5No();  // F0 05  
            }




        }

        private void homepage_Click(object sender, EventArgs e)
        {
            form1 = new Form1();
            label6.Text = "";
            label5.Text = "";
            label2.Text = "";
            form1.Show();
            this.Hide();
        }

        private void yes_Click(object sender, EventArgs e)
        {

            if (label4.Text == "Sınıf = " + "Statik" && label3.Text == "Arıza = " + "Anormal Gürültü")
            {
                statikGurultuYes();  // Statik Gürültü    
            }

            if (label4.Text == "Sınıf = " + "Statik" && label3.Text == "Arıza = " + "Gaz Akış Sesi")
            {
                statikGazAkisSesiYes();  // Statik Gaz Akış Sesi

            }

            if (label4.Text == "Sınıf = " + "Statik" && label3.Text == "Arıza = " + "Soğutmuyor Ya da Yetersiz Soğutma")
            {
                statikSogutmuyorYes();  // Statik soğutmuyor yada yetersiz soğutma
            }

            if (label4.Text == "Sınıf = " + "Statik" && label3.Text == "Arıza = " + "Aşırı Soğutma")
            {
                statikAsiriSogutmaYes();  // Statik soğutmuyor yada yetersiz soğutma
            }

            if (label4.Text == "Sınıf = " + "Statik" && label3.Text == "Arıza = " + "Soğutucu Bölümde Top Şeklinde Buzlanma")
            {
                statikBuzlanmaYes();  // Statik Buzlanma
            }

            if (label4.Text == "Sınıf = " + "Statik" && label3.Text == "Arıza = " + "Koku Yapıyor")
            {
                statikKokuYes();  // Statik Koku Yapıyor
            }

            if (label4.Text == "Sınıf = " + "Statik" && label3.Text == "Arıza = " + "Soğutucu kapıda düşme ve sol üst köşede açıklık")
            {
                statikDusmeYes();  // Statik soğutucu kapıda düşme ve sol üst köşede açıklık
            }

            if (label4.Text == "Sınıf = " + "MekanikNoFrost" && label3.Text == "Arıza = " + "Anormal Gürültü")
            {
                statikGurultuYes();  // MekanikNoFrost Gürültü    
            }

            if (label4.Text == "Sınıf = " + "MekanikNoFrost" && label3.Text == "Arıza = " + "Soğutmuyor Ya da Yetersiz Soğutma")
            {

                mekanikSogutmuyorYes();  // MekanikNoFrost Soğutmuyor   
            }

            if (label4.Text == "Sınıf = " + "MekanikNoFrost" && label3.Text == "Arıza = " + "Koku Yapıyor")
            {

                statikKokuYes();  // MekanikNoFrost Koku Yapıyor  
            }

            if (label4.Text == "Sınıf = " + "MekanikNoFrost" && label3.Text == "Arıza = " + "Soğutucu kapıda düşme ve sol üst köşede açıklık")
            {

                MekanikDusmeYes();  // MekanikNoFrost Düşme 
            }

            if (label4.Text == "Sınıf = " + "MekanikNoFrost" && label3.Text == "Arıza = " + "Gaz akış sesi")
            {

                mekanikGazYes();  // MekanikNoFrost Gaz Akış Sesi 
            }


            if (label4.Text == "Sınıf = " + "MekanikNoFrost" && label3.Text == "Arıza = " + "Aşırı Soğutma")
            {

                mekanikSogutmaYes();  // MekanikNoFrost Aşırı Soğutma
            }


            if (label4.Text == "Sınıf = " + "MekanikNoFrost" && label3.Text == "Arıza = " + "Ara Bölme Buzlanma")
            {

                mekanikBuzlanmaYes();  // MekanikNoFrost Ara Bölme Buzlanma
            }

            if (label4.Text == "Sınıf = " + "MekanikNoFrost" && label3.Text == "Arıza = " + "Soğutucu hava kanalı ile tavanın birleşim noktasında terleme")
            {

                mekanikTerlemeYes();  // MekanikNoFrost Terleme
            }

            if (label4.Text == "Sınıf = " + "ElektronikNoFrost" && label3.Text == "Arıza = " + "Anormal Gürültü")
            {

                statikGurultuYes();  // Elektronik No Frost Anormal Gürültü 
            }

            if (label4.Text == "Sınıf = " + "ElektronikNoFrost" && label3.Text == "Arıza = " + "Gaz akış sesi ")
            {

                mekanikGazYes();  // Elektronik No Frost Gaz akış sesi
            }

            if (label4.Text == "Sınıf = " + "ElektronikNoFrost" && label3.Text == "Arıza = " + "Soğutmuyor yada Yetersiz Soğutma")
            {

                elektronikSogutmuyorYes();  // Elektronik Soğutmuyor
            }

            if (label4.Text == "Sınıf = " + "ElektronikNoFrost" && label3.Text == "Arıza = " + "Koku")
            {

                statikKokuYes();  // Elektronik Koku
            }

            if (label4.Text == "Sınıf = " + "ElektronikNoFrost" && label3.Text == "Arıza = " + "Soğutucu kapıda düşme ve sol üst köşede açıklık")
            {

                MekanikDusmeYes();  // Elektronik Soğutucu kapıda düşme ve sol üst köşede açıklık
            }

            if (label4.Text == "Sınıf = " + "ElektronikNoFrost" && label3.Text == "Arıza = " + "Aşırı Soğutma")
            {

                elektronikSogutmaYes();  // Elektronik Aşırı Soğutma
            }

            if (label4.Text == "Sınıf = " + "ElektronikNoFrost" && label3.Text == "Arıza = " + "Ara Bölme Buzlanma")
            {

                elektronikBuzlanmaYes();  // Elektronik Ara Bölme Buzlanma
            }

            if (label4.Text == "Sınıf = " + "ElektronikNoFrost" && label3.Text == "Arıza = " + "Soğutucu kısımda yetersiz soğutma")
            {

                elektronikYetersizYes();  // Elektronik Yetersiz Soğutma
            }

            if (label4.Text == "Sınıf = " + "SensorHatalari" && label3.Text == "Arıza = " + "FE 01")
            {

                Sensor1Yes();  // FE 01 
            }

            if (label4.Text == "Sınıf = " + "SensorHatalari" && label3.Text == "Arıza = " + "FE 02")
            {

                Sensor2Yes();  // FE 02
            }

            if (label4.Text == "Sınıf = " + "SensorHatalari" && label3.Text == "Arıza = " + "FE 03")
            {

                Sensor3Yes();  // FE 03
            }

            if (label4.Text == "Sınıf = " + "SensorHatalari" && label3.Text == "Arıza = " + "FE 04")
            {

                Sensor4Yes();  // FE 04
            }

            if (label4.Text == "Sınıf = " + "SensorHatalari" && label3.Text == "Arıza = " + "F0 05 ( Soğutma Yetersiz )")
            {

                Sensor5Yes();  // F0 05  
            }


        }

        private void reset_Click(object sender, EventArgs e)
        {
            if (label4.Text == "Sınıf = " + "Statik" && label3.Text == "Arıza = " + "Anormal Gürültü")
            {
                statikGurultuRestart();   // Statik Gürültü Yenileme
            }

            if (label4.Text == "Sınıf = " + "Statik" && label3.Text == "Arıza = " + "Gaz Akış Sesi")
            {
                statikGazAkisSesiRestart();  // Statik Gaz Akış Sesi Yenileme 

            }

            if (label4.Text == "Sınıf = " + "Statik" && label3.Text == "Arıza = " + "Soğutmuyor Ya da Yetersiz Soğutma")
            {
                statikSogutmuyorRestart();  // Statik soğutmuyor yada yetersiz soğutma
            }

            if (label4.Text == "Sınıf = " + "Statik" && label3.Text == "Arıza = " + "Aşırı Soğutma")
            {
                statikAsiriSogutmaRestart();  // Statik soğutmuyor yada yetersiz soğutma
            }

            if (label4.Text == "Sınıf = " + "Statik" && label3.Text == "Arıza = " + "Soğutucu Bölümde Top Şeklinde Buzlanma")
            {
                statikBuzlanmaRestart();  // Statik Buzlanma
            }

            if (label4.Text == "Sınıf = " + "Statik" && label3.Text == "Arıza = " + "Koku Yapıyor")
            {
                statikKokuRestart();  // Statik Koku Yapıyor
            }

            if (label4.Text == "Sınıf = " + "Statik" && label3.Text == "Arıza = " + "Soğutucu kapıda düşme ve sol üst köşede açıklık")
            {
                statikDusmeRestart();  // Statik soğutucu kapıda düşme ve sol üst köşede açıklık
            }

            if (label4.Text == "Sınıf = " + "MekanikNoFrost" && label3.Text == "Arıza = " + "Soğutmuyor Ya da Yetersiz Soğutma")
            {

                mekanikSogutmuyorRestart();  // MekanikNoFrost Soğutmuyor   
            }

            if (label4.Text == "Sınıf = " + "MekanikNoFrost" && label3.Text == "Arıza = " + "Koku Yapıyor")
            {

                statikKokuRestart();  // MekanikNoFrost Koku Yapıyor  
            }

            if (label4.Text == "Sınıf = " + "MekanikNoFrost" && label3.Text == "Arıza = " + "Soğutucu kapıda düşme ve sol üst köşede açıklık")
            {

                MekanikDusmeRestart();  // MekanikNoFrost Düşme 
            }

            if (label4.Text == "Sınıf = " + "MekanikNoFrost" && label3.Text == "Arıza = " + "Gaz akış sesi")
            {

                mekanikGazRestart();  // MekanikNoFrost Gaz Akış Sesi 
            }


            if (label4.Text == "Sınıf = " + "MekanikNoFrost" && label3.Text == "Arıza = " + "Aşırı Soğutma")
            {

                mekanikSogutmaRestart();  // MekanikNoFrost Aşırı Soğutma
            }


            if (label4.Text == "Sınıf = " + "MekanikNoFrost" && label3.Text == "Arıza = " + "Ara Bölme Buzlanma")
            {

                mekanikBuzlanmaRestart();  // MekanikNoFrost Ara Bölme Buzlanma
            }

            if (label4.Text == "Sınıf = " + "MekanikNoFrost" && label3.Text == "Arıza = " + "Soğutucu hava kanalı ile tavanın birleşim noktasında terleme")
            {

                mekanikTerlemeRestart();  // MekanikNoFrost Terleme
            }

            if (label4.Text == "Sınıf = " + "ElektronikNoFrost" && label3.Text == "Arıza = " + "Anormal Gürültü")
            {

                statikGurultuRestart();  // Elektronik No Frost Anormal Gürültü 
            }

            if (label4.Text == "Sınıf = " + "ElektronikNoFrost" && label3.Text == "Arıza = " + "Gaz akış sesi ")
            {

                mekanikGazRestart();  // Elektronik no Frost Gaz akış sesi 
            }

            if (label4.Text == "Sınıf = " + "ElektronikNoFrost" && label3.Text == "Arıza = " + "Soğutmuyor yada Yetersiz Soğutma")
            {

                elektronikSogutmuyorRestart();  // Elektronik Soğutmuyor
            }

            if (label4.Text == "Sınıf = " + "ElektronikNoFrost" && label3.Text == "Arıza = " + "Koku")
            {

                statikKokuRestart();  // Elektronik Koku
            }

            if (label4.Text == "Sınıf = " + "ElektronikNoFrost" && label3.Text == "Arıza = " + "Soğutucu kapıda düşme ve sol üst köşede açıklık")
            {

                MekanikDusmeRestart();  // Elektronik Soğutucu kapıda düşme ve sol üst köşede açıklık
            }

            if (label4.Text == "Sınıf = " + "ElektronikNoFrost" && label3.Text == "Arıza = " + "Aşırı Soğutma")
            {

                elektronikSogutmaRestart();  // Elektronik Aşırı Soğutma
            }

            if (label4.Text == "Sınıf = " + "ElektronikNoFrost" && label3.Text == "Arıza = " + "Ara Bölme Buzlanma")
            {

                elektronikBuzlanmaRestart();  // Elektronik Ara Bölme Buzlanma
            }

            if (label4.Text == "Sınıf = " + "ElektronikNoFrost" && label3.Text == "Arıza = " + "Soğutucu kısımda yetersiz soğutma")
            {

                elektronikYetersizRestart();  // Elektronik Yetersiz Soğutma
            }

            if (label4.Text == "Sınıf = " + "SensorHatalari" && label3.Text == "Arıza = " + "FE 01")
            {

                Sensor1Restart();  // FE 01
            }

            if (label4.Text == "Sınıf = " + "SensorHatalari" && label3.Text == "Arıza = " + "FE 02")
            {

                Sensor2Restart();  // FE 02
            }

            if (label4.Text == "Sınıf = " + "SensorHatalari" && label3.Text == "Arıza = " + "FE 03")
            {

                Sensor3Restart();  // FE 03
            }

            if (label4.Text == "Sınıf = " + "SensorHatalari" && label3.Text == "Arıza = " + "FE 04")
            {

                Sensor4Restart();  // FE 04
            }

            if (label4.Text == "Sınıf = " + "SensorHatalari" && label3.Text == "Arıza = " + "F0 05 ( Soğutma Yetersiz )")
            {

                Sensor5Restart();  // F0 05  
            }
        }
    }
}
