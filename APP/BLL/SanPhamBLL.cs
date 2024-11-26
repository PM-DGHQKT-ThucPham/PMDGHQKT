using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class SanPhamBLL
    {
        DoAnTotNghiepDataContext db = new DoAnTotNghiepDataContext();
        SanPhamDAL _SanPhamDAL = new SanPhamDAL();

        // Lấy danh sách san pham
        public List<SanPham> LayDanhSachSanPham()
        {
            try
            {
                return _SanPhamDAL.LayDanhSachSanPham();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Lấy sản phẩm theo mã
        public SanPham LaySanPhamTheoMa(string maSanPham)
        {
            try
            {
                return _SanPhamDAL.LaySanPhamTheoMa(maSanPham);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ThemSanPham(SanPham sp)
        {
            return _SanPhamDAL.ThemSanPham(sp);

        }
        public bool XoaSanPham(SanPham sp)
        {
            return _SanPhamDAL.XoaSanPham(sp);

        }
        public bool SuaSanPham(string masp1, SanPham sp1)
        {
            return _SanPhamDAL.SuaSanPham(masp1,sp1);
        }

        public bool CapNhatThemXoaSua(List<SanPham> lstSanPham)
        {
            using (var db1 = new DoAnTotNghiepDataContext()) // Thay bằng DbContext thực tế của bạn
            {
                foreach (var sp in lstSanPham)
                {
                    // Kiểm tra sản phẩm có tồn tại trong DB không
                    var spDb = db1.SanPhams.SingleOrDefault(s => s.MaSanPham == sp.MaSanPham);

                    if (spDb != null)
                    {
                        // Cập nhật sản phẩm đã tồn tại
                        spDb.TenSanPham = sp.TenSanPham;
                        spDb.MoTa = sp.MoTa;
                        spDb.Gia = sp.Gia;
                        spDb.DanhMuc = sp.DanhMuc;
                        spDb.NgayPhatHanh = sp.NgayPhatHanh;
                        spDb.SoLuongTon = sp.SoLuongTon;
                        spDb.MucDoAnhHuongTongNguyenLieu = sp.MucDoAnhHuongTongNguyenLieu;
                    }
                    else
                    {
                        // Thêm mới sản phẩm
                        db1.SanPhams.InsertOnSubmit(sp);
                    }
                }

                // Lấy danh sách mã sản phẩm hiện có trong List
                var danhSachMaSanPham = lstSanPham.Select(s => s.MaSanPham).ToList();

                // Lấy các sản phẩm trong cơ sở dữ liệu không tồn tại trong List
                var sanPhamXoa = db1.SanPhams
                                   .Where(sp => !danhSachMaSanPham.Contains(sp.MaSanPham))
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
    }
}
