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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=bilet.accdb");
        DataTable da = new DataTable();
        private void Form6_Load(object sender, EventArgs e)
        {
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From Personel", con);
            adtr.Fill(da);
            CrystalReport4 rapor = new CrystalReport4();
            rapor.SetDataSource(da);
            crystalReportViewer1.ReportSource = rapor;
        }
    }
}
