using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ThiTruongBLL
    {
        ThiTruongDAL dal = new ThiTruongDAL();
        DoAnTotNghiepDataContext db = new DoAnTotNghiepDataContext();
        public List<ThiTruong> LayDanhSachThiTruongCuaSanPham(string masanpham)
        {
            // Sử dụng LINQ để lấy danh sách nguyên liệu của sản phẩm
            return dal.LayDanhSachThiTruongCuaSanPham(masanpham);
        }

        public ThiTruong LayThiTruong(string maThiTruong)
        {
            return LayThiTruong(maThiTruong);
        }

        public bool CapNhatThemXoaSuaThiTruong(List<ThiTruong> temp, string maSanPham)
        {
            try
            {
                if (string.IsNullOrEmpty(maSanPham))
                {
                    throw new ArgumentException("Mã sản phẩm không hợp lệ.");
                }

                // Nếu temp là null hoặc rỗng, xóa hết các thị trường của MaSanPham
                if (temp == null || temp.Count == 0)
                {
                    var thiTruongHienTai = db.ThiTruongs
                        .Where(x => x.MaSanPham == maSanPham)
                        .ToList();

                    foreach (var tt in thiTruongHienTai)
                    {
                        db.ThiTruongs.DeleteOnSubmit(tt);
                    }

                    // Lưu thay đổi vào database
                    db.SubmitChanges();
                    return true;
                }

                // Lấy danh sách thị trường hiện tại trong database của MaSanPham
                var thiTruongHienTaiCuaSanPham = db.ThiTruongs
                    .Where(x => x.MaSanPham == maSanPham)
                    .ToList();

                // 1. Xóa các thị trường không còn trong danh sách temp
                var thiTruongCanXoa = thiTruongHienTaiCuaSanPham
                    .Where(tt => !temp.Any(t => t.MaThiTruong == tt.MaThiTruong))
                    .ToList();

                foreach (var tt in thiTruongCanXoa)
                {
                    db.ThiTruongs.DeleteOnSubmit(tt);
                }

                // 2. Cập nhật các thị trường đã tồn tại
                foreach (var ttTemp in temp)
                {
                    var existing = thiTruongHienTaiCuaSanPham
                        .FirstOrDefault(tt => tt.MaThiTruong == ttTemp.MaThiTruong);

                    if (existing != null)
                    {
                        // Cập nhật các trường nếu khác
                        if (existing.LoaiThiTruong != ttTemp.LoaiThiTruong)
                        {
                            existing.LoaiThiTruong = ttTemp.LoaiThiTruong;
                        }

                        if (existing.GiaTri != ttTemp.GiaTri)
                        {
                            existing.GiaTri = ttTemp.GiaTri;
                        }

                        if (existing.ThoiGian != ttTemp.ThoiGian)
                        {
                            existing.ThoiGian = ttTemp.ThoiGian;
                        }
                        if (existing.MoTa != ttTemp.MoTa)
                        {
                            existing.MoTa = ttTemp.MoTa;
                        }
                    }
                    else
                    {
                        // 3. Thêm mới nếu thị trường không tồn tại
                        ttTemp.MaSanPham = maSanPham; // Gán MaSanPham từ tham số vào
                        db.ThiTruongs.InsertOnSubmit(ttTemp);
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

    }
}
