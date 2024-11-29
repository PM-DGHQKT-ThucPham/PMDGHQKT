using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DichVuKhachHangDAL
    {
        public DichVuKhachHangDAL()
        {
        }
        DoAnTotNghiepDataContext db = new DoAnTotNghiepDataContext();
        public List<DichVuKhachHang> layDanhSachDichVuKhachHang()
        {
            return db.DichVuKhachHangs.ToList();
        }

        /// <summary>
        /// Thêm 1 dịch vụ khách hàng mới vào bảng DichVuKhachHang
        /// </summary>
        /// <param name="dichVuKhachHang"></param>
        /// <returns>true nếu thêm thành công, false nếu thêm thất bại</returns>
        public bool ThemDichVuKhachHang(DichVuKhachHang dichVuKhachHang)
        {
            try
            {
                db.DichVuKhachHangs.InsertOnSubmit(dichVuKhachHang);
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi: "+e);
                return false;
            }
        }

        /// <summary>
        /// Xoá 1 dịch vụ khách hàng khỏi bảng DichVuKhachHang theo mã dịch vụ
        /// </summary>
        /// <param name="maDichVu"></param>
        /// <returns>true nếu xoá thành công, false nếu xoá thất bại</returns>
        public bool XoaDichVuKhachHang(string maDichVu)
        {
            try
            {
                DichVuKhachHang dichVuKhachHang = db.DichVuKhachHangs.Where(p => p.MaDichVu == maDichVu).FirstOrDefault();
                db.DichVuKhachHangs.DeleteOnSubmit(dichVuKhachHang);
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi: " + e);
                return false;
            }
        }

        /// <summary>
        /// Cập nhật thông tin dịch vụ khách hàng trong bảng DichVuKhachHang theo dịch vụ được truyền vào
        /// </summary>
        /// <param name="dichVuKhachHang"></param>
        /// <returns>true nếu cập nhật thành công, false nếu cập nhật thất bại</returns>
        public bool CapNhatDichVuKhachHang(DichVuKhachHang dichVuKhachHang)
        {
            try
            {
                DichVuKhachHang dichVuKhachHangCu = db.DichVuKhachHangs.Where(p => p.MaDichVu == dichVuKhachHang.MaDichVu).FirstOrDefault();
                dichVuKhachHangCu.MaSanPham = dichVuKhachHang.MaSanPham;
                dichVuKhachHangCu.MoTa = dichVuKhachHang.MoTa;
                dichVuKhachHangCu.DanhGiaHoTro = dichVuKhachHang.DanhGiaHoTro;
                dichVuKhachHangCu.ThoiGianBaoHanh = dichVuKhachHang.ThoiGianBaoHanh;
                dichVuKhachHangCu.MucDoAnhHuong = dichVuKhachHang.MucDoAnhHuong;
                db.SubmitChanges();
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine("Lỗi: " + e);
                return false;
            }
        }
    }
}
