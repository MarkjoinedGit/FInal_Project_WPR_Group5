CREATE DATABASE QLTRUNGTAMTA
GO 
USE QLTRUNGTAMTA
GO
CREATE TABLE HOCVIEN	
(
	TenHocVien varchar (50) NOT NULL,
	MaHocVien varchar (50) PRIMARY KEY,
	NgaySinh varchar (50),
	DiaChi varchar (50),
	SoDienThoai varchar (50),
	ChungMinhNhanDan varchar (50) NOT NULL
)
GO
CREATE TABLE GIAOVIEN
(
	TenGiaoVien varchar (50) NOT NULL,
	MaGiaoVien varchar (50) PRIMARY KEY,
	NgaySinh varchar (50),
	DiaChi varchar (50),
	SoDienThoai varchar (50),
	ChungMinhNhanDan varchar (50) NOT NULL,
	Luong varchar (50) NOT NULL
)
GO
 CREATE TABLE LOPHOC
 (
	MaLop varchar (50) PRIMARY KEY,
	SoPhong varchar (50) NOT NULL,
	MaGiaoVien varchar (50) FOREIGN KEY REFERENCES HOCSINH(MaHocSinh),
	MaHocSinh varchar (50) FOREIGN KEY REFERENCES GIAOVIEN(MaGiaoVien
 )
GO
CREATE TABLE DANGNHAP
(
	TenDangNhap varchar (50) PRIMARY KEY,
	MatKhau varchar (50) NOT NULL,
	ChucVu varchar (50) NOT NULL
)
GO
CREATE TABLE NGQUANLY
(
	TenNguoiQuanLy varchar (50) NOT NULL,
	MaNguoiQuanLy varchar (50) PRIMARY KEY
)
INSERT INTO HOCVIEN (TenHocVien, MaHocVien, NgaySinh, DiaChi, SoDienThoai, ChungMinhNhanDan) VALUES ('A','12B','24/3','HCM','027376482','1244243');
DROP TABLE HOCVIEN;
DROP TABLE GIAOVIEN;
DROP TABLE LOPHOC;

SELECT * FROM HOCVIEN;
SELECT * FROM GIAOVIEN;