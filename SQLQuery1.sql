CREATE TABLE [dbo].[Tro](
	[ID_Tro] [nvarchar](50) NOT NULL PRIMARY KEY,
	[DiaChi] [nvarchar](50) NULL,
	dien
	nuoc
	)
CREATE TABLE [dbo].[LoaiPhong](
	[ID_LoaiPhong] [nvarchar](50) NOT NULL PRIMARY KEY,
	[TenLoaiPhong] [nvarchar](50) NULL,
	[DelFlg] [tinyint] NULL,
	[Gia] [nvarchar](50) NULL
	)
---------------------------------------------------------------------------
CREATE TABLE [dbo].[Phong](
	[ID_Phong] [nvarchar](50) NOT NULL Primary key,
	[ID_LoaiPhong] [nvarchar](50) NULL,
	[TenPhong] [nvarchar](50) NULL,
	[TrangThai] [tinyint] NULL,
	[DelFlag] [tinyint] NULL,
	[ID_Tro] [nvarchar](50) NULL,
	FOREIGN KEY ([ID_LoaiPhong]) REFERENCES [dbo].[LoaiPhong]([ID_LoaiPhong]),
	FOREIGN KEY ([ID_Tro]) REFERENCES [dbo].Tro([ID_Tro])
	)
----------------------------------------------------------------------------
CREATE TABLE [dbo].[TaiKhoan](
	[ID_TaiKhoan] [nvarchar](50) NOT NULL PRIMARY KEY,
	[ID_Tro] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[TenTaiKhoan] [nvarchar](50) NULL,
	[Quyen] [int] NULL,
	[DelFlg] [tinyint] NULL,
	FOREIGN KEY ([ID_Tro]) REFERENCES [dbo].Tro([ID_Tro])
	)
---------------------------------------------------------------
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
	FOREIGN KEY ([MaPhong]) REFERENCES [dbo].[Phong]([ID_Phong])
)

--------------------------------------------------------------------------
CREATE TABLE [dbo].[DienNuoc](
	[ID_Phong] [nvarchar](50) NOT NULL PRIMARY KEY,
	SoDienHienTai [bigint]  NULL,
	SoNuocHienTai [bigint]  NULL,
	DonGiaDien [bigint]  NULL,
	DonGiaNuoc [bigint]  NULL,
	FOREIGN KEY ([ID_Phong]) REFERENCES [dbo].[Phong]([ID_Phong])
	)
CREATE TABLE [dbo].[ThongKe](
	[ID_Phong] [nvarchar](50) NOT NULL,
	[Thoigian] [nvarchar] (50) NULL,
	SoDienTieuThu [bigint]  NULL,
	SoNuocTieuThu [bigint]  NULL,
	TienPhong [bigint]  NULL,
	TongTien [bigint]  NULL,
	FOREIGN KEY ([ID_Phong]) REFERENCES [dbo].[Phong]([ID_Phong])
	)

INSERT INTO [dbo].[Tro] ([ID_Tro], [DiaChi])
VALUES 
    (N'TRO01', N'Dia chi 1'),
    (N'TRO02', N'Dia chi 2');
INSERT [dbo].[LoaiPhong] ([ID_LoaiPhong], [TenLoaiPhong], [DelFlg],[Gia]) VALUES (N'00', N'Thường', 0,1000000)
INSERT [dbo].[LoaiPhong] ([ID_LoaiPhong], [TenLoaiPhong], [DelFlg],[Gia]) VALUES (N'01', N'Điều hòa', 0,1500000)
INSERT [dbo].[LoaiPhong] ([ID_LoaiPhong], [TenLoaiPhong], [DelFlg],[Gia]) VALUES (N'02', N'Đầy đủ nội thất', 0,2000000)
INSERT [dbo].[TaiKhoan] ([ID_TaiKhoan],ID_Tro,[Password], [TenTaiKhoan], [Quyen], [DelFlg]) VALUES (N'00001',N'TRO01', N'123', N'Admin', 9999, 0)
INSERT [dbo].[TaiKhoan] ([ID_TaiKhoan],ID_Tro, [Password], [TenTaiKhoan], [Quyen], [DelFlg]) VALUES (N'00006',null, N'1234', N'KHang1', 6666, 0)
INSERT [dbo].[TaiKhoan] ([ID_TaiKhoan],ID_Tro, [Password], [TenTaiKhoan], [Quyen], [DelFlg]) VALUES (N'00007',null, N'1234', N'KHang2', 6666, 0)
INSERT [dbo].[TaiKhoan] ([ID_TaiKhoan],ID_Tro,[Password], [TenTaiKhoan], [Quyen], [DelFlg]) VALUES (N'00002',N'TRO02', N'123', N'Admin1', 9999, 0)
INSERT INTO [dbo].[Phong] ([ID_Phong], [ID_LoaiPhong], [TenPhong], [TrangThai], [DelFlag], [ID_Tro])
VALUES 
    (N'001', N'01', N'001', 0, 0, N'TRO01'),
    (N'002', N'01', N'002', 0, 0, N'TRO01'),
    (N'003', N'01', N'003', 0, 0, N'TRO01'),
    (N'004', N'01', N'004', 0, 0, N'TRO01'),
    (N'005', N'01', N'005', 0, 0, N'TRO01'),
    (N'006', N'01', N'006', 0, 0, N'TRO01'),
    (N'007', N'01', N'007', 0, 0, N'TRO01'),
    (N'008', N'01', N'008', 0, 0, N'TRO01'),
    (N'009', N'01', N'009', 0, 0, N'TRO01'),
    (N'010', N'01', N'010', 0, 0, N'TRO01'),
    (N'011', N'01', N'011', 0, 0, N'TRO02'),
    (N'012', N'01', N'012', 0, 0, N'TRO02'),
    (N'013', N'01', N'013', 0, 0, N'TRO02'),
    (N'014', N'01', N'014', 0, 0, N'TRO02'),
    (N'015', N'01', N'015', 0, 0, N'TRO02'),
    (N'016', N'01', N'016', 0, 0, N'TRO02'),
    (N'017', N'01', N'017', 0, 0, N'TRO02'),
    (N'018', N'01', N'018', 0, 0, N'TRO02'),
    (N'019', N'01', N'019', 0, 0, N'TRO02'),
    (N'020', N'01', N'020', 0, 0, N'TRO02');
Update Phong set TrangThai=0 where ID_Tro='TRO01'
-- Thêm dữ liệu vào bảng ThongKe
-- Thêm dữ liệu vào bảng ThongKe
INSERT INTO [dbo].[ThongKe] ([ID_Phong], [Thoigian], [SoDienTieuThu], [SoNuocTieuThu], [TienPhong], [TongTien])
VALUES 
    (N'001', N'T4/2021', 100, 50, 1000000, 1500000 + 100*3000 + 50*5000),
    (N'002', N'T4/2021', 200, 75, 1500000, 1500000 + 200*3000 + 75*5000),
    (N'003', N'T4/2021', 100, 50, 2000000, 1500000 + 100*3000 + 50*5000),
    (N'004', N'T4/2021', 200, 75, 1500000, 1500000 + 200*3000 + 75*5000),
    (N'005', N'T4/2021', 150, 60, 1000000, 1500000 + 150*3000 + 60*5000),
    (N'006', N'T4/2021', 180, 65, 1500000, 1500000 + 180*3000 + 65*5000),
    (N'007', N'T4/2021', 130, 70, 1000000, 1500000 + 130*3000 + 70*5000),
    (N'008', N'T4/2021', 170, 55, 1500000, 1500000 + 170*3000 + 55*5000),
    (N'009', N'T4/2021', 160, 80, 2000000, 1500000 + 160*3000 + 80*5000),
    (N'010', N'T4/2021', 140, 85, 1500000, 1500000 + 140*3000 + 85*5000);
CREATE TABLE [dbo].[TongTien](
	[ID_Phong] [nvarchar](50) NOT NULL PRIMARY KEY,
	TongTien [bigint]  NULL,
	TienDaThanhToan [bigint]  NULL,
	DuNo [bigint] NULL,
	FOREIGN KEY ([ID_Phong]) REFERENCES [dbo].[Phong]([ID_Phong])
	)
----------------------------------------


Insert [dbo].[ThongKe] values( N'003',N'T3/2023' ,20, 30,1000000,1020080)
Insert [dbo].[ThongKe] values( N'003',N'T4/2023' ,15, 12,1000000,1011500)

Insert KhachHang values(N'00001', N'Thanh', N'1234','KHang2','04040','085038432432',0,N'Quảng Bình','P001')
select* from DienNuoc
INSERT INTO TongTien (ID_Phong, TongTien, TienDaThanhToan,DuNo) VALUES ('001', 1400000, 1400000,0);
INSERT INTO TongTien (ID_Phong, TongTien, TienDaThanhToan,DuNo) VALUES ('002', 1400000, 1400000,0);
INSERT INTO TongTien (ID_Phong, TongTien, TienDaThanhToan,DuNo) VALUES ('003', 1400000, 1400000,0);
INSERT INTO TongTien (ID_Phong, TongTien, TienDaThanhToan,DuNo) VALUES ('004', 1400000, 1400000,0);
INSERT INTO TongTien (ID_Phong, TongTien, TienDaThanhToan,DuNo) VALUES ('005', 1500000, 1500000,0);
INSERT INTO TongTien (ID_Phong, TongTien, TienDaThanhToan,DuNo) VALUES ('006', 900000, 900000,0);
INSERT INTO TongTien (ID_Phong, TongTien, TienDaThanhToan,DuNo) VALUES ('007', 1100000, 1050000,0);
INSERT INTO TongTien (ID_Phong, TongTien, TienDaThanhToan,DuNo) VALUES ('008', 480000, 480000,0);
INSERT INTO TongTien (ID_Phong, TongTien, TienDaThanhToan,DuNo) VALUES ('009', 700000, 700000,0);
INSERT INTO TongTien (ID_Phong, TongTien, TienDaThanhToan,DuNo) VALUES ('010', 1150000, 1150000,0);

select TongTien.ID_Phong,TrangThai,TongTien, TienDaThanhToan,DuNo from TongTien join Phong on Phong.ID_Phong=TongTien.ID_Phong
select* from KhachHang
select* from LoaiPhong
select* from Phong
select* from ThongKe
select * from TongTien
select * from [TaiKhoan]
select * from [Tro]

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

select * from Phong join LoaiPhong on Phong.ID_LoaiPhong = LoaiPhong.ID_LoaiPhong where ID_Phong ='003'
---------------------------------------------------------------------------------------------------------
INSERT INTO [dbo].[DienNuoc] ([ID_Phong], [SoDienHienTai], [SoNuocHienTai], [DonGiaDien], [DonGiaNuoc]) VALUES (N'001', 100, 50, 3000, 5000);
INSERT INTO [dbo].[DienNuoc] ([ID_Phong], [SoDienHienTai], [SoNuocHienTai], [DonGiaDien], [DonGiaNuoc]) VALUES (N'002', 200, 75, 3000, 5000);
INSERT INTO [dbo].[DienNuoc] ([ID_Phong], [SoDienHienTai], [SoNuocHienTai], [DonGiaDien], [DonGiaNuoc]) VALUES (N'003', 100, 50, 3000, 5000);
INSERT INTO [dbo].[DienNuoc] ([ID_Phong], [SoDienHienTai], [SoNuocHienTai], [DonGiaDien], [DonGiaNuoc]) VALUES (N'004', 200, 75, 3000, 5000);
INSERT INTO [dbo].[DienNuoc] ([ID_Phong], [SoDienHienTai], [SoNuocHienTai], [DonGiaDien], [DonGiaNuoc]) VALUES (N'005', 150, 60, 3000, 5000);
INSERT INTO [dbo].[DienNuoc] ([ID_Phong], [SoDienHienTai], [SoNuocHienTai], [DonGiaDien], [DonGiaNuoc]) VALUES (N'006', 180, 65, 3000, 5000);
INSERT INTO [dbo].[DienNuoc] ([ID_Phong], [SoDienHienTai], [SoNuocHienTai], [DonGiaDien], [DonGiaNuoc]) VALUES (N'007', 130, 70, 3000, 5000);
INSERT INTO [dbo].[DienNuoc] ([ID_Phong], [SoDienHienTai], [SoNuocHienTai], [DonGiaDien], [DonGiaNuoc]) VALUES (N'008', 170, 55, 3000, 5000);
INSERT INTO [dbo].[DienNuoc] ([ID_Phong], [SoDienHienTai], [SoNuocHienTai], [DonGiaDien], [DonGiaNuoc]) VALUES (N'009', 160, 80, 3000, 5000);
INSERT INTO [dbo].[DienNuoc] ([ID_Phong], [SoDienHienTai], [SoNuocHienTai], [DonGiaDien], [DonGiaNuoc]) VALUES (N'010', 140, 85, 3000, 5000);

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