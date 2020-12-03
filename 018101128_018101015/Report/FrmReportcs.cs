using _018101128_018101015.DAO;
using _018101128_018101015.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _018101128_018101015
{
    public partial class FrmReportcs : Form
    {
        public FrmReportcs()
        {
            InitializeComponent();
        }

        private void FrmReportcs_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = SpDAO.TT_Datagridview1(SpDAO.makhachhang);
            CrystalReport2 cry = new CrystalReport2();
            cry.SetDataSource(dt);
            crystalReportViewer1.ReportSource = cry;
        }
    }
}
