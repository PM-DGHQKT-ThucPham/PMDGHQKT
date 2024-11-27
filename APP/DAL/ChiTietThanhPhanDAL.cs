using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChiTietThanhPhanDAL
    {
        DoAnTotNghiepDataContext db = new DoAnTotNghiepDataContext();
        public List<ChiTietThanhPhan> LayCTTP_CuaSanPham(string masp)
        {
            var dscttp = db.ChiTietThanhPhans.Where(t=> t.MaSanPham ==  masp).ToList();
            return dscttp;
        }
        public List<ChiTietThanhPhan> LayCTTP_CuaNguyenLieu(string maNguyenLieu)
        {
            var dscttp = db.ChiTietThanhPhans.Where(t => t.MaNguyenLieu == maNguyenLieu).ToList();
            return dscttp;
        }
    }
}
