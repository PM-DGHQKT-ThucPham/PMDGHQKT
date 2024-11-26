using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL
{
    public class DoBenBLL
    {
        public DoBenBLL()
        {

        }
        DoBenDAL doBenDAL = new DoBenDAL();

        /// <summary>
        /// Lấy danh sách độ bền
        /// </summary>
        /// <returns>Danh sách độ bền</returns>
        public List<DoBen> LayDanhSachDoBen()
        {
            return doBenDAL.LayDanhSachDoBen();
        }

        /// <summary>
        /// Lấy danh sách độ bền không trùng lắp
        /// </summary>
        /// <returns></returns>
        public List<DoBen> LayDanhSachDoBenKhongTrungLap()
        {
            // Lấy danh sách độ bền từ database
            List<DoBen> lst = doBenDAL.LayDanhSachDoBen();

            // Lọc danh sách để loại bỏ các phần tử trùng lặp
            // Giả sử "MaDoBen" là trường duy nhất để xác định độ bền không trùng lặp
            var distinctList = lst.GroupBy(d => d.MaDoBen).Select(g => g.First()).ToList();

            return distinctList;
        }
    }
}
