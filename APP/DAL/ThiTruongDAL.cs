using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ThiTruongDAL
    {
        DoAnTotNghiepDataContext db = new DoAnTotNghiepDataContext();
        public List<ThiTruong> LayDanhSachThiTruongCuaSanPham(string masanpham)
        {
            // Sử dụng LINQ để lấy danh sách nguyên liệu của sản phẩm
            var danhSachThiTruong = (from tt in db.ThiTruongs
                                      where tt.MaSanPham == masanpham
                                      select tt).ToList();

            return danhSachThiTruong;
        }

        public ThiTruong LayThiTruong(string maThiTruong)
        {
            ThiTruong nl = db.ThiTruongs.Where(t => t.MaThiTruong == maThiTruong).FirstOrDefault();
            return nl;
        }
    }
}
