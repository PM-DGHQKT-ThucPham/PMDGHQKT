﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class LoiNhuanBLL
    {
        LoiNhuanDAL _loiNhuanDAL = new LoiNhuanDAL();
        public LoiNhuanBLL() { }
        //lấy tất cả lợi nhuận theo mã sản phẩm
        public List<LoiNhuan> LayTatCaLoiNhuanTheoMaSanPham(string maSP)
        {
            return _loiNhuanDAL.LayTatCaLoiNhuanTheoMaSanPham(maSP);
        }
        // lấy tất cả lợi nhuận theo mã và mã sản phẩm
        public LoiNhuan LayLoiNhuanTheoMa(string maLoiNhuan, string maSP)
        {
            return _loiNhuanDAL.LayLoiNhuanTheoMa(maLoiNhuan, maSP);
        }
        // lấy lợi nhuận theo tháng năm và mã sản phẩm
        public List<LoiNhuan> LayLoiNhuanTheoThangNam(int thang, int nam, string maSP)
        {
            return _loiNhuanDAL.LayLoiNhuanTheoThangNam(thang, nam, maSP);
        }
        // lấy lợi nhuận theo khoảng thời gian và mã sản phẩm
        public List<LoiNhuan> LayLoiNhuanTheoKhoangThoiGian(DateTime tuNgay, DateTime denNgay, string maSP)
        {
            return _loiNhuanDAL.LayLoiNhuanTheoKhoangThoiGian(tuNgay, denNgay, maSP);
        }
        public decimal TinhLoiNhuanGop(string maSP, int thang, int nam)
        {
            return _loiNhuanDAL.TinhLoiNhuanGop(maSP, thang, nam);
        }
        public decimal TinhLoiNhuanRong(string maSP, int thang, int nam)
        {
            return _loiNhuanDAL.TinhLoiNhuanRong(maSP, thang, nam);
        }
        public bool CapNhatLoiNhuanTheoThang(int thang, int nam,string maSP)
        {
            return _loiNhuanDAL.CapNhatLoiNhuanTheoThang(thang, nam,maSP);
        }
        public List<(string MaSanPham, decimal TyLeLoiNhuanGop, decimal TyLeLoiNhuanRong)> TinhTyLeLoiNhuan(int thang, int nam)
        {
            return _loiNhuanDAL.TinhTyLeLoiNhuan(thang, nam);
        }
        public bool ThemLoiNhuan(LoiNhuan ln)
        {
            return _loiNhuanDAL.ThemLoiNhuan(ln);
        }
    }
}
