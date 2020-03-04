using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections;


namespace CSharp_BiletSatis
{
    public partial class Bilet_Islemleri : Form
    {
        public Bilet_Islemleri()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Bilet.accdb");
        OleDbDataAdapter veriadaptoru = new OleDbDataAdapter();
        OleDbCommand komut = new OleDbCommand();
        DataTable tablo = new DataTable();
        DataSet veriseti = new DataSet();

        OleDbDataReader veriokuyucu;
        
        void GuzergahListele()
        {
            OleDbDataReader veriOku;
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Select Tanim From Guzergah";
            veriOku = komut.ExecuteReader();
            while (veriOku.Read())
            {
                comboBox1.Items.Add(veriOku[0]);
            }
            baglanti.Close();
        }

        void SeferListele()
        {
            OleDbDataReader veriOku;
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Select KalZamani  From Sefer";
            veriOku = komut.ExecuteReader();
            while (veriOku.Read())
            {
                comboBox2.Items.Add(veriOku[0]);
                
            }
            baglanti.Close();
        }

       

        void islemTipi()
        {
            comboBox3.Items.Add("Satış");
        }

         void cinsiyet()
        {
            comboBox5.Items.Add("Bayan");
            comboBox5.Items.Add("Bay");
        }
        
         void listele()
         {
             baglanti.Open();
             OleDbDataAdapter veriadaptoru = new OleDbDataAdapter("Select * from Bilet", baglanti);
             veriadaptoru.Fill(veriseti, "Bilet");
             dataGridView1.DataSource = veriseti.Tables["Bilet"];
             veriadaptoru.Dispose();
             baglanti.Close();
         }

         void koltukkontrol()
         {
             ArrayList koltukno = new ArrayList();
             baglanti.Open();
             komut.Connection = baglanti;
             komut.CommandText = "Select KoltukNo From Bilet Where Guzergah=('" + comboBox1.Text + "') And SeferID=('" + comboBox2.Text + "')";
             veriokuyucu = komut.ExecuteReader();

             while (veriokuyucu.Read())
             {
                 koltukno.Add(veriokuyucu["KoltukNo"]);
             }
             baglanti.Close();

             int a;
             a = koltukno.Count;
             textBox2.Text = a.ToString();

             for (int i = 0; i < a; i++)
             {
                 comboBox4.Items.Remove("" + koltukno[i] + "");

             }
         }

         void koltukrengi()
         {
             ArrayList koltukno = new ArrayList();
             baglanti.Open();
             komut.Connection = baglanti;
             komut.CommandText = "SELECT KoltukNo FROM Bilet WHERE Guzergah=('" + comboBox1.Text + "') AND SeferID=('" + comboBox2.Text + "')";
             veriokuyucu = komut.ExecuteReader();

             while (veriokuyucu.Read())
             {
                 koltukno.Add(veriokuyucu["KoltukNo"]);
             }
             baglanti.Close();

             int a;
             a = koltukno.Count;

             #region Butun Koltuk Renkleri
             for (int i = 2; i < 48; i++)
             {

                 button2.BackColor = Color.Green;
                 button3.BackColor = Color.Green;
                 button5.BackColor = Color.Green;
                 button4.BackColor = Color.Green;
                 button9.BackColor = Color.Green;
                 button8.BackColor = Color.Green;
                 button6.BackColor = Color.Green;
                 button7.BackColor = Color.Green;
                 button13.BackColor = Color.Green;
                 button12.BackColor = Color.Green;
                 button10.BackColor = Color.Green;
                 button11.BackColor = Color.Green;
                 button17.BackColor = Color.Green;
                 button16.BackColor = Color.Green;
                 button14.BackColor = Color.Green;
                 button15.BackColor = Color.Green;
                 button21.BackColor = Color.Green;
                 button20.BackColor = Color.Green;
                 button18.BackColor = Color.Green;
                 button19.BackColor = Color.Green;
                 button25.BackColor = Color.Green;
                 button24.BackColor = Color.Green;
                 button22.BackColor = Color.Green;
                 button23.BackColor = Color.Green;
                 button29.BackColor = Color.Green;
                 button28.BackColor = Color.Green;
                 button31.BackColor = Color.Green;
                 button30.BackColor = Color.Green;
                 button26.BackColor = Color.Green;
                 button27.BackColor = Color.Green;
                 button35.BackColor = Color.Green;
                 button34.BackColor = Color.Green;
                 button32.BackColor = Color.Green;
                 button33.BackColor = Color.Green;
                 button39.BackColor = Color.Green;
                 button38.BackColor = Color.Green;
                 button36.BackColor = Color.Green;
                 button37.BackColor = Color.Green;
                 button43.BackColor = Color.Green;
                 button42.BackColor = Color.Green;
                 button40.BackColor = Color.Green;
                 button41.BackColor = Color.Green;
                 button47.BackColor = Color.Green;
                 button46.BackColor = Color.Green;
                 button44.BackColor = Color.Green;
                 button45.BackColor = Color.Green;
                 

             }
             #endregion

             #region Bayan Koltuk Renk
             ArrayList koltukbayan = new ArrayList();
             baglanti.Open();
             komut.Connection = baglanti;
             komut.CommandText = "Select KoltukNo,YolcuCinsiyet From Bilet Where Guzergah=('" + comboBox1.Text + "') AND SeferID=('" + comboBox2.Text + "') and YolcuCinsiyet IN ('Bayan')";
             veriokuyucu = komut.ExecuteReader();

             while (veriokuyucu.Read())
             {
                 koltukbayan.Add(veriokuyucu["KoltukNo"]);
             }
             baglanti.Close();

             for (int i = 0; i < koltukbayan.Count; i++)
             {
                 int n;
                 n = Convert.ToInt32(koltukbayan[i]);
                 for (int j = 2; j < 48; j++)
                 {
                     if (n == j)
                     {
                         switch (n)
                         {
                             case 1:
                                 button2.BackColor = Color.Pink;
                                 break;
                             case 2:
                                 button3.BackColor = Color.Pink;
                                 break;
                             case 3:
                                 button5.BackColor = Color.Pink;
                                 break;
                             case 4:
                                 button4.BackColor = Color.Pink;
                                 break;
                             case 5:
                                 button9.BackColor = Color.Pink;
                                 break;
                             case 6:
                                 button8.BackColor = Color.Pink;
                                 break;
                             case 7:
                                 button6.BackColor = Color.Pink;
                                 break;
                             case 8:
                                 button7.BackColor = Color.Pink;
                                 break;
                             case 9:
                                 button13.BackColor = Color.Pink;
                                 break;
                             case 10:
                                 button12.BackColor = Color.Pink;
                                 break;
                             case 11:
                                 button10.BackColor = Color.Pink;
                                 break;
                             case 12:
                                 button11.BackColor = Color.Pink;
                                 break;
                             case 13:
                                 button17.BackColor = Color.Pink;
                                 break;
                             case 14:
                                 button16.BackColor = Color.Pink;
                                 break;
                             case 15:
                                 button14.BackColor = Color.Pink;
                                 break;
                             case 16:
                                 button15.BackColor = Color.Pink;
                                 break;
                             case 17:
                                 button21.BackColor = Color.Pink;
                                 break;
                             case 18:
                                 button20.BackColor = Color.Pink;
                                 break;
                             case 19:
                                 button18.BackColor = Color.Pink;
                                 break;
                             case 20:
                                 button19.BackColor = Color.Pink;
                                 break;
                             case 21:
                                 button25.BackColor = Color.Pink;
                                 break;
                             case 22:
                                 button24.BackColor = Color.Pink;
                                 break;
                             case 23:
                                 button22.BackColor = Color.Pink;
                                 break;
                             case 24:
                                 button23.BackColor = Color.Pink;
                                 break;
                             case 25:
                                 button29.BackColor = Color.Pink;
                                 break;
                             case 26:
                                 button28.BackColor = Color.Pink;
                                 break;
                             case 27:
                                 button31.BackColor = Color.Pink;
                                 break;
                             case 28:
                                 button30.BackColor = Color.Pink;
                                 break;
                             case 29:
                                 button26.BackColor = Color.Pink;
                                 break;
                             case 30:
                                 button27.BackColor = Color.Pink;
                                 break;
                             case 31:
                                 button35.BackColor = Color.Pink;
                                 break;
                             case 32:
                                 button34.BackColor = Color.Pink;
                                 break;
                             case 33:
                                 button32.BackColor = Color.Pink;
                                 break;
                             case 34:
                                 button33.BackColor = Color.Pink;
                                 break;
                             case 35:
                                 button39.BackColor = Color.Pink;
                                 break;
                             case 36:
                                 button38.BackColor = Color.Pink;
                                 break;
                             case 37:
                                 button36.BackColor = Color.Pink;
                                 break;
                             case 38:
                                 button37.BackColor = Color.Pink;
                                 break;
                             case 39:
                                 button43.BackColor = Color.Pink;
                                 break;
                             case 40:
                                 button42.BackColor = Color.Pink;
                                 break;
                             case 41:
                                 button40.BackColor = Color.Pink;
                                 break;
                             case 42:
                                 button41.BackColor = Color.Pink;
                                 break;
                             case 43:
                                 button47.BackColor = Color.Pink;
                                 break;
                             case 44:
                                 button46.BackColor = Color.Pink;
                                 break;
                             case 45:
                                 button44.BackColor = Color.Pink;
                                 break;
                             case 46:
                                 button45.BackColor = Color.Pink;
                                 break;
                         }
                     }
                 }
             }
             #endregion

             #region Bay Koltuk Kısmı
             ArrayList koltukbay = new ArrayList();
             baglanti.Open();
             komut.Connection = baglanti;
             komut.CommandText = "Select KoltukNo,YolcuCinsiyet From Bilet Where Guzergah=('" + comboBox1.Text + "') AND SeferID=('" + comboBox2.Text + "') AND YolcuCinsiyet IN ('Bay')";
             veriokuyucu = komut.ExecuteReader();

             while (veriokuyucu.Read())
             {
                 koltukbay.Add(veriokuyucu["KoltukNo"]);
             }
             baglanti.Close();

             for (int i = 0; i < koltukbay.Count; i++)
             {
                 int n;
                 n = Convert.ToInt32(koltukbay[i]);
                 for (int j = 2; j < 48; j++)
                 {
                     if (n == j)
                     {
                         switch (n)
                         {
                             case 1:
                                 button2.BackColor = Color.Blue;
                                 break;
                             case 2:
                                 button3.BackColor = Color.Blue;
                                 break;
                             case 3:
                                 button5.BackColor = Color.Blue;
                                 break;
                             case 4:
                                 button4.BackColor = Color.Blue;
                                 break;
                             case 5:
                                 button9.BackColor = Color.Blue;
                                 break;
                             case 6:
                                 button8.BackColor = Color.Blue;
                                 break;
                             case 7:
                                 button6.BackColor = Color.Blue;
                                 break;
                             case 8:
                                 button7.BackColor = Color.Blue;
                                 break;
                             case 9:
                                 button13.BackColor = Color.Blue;
                                 break;
                             case 10:
                                 button12.BackColor = Color.Blue;
                                 break;
                             case 11:
                                 button10.BackColor = Color.Blue;
                                 break;
                             case 12:
                                 button11.BackColor = Color.Blue;
                                 break;
                             case 13:
                                 button17.BackColor = Color.Blue;
                                 break;
                             case 14:
                                 button16.BackColor = Color.Blue;
                                 break;
                             case 15:
                                 button14.BackColor = Color.Blue;
                                 break;
                             case 16:
                                 button15.BackColor = Color.Blue;
                                 break;
                             case 17:
                                 button21.BackColor = Color.Blue;
                                 break;
                             case 18:
                                 button20.BackColor = Color.Blue;
                                 break;
                             case 19:
                                 button18.BackColor = Color.Blue;
                                 break;
                             case 20:
                                 button19.BackColor = Color.Blue;
                                 break;
                             case 21:
                                 button25.BackColor = Color.Blue;
                                 break;
                             case 22:
                                 button24.BackColor = Color.Blue;
                                 break;
                             case 23:
                                 button22.BackColor = Color.Blue;
                                 break;
                             case 24:
                                 button23.BackColor = Color.Blue;
                                 break;
                             case 25:
                                 button29.BackColor = Color.Blue;
                                 break;
                             case 26:
                                 button28.BackColor = Color.Blue;
                                 break;
                             case 27:
                                 button31.BackColor = Color.Blue;
                                 break;
                             case 28:
                                 button30.BackColor = Color.Blue;
                                 break;
                             case 29:
                                 button26.BackColor = Color.Blue;
                                 break;
                             case 30:
                                 button27.BackColor = Color.Blue;
                                 break;
                             case 31:
                                 button35.BackColor = Color.Blue;
                                 break;
                             case 32:
                                 button34.BackColor = Color.Blue;
                                 break;
                             case 33:
                                 button32.BackColor = Color.Blue;
                                 break;
                             case 34:
                                 button33.BackColor = Color.Blue;
                                 break;
                             case 35:
                                 button39.BackColor = Color.Blue;
                                 break;
                             case 36:
                                 button38.BackColor = Color.Blue;
                                 break;
                             case 37:
                                 button36.BackColor = Color.Blue;
                                 break;
                             case 38:
                                 button37.BackColor = Color.Blue;
                                 break;
                             case 39:
                                 button43.BackColor = Color.Blue;
                                 break;
                             case 40:
                                 button42.BackColor = Color.Blue;
                                 break;
                             case 41:
                                 button40.BackColor = Color.Blue;
                                 break;
                             case 42:
                                 button41.BackColor = Color.Blue;
                                 break;
                             case 43:
                                 button47.BackColor = Color.Blue;
                                 break;
                             case 44:
                                 button46.BackColor = Color.Blue;
                                 break;
                             case 45:
                                 button44.BackColor = Color.Blue;
                                 break;
                             case 46:
                                 button45.BackColor = Color.Blue;
                                 break;
                         }
                     }
                 }
             }
             #endregion
         }

        private void Bilet_Islemleri_Load(object sender, EventArgs e)
        {
            GuzergahListele();
            islemTipi();
            SeferListele();
            cinsiyet();
            comboBox2.Enabled = false;
            listele();
        }//listelemeler


        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            koltukkontrol();
            koltukrengi();
            //textBox2.Text = "";
            veriseti.Clear();
            baglanti.Open();
            OleDbDataAdapter veriadaptoru = new OleDbDataAdapter("Select * FROM Bilet Where Guzergah=('" + comboBox1.Text + "') and SeferID=('" + comboBox2.Text + "')", baglanti);
            veriadaptoru.Fill(veriseti, "Bilet");
            dataGridView1.DataSource = veriseti.Tables["Bilet"];
            veriadaptoru.Dispose();
            baglanti.Close();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
           comboBox2.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && comboBox4.Text != "" && textBox3.Text != "" && comboBox5.Text != "" && textBox2.Text != "")
            {
                komut.Connection = baglanti;
                komut.CommandText = "insert into Bilet(SeferID,SatisRezervasyon,KoltukNo,YolcuCinsiyet,YolcuAd,Ucret,Guzergah) values ('" + comboBox2.Text + "','" + comboBox3.Text + "','" + comboBox4.Text + "','" + textBox3.Text + "','" + comboBox5.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "')";
                baglanti.Open();
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
                MessageBox.Show("Bilet  Satışı Yapıldı.");
                veriseti.Clear();
                listele();
                koltukrengi();
            }
        }//kaydet butonu

        private void button48_Click(object sender, EventArgs e)//temizleme butonu
        {
            try
            {
                DialogResult cevap;
                cevap = MessageBox.Show("İptal Etmek İstiyor Musunuz?", "Bilet Onayı", MessageBoxButtons.YesNo);
                if (cevap == DialogResult.Yes)
                {
                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.CommandText = "Delete From Bilet Where ID=" + dataGridView1.CurrentRow.Cells[0].Value;
                    komut.ExecuteNonQuery();
                    tablo.Clear();
                    OleDbDataAdapter adptr = new OleDbDataAdapter("Select * From Bilet", baglanti);
                    adptr.Fill(tablo);
                    dataGridView1.DataSource = tablo;
                    baglanti.Close();

                    MessageBox.Show("İptal edildi.");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("İptal Edilemedi.");
            } 
        }

        private void button50_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            textBox3.Text = "";
            comboBox5.Text = "";
            textBox2.Text = "";
        }

        private void button51_Click(object sender, EventArgs e)
        {
            komut = new OleDbCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Update Bilet set SeferID='" + comboBox1.Text + "',SatisRezervasyon='" + comboBox2.Text + "', KoltukNo ='" + comboBox3.Text + "', YolcuCinsiyet ='" + comboBox5.Text + "', YolcuAd ='" + textBox3.Text + "', Ucret ='" + textBox2.Text + "', Guzergah ='" + comboBox1.Text + "' where ID=" + Int32.Parse(textBox1.Text);
            komut.ExecuteNonQuery();
            tablo.Clear();
            OleDbDataAdapter adptr = new OleDbDataAdapter("Select * From Bilet", baglanti);
            adptr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            comboBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void button49_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.ShowDialog();
        }
    }
}
