using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class LoaiChiPhiDAL
    {
        DoAnTotNghiepDataContext db = new DoAnTotNghiepDataContext();
        List<LoaiChiPhi> _lstLoaiChiPhi = null;
        public LoaiChiPhiDAL()
        {
        }
        //lay danh sach loai chi phi
        public List<LoaiChiPhi> LayDanhSachLoaiChiPhi( string maSanPham)
        {
            try
            {
                _lstLoaiChiPhi = new List<LoaiChiPhi>();
                _lstLoaiChiPhi = db.LoaiChiPhis.Where(t=>t.MaSanPham==maSanPham).ToList();
                if (_lstLoaiChiPhi.Count > 0)
                {
                    return _lstLoaiChiPhi;
                }
            }
            catch  
            {
                return null;
            }
            return new List<LoaiChiPhi>(); // Ensure a return value in all code paths
        }
        //lấy loại chi phí theo mã loại chi phí
        public LoaiChiPhi LayLoaiChiPhiTheoMaLoaiChiPhi(string maLoaiChiPhi, string maSanPham)
        {
            try
            {
                LoaiChiPhi _loaiChiPhi = new LoaiChiPhi();
                _loaiChiPhi = db.LoaiChiPhis.Where(t => t.MaLoaiChiPhi == maLoaiChiPhi && t.MaSanPham == maSanPham).FirstOrDefault();
                if (_loaiChiPhi != null)
                {
                    return _loaiChiPhi;
                }
            }
            catch  
            {
                return null;
            }
            return new LoaiChiPhi(); // Ensure a return value in all code paths
        }
    }
}
