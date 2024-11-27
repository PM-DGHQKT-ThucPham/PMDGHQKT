using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NguyenLieuDAL
    {
        DoAnTotNghiepDataContext db = new DoAnTotNghiepDataContext();
        public List<NguyenLieu> LayTatCaDanhSachNguyenLieu()
        {
            // Sử dụng LINQ để lấy danh sách nguyên liệu của sản phẩm
            var danhSachNguyenLieu = db.NguyenLieus.ToList();

            return danhSachNguyenLieu;
        }
        public List<NguyenLieu> LayDanhSachNguyenLieuCuaSanPham(string masanpham)
        {
            // Sử dụng LINQ để lấy danh sách nguyên liệu của sản phẩm
            var danhSachNguyenLieu = (from ct in db.ChiTietThanhPhans
                                      join nl in db.NguyenLieus on ct.MaNguyenLieu equals nl.MaNguyenLieu
                                      where ct.MaSanPham == masanpham
                                      select nl).ToList();

            return danhSachNguyenLieu;
        }

        public NguyenLieu LayNguyenLieu(string manguyenlieu)
        {
            NguyenLieu nl = db.NguyenLieus.Where(t => t.MaNguyenLieu == manguyenlieu).FirstOrDefault();
            return nl;
        }
    }
}
