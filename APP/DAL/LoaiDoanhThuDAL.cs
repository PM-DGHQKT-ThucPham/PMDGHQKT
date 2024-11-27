using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoaiDoanhThuDAL
    {
        DoAnTotNghiepDataContext db = new DoAnTotNghiepDataContext();
        List<LoaiDoanhThu> _lstLoaiDoanhThu = null;

        // Lấy danh sách loại doanh thu theo mã sản phẩm
        public List<LoaiDoanhThu> LayDanhSachLoaiDoanhThu(string maSanPham)
        {
            try
            {
                _lstLoaiDoanhThu = new List<LoaiDoanhThu>();
                _lstLoaiDoanhThu = db.LoaiDoanhThus.Where(l =>l.MaSanPham==maSanPham).ToList();
                return _lstLoaiDoanhThu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Lấy loại doanh thu theo mã
        public LoaiDoanhThu LayLoaiDoanhThuTheoMa(string maLoaiDoanhThu,string maSanPham)
        {
            try
            {
                LoaiDoanhThu loaiDoanhThu = new LoaiDoanhThu();
                loaiDoanhThu = db.LoaiDoanhThus.FirstOrDefault(x => x.MaLoaiDoanhThu == maLoaiDoanhThu && x.MaSanPham==maSanPham);
                return loaiDoanhThu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CapNhatThemXoaSuaLoaiDoanhThu(List<LoaiDoanhThu> _lstLoaiDoanhThu)
        {
            try
            {
                using (var db = new DoAnTotNghiepDataContext()) // Thay bằng DbContext thực tế của bạn
                {
                    foreach (var loaiDoanhThu in _lstLoaiDoanhThu)
                    {
                        // Kiểm tra loại doanh thu có tồn tại trong DB không
                        var loaiDoanhThuDb = db.LoaiDoanhThus.SingleOrDefault(ldt => ldt.MaLoaiDoanhThu == loaiDoanhThu.MaLoaiDoanhThu);

                        if (loaiDoanhThuDb != null)
                        {
                            // Cập nhật loại doanh thu đã tồn tại
                            loaiDoanhThuDb.TenLoaiDoanhThu = loaiDoanhThu.TenLoaiDoanhThu;
                            loaiDoanhThuDb.MoTa = loaiDoanhThu.MoTa;
                            loaiDoanhThuDb.TongTien = loaiDoanhThu.TongTien;
                        }
                        else
                        {
                            // Thêm mới loại doanh thu
                            db.LoaiDoanhThus.InsertOnSubmit(loaiDoanhThu);
                        }
                    }

                    // Lấy danh sách mã loại doanh thu hiện có trong List
                    var danhSachLoaiDoanhThu = _lstLoaiDoanhThu.Select(ldt => ldt.MaLoaiDoanhThu).ToList();

                    // Lấy các loại doanh thu trong cơ sở dữ liệu không tồn tại trong List
                    var loaiDoanhThuXoa = db.LoaiDoanhThus
                                            .Where(ldt => !danhSachLoaiDoanhThu.Contains(ldt.MaLoaiDoanhThu))
                                            .ToList();

                    // Xóa các loại doanh thu này khỏi cơ sở dữ liệu
                    if (loaiDoanhThuXoa.Count > 0)
                    {
                        db.LoaiDoanhThus.DeleteAllOnSubmit(loaiDoanhThuXoa);
                    }

                    // Lưu thay đổi
                    db.SubmitChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật loại doanh thu: {ex.Message}");
                return false;
            }
        }

    }
}
