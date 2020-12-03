using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _018101128_018101015.DAO
{
    class KetnoiCSDL
    {
        private static SqlConnection cnn;
        public static void Mokn()
        {
            try
            {
                cnn = new SqlConnection(@"Data Source=DESKTOP-JTG95LM\SQLEXPRESS;Initial Catalog=QLGIAY;Integrated Security=True");
                // cnn = new SqlConnection(@"Data Source=DESKTOP-P8MOIJI;Initial Catalog=QLGIAY;Integrated Security=True");
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Khong the ket noi co so du lieu!");
            }
        }
        public static void Dongkn()
        {
            if (cnn.State == ConnectionState.Open)
                cnn.Close();
        }
        public static DataTable ExcuteQuery(string s)
        {
            Mokn();
            SqlCommand cd = new SqlCommand(s, cnn);
            SqlDataReader dr = cd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            Dongkn();
            return dt;
        }
        public static void ExcuteNonQuery(string s)
        {
            Mokn();
            SqlCommand cd = new SqlCommand(s, cnn);
            cd.ExecuteNonQuery();
            Dongkn();
        }

    }
}
