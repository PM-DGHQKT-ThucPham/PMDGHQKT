using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL
{
    public class BenVungBLL
    {
        public BenVungBLL()
        {
        }
        BenVungDAL benVungDAL = new BenVungDAL();
        public bool ThemBenVung(BenVung benVung)
        {
            return benVungDAL.ThemBenVung(benVung);
        }
        public bool CapNhatBenVung(BenVung benVung)
        {
            return benVungDAL.SuaBenVung(benVung);
        }
        public bool XoaBenVung(string maBenVung)
        {
            return benVungDAL.XoaBenVung(maBenVung);
        }
        public List<BenVung> LayDanhSachBenVung()
        {
            return benVungDAL.LayDanhSachBenVung();
        }
        public List<BenVung> LayDanhSachBenVungTheoMaSanPham(string maSanPham)
        {
            return LayDanhSachBenVung().Where(t => t.MaSanPham == maSanPham).ToList();
        }
        public bool CapNhatBenVungDuaTrenDanhSachBenVung(List<BenVung> lstBenVung, string maSanPham)
        {
            try
            {
                // Lấy danh sách bền vững từ database dựa trên mã sản phẩm
                List<BenVung> lstBenVungDB = LayDanhSachBenVungTheoMaSanPham(maSanPham);

                // Xử lý từng đối tượng bền vững trong danh sách đầu vào
                foreach (BenVung bv in lstBenVung)
                {
                    try
                    {
                        // Tìm kiếm bền vững trong danh sách từ database
                        BenVung bvDB = lstBenVungDB.FirstOrDefault(x => x.MaBenVung == bv.MaBenVung);

                        if (bvDB != null)
                        {
                            // Nếu bền vững đã tồn tại, tiến hành cập nhật
                            if (!CapNhatBenVung(bv))
                            {
                                Console.WriteLine($"Cập nhật thất bại cho bền vững: {bv.MaBenVung}");
                            }
                        }
                        else
                        {
                            // Nếu không tìm thấy, thêm mới bền vững
                            if (!benVungDAL.ThemBenVung(bv))
                            {
                                Console.WriteLine($"Thêm mới thất bại cho bền vững: {bv.MaBenVung}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Xử lý lỗi trong quá trình xử lý từng đối tượng
                        Console.WriteLine($"Lỗi khi xử lý bền vững: {bv.MaBenVung}. Chi tiết: {ex.Message}");
                    }
                }

                // Tìm và xóa các bền vững không có trong danh sách đầu vào
                foreach (var bvDB in lstBenVungDB)
                {
                    try
                    {
                        if (!lstBenVung.Any(b => b.MaBenVung == bvDB.MaBenVung))
                        {
                            // Nếu bền vững tồn tại trong DB nhưng không có trong danh sách đầu vào, thì xóa
                            if (!benVungDAL.XoaBenVung(bvDB.MaBenVung))
                            {
                                Console.WriteLine($"Xóa thất bại cho bền vững: {bvDB.MaBenVung}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Xử lý lỗi khi xóa bền vững
                        Console.WriteLine($"Lỗi khi xóa bền vững: {bvDB.MaBenVung}. Chi tiết: {ex.Message}");
                    }
                }

                return true; // Trả về true nếu toàn bộ quá trình thành công
            }
            catch (Exception ex)
            {
                // Xử lý lỗi toàn cục trong quá trình cập nhật
                Console.WriteLine($"Lỗi toàn cục trong quá trình cập nhật danh sách bền vững. Chi tiết: {ex.Message}");
                return false;
            }
        }
    }
}
