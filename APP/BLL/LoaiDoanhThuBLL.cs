using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class LoaiDoanhThuBLL
    {
        LoaiDoanhThuDAL _loaiDoanhThuDAL = new LoaiDoanhThuDAL();

        // Lấy danh sách loại doanh thu
        public List<LoaiDoanhThu> LayDanhSachLoaiDoanhThu(string maSanPham)
        {
            try
            {
                return _loaiDoanhThuDAL.LayDanhSachLoaiDoanhThu(maSanPham);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Lấy loại doanh thu theo mã
        public LoaiDoanhThu LayLoaiDoanhThuTheoMa(string maLoaiDoanhThu, string maSanPham)
        {
            try
            {
                return _loaiDoanhThuDAL.LayLoaiDoanhThuTheoMa(maLoaiDoanhThu,maSanPham);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CapNhatThemXoaSuaLoaiDoanhThu(List<LoaiDoanhThu> _lstLoaiDoanhThu)
        {
            try
            {
                return _loaiDoanhThuDAL.CapNhatThemXoaSuaLoaiDoanhThu(_lstLoaiDoanhThu);
            }
            catch
            {
                return false;
            }
        }
    }
}
