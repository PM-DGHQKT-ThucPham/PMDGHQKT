using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
namespace GUI
{
    public partial class frm_quanLyKhoHang : Form
    {
        SanPhamBLL spBll = new SanPhamBLL();
        List<SanPham> lstSanPham = new List<SanPham>();
        public frm_quanLyKhoHang()
        {
            InitializeComponent();
            this.Load += Frm_quanLyKhoHang_Load;
            themXoaSuaSanPham.ThemClicked += ThemXoaSuaSanPham_ThemClicked;
            themXoaSuaSanPham.HuyThemClicked += ThemXoaSuaSanPham_HuyThemClicked;
            
        }

        private void ThemXoaSuaSanPham_HuyThemClicked(object sender, EventArgs e)
        {
            BatDataBindingDataGridViewSanPham();
        }

        private void ThemXoaSuaSanPham_ThemClicked(object sender, EventArgs e)
        {
            if (themXoaSuaSanPham.BtnHuyThem.Enabled == false)
            {
                themXoaSuaSanPham.BtnHuyThem.Enabled = true;
                themXoaSuaSanPham.BtnXoa.Enabled = false;
                themXoaSuaSanPham.BtnSua.Enabled = false;
                themXoaSuaSanPham.BtnLuu.Enabled = false;
                themXoaSuaSanPham.BtnThem.Image = Properties.Resources.icons8_tick_35;
                TatDataBindingDataGridViewSanPham();
                XoaTextBoxSanPham();
            }
            else
            {

                BatDataBindingDataGridViewSanPham();
            }
            
        }
        private bool KiemTraRongTextBoxSanPham()
        {
            if (String.IsNullOrEmpty(txtDanhMuc.Text))
            {
                return true;
            }
            if (String.IsNullOrEmpty(txtMaSanPham.Text))
            {
                return true;
            }
            if (String.IsNullOrEmpty(txtTenSanPham.Text))
            {
                return true;
            }
            if (String.IsNullOrEmpty(txtGia.Text))
            {
                return true;
            }
            if (String.IsNullOrEmpty(txtMoTa.Text))
            {
                return true;
            }
            if (String.IsNullOrEmpty(txtMucDoAnhHuongNguyenLieu.Text))
            {
                return true;
            }
            if (String.IsNullOrEmpty(txtSoLuongTon.Text))
            {
                return true;
            }
            return false;
        }

        private void XoaTextBoxSanPham()
        {
            txtDanhMuc.Clear();
            txtGia.Clear();
            txtMaSanPham.Clear();
            txtMoTa.Clear();
            txtMucDoAnhHuongNguyenLieu.Clear();
            txtSoLuongTon.Clear();
            txtTenSanPham.Clear();
            dtpNgayPhatHanh.Refresh();
        }

        private void Frm_quanLyKhoHang_Load(object sender, EventArgs e)
        {
            LoadDanhSachSanPham();
        }

        private void LoadDanhSachSanPham()
        {
            lstSanPham = spBll.LayDanhSachSanPham();
            dgv_dsSanPham.DataSource = lstSanPham;
            dgv_dsSanPham.AllowUserToAddRows = false;
            dgv_dsSanPham.AutoGenerateColumns = false;
            dgv_dsSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dgv_dsSanPham.Columns[0].HeaderText = "Mã sản phẩm";
            dgv_dsSanPham.Columns[1].HeaderText = "Tên sản phẩm";
            dgv_dsSanPham.Columns[2].HeaderText = "Mô tả";
            dgv_dsSanPham.Columns[3].HeaderText = "Giá";
            dgv_dsSanPham.Columns[4].HeaderText = "Danh mục";
            dgv_dsSanPham.Columns[5].HeaderText = "Số lượng tồn";
            dgv_dsSanPham.Columns[6].HeaderText = "Ngày phát hành";
            dgv_dsSanPham.Columns[7].HeaderText = "Mức độ ảnh hưởng";
            BatDataBindingDataGridViewSanPham();
            TatDataBindingDataGridViewSanPham();
        }

        private void TatDataBindingDataGridViewSanPham()
        {
            // Xóa các binding cũ (nếu có)
            txtMaSanPham.DataBindings.Clear();
            txtTenSanPham.DataBindings.Clear();
            txtMoTa.DataBindings.Clear();
            txtGia.DataBindings.Clear();
            txtDanhMuc.DataBindings.Clear();
            txtSoLuongTon.DataBindings.Clear();
            txtMucDoAnhHuongNguyenLieu.DataBindings.Clear();
            dtpNgayPhatHanh.DataBindings.Clear();
        }

        public void BatDataBindingDataGridViewSanPham()
        {
            TatDataBindingDataGridViewSanPham();
            // Ràng buộc dữ liệu từ DataGridView vào các điều khiển
            txtMaSanPham.DataBindings.Add("Text", dgv_dsSanPham.DataSource, "MaSanPham");
            txtTenSanPham.DataBindings.Add("Text", dgv_dsSanPham.DataSource, "TenSanPham");
            txtMoTa.DataBindings.Add("Text", dgv_dsSanPham.DataSource, "MoTa");
            txtGia.DataBindings.Add("Text", dgv_dsSanPham.DataSource, "Gia");
            txtDanhMuc.DataBindings.Add("Text", dgv_dsSanPham.DataSource, "DanhMuc");
            txtSoLuongTon.DataBindings.Add("Text", dgv_dsSanPham.DataSource, "SoLuongTon");
            dtpNgayPhatHanh.DataBindings.Add("Value", dgv_dsSanPham.DataSource, "NgayPhatHanh");
            txtMucDoAnhHuongNguyenLieu.DataBindings.Add("Text", dgv_dsSanPham.DataSource, "MucDoAnhHuongTongNguyenLieu");
        }


    }
}
