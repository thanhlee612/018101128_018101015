using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _018101128_018101015
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmKhachHang());
            //Application.Run(new frmHoaDon());
            // Application.Run(new frmNhanVien());
            // Application.Run(new frmSanPham());
            Application.Run(new MenuForm());
        }
    }
}
