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
        public List<DoanhThu> LayDanhSachDoanhThu()
        {
            try
            {
                return _doanhThuDAL.LayDanhSachDoanhThu();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Lấy doanh thu theo mã
        public DoanhThu LayDoanhThuTheoMa(string maDoanhThu)
        {
            try
            {
                return _doanhThuDAL.LayDoanhThuTheoMa(maDoanhThu);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //lấy doanh thu theo mã loại doanh thu
        public List<DoanhThu> LayDoanhThuTheoMaLoaiDoanhThu(string maLoaiDoanhThu)
        {
            try
            {
                return _doanhThuDAL.LayDoanhThuTheoMaLoaiDoanhThu(maLoaiDoanhThu);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //lấy doanh thu theo ngày
        public List<DoanhThu> LayDoanhThuTheoNgay(DateTime ngay)
        {
            try
            {
                return _doanhThuDAL.LayDoanhThuTheoNgay(ngay);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DoanhThu> LayDoanhThuTheoThang(int thang, int nam)
        {
            try
            {
                return _doanhThuDAL.LayDoanhThuTheoThang(thang, nam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // lấy doanh thu theo khoảng thời gian 
        public List<DoanhThu> LayDoanhThuTheoKhoangThoiGian(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                return _doanhThuDAL.LayDoanhThuTheoKhoangThoiGian(tuNgay, denNgay);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
