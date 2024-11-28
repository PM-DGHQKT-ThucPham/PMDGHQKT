using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PhanHoiNguoiDungBLL
    {
        PhanHoiNguoiDungDAL dal = new PhanHoiNguoiDungDAL();
        public List<PhanHoiNguoiDung> LayDanhSachPhanHoiNguoiDung(string masanpham)
        {
            return dal.LayDanhSachPhanHoiNguoiDung(masanpham);
        }
        public List<PhanHoiNguoiDung> LayDanhSachPhanHoiNguoiDungTheoNgay(string masanpham, DateTime ngay)
        {
            return dal.LayDanhSachPhanHoiNguoiDungTheoNgay(masanpham, ngay);
        }
        public List<PhanHoiNguoiDung> LayDanhSachPhanHoiNguoiDungTheoThoiGian(string masanpham, DateTime tuNgay, DateTime denNgay)
        {
            return dal.LayDanhSachPhanHoiNguoiDungTheoThoiGian(masanpham, tuNgay, denNgay);
        }
        public List<PhanHoiNguoiDung> LayDanhSachPhanHoiNguoiDungTheoDiem(string masanpham, int diem)
        {
            return dal.LayDanhSachPhanHoiNguoiDungTheoDiem(masanpham, diem);
        }
        public int ThongKeSoLuongPhanHoiNguoiDungTheoDiem(string masanpham, int diem)
        {
            return dal.ThongKeSoLuongPhanHoiNguoiDungTheoDiem(masanpham, diem);
        }
    }
}