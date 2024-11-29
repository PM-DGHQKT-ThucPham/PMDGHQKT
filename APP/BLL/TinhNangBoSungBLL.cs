using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class TinhNangBoSungBLL
    {
        public TinhNangBoSungBLL()
        {

        }
        TinhNangBoSungDAL tinhNangBoSungDAL = new TinhNangBoSungDAL();
        public List<TinhNangBoSung> LayDanhSachTinhNangBoSung()
        {
            return tinhNangBoSungDAL.LayDanhSachTinhNangBoSung();
        }
        public bool ThemTinhNangBoSung(TinhNangBoSung tinhNangBoSung)
        {
            return tinhNangBoSungDAL.ThemTinhNangBoSung(tinhNangBoSung);
        }
        public bool XoaTinhNangBoSung(string maTinhNang)
        {
            return tinhNangBoSungDAL.XoaTinhNangBoSung(maTinhNang);
        }
        public bool CapNhatTinhNangBoSung(TinhNangBoSung tnbs)
        {
            return tinhNangBoSungDAL.CapNhatTinhNangBoSung(tnbs);
        }
        public List<TinhNangBoSung> LayDanhSachTinhNangBoSungTheoMaSanPham(string maSanPham)
        {
            return LayDanhSachTinhNangBoSung().Where(p => p.MaSanPham == maSanPham).ToList();
        }
        public bool CapNhatTinhNangBoSungDuaTrenDanhSachTinhNang(List<TinhNangBoSung> dsTinhNangBoSung, string maSanPham)
        {
            try
            {
                // Lấy danh sách tính năng bổ sung hiện tại từ database theo mã sản phẩm
                List<TinhNangBoSung> dsTinhNangBoSungDB = LayDanhSachTinhNangBoSungTheoMaSanPham(maSanPham);

                // Duyệt qua danh sách tính năng đầu vào để thêm mới hoặc cập nhật
                foreach (var tinhNang in dsTinhNangBoSung)
                {
                    try
                    {
                        // Kiểm tra tính năng đã tồn tại trong database chưa
                        TinhNangBoSung tinhNangDB = dsTinhNangBoSungDB.FirstOrDefault(x => x.MaTinhNang == tinhNang.MaTinhNang);

                        if (tinhNangDB != null)
                        {
                            // Nếu tồn tại, cập nhật thông tin tính năng
                            if (!tinhNangBoSungDAL.CapNhatTinhNangBoSung(tinhNang))
                            {
                                Console.WriteLine($"Cập nhật thất bại cho tính năng: {tinhNang.MaTinhNang}");
                            }
                        }
                        else
                        {
                            // Nếu chưa tồn tại, thêm mới tính năng
                            if (!tinhNangBoSungDAL.ThemTinhNangBoSung(tinhNang))
                            {
                                Console.WriteLine($"Thêm mới thất bại cho tính năng: {tinhNang.MaTinhNang}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi khi xử lý tính năng: {tinhNang.MaTinhNang}. Chi tiết: {ex.Message}");
                    }
                }

                // Duyệt danh sách trong database để xóa những tính năng không có trong danh sách đầu vào
                foreach (var tinhNangDB in dsTinhNangBoSungDB)
                {
                    try
                    {
                        if (!dsTinhNangBoSung.Any(x => x.MaTinhNang == tinhNangDB.MaTinhNang))
                        {
                            // Xóa tính năng nếu không còn trong danh sách đầu vào
                            if (!tinhNangBoSungDAL.XoaTinhNangBoSung(tinhNangDB.MaTinhNang))
                            {
                                Console.WriteLine($"Xóa thất bại cho tính năng: {tinhNangDB.MaTinhNang}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi khi xóa tính năng: {tinhNangDB.MaTinhNang}. Chi tiết: {ex.Message}");
                    }
                }

                return true; // Nếu hoàn thành mà không có lỗi nghiêm trọng
            }
            catch (Exception ex)
            {
                // Xử lý lỗi toàn cục
                Console.WriteLine($"Lỗi toàn cục trong quá trình cập nhật danh sách tính năng bổ sung. Chi tiết: {ex.Message}");
                return false;
            }
        }

    }
}
