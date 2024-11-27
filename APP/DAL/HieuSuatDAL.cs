using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HieuSuatDAL
    {
        public HieuSuatDAL() { }
        DoAnTotNghiepDataContext db = new DoAnTotNghiepDataContext();
        /// <summary>
        /// Lấy danh sách hiệu suất
        /// </summary>
        /// <returns></returns>
        public List<HieuSuat> LayDanhSachHieuSuat()
        {
            return db.HieuSuats.ToList();
        }
        /// <summary>
        /// Thêm hiệu suất mới
        /// </summary>
        /// <param name="hs"></param>
        /// <returns></returns>
        public bool ThemHieuSuat(HieuSuat hs)
        {
            try
            {
                db.HieuSuats.InsertOnSubmit(hs);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Cập nhật hiệu suất
        /// </summary>
        /// <param name="hs"></param>
        /// <returns></returns>
        public bool CapNhatHieuSuat(HieuSuat hs)
        {
            try
            {
                HieuSuat hieuSuat = db.HieuSuats.Where(p => p.MaHieuSuat == hs.MaHieuSuat).FirstOrDefault();
                hieuSuat.MaSanPham = hs.MaSanPham;
                hieuSuat.MoTa = hs.MoTa;
                hieuSuat.DanhGiaChucNang = hs.DanhGiaChucNang;
                hieuSuat.DanhGiaTocDo = hs.DanhGiaTocDo;
                hieuSuat.MucDoAnhHuong = hs.MucDoAnhHuong;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Xóa hiệu suất
        /// </summary>
        /// <param name="maHieuSuat"></param>
        /// <returns></returns>
        public bool XoaHieuSuat(string maHieuSuat)
        {
            try
            {
                HieuSuat hieuSuat = db.HieuSuats.Where(p => p.MaHieuSuat == maHieuSuat).FirstOrDefault();
                db.HieuSuats.DeleteOnSubmit(hieuSuat);
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
