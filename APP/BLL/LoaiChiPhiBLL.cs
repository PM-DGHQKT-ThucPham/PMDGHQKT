using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class LoaiChiPhiBLL
    {
        LoaiChiPhiDAL _loaiChiPhiDAL = new LoaiChiPhiDAL();
        public LoaiChiPhiBLL()
        {
        }
        //lấy danh sách loại chi phí theo mã sản phẩm
        public List<LoaiChiPhi> LayDanhSachLoaiChiPhi(string maSanPham)
        {
            try
            {
                return _loaiChiPhiDAL.LayDanhSachLoaiChiPhi(maSanPham);
            }
            catch  
            {
                return null;
            }
        }
        //lấy loại chi phí theo mã loại chi phí
        public LoaiChiPhi LayLoaiChiPhiTheoMaLoaiChiPhi(string maLoaiChiPhi, string maSanPham)
        {
            try
            {
                return _loaiChiPhiDAL.LayLoaiChiPhiTheoMaLoaiChiPhi(maLoaiChiPhi, maSanPham);
            }
            catch  
            {
                return null;
            }
        }
    }
}
