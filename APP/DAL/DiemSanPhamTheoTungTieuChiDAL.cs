using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DiemSanPhamTheoTungTieuChiDAL
    {
        DoAnTotNghiepDataContext db = new DoAnTotNghiepDataContext();
        public List<DiemSanPhamTheoTungTieuChi> LayDanhSach(string masanpham)
        {
            List<DiemSanPhamTheoTungTieuChi> lst = new List<DiemSanPhamTheoTungTieuChi>();
            var bang1 = db.SanPhams.Where(t => t.MaSanPham == masanpham).FirstOrDefault();            

            var bang2 = db.DoBens.Where(t => t.MaSanPham == masanpham).FirstOrDefault();
            if (bang2 != null)
            {
                lst.Add(new DiemSanPhamTheoTungTieuChi()
                {
                    TenTieuChi = "Chất lượng",
                    MucDoAnhHuong = (decimal)bang2.MucDoAnhHuong,
                    TrongSo = (decimal)bang2.SanPham.TieuChi_SanPhams.Where(t => t.MaTieuChi == "TC001").FirstOrDefault().TrongSo
                });
            }

            var bang3 = db.ThietKes.Where(t => t.MaSanPham == masanpham).FirstOrDefault();
            if (bang3 != null)
            {
                lst.Add(new DiemSanPhamTheoTungTieuChi()
                {
                    TenTieuChi = "Thiết kế",
                    MucDoAnhHuong = (decimal)bang3.MucDoAnhHuong,
                    TrongSo = (decimal)bang3.SanPham.TieuChi_SanPhams.Where(t => t.MaTieuChi == "TC002").FirstOrDefault().TrongSo
                });
            }
            
            var bang4 = db.HieuSuats.Where(t => t.MaSanPham == masanpham).FirstOrDefault();
            if (bang4 != null)
            {
                lst.Add(new DiemSanPhamTheoTungTieuChi()
                {
                    TenTieuChi = "Hiệu suất",
                    MucDoAnhHuong = (decimal)bang4.MucDoAnhHuong,
                    TrongSo = (decimal)bang4.SanPham.TieuChi_SanPhams.Where(t => t.MaTieuChi == "TC003").FirstOrDefault().TrongSo
                });
            }
            var bang5 = db.GiaCas.Where(t => t.MaSanPham == masanpham).FirstOrDefault();
            if (bang5 != null)
            {
                lst.Add(new DiemSanPhamTheoTungTieuChi()
                {
                    TenTieuChi = "Giá cả",
                    MucDoAnhHuong = (decimal)bang5.MucDoAnhHuong,
                    TrongSo = (decimal)bang5.SanPham.TieuChi_SanPhams.Where(t => t.MaTieuChi == "TC004").FirstOrDefault().TrongSo
                });
            }

            var bang6 = db.PhanHoiNguoiDungs.Where(t => t.MaSanPham == masanpham).ToList();
            if (bang6 != null && bang6.Count > 0)
            {
                decimal diemTB = (decimal)bang6.Average(t => t.XepHangNguoiDung);
                decimal mucDoAnhHuong = diemTB * 2;
                lst.Add(new DiemSanPhamTheoTungTieuChi()
                {
                    TenTieuChi = "Phản hồi khách hàng",
                    MucDoAnhHuong = mucDoAnhHuong,
                    TrongSo = (decimal)bang1.TieuChi_SanPhams.Where(t => t.MaTieuChi == "TC005").FirstOrDefault().TrongSo
                });
            }

            var bang7 = db.DichVuKhachHangs.Where(t => t.MaSanPham == masanpham).FirstOrDefault();
            if (bang7 != null)
            {
                lst.Add(new DiemSanPhamTheoTungTieuChi()
                {
                    TenTieuChi = "Dịch vụ khách hàng",
                    MucDoAnhHuong = (decimal)bang7.MucDoAnhHuong,
                    TrongSo = (decimal)bang7.SanPham.TieuChi_SanPhams.Where(t => t.MaTieuChi == "TC006").FirstOrDefault().TrongSo
                });
            }
            var bang8 = db.BenVungs.Where(t => t.MaSanPham == masanpham).FirstOrDefault();
            if (bang8 != null)
            {
                lst.Add(new DiemSanPhamTheoTungTieuChi()
                {
                    TenTieuChi = "Tính Bền vững",
                    MucDoAnhHuong = (decimal)bang8.MucDoAnhHuong,
                    TrongSo = (decimal)bang8.SanPham.TieuChi_SanPhams.Where(t => t.MaTieuChi == "TC007").FirstOrDefault().TrongSo
                });
            }
            if (bang1 != null)
            {
                if(lst.Count != 0)
                {
                    //lst.Add(new DiemSanPhamTheoTungTieuChi();
                    //{
                    //    TenTieuChi = "Nguyên liệu",
                    //    MucDoAnhHuong = (decimal)bang1.MucDoAnhHuongTongNguyenLieu,
                    //    TrongSo = (decimal)bang1.TieuChi_SanPhams.Where(t => t.MaTieuChi == "TC008").FirstOrDefault().TrongSo
                    //});
                    DiemSanPhamTheoTungTieuChi d = new DiemSanPhamTheoTungTieuChi();
                    d.TenTieuChi = "Nguyên liệu";
                    decimal diem = bang1.MucDoAnhHuongTongNguyenLieu.Value;
                    if(diem < 0)
                    {
                        diem = 0;
                    }
                }
                else
                {
                    return null;
                }
            }
            return lst;
        }
    }
}
