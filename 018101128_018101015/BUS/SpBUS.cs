using _018101128_018101015.DAO;
using _018101128_018101015.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _018101128_018101015.BUS
{
    class SpBUS
    {
        public static void Xoa(SpDTO s)

        {
            if(MessageBox.Show("Ban co muon xoa? ","Thong bao",MessageBoxButtons.YesNo)== DialogResult.Yes)
            {
                try
                {
                    SpDAO.XoaHD(s);
                }
                catch(Exception)
                {
                    MessageBox.Show("Khong the xoa");
                }
            }
        }
    }
}
