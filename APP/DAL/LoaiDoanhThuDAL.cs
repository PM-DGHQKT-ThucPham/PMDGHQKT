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

        // Lấy danh sách loại doanh thu theo mã sản phẩm
        public List<LoaiDoanhThu> LayDanhSachLoaiDoanhThu(string maSanPham)
        {
            try
            {
                _lstLoaiDoanhThu = new List<LoaiDoanhThu>();
                _lstLoaiDoanhThu = db.LoaiDoanhThus.Where(l =>l.MaSanPham==maSanPham).ToList();
                return _lstLoaiDoanhThu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Lấy loại doanh thu theo mã
        public LoaiDoanhThu LayLoaiDoanhThuTheoMa(string maLoaiDoanhThu,string maSanPham)
        {
            try
            {
                LoaiDoanhThu loaiDoanhThu = new LoaiDoanhThu();
                loaiDoanhThu = db.LoaiDoanhThus.FirstOrDefault(x => x.MaLoaiDoanhThu == maLoaiDoanhThu && x.MaSanPham==maSanPham);
                return loaiDoanhThu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
