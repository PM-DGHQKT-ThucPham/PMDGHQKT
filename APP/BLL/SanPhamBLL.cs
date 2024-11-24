using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class SanPhamBLL
    {
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
    }
}
