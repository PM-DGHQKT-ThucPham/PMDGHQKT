using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NguyenLieuBLL
    {
        NguyenLieuDAL dal = new NguyenLieuDAL();
        public List<NguyenLieu> LayTatCaDanhSachNguyenLieu()
        {
            return dal.LayTatCaDanhSachNguyenLieu();
        }
        public List<NguyenLieu> LayDanhSachNguyenLieuCuaSanPham(string masanpham)
        {
            return dal.LayDanhSachNguyenLieuCuaSanPham(masanpham);
        }
        public NguyenLieu LayNguyenLieu(string manguyenlieu)
        {
            return dal.LayNguyenLieu(manguyenlieu);
        }
    }
}
