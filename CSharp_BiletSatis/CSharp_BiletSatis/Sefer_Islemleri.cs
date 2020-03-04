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

namespace CSharp_BiletSatis
{
    public partial class Sefer_Islemleri : Form
    {
        public Sefer_Islemleri()
        {
            InitializeComponent();
        }


        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Bilet.accdb");
        DataTable tablo = new DataTable();
        OleDbCommand komut = new OleDbCommand();
        DataSet veriseti = new DataSet();


        void cmbGuzergahListele()
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

        void cmbOtobusListele()
        {
            OleDbDataReader veriOku;
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Select Plaka From Otobus";
            veriOku = komut.ExecuteReader();
            while (veriOku.Read())
            {
                comboBox2.Items.Add(veriOku[0]);
            }
            baglanti.Close();
        }
        void cmbSoforListele()
        {
            OleDbDataReader veriOku;
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT AdSoyad FROM Personel WHERE Gorevi IN ('Şoför')";
            veriOku = komut.ExecuteReader();
            while (veriOku.Read())
            {
                comboBox4.Items.Add(veriOku[0]);
            }
            baglanti.Close();
        }
        void cmbMuavinListele()
        {
            OleDbDataReader veriOku;
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT AdSoyad FROM Personel WHERE Gorevi IN ('Muavin')";
            veriOku = komut.ExecuteReader();
            while (veriOku.Read())
            {
                comboBox3.Items.Add(veriOku[0]);
            }
            baglanti.Close();
        }
        void listele()
        {
            baglanti.Open();
            OleDbDataAdapter veriadaptoru = new OleDbDataAdapter("Select * from Sefer", baglanti);
            veriadaptoru.Fill(veriseti, "Sefer");
            dataGridView1.DataSource = veriseti.Tables["Sefer"];
            veriadaptoru.Dispose();
            baglanti.Close();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            string veri = comboBox1.Text;
            string[] parcalanmis_veri = veri.Split("-".ToCharArray());

            textBox1.Text = parcalanmis_veri[0];
            textBox2.Text = parcalanmis_veri[1];
        }

        private void Sefer_Islemleri_Load(object sender, EventArgs e)
        {
            cmbGuzergahListele();
            cmbOtobusListele();
            cmbSoforListele();
            cmbMuavinListele();
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            comboBox4.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
         
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Close();
            if (comboBox1.Text != "" && textBox1.Text != "" && textBox2.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && comboBox4.Text != "" && dateTimePicker1.Text != "" && dateTimePicker2.Text != "" && textBox3.Text!= "" && textBox4.Text != "")
            {
                komut.Connection = baglanti;
                komut.CommandText = "Insert Into Sefer(KalSehirID,VarSehirID,OtobusID,MuavinID,SoforID,KalZamani,VarZamani,TahminiSure,BilTutar) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + comboBox4.Text+ "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + textBox3.Text + "','" + textBox4.Text+ "')";
                baglanti.Open();
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
                MessageBox.Show("Kayıt Başarıyla Tamamlandı!");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult cevap;
                cevap = MessageBox.Show("İptal Etmek İstiyor Musunuz?", "Sefer Onayı", MessageBoxButtons.YesNo);
                if (cevap == DialogResult.Yes)
                {
                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.CommandText = "Delete From Sefer Where ID=" + dataGridView1.CurrentRow.Cells[0].Value;
                    komut.ExecuteNonQuery();
                    tablo.Clear();
                    OleDbDataAdapter adptr = new OleDbDataAdapter("Select * From Sefer", baglanti);
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

        private void button5_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            komut = new OleDbCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Update Sefer set KalSehirID='" + textBox1.Text + "',VarSehirID='" + textBox2.Text + "', OtobusID ='" + comboBox2.Text + "', MuavinID='" + comboBox3.Text + "',SoforID='" + comboBox4.Text + "',KalZamani='" + dateTimePicker1.Text + "',VarZamani='" + dateTimePicker2.Text + "',TahminiSure='" + textBox3.Text + "',BilTutar='" + textBox4.Text + "' where ID=" + Int32.Parse(textBox5.Text);
            komut.ExecuteNonQuery();
            tablo.Clear();
            OleDbDataAdapter adptr = new OleDbDataAdapter("Select * From Sefer", baglanti);
            adptr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 frm7 = new Form7();
            frm7.ShowDialog();
        }
    }
}
