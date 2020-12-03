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
    public partial class frmSanPham : Form
    {
        public frmSanPham()
        {
            InitializeComponent();
        }

        private void txtsize_TextChanged(object sender, EventArgs e)
        {

        }
        public void Load_listbox()
        {
            DataTable dt = new DataTable();
            dt = SpDAO.Load_Listbox();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listBox1.Items.Add(dt.Rows[i]["TenSP"].ToString());
            }
        }
    /*    public void Load_cbbsp()
        {
            DataTable dt = new DataTable();
            dt = SpDAO.Load_Listbox();
            cbbmasp.DataSource = dt;
            cbbmasp.DisplayMember = "MaSP";
            cbbmasp.ValueMember = "MaSP";
        }*/
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            Load_listbox();
            //Load_cbbsp();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = SpDAO.Load_Listbox();
            for(int i=0;i<dt.Rows.Count;i++)
            {
                if(listBox1.SelectedItem.ToString() == dt.Rows[i]["TenSP"].ToString())
                {
                    txtmasp.Text = dt.Rows[i]["MaSP"].ToString();
                    txtensp.Text= dt.Rows[i]["TenSP"].ToString();
                    txtgia.Text = dt.Rows[i]["Gia"].ToString();
                    txtsize.Text=dt.Rows[i]["Size"].ToString();
                    txtnuocsx.Text= dt.Rows[i]["NuocSX"].ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtnuocsx.Text = txtgia.Text = txtsize.Text = txtensp.Text =txtmasp.Text="";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SpDTO s = new SpDTO();
            s.masp = txtmasp.Text;
            s.tensp = txtensp.Text;
            s.nuocsx = txtnuocsx.Text;
            s.size = txtsize.Text;
            s.gia = txtgia.Text;
            SpDAO.ThemSP(s);
            listBox1.Items.Clear();
            Load_listbox();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SpDTO s = new SpDTO();
            s.masp = txtmasp.Text;
            s.tensp = txtensp.Text;
            s.nuocsx = txtnuocsx.Text;
            s.size = txtsize.Text;
            s.gia = txtgia.Text;
            SpDAO.CapnhatSP(s);
            listBox1.Items.Clear();
            Load_listbox();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SpDTO s = new SpDTO();
            if (MessageBox.Show("Ban co muon xoa san pham?", "Thong bao", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                s.masp = txtmasp.Text;
                SpDAO.XoaSP(s);
                listBox1.Items.Clear();
                Load_listbox();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtsize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
               // MessageBox.Show("Vui l", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void txtgia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
               // MessageBox.Show("Số điện thoại không hợp lệ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }
    }
}
