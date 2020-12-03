using _018101128_018101015.BUS;
using _018101128_018101015.DAO;
using _018101128_018101015.DTO;
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
    public partial class frmHoaDon : Form
    {
        public frmHoaDon()
        {
            InitializeComponent();
        }

       
       public void Load_Datagridview()
        {
            DataTable dt = new DataTable();
            dt = SpDAO.TT_Datagridview(txtsohd.Text);
            dataGridView1.DataSource = dt;
        }
        public void Load_Datagridview1()
        {
            DataTable dt = new DataTable();
            dt = SpDAO.TT_Datagridview1();
            dataGridView1.DataSource = dt;
        }

        public void Load_CbSP()
        {

            DataTable dt = new DataTable();
            dt = SpDAO.TT_CBSP();
            cbbSp.DataSource = dt;
            cbbSp.DisplayMember = "tensp";
            cbbSp.ValueMember = "masp";
        }
        public void Load_Cbkh()
        {
            DataTable dt = new DataTable();
            dt = SpDAO.TT_CBKH();
            cbmakh.DataSource = dt;
            cbmakh.DisplayMember = "tenkh";
            cbmakh.ValueMember = "makh";
        }
        public void Load_Cbnv()
        {
            DataTable dt = new DataTable();
            dt = SpDAO.TT_CBNV();
            cbmanv.DataSource = dt;
            cbmanv.DisplayMember = "tennv";
            cbmanv.ValueMember = "manv";
        }
        public void Load_Cbtk()
        {
            DataTable dt = new DataTable();
            dt = SpDAO.TT_CBTK();
            cbbsohd.DataSource = dt;
            cbbsohd.DisplayMember = "sohd";
            cbbsohd.ValueMember = "sohd";
        }
        private void frmHoaDon_Load(object sender, EventArgs e)
        {
         
            Load_CbSP();
            Load_Cbnv();
            Load_Cbkh();
            Load_Cbtk();
            if (txtsohd.Text != "")
            {
                Load_CTHD();
                btnxoa.Enabled = true;
                btnin.Enabled = true;
            }
            Load_Datagridview();
            Load_Datagridview1();
        }
        public void Load_CTHD()
        {   DataTable dt = new DataTable();
            dt = SpDAO.TT_CTHD(txtsohd.Text);
            dateTimePicker1.Text = dt.Rows[0]["ngayhd"].ToString();
            cbmakh.Text= dt.Rows[0]["tenkh"].ToString();
            cbmanv.Text= dt.Rows[0]["tennv"].ToString();
          }
        private void button1_Click(object sender, EventArgs e)
        {
            if (cbbsohd.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbsohd.Focus();
                return;
            }
          
            txtsohd.Text = cbbsohd.Text;
            Load_CTHD();
            Load_Datagridview();
            btnxoa.Enabled = true;
            btnghi.Enabled = true;
            btnin.Enabled = true;
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txttensp.Text = dataGridView1.Rows[e.RowIndex].Cells["tensp"].FormattedValue.ToString();
            cbbSp.Text= dataGridView1.Rows[e.RowIndex].Cells["MaSP"].FormattedValue.ToString();
            txtdongia.Text= dataGridView1.Rows[e.RowIndex].Cells["Gia"].FormattedValue.ToString();
            txtthanhtien.Text= dataGridView1.Rows[e.RowIndex].Cells["ThanhTien"].FormattedValue.ToString();
            txtsl.Text= dataGridView1.Rows[e.RowIndex].Cells["SoLuong"].FormattedValue.ToString();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = SpDAO.getSohd();
            int sohd = Convert.ToInt32(dt.Rows[0]["sohd"].ToString().Substring(2)) + 1;
            txtsohd.Text = "HD" + string.Format("{0:000}", sohd);
            cbbSp.Text = cbmakh.Text = cbmanv.Text = txtdongia.Text = txttensp.Text =txtthanhtien.Text =txtsl.Text="";
            txtdongia.ReadOnly = true;
        }
       private void btnghi_Click(object sender, EventArgs e)
        {
            SpDTO s = new SpDTO();
            s.sohd = txtsohd.Text;
            s.ngayhd = string.Format("{0:MM/dd/yyyy}", dateTimePicker1.Value);
            s.makh = cbmakh.SelectedValue.ToString();
            s.manv = cbmanv.SelectedValue.ToString();
           // s.trigia = txtthanhtien.Text;
        
             s.trigia =dataGridView1.Rows[0].Cells["ThanhTien"].Value.ToString();
            //dataGridView1.Rows[0].Cells["ThanhTien"].Value.ToString();
            s.masp = cbbSp.SelectedValue.ToString();
            s.soluong =txtsl.Text;
            SpDAO.ThemHD(s);
            Load_Cbtk();
        }

        private void btncapnhat_Click(object sender, EventArgs e)
        {
            SpDTO s = new SpDTO();
            s.sohd = txtsohd.Text;
            s.ngayhd = string.Format("{0:MM/dd/yyyy}", dateTimePicker1.Value);
            s.makh = cbmakh.SelectedValue.ToString();
            s.manv = cbmanv.SelectedValue.ToString();
            DataTable dt = new DataTable();
            s.trigia = dataGridView1.Rows[0].Cells["ThanhTien"].Value.ToString();
            s.masp = cbbSp.SelectedValue.ToString();
            s.soluong = txtsl.Text;
            SpDAO.CapnhatHD(s);
            Load_Cbtk();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            SpDTO s = new SpDTO();
            s.sohd = txtsohd.Text;
            s.masp = cbbSp.Text;
            SpBUS.Xoa(s);
            Load_Cbtk();
           
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnin_Click(object sender, EventArgs e)
        {
            if (cbmakh.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Bạn phải chọn một khách hàng để IN", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                SpDAO.makhachhang = cbmakh.SelectedValue.ToString();
                FrmReportcs f = new FrmReportcs();
                f.Show();
            }
        }
    }
}
