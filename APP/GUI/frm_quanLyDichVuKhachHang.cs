using BLL;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.Utils.StructuredStorage.Internal;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.Utils.HashCodeHelper;
using System.Xml;

namespace GUI
{
    public partial class frm_quanLyDichVuKhachHang : Form
    {
        private List<DichVuKhachHang> danhSachDichVuCuaSanPham = new List<DichVuKhachHang>();
        public frm_quanLyDichVuKhachHang()
        {
            InitializeComponent();
            this.Load += Frm_quanLyDichVuKhachHang_Load;
            this.cboSanPham.SelectedIndexChanged += CboSanPham_SelectedIndexChanged;
            this.dgvDichVuKhachHang.SelectionChanged += DgvDichVuKhachHang_SelectionChanged;
            themXoaSua.ThemClicked += ThemXoaSua_ThemClicked;
            themXoaSua.XoaClicked += ThemXoaSua_XoaClicked;
            themXoaSua.SuaClicked += ThemXoaSua_SuaClicked;
            themXoaSua.LuuClicked += ThemXoaSua_LuuClicked;
            themXoaSua.HuyThemClicked += ThemXoaSua_HuyThemClicked;
        }

        /// <summary>
        /// Lấy danh sách sản phẩm từ database
        /// </summary>
        /// <returns></returns>
        private List<SanPham> LaySanDanhSachSanPham()
        {
            SanPhamBLL sanPhamBLL = new SanPhamBLL();
            return sanPhamBLL.LayDanhSachSanPham();
        }

        /// <summary>
        /// Load dữ liệu từ database vào combobox, datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_quanLyDichVuKhachHang_Load(object sender, EventArgs e)
        {
            // Load danh sách sản phẩm vào combobox
            List<SanPham> lstSanPham = LaySanDanhSachSanPham();
            cboSanPham.DataSource = lstSanPham;
            cboSanPham.DisplayMember = "TenSanPham";
            cboSanPham.ValueMember = "MaSanPham";
            cboSanPham.SelectedIndex = -1;
        }

        /// <summary>
        /// Lấy thông tin sản phẩm theo mã sản phẩm
        /// </summary>
        /// <param name="maSP"></param>
        /// <returns></returns>
        public SanPham LaySanPhamTheoMa(string maSP)
        {
            SanPhamBLL sanPhamBLL = new SanPhamBLL();
            return sanPhamBLL.LaySanPhamTheoMa(maSP);
        }

        /// <summary>
        /// Load dữ liệu từ database vào datagridview
        /// </summary>
        /// <param name="maSP"></param>
        private void LoadDGVDichVuKhachHang(string maSP)
        {
            DichVuKhachHangBLL dichVuKhachHangBLL = new DichVuKhachHangBLL();
            List<DichVuKhachHang> lstDichVuKhachHang = dichVuKhachHangBLL.LayDanhSachDichVuKhachHang();
            dgvDichVuKhachHang.DataSource = lstDichVuKhachHang.Where(p => p.MaSanPham == maSP).ToList();
            danhSachDichVuCuaSanPham = lstDichVuKhachHang.Where(p => p.MaSanPham == maSP).ToList();

            // Định dạng các cột của dgvDichVuKhachHang
            DinhDangDGV();
        }

        private void DinhDangDGV()
        {
            // Đặt chế độ cho datagridview là fill
            dgvDichVuKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Tiêu đề các cột sẽ căn giữa
            foreach (DataGridViewColumn column in dgvDichVuKhachHang.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Ẩn các cột không cần thiết
            dgvDichVuKhachHang.Columns["SanPham"].Visible = false;
            dgvDichVuKhachHang.Columns["MaSanPham"].Visible = false;

            // Đặt tên tiêu đề các cột
            dgvDichVuKhachHang.Columns["MaDichVu"].HeaderText = "Mã dịch vụ";
            dgvDichVuKhachHang.Columns["MoTa"].HeaderText = "Mô tả";
            dgvDichVuKhachHang.Columns["DanhGiaHoTro"].HeaderText = "Đánh giá hỗ trợ";
            dgvDichVuKhachHang.Columns["ThoiGianBaoHanh"].HeaderText = "Thời gian bảo hành(tháng)";
            dgvDichVuKhachHang.Columns["MucDoAnhHuong"].HeaderText = "Mức độ ảnh hưởng";

            // Cột đánh giá hỗ trợ, thời gian bảo hành, mức độ ảnh hưởng căn lề phải
            dgvDichVuKhachHang.Columns["DanhGiaHoTro"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDichVuKhachHang.Columns["ThoiGianBaoHanh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDichVuKhachHang.Columns["MucDoAnhHuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Đặt chiều cao hàng tự động điều chỉnh theo nội dung
            dgvDichVuKhachHang.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;

            // Cột mô tả là cột cuối cùng
            dgvDichVuKhachHang.Columns["MoTa"].DisplayIndex = dgvDichVuKhachHang.Columns.Count - 1;

            // Cột mô tả tự động xuống dòng khi nội dung quá dài
            dgvDichVuKhachHang.Columns["MoTa"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Thiết lập tỉ lệ chiều rộng cho các cột
            dgvDichVuKhachHang.Columns["MaDichVU"].FillWeight = 8;
            dgvDichVuKhachHang.Columns["DanhGiaHoTro"].FillWeight = 8;
            dgvDichVuKhachHang.Columns["ThoiGianBaoHanh"].FillWeight = 8;
            dgvDichVuKhachHang.Columns["MucDoAnhHuong"].FillWeight = 8;
            dgvDichVuKhachHang.Columns["MoTa"].FillWeight = 78;
        }

        /// <summary>
        /// Xử lý sự kiện khi chọn sản phẩm từ combobox sản phẩm để hiển thị thông tin sản phẩm lên datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedValue != null)
            {
                string maSP = cboSanPham.SelectedValue.ToString();
                SanPham sanPham = LaySanPhamTheoMa(maSP);
                if (sanPham != null)
                {
                    LoadDGVDichVuKhachHang(maSP);
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Xoá dữ liệu các textbox
        /// </summary>
        private void ClearTextBoxes()
        {
            txtMaDichVu.Clear();
            txtMoTa.Clear();
            txtDanhGiaHoTro.Clear();
            txtThoiGianBaoHanh.Clear();
            txtMucDoAnhHuong.Clear();
        }

        /// <summary>
        /// Hiển thị dữ liệu lên các textbox khi có dòng được chọn trên datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvDichVuKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvDichVuKhachHang.CurrentRow != null && dgvDichVuKhachHang.CurrentRow.Cells["MaDichVu"].Value != null)
                {
                    // Lấy dữ liệu từ dòng được chọn
                    string maDichVu = dgvDichVuKhachHang.CurrentRow.Cells["MaDichVu"].Value.ToString();
                    string moTa = dgvDichVuKhachHang.CurrentRow.Cells["MoTa"].Value.ToString();
                    string danhGiaHoTro = dgvDichVuKhachHang.CurrentRow.Cells["DanhGiaHoTro"].Value.ToString();
                    string thoiGianBaoHanh = dgvDichVuKhachHang.CurrentRow.Cells["ThoiGianBaoHanh"].Value.ToString();
                    string mucDoAnhHuong = dgvDichVuKhachHang.CurrentRow.Cells["MucDoAnhHuong"].Value.ToString();

                    // Hiển thị dữ liệu lên các textbox
                    txtMaDichVu.Text = maDichVu;
                    txtMoTa.Text = moTa;
                    txtDanhGiaHoTro.Text = danhGiaHoTro;
                    txtThoiGianBaoHanh.Text = thoiGianBaoHanh;
                    txtMucDoAnhHuong.Text = mucDoAnhHuong;
                }
                else
                {
                    // Nếu không có dòng nào được chọn, xóa dữ liệu trong các textbox
                    ClearTextBoxes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private bool KiemTraTextBoxLaSo(TextBox textBox)
        {
            try
            {
                decimal so = Convert.ToDecimal(textBox.Text);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        private bool ThemDoiTuongVaoDataGridView(DichVuKhachHang dvkh)
        {
            try
            {
                // Kiểm tra mã dịch vụ đã tồn tại trong datagridview chưa
                foreach (DataGridViewRow row in dgvDichVuKhachHang.Rows)
                {
                    if (row.Cells["MaDichVu"].Value != null &&
                        row.Cells["MaDichVu"].Value.ToString().ToLower() == dvkh.MaDichVu.ToLower())
                    {
                        MessageBox.Show("Mã dịch vụ đã tồn tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                // Kiểm tra mã đã tồn tại trong database chưa
                DichVuKhachHangBLL dichVuKhachHangBLL = new DichVuKhachHangBLL();
                List<DichVuKhachHang> danhSachDichVu = dichVuKhachHangBLL.LayDanhSachDichVuKhachHang();
                foreach (DichVuKhachHang dv in danhSachDichVu)
                {
                    if (dv.MaDichVu.ToLower() == dvkh.MaDichVu.ToLower())
                    {
                        MessageBox.Show("Mã dịch vụ đã tồn tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                // Thêm vào danh sách dịch vụ của sản phẩm
                danhSachDichVuCuaSanPham.Add(dvkh);
                dgvDichVuKhachHang.DataSource = null;
                dgvDichVuKhachHang.DataSource = danhSachDichVuCuaSanPham;
                dgvDichVuKhachHang.Refresh();
                DinhDangDGV();
                // Hiển thị thông báo thêm thành công
                MessageBox.Show("Thêm dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool KiemTraDuLieuTextbox()
        {
            if (txtMaDichVu.Text.Length <= 0)
            {
                MessageBox.Show("Mã dịch vụ không được để trống");
                txtMaDichVu.Focus();
                return false;
            }
            if (cboSanPham.SelectedValue.ToString().Length <= 0)
            {
                MessageBox.Show("Mã sản phẩm bị lỗi");
                return false;
            }
            if (txtMoTa.Text.Length <= 0)
            {
                MessageBox.Show("Mô tả không được để trống");
                txtMoTa.Focus();
                return false;
            }
            if (txtDanhGiaHoTro.Text.Length <= 0)
            {
                MessageBox.Show("Đánh giá hỗ trợ không được để trống");
                txtDanhGiaHoTro.Focus();
                return false;
            }
            if (!KiemTraTextBoxLaSo(txtDanhGiaHoTro) || Convert.ToDecimal(txtDanhGiaHoTro.Text) <= 0 || Convert.ToDecimal(txtDanhGiaHoTro.Text) > 10)
            {
                MessageBox.Show("Đánh giá hỗ trợ phải lớn hơn 0 và nhỏ hơn 10");
                txtDanhGiaHoTro.Focus();
                return false;
            }
            if (txtThoiGianBaoHanh.Text.Length <= 0)
            {
                MessageBox.Show("Thời gian bảo hành không được để trống");
                txtThoiGianBaoHanh.Focus();
                return false;
            }
            if (!KiemTraTextBoxLaSo(txtThoiGianBaoHanh) || Convert.ToInt32(txtThoiGianBaoHanh.Text) <= 0 || Convert.ToInt32(txtThoiGianBaoHanh.Text) > 12)
            {
                MessageBox.Show("Thời gian bảo hành phải lớn hơn 0 và nhỏ hơn 12");
                txtThoiGianBaoHanh.Focus();
                return false;
            }
            if (txtMucDoAnhHuong.Text.Length <= 0)
            {
                MessageBox.Show("Mức độ ảnh hưởng không được để trống");
                txtMucDoAnhHuong.Focus();
                return false;
            }
            if (!KiemTraTextBoxLaSo(txtMucDoAnhHuong) || Convert.ToDecimal(txtMucDoAnhHuong.Text) <= 0 || Convert.ToDecimal(txtMucDoAnhHuong.Text) > 10)
            {
                MessageBox.Show("Mức độ ảnh hưởng phải lớn hơn 0 và nhỏ hơn 10");
                txtMucDoAnhHuong.Focus();
                return false;
            }
            return true;
        }

        private DichVuKhachHang LayDichVuTuTextBox()
        {
            string maDichVu = txtMaDichVu.Text;
            string maSanPham = cboSanPham.SelectedValue.ToString();
            string moTa = txtMoTa.Text;
            decimal danhGiaHoTro = Convert.ToDecimal(txtDanhGiaHoTro.Text);
            int thoiGianBaoHanh = Convert.ToInt32(txtThoiGianBaoHanh.Text);
            decimal mucDoAnhHuong = Convert.ToDecimal(txtMucDoAnhHuong.Text);
            // Thực hiện thêm vào datagridview ở đây
            DichVuKhachHang dvkh = new DichVuKhachHang();
            dvkh.MaDichVu = maDichVu;
            dvkh.MaSanPham = maSanPham;
            dvkh.MoTa = moTa;
            dvkh.DanhGiaHoTro = danhGiaHoTro;
            dvkh.ThoiGianBaoHanh = thoiGianBaoHanh;
            dvkh.MucDoAnhHuong = mucDoAnhHuong;
            return dvkh;
        }

        private void ThemXoaSua_ThemClicked(object sender, EventArgs e)
        {

            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show(
                "Bạn có muốn thêm dữ liệu này không?",        // Nội dung câu hỏi
                "Xác nhận thêm dữ liệu",                     // Tiêu đề hộp thoại
                MessageBoxButtons.YesNo,                     // Các nút Yes và No
                MessageBoxIcon.Question                     // Icon hình dấu hỏi
            );

            // Xử lý theo lựa chọn của người dùng
            if (result == DialogResult.Yes)
            {
                if (cboSanPham.SelectedValue == null)
                {
                    MessageBox.Show("Không có dữ liệu để thêm");
                    return;
                }
                if (themXoaSua.BtnHuyThem.Enabled == true)
                {
                    // Thực hiện kiểm tra ở đây
                    if (KiemTraDuLieuTextbox() == false)
                    {
                        return;
                    }
                    DichVuKhachHang dvkh = LayDichVuTuTextBox();
                    bool ketQuaThem = ThemDoiTuongVaoDataGridView(dvkh);
                    // Nếu thêm thành công thì đổi trạng thái các nút, thêm thất bại thì return
                    if (!ketQuaThem)
                    {
                        return;
                    }
                    // Nút huỷ thêm đang không cho chọn thì các nút xoá, sửa, lưu sẽ cho sử dụng
                    // Hình ảnh của nút thêm sẽ là dấu cộng
                    themXoaSua.BtnThem.Image = Properties.Resources.icons8_add_35;
                    themXoaSua.BtnXoa.Enabled = true;
                    themXoaSua.BtnSua.Enabled = true;
                    themXoaSua.BtnLuu.Enabled = true;
                    themXoaSua.BtnHuyThem.Enabled = false;
                    txtMaDichVu.Enabled = true;
                    dgvDichVuKhachHang.Refresh();
                }
                else
                {
                    // Nút huỷ thêm đang cho chọn thì các nút xoá, sửa, lưu sẽ không cho chọn
                    // Hình ảnh của nút thêm sẽ là dấu V
                    themXoaSua.BtnThem.Image = Properties.Resources.icons8_tick_35;
                    themXoaSua.BtnXoa.Enabled = false;
                    themXoaSua.BtnSua.Enabled = false;
                    themXoaSua.BtnLuu.Enabled = false;
                    themXoaSua.BtnHuyThem.Enabled = true;
                    txtMaDichVu.Enabled = true;
                    ClearTextBoxes();
                }
            }

        }

        private void ThemXoaSua_XoaClicked(object sender, EventArgs e)
        {
            // hỏi xác nhận xoá 
            DialogResult result = MessageBox.Show(
                "Bạn có muốn xoá dữ liệu này không?",        // Nội dung câu hỏi
                "Xác nhận xoá dữ liệu",                     // Tiêu đề hộp thoại
                MessageBoxButtons.YesNo,                     // Các nút Yes và No
                MessageBoxIcon.Question                     // Icon hình dấu hỏi
            );
            if (result == DialogResult.Yes)
            {
                string maSanPham = cboSanPham.SelectedValue.ToString();
                if (dgvDichVuKhachHang.CurrentRow != null && dgvDichVuKhachHang.CurrentRow.Cells["MaDichVu"].Value != null)
                {
                    string maDichVu = dgvDichVuKhachHang.CurrentRow.Cells["MaDichVu"].Value.ToString();
                    // Xoá dịch vụ đang chọn trong dgv ra khỏi danhSachDichVuCuaSanPham
                    DichVuKhachHang dichVuKhachHang = danhSachDichVuCuaSanPham.Where(p => p.MaDichVu == maDichVu).FirstOrDefault();
                    if (dichVuKhachHang != null)
                    {
                        danhSachDichVuCuaSanPham.Remove(dichVuKhachHang);
                        dgvDichVuKhachHang.DataSource = null;
                        dgvDichVuKhachHang.DataSource = danhSachDichVuCuaSanPham;
                        dgvDichVuKhachHang.Refresh();
                        DinhDangDGV();
                        MessageBox.Show("Xoá dịch vụ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xoá dịch vụ thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }


        private void ThemXoaSua_SuaClicked(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show(
                "Bạn có muốn sửa dữ liệu này không?",        // Nội dung câu hỏi
                "Xác nhận sửa dữ liệu",                     // Tiêu đề hộp thoại
                MessageBoxButtons.YesNo,                     // Các nút Yes và No
                MessageBoxIcon.Question                     // Icon hình dấu hỏi
            );
            if (KiemTraDuLieuTextbox() == false)
            {
                return;
            }
            string maDichVu = txtMaDichVu.Text;
            string maSanPham = cboSanPham.SelectedValue.ToString();
            string moTa = txtMoTa.Text;
            decimal danhGiaHoTro = Convert.ToDecimal(txtDanhGiaHoTro.Text);
            int thoiGianBaoHanh = Convert.ToInt32(txtThoiGianBaoHanh.Text);
            decimal mucDoAnhHuong = Convert.ToDecimal(txtMucDoAnhHuong.Text);
            // Cập nhật dữ liệu từ textbox xuống dgv
            if (dgvDichVuKhachHang.CurrentRow != null && dgvDichVuKhachHang.CurrentRow.Cells["MaDichVu"].Value != null)
            {
                string maDichVuDangChon = dgvDichVuKhachHang.CurrentRow.Cells["MaDichVu"].Value.ToString();
                DichVuKhachHang dichVuKhachHang = danhSachDichVuCuaSanPham.Where(p => p.MaDichVu == maDichVuDangChon).FirstOrDefault();
                if (dichVuKhachHang != null)
                {
                    dichVuKhachHang.MaDichVu = maDichVu;
                    dichVuKhachHang.MaSanPham = maSanPham;
                    dichVuKhachHang.MoTa = moTa;
                    dichVuKhachHang.DanhGiaHoTro = danhGiaHoTro;
                    dichVuKhachHang.ThoiGianBaoHanh = thoiGianBaoHanh;
                    dichVuKhachHang.MucDoAnhHuong = mucDoAnhHuong;
                    dgvDichVuKhachHang.DataSource = null;
                    dgvDichVuKhachHang.DataSource = danhSachDichVuCuaSanPham;
                    dgvDichVuKhachHang.Refresh();
                    DinhDangDGV();
                    MessageBox.Show("Cập nhật dịch vụ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật dịch vụ thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ThemXoaSua_LuuClicked(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show("Bạn có muốn lưu dữ liệu này không?", "Xác nhận lưu dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DichVuKhachHangBLL dichVuKhachHangBLL = new DichVuKhachHangBLL();
                if (cboSanPham.SelectedValue != null)
                {
                    string maSanPham = cboSanPham.SelectedValue.ToString();
                    bool ketQuaCapNhat = dichVuKhachHangBLL.CapNhatDichVuKhachHangDuaTrenDanhSachDichVuKhachHang(danhSachDichVuCuaSanPham, maSanPham);
                    if (ketQuaCapNhat)
                    {
                        MessageBox.Show("Cập nhật dịch vụ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật dịch vụ thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void ThemXoaSua_HuyThemClicked(object sender, EventArgs e)
        {
            txtMaDichVu.Enabled = false;
        }
    }
}
