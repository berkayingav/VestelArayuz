using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {

        int secilenIndex;
        private Form3 form3; // Form2 referansı


        public Form1()
        {
            InitializeComponent();
            progressBar1.Maximum = 100;
            progressBar1.Minimum = 0;

            // Timer'ın Interval değerini 2000 (2 saniye) olarak ayarlayın
            timer1.Interval = 20;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void mobilyasinifi_SelectedIndexChanged(object sender, EventArgs e)
        {
            secilenIndex = mobilyasinifi.SelectedIndex; // Seçilen öğenin index'ini al
            ekleArızaSecenekleri(secilenIndex);
 

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ekleArızaSecenekleri(int secilenIndex)
        {
            switch (secilenIndex)
            {
                case 0: // Statik seçilmişse
                        // Statik'e özgü arıza seçeneklerini combobox3'e ekleyin
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("Anormal Gürültü");
                    comboBox3.Items.Add("Gaz Akış Sesi");
                    comboBox3.Items.Add("Soğutmuyor Ya da Yetersiz Soğutma");
                    comboBox3.Items.Add("Aşırı Soğutma");
                    comboBox3.Items.Add("Soğutucu Bölümde Top Şeklinde Buzlanma");
                    comboBox3.Items.Add("Koku Yapıyor");
                    comboBox3.Items.Add("Soğutucu kapıda düşme ve sol üst köşede açıklık");
                    // ...
                    break;

                case 1: // MekanikNoFrost seçilmişse
                        // MekanikNoFrost'a özgü arıza seçeneklerini combobox3'e ekleyin
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("Anormal Gürültü");
                    comboBox3.Items.Add("Soğutmuyor Ya da Yetersiz Soğutma");
                    comboBox3.Items.Add("Koku Yapıyor");
                    comboBox3.Items.Add("Soğutucu kapıda düşme ve sol üst köşede açıklık");
                    comboBox3.Items.Add("Gaz akış sesi");
                    comboBox3.Items.Add("Aşırı Soğutma");
                    comboBox3.Items.Add("Ara Bölme Buzlanma");
                    comboBox3.Items.Add("Soğutucu hava kanalı ile tavanın birleşim noktasında terleme");
                    // ...
                    break;

                // ... Diğer seçenekler için kod ekleyin ...
                case 2: // ElektronikNoFrost seçilmişse
                        // ElektronikNoFrost'a özgü arıza seçeneklerini combobox3'e ekleyin
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("Anormal Gürültü");
                    comboBox3.Items.Add("Gaz akış sesi ");
                    comboBox3.Items.Add("Soğutmuyor yada Yetersiz Soğutma");
                    comboBox3.Items.Add("Koku");
                    comboBox3.Items.Add("Soğutucu kapıda düşme ve sol üst köşede açıklık");
                    comboBox3.Items.Add("Aşırı Soğutma");
                    comboBox3.Items.Add("Ara Bölme Buzlanma");
                    comboBox3.Items.Add("Soğutucu kısımda yetersiz soğutma");
                    // ...
                    break;

                case 3: // Sensör Kart Hataları seçilmişse
                        // Sensört Kart Hatalarına özgü arıza seçeneklerini combobox3'e ekleyin
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("FE 01");
                    comboBox3.Items.Add("FE 02");
                    comboBox3.Items.Add("FE 03");
                    comboBox3.Items.Add("FE 04");
                    comboBox3.Items.Add("F0 05 ( Soğutma Yetersiz )");

                    // ...
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form3 = new Form3();

            if (comboBox3.SelectedIndex == -1) // Seçilen öğe yok
            {
                MessageBox.Show("Lütfen Arıza Seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Hata mesajı gösterildikten sonra metoddan çıkın
            }

            else if (mobilyasinifi.SelectedIndex == -1) // Seçilen öğe yok
            {
                MessageBox.Show("Lütfen Mobilya Sınıfı Seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Hata mesajı gösterildikten sonra metoddan çıkın
            }

            else if (comboBox1.SelectedIndex == -1) // Seçilen öğe yok
            {
                MessageBox.Show("Lütfen Mobilya Seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Hata mesajı gösterildikten sonra metoddan çıkın
            }

            else
            {
                timer1.Start();


            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value++;

            // ProgressBar'nın Value değeri Maximum değerine ulaştığında Timer'ı durdurun
            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Stop();
                string secilenMobilya = mobilyasinifi.SelectedItem.ToString();
                string secilenArıza = comboBox3.SelectedItem.ToString();
                string mobilyaTürü = comboBox1.SelectedItem.ToString();
                form3.Show();
                form3.label1.Text = "Mobilya = " + mobilyaTürü;
                form3.label4.Text = "Sınıf = " + secilenMobilya;
                form3.label3.Text = "Arıza = " + secilenArıza;
                form3.label6.Text = "";
                form3.label5.Text = "";
                if(mobilyasinifi.SelectedIndex == 0 && comboBox3.SelectedIndex == 0)
                {
                    form3.label2.Text = form3.statikAnormalGurultu[0];

                }
                if(mobilyasinifi.SelectedIndex == 0 && comboBox3.SelectedIndex == 1)
                {
                    form3.label2.Text = form3.statikGazAkisSesi[0];
                }
                if(mobilyasinifi.SelectedIndex == 0 && comboBox3.SelectedIndex == 2)
                {
                    form3.label2.Text = form3.statikSogutmuyor[0];
                }
                if (mobilyasinifi.SelectedIndex == 0 && comboBox3.SelectedIndex == 3)
                {
                    form3.label2.Text = form3.statikAsiriSogutma[0];
                }
                if (mobilyasinifi.SelectedIndex == 0 && comboBox3.SelectedIndex == 4)
                {
                    form3.label2.Text = form3.statikBuzlanma[0];
                }
                if (mobilyasinifi.SelectedIndex == 0 && comboBox3.SelectedIndex == 5)
                {
                    form3.label2.Text = form3.statikKoku[0];
                }
                if (mobilyasinifi.SelectedIndex == 0 && comboBox3.SelectedIndex == 6)
                {
                    form3.label2.Text = form3.statikDusme[0];
                }


                //Mekanik No Frost

                if (mobilyasinifi.SelectedIndex == 1 && comboBox3.SelectedIndex == 0)
                {
                    form3.label2.Text = form3.statikAnormalGurultu[0];
                }

                if (mobilyasinifi.SelectedIndex == 1 && comboBox3.SelectedIndex == 1)
                {
                    form3.label2.Text = form3.mekanikSogutmuyor[0];
                }

                if (mobilyasinifi.SelectedIndex == 1 && comboBox3.SelectedIndex == 2)
                {
                    form3.label2.Text = form3.statikKoku[0];
                }

                if (mobilyasinifi.SelectedIndex == 1 && comboBox3.SelectedIndex == 3)
                {
                    form3.label2.Text = form3.MekanikDusme[0];
                }

                if (mobilyasinifi.SelectedIndex == 1 && comboBox3.SelectedIndex == 4)
                {
                    form3.label2.Text = form3.mekanikGaz[0];
                }

                if (mobilyasinifi.SelectedIndex == 1 && comboBox3.SelectedIndex == 5)
                {
                    form3.label2.Text = form3.mekanikSogutma[0];
                }

                if (mobilyasinifi.SelectedIndex == 1 && comboBox3.SelectedIndex == 6)
                {
                    form3.label2.Text = form3.mekanikBuzlanma[0];
                }

                if (mobilyasinifi.SelectedIndex == 1 && comboBox3.SelectedIndex == 7)
                {
                    form3.label2.Text = form3.mekanikTerleme[0];
                }


                //Elektronik No Frost

                if (mobilyasinifi.SelectedIndex == 2 && comboBox3.SelectedIndex == 0)
                {
                    form3.label2.Text = form3.statikAnormalGurultu[0];
                }

                if (mobilyasinifi.SelectedIndex == 2 && comboBox3.SelectedIndex == 1)
                {
                    form3.label2.Text = form3.mekanikGaz[0];
                }

                if (mobilyasinifi.SelectedIndex == 2 && comboBox3.SelectedIndex == 2)
                {
                    form3.label2.Text = form3.elektronikSogutmuyor[0];
                }

                if (mobilyasinifi.SelectedIndex == 2 && comboBox3.SelectedIndex == 3)
                {
                    form3.label2.Text = form3.statikKoku[0];
                }

                if (mobilyasinifi.SelectedIndex == 2 && comboBox3.SelectedIndex == 4)
                {
                    form3.label2.Text = form3.MekanikDusme[0];
                }

                if (mobilyasinifi.SelectedIndex == 2 && comboBox3.SelectedIndex == 5)
                {
                    form3.label2.Text = form3.elektronikSogutma[0];
                }

                if (mobilyasinifi.SelectedIndex == 2 && comboBox3.SelectedIndex == 6)
                {
                    form3.label2.Text = form3.elektronikBuzlanma[0];
                }

                if (mobilyasinifi.SelectedIndex == 2 && comboBox3.SelectedIndex == 7)
                {
                    form3.label2.Text = form3.elektronikYetersiz[0];
                }

                // Sensör - Kat Hataları

                if (mobilyasinifi.SelectedIndex == 3 && comboBox3.SelectedIndex == 0)
                {
                    form3.label2.Text = form3.Sensor1[0];
                }

                if (mobilyasinifi.SelectedIndex == 3 && comboBox3.SelectedIndex == 1)
                {
                    form3.label2.Text = form3.Sensor2[0];
                }

                if (mobilyasinifi.SelectedIndex == 3 && comboBox3.SelectedIndex == 2)
                {
                    form3.label2.Text = form3.Sensor3[0];
                }

                if (mobilyasinifi.SelectedIndex == 3 && comboBox3.SelectedIndex == 3)
                {
                    form3.label2.Text = form3.Sensor4[0];
                }

                if (mobilyasinifi.SelectedIndex == 3 && comboBox3.SelectedIndex == 4)
                {
                    form3.label2.Text = form3.Sensor5[0];
                }




                this.Hide();
            }
        }
    }

    

}
