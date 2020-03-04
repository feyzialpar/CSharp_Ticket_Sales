using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_BiletSatis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Guzergah_Islemleri Guzergah_Islemleri = new Guzergah_Islemleri();
            Guzergah_Islemleri.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Personel_Islemleri Personel_Islemleri = new Personel_Islemleri();
            Personel_Islemleri.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bilet_Islemleri Bilet_Islemleri = new Bilet_Islemleri();
            Bilet_Islemleri.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Otobus_Islemleri Otobus_Islemleri = new Otobus_Islemleri();
            Otobus_Islemleri.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sefer_Islemleri Sefer_Islemleri = new Sefer_Islemleri();
            Sefer_Islemleri.Show();
        }
    }
}
