
INSERT INTO SanPham (MaSanPham, TenSanPham, MoTa, Gia, DanhMuc,SoLuongTon, NgayPhatHanh, MucDoAnhHuongTongNguyenLieu)
VALUES 
('SP002', N'Nước Ép Cam -Vinamilk',
N'Cam được thu hoạch từ các vùng đất uy tín,
mang đến hương vị đặc trưng của Cam. Không bổ sung đường, không chất bảo quản,
không phẩm màu nhân tạo, và 100% không biến đổi gen.',
50000, 
N'Nước Ép',
3000,
 '2024-5-23',
 9.5);
-- Chiết xuất cà rốt tím
INSERT INTO NguyenLieu (MaNguyenLieu, TenNguyenLieu, DanhGiaChatLuong, MoTa)
VALUES 
('NL006', N'Nước ép cam cô đặc', 9, N'Cam 100% từ nhiên an toàn');

-- Hương liệu giống tự nhiên
INSERT INTO NguyenLieu (MaNguyenLieu, TenNguyenLieu, DanhGiaChatLuong, MoTa)
VALUES 
('NL007', N'Hương liệu cam giống tự nhiên', 7, N'Hương liệu này giúp gia tăng mùi vị tự nhiên, mang lại trải nghiệm thơm ngon cho sản phẩm.');

-- Liên kết nguyên liệu với tổng nguyên liệu (TCNL001)
INSERT INTO ChiTietThanhPhan (MaSanPham, MaNguyenLieu, PhanTramNguyenLieu)
VALUES 
('SP002', 'NL001', 70),  
('SP002', 'NL006', 9.5),  
('SP002', 'NL007', 20.4)


-- Insert data into the DoBen table
INSERT INTO DoBen (MaDoBen, MaSanPham, TuoiThoNgay, DanhGiaDoBen, MucDoAnhHuong, MoTa)
VALUES ('DB002', 'SP002', 6.00, 9, 8.5, N'Bao bì Tetra Pak cao cấp không chỉ giúp bảo quản nước ép mà còn đảm bảo chất lượng và độ tươi mới của sản phẩm trong suốt thời gian sử dụng. Tetra Pak là một giải pháp bao bì bảo vệ hiệu quả, với cấu trúc bao bì bao gồm các lớp vật liệu khác nhau, trong đó có giấy và nhựa PE (polyethylene), mang lại những đặc điểm ưu việt:
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
VALUES ('TK002', 'SP002', 9, 8, 7.5, N'Thẩm mỹ:
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
VALUES ('HS002', 'SP002', 8, 8, 7.5, N'Chức năng:
Lợi ích sức khỏe: Nước ép lựu táo Vinamilk cung cấp lượng vitamin C cần thiết cho cơ thể, giúp tăng cường sức đề kháng và hỗ trợ hệ miễn dịch.
Chất chống oxy hóa: Lựu và táo là những trái cây giàu chất chống oxy hóa, giúp bảo vệ cơ thể khỏi tác động của các gốc tự do và lão hóa.
Tiện lợi: Sản phẩm là lựa chọn lý tưởng cho những người muốn bổ sung dưỡng chất từ thiên nhiên một cách nhanh chóng và hiệu quả, đặc biệt cho những người có cuộc sống bận rộn.
Tốc độ:
Sẵn sàng sử dụng: Sản phẩm có thể uống ngay khi mở nắp, không cần pha chế hay chuẩn bị gì thêm, giúp tiết kiệm thời gian cho người tiêu dùng.
');

-- Insert data into the GiaCa table
INSERT INTO GiaCa (MaGiaCa, MaSanPham, DanhGiaGiaTri, ChiPhiBaoTri, MucDoAnhHuong, MoTa)
VALUES ('GC002', 'SP002', 8, 0, 6.5, N'Mức giá cạnh tranh. Đây là mức giá hợp lý và cạnh tranh, đặc biệt khi so với các sản phẩm nhập khẩu có giá thành cao hơn. Chất lượng của sản phẩm không thua kém bất kỳ thương hiệu nổi tiếng nào trên thị trường, với thành phần 100% từ trái cây tự nhiên, không có chất bảo quản hay phẩm màu nhân tạo.
Giá hợp lý: Mức giá này giúp sản phẩm dễ dàng tiếp cận với nhiều đối tượng người tiêu dùng, đặc biệt là các gia đình có trẻ em hoặc những người quan tâm đến sức khỏe. Với giá thành này, người tiêu dùng không chỉ mua được sản phẩm chất lượng mà còn yên tâm về sự an toàn và nguồn gốc nguyên liệu tự nhiên của nước ép.
');

-- Insert data into the DichVuKhachHang table
INSERT INTO DichVuKhachHang (MaDichVu, MaSanPham, DanhGiaHoTro, ThoiGianBaoHanh, MucDoAnhHuong, MoTa)
VALUES ('DV002', 'SP002', 9, 12, 7.5, N'Chính sách đổi trả: Chính sách đổi trả linh hoạt trong vòng 30 ngày nếu sản phẩm gặp vấn đề về chất lượng, đảm bảo quyền lợi cho người tiêu dùng.
Dịch vụ chăm sóc khách hàng: Chính sách hỗ trợ qua hotline và các kênh trực tuyến giúp giải đáp thắc mắc và hỗ trợ khách hàng khi cần thiết.
Tiêu chuẩn chất lượng: Sản phẩm tuân thủ các tiêu chuẩn chất lượng thực phẩm do Bộ Y tế Việt Nam quy định.
Mã QR truy xuất nguồn gốc: Mỗi lô sản phẩm đều có mã QR giúp khách hàng dễ dàng kiểm tra nguồn gốc và ngày sản xuất của sản phẩm.
');

-- Insert data into the PhanHoiNguoiDung table
DECLARE @i INT = 1;
DECLARE @MaPhanHoi VARCHAR(10);
DECLARE @MaSanPham VARCHAR(10) = 'SP002';
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
    SET @MaPhanHoi = 'PH' + RIGHT('000' + CAST(@i AS VARCHAR(3)), 3)+'SP002';
    
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
    SET @NgayPhanHoi = DATEADD(DAY, (RAND() * 100) + 1, '2024-05-23');  -- Tạo ngày sau 23/05/2024
    
    -- Thực hiện lệnh INSERT
    INSERT INTO PhanHoiNguoiDung (MaPhanHoi, MaSanPham, XepHangNguoiDung, BinhLuan, NgayPhanHoi)
    VALUES (@MaPhanHoi, @MaSanPham, @XepHangNguoiDung, @BinhLuan, @NgayPhanHoi);

    -- Tăng biến đếm
    SET @i = @i + 1;
END;
-- Insert data into the BenVung table
INSERT INTO BenVung (MaBenVung, MaSanPham, DanhGiaAnhHuongMoiTruong, DanhGiaAnToan, MucDoAnhHuong, MoTa)
VALUES ('BV002', 'SP002', 9, 8, 8.0, N'Tác động môi trường:
Bao bì giấy tái chế: Bao bì Tetra Pak giúp giảm thiểu lượng nhựa sử dụng trong ngành thực phẩm và đồ uống, góp phần bảo vệ môi trường.
Quy trình sản xuất tiết kiệm năng lượng: Sản phẩm được sản xuất với quy trình tiết kiệm năng lượng và giảm thiểu phát thải CO2.
Thân thiện với người dùng:
Không chứa chất phụ gia: Sản phẩm không chứa các chất phụ gia, phẩm màu nhân tạo hay hóa chất độc hại, an toàn tuyệt đối cho mọi lứa tuổi.
Không có đường hóa học: Sản phẩm không chứa đường hóa học, phù hợp cho những người ăn kiêng hoặc mắc các bệnh về đường huyết.
');
ALTER TABLE ChiPhi ALTER COLUMN MaChiPhi NVARCHAR(15);

-- Insert data into the TinhNangBoSung table
INSERT INTO TinhNangBoSung (MaTinhNang, MaSanPham, DanhGiaCongNghe, DanhGiaLinhHoat, MucDoAnhHuong, MoTa)
VALUES ('TN002', 'SP002', 9, 8, 7.5, N'Công nghệ:
Ép lạnh (cold-press): Công nghệ ép lạnh hiện đại giúp giữ nguyên dưỡng chất và hương vị của trái cây, đảm bảo sản phẩm giữ được chất lượng và vitamin mà không làm mất các khoáng chất.
Tính linh hoạt:
Nhiều cách sử dụng: Nước ép có thể uống ngay hoặc dùng để pha chế các đồ uống khác như cocktail, sinh tố hoặc tráng miệng trong các bữa tiệc.
Kết hợp với các nước ép khác: Có thể kết hợp với các loại nước ép khác để tạo nên hương vị độc đáo và hấp dẫn hơn.
');

-- Insert data into the DanhGiaSanPham table
INSERT INTO DanhGiaSanPham (MaDanhGia, MaSanPham, XepHangTrungBinh, TongDanhGia)
VALUES ('DG001', 'SP002', 4.9, 1000);

-- Insert into LoaiChiPhi table
INSERT INTO LoaiChiPhi (MaLoaiChiPhi, TenLoaiChiPhi, MoTa, TongTien, MaSanPham) 
VALUES 
('CPCDSP002', N'Chi phí cố định', N'Chi phí không thay đổi theo sản lượng hay doanh thu.', 7000000000, 'SP002'),
('CPBDSP002', N'Chi phí biến đổi', N'Chi phí thay đổi tùy theo khối lượng sản xuất, doanh thu hoặc hoạt động.', 15570000000, 'SP002'),
('CPGTSP002', N'Chi phí gián tiếp', N'Chi phí không trực tiếp liên quan đến sản xuất nhưng cần thiết để duy trì hoạt động.', 4000000000, 'SP002');

-- Chèn dữ liệu vào bảng ChiPhi cho sản phẩm SP002 (Nước ép cam Vinamilk)
INSERT INTO ChiPhi (MaChiPhi, MoTa, SoTien, ThoiGian, MaLoaiChiPhi) 
VALUES 
-- Chi phí cố định
('CPCD1SP2', N'Chi phí thuê mặt bằng', 350000000, '2024-06-01', 'CPCDSP002'), -- tăng 75 triệu
('CPCD2SP2', N'Lương nhân viên', 620000000, '2024-06-01', 'CPCDSP002'),       -- tăng 200 triệu
('CPCD3SP2', N'Chi phí bảo trì thiết bị', 325000000, '2024-06-01', 'CPCDSP002'), -- tăng 150 triệu
('CPCD4SP2', N'Chi phí bảo hiểm', 445000000, '2024-06-01', 'CPCDSP002'),      -- tăng 250 triệu

-- Chi phí biến đổi
('CPBD5SP2', N'Nguyên liệu đầu vào', 1400000000, '2024-06-01', 'CPBDSP002'), -- tăng 300 triệu
('CPBD6SP2', N'Chi phí vận chuyển', 550000000, '2024-06-01', 'CPBDSP002'),   -- tăng 200 triệu
('CPBD7SP2', N'Chi phí marketing', 520000000, '2024-06-01', 'CPBDSP002'),    -- tăng 300 triệu
('CPBD8SP2', N'Chi phí đóng gói sản phẩm', 420000000, '2024-06-01', 'CPBDSP002'), -- tăng 260 triệu

-- Chi phí gián tiếp
('CPGT9SP2', N'Chi phí hành chính', 680000000, '2024-06-01', 'CPGTSP002'),    -- tăng 400 triệu
('CPGT10SP2', N'Chi phí điện, nước, văn phòng', 500000000, '2024-06-01', 'CPGTSP002'), -- tăng 220 triệu

-- SP002 (Nước ép cam Vinamilk) từ tháng 7 đến tháng 11
('CPCD11SP2', N'Chi phí thuê mặt bằng', 375000000, '2024-07-01', 'CPCDSP002'), -- tăng 100 triệu
('CPCD12SP2', N'Lương nhân viên', 720000000, '2024-07-01', 'CPCDSP002'),       -- tăng 300 triệu
('CPCD13SP2', N'Chi phí bảo trì thiết bị', 400000000, '2024-07-01', 'CPCDSP002'), -- tăng 225 triệu
('CPCD14SP2', N'Chi phí bảo hiểm', 645000000, '2024-07-01', 'CPCDSP002'),      -- tăng 450 triệu
('CPBD15SP2', N'Nguyên liệu đầu vào', 1500000000, '2024-07-01', 'CPBDSP002'), -- tăng 400 triệu
('CPBD16SP2', N'Chi phí vận chuyển', 700000000, '2024-07-01', 'CPBDSP002'),   -- tăng 350 triệu
('CPBD17SP2', N'Chi phí marketing', 720000000, '2024-07-01', 'CPBDSP002'),    -- tăng 500 triệu
('CPBD18SP2', N'Chi phí đóng gói sản phẩm', 560000000, '2024-07-01', 'CPBDSP002'), -- tăng 400 triệu
('CPGT19SP2', N'Chi phí hành chính', 880000000, '2024-07-01', 'CPGTSP002'),    -- tăng 600 triệu
('CPGT20SP2', N'Chi phí điện, nước, văn phòng', 680000000, '2024-07-01', 'CPGTSP002'), -- tăng 400 triệu

('CPCD21SP2', N'Chi phí thuê mặt bằng', 400000000, '2024-08-01', 'CPCDSP002'), -- tăng 125 triệu
('CPCD22SP2', N'Lương nhân viên', 770000000, '2024-08-01', 'CPCDSP002'),       -- tăng 350 triệu
('CPCD23SP2', N'Chi phí bảo trì thiết bị', 525000000, '2024-08-01', 'CPCDSP002'), -- tăng 350 triệu
('CPCD24SP2', N'Chi phí bảo hiểm', 695000000, '2024-08-01', 'CPCDSP002'),      -- tăng 500 triệu
('CPBD25SP2', N'Nguyên liệu đầu vào', 1600000000, '2024-08-01', 'CPBDSP002'), -- tăng 500 triệu
('CPBD26SP2', N'Chi phí vận chuyển', 800000000, '2024-08-01', 'CPBDSP002'),   -- tăng 450 triệu
('CPBD27SP2', N'Chi phí marketing', 900000000, '2024-08-01', 'CPBDSP002'),    -- tăng 680 triệu
('CPBD28SP2', N'Chi phí đóng gói sản phẩm', 710000000, '2024-08-01', 'CPBDSP002'), -- tăng 550 triệu
('CPGT29SP2', N'Chi phí hành chính', 980000000, '2024-08-01', 'CPGTSP002'),    -- tăng 700 triệu
('CPGT30SP2', N'Chi phí điện, nước, văn phòng', 830000000, '2024-08-01', 'CPGTSP002'), -- tăng 550 triệu
-- Chi phí cho tháng 9
('CPCD31SP2', N'Chi phí thuê mặt bằng', 325000000, '2024-09-01', 'CPCDSP002'), -- tăng 50 triệu
('CPCD32SP2', N'Lương nhân viên', 600000000, '2024-09-01', 'CPCDSP002'),       -- tăng 180 triệu
('CPCD33SP2', N'Chi phí bảo trì thiết bị', 275000000, '2024-09-01', 'CPCDSP002'), -- tăng 100 triệu
('CPCD34SP2', N'Chi phí bảo hiểm', 395000000, '2024-09-01', 'CPCDSP002'),      -- tăng 200 triệu
('CPBD35SP2', N'Nguyên liệu đầu vào', 1450000000, '2024-09-01', 'CPBDSP002'), -- tăng 350 triệu
('CPBD36SP2', N'Chi phí vận chuyển', 600000000, '2024-09-01', 'CPBDSP002'),   -- tăng 250 triệu
('CPBD37SP2', N'Chi phí marketing', 520000000, '2024-09-01', 'CPBDSP002'),    -- tăng 300 triệu
('CPBD38SP2', N'Chi phí đóng gói sản phẩm', 410000000, '2024-09-01', 'CPBDSP002'), -- tăng 250 triệu
('CPGT39SP2', N'Chi phí hành chính', 680000000, '2024-09-01', 'CPGTSP002'),    -- tăng 400 triệu
('CPGT40SP2', N'Chi phí điện, nước, văn phòng', 530000000, '2024-09-01', 'CPGTSP002'), -- tăng 250 triệu

-- Chi phí cho tháng 10
('CPCD41SP2', N'Chi phí thuê mặt bằng', 345000000, '2024-10-01', 'CPCDSP002'), -- tăng 70 triệu
('CPCD42SP2', N'Lương nhân viên', 680000000, '2024-10-01', 'CPCDSP002'),       -- tăng 260 triệu
('CPCD43SP2', N'Chi phí bảo trì thiết bị', 275000000, '2024-10-01', 'CPCDSP002'), -- tăng 100 triệu
('CPCD44SP2', N'Chi phí bảo hiểm', 445000000, '2024-10-01', 'CPCDSP002'),      -- tăng 250 triệu
('CPBD45SP2', N'Nguyên liệu đầu vào', 1550000000, '2024-10-01', 'CPBDSP002'), -- tăng 450 triệu
('CPBD46SP2', N'Chi phí vận chuyển', 700000000, '2024-10-01', 'CPBDSP002'),   -- tăng 350 triệu
('CPBD47SP2', N'Chi phí marketing', 650000000, '2024-10-01', 'CPBDSP002'),    -- tăng 430 triệu
('CPBD48SP2', N'Chi phí đóng gói sản phẩm', 560000000, '2024-10-01', 'CPBDSP002'), -- tăng 400 triệu
('CPGT49SP2', N'Chi phí hành chính', 780000000, '2024-10-01', 'CPGTSP002'),    -- tăng 500 triệu
('CPGT50SP2', N'Chi phí điện, nước, văn phòng', 630000000, '2024-10-01', 'CPGTSP002'), -- tăng 350 triệu

-- Chi phí cho tháng 11
('CPCD51SP2', N'Chi phí thuê mặt bằng', 365000000, '2024-11-01', 'CPCDSP002'), -- tăng 90 triệu
('CPCD52SP2', N'Lương nhân viên', 800000000, '2024-11-01', 'CPCDSP002'),       -- tăng 380 triệu
('CPCD53SP2', N'Chi phí bảo trì thiết bị', 275000000, '2024-11-01', 'CPCDSP002'), -- tăng 100 triệu
('CPCD54SP2', N'Chi phí bảo hiểm', 545000000, '2024-11-01', 'CPCDSP002'),      -- tăng 350 triệu
('CPBD55SP2', N'Nguyên liệu đầu vào', 1600000000, '2024-11-01', 'CPBDSP002'), -- tăng 500 triệu
('CPBD56SP2', N'Chi phí vận chuyển', 750000000, '2024-11-01', 'CPBDSP002'),   -- tăng 400 triệu
('CPBD57SP2', N'Chi phí marketing', 750000000, '2024-11-01', 'CPBDSP002'),    -- tăng 530 triệu
('CPBD58SP2', N'Chi phí đóng gói sản phẩm', 610000000, '2024-11-01', 'CPBDSP002'), -- tăng 450 triệu
('CPGT59SP2', N'Chi phí hành chính', 880000000, '2024-11-01', 'CPGTSP002'),    -- tăng 600 triệu
('CPGT60SP2', N'Chi phí điện, nước, văn phòng', 730000000, '2024-11-01', 'CPGTSP002'); -- tăng 450 triệu


INSERT INTO ThiTruong (MaThiTruong, LoaiThiTruong, MoTa, GiaTri, ThoiGian, MaSanPham)
VALUES 
('TT2', N'Thị phần sản phẩm', N'Thị phần của sản phẩm Nước ép cam trong thị trường nước ép trái cây tự nhiên tại Việt Nam.', 10.3, '2024-06-01', 'SP002')

-- Insert into LoiNhuan table
INSERT INTO LoiNhuan (MaLoiNhuan, MaSanPham, LoiNhuanGop, LoiNhuanRong, ThoiGian)
VALUES 
('LN1SP002', 'SP002', 1178000000, 752000000, '2024-06-30'),
('LN2SP002', 'SP002', 1551000000, 799000000, '2024-07-30'),
('LN3SP002', 'SP002', 1914000000, 1044000000, '2024-08-30'),
('LN4SP002', 'SP002', 2145000000, 1235000000, '2024-09-30'),
('LN5SP002', 'SP002', 2277000000, 1380000000, '2024-10-30'),
('LN6SP002', 'SP002', 2475000000, 1500000000, '2024-11-30');

-- Chèn dữ liệu vào bảng LoaiDoanhThu
-- Chèn dữ liệu vào bảng LoaiDoanhThu
INSERT INTO LoaiDoanhThu (MaLoaiDoanhThu, TenLoaiDoanhThu, MoTa, TongTien, MaSanPham)
VALUES
('DT1SP002', N'Doanh thu bán trực tiếp', N'Doanh thu từ việc bán hàng trực tiếp tại cửa hàng', 1800000000, 'SP002'),
('DT2SP002', N'Doanh thu bán trực tuyến', N'Doanh thu từ việc bán hàng qua các kênh trực tuyến', 1100000000, 'SP002'),
('DT3SP002', N'Doanh thu bán qua đối tác phân phối', N'Doanh thu từ việc bán hàng qua các đối tác phân phối', 900000000, 'SP002');

-- Chèn dữ liệu vào bảng DoanhThu
-- Doanh thu bán trực tiếp
INSERT INTO DoanhThu (MaDoanhThu, MaLoaiDoanhThu, MoTa, SoTien, ThoiGian)
VALUES
('DT006SP002', 'DT1SP002', N'Doanh thu bán trực tiếp tháng 6', 1800000000, '2024-06-30'),
('DT007SP002', 'DT1SP002', N'Doanh thu bán trực tiếp tháng 7', 2200000000, '2024-07-30'),
('DT008SP002', 'DT1SP002', N'Doanh thu bán trực tiếp tháng 8', 2700000000, '2024-08-30'),
('DT009SP002', 'DT1SP002', N'Doanh thu bán trực tiếp tháng 9', 3000000000, '2024-09-30'),
('DT010SP002', 'DT1SP002', N'Doanh thu bán trực tiếp tháng 10', 3200000000, '2024-10-30'),
('DT011SP002', 'DT1SP002', N'Doanh thu bán trực tiếp tháng 11', 3500000000, '2024-11-30');

-- Doanh thu bán trực tuyến
INSERT INTO DoanhThu (MaDoanhThu, MaLoaiDoanhThu, MoTa, SoTien, ThoiGian)
VALUES
('DT012SP002', 'DT2SP002', N'Doanh thu bán trực tuyến tháng 6', 1100000000, '2024-06-01'),
('DT013SP002', 'DT2SP002', N'Doanh thu bán trực tuyến tháng 7', 1400000000, '2024-07-01'),
('DT014SP002', 'DT2SP002', N'Doanh thu bán trực tuyến tháng 8', 1700000000, '2024-08-01'),
('DT015SP002', 'DT2SP002', N'Doanh thu bán trực tuyến tháng 9', 1900000000, '2024-09-01'),
('DT016SP002', 'DT2SP002', N'Doanh thu bán trực tuyến tháng 10', 2000000000, '2024-10-01'),
('DT017SP002', 'DT2SP002', N'Doanh thu bán trực tuyến tháng 11', 2200000000, '2024-11-01');

-- Doanh thu bán qua đối tác phân phối
INSERT INTO DoanhThu (MaDoanhThu, MaLoaiDoanhThu, MoTa, SoTien, ThoiGian)
VALUES
('DT018SP002', 'DT3SP002', N'Doanh thu bán qua đối tác phân phối tháng 6', 900000000, '2024-06-01'),
('DT019SP002', 'DT3SP002', N'Doanh thu bán qua đối tác phân phối tháng 7', 1100000000, '2024-07-01'),
('DT020SP002', 'DT3SP002', N'Doanh thu bán qua đối tác phân phối tháng 8', 1400000000, '2024-08-01'),
('DT021SP002', 'DT3SP002', N'Doanh thu bán qua đối tác phân phối tháng 9', 1600000000, '2024-09-01'),
('DT022SP002', 'DT3SP002', N'Doanh thu bán qua đối tác phân phối tháng 10', 1700000000, '2024-10-01'),
('DT023SP002', 'DT3SP002', N'Doanh thu bán qua đối tác phân phối tháng 11', 1800000000, '2024-11-01');