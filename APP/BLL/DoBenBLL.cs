using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace BLL
{
    public class DoBenBLL
    {
        public DoBenBLL()
        {

        }
        DoBenDAL doBenDAL = new DoBenDAL();

        /// <summary>
        /// Lấy danh sách độ bền
        /// </summary>
        /// <returns>Danh sách độ bền</returns>
        public List<DoBen> LayDanhSachDoBen()
        {
            return doBenDAL.LayDanhSachDoBen();
        }

        /// <summary>
        /// Lấy danh sách độ bền không trùng lắp
        /// </summary>
        /// <returns></returns>
        public List<DoBen> LayDanhSachDoBenKhongTrungLap()
        {
            // Lấy danh sách độ bền từ database
            List<DoBen> lst = doBenDAL.LayDanhSachDoBen();

            // Lọc danh sách để loại bỏ các phần tử trùng lặp
            // Giả sử "MaDoBen" là trường duy nhất để xác định độ bền không trùng lặp
            var distinctList = lst.GroupBy(d => d.MaDoBen).Select(g => g.First()).ToList();

            return distinctList;
        }

        /// <summary>
        /// Lấy danh sách độ bền theo mã sản phẩm
        /// </summary>
        /// <param name="maSanPham"></param>
        /// <returns></returns>
        public List<DoBen> LayDanhSachDoBenTheoMaSanPham(string maSanPham)
        {
            List<DoBen> lst = LayDanhSachDoBen().Where(x => x.MaSanPham == maSanPham).ToList();
            return lst;
        }

        /// <summary>
        /// Thêm độ bền
        /// </summary>
        /// <param name="doBen">Đối tượng độ bền</param>
        /// <returns>true nếu thêm thành công, false nếu thêm thất bại</returns>
        public bool ThemDoBen(DoBen doBen)
        {
            return doBenDAL.ThemDoBen(doBen);
        }

        /// <summary>
        /// Cập nhật độ bền
        /// </summary>
        /// <param name="doBen">Đối tượng DoBen</param>
        /// <returns>true nếu cập nhật thành công, false nếu cập nhật thất bại</returns>
        public bool CapNhatDoBen(DoBen doBen)
        {
            return doBenDAL.CapNhatDoBen(doBen);
        }

        /// <summary>
        /// Xóa độ bền
        /// </summary>
        /// <param name="maDoBen">Mã độ bền</param>
        /// <returns>true nếu xoá thành công, false nếu xoá thất bại</returns>
        public bool XoaDoBen(string maDoBen)
        {
            return doBenDAL.XoaDoBen(maDoBen);
        }

        /// <summary>
        /// Cập nhật độ bền dựa trên List<DoBen>
        /// </summary>
        /// <param name="dtDoBen">DataTable gồm các cột MaDoBen, MaSanPham, TuoiThoNgay, DanhGiaDoBen, MucDoAnhHuong, MoTa</param>
        /// <returns>Trả về true nếu dữ liệu trong database đã được cập nhật, false nếu quá trình cập nhật bị lỗi</returns>
        public bool CapNhatDoBenDuaTrenDanhSach(List<DoBen> lstDoBen)
        {
            try
            {
                // Lấy danh sách độ bền hiện tại từ DB
                List<DoBen> currentDoBens = doBenDAL.LayDanhSachDoBen();

                // Duyệt qua từng đối tượng trong danh sách mới
                foreach (var newDoBen in lstDoBen)
                {
                    // Kiểm tra xem độ bền đã tồn tại trong database chưa
                    DoBen existingDoBen = currentDoBens.FirstOrDefault(d => d.MaDoBen == newDoBen.MaDoBen);

                    if (existingDoBen != null)
                    {
                        // Cập nhật thông tin của độ bền hiện có
                        existingDoBen.MaSanPham = newDoBen.MaSanPham;
                        existingDoBen.TuoiThoNgay = newDoBen.TuoiThoNgay;
                        existingDoBen.DanhGiaDoBen = newDoBen.DanhGiaDoBen;
                        existingDoBen.MucDoAnhHuong = newDoBen.MucDoAnhHuong;
                        existingDoBen.MoTa = newDoBen.MoTa;

                        // Cập nhật vào cơ sở dữ liệu
                        bool isUpdated = doBenDAL.CapNhatDoBen(existingDoBen);
                        if (!isUpdated)
                        {
                            return false; // Nếu cập nhật thất bại, trả về false
                        }

                        // Xóa bản ghi khỏi danh sách "currentDoBens" vì đã được xử lý
                        currentDoBens.Remove(existingDoBen);
                    }
                    else
                    {
                        // Thêm mới độ bền nếu không tồn tại trong database
                        bool isAdded = doBenDAL.ThemDoBen(newDoBen);
                        if (!isAdded)
                        {
                            return false; // Nếu thêm mới thất bại, trả về false
                        }
                    }
                }

                // Sau khi duyệt xong danh sách mới, tiến hành xóa các bản ghi không có trong danh sách mới nhưng có trong DB
                foreach (var remainingDoBen in currentDoBens)
                {
                    // Xóa các bản ghi không có trong danh sách mới
                    bool isDeleted = doBenDAL.XoaDoBen(remainingDoBen.MaDoBen);
                    if (!isDeleted)
                    {
                        return false; // Nếu xóa thất bại, trả về false
                    }
                }

                return true; // Trả về true nếu tất cả thao tác thành công
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine("Lỗi cập nhật độ bền: " + ex.Message);
                return false;
            }
        }


        /// <summary>
        /// Kiểm tra mã độ bền đã tồn tại trong database chưa
        /// </summary>
        /// <param name="text">Mã độ bền</param>
        /// <returns>Trả về true nếu chưa tồn tại, false nếu đã tồn tại</returns>
        public bool KiemTraMaDoBenTonTai(string maDoBen)
        {
            DoBen doBen = LayDanhSachDoBen().FirstOrDefault(x => x.MaDoBen == maDoBen);
            if (doBen != null)
            {
                return true;
            }
            return false;
        }
    }
}
