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
    public partial class frm_quanLyBenVung : Form
    {
        private List<BenVung> danhSachDichVuCuaSanPham = new List<BenVung>();
        public frm_quanLyBenVung()
        {
            InitializeComponent();
            this.Load += Frm_quanLyDichVuKhachHang_Load;
            this.cboSanPham.SelectedIndexChanged += CboSanPham_SelectedIndexChanged;
            this.dgvBenVung.SelectionChanged += DgvDichVuKhachHang_SelectionChanged;
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
            BenVungBLL dichVuKhachHangBLL = new BenVungBLL();
            List<BenVung> lstDichVuKhachHang = dichVuKhachHangBLL.LayDanhSachBenVung();
            dgvBenVung.DataSource = lstDichVuKhachHang.Where(p => p.MaSanPham == maSP).ToList();
            danhSachDichVuCuaSanPham = lstDichVuKhachHang.Where(p => p.MaSanPham == maSP).ToList();

            // Định dạng các cột của dgvDichVuKhachHang
            DinhDangDGV();
        }

        private void DinhDangDGV()
        {
            // Đặt chế độ cho datagridview là fill
            dgvBenVung.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Tiêu đề các cột sẽ căn giữa
            foreach (DataGridViewColumn column in dgvBenVung.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Ẩn các cột không cần thiết
            dgvBenVung.Columns["SanPham"].Visible = false;
            dgvBenVung.Columns["MaSanPham"].Visible = false;

            // Đặt tên tiêu đề các cột
            dgvBenVung.Columns["MaBenVung"].HeaderText = "Mã bền vững";
            dgvBenVung.Columns["MoTa"].HeaderText = "Mô tả";
            dgvBenVung.Columns["DanhGiaAnhHuongMoiTruong"].HeaderText = "Đánh giá ảnh hưởng môi trường";
            dgvBenVung.Columns["DanhGiaAnToan"].HeaderText = "Đánh giá an toàn";
            dgvBenVung.Columns["MucDoAnhHuong"].HeaderText = "Mức độ ảnh hưởng";

            // Cột đánh giá hỗ trợ, thời gian bảo hành, mức độ ảnh hưởng căn lề phải
            dgvBenVung.Columns["DanhGiaAnhHuongMoiTruong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvBenVung.Columns["DanhGiaAnToan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvBenVung.Columns["MucDoAnhHuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Đặt chiều cao hàng tự động điều chỉnh theo nội dung
            dgvBenVung.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;

            // Cột mô tả là cột cuối cùng
            dgvBenVung.Columns["MoTa"].DisplayIndex = dgvBenVung.Columns.Count - 1;

            // Cột mô tả tự động xuống dòng khi nội dung quá dài
            dgvBenVung.Columns["MoTa"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Thiết lập tỉ lệ chiều rộng cho các cột
            dgvBenVung.Columns["MaBenVung"].FillWeight = 8;
            dgvBenVung.Columns["DanhGiaAnhHuongMoiTruong"].FillWeight = 8;
            dgvBenVung.Columns["DanhGiaAnToan"].FillWeight = 8;
            dgvBenVung.Columns["MucDoAnhHuong"].FillWeight = 8;
            dgvBenVung.Columns["MoTa"].FillWeight = 78;
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
            txtMaBenVung.Clear();
            txtMoTa.Clear();
            txtDanhGIaAnhHuongMoiTruong.Clear();
            txtDanhGiaAnToan.Clear();
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
                if (dgvBenVung.CurrentRow != null && dgvBenVung.CurrentRow.Cells["MaBenVung"].Value != null)
                {
                    // Lấy dữ liệu từ dòng được chọn
                    string maDichVu = dgvBenVung.CurrentRow.Cells["MaBenVung"].Value.ToString();
                    string moTa = dgvBenVung.CurrentRow.Cells["MoTa"].Value.ToString();
                    string danhGiaHoTro = dgvBenVung.CurrentRow.Cells["DanhGiaAnhHuongMoiTruong"].Value.ToString();
                    string thoiGianBaoHanh = dgvBenVung.CurrentRow.Cells["DanhGiaAnToan"].Value.ToString();
                    string mucDoAnhHuong = dgvBenVung.CurrentRow.Cells["MucDoAnhHuong"].Value.ToString();

                    // Hiển thị dữ liệu lên các textbox
                    txtMaBenVung.Text = maDichVu;
                    txtMoTa.Text = moTa;
                    txtDanhGIaAnhHuongMoiTruong.Text = danhGiaHoTro;
                    txtDanhGiaAnToan.Text = thoiGianBaoHanh;
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


        private bool ThemDoiTuongVaoDataGridView(BenVung dvkh)
        {
            try
            {
                // Kiểm tra mã dịch vụ đã tồn tại trong datagridview chưa
                foreach (DataGridViewRow row in dgvBenVung.Rows)
                {
                    if (row.Cells["MaBenVung"].Value != null &&
                        row.Cells["MaBenVung"].Value.ToString().ToLower() == dvkh.MaBenVung.ToLower())
                    {
                        MessageBox.Show("Mã đã tồn tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                // Kiểm tra mã đã tồn tại trong database chưa
                BenVungBLL dichVuKhachHangBLL = new BenVungBLL();
                List<BenVung> danhSachDichVu = dichVuKhachHangBLL.LayDanhSachBenVung();
                foreach (BenVung dv in danhSachDichVu)
                {
                    if (dv.MaBenVung.ToLower() == dvkh.MaBenVung.ToLower())
                    {
                        MessageBox.Show("Mã đã tồn tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                // Thêm vào danh sách dịch vụ của sản phẩm
                danhSachDichVuCuaSanPham.Add(dvkh);
                dgvBenVung.DataSource = null;
                dgvBenVung.DataSource = danhSachDichVuCuaSanPham;
                dgvBenVung.Refresh();
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
            if (txtMaBenVung.Text.Length <= 0)
            {
                MessageBox.Show("Mã bền vững không được để trống");
                txtMaBenVung.Focus();
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
            if (txtDanhGIaAnhHuongMoiTruong.Text.Length <= 0)
            {
                MessageBox.Show("Đánh giá ảnh hưởng môi trường không được để trống");
                txtDanhGIaAnhHuongMoiTruong.Focus();
                return false;
            }
            if (!KiemTraTextBoxLaSo(txtDanhGIaAnhHuongMoiTruong) || Convert.ToDecimal(txtDanhGIaAnhHuongMoiTruong.Text) <= 0 || Convert.ToDecimal(txtDanhGIaAnhHuongMoiTruong.Text) > 10)
            {
                MessageBox.Show("Đánh giá ảnh hưởng môi trường phải lớn hơn 0 và nhỏ hơn 10");
                txtDanhGIaAnhHuongMoiTruong.Focus();
                return false;
            }
            if (txtDanhGiaAnToan.Text.Length <= 0)
            {
                MessageBox.Show("Đánh giá an toàn không được để trống");
                txtDanhGiaAnToan.Focus();
                return false;
            }
            if (!KiemTraTextBoxLaSo(txtDanhGiaAnToan) || Convert.ToInt32(txtDanhGiaAnToan.Text) <= 0 || Convert.ToInt32(txtDanhGiaAnToan.Text) > 12)
            {
                MessageBox.Show("Đánh giá an toàn phải lớn hơn 0 và nhỏ hơn 12");
                txtDanhGiaAnToan.Focus();
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

        private BenVung LayDichVuTuTextBox()
        {
            string maDichVu = txtMaBenVung.Text;
            string maSanPham = cboSanPham.SelectedValue.ToString();
            string moTa = txtMoTa.Text;
            decimal danhGiaHoTro = Convert.ToDecimal(txtDanhGIaAnhHuongMoiTruong.Text);
            int thoiGianBaoHanh = Convert.ToInt32(txtDanhGiaAnToan.Text);
            decimal mucDoAnhHuong = Convert.ToDecimal(txtMucDoAnhHuong.Text);
            // Thực hiện thêm vào datagridview ở đây
            BenVung dvkh = new BenVung();
            dvkh.MaBenVung = maDichVu;
            dvkh.MaSanPham = maSanPham;
            dvkh.MoTa = moTa;
            dvkh.DanhGiaAnhHuongMoiTruong = danhGiaHoTro;
            dvkh.DanhGiaAnToan = thoiGianBaoHanh;
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
                    BenVung dvkh = LayDichVuTuTextBox();
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
                    txtMaBenVung.Enabled = true;
                    dgvBenVung.Refresh();
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
                    txtMaBenVung.Enabled = true;
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
                if (dgvBenVung.CurrentRow != null && dgvBenVung.CurrentRow.Cells["MaBenVung"].Value != null)
                {
                    string maDichVu = dgvBenVung.CurrentRow.Cells["MaBenVung"].Value.ToString();
                    // Xoá dịch vụ đang chọn trong dgv ra khỏi danhSachDichVuCuaSanPham
                    BenVung dichVuKhachHang = danhSachDichVuCuaSanPham.Where(p => p.MaBenVung == maDichVu).FirstOrDefault();
                    if (dichVuKhachHang != null)
                    {
                        danhSachDichVuCuaSanPham.Remove(dichVuKhachHang);
                        dgvBenVung.DataSource = null;
                        dgvBenVung.DataSource = danhSachDichVuCuaSanPham;
                        dgvBenVung.Refresh();
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
            string maDichVu = txtMaBenVung.Text;
            string maSanPham = cboSanPham.SelectedValue.ToString();
            string moTa = txtMoTa.Text;
            decimal danhGiaHoTro = Convert.ToDecimal(txtDanhGIaAnhHuongMoiTruong.Text);
            int thoiGianBaoHanh = Convert.ToInt32(txtDanhGiaAnToan.Text);
            decimal mucDoAnhHuong = Convert.ToDecimal(txtMucDoAnhHuong.Text);
            // Cập nhật dữ liệu từ textbox xuống dgv
            if (dgvBenVung.CurrentRow != null && dgvBenVung.CurrentRow.Cells["MaBenVung"].Value != null)
            {
                string maDichVuDangChon = dgvBenVung.CurrentRow.Cells["MaBenVung"].Value.ToString();
                BenVung dichVuKhachHang = danhSachDichVuCuaSanPham.Where(p => p.MaBenVung == maDichVuDangChon).FirstOrDefault();
                if (dichVuKhachHang != null)
                {
                    dichVuKhachHang.MaBenVung = maDichVu;
                    dichVuKhachHang.MaSanPham = maSanPham;
                    dichVuKhachHang.MoTa = moTa;
                    dichVuKhachHang.DanhGiaAnhHuongMoiTruong = danhGiaHoTro;
                    dichVuKhachHang.DanhGiaAnToan = thoiGianBaoHanh;
                    dichVuKhachHang.MucDoAnhHuong = mucDoAnhHuong;
                    dgvBenVung.DataSource = null;
                    dgvBenVung.DataSource = danhSachDichVuCuaSanPham;
                    dgvBenVung.Refresh();
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
                BenVungBLL dichVuKhachHangBLL = new BenVungBLL();
                if (cboSanPham.SelectedValue != null)
                {
                    string maSanPham = cboSanPham.SelectedValue.ToString();
                    bool ketQuaCapNhat = dichVuKhachHangBLL.CapNhatBenVungDuaTrenDanhSachBenVung(danhSachDichVuCuaSanPham, maSanPham);
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
            txtMaBenVung.Enabled = false;
        }
    }
}
