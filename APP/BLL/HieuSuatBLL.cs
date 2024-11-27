using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    
    public class HieuSuatBLL
    {
        public HieuSuatBLL() { }
        HieuSuatDAL hieuSuatDAL = new HieuSuatDAL();

        /// <summary>
        /// Lấy danh sách hiệu suất
        /// </summary>
        /// <returns>Danh sách hiệu suất có trong database</returns>
        public List<HieuSuat> LayDanhSachHieuSuat()
        {
            return hieuSuatDAL.LayDanhSachHieuSuat();
        }

        /// <summary>
        /// Thêm hiệu suất mới
        /// </summary>
        /// <param name="hs"></param>
        /// <returns>true nếu thêm thành công, false nếu thêm thất bại</returns>
        public bool ThemHieuSuat(HieuSuat hs)
        {
            return hieuSuatDAL.ThemHieuSuat(hs);
        }

        /// <summary>
        /// Cập nhật hiệu suất
        /// </summary>
        /// <param name="hs"></param>
        /// <returns>true nếu cập nhật thành công, false nếu cập nhật thất bại</returns>
        public bool CapNhatHieuSuat(HieuSuat hs)
        {
            return hieuSuatDAL.CapNhatHieuSuat(hs);
        }

        /// <summary>
        /// Xóa hiệu suất dựa vào mã hiệu suất
        /// </summary>
        /// <param name="maHieuSuat"></param>
        /// <returns>true nếu xoá thành công, false nếu xoá thất bại</returns>
        public bool XoaHieuSuat(string maHieuSuat)
        {
            return hieuSuatDAL.XoaHieuSuat(maHieuSuat);
        }

        /// <summary>
        /// So sánh và cập nhật database dựa trên danh sách hiệu suất truyền vào
        /// </summary>
        /// <param name="lstHieuSuat"></param>
        /// <returns>true nếu hoàn thành cập nhật, false nếu thất bại và có lỗi nghiêm trọng</returns>
        public bool CapNhatHieuSuatDuaTrenDanhSachHieuSuat(List<HieuSuat> lstHieuSuat)
        {
            try
            {
                // Lấy danh sách hiệu suất từ database
                List<HieuSuat> lstHieuSuatDB = hieuSuatDAL.LayDanhSachHieuSuat();

                // Mã hiệu suất trong lstHieuSuat và lstHieuSuatDB giống nhau thì cập nhật thông tin hiệu suất
                foreach (HieuSuat hs in lstHieuSuat)
                {
                    try
                    {
                        // Tìm kiếm hiệu suất trong database
                        HieuSuat hsDB = lstHieuSuatDB.Where(x => x.MaHieuSuat == hs.MaHieuSuat).FirstOrDefault();
                        if (hsDB != null)
                        {
                            // Cập nhật thông tin hiệu suất
                            if (!hieuSuatDAL.CapNhatHieuSuat(hs))
                            {
                                Console.WriteLine($"Cập nhật thất bại cho hiệu suất: {hs.MaHieuSuat}");
                            }
                        }
                        else
                        {
                            // Thêm mới hiệu suất
                            if (!hieuSuatDAL.ThemHieuSuat(hs))
                            {
                                Console.WriteLine($"Thêm mới thất bại cho hiệu suất: {hs.MaHieuSuat}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi khi xử lý hiệu suất: {hs.MaHieuSuat}. Chi tiết: {ex.Message}");
                    }
                }

                // Tìm và xóa các hiệu suất không có trong danh sách truyền vào
                foreach (var hsDB in lstHieuSuatDB)
                {
                    try
                    {
                        if (!lstHieuSuat.Any(h => h.MaHieuSuat == hsDB.MaHieuSuat))
                        {
                            // Hiệu suất trong database nhưng không có trong danh sách truyền vào -> Xóa
                            if (!hieuSuatDAL.XoaHieuSuat(hsDB.MaHieuSuat))
                            {
                                Console.WriteLine($"Xóa thất bại cho hiệu suất: {hsDB.MaHieuSuat}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi khi xóa hiệu suất: {hsDB.MaHieuSuat}. Chi tiết: {ex.Message}");
                    }
                }

                return true; // Nếu hoàn thành mà không có lỗi nghiêm trọng
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ toàn cục
                Console.WriteLine($"Lỗi toàn cục trong quá trình cập nhật danh sách hiệu suất. Chi tiết: {ex.Message}");
                return false;
            }
        }

    }
}
