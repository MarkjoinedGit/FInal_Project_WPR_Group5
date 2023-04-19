USE QLTrungTamTiengAnh
GO
CREATE TABLE HOCVIEN	
(
	MaHocVien varchar (10) PRIMARY KEY,
	TenHocVien nvarchar (100) NOT NULL,
	NgaySinh datetime NOT NULL,
	GioiTinh varchar (10) NOT NULL,
	DiaChi nvarchar (1000) NOT NULL,
	SoDienThoai varchar (50),
	ChungMinhNhanDan varchar (50) NOT NULL,
	SoTaiKhoan varchar (50),
	RankLevel float not null,
	check (SoDienThoai like '0[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
)
GO
CREATE TABLE GIAOVIEN
(
	MaGiaoVien varchar (10) PRIMARY KEY,
	TenGiaoVien nvarchar (100) NOT NULL,
	NgaySinh datetime NOT NULL,
	GioiTinh varchar (10) NOT NULL,
	DiaChi nvarchar (1000) NOT NULL,
	SoDienThoai varchar (50),
	ChungMinhNhanDan varchar (50) NOT NULL,
	SoTaiKhoan varchar (50),
	RankLevel float not null,
	Luong float,
	check (SoDienThoai like '0[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	CONSTRAINT check_Level_Teacher
	check (RankLevel > 7.0)
)
GO
CREATE TABLE NGQUANLY
(
	MaNguoiQuanLy varchar (10) PRIMARY KEY,
	TenNguoiQuanLy nvarchar (100) NOT NULL,
	NgaySinh datetime NOT NULL,
	GioiTinh varchar (10) NOT NULL,
	DiaChi nvarchar (1000) NOT NULL,
	SoDienThoai varchar (50),
	ChungMinhNhanDan varchar (50) NOT NULL,
	SoTaiKhoan varchar (50),
	check (SoDienThoai like '0[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
)
GO
CREATE TABLE KHOAHOC
(
	MaKhoaHoc varchar (10) PRIMARY KEY,
	TenKhoaHoc varchar (10) NOT NULL,
	LevelDauVao float NOT NULL,
	LevelDauRa float NOT NULL,
	SoTuanHoc int NOT NULL,
	LevelCuaGiaoVien float,
	CONSTRAINT check_Level 
	CHECK(LevelDauVao < LevelDauRa)
)
GO
CREATE TABLE CA
 (	
	MaCa varchar(5) PRIMARY KEY,
	ThoiGianBatDau time,
	ThoiGianKetThuc time,
)
GO
CREATE TABLE NGUOIDUNG
(
	MaNguoiDung varchar (10) PRIMARY KEY
)
GO
 CREATE TABLE LOPHOC
 (
	MaGiaoVien varchar (10) FOREIGN KEY REFERENCES GIAOVIEN(MaGiaoVien),
	MaLop varchar (10) PRIMARY KEY,
	SoPhong varchar (50) NOT NULL,
	SoHocSinh int,
	MaKhoaHoc varchar(10) FOREIGN KEY REFERENCES KHOAHOC(MaKhoaHoc),
	NgayBatDau datetime,
	NgayKetThuc datetime,
	NgayHocTrongTuan nvarchar(50),
	MaCa varchar(5) FOREIGN KEY REFERENCES CA(MaCa)
)
GO
CREATE TABLE DANGNHAP
(
	MaNguoiDangNhap varchar(10) NOT NULL,
	TenDangNhap varchar (50) NOT NULL,
	MatKhau varchar (50) NOT NULL,
	Email varchar(50),
	ChucVu varchar (50),
	FOREIGN KEY (MaNguoiDangNhap) REFERENCES NGUOIDUNG(MaNguoiDung),
	CHECK (Email like '%@%.%')
)
GO
CREATE TABLE ThongBao
(
	MaNguoiGui varchar (10) NOT NULL,
	MaNguoiNhan varchar (10) NOT NULL,
	NoiDung varchar(1000) NOT NULL,
	FOREIGN KEY (MaNguoiGui) REFERENCES NGUOIDUNG(MaNguoiDung)
)
GO 
CREATE TABLE HocVienTrongLop
(
	MaLop varchar (10),
	MaHocVien varchar (10),
	PRIMARY KEY(MaLop, MaHocVien),
	foreign key(MaLop) references LOPHOC(MaLop),
	foreign key(MaHocVien) references HOCVIEN(MaHocVien)
)
GO
CREATE TABLE NGUOIDUNG
(
	MaNguoiDung varchar (10) PRIMARY KEY
)
/*ràng buộc ngày sinh của giáo viên, học viên và người quản lý không được lớn hơn ngày hiện tại*/
ALTER TABLE GIAOVIEN ADD CONSTRAINT CHECK_NGSINH_GV CHECK (NgaySinh < getdate())
ALTER TABLE HOCVIEN ADD CONSTRAINT CHECK_NGSINH_HV CHECK (NgaySinh < getdate())
ALTER TABLE NGQUANLY ADD CONSTRAINT CHECK_NGSINH_QL CHECK (NgaySinh < getdate())
/*ràng buộc ngày bắt đầu không nhỏ hơn ngày kết thúc*/
ALTER TABLE CA ADD CONSTRAINT CHECK_THOIGIAN CHECK (ThoiGianBatDau < ThoiGianKetThuc)
/*kiểm tra level đầu vào có nhỏ hơn level đầu ra hay không trong bảng khóa học*/
/*GO
CREATE TRIGGER check_level_KhoaHoc
ON KHOAHOC
after insert, update
as
begin
	declare @levelvao float
	declare @levelra float
	select @levelvao = LevelDauVao from KHOAHOC
	select @levelra = LevelDauRa from KHOAHOC
	if not (@levelvao < @levelra)
		begin
			rollback transaction
			raiserror ('Level đầu vào và Level đầu ra không hợp lệ', 16, 1) 
		end
end*/
/*kiểm tra level của giáo viên có hợp lệ hay không (>7.0) */
/*GO
CREATE TRIGGER check_level_GiaoVien
ON KHOAHOC
after insert, update
as
begin
	declare @levelgiaovien float
	select @levelgiaovien = LevelCuaGiaoVien from KHOAHOC
	if not (@levelgiaovien > 7)
		begin
			rollback transaction
			raiserror ('Level của giáo viên không hợp lệ', 16, 1) 
		end
end*/
/* Hàm lấy danh sách sinh viên của một lớp học*/
GO
CREATE TRIGGER THEMNGUOIDUNG_GV
ON GIAOVIEN
after insert
as
begin 
	declare @manguoidung varchar (10)
	select @manguoidung = MaGiaoVien from GIAOVIEN
	insert into NGUOIDUNG values (@manguoidung)
end;

GO
CREATE TRIGGER SUANGUOIDUNG_GV
ON GIAOVIEN
after update
as
begin 
	declare @OLD_manguoidung varchar (10)
	declare @NEW_manguoidung varchar (10)
	select @OLD_manguoidung = deleted.MaGiaoVien from deleted
	select @NEW_manguoidung = inserted.MaGiaoVien from inserted
	update NGUOIDUNG set MaNguoiDung = @NEW_manguoidung where MaNguoiDung = @OLD_manguoidung 
end;

GO
CREATE TRIGGER XOANGUOIDUNG_GV
ON GIAOVIEN
after delete
as
begin 
	declare @manguoidung varchar (10)
	select @manguoidung = deleted.MaGiaoVien from deleted
	delete from NGUOIDUNG where MaNguoiDung = @manguoidung
end;

GO
CREATE TRIGGER THEMNGUOIDUNG_HV
ON HOCVIEN
after insert
as
begin 
	declare @manguoidung varchar (10)
	select @manguoidung = MaHocVien from HOCVIEN
	insert into NGUOIDUNG values (@manguoidung)
end;
GO
CREATE TRIGGER XOANGUOIDUNG_HV
ON HOCVIEN
after delete
as
begin 
	declare @manguoidung varchar (10)
	select @manguoidung = deleted.MaHocVien from deleted
	delete from NGUOIDUNG where MaNguoiDung = @manguoidung
end;
GO
CREATE TRIGGER SUANGUOIDUNG_HV
ON HOCVIEN
after update
as
begin 
	declare @OLD_manguoidung varchar (10)
	declare @NEW_manguoidung varchar (10)
	select @OLD_manguoidung = deleted.MaHocVien from deleted
	select @NEW_manguoidung = inserted.MaHocVien from inserted
	update NGUOIDUNG set MaNguoiDung = @NEW_manguoidung where MaNguoiDung = @OLD_manguoidung 
end;

GO
CREATE TRIGGER THEMNGUOIDUNG_NGQL
ON NGQUANLY
after insert
as
begin 
	declare @manguoidung varchar (10)
	select @manguoidung = MaNguoiQuanLy from NGQUANLY
	insert into NGUOIDUNG values (@manguoidung)
end;
GO
CREATE TRIGGER XOANGUOIDUNG_NGQL
ON NGQUANLY
after delete
as
begin 
	declare @manguoidung varchar (10)
	select @manguoidung = deleted.MaNguoiQuanLy from deleted
	delete from NGUOIDUNG where MaNguoiDung = @manguoidung
end;
GO
CREATE TRIGGER SUANGUOIDUNG_NGQL
ON NGQUANLY
after update
as
begin 
	declare @OLD_manguoidung varchar (10)
	declare @NEW_manguoidung varchar (10)
	select @OLD_manguoidung = deleted.MaNguoiQuanLy from deleted
	select @NEW_manguoidung = inserted.MaNguoiQuanLy from inserted
	update NGUOIDUNG set MaNguoiDung = @NEW_manguoidung where MaNguoiDung = @OLD_manguoidung 
end;

GO
CREATE or ALTER FUNCTION fn_LayDanhSachHocVienTrongLop(@MaLop varchar (10))
returns table
AS
return(
	SELECT *
	FROM HOCVIEN
	WHERE MaHocVien IN (SELECT MaHocVien
						FROM HocVienTrongLop
						WHERE @MaLop = MaLop))
go

/*ràng buộc số học sinh <=25*/
ALTER TABLE LOPHOC ADD CONSTRAINT CHECK_SL_HS CHECK (SoHocSinh < 26)	

/*Tạo dư liệu*/
/*MaHocVien, TenHocVien, NgaySinh, GioiTinh, DiaChi, SoDienThoai, ChungMinhNhanDan, SoTaiKhoan, RankLevel*/
INSERT INTO GIAOVIEN (MaGiaoVien, TenGiaoVien, NgaySinh, GioiTinh, DiaChi, SoDienThoai, ChungMinhNhanDan, RankLevel) VALUES ('TEA0001', N'Trần Văn A', '1980-06-20', 'Nam', N'Hồ Chí Minh', '0905227152', '079102929818', '8.0')
INSERT INTO GIAOVIEN (MaGiaoVien, TenGiaoVien, NgaySinh, GioiTinh, DiaChi, SoDienThoai, ChungMinhNhanDan, RankLevel) VALUES ('TEA0002', N'Nguyễn Thị Hồng', '1978-05-24', 'Nu', N'Hà Nội', '0306227152', '057152464', '8.5')
INSERT INTO GIAOVIEN (MaGiaoVien, TenGiaoVien, NgaySinh, GioiTinh, DiaChi, SoDienThoai, ChungMinhNhanDan, RankLevel) VALUES ('TEA0003', N'Nguyễn Tiến Dũng', '1990-12-24', 'Nam', N'Cần Thơ', '0406227142', '065102929810', '7.5')

INSERT INTO HOCVIEN (MaHocVien, TenHocVien, NgaySinh, GioiTinh, DiaChi, SoDienThoai, ChungMinhNhanDan, RankLevel) VALUES ('STU0001', N'Nguyễn Công Phương', '2003-05-19', 'Nam', N'Bến Tre', '0906227172', '085102929800', '1.0')
INSERT INTO HOCVIEN (MaHocVien, TenHocVien, NgaySinh, GioiTinh, DiaChi, SoDienThoai, ChungMinhNhanDan, RankLevel) VALUES ('STU0002', N'Quang Hải', '2004-02-28', 'Nam', N'Sài Gòn', '0606227022', '065102929801', '1.5')
INSERT INTO HOCVIEN (MaHocVien, TenHocVien, NgaySinh, GioiTinh, DiaChi, SoDienThoai, ChungMinhNhanDan, RankLevel) VALUES ('STU0003', N'Lê Văn Đô', '2003-01-29', 'Nam', N'Bến  Tre', '0206226174', '075102929802', '1.0')

INSERT INTO NGQUANLY (MaNguoiQuanLy, TenNguoiQuanLy, NgaySinh, GioiTinh, DiaChi, SoDienThoai, ChungMinhNhanDan) VALUES ('MNG001', 'Admin', '11-04-2003', 'Nam', N'Biên Hòa', '0869628507', '075203001794') 

INSERT INTO KHOAHOC VALUES ('BS', 'BASIC', '0.0', '2.0', '10', '7.0')
INSERT INTO KHOAHOC VALUES ('PF', 'PRFOUNDATN', '2.0', '4.0', '10', '7.0')
INSERT INTO KHOAHOC VALUES ('FO', 'FOUNDATION', '4.0', '5.0', '10', '7.0')

INSERT INTO CA VALUES ('CA01','17:45:00','19:45:00')
INSERT INTO CA VALUES ('CA02','19:45:00','21:45:00')

INSERT INTO DANGNHAP VALUES ('STU0001', 'NguyenCongPhuong', '123456789', 'phuong123@gmail.com', 'HV')
INSERT INTO DANGNHAP VALUES ('STU0002', 'QuangHai', '123443', 'quanghai98@gmail.com', 'HV')
INSERT INTO DANGNHAP VALUES ('STU0003', 'LeVanDo', '354264', 'daklak115@gmail.com', 'HV')

INSERT INTO DANGNHAP VALUES ('TEA0001', 'TranVanA', '454768', 'tranvana4@gmail.com', 'GV')
INSERT INTO DANGNHAP VALUES ('TEA0002', 'NguyenThiHong', '124789', 'honghao12@gmail.com', 'GV')
INSERT INTO DANGNHAP VALUES ('TEA0003', 'NguyenTienDung', '473789', 'dungman87@gmail.com', 'GV')

INSERT INTO DANGNHAP VALUES ('MNG001', 'admin', 'admin', 'admin@gmail.com', 'QL')
													
INSERT INTO LOPHOC VALUES ('TEA0001', 'BS001', '3', '20', 'BS', '2023-06-20', '2023-08-22', 'T3-T5-T7', 'CA01')
INSERT INTO LOPHOC VALUES ('TEA0002', 'BS002', '3', '20', 'BS', '2023-06-20', '2023-08-22', 'T3-T5-T7', 'CA02')
INSERT INTO LOPHOC VALUES ('TEA0003', 'PF002', '1', '22', 'PF', '2023-05-19', '2023-07-28', 'T2-T4-T6', 'CA01')
INSERT INTO LOPHOC VALUES ('TEA0002', 'BS0002', '12', '20', 'BS', '1/1/0001 12:00:00 AM', '1/1/0001 12:00:00 AM', 'T2-T4-T6', 'CA01')

																

DROP TABLE LOPHOC;
DROP TABLE DANGNHAP;
DROP TABLE NGQUANLY;
DROP TABLE HOCVIEN;
DROP TABLE ThongBao;
DROP TABLE KHOAHOC;
DROP TABLE CA;
DROP TABLE GIAOVIEN;
DROP TABLE HocVienTrongLop;
DROP TABLE NGUOIDUNG;

SELECT* FROM DANGNHAP WHERE TenDangNhap = 'admin' AND MatKhau = 'admin'
ALTER TABLE LOPHOC
ALTER COLUMN NgayBatDau DATE
ALTER TABLE LOPHOC
ALTER COLUMN NgayKetThuc DATE