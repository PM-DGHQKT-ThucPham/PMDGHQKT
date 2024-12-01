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
    public partial class frm_themTieuChi_SanPhamTieuChi : Form
    {
        // Sự kiện để truyền dữ liệu về form chính
        public event EventHandler<(string maTieuChi, decimal trongSo)> HoanTatClicked;
        TieuChiBLL TieuChiBLL = new TieuChiBLL();
        public frm_themTieuChi_SanPhamTieuChi()
        {
            InitializeComponent();
            this.Load += Frm_themChiTietThanhPhanTieuChi_Load;
        }

        private void Frm_themChiTietThanhPhanTieuChi_Load(object sender, EventArgs e)
        {
            LoadComboboxTieuChi();
            btnHoanTatThem.Click += BtnHoanTatThem_Click;
        }

        private void BtnHoanTatThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các TextBox (hoặc control khác)
                string maTieuChi = cbbTieuChi.SelectedValue.ToString();
                decimal trongSo = decimal.Parse(txtTrongSo.Text.Trim());

                // Kích hoạt sự kiện và truyền dữ liệu
                HoanTatClicked?.Invoke(this, (maTieuChi, trongSo));

                // Đóng form
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboboxTieuChi()
        {
            List<TieuChi> lstTieuChi = new List<TieuChi>();
            lstTieuChi = TieuChiBLL.LayTatCaDanhSachTieuChi();
            if (lstTieuChi != null && lstTieuChi.Count > 0)
            {
                cbbTieuChi.DataSource = lstTieuChi;
                cbbTieuChi.ValueMember = "MaTieuChi";
                cbbTieuChi.DisplayMember = "TenTieuChi";
                cbbTieuChi.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Danh sách tiêu chí đang rỗng !!!");
            }
        }
    }
}
