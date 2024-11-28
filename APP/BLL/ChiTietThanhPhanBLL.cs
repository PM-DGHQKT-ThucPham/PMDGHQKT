using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChiTietThanhPhanBLL
    {
        readonly ChiTietThanhPhanDAL dal = new  ChiTietThanhPhanDAL();
        readonly DoAnTotNghiepDataContext db = new DoAnTotNghiepDataContext();
        public bool CapNhatThemXoaSua(List<ChiTietThanhPhan> temp, string maSanPham)
        {
            try
            {
                if (string.IsNullOrEmpty(maSanPham))
                {
                    throw new ArgumentException("Mã sản phẩm không hợp lệ.");
                }

                // Nếu temp là null hoặc rỗng, xóa hết các chi tiết thành phần của MaSanPham
                if (temp == null || temp.Count == 0)
                {
                    var chiTietHienTai = db.ChiTietThanhPhans
                        .Where(x => x.MaSanPham == maSanPham)
                        .ToList();

                    foreach (var ct in chiTietHienTai)
                    {
                        db.ChiTietThanhPhans.DeleteOnSubmit(ct);
                    }

                    // Lưu thay đổi vào database
                    db.SubmitChanges();
                    return true;
                }

                // Lấy danh sách chi tiết thành phần hiện tại trong database của MaSanPham
                var chiTietHienTaiCuaSanPham = db.ChiTietThanhPhans
                    .Where(x => x.MaSanPham == maSanPham)
                    .ToList();

                // 1. Xóa các chi tiết thành phần không còn trong danh sách temp
                var chiTietCanXoa = chiTietHienTaiCuaSanPham
                    .Where(ct => !temp.Any(t => t.MaNguyenLieu == ct.MaNguyenLieu))
                    .ToList();

                foreach (var ct in chiTietCanXoa)
                {
                    db.ChiTietThanhPhans.DeleteOnSubmit(ct);
                }

                // 2. Cập nhật các chi tiết thành phần đã tồn tại
                foreach (var ctTemp in temp)
                {
                    var existing = chiTietHienTaiCuaSanPham
                        .FirstOrDefault(ct => ct.MaNguyenLieu == ctTemp.MaNguyenLieu);

                    if (existing != null)
                    {
                        // Cập nhật PhanTramNguyenLieu nếu khác
                        if (existing.PhanTramNguyenLieu != ctTemp.PhanTramNguyenLieu)
                        {
                            existing.PhanTramNguyenLieu = ctTemp.PhanTramNguyenLieu;
                        }
                    }
                    else
                    {
                        // 3. Thêm mới nếu chi tiết không tồn tại
                        ctTemp.MaSanPham = maSanPham; // Gán MaSanPham từ tham số vào
                        db.ChiTietThanhPhans.InsertOnSubmit(ctTemp);
                    }
                }

                // Lưu thay đổi vào database
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần
                Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
                return false;
            }
        }



        public List<ChiTietThanhPhan> LayCTTP_CuaSanPham(string masp)
        {
            return dal.LayCTTP_CuaSanPham(masp);
        }
        public List<ChiTietThanhPhan> LayCTTP_CuaNguyenLieu(string maNguyenLieu)
        {
            return dal.LayCTTP_CuaNguyenLieu(maNguyenLieu);
        }
    }
}
