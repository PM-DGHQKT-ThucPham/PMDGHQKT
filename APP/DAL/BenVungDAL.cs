using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BenVungDAL
    {
        public BenVungDAL()
        {

        }
        DoAnTotNghiepDataContext db = new DoAnTotNghiepDataContext();
        public List<BenVung> LayDanhSachBenVung()
        {
            return db.BenVungs.ToList();
        }
        public bool ThemBenVung(BenVung benVung)
        {
            try
            {
                db.BenVungs.InsertOnSubmit(benVung);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SuaBenVung(BenVung benVung)
        {
            try
            {
                BenVung bv = db.BenVungs.Where(t => t.MaBenVung == benVung.MaBenVung).FirstOrDefault();
                bv.MaSanPham = benVung.MaSanPham;
                bv.MoTa = benVung.MoTa;
                bv.DanhGiaAnhHuongMoiTruong = benVung.DanhGiaAnhHuongMoiTruong;
                bv.DanhGiaAnToan = benVung.DanhGiaAnToan;
                bv.MucDoAnhHuong = benVung.MucDoAnhHuong;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool XoaBenVung(string maBenVung)
        {
            try
            {
                BenVung bv = db.BenVungs.Where(t => t.MaBenVung == maBenVung).FirstOrDefault();
                db.BenVungs.DeleteOnSubmit(bv);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
