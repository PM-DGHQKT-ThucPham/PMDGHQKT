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
    public partial class frm_quanLyChatLuong : Form
    {
     private List<DoBen> danhSachDichVuCuaSanPham = new List<DoBen>();   
        public frm_quanLyChatLuong()
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
            DoBenBLL dichVuKhachHangBLL = new DoBenBLL();
            List<DoBen> lstDichVuKhachHang = dichVuKhachHangBLL.LayDanhSachDoBen();
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
            dgvDichVuKhachHang.Columns["MaDoBen"].HeaderText = "Mã độ bền";
            dgvDichVuKhachHang.Columns["MoTa"].HeaderText = "Mô tả";
            dgvDichVuKhachHang.Columns["TuoiThoNgay"].HeaderText = "Tuổi thọ ngày";
            dgvDichVuKhachHang.Columns["DanhGiaDoBen"].HeaderText = "Đánh giá độ bền";
            dgvDichVuKhachHang.Columns["MucDoAnhHuong"].HeaderText = "Mức độ ảnh hưởng";

            // Cột đánh giá hỗ trợ, thời gian bảo hành, mức độ ảnh hưởng căn lề phải
            dgvDichVuKhachHang.Columns["TuoiThoNgay"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDichVuKhachHang.Columns["DanhGiaDoBen"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDichVuKhachHang.Columns["MucDoAnhHuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Đặt chiều cao hàng tự động điều chỉnh theo nội dung
            dgvDichVuKhachHang.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;

            // Cột mô tả là cột cuối cùng
            dgvDichVuKhachHang.Columns["MoTa"].DisplayIndex = dgvDichVuKhachHang.Columns.Count - 1;

            // Cột mô tả tự động xuống dòng khi nội dung quá dài
            dgvDichVuKhachHang.Columns["MoTa"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Thiết lập tỉ lệ chiều rộng cho các cột
            dgvDichVuKhachHang.Columns["MaDoBen"].FillWeight = 8;
            dgvDichVuKhachHang.Columns["TuoiThoNgay"].FillWeight = 8;
            dgvDichVuKhachHang.Columns["DanhGiaDoBen"].FillWeight = 8;
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
            txtMaDoBen.Clear();
            txtMoTa.Clear();
            txtTuoiThoNgay.Clear();
            txtDanhGiaDoBen.Clear();
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
                if (dgvDichVuKhachHang.CurrentRow != null && dgvDichVuKhachHang.CurrentRow.Cells["MaDoBen"].Value != null)
                {
                    // Lấy dữ liệu từ dòng được chọn
                    string maDichVu = dgvDichVuKhachHang.CurrentRow.Cells["MaDoBen"].Value.ToString();
                    string moTa = dgvDichVuKhachHang.CurrentRow.Cells["MoTa"].Value.ToString();
                    string danhGiaHoTro = dgvDichVuKhachHang.CurrentRow.Cells["TuoiThoNgay"].Value.ToString();
                    string thoiGianBaoHanh = dgvDichVuKhachHang.CurrentRow.Cells["DanhGiaDoBen"].Value.ToString();
                    string mucDoAnhHuong = dgvDichVuKhachHang.CurrentRow.Cells["MucDoAnhHuong"].Value.ToString();

                    // Hiển thị dữ liệu lên các textbox
                    txtMaDoBen.Text = maDichVu;
                    txtMoTa.Text = moTa;
                    txtTuoiThoNgay.Text = danhGiaHoTro;
                    txtDanhGiaDoBen.Text = thoiGianBaoHanh;
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


        private bool ThemDoiTuongVaoDataGridView(DoBen dvkh)
        {
            try
            {
                // Kiểm tra mã đã tồn tại trong datagridview chưa
                foreach (DataGridViewRow row in dgvDichVuKhachHang.Rows)
                {
                    if (row.Cells["MaDoBen"].Value != null &&
                        row.Cells["MaDoBen"].Value.ToString().ToLower() == dvkh.MaDoBen.ToLower())
                    {
                        MessageBox.Show("Mã độ bền đã tồn tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                // Kiểm tra mã đã tồn tại trong database chưa
                DoBenBLL dichVuKhachHangBLL = new DoBenBLL();
                List<DoBen> danhSachDichVu = dichVuKhachHangBLL.LayDanhSachDoBen();
                foreach (DoBen dv in danhSachDichVu)
                {
                    if (dv.MaDoBen.ToLower() == dvkh.MaDoBen.ToLower())
                    {
                        MessageBox.Show("Mã độ bền đã tồn tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool KiemTraDuLieuTextbox()
        {
            if (txtMaDoBen.Text.Length <= 0)
            {
                MessageBox.Show("Mã độ bền không được để trống");
                txtMaDoBen.Focus();
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
            if (txtTuoiThoNgay.Text.Length <= 0)
            {
                MessageBox.Show("Tuổi thọ không được để trống");
                txtTuoiThoNgay.Focus();
                return false;
            }
            if (!KiemTraTextBoxLaSo(txtTuoiThoNgay) || Convert.ToDecimal(txtTuoiThoNgay.Text) <= 0 || Convert.ToDecimal(txtTuoiThoNgay.Text) > 730)
            {
                MessageBox.Show("Đánh giá hỗ trợ phải lớn hơn 0 và nhỏ hơn 730(2 năm)");
                txtTuoiThoNgay.Focus();
                return false;
            }
            if (txtDanhGiaDoBen.Text.Length <= 0)
            {
                MessageBox.Show("Đánh giá độ bền không được để trống");
                txtDanhGiaDoBen.Focus();
                return false;
            }
            if (!KiemTraTextBoxLaSo(txtDanhGiaDoBen) || Convert.ToInt32(txtDanhGiaDoBen.Text) <= 0 || Convert.ToInt32(txtDanhGiaDoBen.Text) > 10)
            {
                MessageBox.Show("Thời gian bảo hành phải lớn hơn 0 và nhỏ hơn 10");
                txtDanhGiaDoBen.Focus();
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

        private DoBen LayDichVuTuTextBox()
        {
            string maDichVu = txtMaDoBen.Text;
            string maSanPham = cboSanPham.SelectedValue.ToString();
            string moTa = txtMoTa.Text;
            decimal danhGiaHoTro = Convert.ToDecimal(txtTuoiThoNgay.Text);
            int thoiGianBaoHanh = Convert.ToInt32(txtDanhGiaDoBen.Text);
            decimal mucDoAnhHuong = Convert.ToDecimal(txtMucDoAnhHuong.Text);
            // Thực hiện thêm vào datagridview ở đây
            DoBen dvkh = new DoBen();
            dvkh.MaDoBen = maDichVu;
            dvkh.MaSanPham = maSanPham;
            dvkh.MoTa = moTa;
            dvkh.TuoiThoNgay = danhGiaHoTro;
            dvkh.DanhGiaDoBen = thoiGianBaoHanh;
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
                    DoBen dvkh = LayDichVuTuTextBox();
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
                    txtMaDoBen.Enabled = true;
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
                    txtMaDoBen.Enabled = true;
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
                if (dgvDichVuKhachHang.CurrentRow != null && dgvDichVuKhachHang.CurrentRow.Cells["MaDoBen"].Value != null)
                {
                    string maDichVu = dgvDichVuKhachHang.CurrentRow.Cells["MaDoBen"].Value.ToString();
                    // Xoá dịch vụ đang chọn trong dgv ra khỏi danhSachDichVuCuaSanPham
                    DoBen dichVuKhachHang = danhSachDichVuCuaSanPham.Where(p => p.MaDoBen == maDichVu).FirstOrDefault();
                    if (dichVuKhachHang != null)
                    {
                        danhSachDichVuCuaSanPham.Remove(dichVuKhachHang);
                        dgvDichVuKhachHang.DataSource = null;
                        dgvDichVuKhachHang.DataSource = danhSachDichVuCuaSanPham;
                        dgvDichVuKhachHang.Refresh();
                        DinhDangDGV();
                        MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xoá thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string maDichVu = txtMaDoBen.Text;
            string maSanPham = cboSanPham.SelectedValue.ToString();
            string moTa = txtMoTa.Text;
            decimal danhGiaHoTro = Convert.ToDecimal(txtTuoiThoNgay.Text);
            int thoiGianBaoHanh = Convert.ToInt32(txtDanhGiaDoBen.Text);
            decimal mucDoAnhHuong = Convert.ToDecimal(txtMucDoAnhHuong.Text);
            // Cập nhật dữ liệu từ textbox xuống dgv
            if (dgvDichVuKhachHang.CurrentRow != null && dgvDichVuKhachHang.CurrentRow.Cells["MaDichVu"].Value != null)
            {
                string maDichVuDangChon = dgvDichVuKhachHang.CurrentRow.Cells["MaDoBen"].Value.ToString();
                DoBen dichVuKhachHang = danhSachDichVuCuaSanPham.Where(p => p.MaDoBen == maDichVuDangChon).FirstOrDefault();
                if (dichVuKhachHang != null)
                {
                    dichVuKhachHang.MaDoBen = maDichVu;
                    dichVuKhachHang.MaSanPham = maSanPham;
                    dichVuKhachHang.MoTa = moTa;
                    dichVuKhachHang.TuoiThoNgay = danhGiaHoTro;
                    dichVuKhachHang.DanhGiaDoBen = thoiGianBaoHanh;
                    dichVuKhachHang.MucDoAnhHuong = mucDoAnhHuong;
                    dgvDichVuKhachHang.DataSource = null;
                    dgvDichVuKhachHang.DataSource = danhSachDichVuCuaSanPham;
                    dgvDichVuKhachHang.Refresh();
                    DinhDangDGV();
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ThemXoaSua_LuuClicked(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show("Bạn có muốn lưu dữ liệu này không?", "Xác nhận lưu dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DoBenBLL dichVuKhachHangBLL = new DoBenBLL();
                if (cboSanPham.SelectedValue != null)
                {
                    string maSanPham = cboSanPham.SelectedValue.ToString();
                    bool ketQuaCapNhat = dichVuKhachHangBLL.CapNhatDoBenDuaTrenDanhSach(danhSachDichVuCuaSanPham, maSanPham);
                    if (ketQuaCapNhat)
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void ThemXoaSua_HuyThemClicked(object sender, EventArgs e)
        {
            txtMaDoBen.Enabled = false;
        }
    }
}
