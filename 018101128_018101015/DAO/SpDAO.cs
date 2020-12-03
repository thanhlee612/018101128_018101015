using _018101128_018101015.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _018101128_018101015.DAO
{
    class SpDAO
    {
        // load hoa don & CTHD
        public static DataTable TT_HD(string sohd)
        {
            string s = "select sohd, ngayhd, k.makh, tenkh, n.manv, tennv from hoadon h, nhanvien n, khachhang k where k.makh=h.makh and h.manv=n.manv and sohd= '" + sohd + "'";
            DataTable dt = new DataTable();
            dt = KetnoiCSDL.ExcuteQuery(s);
            return dt;
        }
        public static DataTable TT_Datagridview(string sohd)
        {
            string s = "select  s.MaSP, TenSP, SoLuong, Gia, c.soluong*gia as ThanhTien from CTHD  c , SANPHAM  s where c.masp=s.masp and sohd ='" + sohd + "' ";
            DataTable dt = new DataTable();
            dt = KetnoiCSDL.ExcuteQuery(s);
            return dt;
        }
        public static DataTable TT_Datagridview1(string makh)
        {
            string s = "select c.sohd, s.MaSP, TenSP,n.MaNV,TenNV,k.DiaChi,k.SDT, SoLuong,k.MaKH, TenKH,ngayhd, Gia,TriGia  from NhanVien n, CTHD c ,HoaDon h,khachhang k, SANPHAM s where h.manv=n.manv and c.masp=s.masp and k.makh=h.makh and c.sohd=h.sohd and k.makh ='" + makh + "' ";
            DataTable dt = new DataTable();
            dt = KetnoiCSDL.ExcuteQuery(s);
            return dt;
        }
        public static DataTable TT_Datagridview1()
        {
            string s = " select s.MaSP, TenSP, SoLuong,gia,soluong* gia as ThanhTien from CTHD AS c INNER JOIN SANPHAM AS s ON c.masp= s.masp  ";
            DataTable dt = new DataTable();
            dt = KetnoiCSDL.ExcuteQuery(s);
            return dt;
        }

        public static DataTable TT_CBSP()
        {
            string s = "select * from sanpham";
            DataTable dt = new DataTable();
            dt = KetnoiCSDL.ExcuteQuery(s);
            return dt;
        }
        public static DataTable TT_CBTK()
        {
            string s = "select sohd from hoadon";
            DataTable dt = new DataTable();
            dt = KetnoiCSDL.ExcuteQuery(s);
            return dt;
        }
        public static DataTable TT_CBKH()
        {
            string s = "select * from khachhang";
            DataTable dt = new DataTable();
            dt = KetnoiCSDL.ExcuteQuery(s);
            return dt;
        }
        public static DataTable TT_CBNV()
        {
            string s = "select * from nhanvien";
            DataTable dt = new DataTable();
            dt = KetnoiCSDL.ExcuteQuery(s);
            return dt;
        }
        public static DataTable TT_CTHD(string sodh)
        {
            string s = "select sohd,ngayhd, k.makh, tenkh, n.manv, tennv from  hoadon h, nhanvien n, khachhang k where h.makh=k.makh and h.manv=n.manv and  h.sohd= '" + sodh + "' ";
            DataTable dt = new DataTable();
            dt = KetnoiCSDL.ExcuteQuery(s);
            return dt;
        }

        public static DataTable getSohd()
        {
            string s = "select top 1 sohd from hoadon order by sohd desc";
            DataTable dt = new DataTable();
            dt = KetnoiCSDL.ExcuteQuery(s);
            return dt;
        }
        public static DataTable getDongia(string sohd)
        {
            string s = "select sohd,Gia, soluong from CTHD c, sanpham s where c.masp=s.masp and sohd='" + sohd + "'";
            DataTable dt = new DataTable();
            dt = KetnoiCSDL.ExcuteQuery(s);
            return dt;
        }

        // Them sua xoa HoaDon & CTHD
        public static void ThemHD(SpDTO s)
        {
            string sql = "insert into hoadon values('" + s.sohd + "','" + s.ngayhd + "','" + s.makh + "','" + s.manv + "','" + s.trigia + "')";
            KetnoiCSDL.ExcuteNonQuery(sql);

            string sql1 = "insert into cthd values('" + s.sohd + "','" + s.masp + "','" + s.soluong + "')";
            KetnoiCSDL.ExcuteNonQuery(sql1);
        }
        public static void CapnhatHD(SpDTO s)
        {
            string sql = "update hoadon set ngayhd='" + s.ngayhd + "',makh='" + s.makh + "',manv='" + s.manv + "',trigia='" + s.trigia + "' where sohd='" + s.sohd + "'";
            KetnoiCSDL.ExcuteNonQuery(sql);

            string sql1 = "update cthd set masp='" + s.masp + "',soluong='" + s.soluong + "' where sohd='" + s.sohd + "'";
            KetnoiCSDL.ExcuteNonQuery(sql1);
        }
        public static void XoaHD(SpDTO s)
        {
            string sql1 = "Delete From CTHD where sohd='" + s.sohd + "' and MaSP='"+s.masp+"'";
            KetnoiCSDL.ExcuteNonQuery(sql1);
            string sql = "Delete From hoadon where sohd='" + s.sohd + "'";
            KetnoiCSDL.ExcuteNonQuery(sql);
            
        }
        // report Hoa don
        public static string SoHD;
        public static string sohdd
        {
            get { return SoHD; }
            set { SoHD = value; }
        }
        public static string MaKH;
        public static string makhachhang
        {
            get { return MaKH; }
            set { MaKH = value; }
        }

        //Them sua xoa San Pham
        public static void ThemSP(SpDTO s)
        {
            string s1 = "insert into sanpham values('" + s.masp + "',N'" + s.tensp + " ','" + s.size + "',N'" + s.nuocsx + "','" + s.gia + "')";
            KetnoiCSDL.ExcuteNonQuery(s1);
        }
      
        public static void CapnhatSP(SpDTO s)
        {
            string s1 = "Update SanPham set TenSP=N'"+s.tensp+"',Size='"+s.size+"',NuocSX=N'"+s.nuocsx+"',Gia='"+s.gia+"' where MaSP='"+s.masp+"'";
            KetnoiCSDL.ExcuteNonQuery(s1);
        }
        public static void XoaSP(SpDTO s)
        {
            string s1 = "Delete From SanPham where MaSP='" + s.masp + "'";
            KetnoiCSDL.ExcuteNonQuery(s1);
        }
        public static DataTable Load_Listbox()
        {
            string s = "select * from Sanpham";
            DataTable dt = new DataTable();
            dt = KetnoiCSDL.ExcuteQuery(s);
            return dt;
        }
       
        
    }
}