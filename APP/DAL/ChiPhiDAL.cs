using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class ChiPhiDAL
    {
        DoAnTotNghiepDataContext db = new DoAnTotNghiepDataContext();
        List<ChiPhi> _lstChiPhi = null;
        public ChiPhiDAL()
        {
        }
        //lay danh sach chi phi theo mã sản phẩm
        public List<ChiPhi> LayDanhSachChiPhi(string maSanPham)
        {
            try
            {
                _lstChiPhi = new List<ChiPhi>();
                _lstChiPhi = db.ChiPhis.Where(t => t.LoaiChiPhi.MaSanPham == maSanPham).ToList();
                if (_lstChiPhi.Count > 0)
                {
                    return _lstChiPhi;
                }
            }
            catch
            {
                return null;
            }
            return new List<ChiPhi>(); // Ensure a return value in all code paths
        }
        //lấy chi phí theo mã chi phí
        public ChiPhi LayChiPhiTheoMaChiPhi(string maChiPhi,string maSanPham)
        {
            try
            {
                ChiPhi _chiPhi = new ChiPhi();
                _chiPhi = db.ChiPhis.Where(t =>t.LoaiChiPhi.MaSanPham==maSanPham && t.MaChiPhi==maChiPhi).FirstOrDefault();
                if (_chiPhi != null)
                {
                    return _chiPhi;
                }
            }
            catch
            {
                return null;
            }
            return new ChiPhi(); // Ensure a return value in all code paths
        }
        //lấy chi phí theo mã loại chi phí
        public List<ChiPhi> LayChiPhiTheoMaLoaiChiPhi(string maLoaiChiPhi,string maSanPham)
        {
            try
            {
                _lstChiPhi = new List<ChiPhi>();
                _lstChiPhi = db.ChiPhis.Where(x => x.MaLoaiChiPhi == maLoaiChiPhi && x.LoaiChiPhi.MaSanPham==maSanPham).ToList();
                if (_lstChiPhi.Count > 0)
                {
                    return _lstChiPhi;
                }
            }
            catch
            {
                return null;
            }
            return new List<ChiPhi>(); // Ensure a return value in all code paths
        }
        //lấy chi phí theo tháng năm
        public List<ChiPhi> LayChiPhiTheoThangNam(int thang, int nam,string maSanPham)
        {
            try
            {
                _lstChiPhi = new List<ChiPhi>();
                _lstChiPhi = db.ChiPhis.Where( x =>x.LoaiChiPhi.MaSanPham==maSanPham && x.ThoiGian.HasValue && x.ThoiGian.Value.Month == thang && x.ThoiGian.Value.Year == nam).ToList();
                if (_lstChiPhi.Count > 0)
                {
                    return _lstChiPhi;
                }
            }
            catch
            {
                return null;
            }
            return new List<ChiPhi>(); // Ensure a return value in all code paths
        }
        //lấy chi phí theo khoảng thời gian của 1 san phẩm
        public List<ChiPhi> LayChiPhiTheoKhoangThoiGian(DateTime tuNgay, DateTime denNgay, string maSanPham)
        {
            try
            {
                _lstChiPhi = new List<ChiPhi>();
                _lstChiPhi = db.ChiPhis.Where(x => x.LoaiChiPhi.MaSanPham == maSanPham && x.ThoiGian >= tuNgay && x.ThoiGian <= denNgay).ToList();
                if (_lstChiPhi.Count > 0)
                {
                    return _lstChiPhi;
                }
            }
            catch 
            {
                return null;
            }
            return new List<ChiPhi>(); // Ensure a return value in all code paths
        }
        public bool CapNhatThemXoaSuaChiPhi(List<ChiPhi> _lstChiPhi, string maLoaiChiPhi)
        {
            try
            {
                using (var db = new DoAnTotNghiepDataContext()) // Thay bằng DbContext thực tế của bạn
                {
                    foreach (var cp in _lstChiPhi)
                    {
                        // Kiểm tra chi phí có tồn tại trong DB không
                        var cpdb = db.ChiPhis.SingleOrDefault(c => c.MaChiPhi == cp.MaChiPhi && c.MaLoaiChiPhi == maLoaiChiPhi);

                        if (cpdb != null)
                        {
                            // Cập nhật chi phí đã tồn tại
                            cpdb.MoTa = cp.MoTa;
                            cpdb.SoTien = cp.SoTien;
                            cpdb.ThoiGian = cp.ThoiGian;
                        }
                        else
                        {
                            // Thêm mới chi phí nếu thuộc loại chi phí hiện tại
                            cp.MaLoaiChiPhi = maLoaiChiPhi; // Gắn mã loại chi phí
                            db.ChiPhis.InsertOnSubmit(cp);
                        }
                    }

                    // Lấy danh sách mã chi phí hiện có trong List
                    var danhSachChiPhi = _lstChiPhi.Select(c => c.MaChiPhi).ToList();

                    // Lấy các chi phí trong cơ sở dữ liệu thuộc loại chi phí hiện tại nhưng không còn trong danh sách (để xóa)
                    var chiPhiXoa = db.ChiPhis
                                      .Where(c => c.MaLoaiChiPhi == maLoaiChiPhi && !danhSachChiPhi.Contains(c.MaChiPhi))
                                      .ToList();

                    // Xóa các chi phí không còn trong danh sách
                    if (chiPhiXoa.Count > 0)
                    {
                        db.ChiPhis.DeleteAllOnSubmit(chiPhiXoa);
                    }

                    // Lưu thay đổi
                    db.SubmitChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật chi phí: {ex.Message}");
                return false;
            }
        }
    }
}
