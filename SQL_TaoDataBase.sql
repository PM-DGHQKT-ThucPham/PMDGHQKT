use master
go
create database DoAnTotNghiep
go
use DoAnTotNghiep
go
CREATE TABLE SanPham (
    MaSanPham Varchar(10) PRIMARY KEY,
    TenSanPham NVARCHAR(255) NOT NULL,
    MoTa NVARCHAR(MAX),
    Gia DECIMAL(18,0),
    DanhMuc NVARCHAR(100),
	SoLuongTon INT,
    NgayPhatHanh DATETIME,
	MucDoAnhHuongTongNguyenLieu DECIMAL(5,2)
);
CREATE TABLE NguyenLieu (
    MaNguyenLieu Varchar(10) PRIMARY KEY,
    TenNguyenLieu NVARCHAR(255),
	MoTa NVARCHAR(MAX),
    DanhGiaChatLuong DECIMAL(5,2) -- Đánh giá chất lượng (1-10)
);
CREATE TABLE ChiTietThanhPhan(
	MaSanPham Varchar(10),
	MaNguyenLieu Varchar(10),
	PhanTramNguyenLieu DECIMAL(5,2),
	Constraint PK_CTTP Primary Key (MaSanPham, MaNguyenLieu),
	Constraint FK_CTTP_NL Foreign Key (MaNguyenLieu) References NguyenLieu(MaNguyenLieu),
	Constraint FK_CTTP_SanPham Foreign Key (MaSanPham) References SanPham(MaSanPham),
);
CREATE TABLE DoBen (
    MaDoBen Varchar(10) PRIMARY KEY,
    MaSanPham Varchar(10) FOREIGN KEY REFERENCES SanPham(MaSanPham),
    TuoiThoNgay Decimal(18,2), -- Tuổi thọ ước tính của sản phẩm (năm)
	MoTa NVARCHAR(MAX),
    DanhGiaDoBen DECIMAL(5,2), -- Đánh giá độ bền (1-10)
	MucDoAnhHuong DECIMAL(5,2), -- Đánh giá chất lượng (1-10)
);
CREATE TABLE ThietKe (
    MaThietKe Varchar(10) PRIMARY KEY,
    MaSanPham Varchar(10) FOREIGN KEY REFERENCES SanPham(MaSanPham),
	MoTa NVARCHAR(MAX),
    DanhGiaThamMy DECIMAL(5,2), -- Đánh giá thẩm mỹ (1-10)
    DanhGiaTienDung DECIMAL(5,2), -- Đánh giá tính năng tiện dụng (1-10)
	MucDoAnhHuong DECIMAL(5,2), -- Đánh giá chất lượng (1-10)
	HinhAnh nvarchar(max) default N'',
);
CREATE TABLE HieuSuat (
    MaHieuSuat Varchar(10) PRIMARY KEY,
    MaSanPham Varchar(10) FOREIGN KEY REFERENCES SanPham(MaSanPham),
	MoTa NVARCHAR(MAX),
    DanhGiaChucNang DECIMAL(5,2), -- Đánh giá chức năng (1-10)
    DanhGiaTocDo DECIMAL(5,2), -- Đánh giá tốc độ (1-10)
	MucDoAnhHuong DECIMAL(5,2), -- Đánh giá chất lượng (1-10)
);
CREATE TABLE GiaCa (
    MaGiaCa Varchar(10) PRIMARY KEY,
    MaSanPham Varchar(10) FOREIGN KEY REFERENCES SanPham(MaSanPham),
	MoTa NVARCHAR(MAX),
    DanhGiaGiaTri DECIMAL(5,2), -- Đánh giá giá trị so với chất lượng (1-10)
    ChiPhiBaoTri DECIMAL(18, 2), -- Chi phí bảo trì
	MucDoAnhHuong DECIMAL(5,2), -- Đánh giá chất lượng (1-10)
);
CREATE TABLE DichVuKhachHang (
    MaDichVu Varchar(10) PRIMARY KEY,
    MaSanPham Varchar(10) FOREIGN KEY REFERENCES SanPham(MaSanPham),
	MoTa NVARCHAR(MAX),
    DanhGiaHoTro DECIMAL(5,2), -- Đánh giá hỗ trợ khách hàng (1-10)
    ThoiGianBaoHanh INT, -- Thời gian bảo hành (tháng)
	MucDoAnhHuong DECIMAL(5,2), -- Đánh giá chất lượng (1-10)
);
CREATE TABLE PhanHoiNguoiDung (
    MaPhanHoi Varchar(10) PRIMARY KEY,
    MaSanPham Varchar(10) FOREIGN KEY REFERENCES SanPham(MaSanPham),
    XepHangNguoiDung INT, -- Xếp hạng người dùng (1-5 sao)
    BinhLuan NVARCHAR(MAX),
    NgayPhanHoi DATETIME
);
CREATE TABLE BenVung (
    MaBenVung Varchar(10) PRIMARY KEY,
    MaSanPham Varchar(10) FOREIGN KEY REFERENCES SanPham(MaSanPham),
	MoTa NVARCHAR(MAX),
    DanhGiaAnhHuongMoiTruong DECIMAL(5,2), -- Đánh giá ảnh hưởng đến môi trường (1-10)
    DanhGiaAnToan DECIMAL(5,2), -- Đánh giá an toàn cho người sử dụng (1-10)
	MucDoAnhHuong DECIMAL(5,2) -- Đánh giá chất lượng (1-10)
);
CREATE TABLE TinhNangBoSung (
    MaTinhNang Varchar(10) PRIMARY KEY,
    MaSanPham Varchar(10) FOREIGN KEY REFERENCES SanPham(MaSanPham),
	MoTa NVARCHAR(MAX),
    DanhGiaCongNghe DECIMAL(5,2), -- Đánh giá tính năng công nghệ (1-10)
    DanhGiaLinhHoat DECIMAL(5,2), -- Đánh giá tính linh hoạt (1-10)
	MucDoAnhHuong DECIMAL(5,2) -- Đánh giá chất lượng (1-10)
);
CREATE TABLE DanhGiaSanPham (
    MaDanhGia Varchar(10) PRIMARY KEY,
    MaSanPham Varchar(10) FOREIGN KEY REFERENCES SanPham(MaSanPham),
	MoTa NVARCHAR(MAX),
    XepHangTrungBinh DECIMAL(5, 2), -- Xếp hạng trung bình của sản phẩm
    TongDanhGia INT -- Tổng số đánh giá
);
CREATE TABLE LoaiChiPhi(
	MaLoaiChiPhi Varchar(10) PRIMARY KEY,
	TenLoaiChiPhi NVARCHAR(255),
	MoTa NVARCHAR(MAX),
	TongTien DECIMAL(18,2),
	MaSanPham Varchar(10) FOREIGN KEY REFERENCES SanPham(MaSanPham) NULL -- Liên kết với sản phẩm (nếu có)
)
CREATE TABLE ChiPhi (
    MaChiPhi Varchar(10) PRIMARY KEY,
    MoTa NVARCHAR(MAX), -- Mô tả chi tiết
    SoTien DECIMAL(18, 2), -- Số tiền chi phí
    ThoiGian DATETIME, -- Thời gian ghi nhận chi phí
	MaLoaiChiPhi Varchar(10) FOREIGN KEY REFERENCES LoaiChiPhi(MaLoaiChiPhi), -- Loại chi phí (Cố định, Biến đổi, Gián tiếp)
);
CREATE TABLE LoaiDoanhThu(
	MaLoaiDoanhThu Varchar(10) PRIMARY KEY,
	TenLoaiDoanhThu NVARCHAR(255),
	MoTa NVARCHAR(MAX),
	TongTien DECIMAL(18,2),
	MaSanPham Varchar(10) FOREIGN KEY REFERENCES SanPham(MaSanPham) NULL -- Liên kết với sản phẩm (nếu có)
);

CREATE TABLE DoanhThu (
    MaDoanhThu Varchar(10) PRIMARY KEY,
    MaLoaiDoanhThu Varchar(10) FOREIGN KEY REFERENCES LoaiDoanhThu(MaLoaiDoanhThu), -- Loại doanh thu (Doanh thu bán hàng, Doanh thu khuyến mãi, Doanh thu theo kênh phân phối...)
    MoTa NVARCHAR(MAX), -- Mô tả chi tiết
    SoTien DECIMAL(18, 2), -- Số tiền doanh thu
    ThoiGian DATETIME -- Thời gian ghi nhận doanh thu
);

CREATE TABLE ThiTruong (
    MaThiTruong Varchar(10) PRIMARY KEY,
    LoaiThiTruong NVARCHAR(255), -- Loại thông tin thị trường (Quy mô, Phân khúc, Cạnh tranh)
    MoTa NVARCHAR(MAX), -- Mô tả chi tiết
    GiaTri DECIMAL(18, 2) NULL, -- Giá trị của thị trường (TAM, Thị phần)
    ThoiGian DATETIME, -- Thời gian ghi nhận
    MaSanPham Varchar(10), -- Liên kết với sản phẩm
    FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham) -- Khóa ngoại liên kết với bảng SanPham
);
CREATE TABLE PhanTichDoiSoat (
    MaPhanTich Varchar(10) PRIMARY KEY,
    LoaiPhanTich NVARCHAR(255), -- Loại phân tích (Lợi nhuận, Tỷ lệ lợi nhuận, Phân tích xu hướng)
    MoTa NVARCHAR(MAX), -- Mô tả chi tiết
    GiaTri DECIMAL(18, 2), -- Giá trị phân tích
    ThoiGian DATETIME, -- Thời gian ghi nhận phân tích
    MaSanPham Varchar(10), -- Liên kết với sản phẩm
    FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham) -- Khóa ngoại liên kết với bảng SanPham
);
CREATE TABLE LoiNhuan (
    MaLoiNhuan Varchar(10) PRIMARY KEY,
    MaSanPham Varchar(10) FOREIGN KEY REFERENCES SanPham(MaSanPham),
	MoTa NVARCHAR(MAX),
    LoiNhuanGop DECIMAL(18, 2), -- Lợi nhuận gộp
    LoiNhuanRong DECIMAL(18, 2), -- Lợi nhuận ròng
    ThoiGian DATETIME -- Thời gian ghi nhận lợi nhuận
);
-- dữ liệu
INSERT INTO SanPham (MaSanPham, TenSanPham, MoTa, Gia, DanhMuc,SoLuongTon, NgayPhatHanh, MucDoAnhHuongTongNguyenLieu)
VALUES 
('SP001', N'Nước Ép Lựu Táo Giòn',
N'Lựu táo giòn được thu hoạch từ các vùng đất uy tín,
mang đến hương vị đặc trưng của lựu và táo. Không bổ sung đường, không chất bảo quản,
không phẩm màu nhân tạo, và 100% không biến đổi gen.',
60000, 
N'Nước Ép',
3000,
 '2024-5-22',
 9.5);

 -- Nước
INSERT INTO NguyenLieu (MaNguyenLieu, TenNguyenLieu, DanhGiaChatLuong, MoTa)
VALUES 
('NL001', N'Nước', 10, N'Thành phần chính giúp hòa tan và làm loãng nước ép, mang lại hương vị tươi mát.');

-- Nước ép táo cô đặc
INSERT INTO NguyenLieu (MaNguyenLieu, TenNguyenLieu, DanhGiaChatLuong, MoTa)
VALUES 
('NL002', N'Nước ép táo cô đặc', 9, N'Cung cấp hương vị ngọt tự nhiên và nhiều vitamin, đặc biệt là vitamin C và chất xơ.');

-- Nước ép lựu cô đặc
INSERT INTO NguyenLieu (MaNguyenLieu, TenNguyenLieu, DanhGiaChatLuong, MoTa)
VALUES 
('NL003', N'Nước ép lựu cô đặc', 10, N'Lựu mang lại vitamin C, chất chống oxy hóa và hỗ trợ sức khỏe tim mạch.');

-- Chiết xuất cà rốt tím
INSERT INTO NguyenLieu (MaNguyenLieu, TenNguyenLieu, DanhGiaChatLuong, MoTa)
VALUES 
('NL004', N'Chiết xuất cà rốt tím', 8, N'Tạo màu sắc tự nhiên và cung cấp thêm các vitamin A, beta-carotene và chất chống oxy hóa.');

-- Hương liệu giống tự nhiên
INSERT INTO NguyenLieu (MaNguyenLieu, TenNguyenLieu, DanhGiaChatLuong, MoTa)
VALUES 
('NL005', N'Hương liệu giống tự nhiên', 7, N'Hương liệu này giúp gia tăng mùi vị tự nhiên, mang lại trải nghiệm thơm ngon cho sản phẩm.');

-- Tạo tổng nguyên liệu cho sản phẩm SP001 (Nước ép lựu táo giòn)
--INSERT INTO TongCacNguyenLieu (MaTongNguyenLieu, MaSanPham, MucDoAnhHuong)
--VALUES 
--('TCNL001', 'SP001', 9.5);

-- Liên kết nguyên liệu với tổng nguyên liệu (TCNL001)
INSERT INTO ChiTietThanhPhan (MaSanPham, MaNguyenLieu, PhanTramNguyenLieu)
VALUES 
('SP001', 'NL001', 79.6),  -- Nước (đã điều chỉnh)
('SP001', 'NL002', 10.2),  -- Nước ép táo cô đặc
('SP001', 'NL003', 7.6),   -- Nước ép lựu cô đặc
('SP001', 'NL004', 2),     -- Chiết xuất cà rốt tím
('SP001', 'NL005', 0.5);   -- Hương liệu giống tự nhiên


-- Insert data into the DoBen table
INSERT INTO DoBen (MaDoBen, MaSanPham, TuoiThoNgay, DanhGiaDoBen, MucDoAnhHuong, MoTa)
VALUES ('DB001', 'SP001', 6.00, 9, 8.5, N'Bao bì Tetra Pak cao cấp không chỉ giúp bảo quản nước ép mà còn đảm bảo chất lượng và độ tươi mới của sản phẩm trong suốt thời gian sử dụng. Tetra Pak là một giải pháp bao bì bảo vệ hiệu quả, với cấu trúc bao bì bao gồm các lớp vật liệu khác nhau, trong đó có giấy và nhựa PE (polyethylene), mang lại những đặc điểm ưu việt:
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
');

-- Insert data into the ThietKe table
INSERT INTO ThietKe (MaThietKe, MaSanPham, DanhGiaThamMy, DanhGiaTienDung, MucDoAnhHuong, MoTa)
VALUES ('TK001', 'SP001', 9, 8, 7.5, N'Thẩm mỹ:
Phong cách thiết kế: Bao bì được thiết kế hiện đại, trẻ trung, thu hút, với hình ảnh trái lựu đỏ tươi và táo xanh bắt mắt, mang lại cảm giác tự nhiên, tươi mới.
Màu sắc và hình dáng: Màu sắc của bao bì được tối ưu để dễ dàng nhận diện trên kệ hàng. Kiểu dáng bao bì đơn giản nhưng tinh tế, giúp người tiêu dùng dễ dàng lựa chọn.
Thông tin sản phẩm: Logo Vinamilk được in rõ ràng, cùng với các thông tin sản phẩm được trình bày dễ đọc và dễ hiểu.
Tính năng tiện dụng:
Dung tích đa dạng: Nước ép lựu táo Vinamilk có hai dung tích: 330ml và 1L, phù hợp với nhu cầu tiêu dùng cá nhân hoặc gia đình.
Dung tích 330ml thích hợp mang theo khi đi làm, đi học, hay đi chơi.
Dung tích 1L phù hợp cho các gia đình hoặc nhóm bạn sử dụng.
Thiết kế dễ sử dụng: Bao bì có thiết kế tiện lợi, dễ mở nắp và sử dụng, giúp người tiêu dùng không gặp khó khăn trong việc tiếp cận sản phẩm.
');

-- Insert data into the HieuSuat table
INSERT INTO HieuSuat (MaHieuSuat, MaSanPham, DanhGiaChucNang, DanhGiaTocDo, MucDoAnhHuong,MoTa)
VALUES ('HS001', 'SP001', 8, 8, 7.5, N'Chức năng:
Lợi ích sức khỏe: Nước ép lựu táo Vinamilk cung cấp lượng vitamin C cần thiết cho cơ thể, giúp tăng cường sức đề kháng và hỗ trợ hệ miễn dịch.
Chất chống oxy hóa: Lựu và táo là những trái cây giàu chất chống oxy hóa, giúp bảo vệ cơ thể khỏi tác động của các gốc tự do và lão hóa.
Tiện lợi: Sản phẩm là lựa chọn lý tưởng cho những người muốn bổ sung dưỡng chất từ thiên nhiên một cách nhanh chóng và hiệu quả, đặc biệt cho những người có cuộc sống bận rộn.
Tốc độ:
Sẵn sàng sử dụng: Sản phẩm có thể uống ngay khi mở nắp, không cần pha chế hay chuẩn bị gì thêm, giúp tiết kiệm thời gian cho người tiêu dùng.
');

-- Insert data into the GiaCa table
INSERT INTO GiaCa (MaGiaCa, MaSanPham, DanhGiaGiaTri, ChiPhiBaoTri, MucDoAnhHuong, MoTa)
VALUES ('GC001', 'SP001', 8, 0, 6.5, N'Mức giá cạnh tranh. Đây là mức giá hợp lý và cạnh tranh, đặc biệt khi so với các sản phẩm nhập khẩu có giá thành cao hơn. Chất lượng của sản phẩm không thua kém bất kỳ thương hiệu nổi tiếng nào trên thị trường, với thành phần 100% từ trái cây tự nhiên, không có chất bảo quản hay phẩm màu nhân tạo.
Giá hợp lý: Mức giá này giúp sản phẩm dễ dàng tiếp cận với nhiều đối tượng người tiêu dùng, đặc biệt là các gia đình có trẻ em hoặc những người quan tâm đến sức khỏe. Với giá thành này, người tiêu dùng không chỉ mua được sản phẩm chất lượng mà còn yên tâm về sự an toàn và nguồn gốc nguyên liệu tự nhiên của nước ép.
');

-- Insert data into the DichVuKhachHang table
INSERT INTO DichVuKhachHang (MaDichVu, MaSanPham, DanhGiaHoTro, ThoiGianBaoHanh, MucDoAnhHuong, MoTa)
VALUES ('DV001', 'SP001', 9, 12, 7.5, N'Chính sách đổi trả: Chính sách đổi trả linh hoạt trong vòng 30 ngày nếu sản phẩm gặp vấn đề về chất lượng, đảm bảo quyền lợi cho người tiêu dùng.
Dịch vụ chăm sóc khách hàng: Chính sách hỗ trợ qua hotline và các kênh trực tuyến giúp giải đáp thắc mắc và hỗ trợ khách hàng khi cần thiết.
Tiêu chuẩn chất lượng: Sản phẩm tuân thủ các tiêu chuẩn chất lượng thực phẩm do Bộ Y tế Việt Nam quy định.
Mã QR truy xuất nguồn gốc: Mỗi lô sản phẩm đều có mã QR giúp khách hàng dễ dàng kiểm tra nguồn gốc và ngày sản xuất của sản phẩm.
');

-- Insert data into the PhanHoiNguoiDung table
DECLARE @i INT = 1;
DECLARE @MaPhanHoi VARCHAR(10);
DECLARE @MaSanPham VARCHAR(10) = 'SP001';
DECLARE @XepHangNguoiDung INT;
DECLARE @BinhLuan NVARCHAR(MAX);
DECLARE @NgayPhanHoi DATE;

WHILE @i <= 100
BEGIN
    -- Tạo mã phản hồi ngẫu nhiên
    SET @MaPhanHoi = 'PH' + RIGHT('000' + CAST(@i AS VARCHAR(3)), 3);
    
    -- Tạo Xếp hạng người dùng ngẫu nhiên từ 1 đến 5
    SET @XepHangNguoiDung = (RAND() * 5) + 1;
    SET @XepHangNguoiDung = ROUND(@XepHangNguoiDung, 0);

    -- Tạo bình luận ngẫu nhiên (có thể thay đổi thêm bình luận cho phong phú)
    IF @XepHangNguoiDung = 5
        SET @BinhLuan = N'Sản phẩm rất tươi ngon, giữ được hương vị tự nhiên của trái cây.';
    ELSE IF @XepHangNguoiDung = 4
        SET @BinhLuan = N'Sản phẩm tốt, nhưng có thể cải thiện một chút về độ ngọt.';
    ELSE IF @XepHangNguoiDung = 3
        SET @BinhLuan = N'Chất lượng bình thường, không có gì đặc biệt.';
    ELSE IF @XepHangNguoiDung = 2
        SET @BinhLuan = N'Chất lượng kém, không giống mô tả.';
    ELSE
        SET @BinhLuan = N'Dịch vụ tệ, sản phẩm không như mong đợi.';

    -- Tạo Ngày phản hồi ngẫu nhiên sau ngày 22/05/2024
    SET @NgayPhanHoi = DATEADD(DAY, (RAND() * 100) + 1, '2024-05-22');  -- Tạo ngày sau 22/05/2024
    
    -- Thực hiện lệnh INSERT
    INSERT INTO PhanHoiNguoiDung (MaPhanHoi, MaSanPham, XepHangNguoiDung, BinhLuan, NgayPhanHoi)
    VALUES (@MaPhanHoi, @MaSanPham, @XepHangNguoiDung, @BinhLuan, @NgayPhanHoi);

    -- Tăng biến đếm
    SET @i = @i + 1;
END;

-- Insert data into the BenVung table
INSERT INTO BenVung (MaBenVung, MaSanPham, DanhGiaAnhHuongMoiTruong, DanhGiaAnToan, MucDoAnhHuong, MoTa)
VALUES ('BV001', 'SP001', 9, 8, 8.0, N'Tác động môi trường:
Bao bì giấy tái chế: Bao bì Tetra Pak giúp giảm thiểu lượng nhựa sử dụng trong ngành thực phẩm và đồ uống, góp phần bảo vệ môi trường.
Quy trình sản xuất tiết kiệm năng lượng: Sản phẩm được sản xuất với quy trình tiết kiệm năng lượng và giảm thiểu phát thải CO2.
Thân thiện với người dùng:
Không chứa chất phụ gia: Sản phẩm không chứa các chất phụ gia, phẩm màu nhân tạo hay hóa chất độc hại, an toàn tuyệt đối cho mọi lứa tuổi.
Không có đường hóa học: Sản phẩm không chứa đường hóa học, phù hợp cho những người ăn kiêng hoặc mắc các bệnh về đường huyết.
');

-- Insert data into the TinhNangBoSung table
INSERT INTO TinhNangBoSung (MaTinhNang, MaSanPham, DanhGiaCongNghe, DanhGiaLinhHoat, MucDoAnhHuong, MoTa)
VALUES ('TN001', 'SP001', 9, 8, 7.5, N'Công nghệ:
Ép lạnh (cold-press): Công nghệ ép lạnh hiện đại giúp giữ nguyên dưỡng chất và hương vị của trái cây, đảm bảo sản phẩm giữ được chất lượng và vitamin mà không làm mất các khoáng chất.
Tính linh hoạt:
Nhiều cách sử dụng: Nước ép có thể uống ngay hoặc dùng để pha chế các đồ uống khác như cocktail, sinh tố hoặc tráng miệng trong các bữa tiệc.
Kết hợp với các nước ép khác: Có thể kết hợp với các loại nước ép khác để tạo nên hương vị độc đáo và hấp dẫn hơn.
');

-- Insert data into the DanhGiaSanPham table
INSERT INTO DanhGiaSanPham (MaDanhGia, MaSanPham, XepHangTrungBinh, TongDanhGia)
VALUES ('DG001', 'SP001', 4.8, 1000);
-- Insert into LoaiChiPhi table
INSERT INTO LoaiChiPhi (MaLoaiChiPhi, TenLoaiChiPhi, MoTa, TongTien, MaSanPham) 
VALUES 
('CPCD', N'Chi phí cố định', N'Chi phí không thay đổi theo sản lượng hay doanh thu.', 7000000000, 'SP001'),
('CPBD', N'Chi phí biến đổi', N'Chi phí thay đổi tùy theo khối lượng sản xuất, doanh thu hoặc hoạt động.', 15570000000, 'SP001'),
('CPGT', N'Chi phí gián tiếp', N'Chi phí không trực tiếp liên quan đến sản xuất nhưng cần thiết để duy trì hoạt động.', 4000000000, 'SP001');

-- Insert into ChiPhi table for 6 months
INSERT INTO ChiPhi (MaChiPhi, MoTa, SoTien, ThoiGian, MaLoaiChiPhi) 
VALUES 
-- Chi phí cố định
('CPCD1', N'Chi phí thuê mặt bằng', 275000000, '2024-06-01', 'CPCD'),
('CPCD2', N'Lương nhân viên', 420000000, '2024-06-01', 'CPCD'),
('CPCD3', N'Chi phí bảo trì thiết bị', 175000000, '2024-06-01', 'CPCD'),
('CPCD4', N'Chi phí bảo hiểm', 195000000, '2024-06-01', 'CPCD'),
-- Chi phí biến đổi
('CPBD5', N'Nguyên liệu đầu vào', 1100000000, '2024-06-01', 'CPBD'),
('CPBD6', N'Chi phí vận chuyển', 350000000, '2024-06-01', 'CPBD'),
('CPBD7', N'Chi phí marketing', 220000000, '2024-06-01', 'CPBD'),
('CPBD8', N'Chi phí đóng gói sản phẩm', 160000000, '2024-06-01', 'CPBD'),
-- Chi phí gián tiếp
('CPGT9', N'Chi phí hành chính', 280000000, '2024-06-01', 'CPGT'),
('CPGT10', N'Chi phí điện, nước, văn phòng', 280000000, '2024-06-01', 'CPGT'),

-- Chi phí cố định (Tháng 7 đến tháng 11)
('CPCD11', N'Chi phí thuê mặt bằng', 275000000, '2024-07-01', 'CPCD'),
('CPCD12', N'Lương nhân viên', 420000000, '2024-07-01', 'CPCD'),
('CPCD13', N'Chi phí bảo trì thiết bị', 175000000, '2024-07-01', 'CPCD'),
('CPCD14', N'Chi phí bảo hiểm', 195000000, '2024-07-01', 'CPCD'),
('CPBD15', N'Nguyên liệu đầu vào', 1100000000, '2024-07-01', 'CPBD'),
('CPBD16', N'Chi phí vận chuyển', 350000000, '2024-07-01', 'CPBD'),
('CPBD17', N'Chi phí marketing', 220000000, '2024-07-01', 'CPBD'),
('CPBD18', N'Chi phí đóng gói sản phẩm', 160000000, '2024-07-01', 'CPBD'),
('CPGT19', N'Chi phí hành chính', 280000000, '2024-07-01', 'CPGT'),
('CPGT20', N'Chi phí điện, nước, văn phòng', 280000000, '2024-07-01', 'CPGT'),

('CPCD21', N'Chi phí thuê mặt bằng', 275000000, '2024-08-01', 'CPCD'),
('CPCD22', N'Lương nhân viên', 420000000, '2024-08-01', 'CPCD'),
('CPCD23', N'Chi phí bảo trì thiết bị', 175000000, '2024-08-01', 'CPCD'),
('CPCD24', N'Chi phí bảo hiểm', 195000000, '2024-08-01', 'CPCD'),
('CPBD25', N'Nguyên liệu đầu vào', 1100000000, '2024-08-01', 'CPBD'),
('CPBD26', N'Chi phí vận chuyển', 350000000, '2024-08-01', 'CPBD'),
('CPBD27', N'Chi phí marketing', 220000000, '2024-08-01', 'CPBD'),
('CPBD28', N'Chi phí đóng gói sản phẩm', 160000000, '2024-08-01', 'CPBD'),
('CPGT29', N'Chi phí hành chính', 280000000, '2024-08-01', 'CPGT'),
('CPGT30', N'Chi phí điện, nước, văn phòng', 280000000, '2024-08-01', 'CPGT'),

('CPCD31', N'Chi phí thuê mặt bằng', 275000000, '2024-09-01', 'CPCD'),
('CPCD32', N'Lương nhân viên', 420000000, '2024-09-01', 'CPCD'),
('CPCD33', N'Chi phí bảo trì thiết bị', 175000000, '2024-09-01', 'CPCD'),
('CPCD34', N'Chi phí bảo hiểm', 195000000, '2024-09-01', 'CPCD'),
('CPBD35', N'Nguyên liệu đầu vào', 1100000000, '2024-09-01', 'CPBD'),
('CPBD36', N'Chi phí vận chuyển', 350000000, '2024-09-01', 'CPBD'),
('CPBD37', N'Chi phí marketing', 220000000, '2024-09-01', 'CPBD'),
('CPBD38', N'Chi phí đóng gói sản phẩm', 160000000, '2024-09-01', 'CPBD'),
('CPGT39', N'Chi phí hành chính', 280000000, '2024-09-01', 'CPGT'),
('CPGT40', N'Chi phí điện, nước, văn phòng', 280000000, '2024-09-01', 'CPGT'),

('CPCD41', N'Chi phí thuê mặt bằng', 275000000, '2024-10-01', 'CPCD'),
('CPCD42', N'Lương nhân viên', 420000000, '2024-10-01', 'CPCD'),
('CPCD43', N'Chi phí bảo trì thiết bị', 175000000, '2024-10-01', 'CPCD'),
('CPCD44', N'Chi phí bảo hiểm', 195000000, '2024-10-01', 'CPCD'),
('CPBD45', N'Nguyên liệu đầu vào', 1100000000, '2024-10-01', 'CPBD'),
('CPBD46', N'Chi phí vận chuyển', 350000000, '2024-10-01', 'CPBD'),
('CPBD47', N'Chi phí marketing', 220000000, '2024-10-01', 'CPBD'),
('CPBD48', N'Chi phí đóng gói sản phẩm', 160000000, '2024-10-01', 'CPBD'),
('CPGT49', N'Chi phí hành chính', 280000000, '2024-10-01', 'CPGT'),
('CPGT50', N'Chi phí điện, nước, văn phòng', 280000000, '2024-10-01', 'CPGT'),

('CPCD51', N'Chi phí thuê mặt bằng', 275000000, '2024-11-01', 'CPCD'),
('CPCD52', N'Lương nhân viên', 420000000, '2024-11-01', 'CPCD'),
('CPCD53', N'Chi phí bảo trì thiết bị', 175000000, '2024-11-01', 'CPCD'),
('CPCD54', N'Chi phí bảo hiểm', 195000000, '2024-11-01', 'CPCD'),
('CPBD55', N'Nguyên liệu đầu vào', 1100000000, '2024-11-01', 'CPBD'),
('CPBD56', N'Chi phí vận chuyển', 350000000, '2024-11-01', 'CPBD'),
('CPBD57', N'Chi phí marketing', 220000000, '2024-11-01', 'CPBD'),
('CPBD58', N'Chi phí đóng gói sản phẩm', 160000000, '2024-11-01', 'CPBD'),
('CPGT59', N'Chi phí hành chính', 280000000, '2024-11-01', 'CPGT'),
('CPGT60', N'Chi phí điện, nước, văn phòng', 280000000, '2024-11-01', 'CPGT');


-- Insert into ThiTruong table
INSERT INTO ThiTruong (MaThiTruong, LoaiThiTruong, MoTa, GiaTri, ThoiGian, MaSanPham)
VALUES 
('TT1', N'Thị phần sản phẩm', N'Thị phần của sản phẩm Nước ép Lựu Táo trong thị trường nước ép trái cây tự nhiên tại Việt Nam.', 7.6, '2024-06-01', 'SP001')


-- Insert into PhanTichDoiSoat table
INSERT INTO PhanTichDoiSoat (MaPhanTich, LoaiPhanTich, MoTa, GiaTri, ThoiGian, MaSanPham)
VALUES 
('PTDS1', N'Lợi nhuận', N'Phân tích lợi nhuận từ các kênh bán hàng khác nhau.', 11540000000, '2024-06-01', 'SP001'),
('PTDS2', N'Tỷ lệ lợi nhuận', N'Tỷ lệ lợi nhuận trên tổng doanh thu.', 32, '2024-06-01', 'SP001'),
('PTDS3', N'Phân tích xu hướng', N'Phân tích xu hướng doanh thu và chi phí trong các tháng.', 0, '2024-06-01', 'SP001');

-- Insert into LoiNhuan table
INSERT INTO LoiNhuan (MaLoiNhuan, MaSanPham, LoiNhuanGop, LoiNhuanRong, ThoiGian)
VALUES 
('LN1', 'SP001', 1178000000, 752000000, '2024-06-30'),
('LN2', 'SP001', 1551000000, 799000000, '2024-07-30'),
('LN3', 'SP001', 1914000000, 1044000000, '2024-08-30'),
('LN4', 'SP001', 2145000000, 1235000000, '2024-09-30'),
('LN5', 'SP001', 2277000000, 1380000000, '2024-10-30'),
('LN6', 'SP001', 2475000000, 1500000000, '2024-11-30');

-- Chèn dữ liệu vào bảng LoaiDoanhThu
INSERT INTO LoaiDoanhThu (MaLoaiDoanhThu, TenLoaiDoanhThu, MoTa, TongTien, MaSanPham)
VALUES
('DT1', N'Doanh thu bán trực tiếp', N'Doanh thu từ việc bán hàng trực tiếp tại cửa hàng', 1800000000, 'SP001'),
('DT2', N'Doanh thu bán trực tuyến', N'Doanh thu từ việc bán hàng qua các kênh trực tuyến', 1100000000, 'SP001'),
('DT3', N'Doanh thu bán qua đối tác phân phối', N'Doanh thu từ việc bán hàng qua các đối tác phân phối', 900000000, 'SP001')

-- Chèn dữ liệu vào bảng DoanhThu
-- Doanh thu bán trực tiếp
INSERT INTO DoanhThu (MaDoanhThu,MaLoaiDoanhThu , MoTa, SoTien, ThoiGian)
VALUES
('DT006', 'DT1', N'Doanh thu bán trực tiếp tháng 6', 1800000000, '2024-06-30'),
('DT007', 'DT1', N'Doanh thu bán trực tiếp tháng 7', 2200000000, '2024-07-30'),
('DT008', 'DT1', N'Doanh thu bán trực tiếp tháng 8', 2700000000, '2024-08-30'),
('DT009', 'DT1', N'Doanh thu bán trực tiếp tháng 9', 3000000000, '2024-09-30'),
('DT010', 'DT1', N'Doanh thu bán trực tiếp tháng 10', 3200000000, '2024-10-30'),
('DT011', 'DT1', N'Doanh thu bán trực tiếp tháng 11', 3500000000, '2024-11-30');

-- Doanh thu bán trực tuyến
INSERT INTO DoanhThu (MaDoanhThu, MaLoaiDoanhThu, MoTa, SoTien, ThoiGian)
VALUES
('DT012', 'DT2', N'Doanh thu bán trực tuyến tháng 6', 1100000000, '2024-06-01'),
('DT013', 'DT2', N'Doanh thu bán trực tuyến tháng 7', 1400000000, '2024-07-01'),
('DT014', 'DT2', N'Doanh thu bán trực tuyến tháng 8', 1700000000, '2024-08-01'),
('DT015', 'DT2', N'Doanh thu bán trực tuyến tháng 9', 1900000000, '2024-09-01'),
('DT016', 'DT2', N'Doanh thu bán trực tuyến tháng 10', 2000000000, '2024-10-01'),
('DT017', 'DT2', N'Doanh thu bán trực tuyến tháng 11', 2200000000, '2024-11-01');

-- Doanh thu bán qua đối tác phân phối
INSERT INTO DoanhThu (MaDoanhThu, MaLoaiDoanhThu, MoTa, SoTien, ThoiGian)
VALUES
('DT018', 'DT3', N'Doanh thu bán qua đối tác phân phối tháng 6', 900000000, '2024-06-01'),
('DT019', 'DT3', N'Doanh thu bán qua đối tác phân phối tháng 7', 1100000000, '2024-07-01'),
('DT020', 'DT3', N'Doanh thu bán qua đối tác phân phối tháng 8', 1400000000, '2024-08-01'),
('DT021', 'DT3', N'Doanh thu bán qua đối tác phân phối tháng 9', 1600000000, '2024-09-01'),
('DT022', 'DT3', N'Doanh thu bán qua đối tác phân phối tháng 10', 1700000000, '2024-10-01'),
('DT023', 'DT3', N'Doanh thu bán qua đối tác phân phối tháng 11', 1800000000, '2024-11-01');