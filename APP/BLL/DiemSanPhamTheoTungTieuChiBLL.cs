using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DiemSanPhamTheoTungTieuChiBLL
    {
        DiemSanPhamTheoTungTieuChiDAL dal = new DiemSanPhamTheoTungTieuChiDAL();
        public List<DiemSanPhamTheoTungTieuChi> LayDanhSach(string masanpham)
        {
            return dal.LayDanhSach(masanpham);
        }
    }
}
