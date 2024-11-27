using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL
{
    public class ThietKeBLL
    {
        public ThietKeBLL() { }
        
        ThietKeDAL ThietKeDAL = new ThietKeDAL();

        /// <summary>
        /// Lấy danh sách thiết kế
        /// </summary>
        /// <returns>Danh sách thiết kế có trong database</returns>
        public List<ThietKe> LayDanhSachThietKe()
        {
            return ThietKeDAL.LayDanhSachThietKe();
        }

        /// <summary>
        /// Thêm thiết kế mới
        /// </summary>
        /// <param name="tk">Đối tượng thiết kế</param>
        /// <returns>Trả về true nếu thêm thành công, false nếu thêm thất bại</returns>
        public bool ThemThietKe(ThietKe tk)
        {
            return ThietKeDAL.ThemThietKe(tk);
        }

        /// <summary>
        /// Cập nhật thiết kế
        /// </summary>
        /// <param name="tk">Đối tượng thiết kế</param>
        /// <returns>Trả về true nếu cập nhật thành công, false nếu cập nhật thất bại</returns>
        public bool CapNhatThietKe(ThietKe tk)
        {
            return ThietKeDAL.CapNhatThietKe(tk);
        }

        /// <summary>
        /// Xóa thiết kế
        /// </summary>
        /// <param name="maThietKe">Mã thiết kế</param>
        /// <returns>Trả về true nếu xoá thành công, false nếu xoá thất bại</returns>
        public bool XoaThietKe(string maThietKe)
        {
            return ThietKeDAL.XoaThietKe(maThietKe);
        }

        /// <summary>
        /// So sánh và cập nhật database dựa trên danh sách thiết kế truyền vào
        /// </summary>
        /// <param name="lstThietKe">Danh sách thiết kế</param>
        /// <returns>Trả về true nếu quá trình cập nhật thành công, false nếu quá trình cập nhật thất bại</returns>
        public bool CapNhatThietKeDuaTrenDanhSachThietKe(List<ThietKe> lstThietKe)
        {
            try
            {
                // Lấy danh sách thiết kế từ database
                List<ThietKe> lstThietKeDB = ThietKeDAL.LayDanhSachThietKe();

                // Mã thiết kế trong lstThietKe và lstThietKeDB giống nhau thì cập nhật thông tin thiết kế
                foreach (ThietKe tk in lstThietKe)
                {
                    try
                    {
                        ThietKe tkDB = lstThietKeDB.Where(x => x.MaThietKe == tk.MaThietKe).FirstOrDefault();
                        if (tkDB != null)
                        {
                            // Cập nhật thông tin thiết kế
                            if (!ThietKeDAL.CapNhatThietKe(tk))
                            {
                                Console.WriteLine($"Cập nhật thất bại cho thiết kế: {tk.MaThietKe}");
                            }
                        }
                        else
                        {
                            // Thêm mới thiết kế
                            if (!ThietKeDAL.ThemThietKe(tk))
                            {
                                Console.WriteLine($"Thêm mới thất bại cho thiết kế: {tk.MaThietKe}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi khi xử lý thiết kế: {tk.MaThietKe}. Chi tiết: {ex.Message}");
                    }
                }

                // Tìm và xóa các thiết kế không có trong danh sách truyền vào
                foreach (var tkDB in lstThietKeDB)
                {
                    try
                    {
                        if (!lstThietKe.Any(t => t.MaThietKe == tkDB.MaThietKe))
                        {
                            // Thiết kế trong database nhưng không có trong danh sách truyền vào -> Xóa
                            if (!ThietKeDAL.XoaThietKe(tkDB.MaThietKe))
                            {
                                Console.WriteLine($"Xóa thất bại cho thiết kế: {tkDB.MaThietKe}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi khi xóa thiết kế: {tkDB.MaThietKe}. Chi tiết: {ex.Message}");
                    }
                }

                return true; // Nếu hoàn thành mà không có lỗi nghiêm trọng
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ toàn cục
                Console.WriteLine($"Lỗi toàn cục trong quá trình cập nhật danh sách thiết kế. Chi tiết: {ex.Message}");
                return false;
            }
        }

    }
}
