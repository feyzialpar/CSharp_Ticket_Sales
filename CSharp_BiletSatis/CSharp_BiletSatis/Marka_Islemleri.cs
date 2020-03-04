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
    public partial class Guzergah_Islemleri : Form
    {
        public Guzergah_Islemleri()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Bilet.accdb");
        DataTable tablo = new DataTable();
        OleDbCommand komut = new OleDbCommand();
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "INSERT INTO Guzergah(KalkisSehir,VarisSehir,Tanim) VALUES('" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox2.Text + "')";
                komut.ExecuteNonQuery();
                tablo.Clear();
                OleDbDataAdapter adptr = new OleDbDataAdapter("Select * From Guzergah", baglanti);
                adptr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                baglanti.Close();
                MessageBox.Show("Kayıt eklendi.");
            }

            catch (Exception)
            {
                MessageBox.Show("Hata!");
                baglanti.Close();
            }
        }

        private void Marka_Islemleri_Load(object sender, EventArgs e)
        {
            tablo.Clear();
            OleDbDataAdapter adptr = new OleDbDataAdapter("Select * from Guzergah", baglanti);
            adptr.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult cevap;
                cevap = MessageBox.Show("Kaydı silmek istiyor musun?", "Bildirim", MessageBoxButtons.YesNo);
                if (cevap == DialogResult.Yes)
                {
                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.CommandText = "Delete From Guzergah Where ID=" + dataGridView1.CurrentRow.Cells[0].Value;
                    komut.ExecuteNonQuery();
                    tablo.Clear();
                    OleDbDataAdapter adptr = new OleDbDataAdapter("Select * From Guzergah", baglanti);
                    adptr.Fill(tablo);
                    dataGridView1.DataSource = tablo;
                    baglanti.Close();

                    MessageBox.Show("Kayıt silindi.");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Kayıt silinemedi.");
            } 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            komut = new OleDbCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Update Guzergah set KalkisSehir='" + comboBox1.Text + "',VarisSehir='" + comboBox2.Text + "', Tanim ='" + textBox2.Text + "' where ID=" + Int32.Parse(textBox1.Text);
            komut.ExecuteNonQuery();
            tablo.Clear();
            OleDbDataAdapter adptr = new OleDbDataAdapter("Select * From Guzergah", baglanti);
            adptr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox2.Text = "";
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = comboBox1.Text + " - " + comboBox2.Text;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.ShowDialog();
        }
    }
}
