using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PhanHoiNguoiDungDAL
    {
        DoAnTotNghiepDataContext db = new DoAnTotNghiepDataContext();
        public List<PhanHoiNguoiDung> LayDanhSachPhanHoiNguoiDung(string masanpham)
        {
            List<PhanHoiNguoiDung> lst = db.PhanHoiNguoiDungs.Where(t=> t.MaSanPham == masanpham).ToList();
            return lst;
        }
        //Tìm danh sách PhanHoiNguoiDung theo ngày
        public List<PhanHoiNguoiDung> LayDanhSachPhanHoiNguoiDungTheoNgay(string masanpham, DateTime ngay)
        {
            List<PhanHoiNguoiDung> lst = db.PhanHoiNguoiDungs.Where(t => t.MaSanPham == masanpham && t.NgayPhanHoi.Value.Date == ngay.Date).ToList();
            return lst;
        }
        //Tìm danh sách PhanHoiNguoiDung theo thời gian
        public List<PhanHoiNguoiDung> LayDanhSachPhanHoiNguoiDungTheoThoiGian(string masanpham, DateTime tuNgay, DateTime denNgay)
        {
            List<PhanHoiNguoiDung> lst = db.PhanHoiNguoiDungs.Where(t => t.MaSanPham == masanpham && t.NgayPhanHoi.Value.Date >= tuNgay.Date && t.NgayPhanHoi.Value.Date <= denNgay.Date).ToList();
            return lst;
        }
        //Tìm danh sách PhanHoiNguoiDung theo điểm xếp hạng
        public List<PhanHoiNguoiDung> LayDanhSachPhanHoiNguoiDungTheoDiem(string masanpham, int diem)
        {
            List<PhanHoiNguoiDung> lst = db.PhanHoiNguoiDungs.Where(t => t.MaSanPham == masanpham && t.XepHangNguoiDung == diem).ToList();
            return lst;
        }
        //Thống kê số lượng PhanHoiNguoiDung theo điểm XepHangNguoiDung
        public int ThongKeSoLuongPhanHoiNguoiDungTheoDiem(string masanpham, int diem)
        {
            int count = db.PhanHoiNguoiDungs.Where(t => t.MaSanPham == masanpham && t.XepHangNguoiDung == diem).Count();
            return count;
        }
    }
}
