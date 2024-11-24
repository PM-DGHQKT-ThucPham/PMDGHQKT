﻿using DTO;
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
    }
}
