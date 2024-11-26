using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DoBenDAL
    {
        DoAnTotNghiepDataContext db = new DoAnTotNghiepDataContext();
        public DoBenDAL()
        {
            db = new DoAnTotNghiepDataContext();
        }

        /// <summary>
        /// Lấy danh sách độ bền
        /// </summary>
        /// <returns>Danh sách độ bền có trong database</returns>
        public List<DoBen> LayDanhSachDoBen()
        {
            return db.DoBens.ToList();
        }

        /// <summary>
        /// Thêm độ bền
        /// </summary>
        /// <param name="doBen"></param>
        /// <returns></returns>
        public bool ThemDoBen(DoBen doBen)
        {
            try
            {
                db.DoBens.InsertOnSubmit(doBen);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Cập nhật độ bền theo mã độ bền
        /// </summary>
        /// <param name="doBen"></param>
        /// <returns></returns>
        public bool CapNhatDoBen(DoBen doBen)
        {
            try
            {
                DoBen dbDoBen = db.DoBens.FirstOrDefault(x => x.MaDoBen == doBen.MaDoBen);
                if (dbDoBen != null)
                {
                    dbDoBen.MaSanPham = doBen.MaSanPham;
                    dbDoBen.TuoiThoNgay = doBen.TuoiThoNgay;
                    dbDoBen.DanhGiaDoBen = doBen.DanhGiaDoBen;
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Xóa độ bền theo mã độ bền
        /// </summary>
        /// <param name="maDoBen"></param>
        /// <returns></returns>
        public bool XoaDoBen(string maDoBen)
        {
            try
            {
                DoBen dbDoBen = db.DoBens.FirstOrDefault(x => x.MaDoBen == maDoBen);
                if (dbDoBen != null)
                {
                    db.DoBens.DeleteOnSubmit(dbDoBen);
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
