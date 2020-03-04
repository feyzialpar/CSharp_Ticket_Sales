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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=bilet.accdb");
        DataTable da = new DataTable();
        private void Form5_Load(object sender, EventArgs e)
        {
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From Otobus", con);
            adtr.Fill(da);
            CrystalReport3 rapor = new CrystalReport3();
            rapor.SetDataSource(da);
            crystalReportViewer1.ReportSource = rapor;
        }
    }
}
