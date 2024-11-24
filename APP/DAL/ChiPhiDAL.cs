using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class ChiPhiDAL
    {
        DoAnTotNghiepDataContext db = new DoAnTotNghiepDataContext();
        List<ChiPhi> _lstChiPhi = null;
        public ChiPhiDAL()
        {
        }
        //lay danh sach chi phi theo mã sản phẩm
        public List<ChiPhi> LayDanhSachChiPhi(string maSanPham)
        {
            try
            {
                _lstChiPhi = new List<ChiPhi>();
                _lstChiPhi = db.ChiPhis.Where(t => t.LoaiChiPhi.MaSanPham == maSanPham).ToList();
                if (_lstChiPhi.Count > 0)
                {
                    return _lstChiPhi;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return new List<ChiPhi>(); // Ensure a return value in all code paths
        }
        //lấy chi phí theo mã chi phí
        public ChiPhi LayChiPhiTheoMaChiPhi(string maChiPhi,string maSanPham)
        {
            try
            {
                ChiPhi _chiPhi = new ChiPhi();
                _chiPhi = db.ChiPhis.Where(t =>t.LoaiChiPhi.MaSanPham==maSanPham && t.MaChiPhi==maChiPhi).FirstOrDefault();
                if (_chiPhi != null)
                {
                    return _chiPhi;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return new ChiPhi(); // Ensure a return value in all code paths
        }
        //lấy chi phí theo mã loại chi phí
        public List<ChiPhi> LayChiPhiTheoMaLoaiChiPhi(string maLoaiChiPhi,string maSanPham)
        {
            try
            {
                _lstChiPhi = new List<ChiPhi>();
                _lstChiPhi = db.ChiPhis.Where(x => x.MaLoaiChiPhi == maLoaiChiPhi && x.LoaiChiPhi.MaSanPham==maSanPham).ToList();
                if (_lstChiPhi.Count > 0)
                {
                    return _lstChiPhi;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return new List<ChiPhi>(); // Ensure a return value in all code paths
        }
        //lấy chi phí theo tháng năm
        public List<ChiPhi> LayChiPhiTheoThangNam(int thang, int nam,string maSanPham)
        {
            try
            {
                _lstChiPhi = new List<ChiPhi>();
                _lstChiPhi = db.ChiPhis.Where( x =>x.LoaiChiPhi.MaSanPham==maSanPham && x.ThoiGian.HasValue && x.ThoiGian.Value.Month == thang && x.ThoiGian.Value.Year == nam).ToList();
                if (_lstChiPhi.Count > 0)
                {
                    return _lstChiPhi;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return new List<ChiPhi>(); // Ensure a return value in all code paths
        }
        //lấy chi phí theo khoảng thời gian của 1 san phẩm
        public List<ChiPhi> LayChiPhiTheoKhoangThoiGian(DateTime tuNgay, DateTime denNgay, string maSanPham)
        {
            try
            {
                _lstChiPhi = new List<ChiPhi>();
                _lstChiPhi = db.ChiPhis.Where(x => x.LoaiChiPhi.MaSanPham == maSanPham && x.ThoiGian >= tuNgay && x.ThoiGian <= denNgay).ToList();
                if (_lstChiPhi.Count > 0)
                {
                    return _lstChiPhi;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return new List<ChiPhi>(); // Ensure a return value in all code paths
        }

    }
}
