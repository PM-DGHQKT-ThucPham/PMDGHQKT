using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class GiaCaBLL
    {
        public GiaCaBLL() { }
        GiaCaDAL giaCaDAL = new GiaCaDAL();

        /// <summary>
        /// Lấy danh sách giá cả
        /// </summary>
        /// <returns>Danh sách giá cả có trong database</returns>
        public List<GiaCa> LayDanhSachGiaCa()
        {
            return giaCaDAL.LayDanhSachGiaCa();
        }

        /// <summary>
        /// Thêm giá cả mới
        /// </summary>
        /// <param name="gc"></param>
        /// <returns>true nếu thêm thành công, false nếu thêm thất bại</returns>
        public bool ThemGiaCa(GiaCa gc)
        {
            return giaCaDAL.ThemGiaCa(gc);
        }

        /// <summary>
        /// Cập nhật giá cả
        /// </summary>
        /// <param name="gc"></param>
        /// <returns>true nếu cập nhật thành công, false nếu cập nhật thất bại</returns>
        public bool CapNhatGiaCa(GiaCa gc)
        {
            return giaCaDAL.CapNhatGiaCa(gc);
        }

        /// <summary>
        /// Xóa giá cả dựa vào mã giá
        /// </summary>
        /// <param name="maGiaCa"></param>
        /// <returns>true nếu xoá thành công, false nếu xoá thất bại</returns>
        public bool XoaGiaCa(string maGiaCa)
        {
            return giaCaDAL.XoaGiaCa(maGiaCa);
        }

        /// <summary>
        /// So sánh và cập nhật database dựa trên danh sách giá cả truyền vào
        /// </summary>
        /// <param name="lstGiaCa"></param>
        /// <returns>true nếu hoàn thành cập nhật, false nếu thất bại và có lỗi nghiêm trọng</returns>
        public bool CapNhatGiaCaDuaTrenDanhSachGiaCa(List<GiaCa> lstGiaCa, string maSanPham)
        {
            try
            {
                // Lấy danh sách giá cả từ database
                List<GiaCa> lstGiaCaDB = giaCaDAL.LayDanhSachGiaCa().Where(x => x.MaSanPham == maSanPham).ToList() ;

                // Mã giá trong lstGiaCa và lstGiaCaDB giống nhau thì cập nhật thông tin giá cả
                foreach (GiaCa gc in lstGiaCa)
                {
                    try
                    {
                        // Tìm kiếm giá trong database
                        GiaCa gcDB = lstGiaCaDB.Where(x => x.MaGiaCa == gc.MaGiaCa).FirstOrDefault();
                        if (gcDB != null)
                        {
                            // Cập nhật thông tin giá cả
                            if (!giaCaDAL.CapNhatGiaCa(gc))
                            {
                                Console.WriteLine($"Cập nhật thất bại cho giá: {gc.MaGiaCa}");
                            }
                        }
                        else
                        {
                            // Thêm mới giá cả
                            if (!giaCaDAL.ThemGiaCa(gc))
                            {
                                Console.WriteLine($"Thêm mới thất bại cho giá: {gc.MaGiaCa}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi khi xử lý giá: {gc.MaGiaCa}. Chi tiết: {ex.Message}");
                    }
                }

                // Tìm và xóa các giá không có trong danh sách truyền vào
                foreach (var gcDB in lstGiaCaDB)
                {
                    try
                    {
                        if (!lstGiaCa.Any(g => g.MaGiaCa == gcDB.MaGiaCa))
                        {
                            // Giá trong database nhưng không có trong danh sách truyền vào -> Xóa
                            if (!giaCaDAL.XoaGiaCa(gcDB.MaGiaCa))
                            {
                                Console.WriteLine($"Xóa thất bại cho giá: {gcDB.MaGiaCa}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi khi xóa giá: {gcDB.MaGiaCa}. Chi tiết: {ex.Message}");
                    }
                }

                return true; // Nếu hoàn thành mà không có lỗi nghiêm trọng
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ toàn cục
                Console.WriteLine($"Lỗi toàn cục trong quá trình cập nhật danh sách giá cả. Chi tiết: {ex.Message}");
                return false;
            }
        }
    }
}
