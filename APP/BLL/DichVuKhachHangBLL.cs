using DAL;
using DTO;
using System.Collections.Generic;
using System;
using System.Linq;

namespace BLL
{
    public class DichVuKhachHangBLL
    {
        public DichVuKhachHangBLL() { }
        DichVuKhachHangDAL dichVuKhachHangDAL = new DichVuKhachHangDAL();

        /// <summary>
        /// Lấy danh sách dịch vụ khách hàng
        /// </summary>
        /// <returns>Danh sách dịch vụ khách hàng có trong database</returns>
        public List<DichVuKhachHang> LayDanhSachDichVuKhachHang()
        {
            return dichVuKhachHangDAL.layDanhSachDichVuKhachHang();
        }

        /// <summary>
        /// Thêm dịch vụ khách hàng mới
        /// </summary>
        /// <param name="dichVuKhachHang"></param>
        /// <returns>true nếu thêm thành công, false nếu thêm thất bại</returns>
        public bool ThemDichVuKhachHang(DichVuKhachHang dichVuKhachHang)
        {
            return dichVuKhachHangDAL.ThemDichVuKhachHang(dichVuKhachHang);
        }

        /// <summary>
        /// Cập nhật dịch vụ khách hàng
        /// </summary>
        /// <param name="dichVuKhachHang"></param>
        /// <returns>true nếu cập nhật thành công, false nếu cập nhật thất bại</returns>
        public bool CapNhatDichVuKhachHang(DichVuKhachHang dichVuKhachHang)
        {
            return dichVuKhachHangDAL.CapNhatDichVuKhachHang(dichVuKhachHang);
        }

        /// <summary>
        /// Xóa dịch vụ khách hàng dựa vào mã dịch vụ
        /// </summary>
        /// <param name="maDichVu"></param>
        /// <returns>true nếu xoá thành công, false nếu xoá thất bại</returns>
        public bool XoaDichVuKhachHang(string maDichVu)
        {
            return dichVuKhachHangDAL.XoaDichVuKhachHang(maDichVu);
        }

        public List<DichVuKhachHang> LayDanhSachKhachHangDuaTrenMaSanPham(string maSanPham)
        {
            return dichVuKhachHangDAL.layDanhSachDichVuKhachHang().Where(x => x.MaSanPham == maSanPham).ToList();
        }

        /// <summary>
        /// So sánh và cập nhật database dựa trên danh sách dịch vụ khách hàng dựa trên mã sản phẩm truyền vào
        /// </summary>
        /// <param name="lstDichVuKhachHang"></param>
        /// <returns>true nếu hoàn thành cập nhật, false nếu thất bại và có lỗi nghiêm trọng</returns>
        public bool CapNhatDichVuKhachHangDuaTrenDanhSachDichVuKhachHang(List<DichVuKhachHang> lstDichVuKhachHang, string maSanPham)
        {
            try
            {
                // Lấy danh sách dịch vụ khách hàng dựa trên mã sản phẩm từ database
                List<DichVuKhachHang> lstDichVuKhachHangDB = LayDanhSachKhachHangDuaTrenMaSanPham(maSanPham);

                // Mã dịch vụ trong lstDichVuKhachHang và lstDichVuKhachHangDB giống nhau thì cập nhật thông tin dịch vụ khách hàng
                foreach (DichVuKhachHang dv in lstDichVuKhachHang)
                {
                    try
                    {
                        // Tìm kiếm dịch vụ trong database
                        DichVuKhachHang dvDB = lstDichVuKhachHangDB.Where(x => x.MaDichVu == dv.MaDichVu).FirstOrDefault();
                        if (dvDB != null)
                        {
                            // Cập nhật thông tin dịch vụ khách hàng
                            if (!dichVuKhachHangDAL.CapNhatDichVuKhachHang(dv))
                            {
                                Console.WriteLine($"Cập nhật thất bại cho dịch vụ: {dv.MaDichVu}");
                            }
                        }
                        else
                        {
                            // Thêm mới dịch vụ khách hàng
                            if (!dichVuKhachHangDAL.ThemDichVuKhachHang(dv))
                            {
                                Console.WriteLine($"Thêm mới thất bại cho dịch vụ: {dv.MaDichVu}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi khi xử lý dịch vụ: {dv.MaDichVu}. Chi tiết: {ex.Message}");
                    }
                }

                // Tìm và xóa các dịch vụ không có trong danh sách truyền vào
                foreach (var dvDB in lstDichVuKhachHangDB)
                {
                    try
                    {
                        if (!lstDichVuKhachHang.Any(d => d.MaDichVu == dvDB.MaDichVu))
                        {
                            // Dịch vụ trong database nhưng không có trong danh sách truyền vào -> Xóa
                            if (!dichVuKhachHangDAL.XoaDichVuKhachHang(dvDB.MaDichVu))
                            {
                                Console.WriteLine($"Xóa thất bại cho dịch vụ: {dvDB.MaDichVu}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi khi xóa dịch vụ: {dvDB.MaDichVu}. Chi tiết: {ex.Message}");
                    }
                }

                return true; // Nếu hoàn thành mà không có lỗi nghiêm trọng
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ toàn cục
                Console.WriteLine($"Lỗi toàn cục trong quá trình cập nhật danh sách dịch vụ khách hàng. Chi tiết: {ex.Message}");
                return false;
            }
        }
    }
}