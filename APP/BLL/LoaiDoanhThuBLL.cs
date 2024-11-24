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
        public List<LoaiDoanhThu> LayDanhSachLoaiDoanhThu()
        {
            try
            {
                return _loaiDoanhThuDAL.LayDanhSachLoaiDoanhThu();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Lấy loại doanh thu theo mã
        public LoaiDoanhThu LayLoaiDoanhThuTheoMa(string maLoaiDoanhThu)
        {
            try
            {
                return _loaiDoanhThuDAL.LayLoaiDoanhThuTheoMa(maLoaiDoanhThu);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
