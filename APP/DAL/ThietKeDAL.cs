using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ThietKeDAL
    {
        public ThietKeDAL() { }
        DoAnTotNghiepDataContext db = new DoAnTotNghiepDataContext();

        /// <summary>
        /// Lấy toàn bộ danh sách thiết kế
        /// </summary>
        /// <returns></returns>
        public List<ThietKe> LayDanhSachThietKe()
        {
            return db.ThietKes.ToList();
        }

        /// <summary>
        /// Thêm thiết kế mới
        /// </summary>
        /// <param name="tk">Đối tương ThietKe</param>
        /// <returns>Trả về true nếu thêm thành công, false nếu thêm thất bại</returns>
        public bool ThemThietKe(ThietKe tk)
        {
            try
            {
                db.ThietKes.InsertOnSubmit(tk);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Cập nhật thiết kế có sẵn trong database
        /// </summary>
        /// <param name="tk">Đối tượng thiết kế</param>
        /// <returns>Trả về true nếu cập nhật thành công, false nếu cập nhật thất bại</returns>
        public bool CapNhatThietKe(ThietKe tk)
        {
            try
            {
                // Kiểm tra xem mã thiết kế có tồn tại không
                ThietKe thietKe = db.ThietKes.Where(x => x.MaThietKe == tk.MaThietKe).FirstOrDefault();
                // Nếu không tồn tại thì trả về false
                if (thietKe == null)
                {
                    return false;
                }
                // Cập nhật thông tin thiết kế
                thietKe.MaSanPham = tk.MaSanPham;
                thietKe.MoTa = tk.MoTa;
                thietKe.DanhGiaThamMy = tk.DanhGiaThamMy;   
                thietKe.DanhGiaTienDung = tk.DanhGiaTienDung;
                thietKe.MucDoAnhHuong = tk.MucDoAnhHuong;
                thietKe.HinhAnh = tk.HinhAnh;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Xóa thiết kế
        /// </summary>
        /// <param name="maThietKe">Mã thiết kế</param>
        /// <returns>Trả về true nếu xoá thành công, false nếu xoá thất bại</returns>
        public bool XoaThietKe(string maThietKe)
        {
            try
            {
                ThietKe tk = db.ThietKes.Where(x => x.MaThietKe == maThietKe).FirstOrDefault();
                if (tk == null)
                {
                    return false;
                }
                db.ThietKes.DeleteOnSubmit(tk);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
