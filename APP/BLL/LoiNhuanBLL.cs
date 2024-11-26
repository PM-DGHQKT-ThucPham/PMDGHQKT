using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class LoiNhuanBLL
    {
        LoiNhuanDAL _loiNhuanDAL = new LoiNhuanDAL();
        public LoiNhuanBLL() { }
        //lấy tất cả lợi nhuận theo mã sản phẩm
        public List<LoiNhuan> LayTatCaLoiNhuanTheoMaSanPham(string maSP)
        {
            return _loiNhuanDAL.LayTatCaLoiNhuanTheoMaSanPham(maSP);
        }
        // lấy tất cả lợi nhuận theo mã và mã sản phẩm
        public LoiNhuan LayLoiNhuanTheoMa(string maLoiNhuan, string maSP)
        {
            return _loiNhuanDAL.LayLoiNhuanTheoMa(maLoiNhuan, maSP);
        }
        // lấy lợi nhuận theo tháng năm và mã sản phẩm
        public List<LoiNhuan> LayLoiNhuanTheoThangNam(int thang, int nam, string maSP)
        {
            return _loiNhuanDAL.LayLoiNhuanTheoThangNam(thang, nam, maSP);
        }
        // lấy lợi nhuận theo khoảng thời gian và mã sản phẩm
        public List<LoiNhuan> LayLoiNhuanTheoKhoangThoiGian(DateTime tuNgay, DateTime denNgay, string maSP)
        {
            return _loiNhuanDAL.LayLoiNhuanTheoKhoangThoiGian(tuNgay, denNgay, maSP);
        }
    }
}
