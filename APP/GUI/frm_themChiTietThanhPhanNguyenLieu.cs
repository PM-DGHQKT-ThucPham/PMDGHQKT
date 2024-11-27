using BLL;
using DTO;
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
    public partial class frm_themChiTietThanhPhanNguyenLieu : Form
    {
        // Sự kiện để truyền dữ liệu về form chính
        public event EventHandler<(string maNguyenLieu, decimal phanTramNguyenLieu)> HoanTatClicked;
        NguyenLieuBLL nguyenLieuBLL = new NguyenLieuBLL();
        public frm_themChiTietThanhPhanNguyenLieu()
        {
            InitializeComponent();
            this.Load += Frm_themChiTietThanhPhanNguyenLieu_Load;
        }

        private void Frm_themChiTietThanhPhanNguyenLieu_Load(object sender, EventArgs e)
        {
            LoadComboboxNguyenLieu();
            btnHoanTatThem.Click += BtnHoanTatThem_Click;
        }

        private void BtnHoanTatThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các TextBox (hoặc control khác)
                string maNguyenLieu = cbbNguyenLieu.SelectedValue.ToString();
                decimal phanTramNguyenLieu = decimal.Parse(txtPhanTramNguyenLieu.Text.Trim());

                // Kích hoạt sự kiện và truyền dữ liệu
                HoanTatClicked?.Invoke(this, (maNguyenLieu, phanTramNguyenLieu));

                // Đóng form
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboboxNguyenLieu()
        {
            List<NguyenLieu> lstNguyenLieu = new List<NguyenLieu>();
            lstNguyenLieu = nguyenLieuBLL.LayTatCaDanhSachNguyenLieu();
            if (lstNguyenLieu != null && lstNguyenLieu.Count > 0)
            {
                cbbNguyenLieu.DataSource = lstNguyenLieu;
                cbbNguyenLieu.ValueMember = "MaNguyenLieu";
                cbbNguyenLieu.DisplayMember = "TenNguyenLieu";
                cbbNguyenLieu.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Danh sách nguyên liệu đang rỗng !!!");
            }
        }
    }
}
