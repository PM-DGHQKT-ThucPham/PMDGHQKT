using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class ChiPhiBLL
    {
        ChiPhiDAL _chiPhiDAL = new ChiPhiDAL();
        public ChiPhiBLL()
        {
        }
        //lay danh sach chi phi theo mã sản phẩm
        public List<ChiPhi> LayDanhSachChiPhi(string maSanPham)
        {
            try
            {
                return _chiPhiDAL.LayDanhSachChiPhi(maSanPham);
            }
            catch  
            {
                return null;
            }
        }
        //lấy chi phí theo mã chi phí
        public ChiPhi LayChiPhiTheoMaChiPhi(string maChiPhi, string maSanPham)
        {
            try
            {
                return _chiPhiDAL.LayChiPhiTheoMaChiPhi(maChiPhi, maSanPham);
            }
            catch  
            {
                return null;
            }
        }
        //lấy chi phí theo mã loại chi phí
        public List<ChiPhi> LayChiPhiTheoMaLoaiChiPhi(string maLoaiChiPhi, string maSanPham)
        {
            try
            {
                return _chiPhiDAL.LayChiPhiTheoMaLoaiChiPhi(maLoaiChiPhi, maSanPham);
            }
            catch  
            {
                return null;
            }
        }
        //lấy theo tháng và năm
        public List<ChiPhi> LayChiPhiTheoThangNam(int thang, int nam, string maSanPham)
        {
            try
            {
                return _chiPhiDAL.LayChiPhiTheoThangNam(thang, nam, maSanPham);
            }
            catch  
            {
                return null;
            }
        }
        // lấy chi phí theo khoảng thời gian
        public List<ChiPhi> LayChiPhiTheoKhoangThoiGian(DateTime tuNgay, DateTime denNgay, string maSanPham)
        {
            try
            {
                return _chiPhiDAL.LayChiPhiTheoKhoangThoiGian(tuNgay, denNgay, maSanPham);
            }
            catch  
            {
                return null;
            }
        }
    }
}
