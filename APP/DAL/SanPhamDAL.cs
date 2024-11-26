using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SanPhamDAL
    {
        DoAnTotNghiepDataContext db = new DoAnTotNghiepDataContext();
        List<SanPham> _lstSanPham = null;

        // Lấy danh sách san pham
        public List<SanPham> LayDanhSachSanPham()
        {
            try
            {
                _lstSanPham = new List<SanPham>();
                _lstSanPham = db.SanPhams.ToList();
                return _lstSanPham;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Lấy san pham theo mã
        public SanPham LaySanPhamTheoMa(string maSanPham)
        {
            try
            {
                SanPham SanPham = new SanPham();
                SanPham = db.SanPhams.FirstOrDefault(x => x.MaSanPham == maSanPham);
                return SanPham;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ThemSanPham(SanPham sp)
        {
            try
            {
                db.SanPhams.InsertOnSubmit(sp);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        public bool XoaSanPham(SanPham sp)
        {
            try
            {
                db.SanPhams.DeleteOnSubmit(sp);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool SuaSanPham(string masp1, SanPham sp1)
        {
            try
            {
                SanPham sp = db.SanPhams.Where(t => t.MaSanPham == masp1).FirstOrDefault();
                // Sản phẩm cũ bằng sản phẩm mới
                sp = sp1;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}
