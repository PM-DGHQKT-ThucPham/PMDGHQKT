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
    }
}
