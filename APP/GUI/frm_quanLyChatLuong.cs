using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_quanLyChatLuong : Form
    {
        public frm_quanLyChatLuong()
        {
            InitializeComponent();
        }

        private void frm_quanLyChatLuong_Load(object sender, EventArgs e)
        {
            DinhDangDGVDoBen();
            TaiDanhSachDoBen();
        }

        /// <summary>
        /// Định dạng datagridview dgvDoBen
        /// </summary>
        private void DinhDangDGVDoBen()
        {
            dgvDoBen.Columns.Clear();
            dgvDoBen.AutoGenerateColumns = false;

            // Thêm các cột với chế độ AutoSize
            dgvDoBen.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaDoBen",
                HeaderText = "Mã độ bền",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
            dgvDoBen.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaSanPham",
                HeaderText = "Mã sản phẩm",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
            dgvDoBen.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TuoiThoNgay",
                HeaderText = "Tuổi thọ (ngày)",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight // Căn lề phải cho cột số
                }
            });
            dgvDoBen.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DanhGiaDoBen",
                HeaderText = "Đánh giá độ bền",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight // Căn lề phải cho cột số
                }
            });
            dgvDoBen.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MucDoAnhHuong",
                HeaderText = "Mức độ ảnh hưởng",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight // Căn lề phải cho cột số
                }
            });
            dgvDoBen.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MoTa",
                HeaderText = "Mô tả",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, // Cột mô tả chiếm hết không gian còn lại
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    WrapMode = DataGridViewTriState.True // Cho phép xuống dòng
                }
            });

            // Cho phép tự động thay đổi chiều cao dòng nếu nội dung vượt quá chiều cao
            dgvDoBen.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Một số cài đặt khác
            dgvDoBen.AllowUserToAddRows = false; // Không cho thêm hàng trống cuối
            dgvDoBen.AllowUserToDeleteRows = true; // Cho phép xóa hàng
            dgvDoBen.ReadOnly = false; // Có thể chỉnh sửa
            dgvDoBen.Dock = DockStyle.Fill; // Chiếm toàn bộ không gian Form
        }

        /// <summary>
        /// Tải danh sách độ bền từ database lên datagridview
        /// </summary>
        private void TaiDanhSachDoBen()
        {
            DoBenBLL doBenBLL = new DoBenBLL();
            var danhSach = doBenBLL.LayDanhSachDoBenKhongTrungLap();

            dgvDoBen.DataSource = null;
            dgvDoBen.DataSource = danhSach;
        }

    }
}
