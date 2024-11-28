using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GiaCaDAL
    {
        // Khởi tạo đối tượng context để kết nối với cơ sở dữ liệu
        DoAnTotNghiepDataContext db = new DoAnTotNghiepDataContext();

        /// <summary>
        /// Lấy danh sách giá cả
        /// </summary>
        /// <returns>Danh sách giá cả</returns>
        public List<GiaCa> LayDanhSachGiaCa()
        {
            try
            {
                return db.GiaCas.ToList(); // Trả về tất cả các bản ghi trong bảng GiaCa
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần thiết
                Console.WriteLine("Lỗi khi lấy danh sách GiaCa: " + ex.Message);
                return new List<GiaCa>(); // Trả về danh sách rỗng nếu có lỗi
            }
        }

        /// <summary>
        /// Thêm mới giá cả
        /// </summary>
        /// <param name="giaCa">Đối tượng giá cả cần thêm</param>
        /// <returns>Trả về true nếu thêm thành công, false nếu thất bại</returns>
        public bool ThemGiaCa(GiaCa giaCa)
        {
            try
            {
                db.GiaCas.InsertOnSubmit(giaCa); // Thêm đối tượng vào bảng GiaCa
                db.SubmitChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                return true; // Trả về true nếu thành công
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần thiết
                Console.WriteLine("Lỗi khi thêm GiaCa: " + ex.Message);
                return false; // Trả về false nếu có lỗi
            }
        }

        /// <summary>
        /// Cập nhật thông tin giá cả
        /// </summary>
        /// <param name="giaCa">Đối tượng giá cả cần cập nhật</param>
        /// <returns>Trả về true nếu cập nhật thành công, false nếu thất bại</returns>
        public bool CapNhatGiaCa(GiaCa giaCa)
        {
            try
            {
                // Tìm đối tượng giá cả cần cập nhật
                GiaCa giaCaSua = db.GiaCas.Where(p => p.MaGiaCa == giaCa.MaGiaCa).FirstOrDefault();
                if (giaCaSua != null)
                {
                    // Cập nhật thông tin giá cả
                    giaCaSua.MaSanPham = giaCa.MaSanPham;
                    giaCaSua.MoTa = giaCa.MoTa;
                    giaCaSua.DanhGiaGiaTri = giaCa.DanhGiaGiaTri;
                    giaCaSua.ChiPhiBaoTri = giaCa.ChiPhiBaoTri;
                    giaCaSua.MucDoAnhHuong = giaCa.MucDoAnhHuong;

                    db.SubmitChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                    return true; // Trả về true nếu cập nhật thành công
                }
                return false; // Trả về false nếu không tìm thấy đối tượng cần cập nhật
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần thiết
                Console.WriteLine("Lỗi khi cập nhật GiaCa: " + ex.Message);
                return false; // Trả về false nếu có lỗi
            }
        }

        /// <summary>
        /// Xóa giá cả
        /// </summary>
        /// <param name="maGiaCa">Mã giá cả cần xóa</param>
        /// <returns>Trả về true nếu xóa thành công, false nếu thất bại</returns>
        public bool XoaGiaCa(string maGiaCa)
        {
            try
            {
                // Tìm đối tượng giá cả cần xóa
                GiaCa giaCa = db.GiaCas.Where(p => p.MaGiaCa == maGiaCa).FirstOrDefault();
                if (giaCa != null)
                {
                    db.GiaCas.DeleteOnSubmit(giaCa); // Xóa đối tượng giá cả
                    db.SubmitChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                    return true; // Trả về true nếu xóa thành công
                }
                return false; // Trả về false nếu không tìm thấy đối tượng cần xóa
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần thiết
                Console.WriteLine("Lỗi khi xóa GiaCa: " + ex.Message);
                return false; // Trả về false nếu có lỗi
            }
        }
    }
}
