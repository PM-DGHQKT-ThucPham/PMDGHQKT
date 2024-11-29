Use master
go
create database [DoAnTotNghiep]
go
USE [DoAnTotNghiep]
GO
/****** Object:  Table [dbo].[BenVung]    Script Date: 11/29/2024 9:47:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BenVung](
	[MaBenVung] [varchar](10) NOT NULL,
	[MaSanPham] [varchar](10) NULL,
	[MoTa] [nvarchar](max) NULL,
	[DanhGiaAnhHuongMoiTruong] [decimal](5, 2) NULL,
	[DanhGiaAnToan] [decimal](5, 2) NULL,
	[MucDoAnhHuong] [decimal](5, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaBenVung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiPhi]    Script Date: 11/29/2024 9:47:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiPhi](
	[MaChiPhi] [varchar](10) NOT NULL,
	[MoTa] [nvarchar](max) NULL,
	[SoTien] [decimal](18, 2) NULL,
	[ThoiGian] [datetime] NULL,
	[MaLoaiChiPhi] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChiPhi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietThanhPhan]    Script Date: 11/29/2024 9:47:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietThanhPhan](
	[MaSanPham] [varchar](10) NOT NULL,
	[MaNguyenLieu] [varchar](10) NOT NULL,
	[PhanTramNguyenLieu] [decimal](5, 2) NULL,
 CONSTRAINT [PK_CTTP] PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC,
	[MaNguyenLieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhGiaSanPham]    Script Date: 11/29/2024 9:47:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhGiaSanPham](
	[MaDanhGia] [varchar](10) NOT NULL,
	[MaSanPham] [varchar](10) NULL,
	[MoTa] [nvarchar](max) NULL,
	[XepHangTrungBinh] [decimal](5, 2) NULL,
	[TongDanhGia] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDanhGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DichVuKhachHang]    Script Date: 11/29/2024 9:47:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DichVuKhachHang](
	[MaDichVu] [varchar](10) NOT NULL,
	[MaSanPham] [varchar](10) NULL,
	[MoTa] [nvarchar](max) NULL,
	[DanhGiaHoTro] [decimal](5, 2) NULL,
	[ThoiGianBaoHanh] [int] NULL,
	[MucDoAnhHuong] [decimal](5, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDichVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoanhThu]    Script Date: 11/29/2024 9:47:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoanhThu](
	[MaDoanhThu] [varchar](10) NOT NULL,
	[MaLoaiDoanhThu] [varchar](10) NULL,
	[MoTa] [nvarchar](max) NULL,
	[SoTien] [decimal](18, 2) NULL,
	[ThoiGian] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDoanhThu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoBen]    Script Date: 11/29/2024 9:47:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoBen](
	[MaDoBen] [varchar](10) NOT NULL,
	[MaSanPham] [varchar](10) NULL,
	[TuoiThoNgay] [decimal](18, 2) NULL,
	[MoTa] [nvarchar](max) NULL,
	[DanhGiaDoBen] [decimal](5, 2) NULL,
	[MucDoAnhHuong] [decimal](5, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDoBen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiaCa]    Script Date: 11/29/2024 9:47:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiaCa](
	[MaGiaCa] [varchar](10) NOT NULL,
	[MaSanPham] [varchar](10) NULL,
	[MoTa] [nvarchar](max) NULL,
	[DanhGiaGiaTri] [decimal](5, 2) NULL,
	[ChiPhiBaoTri] [decimal](18, 2) NULL,
	[MucDoAnhHuong] [decimal](5, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaGiaCa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HieuSuat]    Script Date: 11/29/2024 9:47:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HieuSuat](
	[MaHieuSuat] [varchar](10) NOT NULL,
	[MaSanPham] [varchar](10) NULL,
	[MoTa] [nvarchar](max) NULL,
	[DanhGiaChucNang] [decimal](5, 2) NULL,
	[DanhGiaTocDo] [decimal](5, 2) NULL,
	[MucDoAnhHuong] [decimal](5, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHieuSuat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiChiPhi]    Script Date: 11/29/2024 9:47:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiChiPhi](
	[MaLoaiChiPhi] [varchar](10) NOT NULL,
	[TenLoaiChiPhi] [nvarchar](255) NULL,
	[MoTa] [nvarchar](max) NULL,
	[TongTien] [decimal](18, 2) NULL,
	[MaSanPham] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoaiChiPhi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiDoanhThu]    Script Date: 11/29/2024 9:47:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiDoanhThu](
	[MaLoaiDoanhThu] [varchar](10) NOT NULL,
	[TenLoaiDoanhThu] [nvarchar](255) NULL,
	[MoTa] [nvarchar](max) NULL,
	[TongTien] [decimal](18, 2) NULL,
	[MaSanPham] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoaiDoanhThu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoiNhuan]    Script Date: 11/29/2024 9:47:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoiNhuan](
	[MaLoiNhuan] [varchar](10) NOT NULL,
	[MaSanPham] [varchar](10) NULL,
	[MoTa] [nvarchar](max) NULL,
	[LoiNhuanGop] [decimal](18, 2) NULL,
	[LoiNhuanRong] [decimal](18, 2) NULL,
	[ThoiGian] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoiNhuan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguyenLieu]    Script Date: 11/29/2024 9:47:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguyenLieu](
	[MaNguyenLieu] [varchar](10) NOT NULL,
	[TenNguyenLieu] [nvarchar](255) NULL,
	[MoTa] [nvarchar](max) NULL,
	[DanhGiaChatLuong] [decimal](5, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNguyenLieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 11/29/2024 9:47:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [nvarchar](50) NOT NULL,
	[TenNhanVien] [nvarchar](255) NOT NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [nvarchar](3) NOT NULL,
	[SoDienThoai] [nvarchar](15) NULL,
	[Email] [nvarchar](255) NULL,
	[ChucVu] [nvarchar](255) NULL,
	[TaiKhoan] [nvarchar](255) NULL,
	[MatKhau] [nvarchar](255) NULL,
	[HinhAnh] [nvarchar](255) NULL,
	[TrangThaiHoatDong] [bit] NULL,
	[NgayTao] [date] NULL,
	[NgayCapNhat] [date] NULL,
	[DiaChi] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien_VaiTro]    Script Date: 11/29/2024 9:47:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien_VaiTro](
	[MaNhanVien] [nvarchar](50) NOT NULL,
	[MaVaiTro] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC,
	[MaVaiTro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanHoiNguoiDung]    Script Date: 11/29/2024 9:47:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanHoiNguoiDung](
	[MaPhanHoi] [varchar](10) NOT NULL,
	[MaSanPham] [varchar](10) NULL,
	[XepHangNguoiDung] [int] NULL,
	[BinhLuan] [nvarchar](max) NULL,
	[NgayPhanHoi] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhanHoi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanTichDoiSoat]    Script Date: 11/29/2024 9:47:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanTichDoiSoat](
	[MaPhanTich] [varchar](10) NOT NULL,
	[LoaiPhanTich] [nvarchar](255) NULL,
	[MoTa] [nvarchar](max) NULL,
	[GiaTri] [decimal](18, 2) NULL,
	[ThoiGian] [datetime] NULL,
	[MaSanPham] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhanTich] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quyen]    Script Date: 11/29/2024 9:47:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quyen](
	[MaQuyen] [nvarchar](50) NOT NULL,
	[TenQuyen] [nvarchar](50) NOT NULL,
	[MoTa] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaQuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 11/29/2024 9:47:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSanPham] [varchar](10) NOT NULL,
	[TenSanPham] [nvarchar](255) NOT NULL,
	[MoTa] [nvarchar](max) NULL,
	[Gia] [decimal](18, 0) NULL,
	[DanhMuc] [nvarchar](100) NULL,
	[SoLuongTon] [int] NULL,
	[NgayPhatHanh] [datetime] NULL,
	[MucDoAnhHuongTongNguyenLieu] [decimal](5, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThietKe]    Script Date: 11/29/2024 9:47:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThietKe](
	[MaThietKe] [varchar](10) NOT NULL,
	[MaSanPham] [varchar](10) NULL,
	[MoTa] [nvarchar](max) NULL,
	[DanhGiaThamMy] [decimal](5, 2) NULL,
	[DanhGiaTienDung] [decimal](5, 2) NULL,
	[MucDoAnhHuong] [decimal](5, 2) NULL,
	[HinhAnh] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaThietKe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThiTruong]    Script Date: 11/29/2024 9:47:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThiTruong](
	[MaThiTruong] [varchar](10) NOT NULL,
	[LoaiThiTruong] [nvarchar](255) NULL,
	[MoTa] [nvarchar](max) NULL,
	[GiaTri] [decimal](18, 2) NULL,
	[ThoiGian] [datetime] NULL,
	[MaSanPham] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaThiTruong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TinhNangBoSung]    Script Date: 11/29/2024 9:47:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TinhNangBoSung](
	[MaTinhNang] [varchar](10) NOT NULL,
	[MaSanPham] [varchar](10) NULL,
	[MoTa] [nvarchar](max) NULL,
	[DanhGiaCongNghe] [decimal](5, 2) NULL,
	[DanhGiaLinhHoat] [decimal](5, 2) NULL,
	[MucDoAnhHuong] [decimal](5, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTinhNang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VaiTro]    Script Date: 11/29/2024 9:47:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VaiTro](
	[MaVaiTro] [nvarchar](50) NOT NULL,
	[TenVaiTro] [nvarchar](50) NOT NULL,
	[MoTa] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaVaiTro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VaiTro_Quyen]    Script Date: 11/29/2024 9:47:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VaiTro_Quyen](
	[MaVaiTro] [nvarchar](50) NOT NULL,
	[MaQuyen] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaVaiTro] ASC,
	[MaQuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[BenVung] ([MaBenVung], [MaSanPham], [MoTa], [DanhGiaAnhHuongMoiTruong], [DanhGiaAnToan], [MucDoAnhHuong]) VALUES (N'BV001', N'SP001', N'Tác động môi trường:
Bao bì giấy tái chế: Bao bì Tetra Pak giúp giảm thiểu lượng nhựa sử dụng trong ngành thực phẩm và đồ uống, góp phần bảo vệ môi trường.
Quy trình sản xuất tiết kiệm năng lượng: Sản phẩm được sản xuất với quy trình tiết kiệm năng lượng và giảm thiểu phát thải CO2.
Thân thiện với người dùng:
Không chứa chất phụ gia: Sản phẩm không chứa các chất phụ gia, phẩm màu nhân tạo hay hóa chất độc hại, an toàn tuyệt đối cho mọi lứa tuổi.
Không có đường hóa học: Sản phẩm không chứa đường hóa học, phù hợp cho những người ăn kiêng hoặc mắc các bệnh về đường huyết.
', CAST(9.00 AS Decimal(5, 2)), CAST(8.00 AS Decimal(5, 2)), CAST(8.00 AS Decimal(5, 2)))
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPBD15', N'Nguyên liệu đầu vào', CAST(1200000000.00 AS Decimal(18, 2)), CAST(N'2024-07-01T00:00:00.000' AS DateTime), N'CPBD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPBD16', N'Chi phí vận chuyển', CAST(350000000.00 AS Decimal(18, 2)), CAST(N'2024-07-01T00:00:00.000' AS DateTime), N'CPBD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPBD17', N'Chi phí marketing', CAST(220000000.00 AS Decimal(18, 2)), CAST(N'2024-07-01T00:00:00.000' AS DateTime), N'CPBD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPBD18', N'Chi phí đóng gói sản phẩm', CAST(160000000.00 AS Decimal(18, 2)), CAST(N'2024-07-01T00:00:00.000' AS DateTime), N'CPBD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPBD25', N'Nguyên liệu đầu vào', CAST(1100000000.00 AS Decimal(18, 2)), CAST(N'2024-08-01T00:00:00.000' AS DateTime), N'CPBD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPBD26', N'Chi phí vận chuyển', CAST(350000000.00 AS Decimal(18, 2)), CAST(N'2024-08-01T00:00:00.000' AS DateTime), N'CPBD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPBD27', N'Chi phí marketing', CAST(220000000.00 AS Decimal(18, 2)), CAST(N'2024-08-01T00:00:00.000' AS DateTime), N'CPBD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPBD28', N'Chi phí đóng gói sản phẩm', CAST(160000000.00 AS Decimal(18, 2)), CAST(N'2024-08-01T00:00:00.000' AS DateTime), N'CPBD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPBD35', N'Nguyên liệu đầu vào', CAST(1100000000.00 AS Decimal(18, 2)), CAST(N'2024-09-01T00:00:00.000' AS DateTime), N'CPBD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPBD36', N'Chi phí vận chuyển', CAST(350000000.00 AS Decimal(18, 2)), CAST(N'2024-09-01T00:00:00.000' AS DateTime), N'CPBD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPBD37', N'Chi phí marketing', CAST(220000000.00 AS Decimal(18, 2)), CAST(N'2024-09-01T00:00:00.000' AS DateTime), N'CPBD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPBD38', N'Chi phí đóng gói sản phẩm', CAST(160000000.00 AS Decimal(18, 2)), CAST(N'2024-09-01T00:00:00.000' AS DateTime), N'CPBD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPBD45', N'Nguyên liệu đầu vào', CAST(1100000000.00 AS Decimal(18, 2)), CAST(N'2024-10-01T00:00:00.000' AS DateTime), N'CPBD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPBD46', N'Chi phí vận chuyển', CAST(350000000.00 AS Decimal(18, 2)), CAST(N'2024-10-01T00:00:00.000' AS DateTime), N'CPBD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPBD47', N'Chi phí marketing', CAST(220000000.00 AS Decimal(18, 2)), CAST(N'2024-10-01T00:00:00.000' AS DateTime), N'CPBD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPBD48', N'Chi phí đóng gói sản phẩm', CAST(160000000.00 AS Decimal(18, 2)), CAST(N'2024-10-01T00:00:00.000' AS DateTime), N'CPBD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPBD5', N'Nguyên liệu đầu vào', CAST(1100000000.00 AS Decimal(18, 2)), CAST(N'2024-06-01T00:00:00.000' AS DateTime), N'CPBD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPBD55', N'Nguyên liệu đầu vào', CAST(1100000000.00 AS Decimal(18, 2)), CAST(N'2024-11-01T00:00:00.000' AS DateTime), N'CPBD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPBD56', N'Chi phí vận chuyển', CAST(350000000.00 AS Decimal(18, 2)), CAST(N'2024-11-01T00:00:00.000' AS DateTime), N'CPBD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPBD57', N'Chi phí marketing', CAST(220000000.00 AS Decimal(18, 2)), CAST(N'2024-11-01T00:00:00.000' AS DateTime), N'CPBD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPBD58', N'Chi phí đóng gói sản phẩm', CAST(160000000.00 AS Decimal(18, 2)), CAST(N'2024-11-01T00:00:00.000' AS DateTime), N'CPBD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPBD6', N'Chi phí vận chuyển', CAST(350000000.00 AS Decimal(18, 2)), CAST(N'2024-06-01T00:00:00.000' AS DateTime), N'CPBD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPBD7', N'Chi phí marketing', CAST(220000000.00 AS Decimal(18, 2)), CAST(N'2024-06-01T00:00:00.000' AS DateTime), N'CPBD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPBD8', N'Chi phí đóng gói sản phẩm', CAST(160000000.00 AS Decimal(18, 2)), CAST(N'2024-06-01T00:00:00.000' AS DateTime), N'CPBD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPCD1', N'Chi phí thuê mặt bằng', CAST(275000000.00 AS Decimal(18, 2)), CAST(N'2024-06-01T00:00:00.000' AS DateTime), N'CPCD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPCD11', N'Chi phí thuê mặt bằng', CAST(275000000.00 AS Decimal(18, 2)), CAST(N'2024-07-01T00:00:00.000' AS DateTime), N'CPCD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPCD12', N'Lương nhân viên', CAST(420000000.00 AS Decimal(18, 2)), CAST(N'2024-07-01T00:00:00.000' AS DateTime), N'CPCD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPCD13', N'Chi phí bảo trì thiết bị', CAST(175000000.00 AS Decimal(18, 2)), CAST(N'2024-07-01T00:00:00.000' AS DateTime), N'CPCD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPCD14', N'Chi phí bảo hiểm', CAST(195000000.00 AS Decimal(18, 2)), CAST(N'2024-07-01T00:00:00.000' AS DateTime), N'CPCD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPCD2', N'Lương nhân viên', CAST(420000000.00 AS Decimal(18, 2)), CAST(N'2024-06-01T00:00:00.000' AS DateTime), N'CPCD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPCD21', N'Chi phí thuê mặt bằng', CAST(275000000.00 AS Decimal(18, 2)), CAST(N'2024-08-01T00:00:00.000' AS DateTime), N'CPCD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPCD22', N'Lương nhân viên', CAST(420000000.00 AS Decimal(18, 2)), CAST(N'2024-08-01T00:00:00.000' AS DateTime), N'CPCD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPCD23', N'Chi phí bảo trì thiết bị', CAST(175000000.00 AS Decimal(18, 2)), CAST(N'2024-08-01T00:00:00.000' AS DateTime), N'CPCD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPCD24', N'Chi phí bảo hiểm', CAST(195000000.00 AS Decimal(18, 2)), CAST(N'2024-08-01T00:00:00.000' AS DateTime), N'CPCD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPCD3', N'Chi phí bảo trì thiết bị', CAST(175000000.00 AS Decimal(18, 2)), CAST(N'2024-06-01T00:00:00.000' AS DateTime), N'CPCD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPCD31', N'Chi phí thuê mặt bằng', CAST(275000000.00 AS Decimal(18, 2)), CAST(N'2024-09-01T00:00:00.000' AS DateTime), N'CPCD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPCD32', N'Lương nhân viên', CAST(420000000.00 AS Decimal(18, 2)), CAST(N'2024-09-01T00:00:00.000' AS DateTime), N'CPCD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPCD33', N'Chi phí bảo trì thiết bị', CAST(175000000.00 AS Decimal(18, 2)), CAST(N'2024-09-01T00:00:00.000' AS DateTime), N'CPCD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPCD34', N'Chi phí bảo hiểm', CAST(195000000.00 AS Decimal(18, 2)), CAST(N'2024-09-01T00:00:00.000' AS DateTime), N'CPCD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPCD4', N'Chi phí bảo hiểm', CAST(195000000.00 AS Decimal(18, 2)), CAST(N'2024-06-01T00:00:00.000' AS DateTime), N'CPCD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPCD41', N'Chi phí thuê mặt bằng', CAST(275000000.00 AS Decimal(18, 2)), CAST(N'2024-10-01T00:00:00.000' AS DateTime), N'CPCD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPCD42', N'Lương nhân viên', CAST(420000000.00 AS Decimal(18, 2)), CAST(N'2024-10-01T00:00:00.000' AS DateTime), N'CPCD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPCD43', N'Chi phí bảo trì thiết bị', CAST(175000000.00 AS Decimal(18, 2)), CAST(N'2024-10-01T00:00:00.000' AS DateTime), N'CPCD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPCD44', N'Chi phí bảo hiểm', CAST(195000000.00 AS Decimal(18, 2)), CAST(N'2024-10-01T00:00:00.000' AS DateTime), N'CPCD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPCD51', N'Chi phí thuê mặt bằng', CAST(275000000.00 AS Decimal(18, 2)), CAST(N'2024-11-01T00:00:00.000' AS DateTime), N'CPCD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPCD52', N'Lương nhân viên', CAST(420000000.00 AS Decimal(18, 2)), CAST(N'2024-11-01T00:00:00.000' AS DateTime), N'CPCD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPCD53', N'Chi phí bảo trì thiết bị', CAST(175000000.00 AS Decimal(18, 2)), CAST(N'2024-11-01T00:00:00.000' AS DateTime), N'CPCD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPCD54', N'Chi phí bảo hiểm', CAST(195000000.00 AS Decimal(18, 2)), CAST(N'2024-11-01T00:00:00.000' AS DateTime), N'CPCD')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPGT10', N'Chi phí điện, nước, văn phòng', CAST(280000000.00 AS Decimal(18, 2)), CAST(N'2024-06-01T00:00:00.000' AS DateTime), N'CPGT')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPGT19', N'Chi phí hành chính', CAST(280000000.00 AS Decimal(18, 2)), CAST(N'2024-07-01T00:00:00.000' AS DateTime), N'CPGT')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPGT20', N'Chi phí điện, nước, văn phòng', CAST(280000000.00 AS Decimal(18, 2)), CAST(N'2024-07-01T00:00:00.000' AS DateTime), N'CPGT')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPGT29', N'Chi phí hành chính', CAST(280000000.00 AS Decimal(18, 2)), CAST(N'2024-08-01T00:00:00.000' AS DateTime), N'CPGT')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPGT30', N'Chi phí điện, nước, văn phòng', CAST(280000000.00 AS Decimal(18, 2)), CAST(N'2024-08-01T00:00:00.000' AS DateTime), N'CPGT')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPGT39', N'Chi phí hành chính', CAST(280000000.00 AS Decimal(18, 2)), CAST(N'2024-09-01T00:00:00.000' AS DateTime), N'CPGT')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPGT40', N'Chi phí điện, nước, văn phòng', CAST(280000000.00 AS Decimal(18, 2)), CAST(N'2024-09-01T00:00:00.000' AS DateTime), N'CPGT')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPGT49', N'Chi phí hành chính', CAST(280000000.00 AS Decimal(18, 2)), CAST(N'2024-10-01T00:00:00.000' AS DateTime), N'CPGT')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPGT50', N'Chi phí điện, nước, văn phòng', CAST(280000000.00 AS Decimal(18, 2)), CAST(N'2024-10-01T00:00:00.000' AS DateTime), N'CPGT')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPGT59', N'Chi phí hành chính', CAST(280000000.00 AS Decimal(18, 2)), CAST(N'2024-11-01T00:00:00.000' AS DateTime), N'CPGT')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPGT60', N'Chi phí điện, nước, văn phòng', CAST(280000000.00 AS Decimal(18, 2)), CAST(N'2024-11-01T00:00:00.000' AS DateTime), N'CPGT')
GO
INSERT [dbo].[ChiPhi] ([MaChiPhi], [MoTa], [SoTien], [ThoiGian], [MaLoaiChiPhi]) VALUES (N'CPGT9', N'Chi phí hành chính', CAST(280000000.00 AS Decimal(18, 2)), CAST(N'2024-06-01T00:00:00.000' AS DateTime), N'CPGT')
GO
INSERT [dbo].[ChiTietThanhPhan] ([MaSanPham], [MaNguyenLieu], [PhanTramNguyenLieu]) VALUES (N'SP001', N'NL001', CAST(79.60 AS Decimal(5, 2)))
GO
INSERT [dbo].[ChiTietThanhPhan] ([MaSanPham], [MaNguyenLieu], [PhanTramNguyenLieu]) VALUES (N'SP001', N'NL002', CAST(10.20 AS Decimal(5, 2)))
GO
INSERT [dbo].[ChiTietThanhPhan] ([MaSanPham], [MaNguyenLieu], [PhanTramNguyenLieu]) VALUES (N'SP001', N'NL003', CAST(7.60 AS Decimal(5, 2)))
GO
INSERT [dbo].[ChiTietThanhPhan] ([MaSanPham], [MaNguyenLieu], [PhanTramNguyenLieu]) VALUES (N'SP001', N'NL004', CAST(2.00 AS Decimal(5, 2)))
GO
INSERT [dbo].[ChiTietThanhPhan] ([MaSanPham], [MaNguyenLieu], [PhanTramNguyenLieu]) VALUES (N'SP001', N'NL005', CAST(0.50 AS Decimal(5, 2)))
GO
INSERT [dbo].[DanhGiaSanPham] ([MaDanhGia], [MaSanPham], [MoTa], [XepHangTrungBinh], [TongDanhGia]) VALUES (N'DG001', N'SP001', NULL, CAST(4.80 AS Decimal(5, 2)), 1000)
GO
INSERT [dbo].[DichVuKhachHang] ([MaDichVu], [MaSanPham], [MoTa], [DanhGiaHoTro], [ThoiGianBaoHanh], [MucDoAnhHuong]) VALUES (N'DV001', N'SP001', N'Chính sách đổi trả: Chính sách đổi trả linh hoạt trong vòng 30 ngày nếu sản phẩm gặp vấn đề về chất lượng, đảm bảo quyền lợi cho người tiêu dùng.
Dịch vụ chăm sóc khách hàng: Chính sách hỗ trợ qua hotline và các kênh trực tuyến giúp giải đáp thắc mắc và hỗ trợ khách hàng khi cần thiết.
Tiêu chuẩn chất lượng: Sản phẩm tuân thủ các tiêu chuẩn chất lượng thực phẩm do Bộ Y tế Việt Nam quy định.
Mã QR truy xuất nguồn gốc: Mỗi lô sản phẩm đều có mã QR giúp khách hàng dễ dàng kiểm tra nguồn gốc và ngày sản xuất của sản phẩm.
', CAST(9.00 AS Decimal(5, 2)), 12, CAST(7.50 AS Decimal(5, 2)))
GO
INSERT [dbo].[DoanhThu] ([MaDoanhThu], [MaLoaiDoanhThu], [MoTa], [SoTien], [ThoiGian]) VALUES (N'DT006', N'DT1', N'Doanh thu bán trực tiếp tháng 6', CAST(1800000000.00 AS Decimal(18, 2)), CAST(N'2024-06-30T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DoanhThu] ([MaDoanhThu], [MaLoaiDoanhThu], [MoTa], [SoTien], [ThoiGian]) VALUES (N'DT007', N'DT1', N'Doanh thu bán trực tiếp tháng 7', CAST(2000000000.00 AS Decimal(18, 2)), CAST(N'2024-07-30T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DoanhThu] ([MaDoanhThu], [MaLoaiDoanhThu], [MoTa], [SoTien], [ThoiGian]) VALUES (N'DT008', N'DT1', N'Doanh thu bán trực tiếp tháng 8', CAST(2200000000.00 AS Decimal(18, 2)), CAST(N'2024-08-30T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DoanhThu] ([MaDoanhThu], [MaLoaiDoanhThu], [MoTa], [SoTien], [ThoiGian]) VALUES (N'DT009', N'DT1', N'Doanh thu bán trực tiếp tháng 9', CAST(2400000000.00 AS Decimal(18, 2)), CAST(N'2024-09-30T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DoanhThu] ([MaDoanhThu], [MaLoaiDoanhThu], [MoTa], [SoTien], [ThoiGian]) VALUES (N'DT010', N'DT1', N'Doanh thu bán trực tiếp tháng 10', CAST(2600000000.00 AS Decimal(18, 2)), CAST(N'2024-10-30T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DoanhThu] ([MaDoanhThu], [MaLoaiDoanhThu], [MoTa], [SoTien], [ThoiGian]) VALUES (N'DT011', N'DT1', N'Doanh thu bán trực tiếp tháng 11', CAST(2800000000.00 AS Decimal(18, 2)), CAST(N'2024-11-30T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DoanhThu] ([MaDoanhThu], [MaLoaiDoanhThu], [MoTa], [SoTien], [ThoiGian]) VALUES (N'DT012', N'DT2', N'Doanh thu bán trực tuyến tháng 6', CAST(1000000000.00 AS Decimal(18, 2)), CAST(N'2024-06-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DoanhThu] ([MaDoanhThu], [MaLoaiDoanhThu], [MoTa], [SoTien], [ThoiGian]) VALUES (N'DT013', N'DT2', N'Doanh thu bán trực tuyến tháng 7', CAST(1100000000.00 AS Decimal(18, 2)), CAST(N'2024-07-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DoanhThu] ([MaDoanhThu], [MaLoaiDoanhThu], [MoTa], [SoTien], [ThoiGian]) VALUES (N'DT014', N'DT2', N'Doanh thu bán trực tuyến tháng 8', CAST(1200000000.00 AS Decimal(18, 2)), CAST(N'2024-08-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DoanhThu] ([MaDoanhThu], [MaLoaiDoanhThu], [MoTa], [SoTien], [ThoiGian]) VALUES (N'DT015', N'DT2', N'Doanh thu bán trực tuyến tháng 9', CAST(1300000000.00 AS Decimal(18, 2)), CAST(N'2024-09-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DoanhThu] ([MaDoanhThu], [MaLoaiDoanhThu], [MoTa], [SoTien], [ThoiGian]) VALUES (N'DT016', N'DT2', N'Doanh thu bán trực tuyến tháng 10', CAST(1400000000.00 AS Decimal(18, 2)), CAST(N'2024-10-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DoanhThu] ([MaDoanhThu], [MaLoaiDoanhThu], [MoTa], [SoTien], [ThoiGian]) VALUES (N'DT017', N'DT2', N'Doanh thu bán trực tuyến tháng 11', CAST(1500000000.00 AS Decimal(18, 2)), CAST(N'2024-11-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DoanhThu] ([MaDoanhThu], [MaLoaiDoanhThu], [MoTa], [SoTien], [ThoiGian]) VALUES (N'DT018', N'DT3', N'Doanh thu bán qua đối tác phân phối tháng 6', CAST(900000000.00 AS Decimal(18, 2)), CAST(N'2024-06-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DoanhThu] ([MaDoanhThu], [MaLoaiDoanhThu], [MoTa], [SoTien], [ThoiGian]) VALUES (N'DT019', N'DT3', N'Doanh thu bán qua đối tác phân phối tháng 7', CAST(1100000000.00 AS Decimal(18, 2)), CAST(N'2024-07-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DoanhThu] ([MaDoanhThu], [MaLoaiDoanhThu], [MoTa], [SoTien], [ThoiGian]) VALUES (N'DT020', N'DT3', N'Doanh thu bán qua đối tác phân phối tháng 8', CAST(1400000000.00 AS Decimal(18, 2)), CAST(N'2024-08-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DoanhThu] ([MaDoanhThu], [MaLoaiDoanhThu], [MoTa], [SoTien], [ThoiGian]) VALUES (N'DT021', N'DT3', N'Doanh thu bán qua đối tác phân phối tháng 9', CAST(1600000000.00 AS Decimal(18, 2)), CAST(N'2024-09-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DoanhThu] ([MaDoanhThu], [MaLoaiDoanhThu], [MoTa], [SoTien], [ThoiGian]) VALUES (N'DT022', N'DT3', N'Doanh thu bán qua đối tác phân phối tháng 10', CAST(1700000000.00 AS Decimal(18, 2)), CAST(N'2024-10-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DoanhThu] ([MaDoanhThu], [MaLoaiDoanhThu], [MoTa], [SoTien], [ThoiGian]) VALUES (N'DT023', N'DT3', N'Doanh thu bán qua đối tác phân phối tháng 11', CAST(1800000000.00 AS Decimal(18, 2)), CAST(N'2024-11-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DoanhThu] ([MaDoanhThu], [MaLoaiDoanhThu], [MoTa], [SoTien], [ThoiGian]) VALUES (N'DTDT01', N'DT3', N'Doanh thu từ đối tác tháng 12', CAST(2000000000.00 AS Decimal(18, 2)), CAST(N'2024-12-01T19:43:21.000' AS DateTime))
GO
INSERT [dbo].[DoBen] ([MaDoBen], [MaSanPham], [TuoiThoNgay], [MoTa], [DanhGiaDoBen], [MucDoAnhHuong]) VALUES (N'DB001', N'SP001', CAST(6.00 AS Decimal(18, 2)), N'Bao bì Tetra Pak cao cấp không chỉ giúp bảo quản nước ép mà còn đảm bảo chất lượng và độ tươi mới của sản phẩm trong suốt thời gian sử dụng. Tetra Pak là một giải pháp bao bì bảo vệ hiệu quả, với cấu trúc bao bì bao gồm các lớp vật liệu khác nhau, trong đó có giấy và nhựa PE (polyethylene), mang lại những đặc điểm ưu việt:
Chất liệu bao bì Tetra Pak:
1.	Giấy tái chế: Lớp giấy bên ngoài của Tetra Pak được làm từ giấy tái chế, giúp giảm thiểu tác động tiêu cực đến môi trường, đồng thời mang lại tính năng bảo vệ tối ưu cho sản phẩm bên trong. Việc sử dụng giấy tái chế giúp giảm lượng rác thải và khối lượng chất thải từ bao bì.
2.	Nhựa PE (Polyethylene): Nhựa PE được sử dụng trong các lớp bao bì Tetra Pak để tạo ra tính năng chống thấm và bảo vệ chất lỏng khỏi sự tác động của ánh sáng và không khí, giúp kéo dài thời gian bảo quản sản phẩm. Lớp nhựa này giúp giữ cho nước ép luôn tươi ngon mà không cần thêm chất bảo quản.
Ưu điểm của bao bì Tetra Pak:
•	Chống vi khuẩn: Bao bì Tetra Pak giúp giữ nước ép an toàn bằng cách bảo vệ khỏi các tác nhân gây hại từ bên ngoài, bao gồm cả vi khuẩn, mà không cần đến chất bảo quản nhân tạo.
•	Giữ nguyên dinh dưỡng: Bao bì giúp bảo vệ các vitamin và khoáng chất có trong nước ép, giữ nguyên hương vị và dinh dưỡng trong suốt thời gian bảo quản.
•	Thân thiện với môi trường: Lớp giấy tái chế và khả năng tái chế cao của bao bì giúp giảm thiểu lượng rác thải nhựa, bảo vệ môi trường.
Thời gian bảo quản:
Sản phẩm có thể được bảo quản ở nhiệt độ phòng trong thời gian dài lên đến 6 tháng, nhưng vẫn giữ được chất lượng, hương vị và dinh dưỡng tối ưu, nhờ vào cấu trúc bảo vệ tuyệt vời của bao bì Tetra Pak.
Với bao bì này, người tiêu dùng có thể yên tâm về sự an toàn, bảo quản chất lượng sản phẩm, đồng thời góp phần vào bảo vệ môi trường.
', CAST(9.00 AS Decimal(5, 2)), CAST(8.50 AS Decimal(5, 2)))
GO
INSERT [dbo].[GiaCa] ([MaGiaCa], [MaSanPham], [MoTa], [DanhGiaGiaTri], [ChiPhiBaoTri], [MucDoAnhHuong]) VALUES (N'GC001', N'SP001', N'Mức giá cạnh tranh. Đây là mức giá hợp lý và cạnh tranh, đặc biệt khi so với các sản phẩm nhập khẩu có giá thành cao hơn. Chất lượng của sản phẩm không thua kém bất kỳ thương hiệu nổi tiếng nào trên thị trường, với thành phần 100% từ trái cây tự nhiên, không có chất bảo quản hay phẩm màu nhân tạo.
Giá hợp lý: Mức giá này giúp sản phẩm dễ dàng tiếp cận với nhiều đối tượng người tiêu dùng, đặc biệt là các gia đình có trẻ em hoặc những người quan tâm đến sức khỏe. Với giá thành này, người tiêu dùng không chỉ mua được sản phẩm chất lượng mà còn yên tâm về sự an toàn và nguồn gốc nguyên liệu tự nhiên của nước ép.
', CAST(8.00 AS Decimal(5, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(6.50 AS Decimal(5, 2)))
GO
INSERT [dbo].[HieuSuat] ([MaHieuSuat], [MaSanPham], [MoTa], [DanhGiaChucNang], [DanhGiaTocDo], [MucDoAnhHuong]) VALUES (N'HS001', N'SP001', N'Chức năng:
Lợi ích sức khỏe: Nước ép lựu táo Vinamilk cung cấp lượng vitamin C cần thiết cho cơ thể, giúp tăng cường sức đề kháng và hỗ trợ hệ miễn dịch.
Chất chống oxy hóa: Lựu và táo là những trái cây giàu chất chống oxy hóa, giúp bảo vệ cơ thể khỏi tác động của các gốc tự do và lão hóa.
Tiện lợi: Sản phẩm là lựa chọn lý tưởng cho những người muốn bổ sung dưỡng chất từ thiên nhiên một cách nhanh chóng và hiệu quả, đặc biệt cho những người có cuộc sống bận rộn.
Tốc độ:
Sẵn sàng sử dụng: Sản phẩm có thể uống ngay khi mở nắp, không cần pha chế hay chuẩn bị gì thêm, giúp tiết kiệm thời gian cho người tiêu dùng.
', CAST(8.00 AS Decimal(5, 2)), CAST(8.00 AS Decimal(5, 2)), CAST(7.50 AS Decimal(5, 2)))
GO
INSERT [dbo].[LoaiChiPhi] ([MaLoaiChiPhi], [TenLoaiChiPhi], [MoTa], [TongTien], [MaSanPham]) VALUES (N'CPBD', N'Chi phí biến đổi', N'Chi phí thay đổi tùy theo khối lượng sản xuất, doanh thu hoặc hoạt động.', CAST(15570000000.00 AS Decimal(18, 2)), N'SP001')
GO
INSERT [dbo].[LoaiChiPhi] ([MaLoaiChiPhi], [TenLoaiChiPhi], [MoTa], [TongTien], [MaSanPham]) VALUES (N'CPCD', N'Chi phí cố định', N'Chi phí không thay đổi theo sản lượng hay doanh thu.', CAST(7000000000.00 AS Decimal(18, 2)), N'SP001')
GO
INSERT [dbo].[LoaiChiPhi] ([MaLoaiChiPhi], [TenLoaiChiPhi], [MoTa], [TongTien], [MaSanPham]) VALUES (N'CPGT', N'Chi phí gián tiếp', N'Chi phí không trực tiếp liên quan đến sản xuất nhưng cần thiết để duy trì hoạt động.', CAST(4000000000.00 AS Decimal(18, 2)), N'SP001')
GO
INSERT [dbo].[LoaiDoanhThu] ([MaLoaiDoanhThu], [TenLoaiDoanhThu], [MoTa], [TongTien], [MaSanPham]) VALUES (N'DT1', N'Doanh thu bán trực tiếp', N'Doanh thu từ việc bán hàng trực tiếp tại cửa hàng', CAST(1800000000.00 AS Decimal(18, 2)), N'SP001')
GO
INSERT [dbo].[LoaiDoanhThu] ([MaLoaiDoanhThu], [TenLoaiDoanhThu], [MoTa], [TongTien], [MaSanPham]) VALUES (N'DT2', N'Doanh thu bán trực tuyến', N'Doanh thu từ việc bán hàng qua các kênh trực tuyến', CAST(1200000000.00 AS Decimal(18, 2)), N'SP001')
GO
INSERT [dbo].[LoaiDoanhThu] ([MaLoaiDoanhThu], [TenLoaiDoanhThu], [MoTa], [TongTien], [MaSanPham]) VALUES (N'DT3', N'Doanh thu bán qua đối tác phân phối', N'Doanh thu từ việc bán hàng qua các đối tác phân phối', CAST(900000000.00 AS Decimal(18, 2)), N'SP001')
GO
INSERT [dbo].[LoiNhuan] ([MaLoiNhuan], [MaSanPham], [MoTa], [LoiNhuanGop], [LoiNhuanRong], [ThoiGian]) VALUES (N'LN1', N'SP001', N'', CAST(1970000000.00 AS Decimal(18, 2)), CAST(345000000.00 AS Decimal(18, 2)), CAST(N'2024-06-30T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[LoiNhuan] ([MaLoiNhuan], [MaSanPham], [MoTa], [LoiNhuanGop], [LoiNhuanRong], [ThoiGian]) VALUES (N'LN2', N'SP001', N'', CAST(2570000000.00 AS Decimal(18, 2)), CAST(945000000.00 AS Decimal(18, 2)), CAST(N'2024-07-30T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[LoiNhuan] ([MaLoiNhuan], [MaSanPham], [MoTa], [LoiNhuanGop], [LoiNhuanRong], [ThoiGian]) VALUES (N'LN3', N'SP001', N'', CAST(3470000000.00 AS Decimal(18, 2)), CAST(1845000000.00 AS Decimal(18, 2)), CAST(N'2024-08-30T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[LoiNhuan] ([MaLoiNhuan], [MaSanPham], [MoTa], [LoiNhuanGop], [LoiNhuanRong], [ThoiGian]) VALUES (N'LN4', N'SP001', N'', CAST(4070000000.00 AS Decimal(18, 2)), CAST(2445000000.00 AS Decimal(18, 2)), CAST(N'2024-09-30T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[LoiNhuan] ([MaLoiNhuan], [MaSanPham], [MoTa], [LoiNhuanGop], [LoiNhuanRong], [ThoiGian]) VALUES (N'LN5', N'SP001', NULL, CAST(2277000000.00 AS Decimal(18, 2)), CAST(1380000000.00 AS Decimal(18, 2)), CAST(N'2024-10-30T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[LoiNhuan] ([MaLoiNhuan], [MaSanPham], [MoTa], [LoiNhuanGop], [LoiNhuanRong], [ThoiGian]) VALUES (N'LN6', N'SP001', N'', CAST(4970000000.00 AS Decimal(18, 2)), CAST(3345000000.00 AS Decimal(18, 2)), CAST(N'2024-11-30T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [MoTa], [DanhGiaChatLuong]) VALUES (N'NL001', N'Nước', N'Thành phần chính giúp hòa tan và làm loãng nước ép, mang lại hương vị tươi mát.', CAST(10.00 AS Decimal(5, 2)))
GO
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [MoTa], [DanhGiaChatLuong]) VALUES (N'NL002', N'Nước ép táo cô đặc', N'Cung cấp hương vị ngọt tự nhiên và nhiều vitamin, đặc biệt là vitamin C và chất xơ.', CAST(9.00 AS Decimal(5, 2)))
GO
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [MoTa], [DanhGiaChatLuong]) VALUES (N'NL003', N'Nước ép lựu cô đặc', N'Lựu mang lại vitamin C, chất chống oxy hóa và hỗ trợ sức khỏe tim mạch.', CAST(10.00 AS Decimal(5, 2)))
GO
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [MoTa], [DanhGiaChatLuong]) VALUES (N'NL004', N'Chiết xuất cà rốt tím', N'Tạo màu sắc tự nhiên và cung cấp thêm các vitamin A, beta-carotene và chất chống oxy hóa.', CAST(8.00 AS Decimal(5, 2)))
GO
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [MoTa], [DanhGiaChatLuong]) VALUES (N'NL005', N'Hương liệu giống tự nhiên', N'Hương liệu này giúp gia tăng mùi vị tự nhiên, mang lại trải nghiệm thơm ngon cho sản phẩm.', CAST(7.00 AS Decimal(5, 2)))
GO
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [NgaySinh], [GioiTinh], [SoDienThoai], [Email], [ChucVu], [TaiKhoan], [MatKhau], [HinhAnh], [TrangThaiHoatDong], [NgayTao], [NgayCapNhat], [DiaChi]) VALUES (N'NV001', N'Phạm Quang Duy', CAST(N'1990-02-10' AS Date), N'Nam', N'0123456789', N'phamduy@example.com', N'Quản lý kho', N'admin', N'admin', N'NV001.png', 1, CAST(N'2023-05-10' AS Date), CAST(N'2024-11-17' AS Date), N'123 Đường Nguyễn Trãi, Hà Nội')
GO
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [NgaySinh], [GioiTinh], [SoDienThoai], [Email], [ChucVu], [TaiKhoan], [MatKhau], [HinhAnh], [TrangThaiHoatDong], [NgayTao], [NgayCapNhat], [DiaChi]) VALUES (N'NV002', N'Hoàng Thị Mai', CAST(N'1993-08-25' AS Date), N'Nữ', N'0987654321', N'hoangmai@example.com', N'Nhân viên bán hàng', N'admin1', N'admin1', N'NV002.png', 1, CAST(N'2023-05-22' AS Date), CAST(N'2024-11-17' AS Date), N'456 Đường Lý Thường Kiệt, TP HCM')
GO
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [NgaySinh], [GioiTinh], [SoDienThoai], [Email], [ChucVu], [TaiKhoan], [MatKhau], [HinhAnh], [TrangThaiHoatDong], [NgayTao], [NgayCapNhat], [DiaChi]) VALUES (N'NV003', N'Trần Quốc Duy', CAST(N'1987-11-05' AS Date), N'Nam', N'0912345678', N'tranquocduy@example.com', N'Nhân viên thu ngân', N'admin123', N'admin123', N'NV003.png', 1, CAST(N'2023-05-22' AS Date), CAST(N'2024-11-17' AS Date), N'789 Đường Hoàng Diệu, Đà Nẵng')
GO
INSERT [dbo].[NhanVien_VaiTro] ([MaNhanVien], [MaVaiTro]) VALUES (N'NV001', N'VT001')
GO
INSERT [dbo].[NhanVien_VaiTro] ([MaNhanVien], [MaVaiTro]) VALUES (N'NV001', N'VT002')
GO
INSERT [dbo].[NhanVien_VaiTro] ([MaNhanVien], [MaVaiTro]) VALUES (N'NV001', N'VT003')
GO
INSERT [dbo].[NhanVien_VaiTro] ([MaNhanVien], [MaVaiTro]) VALUES (N'NV001', N'VT004')
GO
INSERT [dbo].[NhanVien_VaiTro] ([MaNhanVien], [MaVaiTro]) VALUES (N'NV002', N'VT002')
GO
INSERT [dbo].[NhanVien_VaiTro] ([MaNhanVien], [MaVaiTro]) VALUES (N'NV003', N'VT004')
GO
DECLARE @i INT = 1;
DECLARE @MaPhanHoi VARCHAR(10);
DECLARE @MaSanPham VARCHAR(10) = 'SP001';
DECLARE @XepHangNguoiDung INT;
DECLARE @BinhLuan NVARCHAR(MAX);
DECLARE @NgayPhanHoi DATE;

-- Các bình luận mẫu cho từng mức xếp hạng
DECLARE @BinhLuan5 NVARCHAR(MAX) = N'';
DECLARE @BinhLuan4 NVARCHAR(MAX) = N'';
DECLARE @BinhLuan3 NVARCHAR(MAX) = N'';
DECLARE @BinhLuan2 NVARCHAR(MAX) = N'';
DECLARE @BinhLuan1 NVARCHAR(MAX) = N'';

-- Tạo các câu bình luận mẫu cho mỗi mức xếp hạng
SET @BinhLuan5 = N'Sản phẩm rất tươi ngon, giữ được hương vị tự nhiên của trái cây.|Chất lượng tuyệt vời, giá cả hợp lý, tôi rất hài lòng.|Đây là sản phẩm tốt nhất mà tôi từng mua, sẽ quay lại mua thêm.|Sản phẩm hoàn hảo, hương vị tươi ngon, giữ lâu mà không bị hỏng.|Chất lượng cao, trái cây rất tươi và ngon miệng.|Mình rất hài lòng với sản phẩm này, sẽ mua lại.|Tôi rất thích sản phẩm này, rất đáng đồng tiền bát gạo.|Đây là sản phẩm tuyệt vời, sẽ giới thiệu cho bạn bè.|Sản phẩm tốt, độ tươi rất cao, giá lại hợp lý.|Rất ấn tượng với chất lượng sản phẩm và dịch vụ.';  
SET @BinhLuan4 = N'Sản phẩm tốt, nhưng có thể cải thiện một chút về độ ngọt.|Chất lượng tốt nhưng tôi nghĩ có thể cải thiện thêm về hương vị.|Sản phẩm khá ngon, nhưng cần cải thiện về độ tươi.|Sản phẩm ổn, tuy nhiên hương vị có thể tốt hơn.|Chất lượng khá tốt, nhưng cần thay đổi chút về độ ngọt.|Tốt nhưng không phải xuất sắc, giá hợp lý.|Đây là sản phẩm khá ổn, tuy nhiên vẫn có thể làm tốt hơn.|Mua sản phẩm này khá ok, nhưng chưa hoàn hảo.|Chất lượng tốt nhưng chưa đạt đến mức tuyệt vời.|Sản phẩm ổn, nhưng tôi mong đợi một chút sự cải thiện.';  
SET @BinhLuan3 = N'Chất lượng bình thường, không có gì đặc biệt.|Sản phẩm bình thường, không có gì nổi bật.|Mình không thấy gì đặc biệt về sản phẩm này.|Chất lượng không có gì đặc biệt, giá khá hợp lý.|Sản phẩm khá bình thường, không gây ấn tượng.|Tôi cảm thấy sản phẩm này bình thường, không quá xuất sắc.|Sản phẩm ổn nhưng không có gì đặc biệt.|Chất lượng ở mức bình thường, không gây ấn tượng mạnh.|Sản phẩm không xấu nhưng không có gì đặc biệt.|Chất lượng bình thường, có thể tìm được những sản phẩm tương tự với giá rẻ hơn.';  
SET @BinhLuan2 = N'Chất lượng kém, không giống mô tả.|Sản phẩm không như mong đợi, chất lượng kém.|Không hài lòng với chất lượng của sản phẩm.|Sản phẩm không giống mô tả, rất thất vọng.|Chất lượng kém, không đáng tiền.|Sản phẩm không đạt yêu cầu, tôi sẽ không mua lại.|Sản phẩm không giống với mô tả, rất kém.|Không như tôi kỳ vọng, chất lượng không tốt.|Mình không hài lòng với sản phẩm này, sẽ không mua nữa.|Sản phẩm này chất lượng rất kém, tôi rất thất vọng.';  
SET @BinhLuan1 = N'Dịch vụ tệ, sản phẩm không như mong đợi.|Sản phẩm rất tệ, tôi không muốn mua nữa.|Chất lượng dịch vụ tệ, sản phẩm không tốt.|Tôi không hài lòng với sản phẩm, sẽ không quay lại.|Chất lượng sản phẩm quá tệ, dịch vụ cũng không tốt.|Sản phẩm không giống quảng cáo, rất thất vọng.|Chất lượng kém, dịch vụ không hỗ trợ tốt.|Sản phẩm này quá tệ, không đáng tiền.|Dịch vụ và sản phẩm đều rất tệ, tôi không hài lòng.|Quá thất vọng với sản phẩm, sẽ không mua nữa.';

WHILE @i <= 100
BEGIN
    -- Tạo mã phản hồi ngẫu nhiên
    SET @MaPhanHoi = 'PH' + RIGHT('000' + CAST(@i AS VARCHAR(3)), 3);
    
    -- Tạo Xếp hạng người dùng ngẫu nhiên từ 1 đến 5
    SET @XepHangNguoiDung = (RAND() * 5) + 1;
    SET @XepHangNguoiDung = ROUND(@XepHangNguoiDung, 0);

    -- Chọn bình luận ngẫu nhiên dựa trên XepHangNguoiDung
    IF @XepHangNguoiDung = 5
        SET @BinhLuan = (SELECT TOP 1 value FROM STRING_SPLIT(@BinhLuan5, '|') ORDER BY NEWID());
    ELSE IF @XepHangNguoiDung = 4
        SET @BinhLuan = (SELECT TOP 1 value FROM STRING_SPLIT(@BinhLuan4, '|') ORDER BY NEWID());
    ELSE IF @XepHangNguoiDung = 3
        SET @BinhLuan = (SELECT TOP 1 value FROM STRING_SPLIT(@BinhLuan3, '|') ORDER BY NEWID());
    ELSE IF @XepHangNguoiDung = 2
        SET @BinhLuan = (SELECT TOP 1 value FROM STRING_SPLIT(@BinhLuan2, '|') ORDER BY NEWID());
    ELSE
        SET @BinhLuan = (SELECT TOP 1 value FROM STRING_SPLIT(@BinhLuan1, '|') ORDER BY NEWID());

    -- Chuyển đổi kết quả về NVARCHAR để giữ dấu
    SET @BinhLuan = CAST(@BinhLuan AS NVARCHAR(MAX));

    -- Tạo Ngày phản hồi ngẫu nhiên sau ngày 22/05/2024
    SET @NgayPhanHoi = DATEADD(DAY, (RAND() * 100) + 1, '2024-05-22');  -- Tạo ngày sau 22/05/2024
    
    -- Thực hiện lệnh INSERT
    INSERT INTO PhanHoiNguoiDung (MaPhanHoi, MaSanPham, XepHangNguoiDung, BinhLuan, NgayPhanHoi)
    VALUES (@MaPhanHoi, @MaSanPham, @XepHangNguoiDung, @BinhLuan, @NgayPhanHoi);

    -- Tăng biến đếm
    SET @i = @i + 1;
END;

GO
INSERT [dbo].[PhanTichDoiSoat] ([MaPhanTich], [LoaiPhanTich], [MoTa], [GiaTri], [ThoiGian], [MaSanPham]) VALUES (N'PTDS1', N'Lợi nhuận', N'Phân tích lợi nhuận từ các kênh bán hàng khác nhau.', CAST(11540000000.00 AS Decimal(18, 2)), CAST(N'2024-06-01T00:00:00.000' AS DateTime), N'SP001')
GO
INSERT [dbo].[PhanTichDoiSoat] ([MaPhanTich], [LoaiPhanTich], [MoTa], [GiaTri], [ThoiGian], [MaSanPham]) VALUES (N'PTDS2', N'Tỷ lệ lợi nhuận', N'Tỷ lệ lợi nhuận trên tổng doanh thu.', CAST(32.00 AS Decimal(18, 2)), CAST(N'2024-06-01T00:00:00.000' AS DateTime), N'SP001')
GO
INSERT [dbo].[PhanTichDoiSoat] ([MaPhanTich], [LoaiPhanTich], [MoTa], [GiaTri], [ThoiGian], [MaSanPham]) VALUES (N'PTDS3', N'Phân tích xu hướng', N'Phân tích xu hướng doanh thu và chi phí trong các tháng.', CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-06-01T00:00:00.000' AS DateTime), N'SP001')
GO
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (N'Q001', N'Lập hoá đơn', N'Xem màn hình lập hoá đơn')
GO
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (N'Q002', N'Lập thống kê báo cáo', N'Xem màn hình lập thống kê báo cáo')
GO
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (N'Q003', N'Lập phiếu kiểm kê', N'Quyền truy cập vào màn hình báo cáo')
GO
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (N'Q004', N'Lập đơn đặt hàng', N'Xem màn hình lập đơn đặt hàng')
GO
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (N'Q005', N'Lâp phiếu đổi trả', N'Xem màn hình lập phiếu đổi trả')
GO
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (N'Q006', N'Quản lý hoá đơn', N'Xem màn hình quản lý hoá đơn')
GO
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (N'Q007', N'Quản lý đơn đặt hàng', N'Xem màn hình quản lý đơn đặt hàng')
GO
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (N'Q008', N'Quản lý phiểu kiểm kê', N'Xem màn hình quản lý phiếu kiểm kê')
GO
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (N'Q009', N'Quản lý đổi trả sản phẩm', N'Xem màn hình quản lý đổi trả sản phẩm')
GO
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (N'Q010', N'Quản lý nhà cung cấp', N'Xem màn hình quản lý nhà cung cấp')
GO
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (N'Q011', N'Quản lý khách hàng', N'Xem màn hình quản lý khách hàng')
GO
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (N'Q012', N'Quản lý kho hàng', N'Xem màn hình quản lý kho hàng')
GO
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (N'Q013', N'Quản lý nhân viên', N'Xem màn hình quản lý nhân viên')
GO
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (N'Q014', N'Quản lý hoàn sản phẩm', N'Xem màn hình quản lý hoàn sản phẩm')
GO
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (N'Q015', N'Quản lý chủng loại sản phẩm', N'Xem màn hình quản lý chủng loại sản phẩm')
GO
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (N'Q016', N'Quản lý phân quyền', N'Xem màn hình quản lý phân quyền')
GO
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MoTa], [Gia], [DanhMuc], [SoLuongTon], [NgayPhatHanh], [MucDoAnhHuongTongNguyenLieu]) VALUES (N'SP001', N'Nước Ép Lựu Táo Giòn', N'Lựu táo giòn được thu hoạch từ các vùng đất uy tín,
mang đến hương vị đặc trưng của lựu và táo. Không bổ sung đường, không chất bảo quản,
không phẩm màu nhân tạo, và 100% không biến đổi gen.', CAST(60000 AS Decimal(18, 0)), N'Nước Ép', 3000, CAST(N'2024-05-22T00:00:00.000' AS DateTime), CAST(9.50 AS Decimal(5, 2)))
GO
INSERT [dbo].[ThietKe] ([MaThietKe], [MaSanPham], [MoTa], [DanhGiaThamMy], [DanhGiaTienDung], [MucDoAnhHuong], [HinhAnh]) VALUES (N'TK001', N'SP001', N'Thẩm mỹ:
Phong cách thiết kế: Bao bì được thiết kế hiện đại, trẻ trung, thu hút, với hình ảnh trái lựu đỏ tươi và táo xanh bắt mắt, mang lại cảm giác tự nhiên, tươi mới.
Màu sắc và hình dáng: Màu sắc của bao bì được tối ưu để dễ dàng nhận diện trên kệ hàng. Kiểu dáng bao bì đơn giản nhưng tinh tế, giúp người tiêu dùng dễ dàng lựa chọn.
Thông tin sản phẩm: Logo Vinamilk được in rõ ràng, cùng với các thông tin sản phẩm được trình bày dễ đọc và dễ hiểu.
Tính năng tiện dụng:
Dung tích đa dạng: Nước ép lựu táo Vinamilk có hai dung tích: 330ml và 1L, phù hợp với nhu cầu tiêu dùng cá nhân hoặc gia đình.
Dung tích 330ml thích hợp mang theo khi đi làm, đi học, hay đi chơi.
Dung tích 1L phù hợp cho các gia đình hoặc nhóm bạn sử dụng.
Thiết kế dễ sử dụng: Bao bì có thiết kế tiện lợi, dễ mở nắp và sử dụng, giúp người tiêu dùng không gặp khó khăn trong việc tiếp cận sản phẩm.
', CAST(9.00 AS Decimal(5, 2)), CAST(8.00 AS Decimal(5, 2)), CAST(7.50 AS Decimal(5, 2)), NULL)
GO
INSERT [dbo].[ThiTruong] ([MaThiTruong], [LoaiThiTruong], [MoTa], [GiaTri], [ThoiGian], [MaSanPham]) VALUES (N'TT1', N'Thị phần sản phẩm', N'Thị phần của sản phẩm Nước ép Lựu Táo trong thị trường nước ép trái cây tự nhiên tại Việt Nam.', CAST(7.60 AS Decimal(18, 2)), CAST(N'2024-06-01T00:00:00.000' AS DateTime), N'SP001')
GO
INSERT [dbo].[TinhNangBoSung] ([MaTinhNang], [MaSanPham], [MoTa], [DanhGiaCongNghe], [DanhGiaLinhHoat], [MucDoAnhHuong]) VALUES (N'TN001', N'SP001', N'Công nghệ:
Ép lạnh (cold-press): Công nghệ ép lạnh hiện đại giúp giữ nguyên dưỡng chất và hương vị của trái cây, đảm bảo sản phẩm giữ được chất lượng và vitamin mà không làm mất các khoáng chất.
Tính linh hoạt:
Nhiều cách sử dụng: Nước ép có thể uống ngay hoặc dùng để pha chế các đồ uống khác như cocktail, sinh tố hoặc tráng miệng trong các bữa tiệc.
Kết hợp với các nước ép khác: Có thể kết hợp với các loại nước ép khác để tạo nên hương vị độc đáo và hấp dẫn hơn.
', CAST(9.00 AS Decimal(5, 2)), CAST(8.00 AS Decimal(5, 2)), CAST(7.50 AS Decimal(5, 2)))
GO
INSERT [dbo].[VaiTro] ([MaVaiTro], [TenVaiTro], [MoTa]) VALUES (N'VT001', N'Quản trị viên', N'Quyền truy cập đầy đủ trong hệ thống')
GO
INSERT [dbo].[VaiTro] ([MaVaiTro], [TenVaiTro], [MoTa]) VALUES (N'VT002', N'Nhân viên bán hàng', N'Chỉ có quyền truy cập vào các chức năng bán hàng')
GO
INSERT [dbo].[VaiTro] ([MaVaiTro], [TenVaiTro], [MoTa]) VALUES (N'VT003', N'Nhân viên kho', N'Chỉ có quyền truy cập vào các chức năng quản lý kho')
GO
INSERT [dbo].[VaiTro] ([MaVaiTro], [TenVaiTro], [MoTa]) VALUES (N'VT004', N'Nhân viên chăm sóc khách hàng', N'Có vai trò truy cập vào các màn hình để kiểm tra quy trình chăm sóc khách hàng')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT001', N'Q001')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT001', N'Q002')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT001', N'Q003')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT001', N'Q004')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT001', N'Q005')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT001', N'Q006')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT001', N'Q007')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT001', N'Q008')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT001', N'Q009')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT001', N'Q010')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT001', N'Q011')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT001', N'Q012')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT001', N'Q013')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT001', N'Q014')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT001', N'Q015')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT001', N'Q016')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT002', N'Q001')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT002', N'Q005')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT002', N'Q006')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT002', N'Q009')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT002', N'Q011')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT002', N'Q014')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT003', N'Q002')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT003', N'Q003')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT003', N'Q004')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT003', N'Q007')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT003', N'Q008')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT003', N'Q010')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT003', N'Q011')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT003', N'Q012')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT003', N'Q013')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT003', N'Q015')
GO
ALTER TABLE [dbo].[NhanVien] ADD  DEFAULT ((1)) FOR [TrangThaiHoatDong]
GO
ALTER TABLE [dbo].[NhanVien] ADD  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[ThietKe] ADD  DEFAULT (N'') FOR [HinhAnh]
GO
ALTER TABLE [dbo].[BenVung]  WITH CHECK ADD FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[ChiPhi]  WITH CHECK ADD FOREIGN KEY([MaLoaiChiPhi])
REFERENCES [dbo].[LoaiChiPhi] ([MaLoaiChiPhi])
GO
ALTER TABLE [dbo].[ChiTietThanhPhan]  WITH CHECK ADD  CONSTRAINT [FK_CTTP_NL] FOREIGN KEY([MaNguyenLieu])
REFERENCES [dbo].[NguyenLieu] ([MaNguyenLieu])
GO
ALTER TABLE [dbo].[ChiTietThanhPhan] CHECK CONSTRAINT [FK_CTTP_NL]
GO
ALTER TABLE [dbo].[ChiTietThanhPhan]  WITH CHECK ADD  CONSTRAINT [FK_CTTP_SanPham] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[ChiTietThanhPhan] CHECK CONSTRAINT [FK_CTTP_SanPham]
GO
ALTER TABLE [dbo].[DanhGiaSanPham]  WITH CHECK ADD FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[DichVuKhachHang]  WITH CHECK ADD FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[DoanhThu]  WITH CHECK ADD FOREIGN KEY([MaLoaiDoanhThu])
REFERENCES [dbo].[LoaiDoanhThu] ([MaLoaiDoanhThu])
GO
ALTER TABLE [dbo].[DoBen]  WITH CHECK ADD FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[GiaCa]  WITH CHECK ADD FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[HieuSuat]  WITH CHECK ADD FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[LoaiChiPhi]  WITH CHECK ADD FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[LoaiDoanhThu]  WITH CHECK ADD FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[LoiNhuan]  WITH CHECK ADD FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[NhanVien_VaiTro]  WITH CHECK ADD FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NhanVien_VaiTro]  WITH CHECK ADD FOREIGN KEY([MaVaiTro])
REFERENCES [dbo].[VaiTro] ([MaVaiTro])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PhanHoiNguoiDung]  WITH CHECK ADD FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[PhanTichDoiSoat]  WITH CHECK ADD FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[ThietKe]  WITH CHECK ADD FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[ThiTruong]  WITH CHECK ADD FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[TinhNangBoSung]  WITH CHECK ADD FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[VaiTro_Quyen]  WITH CHECK ADD FOREIGN KEY([MaQuyen])
REFERENCES [dbo].[Quyen] ([MaQuyen])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VaiTro_Quyen]  WITH CHECK ADD FOREIGN KEY([MaVaiTro])
REFERENCES [dbo].[VaiTro] ([MaVaiTro])
ON DELETE CASCADE
GO
USE [master]
GO
ALTER DATABASE [DoAnTotNghiep] SET  READ_WRITE 
GO