using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class LoaiChiPhiDAL
    {
        DoAnTotNghiepDataContext db = new DoAnTotNghiepDataContext();
        List<LoaiChiPhi> _lstLoaiChiPhi = null;
        public LoaiChiPhiDAL()
        {
        }
        //lay danh sach loai chi phi
        public List<LoaiChiPhi> LayDanhSachLoaiChiPhi(string maSanPham)
        {
            try
            {
                _lstLoaiChiPhi = new List<LoaiChiPhi>();
                _lstLoaiChiPhi = db.LoaiChiPhis.Where(t => t.MaSanPham == maSanPham).ToList();
                if (_lstLoaiChiPhi.Count > 0)
                {
                    return _lstLoaiChiPhi;
                }
            }
            catch
            {
                return null;
            }
            return new List<LoaiChiPhi>(); // Ensure a return value in all code paths
        }
        //lấy loại chi phí theo mã loại chi phí
        public LoaiChiPhi LayLoaiChiPhiTheoMaLoaiChiPhi(string maLoaiChiPhi, string maSanPham)
        {
            try
            {
                LoaiChiPhi _loaiChiPhi = new LoaiChiPhi();
                _loaiChiPhi = db.LoaiChiPhis.Where(t => t.MaLoaiChiPhi == maLoaiChiPhi && t.MaSanPham == maSanPham).FirstOrDefault();
                if (_loaiChiPhi != null)
                {
                    return _loaiChiPhi;
                }
            }
            catch
            {
                return null;
            }
            return new LoaiChiPhi(); // Ensure a return value in all code paths
        }
        public bool CapNhatThemXoaSua(List<LoaiChiPhi> _lst)
        {
            try
            {
                using (var db1 = new DoAnTotNghiepDataContext()) // Thay bằng DbContext thực tế của bạn
                {
                    foreach (var cp in _lst)
                    {
                        // Kiểm tra sản phẩm có tồn tại trong DB không
                        var cpdb = db1.LoaiChiPhis.SingleOrDefault(s => s.MaLoaiChiPhi == cp.MaLoaiChiPhi);

                        if (cpdb != null)
                        {
                            // Cập nhật sản phẩm đã tồn tại
                            cpdb.TenLoaiChiPhi = cp.TenLoaiChiPhi;
                            cpdb.MoTa = cp.MoTa;
                            cpdb.TongTien = cp.TongTien;
                            cpdb.MaSanPham = cp.MaSanPham;
                        }
                        else
                        {
                            // Thêm mới sản phẩm
                            db1.LoaiChiPhis.InsertOnSubmit(cp);
                        }
                    }

                    // Lấy danh sách mã sản phẩm hiện có trong List
                    var danhSachChiPhi = _lst.Select(s => s.MaSanPham).ToList();

                    // Lấy các sản phẩm trong cơ sở dữ liệu không tồn tại trong List
                    var sanPhamXoa = db1.SanPhams
                                       .Where(sp => !danhSachChiPhi.Contains(sp.MaSanPham))
                                       .ToList();

                    // Xóa các sản phẩm này khỏi cơ sở dữ liệu
                    if (sanPhamXoa.Count > 0)
                    {
                        db1.SanPhams.DeleteAllOnSubmit(sanPhamXoa);
                    }

                    // Lưu thay đổi
                    db1.SubmitChanges();
                }

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
