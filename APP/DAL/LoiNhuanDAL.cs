using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class LoiNhuanDAL
    {
        DoAnTotNghiepDataContext db = new DoAnTotNghiepDataContext();
        List<LoiNhuan> _lstLoiNhuan = new List<LoiNhuan>();
        public LoiNhuanDAL() { }
        //lấy tất cả lợi nhuận theo mã sản phẩm
        public List<LoiNhuan> LayTatCaLoiNhuanTheoMaSanPham(string maSP)
        {
            try
            {
                _lstLoiNhuan = db.LoiNhuans.Where(x => x.MaSanPham == maSP).ToList();
                return _lstLoiNhuan;
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }
        // lấy tất cả lợi nhuận theo mã và mã sản phẩm
        public LoiNhuan LayLoiNhuanTheoMa(string maLoiNhuan, string maSP)
        {
            try
            {
                LoiNhuan loiNhuan = db.LoiNhuans.Where(x =>x.MaLoiNhuan == maLoiNhuan && x.MaSanPham == maSP).FirstOrDefault();
                return loiNhuan;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // lấy lợi nhuận theo tháng năm và mã sản phẩm
        public List<LoiNhuan> LayLoiNhuanTheoThangNam(int thang, int nam, string maSP)
        {
            try
            {
               _lstLoiNhuan = db.LoiNhuans.Where(x => x.ThoiGian.Value.Month == thang && x.ThoiGian.Value.Year == nam && x.MaSanPham == maSP).ToList();
                if (_lstLoiNhuan.Count > 0)
                {
                    return _lstLoiNhuan;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // lấy lợi nhuận theo khoảng thời gian và mã sản phẩm
        public List<LoiNhuan> LayLoiNhuanTheoKhoangThoiGian(DateTime tuNgay, DateTime denNgay, string maSP)
        {
            try
            {
                _lstLoiNhuan = db.LoiNhuans
                    .Where(x => x.ThoiGian.HasValue && x.ThoiGian.Value >= tuNgay && x.ThoiGian.Value <= denNgay && x.MaSanPham == maSP)
                    .ToList();
                return _lstLoiNhuan;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
