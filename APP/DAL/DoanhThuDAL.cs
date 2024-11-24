using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DoanhThuDAL
    {
        DoAnTotNghiepDataContext db = new DoAnTotNghiepDataContext();
        List<DoanhThu> _lstDoanhThu = null;

        // Lấy danh sách doanh thu theo san phẩm
        public List<DoanhThu> LayDanhSachDoanhThu(string maSanPham)
        {
            try
            {
                _lstDoanhThu = new List<DoanhThu>();
                _lstDoanhThu = db.DoanhThus.Where(d =>d.LoaiDoanhThu.MaSanPham==maSanPham).ToList();
                return _lstDoanhThu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Lấy doanh thu theo mã
        public DoanhThu LayDoanhThuTheoMa(string maDoanhThu, string maSanPham)
        {
            try
            {
                DoanhThu doanhThu = new DoanhThu();
                doanhThu = db.DoanhThus.FirstOrDefault(x => x.MaDoanhThu == maDoanhThu && x.LoaiDoanhThu.MaSanPham==maSanPham);
                return doanhThu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //lấy doanh thu theo mã loại doanh thu
        public List<DoanhThu> LayDoanhThuTheoMaLoaiDoanhThu(string maLoaiDoanhThu, string maSanPham)
        {
            try
            {
                _lstDoanhThu = new List<DoanhThu>();
                _lstDoanhThu = db.DoanhThus.Where(x => x.MaLoaiDoanhThu == maLoaiDoanhThu && x.LoaiDoanhThu.MaSanPham==maSanPham).ToList();
                return _lstDoanhThu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //lấy doanh thu theo ngày
        public List<DoanhThu> LayDoanhThuTheoNgay(DateTime ngay, string maSanPham)
        {
            try
            {
                _lstDoanhThu = new List<DoanhThu>();
                _lstDoanhThu = db.DoanhThus.Where(x => x.ThoiGian == ngay && x.LoaiDoanhThu.MaSanPham == maSanPham).ToList();
                return _lstDoanhThu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //lấy doanh thu theo tháng
        public List<DoanhThu> LayDoanhThuTheoThang(int thang, int nam, string maSanPham)
        {
            try
            {
                _lstDoanhThu = new List<DoanhThu>();
                _lstDoanhThu = db.DoanhThus.Where(x =>x.LoaiDoanhThu.MaSanPham==maSanPham && x.ThoiGian.HasValue && x.ThoiGian.Value.Month == thang && x.ThoiGian.Value.Year == nam ).ToList();
                return _lstDoanhThu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //lấy doanh thu theo khoảng thời gian
        public List<DoanhThu> LayDoanhThuTheoKhoangThoiGian(DateTime tuNgay, DateTime denNgay, string maSanPham)
        {
            try
            {
                _lstDoanhThu = new List<DoanhThu>();
                _lstDoanhThu = db.DoanhThus.Where(x =>x.LoaiDoanhThu.MaSanPham==maSanPham && x.ThoiGian >= tuNgay && x.ThoiGian <= denNgay).ToList();
                return _lstDoanhThu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
