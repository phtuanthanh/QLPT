CREATE TABLE [dbo].[TaiKhoan](
	[ID_TaiKhoan] [nvarchar](50) NOT NULL PRIMARY KEY,
	[Password] [nvarchar](50) NULL,
	[TenTaiKhoan] [nvarchar](50) NULL,
	[Quyen] [int] NULL,
	[DelFlg] [tinyint] NULL,
	)
//---------------------------------------------------------------
CREATE TABLE [dbo].[KhachHang](
	[ID_KhachHang] [nvarchar](50) NOT NULL PRIMARY KEY,
	[TenKhachHang] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[TenTaiKhoan] [nvarchar](50) NULL,
	[CCCD] [nvarchar](50) NULL,
	[SoDienThoai] [nvarchar](50) NULL,
	[DelFlg] [tinyint] NULL,
	[DiaChi] [nvarchar](500) NULL DEFAULT (''),
	[MaPhong] [nvarchar] (50) NULL,
)
-----------------------------------------------------------------------
CREATE TABLE [dbo].[Phong](
	[ID_Phong] [nvarchar](50) NOT NULL Primary key,
	[ID_LoaiPhong] [nvarchar](50) NULL,
	[TrangThai] [tinyint] NULL,
	[DelFlag] [tinyint] NULL,
	)
----------------------------------------------------------------------------
CREATE TABLE [dbo].[LoaiPhong](
	[ID_LoaiPhong] [nvarchar](50) NOT NULL PRIMARY KEY,
	[TenLoaiPhong] [nvarchar](50) NULL,
	[DelFlg] [tinyint] NULL,
	[Gia] [nvarchar](50) NULL
	)
--------------------------------------------------------------------------
CREATE TABLE [dbo].[DienNuoc](
	[ID_Phong] [nvarchar](50) NOT NULL PRIMARY KEY,
	SoDienHienTai [bigint]  NULL,
	SoNuocHienTai [bigint]  NULL,
	DonGiaDien [bigint]  NULL,
	DonGiaNuoc [bigint]  NULL,
	)
CREATE TABLE [dbo].[ThongKe](
	[ID_Phong] [nvarchar](50) NOT NULL,
	[Thoigian] [nvarchar] (50) NULL,
	SoDienTieuThu [bigint]  NULL,
	SoNuocTieuThu [bigint]  NULL,
	TienPhong [bigint]  NULL,
	TongTien [bigint]  NULL,
	)
CREATE TABLE [dbo].[TongTien](
	[ID_Phong] [nvarchar](50) NOT NULL PRIMARY KEY,
	TongTien [bigint]  NULL,
	TienDaThanhToan [bigint]  NULL,
	DuNo [bigint] NULL,
	)
----------------------------------------
INSERT [dbo].[TaiKhoan] ([ID_TaiKhoan], [Password], [TenTaiKhoan], [Quyen], [DelFlg]) VALUES (N'00001', N'123', N'Admin', 9999, 0)
INSERT [dbo].[TaiKhoan] ([ID_TaiKhoan], [Password], [TenTaiKhoan], [Quyen], [DelFlg]) VALUES (N'00006', N'1234', N'KHang1', 6666, 0)
INSERT [dbo].[TaiKhoan] ([ID_TaiKhoan], [Password], [TenTaiKhoan], [Quyen], [DelFlg]) VALUES (N'00007', N'1234', N'KHang2', 6666, 0)

Insert [dbo].[ThongKe] values( N'003',N'T3/2023' ,20, 30,1000000,1020080)
Insert [dbo].[ThongKe] values( N'003',N'T4/2023' ,15, 12,1000000,1011500)

Insert KhachHang values(N'00001', N'Thanh', N'1234','KHang2','04040','085038432432',0,N'Quảng Bình','P001')
select* from DienNuoc
INSERT INTO TongTien (ID_Phong, TongTien, TienDaThanhToan,DuNo) VALUES ('003', 1400000, 1400000,0);
INSERT INTO TongTien (ID_Phong, TongTien, TienDaThanhToan,DuNo) VALUES ('004', 1400000, 1400000,0);
INSERT INTO TongTien (ID_Phong, TongTien, TienDaThanhToan,DuNo) VALUES ('005', 1500000, 1500000,0);
INSERT INTO TongTien (ID_Phong, TongTien, TienDaThanhToan,DuNo) VALUES ('006', 900000, 900000,0);
INSERT INTO TongTien (ID_Phong, TongTien, TienDaThanhToan,DuNo) VALUES ('007', 1100000, 1050000,0);
INSERT INTO TongTien (ID_Phong, TongTien, TienDaThanhToan,DuNo) VALUES ('008', 480000, 480000,0);
INSERT INTO TongTien (ID_Phong, TongTien, TienDaThanhToan,DuNo) VALUES ('009', 700000, 700000,0);
INSERT INTO TongTien (ID_Phong, TongTien, TienDaThanhToan,DuNo) VALUES ('010', 1150000, 1150000,0);
INSERT INTO TongTien (ID_Phong, TongTien, TienDaThanhToan,DuNo) VALUES ('011', 1300000, 1250000,0);
INSERT INTO TongTien (ID_Phong, TongTien, TienDaThanhToan,DuNo) VALUES ('012', 950000, 900000,0);
INSERT INTO TongTien (ID_Phong, TongTien, TienDaThanhToan,DuNo) VALUES ('015', 350000, 350000,0);



select* from KhachHang
select* from LoaiPhong
select Gia from LoaiPhong
select* from Phong
select* from ThongKe
select * from TongTien
select * from [TaiKhoan]
update DienNuoc set SoDienHienTai=50,SoNuocHienTai=45 where ID_Phong = '003'  

INSERT [dbo].[Phong] ([ID_Phong], [ID_LoaiPhong], [TrangThai], [DelFlag]) VALUES (N'003', N'02', 1, 0)
INSERT [dbo].[Phong] ([ID_Phong], [ID_LoaiPhong],  [TrangThai], [DelFlag]) VALUES (N'004', N'01', 0, 0)
INSERT [dbo].[Phong] ([ID_Phong], [ID_LoaiPhong],  [TrangThai], [DelFlag]) VALUES (N'005', N'00', 1, 0)
INSERT [dbo].[Phong] ([ID_Phong], [ID_LoaiPhong],[TrangThai], [DelFlag]) VALUES (N'006', N'00', 0, 0)
INSERT [dbo].[Phong] ([ID_Phong], [ID_LoaiPhong],  [TrangThai], [DelFlag]) VALUES (N'007', N'00', 0, 0)
INSERT [dbo].[Phong] ([ID_Phong], [ID_LoaiPhong],  [TrangThai], [DelFlag]) VALUES (N'008', N'00', 0, 0)
INSERT [dbo].[Phong] ([ID_Phong], [ID_LoaiPhong],  [TrangThai], [DelFlag]) VALUES (N'009', N'00', 0, 0)
INSERT [dbo].[Phong] ([ID_Phong], [ID_LoaiPhong],  [TrangThai], [DelFlag]) VALUES (N'010', N'00', 0, 0)
//---------------------------------------------------------------
INSERT [dbo].[LoaiPhong] ([ID_LoaiPhong], [TenLoaiPhong], [DelFlg],[Gia]) VALUES (N'00', N'Thường', 0,1000000)
INSERT [dbo].[LoaiPhong] ([ID_LoaiPhong], [TenLoaiPhong], [DelFlg],[Gia]) VALUES (N'01', N'Điều hòa', 0,1500000)
INSERT [dbo].[LoaiPhong] ([ID_LoaiPhong], [TenLoaiPhong], [DelFlg],[Gia]) VALUES (N'02', N'Đầy đủ nội thất', 0,2000000)
select * from Phong join LoaiPhong on Phong.ID_LoaiPhong = LoaiPhong.ID_LoaiPhong where ID_Phong ='003'
---------------------------------------------------------------------------------------------------------


ALTER TABLE KhachHang
ADD CONSTRAINT FK_KhachHang_TaiKhoan
FOREIGN KEY ([ID_KhachHang])
REFERENCES TaiKhoan([ID_KhachHang]);
select * from DienNuoc
select * from ThongKe
select Phong.ID_Phong,SoNuocHienTai,SoDienHienTai,DonGiaDien,DonGiaNuoc,TrangThai,Gia from Phong full join DienNuoc on DienNuoc.ID_Phong=Phong.ID_Phong join LoaiPhong on LoaiPhong.ID_LoaiPhong = Phong.ID_LoaiPhong
select * from TongTien join Phong on Phong.ID_Phong = TongTien.ID_Phong where Phong.TrangThai= 0
Select * from Phong join LoaiPhong on Phong.ID_LoaiPhong = LoaiPhong.ID_LoaiPhong full join KhachHang on KhachHang.[MaPhong] = Phong.ID_Phong 
Select * from Phong join LoaiPhong on Phong.ID_LoaiPhong = LoaiPhong.ID_LoaiPhong full join KhachHang on KhachHang.[MaPhong] = Phong.ID_Phong Where ID_Phong='003'