using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class DoanhThuBLL
    {
        DoanhThuDAL _doanhThuDAL = new DoanhThuDAL();

        // Lấy danh sách doanh thu
        public List<DoanhThu> LayDanhSachDoanhThu(string maSanPham)
        {
            try
            {
                return _doanhThuDAL.LayDanhSachDoanhThu(maSanPham);
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
                return _doanhThuDAL.LayDoanhThuTheoMa(maDoanhThu, maSanPham);
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
                return _doanhThuDAL.LayDoanhThuTheoMaLoaiDoanhThu(maLoaiDoanhThu, maSanPham);
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
                return _doanhThuDAL.LayDoanhThuTheoNgay(ngay, maSanPham);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DoanhThu> LayDoanhThuTheoThang(int thang, int nam, string maSanPham)
        {
            try
            {
                return _doanhThuDAL.LayDoanhThuTheoThang(thang, nam,maSanPham);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // lấy doanh thu theo khoảng thời gian 
        public List<DoanhThu> LayDoanhThuTheoKhoangThoiGian(DateTime tuNgay, DateTime denNgay, string maSanPham)
        {
            try
            {
                return _doanhThuDAL.LayDoanhThuTheoKhoangThoiGian(tuNgay, denNgay, maSanPham);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CapNhatThemXoaSuaDoanhThu(List<DoanhThu> _lstDoanhThu, string maLoaiDoanhThu)
        {
            try
            {
                return _doanhThuDAL.CapNhatThemXoaSuaDoanhThu(_lstDoanhThu,maLoaiDoanhThu);
            }
            catch
            {
                return false;
            }
        }
        public List<(DateTime Thang, string LoaiDoanhThu, decimal DoanhThu, decimal TiLeTangTruong)> TinhTiLeTangTruongTheoLoai(string maSanPham)
        {
            try
            {
                return _doanhThuDAL.TinhTiLeTangTruongTheoLoai(maSanPham);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
