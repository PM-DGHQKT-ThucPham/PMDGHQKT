using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChiTietThanhPhanBLL
    {
        ChiTietThanhPhanDAL dal = new  ChiTietThanhPhanDAL();
        public List<ChiTietThanhPhan> LayCTTP_CuaSanPham(string masp)
        {
            return dal.LayCTTP_CuaSanPham(masp);
        }
    }
}
