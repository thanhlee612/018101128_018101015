create Database QLGIAY
go
use QLGIAY
go

create Table NhanVien(
	MaNV nvarchar(10) primary key (MaNV),
	TenNV nvarchar(40),
	Phai bit,
	DiaChi nvarchar(50),
	SDT nvarchar(10),
	NgaySinh datetime
	
);
create Table KhachHang(
	MaKH nvarchar(20) primary key (MaKH),
	TenKH nvarchar(40),
	DiaChi nvarchar(50),
	SDT nvarchar(10),
	NgaySinh datetime
	
);
create Table SanPham(
	MaSP nvarchar(10) primary key (MaSP),
	TenSP nvarchar(40), 
	Size nvarchar(10),
	NuocSX nvarchar(20),
	Gia money
	
);
create Table HoaDon(
	SoHD varchar(10) primary key (SoHD),
	NgayHD datetime,
	MaKH nvarchar(20),
	MaNV nvarchar(10), 
	TriGia money
	foreign key (MaKH) references KhachHang(MaKH),
	foreign key (MaNV) references NhanVien(MaNV)
	
);

 create Table CTHD(
	SoHD varchar(10) primary key (SoHD, MaSP),
	MaSP nvarchar(10),
	SoLuong nvarchar(10)
	foreign key(SoHD) references HoaDon(SoHD),
	foreign key(MaSP) references SanPham(MaSP),
 );

 create Table NhaCC (
	MaNCC nvarchar(10) primary key(MaNCC),
	TenNCC nvarchar(40),
	DiaChi nvarchar(40),
	SDT varchar(10)
);
create Table PhieuNhap(
MaPN nvarchar(10) primary key(MaPN),
NgayNhap datetime,
MaNCC nvarchar(10),
MaNV nvarchar(10)

foreign key (MaNV) references NhanVien(MaNV),
foreign key (MaNCC) references NhaCC(MaNCC)
);
 --Khóa ngoại bảng CTHD
--ALTER TABLE CTHD ADD CONSTRAINT fk01_CTHD FOREIGN KEY(SOHD) REFERENCES HOADON(SOHD)
--ALTER TABLE CTHD ADD CONSTRAINT fk02_CTHD FOREIGN KEY(MASP) REFERENCES SANPHAM(MASP)
-- SANPHAM
insert into sanpham values('ADIDAS',N'Giày Chạy Bộ Nam Adidas SOLAR DRIVE ','42',N'Đức','1450000')
insert into sanpham values('NIKE',N'Giày Chạy Bộ Nữ WMNS Nike Quest','40',N'Mỹ','1455000')
insert into sanpham values('CONVERSE',N'Giày Sneaker Unisex Converse','41',N'Hoa Kỳ','1500000')
insert into sanpham values('FILA',N'Giày Thể Thao Nam FILA ATTREK','39','Italya','998000')
insert into sanpham values('PUMA',N'Giày sneaker Puma','43',N'Đức','799000')
insert into sanpham values('VANS',N'Giày Sneaker Unisex Old Skool Vans','44',N'Mỹ','1750000')
insert into sanpham values('DOMBA',N'Giày Domba High Point','39','California,','980000')


-- KHACHHANG
insert into khachhang values('KH01','Nguyen Van A','731 Tran Hung Dao, Q5, TpHCM','8823451','2/07/2006')
insert into khachhang values('KH02','Tran Ngoc Han','23/5 Nguyen Trai, Q5, TpHCM','908256478','3/07/2006')
insert into khachhang values('KH03','Tran Ngoc Linh','45 Nguyen Canh Chan, Q1, TpHCM','938776266','8/05/2005')
insert into khachhang values('KH04','Tran Minh Long','50/34 Le Dai Hanh, Q10, TpHCM','917325476','10/02/2004')
insert into khachhang values('KH05','Le Nhat Minh','34 Truong Dinh, Q3, TpHCM','8246108','8/10/2001')
insert into khachhang values('KH06','Le Hoai Thuong','227 Nguyen Van Cu, Q5, TpHCM','8631738','2/11/2002')
insert into khachhang values('KH07','Nguyen Van Tam','32/3 Tran Binh Trong, Q5, TpHCM','916783565','2/01/2005')
insert into khachhang values('KH08','Phan Thi Thanh','45/2 An Duong Vuong, Q5, TpHCM','938435756','1/12/2000')
insert into khachhang values('KH09','Le Ha Vinh','873 Le Hong Phong, Q5, TpHCM','8654763','4/01/2007')
insert into khachhang values('KH10','Ha Duy Lap','34/34B Nguyen Trai, Q1, TpHCM','8768904','1/01/2003')

-- NHANVIEN
insert into nhanvien values('NV01','Nguyen Nhu Nhut','0','Tien Giang','927345678','1/04/2006')
insert into nhanvien values('NV02','Le Thi Phi Yen','0','Ben Tre','987567390','2/04/2006')
insert into nhanvien values('NV03','Nguyen Van B','1','Vinh Long','997047382','7/04/2006')
insert into nhanvien values('NV04','Ngo Thanh Tuan','1','Long An','913758498','4/06/2006')
insert into nhanvien values('NV05','Nguyen Thi Truc Thanh','0','Tien Giang','918590387','2/07/2006')
--Hoa Don
insert into hoadon values('HD001','2/07/2020','KH01','NV01','290000')
insert into hoadon values('HD011','3/07/2020','KH01','NV01','4350000')
insert into hoadon values('HD002','12/08/2020','KH02','NV02','727500')
insert into hoadon values('HD003','3/08/2020','KH03','NV01','450000')
insert into hoadon values('HD004','1/09/2020','KH04','NV01','399200')
insert into hoadon values('HD005','2/10/2020','KH05','NV02','159800')
insert into hoadon values('HD006','6/10/2020','KH06','NV03','1750000')
insert into hoadon values('HD007','8/10/2020','KH07','NV03','2940000')
insert into hoadon values('HD008','2/10/2020','KH08','NV03','3920000')
insert into hoadon values('HD009','8/11/2020','KH09','NV04','3500000')
insert into hoadon values('HD010','1/11/2020','KH10','NV01','4990000')

--CTHD
insert into cthd values('HD001','ADIDAS','2')
insert into cthd values('HD011','ADIDAS','3')
insert into cthd values('HD002','NIKE','5')
insert into cthd values('HD003','CONVERSE','3')
insert into cthd values('HD004','FILA','4')
insert into cthd values('HD005','PUMA','2')
insert into cthd values('HD006','VANS','1')
insert into cthd values('HD007','DOMBA','3')
insert into cthd values('HD008','DOMBA','4')
insert into cthd values('HD009','VANS','2')
insert into cthd values('HD010','FILA','5')

SELECT SCOPE_IDENTITY()
select  a.masp,soluong*gia as thanhtien from CTHD AS a INNER JOIN SANPHAM AS b ON a.masp=b.masp;
--select s.MaSP, TenSP, SoLuong, Gia, c.soluong*gia as ThanhTien from CTHD AS c INNER JOIN SANPHAM AS s ON c.masp=s.masp ;