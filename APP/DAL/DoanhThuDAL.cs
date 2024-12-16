using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DoanhThuDAL
    {
        DoAnTotNghiepDataContext db = new DoAnTotNghiepDataContext();
        List<DoanhThu> _lstDoanhThu = null;

        // Lấy danh sách doanh thu theo san phẩm
        public List<DoanhThu> LayDanhSachDoanhThu(string maSanPham)
        {
            try
            {
                _lstDoanhThu = new List<DoanhThu>();
                _lstDoanhThu = db.DoanhThus.Where(d => d.LoaiDoanhThu.MaSanPham == maSanPham).OrderByDescending(x => x.ThoiGian).ToList();
                return _lstDoanhThu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Lấy doanh thu theo mã
        public DoanhThu LayDoanhThuTheoMa(string maDoanhThu, string maSanPham)
        {
            try
            {
                DoanhThu doanhThu = new DoanhThu();
                doanhThu = db.DoanhThus.FirstOrDefault(x => x.MaDoanhThu == maDoanhThu && x.LoaiDoanhThu.MaSanPham == maSanPham);
                return doanhThu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //lấy doanh thu theo mã loại doanh thu
        public List<DoanhThu> LayDoanhThuTheoMaLoaiDoanhThu(string maLoaiDoanhThu, string maSanPham)
        {
            try
            {
                _lstDoanhThu = new List<DoanhThu>();
                _lstDoanhThu = db.DoanhThus.Where(x => x.MaLoaiDoanhThu == maLoaiDoanhThu && x.LoaiDoanhThu.MaSanPham == maSanPham).OrderByDescending(x => x.ThoiGian).ToList();
                return _lstDoanhThu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //lấy doanh thu theo ngày
        public List<DoanhThu> LayDoanhThuTheoNgay(DateTime ngay, string maSanPham)
        {
            try
            {
                _lstDoanhThu = new List<DoanhThu>();
                _lstDoanhThu = db.DoanhThus.Where(x => x.ThoiGian == ngay && x.LoaiDoanhThu.MaSanPham == maSanPham).OrderByDescending(x => x.ThoiGian).ToList();
                return _lstDoanhThu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //lấy doanh thu theo tháng
        public List<DoanhThu> LayDoanhThuTheoThang(int thang, int nam, string maSanPham)
        {
            try
            {
                _lstDoanhThu = new List<DoanhThu>();
                _lstDoanhThu = db.DoanhThus.Where(x => x.LoaiDoanhThu.MaSanPham == maSanPham && x.ThoiGian.HasValue && x.ThoiGian.Value.Month == thang && x.ThoiGian.Value.Year == nam).OrderByDescending(x => x.ThoiGian).ToList();
                return _lstDoanhThu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //lấy doanh thu theo khoảng thời gian
        public List<DoanhThu> LayDoanhThuTheoKhoangThoiGian(DateTime tuNgay, DateTime denNgay, string maSanPham)
        {
            try
            {
                _lstDoanhThu = new List<DoanhThu>();
                _lstDoanhThu = db.DoanhThus.Where(x => x.LoaiDoanhThu.MaSanPham == maSanPham && x.ThoiGian >= tuNgay && x.ThoiGian <= denNgay).OrderByDescending(x => x.ThoiGian).ToList();
                return _lstDoanhThu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CapNhatThemXoaSuaDoanhThu(List<DoanhThu> _lstDoanhThu, string maLoaiDoanhThu)
        {
            try
            {
                using (var db = new DoAnTotNghiepDataContext()) // Thay bằng DbContext thực tế của bạn
                {
                    foreach (var dt in _lstDoanhThu)
                    {
                        // Kiểm tra doanh thu có tồn tại trong DB không
                        var dtDb = db.DoanhThus.SingleOrDefault(d => d.MaDoanhThu == dt.MaDoanhThu && d.MaLoaiDoanhThu == maLoaiDoanhThu);

                        if (dtDb != null)
                        {
                            // Cập nhật doanh thu đã tồn tại
                            dtDb.MoTa = dt.MoTa;
                            dtDb.SoTien = dt.SoTien;
                            dtDb.ThoiGian = dt.ThoiGian;
                        }
                        else
                        {
                            // Thêm mới doanh thu nếu thuộc loại doanh thu hiện tại
                            dt.MaLoaiDoanhThu = maLoaiDoanhThu; // Gắn mã loại doanh thu
                            db.DoanhThus.InsertOnSubmit(dt);
                        }
                    }

                    // Lấy danh sách mã doanh thu hiện có trong List
                    var danhSachDoanhThu = _lstDoanhThu.Select(d => d.MaDoanhThu).ToList();

                    // Lấy các doanh thu trong cơ sở dữ liệu thuộc loại doanh thu hiện tại nhưng không còn trong danh sách (để xóa)
                    var doanhThuXoa = db.DoanhThus
                                        .Where(d => d.MaLoaiDoanhThu == maLoaiDoanhThu && !danhSachDoanhThu.Contains(d.MaDoanhThu))
                                        .ToList();

                    // Xóa các doanh thu không còn trong danh sách
                    if (doanhThuXoa.Count > 0)
                    {
                        db.DoanhThus.DeleteAllOnSubmit(doanhThuXoa);
                    }

                    // Lưu thay đổi
                    db.SubmitChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật doanh thu: {ex.Message}");
                return false;
            }
        }
        public List<(DateTime Thang, string LoaiDoanhThu, decimal DoanhThu, decimal TiLeTangTruong)> TinhTiLeTangTruongTheoLoai(string maSanPham)
        {
            try
            {
                // Lấy danh sách doanh thu nhóm theo loại doanh thu và tháng
                var doanhThuTheoLoai = db.DoanhThus
                    .Where(d => d.LoaiDoanhThu.MaSanPham == maSanPham)
                    .GroupBy(d => new { d.LoaiDoanhThu.TenLoaiDoanhThu, Thang = new DateTime(d.ThoiGian.Value.Year, d.ThoiGian.Value.Month, 1) }) // Nhóm theo loại và tháng
                    .Select(g => new
                    {
                        g.Key.TenLoaiDoanhThu,
                        g.Key.Thang,
                        TongDoanhThu = g.Sum(x => x.SoTien)
                    })
                    .OrderBy(d => d.Thang) // Sắp xếp theo thời gian
                    .ToList();

                // Nhóm danh sách theo loại doanh thu
                var doanhThuTheoLoaiNhom = doanhThuTheoLoai.GroupBy(d => d.TenLoaiDoanhThu);

                var ketQua = new List<(DateTime Thang, string LoaiDoanhThu, decimal DoanhThu, decimal TiLeTangTruong)>();

                // Xử lý từng nhóm loại doanh thu
                foreach (var nhom in doanhThuTheoLoaiNhom)
                {
                    var doanhThuThangDau = nhom.First().TongDoanhThu; // Doanh thu tháng đầu tiên của nhóm này

                    // Tính tỷ lệ tăng trưởng cho từng tháng
                    var ketQuaTheoLoai = nhom.Select(d => (
                      d.Thang,
                      d.TenLoaiDoanhThu,
                      d.TongDoanhThu ?? 0, // Đảm bảo giá trị không bị null
                         TiLeTangTruong: doanhThuThangDau > 0
                        ? (decimal)Math.Round((double)((d.TongDoanhThu ?? 0 - doanhThuThangDau) / doanhThuThangDau) * 100, 2)
                        : 0

                  )).ToList();


                    ketQua.AddRange(ketQuaTheoLoai);
                }

                return ketQua;
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi tính tỷ lệ tăng trưởng theo loại doanh thu: " + ex.Message);
            }
        }
    }
}
