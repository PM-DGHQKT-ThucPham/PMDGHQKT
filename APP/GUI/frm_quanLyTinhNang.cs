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
    public partial class frm_quanLyTinhNang : Form
    {
        private List<TinhNangBoSung> danhSachDichVuCuaSanPham = new List<TinhNangBoSung>();
        public frm_quanLyTinhNang()
        {
            InitializeComponent();
            this.Load += Frm_quanLyDichVuKhachHang_Load;
            this.cboSanPham.SelectedIndexChanged += CboSanPham_SelectedIndexChanged;
            this.dgvTinhNangBoSung.SelectionChanged += DgvDichVuKhachHang_SelectionChanged;
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
            TinhNangBoSungBLL dichVuKhachHangBLL = new TinhNangBoSungBLL();
            List<TinhNangBoSung> lstDichVuKhachHang = dichVuKhachHangBLL.LayDanhSachTinhNangBoSung();
            dgvTinhNangBoSung.DataSource = lstDichVuKhachHang.Where(p => p.MaSanPham == maSP).ToList();
            danhSachDichVuCuaSanPham = lstDichVuKhachHang.Where(p => p.MaSanPham == maSP).ToList();

            // Định dạng các cột của dgvDichVuKhachHang
            DinhDangDGV();
        }

        private void DinhDangDGV()
        {
            // Đặt chế độ cho datagridview là fill
            dgvTinhNangBoSung.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Tiêu đề các cột sẽ căn giữa
            foreach (DataGridViewColumn column in dgvTinhNangBoSung.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Ẩn các cột không cần thiết
            dgvTinhNangBoSung.Columns["SanPham"].Visible = false;
            dgvTinhNangBoSung.Columns["MaSanPham"].Visible = false;

            // Đặt tên tiêu đề các cột
            dgvTinhNangBoSung.Columns["MaTinhNang"].HeaderText = "Mã tính năng";
            dgvTinhNangBoSung.Columns["MoTa"].HeaderText = "Mô tả";
            dgvTinhNangBoSung.Columns["DanhGiaCongNghe"].HeaderText = "Đánh giá công nghệ";
            dgvTinhNangBoSung.Columns["DanhGiaLinhHoat"].HeaderText = "Đánh giá linh hoạt";
            dgvTinhNangBoSung.Columns["MucDoAnhHuong"].HeaderText = "Mức độ ảnh hưởng";

            // Cột đánh giá hỗ trợ, thời gian bảo hành, mức độ ảnh hưởng căn lề phải
            dgvTinhNangBoSung.Columns["DanhGiaCongNghe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTinhNangBoSung.Columns["DanhGiaLinhHoat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTinhNangBoSung.Columns["MucDoAnhHuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Đặt chiều cao hàng tự động điều chỉnh theo nội dung
            dgvTinhNangBoSung.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;

            // Cột mô tả là cột cuối cùng
            dgvTinhNangBoSung.Columns["MoTa"].DisplayIndex = dgvTinhNangBoSung.Columns.Count - 1;

            // Cột mô tả tự động xuống dòng khi nội dung quá dài
            dgvTinhNangBoSung.Columns["MoTa"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Thiết lập tỉ lệ chiều rộng cho các cột
            dgvTinhNangBoSung.Columns["MaTinhNang"].FillWeight = 8;
            dgvTinhNangBoSung.Columns["DanhGiaCongNghe"].FillWeight = 8;
            dgvTinhNangBoSung.Columns["DanhGiaLinhHoat"].FillWeight = 8;
            dgvTinhNangBoSung.Columns["MucDoAnhHuong"].FillWeight = 8;
            dgvTinhNangBoSung.Columns["MoTa"].FillWeight = 78;
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
            txtMaTinhNang.Clear();
            txtMoTa.Clear();
            txtDanhGiaCongNghe.Clear();
            txtDanhGiaLinhHoat.Clear();
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
                if (dgvTinhNangBoSung.CurrentRow != null && dgvTinhNangBoSung.CurrentRow.Cells["MaTinhNang"].Value != null)
                {
                    // Lấy dữ liệu từ dòng được chọn
                    string maDichVu = dgvTinhNangBoSung.CurrentRow.Cells["MaTinhNang"].Value.ToString();
                    string moTa = dgvTinhNangBoSung.CurrentRow.Cells["MoTa"].Value.ToString();
                    string danhGiaHoTro = dgvTinhNangBoSung.CurrentRow.Cells["DanhGiaCongNghe"].Value.ToString();
                    string thoiGianBaoHanh = dgvTinhNangBoSung.CurrentRow.Cells["DanhGiaLinhHoat"].Value.ToString();
                    string mucDoAnhHuong = dgvTinhNangBoSung.CurrentRow.Cells["MucDoAnhHuong"].Value.ToString();

                    // Hiển thị dữ liệu lên các textbox
                    txtMaTinhNang.Text = maDichVu;
                    txtMoTa.Text = moTa;
                    txtDanhGiaCongNghe.Text = danhGiaHoTro;
                    txtDanhGiaLinhHoat.Text = thoiGianBaoHanh;
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


        private bool ThemDoiTuongVaoDataGridView(TinhNangBoSung dvkh)
        {
            try
            {
                // Kiểm tra mã dịch vụ đã tồn tại trong datagridview chưa
                foreach (DataGridViewRow row in dgvTinhNangBoSung.Rows)
                {
                    if (row.Cells["MaTinhNang"].Value != null &&
                        row.Cells["MaTinhNang"].Value.ToString().ToLower() == dvkh.MaTinhNang.ToLower())
                    {
                        MessageBox.Show("Mã đã tồn tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                // Kiểm tra mã đã tồn tại trong database chưa
                TinhNangBoSungBLL dichVuKhachHangBLL = new TinhNangBoSungBLL();
                List<TinhNangBoSung> danhSachDichVu = dichVuKhachHangBLL.LayDanhSachTinhNangBoSung();
                foreach (TinhNangBoSung dv in danhSachDichVu)
                {
                    if (dv.MaTinhNang.ToLower() == dvkh.MaTinhNang.ToLower())
                    {
                        MessageBox.Show("Mã đã tồn tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                // Thêm vào danh sách dịch vụ của sản phẩm
                danhSachDichVuCuaSanPham.Add(dvkh);
                dgvTinhNangBoSung.DataSource = null;
                dgvTinhNangBoSung.DataSource = danhSachDichVuCuaSanPham;
                dgvTinhNangBoSung.Refresh();
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
            if (txtMaTinhNang.Text.Length <= 0)
            {
                MessageBox.Show("Mã tính năng không được để trống");
                txtMaTinhNang.Focus();
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
            if (txtDanhGiaCongNghe.Text.Length <= 0)
            {
                MessageBox.Show("Đánh giá công nghệ không được để trống");
                txtDanhGiaCongNghe.Focus();
                return false;
            }
            if (!KiemTraTextBoxLaSo(txtDanhGiaCongNghe) || Convert.ToDecimal(txtDanhGiaCongNghe.Text) <= 0 || Convert.ToDecimal(txtDanhGiaCongNghe.Text) > 10)
            {
                MessageBox.Show("Đánh giá công nghệ phải lớn hơn 0 và nhỏ hơn 10");
                txtDanhGiaCongNghe.Focus();
                return false;
            }
            if (txtDanhGiaLinhHoat.Text.Length <= 0)
            {
                MessageBox.Show("Đánh giá linh hoạt không được để trống");
                txtDanhGiaLinhHoat.Focus();
                return false;
            }
            if (!KiemTraTextBoxLaSo(txtDanhGiaLinhHoat) || Convert.ToInt32(txtDanhGiaLinhHoat.Text) <= 0 || Convert.ToInt32(txtDanhGiaLinhHoat.Text) > 10)
            {
                MessageBox.Show("Đánh giá linh hoạt phải lớn hơn 0 và nhỏ hơn 10");
                txtDanhGiaLinhHoat.Focus();
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

        private TinhNangBoSung LayDichVuTuTextBox()
        {
            string maDichVu = txtMaTinhNang.Text;
            string maSanPham = cboSanPham.SelectedValue.ToString();
            string moTa = txtMoTa.Text;
            decimal danhGiaHoTro = Convert.ToDecimal(txtDanhGiaCongNghe.Text);
            int thoiGianBaoHanh = Convert.ToInt32(txtDanhGiaLinhHoat.Text);
            decimal mucDoAnhHuong = Convert.ToDecimal(txtMucDoAnhHuong.Text);
            // Thực hiện thêm vào datagridview ở đây
            TinhNangBoSung dvkh = new TinhNangBoSung();
            dvkh.MaTinhNang = maDichVu;
            dvkh.MaSanPham = maSanPham;
            dvkh.MoTa = moTa;
            dvkh.DanhGiaCongNghe = danhGiaHoTro;
            dvkh.DanhGiaLinhHoat = thoiGianBaoHanh;
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
                    TinhNangBoSung dvkh = LayDichVuTuTextBox();
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
                    txtMaTinhNang.Enabled = true;
                    dgvTinhNangBoSung.Refresh();
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
                    txtMaTinhNang.Enabled = true;
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
                if (dgvTinhNangBoSung.CurrentRow != null && dgvTinhNangBoSung.CurrentRow.Cells["MaTinhNang"].Value != null)
                {
                    string maDichVu = dgvTinhNangBoSung.CurrentRow.Cells["MaTinhNang"].Value.ToString();
                    // Xoá dịch vụ đang chọn trong dgv ra khỏi danhSachDichVuCuaSanPham
                    TinhNangBoSung dichVuKhachHang = danhSachDichVuCuaSanPham.Where(p => p.MaTinhNang == maDichVu).FirstOrDefault();
                    if (dichVuKhachHang != null)
                    {
                        danhSachDichVuCuaSanPham.Remove(dichVuKhachHang);
                        dgvTinhNangBoSung.DataSource = null;
                        dgvTinhNangBoSung.DataSource = danhSachDichVuCuaSanPham;
                        dgvTinhNangBoSung.Refresh();
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
            string maDichVu = txtMaTinhNang.Text;
            string maSanPham = cboSanPham.SelectedValue.ToString();
            string moTa = txtMoTa.Text;
            decimal danhGiaHoTro = Convert.ToDecimal(txtDanhGiaCongNghe.Text);
            int thoiGianBaoHanh = Convert.ToInt32(txtDanhGiaLinhHoat.Text);
            decimal mucDoAnhHuong = Convert.ToDecimal(txtMucDoAnhHuong.Text);
            // Cập nhật dữ liệu từ textbox xuống dgv
            if (dgvTinhNangBoSung.CurrentRow != null && dgvTinhNangBoSung.CurrentRow.Cells["MaTinhNang"].Value != null)
            {
                string maDichVuDangChon = dgvTinhNangBoSung.CurrentRow.Cells["MaTinhNang"].Value.ToString();
                TinhNangBoSung dichVuKhachHang = danhSachDichVuCuaSanPham.Where(p => p.MaTinhNang == maDichVuDangChon).FirstOrDefault();
                if (dichVuKhachHang != null)
                {
                    dichVuKhachHang.MaTinhNang = maDichVu;
                    dichVuKhachHang.MaSanPham = maSanPham;
                    dichVuKhachHang.MoTa = moTa;
                    dichVuKhachHang.DanhGiaCongNghe= danhGiaHoTro;
                    dichVuKhachHang.DanhGiaLinhHoat = thoiGianBaoHanh;
                    dichVuKhachHang.MucDoAnhHuong = mucDoAnhHuong;
                    dgvTinhNangBoSung.DataSource = null;
                    dgvTinhNangBoSung.DataSource = danhSachDichVuCuaSanPham;
                    dgvTinhNangBoSung.Refresh();
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
                TinhNangBoSungBLL dichVuKhachHangBLL = new TinhNangBoSungBLL();
                if (cboSanPham.SelectedValue != null)
                {
                    string maSanPham = cboSanPham.SelectedValue.ToString();
                    bool ketQuaCapNhat = dichVuKhachHangBLL.CapNhatTinhNangBoSungDuaTrenDanhSachTinhNang(danhSachDichVuCuaSanPham, maSanPham);
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
            txtMaTinhNang.Enabled = false;
        }
    }
}
