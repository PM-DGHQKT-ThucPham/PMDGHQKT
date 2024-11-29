using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;


namespace DAL
{
    public class TinhNangBoSungDAL
    {
        public TinhNangBoSungDAL()
        {
        }
        DoAnTotNghiepDataContext db = new DoAnTotNghiepDataContext();
        public List<TinhNangBoSung> LayDanhSachTinhNangBoSung()
        {
            return db.TinhNangBoSungs.ToList();
        }
        public bool ThemTinhNangBoSung(TinhNangBoSung tinhNangBoSung)
        {
            try
            {
                db.TinhNangBoSungs.InsertOnSubmit(tinhNangBoSung);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool XoaTinhNangBoSung(string maTinhNang)
        {
            try
            {
                TinhNangBoSung tinhNangBoSung = db.TinhNangBoSungs.Where(p => p.MaTinhNang == maTinhNang).FirstOrDefault();
                db.TinhNangBoSungs.DeleteOnSubmit(tinhNangBoSung);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CapNhatTinhNangBoSung(TinhNangBoSung tnbs)
        {
            try
            {
                TinhNangBoSung tinhNangBoSung = db.TinhNangBoSungs.Where(p => p.MaTinhNang == tnbs.MaTinhNang).FirstOrDefault();
                tinhNangBoSung.MaSanPham = tnbs.MaSanPham;
                tinhNangBoSung.MoTa = tnbs.MoTa;
                tinhNangBoSung.DanhGiaCongNghe = tnbs.DanhGiaCongNghe;
                tinhNangBoSung.DanhGiaLinhHoat = tnbs.DanhGiaLinhHoat;
                tinhNangBoSung.MucDoAnhHuong = tnbs.MucDoAnhHuong;
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
