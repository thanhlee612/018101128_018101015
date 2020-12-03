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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        

        private void cTHDToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            frmHoaDon fr = new frmHoaDon();
              fr.Show();


        }

        private void quảnLýNhânViênToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            frmNhanVien f = new frmNhanVien();
            f.Show();
        }

        private void danhSáchSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSanPham f = new frmSanPham();
           f.Show();
        }

        private void danhSáchKháchHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmKhachHang f = new frmKhachHang();
            f.Show();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }
    }
    
}
