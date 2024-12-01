using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TieuChiBLL
    {
        TieuChiDAL dal = new TieuChiDAL();
        public List<TieuChi> LayTatCaDanhSachTieuChi()
        {
            return dal.LayTatCaDanhSachTieuChi();
        }
        public List<TieuChi> LayDanhSachTieuChiCuaSanPham(string masanpham)
        {
            return dal.LayDanhSachTieuChiCuaSanPham(masanpham);
        }
        public TieuChi LayTieuChi(string maTieuChi)
        {
            return dal.LayTieuChi(maTieuChi);
        }
        public bool CapNhatThemXoaSuaTieuChi(List<TieuChi> lstTieuChi)
        {
            using (var db1 = new DoAnTotNghiepDataContext()) // Thay bằng DbContext thực tế của bạn
            {
                foreach (var tc in lstTieuChi)
                {
                    // Kiểm tra tiêu chí có tồn tại trong DB không
                    var tcDb = db1.TieuChis.SingleOrDefault(n => n.MaTieuChi == tc.MaTieuChi);

                    if (tcDb != null)
                    {
                        // Cập nhật tiêu chí đã tồn tại
                        tcDb.TenTieuChi = tc.TenTieuChi;
                    }
                    else
                    {
                        // Thêm mới tiêu chí
                        db1.TieuChis.InsertOnSubmit(tc);
                    }
                }

                // Lấy danh sách mã tiêu chí hiện có trong List
                var danhSachMaTieuChi = lstTieuChi.Select(n => n.MaTieuChi).ToList();

                // Lấy các tiêu chí trong cơ sở dữ liệu không tồn tại trong List
                var TieuChiXoa = db1.TieuChis
                                       .Where(tc => !danhSachMaTieuChi.Contains(tc.MaTieuChi))
                                       .ToList();

                // Xóa các tiêu chí này khỏi cơ sở dữ liệu
                if (TieuChiXoa.Count > 0)
                {
                    db1.TieuChis.DeleteAllOnSubmit(TieuChiXoa);
                }

                // Lưu thay đổi
                db1.SubmitChanges();
            }

            return true;
        }
    }
}
