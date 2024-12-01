using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SanPham_TieuChiBLL
    {
            readonly SanPham_TieuChiDAL dal = new SanPham_TieuChiDAL();
            readonly DoAnTotNghiepDataContext db = new DoAnTotNghiepDataContext();
            public bool CapNhatThemXoaSua(List<TieuChi_SanPham> temp, string maSanPham)
            {
                try
                {
                    if (string.IsNullOrEmpty(maSanPham))
                    {
                        throw new ArgumentException("Mã sản phẩm không hợp lệ.");
                    }

                    // Nếu temp là null hoặc rỗng, xóa hết các chi tiết tiêu chí của MaSanPham
                    if (temp == null || temp.Count == 0)
                    {
                        var chiTietHienTai = db.TieuChi_SanPhams
                            .Where(x => x.MaSanPham == maSanPham)
                            .ToList();

                        foreach (var ct in chiTietHienTai)
                        {
                            db.TieuChi_SanPhams.DeleteOnSubmit(ct);
                        }

                        // Lưu thay đổi vào database
                        db.SubmitChanges();
                        return true;
                    }

                    // Lấy danh sách chi tiết tiêu chí hiện tại trong database của MaSanPham
                    var chiTietHienTaiCuaSanPham = db.TieuChi_SanPhams
                        .Where(x => x.MaSanPham == maSanPham)
                        .ToList();

                    // 1. Xóa các chi tiết tiêu chí không còn trong danh sách temp
                    var chiTietCanXoa = chiTietHienTaiCuaSanPham
                        .Where(ct => !temp.Any(t => t.MaTieuChi == ct.MaTieuChi))
                        .ToList();

                    foreach (var ct in chiTietCanXoa)
                    {
                        db.TieuChi_SanPhams.DeleteOnSubmit(ct);
                    }

                    // 2. Cập nhật các chi tiết tiêu chí đã tồn tại
                    foreach (var ctTemp in temp)
                    {
                        var existing = chiTietHienTaiCuaSanPham
                            .FirstOrDefault(ct => ct.MaTieuChi == ctTemp.MaTieuChi);

                        if (existing != null)
                        {
                            // Cập nhật Trọng số nếu khác
                            if (existing.TrongSo != ctTemp.TrongSo)
                            {
                                existing.TrongSo = ctTemp.TrongSo;
                            }
                        }
                        else
                        {
                            // 3. Thêm mới nếu chi tiết không tồn tại
                            ctTemp.MaSanPham = maSanPham; // Gán MaSanPham từ tham số vào
                            db.TieuChi_SanPhams.InsertOnSubmit(ctTemp);
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



            public List<TieuChi_SanPham> LayCTTC_CuaSanPham(string masp)
            {
                return dal.LayCTTC_CuaSanPham(masp);
            }
            public List<TieuChi_SanPham> LayCTTC_CuaTieuChi(string maTieuChi)
            {
                return dal.LayCTTC_CuaTieuChi(maTieuChi);
            }
        }
}
