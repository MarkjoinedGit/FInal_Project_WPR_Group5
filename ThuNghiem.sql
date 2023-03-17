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
	Email varchar (50),
	ChungMinhNhanDan varchar (50) NOT NULL,
	Luong varchar (50)
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
	MaNguoiQuanLy varchar (50) PRIMARY KEY,
	NgaySinh varchar (50),
	DiaChi varchar (50),
	SoDienThoai varchar (50),
	Email varchar (50),
	ChungMinhNhanDan varchar (50) NOT NULL
)
GO
CREATE PROCEDURE KIEMTRADANGNHAP (
@USER_NAME varchar (50),
@PASSWORD varchar (50)
)
AS
BEGIN
	if exists (select * from DANGNHAP where TenDangNhap = @USER_NAME and MatKhau = @PASSWORD)
		select '1' as code
	else 
		select '0' as code
END;
GO
CREATE PROCEDURE THEMDANGNHAP (
@USER_NAME varchar (50),
@PASSWORD varchar (50),
@CHUC_VU VARCHAR (50) = 'QUANLY'
)
AS
BEGIN
	INSERT INTO DANGNHAP 
	VALUES (@USER_NAME, @PASSWORD, @CHUC_VU)
END;
EXEC  THEMDANGNHAP 'HanhPhucCong1','HanhPhucCong1';

EXEC  KIEMTRADANGNHAP 'HanhPhucCong','HanhPhucCong';
INSERT INTO HOCVIEN (TenHocVien, MaHocVien, NgaySinh, DiaChi, SoDienThoai, ChungMinhNhanDan) VALUES ('A','12B','24/3','HCM','027376482','1244243');
INSERT INTO DANGNHAP (TenDangNhap, MatKhau, ChucVu) VALUES ('HanhPhucCong', 'HanhPhucCong', 'QuanLy');
DROP TABLE HOCVIEN;
DROP TABLE GIAOVIEN;
DROP TABLE LOPHOC;
DROP PROCEDURE KIEMTRADANGNHAP;
DROP PROCEDURE THEMDANGNHAP;


SELECT * FROM DANGNHAP;
SELECT * FROM HOCVIEN;
SELECT * FROM GIAOVIEN;