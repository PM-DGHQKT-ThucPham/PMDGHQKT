using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SanPham_TieuChiDAL
    {
        DoAnTotNghiepDataContext db = new DoAnTotNghiepDataContext();
        public List<TieuChi_SanPham> LayCTTC_CuaSanPham(string masp)
        {
            var dscttc = db.TieuChi_SanPhams.Where(t => t.MaSanPham == masp).ToList();
            return dscttc;
        }
        public List<TieuChi_SanPham> LayCTTC_CuaTieuChi(string maTieuChi)
        {
            var dscttp = db.TieuChi_SanPhams.Where(t => t.MaTieuChi == maTieuChi).ToList();
            return dscttp;
        }
    }
}
