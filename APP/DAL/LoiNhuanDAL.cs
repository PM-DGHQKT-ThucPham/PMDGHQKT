using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class LoiNhuanDAL
    {
        readonly DoAnTotNghiepDataContext db = new DoAnTotNghiepDataContext();
        List<LoiNhuan> _lstLoiNhuan = new List<LoiNhuan>();
        public LoiNhuanDAL() { }
        //lấy tất cả lợi nhuận theo mã sản phẩm
        public List<LoiNhuan> LayTatCaLoiNhuanTheoMaSanPham(string maSP)
        {
            try
            {
                _lstLoiNhuan = db.LoiNhuans.Where(x => x.MaSanPham == maSP).ToList();
                return _lstLoiNhuan;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // lấy tất cả lợi nhuận theo mã và mã sản phẩm
        public LoiNhuan LayLoiNhuanTheoMa(string maLoiNhuan, string maSP)
        {
            try
            {
                LoiNhuan loiNhuan = db.LoiNhuans.Where(x => x.MaLoiNhuan == maLoiNhuan && x.MaSanPham == maSP).FirstOrDefault();
                return loiNhuan;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // lấy lợi nhuận theo tháng năm và mã sản phẩm
        public List<LoiNhuan> LayLoiNhuanTheoThangNam(int thang, int nam, string maSP)
        {
            try
            {
                _lstLoiNhuan = db.LoiNhuans.Where(x => x.ThoiGian.Value.Month == thang && x.ThoiGian.Value.Year == nam && x.MaSanPham == maSP).ToList();
                if (_lstLoiNhuan.Count > 0)
                {
                    return _lstLoiNhuan;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // lấy lợi nhuận theo khoảng thời gian và mã sản phẩm
        public List<LoiNhuan> LayLoiNhuanTheoKhoangThoiGian(DateTime tuNgay, DateTime denNgay, string maSP)
        {
            try
            {
                _lstLoiNhuan = db.LoiNhuans
                    .Where(x => x.ThoiGian.HasValue && x.ThoiGian.Value >= tuNgay && x.ThoiGian.Value <= denNgay && x.MaSanPham == maSP)
                    .ToList();
                return _lstLoiNhuan;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Tính lợi nhuận gộp
        // Tính lợi nhuận gộp
        public decimal TinhLoiNhuanGop(string maSP, int thang, int nam)
        {
            string maLoaiChiPhiBD = "";
            if (maSP == "SP001")
            {
                maLoaiChiPhiBD = "CPBD";
            }
            else
            {
                maLoaiChiPhiBD = "CPBDSP002";
            }
            try
            {
                // Lấy doanh thu của tháng và sản phẩm
                var doanhThu = db.DoanhThus
                    .Where(x => x.LoaiDoanhThu.MaSanPham == maSP && x.ThoiGian.Value.Month == thang && x.ThoiGian.Value.Year == nam)
                    .Sum(x => x.SoTien) ?? 0; // Tính tổng doanh thu, trả về 0 nếu không có dữ liệu

                // Lấy chi phí biến đổi của tháng và sản phẩm
                var chiPhiBienDoi = db.ChiPhis
                    .Where(x => x.LoaiChiPhi.MaSanPham == maSP && x.MaLoaiChiPhi == maLoaiChiPhiBD && x.ThoiGian.Value.Month == thang && x.ThoiGian.Value.Year == nam)
                    .Sum(x => x.SoTien) ?? 0; // Tính tổng chi phí biến đổi, trả về 0 nếu không có dữ liệu

                // Tính lợi nhuận gộp
                return doanhThu - chiPhiBienDoi;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Tính lợi nhuận ròng
        public decimal TinhLoiNhuanRong(string maSP, int thang, int nam)
        {
            string maLoaiChiPhiCD = "";
            string maLoaiChiPhiGT = "";
            if (maSP =="SP001")
            {
                maLoaiChiPhiCD = "CPCD";
                maLoaiChiPhiGT = "CPGT";
            }
            else
            {
                maLoaiChiPhiCD = "CPCDSP002";
                maLoaiChiPhiGT = "CPGTSP002";
            }    
            
            try
            {
                // Lợi nhuận gộp
                decimal loiNhuanGop = TinhLoiNhuanGop(maSP, thang, nam);

                // Lấy chi phí cố định và chi phí gián tiếp của tháng và sản phẩm
                var chiPhiCoDinh = db.ChiPhis
                    .Where(x => x.LoaiChiPhi.MaSanPham == maSP && x.MaLoaiChiPhi == maLoaiChiPhiCD && x.ThoiGian.Value.Month == thang && x.ThoiGian.Value.Year == nam)
                    .Sum(x => x.SoTien) ?? 0; // Tính tổng chi phí cố định, trả về 0 nếu không có dữ liệu

                var chiPhiGianTiep = db.ChiPhis
                    .Where(x => x.LoaiChiPhi.MaSanPham == maSP && x.MaLoaiChiPhi == maLoaiChiPhiGT && x.ThoiGian.Value.Month == thang && x.ThoiGian.Value.Year == nam)
                    .Sum(x => x.SoTien) ?? 0; // Tính tổng chi phí gián tiếp, trả về 0 nếu không có dữ liệu

                // Tính lợi nhuận ròng
                return loiNhuanGop - chiPhiCoDinh - chiPhiGianTiep;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Hàm cập nhật lợi nhuận gộp và lợi nhuận ròng theo tháng
        public bool CapNhatLoiNhuanTheoThang(int thang, int nam,string maSP)
        {
            string maLoaiChiPhiBD = "";
            string maLoaiChiPhiCD = "";
            string maLoaiChiPhiGT = "";
            if (maSP == "SP001")
            {
                maLoaiChiPhiBD = "CPBD";
                maLoaiChiPhiCD = "CPCD";
                maLoaiChiPhiGT = "CPGT";
            }
            else
            {
                maLoaiChiPhiBD = "CPBDSP002";
                maLoaiChiPhiCD = "CPCDSP002";
                maLoaiChiPhiGT = "CPGTSP002";
            }
            try
            {
                // Lấy danh sách tất cả các sản phẩm
                var danhSachSanPham = db.SanPhams.ToList();

                foreach (var sanPham in danhSachSanPham)
                {
                    // Tính tổng doanh thu của sản phẩm theo tháng và năm
                    decimal doanhThu = db.DoanhThus
                        .Where(x => x.LoaiDoanhThu.MaSanPham == sanPham.MaSanPham && x.ThoiGian.Value.Month == thang && x.ThoiGian.Value.Year == nam)
                        .Sum(x => x.SoTien) ?? 0;  // Trả về 0 nếu không có dữ liệu

                    // Tính chi phí biến đổi của sản phẩm theo tháng và năm
                    decimal chiPhiBienDoi = db.ChiPhis
                        .Where(x => x.LoaiChiPhi.MaSanPham == sanPham.MaSanPham && x.MaLoaiChiPhi == maLoaiChiPhiBD && x.ThoiGian.Value.Month == thang && x.ThoiGian.Value.Year == nam)
                        .Sum(x => x.SoTien) ?? 0;  // Trả về 0 nếu không có dữ liệu

                    // Tính chi phí cố định của sản phẩm theo tháng và năm
                    decimal chiPhiCoDinh = db.ChiPhis
                        .Where(x => x.LoaiChiPhi.MaSanPham == sanPham.MaSanPham && x.MaLoaiChiPhi == maLoaiChiPhiCD && x.ThoiGian.Value.Month == thang && x.ThoiGian.Value.Year == nam)
                        .Sum(x => x.SoTien) ?? 0;  // Trả về 0 nếu không có dữ liệu

                    // Tính chi phí gián tiếp của sản phẩm theo tháng và năm
                    decimal chiPhiGianTiep = db.ChiPhis
                        .Where(x => x.LoaiChiPhi.MaSanPham == sanPham.MaSanPham && x.MaLoaiChiPhi == maLoaiChiPhiGT && x.ThoiGian.Value.Month == thang && x.ThoiGian.Value.Year == nam)
                        .Sum(x => x.SoTien) ?? 0;  // Trả về 0 nếu không có dữ liệu

                    // Tính lợi nhuận gộp
                    decimal loiNhuanGop = doanhThu - chiPhiBienDoi;

                    // Tính lợi nhuận ròng
                    decimal loiNhuanRong = loiNhuanGop - chiPhiCoDinh - chiPhiGianTiep;

                    // Kiểm tra xem đã có bản ghi lợi nhuận cho tháng và sản phẩm này chưa
                    var loiNhuanExist = db.LoiNhuans
                        .FirstOrDefault(x => x.MaSanPham == sanPham.MaSanPham && x.ThoiGian.Value.Month == thang && x.ThoiGian.Value.Year == nam);

                    if (loiNhuanExist != null)
                    {
                        // Nếu đã có lợi nhuận, cập nhật thông tin
                        loiNhuanExist.LoiNhuanGop = loiNhuanGop;
                        loiNhuanExist.LoiNhuanRong = loiNhuanRong;
                    }
                    else
                    {
                        // Nếu chưa có lợi nhuận, tạo mới bản ghi
                        LoiNhuan newLoiNhuan = new LoiNhuan
                        {
                            MaSanPham = sanPham.MaSanPham,
                            ThoiGian = new DateTime(nam, thang, 1), // Cập nhật tháng và năm
                            LoiNhuanGop = loiNhuanGop,
                            LoiNhuanRong = loiNhuanRong
                        };
                        db.LoiNhuans.InsertOnSubmit(newLoiNhuan); // Thêm mới vào bảng
                    }
                }

                // Lưu tất cả thay đổi vào cơ sở dữ liệu sau khi đã cập nhật xong
                db.SubmitChanges();
                
                return true; // Trả về true khi cập nhật thành công
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                // Log lỗi nếu có
                return false; // Trả về false nếu có lỗi
            }
        }
        // Hàm tính toán lợi nhuận gộp và ròng theo tháng, trả về tỷ lệ lợi nhuận mà không lưu vào DB
        public List<(string MaSanPham, decimal TyLeLoiNhuanGop, decimal TyLeLoiNhuanRong)> TinhTyLeLoiNhuan(int thang, int nam)
        {
            try
            {
                List<(string MaSanPham, decimal TyLeLoiNhuanGop, decimal TyLeLoiNhuanRong)> ketQua = new List<(string, decimal, decimal)>();

                // Lấy danh sách tất cả các sản phẩm
                var danhSachSanPham = db.SanPhams.ToList();

                foreach (var sanPham in danhSachSanPham)
                {
                    // Tính tổng doanh thu của sản phẩm theo tháng và năm
                    decimal doanhThu = db.DoanhThus
                        .Where(x => x.LoaiDoanhThu.MaSanPham == sanPham.MaSanPham && x.ThoiGian.Value.Month == thang && x.ThoiGian.Value.Year == nam)
                        .Sum(x => x.SoTien) ?? 0;  // Trả về 0 nếu không có dữ liệu

                    // Tính chi phí biến đổi của sản phẩm theo tháng và năm
                    decimal chiPhiBienDoi = db.ChiPhis
                        .Where(x => x.LoaiChiPhi.MaSanPham == sanPham.MaSanPham && x.MaLoaiChiPhi == "CPBD" && x.ThoiGian.Value.Month == thang && x.ThoiGian.Value.Year == nam)
                        .Sum(x => x.SoTien) ?? 0;  // Trả về 0 nếu không có dữ liệu

                    // Tính chi phí cố định của sản phẩm theo tháng và năm
                    decimal chiPhiCoDinh = db.ChiPhis
                        .Where(x => x.LoaiChiPhi.MaSanPham == sanPham.MaSanPham && x.MaLoaiChiPhi == "CPCD" && x.ThoiGian.Value.Month == thang && x.ThoiGian.Value.Year == nam)
                        .Sum(x => x.SoTien) ?? 0;  // Trả về 0 nếu không có dữ liệu

                    // Tính chi phí gián tiếp của sản phẩm theo tháng và năm
                    decimal chiPhiGianTiep = db.ChiPhis
                        .Where(x => x.LoaiChiPhi.MaSanPham == sanPham.MaSanPham && x.MaLoaiChiPhi == "CPGT" && x.ThoiGian.Value.Month == thang && x.ThoiGian.Value.Year == nam)
                        .Sum(x => x.SoTien) ?? 0;  // Trả về 0 nếu không có dữ liệu

                    // Tính lợi nhuận gộp
                    decimal loiNhuanGop = doanhThu - chiPhiBienDoi;

                    // Tính lợi nhuận ròng
                    decimal loiNhuanRong = loiNhuanGop - chiPhiCoDinh - chiPhiGianTiep;

                    // Tính tỷ lệ lợi nhuận gộp (Gross Profit Margin)
                    decimal tyLeLoiNhuanGop = doanhThu != 0 ? (loiNhuanGop / doanhThu) * 100 : 0;

                    // Tính tỷ lệ lợi nhuận ròng (Net Profit Margin)
                    decimal tyLeLoiNhuanRong = doanhThu != 0 ? (loiNhuanRong / doanhThu) * 100 : 0;

                    // Thêm kết quả vào danh sách trả về
                    ketQua.Add((sanPham.MaSanPham, tyLeLoiNhuanGop, tyLeLoiNhuanRong));
                }

                return ketQua;
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra khi tính toán tỷ lệ lợi nhuận", ex);
            }
        }
    }
}
