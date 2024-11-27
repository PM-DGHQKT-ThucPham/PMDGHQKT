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
                _lstDoanhThu = db.DoanhThus.Where(d =>d.LoaiDoanhThu.MaSanPham==maSanPham).ToList();
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
                doanhThu = db.DoanhThus.FirstOrDefault(x => x.MaDoanhThu == maDoanhThu && x.LoaiDoanhThu.MaSanPham==maSanPham);
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
                _lstDoanhThu = db.DoanhThus.Where(x => x.MaLoaiDoanhThu == maLoaiDoanhThu && x.LoaiDoanhThu.MaSanPham==maSanPham).ToList();
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
                _lstDoanhThu = db.DoanhThus.Where(x => x.ThoiGian == ngay && x.LoaiDoanhThu.MaSanPham == maSanPham).ToList();
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
                _lstDoanhThu = db.DoanhThus.Where(x =>x.LoaiDoanhThu.MaSanPham==maSanPham && x.ThoiGian.HasValue && x.ThoiGian.Value.Month == thang && x.ThoiGian.Value.Year == nam ).ToList();
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
                _lstDoanhThu = db.DoanhThus.Where(x =>x.LoaiDoanhThu.MaSanPham==maSanPham && x.ThoiGian >= tuNgay && x.ThoiGian <= denNgay).ToList();
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

    }
}
