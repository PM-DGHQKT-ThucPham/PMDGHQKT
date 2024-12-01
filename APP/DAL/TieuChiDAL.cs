using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TieuChiDAL
    {
        DoAnTotNghiepDataContext db = new DoAnTotNghiepDataContext();
        public List<TieuChi> LayTatCaDanhSachTieuChi()
        {
            // Sử dụng LINQ để lấy danh sách nguyên liệu của sản phẩm
            var danhSachTieuChi = db.TieuChis.ToList();

            return danhSachTieuChi;
        }
        public List<TieuChi> LayDanhSachTieuChiCuaSanPham(string masanpham)
        {
            // Sử dụng LINQ để lấy danh sách nguyên liệu của sản phẩm
            var danhSachTieuChi = (from ct in db.TieuChi_SanPhams
                                      join tc in db.TieuChis on ct.MaTieuChi equals tc.MaTieuChi
                                      where ct.MaSanPham == masanpham
                                      select tc).ToList();

            return danhSachTieuChi;
        }

        public TieuChi LayTieuChi(string maTieuChi)
        {
            TieuChi tc = db.TieuChis.Where(t => t.MaTieuChi == maTieuChi).FirstOrDefault();
            return tc;
        }
    }
}
