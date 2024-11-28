using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NguyenLieuBLL
    {
        NguyenLieuDAL dal = new NguyenLieuDAL();
        public List<NguyenLieu> LayTatCaDanhSachNguyenLieu()
        {
            return dal.LayTatCaDanhSachNguyenLieu();
        }
        public List<NguyenLieu> LayDanhSachNguyenLieuCuaSanPham(string masanpham)
        {
            return dal.LayDanhSachNguyenLieuCuaSanPham(masanpham);
        }
        public NguyenLieu LayNguyenLieu(string manguyenlieu)
        {
            return dal.LayNguyenLieu(manguyenlieu);
        }
        public bool CapNhatThemXoaSuaNguyenLieu(List<NguyenLieu> lstNguyenLieu)
        {
            using (var db1 = new DoAnTotNghiepDataContext()) // Thay bằng DbContext thực tế của bạn
            {
                foreach (var nl in lstNguyenLieu)
                {
                    // Kiểm tra nguyên liệu có tồn tại trong DB không
                    var nlDb = db1.NguyenLieus.SingleOrDefault(n => n.MaNguyenLieu == nl.MaNguyenLieu);

                    if (nlDb != null)
                    {
                        // Cập nhật nguyên liệu đã tồn tại
                        nlDb.TenNguyenLieu = nl.TenNguyenLieu;
                        nlDb.MoTa = nl.MoTa;
                        nlDb.DanhGiaChatLuong = nl.DanhGiaChatLuong;
                    }
                    else
                    {
                        // Thêm mới nguyên liệu
                        db1.NguyenLieus.InsertOnSubmit(nl);
                    }
                }

                // Lấy danh sách mã nguyên liệu hiện có trong List
                var danhSachMaNguyenLieu = lstNguyenLieu.Select(n => n.MaNguyenLieu).ToList();

                // Lấy các nguyên liệu trong cơ sở dữ liệu không tồn tại trong List
                var nguyenLieuXoa = db1.NguyenLieus
                                       .Where(nl => !danhSachMaNguyenLieu.Contains(nl.MaNguyenLieu))
                                       .ToList();

                // Xóa các nguyên liệu này khỏi cơ sở dữ liệu
                if (nguyenLieuXoa.Count > 0)
                {
                    db1.NguyenLieus.DeleteAllOnSubmit(nguyenLieuXoa);
                }

                // Lưu thay đổi
                db1.SubmitChanges();
            }

            return true;
        }

    }
}
