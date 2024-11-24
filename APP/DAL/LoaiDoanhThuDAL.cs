using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoaiDoanhThuDAL
    {
        DoAnTotNghiepDataContext db = new DoAnTotNghiepDataContext();
        List<LoaiDoanhThu> _lstLoaiDoanhThu = null;

        // Lấy danh sách loại doanh thu
        public List<LoaiDoanhThu> LayDanhSachLoaiDoanhThu()
        {
            try
            {
                _lstLoaiDoanhThu = new List<LoaiDoanhThu>();
                _lstLoaiDoanhThu = db.LoaiDoanhThus.ToList();
                return _lstLoaiDoanhThu;
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
                LoaiDoanhThu loaiDoanhThu = new LoaiDoanhThu();
                loaiDoanhThu = db.LoaiDoanhThus.FirstOrDefault(x => x.MaLoaiDoanhThu == maLoaiDoanhThu);
                return loaiDoanhThu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
