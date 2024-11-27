using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UC;

namespace GUI
{
    public partial class frm_quanLyChiPhi : Form
    {
        LoaiChiPhiBLL _loaiChiPhiBLL = new LoaiChiPhiBLL();
        ChiPhiBLL _chiPhiBLL = new ChiPhiBLL();
        List<LoaiChiPhi> _lstLoaiChiPhi = new List<LoaiChiPhi>();
        List<ChiPhi> _lstChiPhi = new List<ChiPhi>();
        string maSanPham = "SP001";
        ThemXoaSua t = new ThemXoaSua();
        private BindingList<LoaiChiPhi> _bindingListLoaiChiPhi;
        private BindingList<ChiPhi> _bindingListChiPhi;
        public frm_quanLyChiPhi()
        {
            InitializeComponent();
            this.Load += Frm_quanLyChiPhi_Load;
        }

        private void Frm_quanLyChiPhi_Load(object sender, EventArgs e)
        {
            HienThiLoaiChiPhi();
            dgv_dsLoaiChiPhi.SelectionChanged += Dgv_dsLoaiChiPhi_SelectionChanged;
            dgv_dsChiPhi.SelectionChanged += Dgv_dsChiPhi_SelectionChanged;
            cbo_sanPham.DropDownStyle=ComboBoxStyle.DropDownList;
            themXoaSuaChiPhi.ThemClicked += ThemXoaSuaChiPhi_ThemClicked;
            themXoaSuaChiPhi.HuyThemClicked += ThemXoaSuaChiPhi_HuyThemClicked;
            themXoaSuaChiPhi.XoaClicked += ThemXoaSuaChiPhi_XoaClicked;
            themXoaSuaChiPhi.SuaClicked += ThemXoaSuaChiPhi_SuaClicked;
            themXoaSuaChiPhi.LuuClicked += ThemXoaSuaChiPhi_LuuClicked;
            btn_clear.Click += Btn_clear_Click;
            // Cấu hình DataGridView
            dgv_dsLoaiChiPhi.AllowUserToAddRows = true;
            themXoaSuaCP.ThemClicked += ThemXoaSuaCP_ThemClicked;
            themXoaSuaCP.XoaClicked += ThemXoaSuaCP_XoaClicked;
            themXoaSuaCP.SuaClicked += ThemXoaSuaCP_SuaClicked;
            themXoaSuaCP.LuuClicked += ThemXoaSuaCP_LuuClicked;
            themXoaSuaCP.HuyThemClicked += ThemXoaSuaCP_HuyThemClicked;
            LoadDataComboboxLoaiChiPhi();
            btn_khoiPhuc.Click += Btn_khoiPhuc_Click;

        }

        private void Btn_khoiPhuc_Click(object sender, EventArgs e)
        {
            HienThiLoaiChiPhi();
        }

        private void ThemXoaSuaCP_HuyThemClicked(object sender, EventArgs e)
        {
            try
            {
                // Khôi phục giao diện
                txt_maChiPhi.Enabled = false;
                BatDataBindingDataGridViewChiPhi();
                dgv_dsChiPhi.SelectionChanged += Dgv_dsChiPhi_SelectionChanged;

                // Điều chỉnh trạng thái nút
                themXoaSuaCP.BtnSua.Enabled = true;
                themXoaSuaCP.BtnXoa.Enabled = true;
                themXoaSuaCP.BtnLuu.Enabled = true;
                themXoaSuaCP.BtnHuyThem.Enabled = false;

                // Đổi biểu tượng nút "Thêm" và "Sửa" về trạng thái ban đầu
                themXoaSuaCP.BtnThem.Image = Properties.Resources.icons8_add_35;

                MessageBox.Show("Hủy thao tác thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hủy thêm: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ThemXoaSuaCP_LuuClicked(object sender, EventArgs e)
        {
            try
            {
                // Xác nhận lưu thay đổi
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn lưu tất cả thay đổi?",
                                                    "Xác nhận lưu",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    string maLoai = dgv_dsLoaiChiPhi.CurrentRow.Cells["MaLoaiChiPhi"].Value.ToString();
                    // Lưu danh sách chi phí xuống cơ sở dữ liệu
                    var danhSachChiPhi = _bindingListChiPhi.ToList();
                    bool ketQua = _chiPhiBLL.CapNhatThemXoaSuaChiPhi(danhSachChiPhi,maLoai);
                    if (ketQua)
                    {
                        MessageBox.Show("Lưu thay đổi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HienThiChiPhi(maLoai);
                    }
                    else
                    {
                        MessageBox.Show("Lưu thay đổi thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu chi phí: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ThemXoaSuaCP_SuaClicked(object sender, EventArgs e)
        {
            try
            {
                if (dgv_dsChiPhi.CurrentRow != null)
                {
                    var row = dgv_dsChiPhi.CurrentRow;

                    // Lấy dữ liệu mới từ giao diện
                    if (string.IsNullOrEmpty(txt_moTaChiPhi.Text) || string.IsNullOrEmpty(txt_soTien.Text))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!decimal.TryParse(txt_soTien.Text, out decimal soTien))
                    {
                        MessageBox.Show("Số tiền phải là một giá trị hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (cbo_loaiChiPhi.SelectedValue == null)
                    {
                        MessageBox.Show("Vui lòng chọn một loại chi phí hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Cập nhật dữ liệu vào DataGridView
                    row.Cells["MoTa"].Value = txt_moTaChiPhi.Text;
                    row.Cells["SoTien"].Value = soTien;
                    row.Cells["ThoiGian"].Value = dtp_thoiGian.Value;
                    row.Cells["MaLoaiChiPhi"].Value = cbo_loaiChiPhi.SelectedValue.ToString();

                    // Làm mới DataGridView
                    dgv_dsChiPhi.Refresh();

                    MessageBox.Show("Sửa chi phí thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Khôi phục trạng thái ban đầu
                    txt_maChiPhi.Enabled = false;
                    themXoaSuaCP.BtnThem.Enabled = true;
                    themXoaSuaCP.BtnXoa.Enabled = true;
                    themXoaSuaCP.BtnLuu.Enabled = true;
                    themXoaSuaCP.BtnHuyThem.Enabled = false;

                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một chi phí để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa chi phí: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ThemXoaSuaCP_XoaClicked(object sender, EventArgs e)
        {
            try
            {
                if (dgv_dsChiPhi.CurrentRow != null)
                {
                    // Lấy dòng được chọn
                    var row = dgv_dsChiPhi.CurrentRow;
                    string maChiPhi = row.Cells["MaChiPhi"].Value?.ToString();

                    // Xác nhận xóa
                    var confirmResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa chi phí có mã: {maChiPhi}?",
                                                        "Xác nhận xóa",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        // Xóa khỏi BindingList
                        _bindingListChiPhi.RemoveAt(row.Index);
                        dgv_dsChiPhi.Refresh();

                        MessageBox.Show("Xóa chi phí thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một chi phí để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa chi phí: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ThemXoaSuaCP_ThemClicked(object sender, EventArgs e)
        {
            try
            {
                // Nếu nút Hủy Thêm đang ẩn, bật chế độ thêm mới
                if (!themXoaSuaCP.BtnHuyThem.Enabled)
                {
                    // Bật các TextBox để nhập liệu
                    TatBatTextBoxChiPhi(true);

                    // Xóa sạch TextBox để chuẩn bị thêm mới
                    XoaTextBoxChiPhi();

                    // Tắt binding và sự kiện SelectionChanged
                    TatDataBindingDataGridViewChiPhi();
                    dgv_dsChiPhi.SelectionChanged -= Dgv_dsChiPhi_SelectionChanged;

                    // Điều chỉnh trạng thái nút
                    themXoaSuaCP.BtnSua.Enabled = false;
                    themXoaSuaCP.BtnXoa.Enabled = false;
                    themXoaSuaCP.BtnLuu.Enabled = false;
                    themXoaSuaCP.BtnHuyThem.Enabled = true;

                    // Đổi biểu tượng nút "Thêm" thành xác nhận
                    themXoaSuaCP.BtnThem.Image = Properties.Resources.icons8_tick_35;
                }
                else
                {
                    // Kiểm tra rỗng
                    if (KiemTraRongTextBoxChiPhi())
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin chi phí!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Lấy chi phí từ giao diện
                    ChiPhi chiPhi = LayChiPhiTuGiaoDien();
                    if (chiPhi == null) return;

                    // Kiểm tra trùng mã chi phí
                    if (_bindingListChiPhi.Any(c => c.MaChiPhi == chiPhi.MaChiPhi))
                    {
                        MessageBox.Show("Mã chi phí đã tồn tại! Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Thêm chi phí vào BindingList
                    _bindingListChiPhi.Add(chiPhi);
                    dgv_dsChiPhi.Refresh();

                    // Khôi phục giao diện
                    TatBatTextBoxChiPhi(false);
                    BatDataBindingDataGridViewChiPhi();
                    dgv_dsChiPhi.SelectionChanged += Dgv_dsChiPhi_SelectionChanged;

                    // Điều chỉnh trạng thái nút
                    themXoaSuaCP.BtnSua.Enabled = true;
                    themXoaSuaCP.BtnXoa.Enabled = true;
                    themXoaSuaCP.BtnLuu.Enabled = true;
                    themXoaSuaCP.BtnHuyThem.Enabled = false;

                    // Đổi biểu tượng nút "Thêm" về trạng thái ban đầu
                    themXoaSuaCP.BtnThem.Image = Properties.Resources.icons8_add_35;

                    MessageBox.Show("Thêm chi phí thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm chi phí: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ThemXoaSuaChiPhi_LuuClicked(object sender, EventArgs e)
        {
            try
            {
                // Lưu Loại Chi Phí
                var danhSachLoaiChiPhi = _bindingListLoaiChiPhi.ToList();
                _loaiChiPhiBLL.CapNhatThemXoaSua(danhSachLoaiChiPhi);

                // Lưu Chi Phí
                MessageBox.Show("Lưu thành công tất cả thay đổi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiLoaiChiPhi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ThemXoaSuaChiPhi_SuaClicked(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn trong DataGridView không
                if (dgv_dsLoaiChiPhi.CurrentRow != null)
                {
                    // Lấy dòng hiện tại
                    var row = dgv_dsLoaiChiPhi.CurrentRow;

                    // Hiển thị các TextBox và cho phép người dùng sửa
                    txt_maLoaiChiPhi.Enabled = false; // Mã loại chi phí không được sửa
                    txt_tenLoaiChiPhi.Enabled = true;
                    txt_moTaLoaiChiPhi.Enabled = true;
                    txt_tongTien.Enabled = true;

                    // Gắn dữ liệu dòng hiện tại vào TextBox để chỉnh sửa
                    txt_maLoaiChiPhi.Text = row.Cells["MaLoaiChiPhi"].Value?.ToString();
                    txt_tenLoaiChiPhi.Text = row.Cells["TenLoaiChiPhi"].Value?.ToString();
                    txt_moTaLoaiChiPhi.Text = row.Cells["MoTa"].Value?.ToString();
                    txt_tongTien.Text = row.Cells["TongTien"].Value?.ToString();

                    // Kiểm tra các điều kiện khi người dùng nhấn nút sửa lần thứ hai
                    if (!KiemTraRongTextBoxLoaiChiPhi()) // Kiểm tra không rỗng
                    {
                        // Cập nhật giá trị từ TextBox vào dòng
                        row.Cells["TenLoaiChiPhi"].Value = txt_tenLoaiChiPhi.Text;
                        row.Cells["MoTa"].Value = txt_moTaLoaiChiPhi.Text;

                        if (decimal.TryParse(txt_tongTien.Text, out decimal tongTien))
                        {
                            row.Cells["TongTien"].Value = tongTien;
                        }
                        else
                        {
                            MessageBox.Show("Tổng tiền phải là số hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }


                        // Kích hoạt lại các nút
                        themXoaSuaChiPhi.BtnThem.Enabled = true;
                        themXoaSuaChiPhi.BtnXoa.Enabled = true;
                        themXoaSuaChiPhi.BtnLuu.Enabled = true;
                        themXoaSuaChiPhi.BtnHuyThem.Enabled = false;
                        MessageBox.Show("Sửa loại chi phí thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgv_dsLoaiChiPhi.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một loại chi phí để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa loại chi phí: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ThemXoaSuaChiPhi_XoaClicked(object sender, EventArgs e)
        {
            try
            {
                if (dgv_dsLoaiChiPhi.CurrentRow != null)
                {
                    // Lấy loại chi phí hiện tại
                    var row = dgv_dsLoaiChiPhi.CurrentRow;
                    string maLoaiChiPhi = row.Cells["MaLoaiChiPhi"].Value?.ToString();

                    if (string.IsNullOrEmpty(maLoaiChiPhi))
                    {
                        MessageBox.Show("Dữ liệu không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Kiểm tra chi phí liên quan
                    var danhSachChiPhi = _chiPhiBLL.LayChiPhiTheoMaLoaiChiPhi(maLoaiChiPhi, maSanPham);
                    if (danhSachChiPhi != null && danhSachChiPhi.Count > 0)
                    {
                        MessageBox.Show("Không thể xóa loại chi phí này vì có chi phí liên quan!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Xóa loại chi phí
                    _bindingListLoaiChiPhi.RemoveAt(row.Index);
                    MessageBox.Show("Xóa loại chi phí thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một loại chi phí để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ThemXoaSuaChiPhi_HuyThemClicked(object sender, EventArgs e)
        {
            try
            {
                txt_maLoaiChiPhi.Enabled = false;
                BatDataBindingDataGridViewLoaiChiPhi();
                dgv_dsLoaiChiPhi.SelectionChanged += Dgv_dsLoaiChiPhi_SelectionChanged;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ThemXoaSuaChiPhi_ThemClicked(object sender, EventArgs e)
        {
            try
            {
                // Nếu nút "Hủy Thêm" đang ẩn, nghĩa là đây là lần đầu nhấn nút "Thêm"
                if (!themXoaSuaChiPhi.BtnHuyThem.Enabled)
                {
                    // Bật chế độ nhập liệu
                    TatBatTextBox(true);

                    // Tắt binding và sự kiện SelectionChanged
                    TatDataBindingDataGridViewLoaiChiPhi();
                    dgv_dsLoaiChiPhi.SelectionChanged -= Dgv_dsLoaiChiPhi_SelectionChanged;

                    // Xóa các trường nhập liệu
                    XoaTextBoxLoaiChiPhi();

                    // Thay đổi trạng thái của các nút
                    themXoaSuaChiPhi.BtnXoa.Enabled = false;
                    themXoaSuaChiPhi.BtnSua.Enabled = false;
                    themXoaSuaChiPhi.BtnLuu.Enabled = false;
                    themXoaSuaChiPhi.BtnHuyThem.Enabled = true;

                    // Đổi biểu tượng nút "Thêm" thành dấu tick (xác nhận)
                    themXoaSuaChiPhi.BtnThem.Image = Properties.Resources.icons8_tick_35;

                    MessageBox.Show("Sẵn sàng để thêm loại chi phí mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // Khi nút "Hủy Thêm" đang hiện, nghĩa là đang chờ xác nhận thêm
                {
                    // Kiểm tra dữ liệu nhập liệu
                    if (!KiemTraRongTextBoxLoaiChiPhi())
                    {
                        // Lấy loại chi phí từ các TextBox
                        LoaiChiPhi loaiChiPhi = new LoaiChiPhi
                        {
                            MaLoaiChiPhi = txt_maLoaiChiPhi.Text,
                            TenLoaiChiPhi = txt_tenLoaiChiPhi.Text,
                            MoTa = txt_moTaLoaiChiPhi.Text,
                            TongTien = decimal.TryParse(txt_tongTien.Text, out decimal tongTien) ? tongTien : 0,
                            MaSanPham = maSanPham
                        };

                        // Kiểm tra trùng mã loại chi phí
                        if (_bindingListLoaiChiPhi.Any(l => l.MaLoaiChiPhi.Equals(loaiChiPhi.MaLoaiChiPhi, StringComparison.OrdinalIgnoreCase)))
                        {
                            MessageBox.Show("Mã loại chi phí đã tồn tại! Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txt_maLoaiChiPhi.Focus();
                            return;
                        }

                        // Thêm loại chi phí vào BindingList
                        _bindingListLoaiChiPhi.Add(loaiChiPhi);
                        dgv_dsLoaiChiPhi.Refresh();

                        // Khôi phục trạng thái ban đầu của giao diện
                        txt_maLoaiChiPhi.Enabled = false;

                        BatDataBindingDataGridViewLoaiChiPhi();
                        dgv_dsLoaiChiPhi.SelectionChanged += Dgv_dsLoaiChiPhi_SelectionChanged;

                        // Kích hoạt lại các nút
                        themXoaSuaChiPhi.BtnXoa.Enabled = true;
                        themXoaSuaChiPhi.BtnSua.Enabled = true;
                        themXoaSuaChiPhi.BtnLuu.Enabled = true;
                        themXoaSuaChiPhi.BtnHuyThem.Enabled = false;

                        // Đổi biểu tượng nút "Thêm" về trạng thái ban đầu
                        themXoaSuaChiPhi.BtnThem.Image = Properties.Resources.icons8_add_35;

                        MessageBox.Show("Thêm loại chi phí mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm loại chi phí: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Frm_quanLyKhoHang_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDanhSachLoaiChiPhi();
                txt_maLoaiChiPhi.Enabled = false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void Btn_clear_Click(object sender, EventArgs e)
        {
            // Kích hoạt chế độ nhập liệu
            txt_maLoaiChiPhi.Enabled = true; // Mã chi phí
            txt_tenLoaiChiPhi.Enabled = true; // Tên chi phí
            txt_moTaLoaiChiPhi.Enabled = true; // Mô tả
            txt_tongTien.Enabled = true; // Số tiền
            txt_maLoaiChiPhi.Text = string.Empty;
            txt_tenLoaiChiPhi.Text = string.Empty;
            txt_tongTien.Text = string.Empty;
            txt_moTaLoaiChiPhi.Text = string.Empty;
        }

        private void Dgv_dsChiPhi_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị dòng đang chọn lên TextBox
                if (dgv_dsChiPhi.CurrentRow != null)
                {
                    // Lấy thông tin từ dòng hiện tại
                    txt_maChiPhi.Text = dgv_dsChiPhi.CurrentRow.Cells["MaChiPhi"].Value?.ToString();
                    txt_moTaChiPhi.Text = dgv_dsChiPhi.CurrentRow.Cells["MoTa"].Value?.ToString();
                    txt_soTien.Text = dgv_dsChiPhi.CurrentRow.Cells["SoTien"].Value?.ToString();

                    if (DateTime.TryParse(dgv_dsChiPhi.CurrentRow.Cells["ThoiGian"].Value?.ToString(), out DateTime thoiGian))
                    {
                        dtp_thoiGian.Value = thoiGian;
                    }

                    string maLoaiChiPhi = dgv_dsChiPhi.CurrentRow.Cells["MaLoaiChiPhi"].Value?.ToString();

                    // Tìm và hiển thị tên loại chi phí trong ComboBox
                    if (!string.IsNullOrEmpty(maLoaiChiPhi))
                    {
                        // Gán giá trị SelectedValue cho ComboBox
                        cbo_loaiChiPhi.SelectedValue = maLoaiChiPhi;

                        // Kiểm tra xem giá trị đã được tìm thấy hay chưa
                        if (cbo_loaiChiPhi.SelectedValue == null)
                        {
                            MessageBox.Show("Mã loại chi phí không tồn tại trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cbo_loaiChiPhi.SelectedIndex = -1; // Xóa lựa chọn nếu không tìm thấy
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị chi phí: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Dgv_dsLoaiChiPhi_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                BatDataBindingDataGridViewLoaiChiPhi();
                // Check if the current row is not null
                if (dgv_dsLoaiChiPhi.CurrentRow != null)
                {
                    // Check if the specific cell is not null
                    var cell = dgv_dsLoaiChiPhi.CurrentRow.Cells["MaLoaiChiPhi"];
                    if (cell != null && cell.Value != null)
                    {
                        string loaiChiPhi = cell.Value.ToString();
                        txt_maLoaiChiPhi.Text = loaiChiPhi;
                        txt_tenLoaiChiPhi.Text = dgv_dsLoaiChiPhi.CurrentRow.Cells["TenLoaiChiPhi"].Value.ToString();
                        txt_moTaLoaiChiPhi.Text = dgv_dsLoaiChiPhi.CurrentRow.Cells["MoTa"].Value.ToString();
                        txt_tongTien.Text = dgv_dsLoaiChiPhi.CurrentRow.Cells["TongTien"].Value.ToString();
                        // lấy mã sản phẩm từ dgv_dsLoaiChiPhi
                        string maLoaiChiPhi = loaiChiPhi;
                        HienThiChiPhi(maLoaiChiPhi);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        //viết hàm xử lý ở đây
        //xử lý chi phí
        private void TatBatTextBoxChiPhi(bool trangThai)
        {
            try
            {
                txt_maChiPhi.Enabled = trangThai;
                txt_moTaChiPhi.Enabled = trangThai;
                txt_soTien.Enabled = trangThai;
                dtp_thoiGian.Enabled = trangThai;
                cbo_loaiChiPhi.Enabled = trangThai; // Combobox chọn loại chi phí
            }
            catch
            {
                // Xử lý lỗi (nếu cần)
            }
        }

        private bool KiemTraRongTextBoxChiPhi()
        {
            try
            {
                return string.IsNullOrEmpty(txt_maChiPhi.Text) ||
                       string.IsNullOrEmpty(txt_moTaChiPhi.Text) ||
                       string.IsNullOrEmpty(txt_soTien.Text) ||
                       string.IsNullOrEmpty(cbo_loaiChiPhi.Text); // Kiểm tra chọn loại chi phí
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kiểm tra rỗng: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

        private void XoaTextBoxChiPhi()
        {
            try
            {
                txt_maChiPhi.Clear();
                txt_moTaChiPhi.Clear();
                txt_soTien.Clear();
                cbo_loaiChiPhi.SelectedIndex = -1;
                dtp_thoiGian.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa TextBox: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ChiPhi LayChiPhiTuGiaoDien()
        {
            try
            {
                ChiPhi chiPhi = new ChiPhi();

                chiPhi.MaChiPhi = txt_maChiPhi.Text;
                chiPhi.MoTa = txt_moTaChiPhi.Text;

                if (decimal.TryParse(txt_soTien.Text, out decimal soTien))
                {
                    chiPhi.SoTien = soTien;
                }
                else
                {
                    throw new FormatException("Số tiền phải là số hợp lệ!");
                }

                chiPhi.ThoiGian = dtp_thoiGian.Value;

                // Lấy mã loại chi phí từ combobox
                if (cbo_loaiChiPhi.SelectedValue != null)
                {
                    chiPhi.MaLoaiChiPhi = cbo_loaiChiPhi.SelectedValue.ToString();
                }
                else
                {
                    throw new Exception("Vui lòng chọn loại chi phí hợp lệ!");
                }

                return chiPhi;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy dữ liệu Chi Phí: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void ThemChiPhiVaoDataGridView()
        {
            try
            {
                if (!KiemTraRongTextBoxChiPhi())
                {
                    // Lấy thông tin chi phí từ giao diện
                    ChiPhi chiPhi = LayChiPhiTuGiaoDien();
                    if (chiPhi == null) return;

                    // Kiểm tra mã chi phí đã tồn tại
                    foreach (DataGridViewRow row in dgv_dsChiPhi.Rows)
                    {
                        if (row.Cells["MaChiPhi"].Value?.ToString() == chiPhi.MaChiPhi)
                        {
                            MessageBox.Show("Mã chi phí đã tồn tại! Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Thêm chi phí mới vào BindingList
                    _bindingListChiPhi.Add(chiPhi);

                    MessageBox.Show("Thêm chi phí thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv_dsChiPhi.Refresh();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void XoaChiPhi()
        {
            try
            {
                if (dgv_dsChiPhi.CurrentRow != null)
                {
                    // Lấy mã chi phí hiện tại
                    var row = dgv_dsChiPhi.CurrentRow;
                    string maChiPhi = row.Cells["MaChiPhi"].Value?.ToString();

                    // Xóa chi phí khỏi BindingList
                    _bindingListChiPhi.RemoveAt(row.Index);

                    MessageBox.Show("Xóa chi phí thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv_dsChiPhi.Refresh();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một chi phí để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDanhSachChiPhi(string maLoaiChiPhi)
        {
            try
            {
                _lstChiPhi = _chiPhiBLL.LayChiPhiTheoMaLoaiChiPhi(maLoaiChiPhi, maSanPham);
                dgv_dsChiPhi.DataSource = _lstChiPhi;
                dgv_dsChiPhi.AllowUserToAddRows = false;
                dgv_dsChiPhi.AutoGenerateColumns = false;
                dgv_dsChiPhi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
                dgv_dsChiPhi.MultiSelect = false;
                dgv_dsChiPhi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Đặt tiêu đề cột
                dgv_dsChiPhi.Columns[0].HeaderText = "Mã Chi Phí";
                dgv_dsChiPhi.Columns[1].HeaderText = "Mô Tả";
                dgv_dsChiPhi.Columns[2].HeaderText = "Số Tiền";
                dgv_dsChiPhi.Columns[3].HeaderText = "Thời Gian";
                dgv_dsChiPhi.Columns[4].HeaderText = "Mã Loại Chi Phí";

                TatDataBindingDataGridViewChiPhi();
                BatDataBindingDataGridViewChiPhi();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách chi phí: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TatDataBindingDataGridViewChiPhi()
        {
            try
            {
                txt_maChiPhi.DataBindings.Clear();
                txt_moTaChiPhi.DataBindings.Clear();
                txt_soTien.DataBindings.Clear();
                cbo_loaiChiPhi.DataBindings.Clear();
                dtp_thoiGian.DataBindings.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tắt ràng buộc: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BatDataBindingDataGridViewChiPhi()
        {
            try
            {
                TatDataBindingDataGridViewChiPhi();

                // Ràng buộc dữ liệu từ DataGridView vào TextBox
                if (dgv_dsChiPhi.CurrentRow != null)
                {
                    txt_maChiPhi.Text = dgv_dsChiPhi.CurrentRow.Cells["MaChiPhi"].Value?.ToString();
                    txt_moTaChiPhi.Text = dgv_dsChiPhi.CurrentRow.Cells["MoTa"].Value?.ToString();
                    txt_soTien.Text = dgv_dsChiPhi.CurrentRow.Cells["SoTien"].Value?.ToString();
                    cbo_loaiChiPhi.SelectedValue = dgv_dsChiPhi.CurrentRow.Cells["MaLoaiChiPhi"].Value?.ToString();
                    dtp_thoiGian.Value = Convert.ToDateTime(dgv_dsChiPhi.CurrentRow.Cells["ThoiGian"].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi bật ràng buộc: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //xử lý loại chi phí
        // tắt các textbox
        private void TatBatTextBox(bool trangThai)
        {
            try
            {
                // Khôi phục trạng thái ban đầu của giao diện
                txt_maLoaiChiPhi.Enabled = trangThai;
                txt_tenLoaiChiPhi.Enabled = trangThai;
                txt_moTaLoaiChiPhi.Enabled = trangThai;
                txt_tongTien.Enabled = trangThai;
            }
            catch { }
        }

        private void XoaLoaiChiPhi()
        {
            try
            {
                if (dgv_dsLoaiChiPhi.CurrentRow != null)
                {
                    // Lấy mã loại chi phí hiện tại
                    var row = dgv_dsLoaiChiPhi.CurrentRow;
                    string maLoaiChiPhi = row.Cells["MaLoaiChiPhi"].Value?.ToString();

                    // Kiểm tra chi phí liên quan
                    var danhSachChiPhi = _chiPhiBLL.LayChiPhiTheoMaLoaiChiPhi(maLoaiChiPhi, maSanPham);
                    if (danhSachChiPhi != null && danhSachChiPhi.Count > 0)
                    {
                        MessageBox.Show("Không thể xóa loại chi phí này vì có chi phí liên quan!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Xóa loại chi phí khỏi BindingList
                    _bindingListLoaiChiPhi.RemoveAt(row.Index);

                    MessageBox.Show("Xóa loại chi phí thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv_dsLoaiChiPhi.Refresh();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một loại chi phí để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ThemLoaiChiPhiVaoDataGridView()
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(txt_maLoaiChiPhi.Text) || string.IsNullOrEmpty(txt_tenLoaiChiPhi.Text) || string.IsNullOrEmpty(txt_tongTien.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txt_tongTien.Text, out decimal tongTien))
                {
                    MessageBox.Show("Tổng tiền phải là số hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra trùng mã
                foreach (DataGridViewRow row in dgv_dsLoaiChiPhi.Rows)
                {
                    if (row.Cells["MaLoaiChiPhi"].Value?.ToString() == txt_maLoaiChiPhi.Text)
                    {
                        MessageBox.Show("Mã loại chi phí đã tồn tại! Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Thêm vào danh sách
                _bindingListLoaiChiPhi.Add(new LoaiChiPhi
                {
                    MaLoaiChiPhi = txt_maLoaiChiPhi.Text,
                    TenLoaiChiPhi = txt_tenLoaiChiPhi.Text,
                    MoTa = txt_moTaLoaiChiPhi.Text,
                    TongTien = tongTien,
                    MaSanPham = maSanPham
                });

                MessageBox.Show("Thêm loại chi phí thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgv_dsLoaiChiPhi.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private LoaiChiPhi LayLoaiChiPhiTuGiaoDien()
        {
            try
            {
                // Tạo đối tượng Loại Chi Phí
                LoaiChiPhi loaiChiPhi = new LoaiChiPhi();

                // Lấy dữ liệu từ các TextBox
                loaiChiPhi.MaLoaiChiPhi = txt_maLoaiChiPhi.Text;
                loaiChiPhi.TenLoaiChiPhi = txt_tenLoaiChiPhi.Text;
                loaiChiPhi.MoTa = txt_moTaLoaiChiPhi.Text;

                // Chuyển đổi Tổng Tiền
                if (decimal.TryParse(txt_tongTien.Text, out decimal tongTien))
                {
                    loaiChiPhi.TongTien = tongTien;
                }
                else
                {
                    throw new FormatException("Tổng tiền phải là số hợp lệ!");
                }

                // Gắn mã sản phẩm nếu cần
                loaiChiPhi.MaSanPham = maSanPham; // `maSanPham` có thể là biến toàn cục

                return loaiChiPhi;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy dữ liệu Loại Chi Phí: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private bool KiemTraRongTextBoxLoaiChiPhi()
        {
            try
            {
                if (string.IsNullOrEmpty(txt_maLoaiChiPhi.Text) ||
                    string.IsNullOrEmpty(txt_tenLoaiChiPhi.Text) ||
                    string.IsNullOrEmpty(txt_tongTien.Text) ||
                    string.IsNullOrEmpty(txt_moTaLoaiChiPhi.Text))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kiểm tra rỗng: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

        private void XoaTextBoxLoaiChiPhi()
        {
            try
            {
                txt_maLoaiChiPhi.Clear();
                txt_tenLoaiChiPhi.Clear();
                txt_moTaLoaiChiPhi.Clear();
                txt_tongTien.Clear();
                txt_maLoaiChiPhi.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa TextBox: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDanhSachLoaiChiPhi()
        {
            try
            {
                _lstLoaiChiPhi = _loaiChiPhiBLL.LayDanhSachLoaiChiPhi(maSanPham);
                dgv_dsLoaiChiPhi.DataSource = _lstLoaiChiPhi;
                dgv_dsLoaiChiPhi.AllowUserToAddRows = false;
                dgv_dsLoaiChiPhi.AutoGenerateColumns = false;
                dgv_dsLoaiChiPhi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
                dgv_dsLoaiChiPhi.MultiSelect = false;
                dgv_dsLoaiChiPhi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Đặt tiêu đề cột
                dgv_dsLoaiChiPhi.Columns[0].HeaderText = "Mã Loại Chi Phí";
                dgv_dsLoaiChiPhi.Columns[1].HeaderText = "Tên Loại Chi Phí";
                dgv_dsLoaiChiPhi.Columns[2].HeaderText = "Mô Tả";
                dgv_dsLoaiChiPhi.Columns[3].HeaderText = "Tổng Tiền";

                dgv_dsLoaiChiPhi.SelectionChanged += Dgv_dsLoaiChiPhi_SelectionChanged;

                TatDataBindingDataGridViewLoaiChiPhi();
                BatDataBindingDataGridViewLoaiChiPhi();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách loại chi phí: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TatDataBindingDataGridViewLoaiChiPhi()
        {
            try
            {
                txt_maLoaiChiPhi.DataBindings.Clear();
                txt_tenLoaiChiPhi.DataBindings.Clear();
                txt_moTaLoaiChiPhi.DataBindings.Clear();
                txt_tongTien.DataBindings.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tắt ràng buộc: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void BatDataBindingDataGridViewLoaiChiPhi()
        {
            try
            {
                TatDataBindingDataGridViewLoaiChiPhi();

                // Ràng buộc dữ liệu từ DataGridView vào các TextBox
                if (dgv_dsLoaiChiPhi.CurrentRow != null)
                {
                    txt_maLoaiChiPhi.Text = dgv_dsLoaiChiPhi.CurrentRow.Cells["MaLoaiChiPhi"].Value.ToString();
                    txt_tenLoaiChiPhi.Text = dgv_dsLoaiChiPhi.CurrentRow.Cells["TenLoaiChiPhi"].Value.ToString();
                    txt_moTaLoaiChiPhi.Text = dgv_dsLoaiChiPhi.CurrentRow.Cells["MoTa"].Value.ToString();
                    txt_tongTien.Text = dgv_dsLoaiChiPhi.CurrentRow.Cells["TongTien"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi bật ràng buộc: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadLaiDanhSachLoaiChiPhi()
        {
            try
            {
                TatDataBindingDataGridViewLoaiChiPhi();
                dgv_dsLoaiChiPhi.SelectionChanged -= Dgv_dsLoaiChiPhi_SelectionChanged;

                // Tải lại danh sách loại chi phí
                _lstLoaiChiPhi = _loaiChiPhiBLL.LayDanhSachLoaiChiPhi(maSanPham);
                dgv_dsLoaiChiPhi.DataSource = _lstLoaiChiPhi;

                dgv_dsLoaiChiPhi.SelectionChanged += Dgv_dsLoaiChiPhi_SelectionChanged;

                TatDataBindingDataGridViewLoaiChiPhi();
                BatDataBindingDataGridViewLoaiChiPhi();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải lại danh sách loại chi phí: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //viết hàm load dữ liệu combobox loai chi phí
        private void LoadDataComboboxLoaiChiPhi()
        {
            try
            {
                //lấy danh sách loại chi phí
                List<LoaiChiPhi> lstLoaiChiPhi = _loaiChiPhiBLL.LayDanhSachLoaiChiPhi(maSanPham);
                if (lstLoaiChiPhi != null)
                {
                    //gán dữ liệu vào combobox
                    cbo_loaiChiPhi.DataSource = lstLoaiChiPhi;
                    cbo_loaiChiPhi.DisplayMember = "TenLoaiChiPhi";
                    cbo_loaiChiPhi.ValueMember = "MaLoaiChiPhi";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void dgvSanPham_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                if (dgv_dsLoaiChiPhi.Columns.Contains("SoThuTu") && e.RowIndex < dgv_dsLoaiChiPhi.Rows.Count)
                {
                    dgv_dsLoaiChiPhi.Rows[e.RowIndex].Cells["SoThuTu"].Value = (e.RowIndex + 1).ToString();
                }
                if (dgv_dsChiPhi.Columns.Contains("SoThuTu") && e.RowIndex < dgv_dsChiPhi.Rows.Count)
                {
                    dgv_dsChiPhi.Rows[e.RowIndex].Cells["SoThuTu"].Value = (e.RowIndex + 1).ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void themCotSoThuTu(DataGridView dgvSanPham)
        {
            try
            {
                // Kiểm tra xem cột đã tồn tại hay chưa
                if (dgvSanPham.Columns["SoThuTu"] == null)
                {
                    DataGridViewTextBoxColumn soThuTuColumn = new DataGridViewTextBoxColumn
                    {
                        Name = "SoThuTu",
                        HeaderText = "STT",
                        Width = 40,
                        ReadOnly = true
                    };

                    // Thêm cột số thứ tự vào đầu DataGridView
                    dgvSanPham.Columns.Insert(0, soThuTuColumn);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //viết hàm khởi tạo datagridview
        private void KhoiTaoChiPhi()
        {
            try
            {
                //đổi tên cột
                dgv_dsChiPhi.Columns["MaChiPhi"].HeaderText = "Mã chi phí";
                dgv_dsChiPhi.Columns["MoTa"].HeaderText = "Tên chi phí";
                dgv_dsChiPhi.Columns["SoTien"].HeaderText = "Số tiền";
                dgv_dsChiPhi.Columns["ThoiGian"].HeaderText = "ThoiGian";
                dgv_dsChiPhi.Columns["MaLoaiChiPhi"].HeaderText = "Mã loại chi phí";
                //in đậm tiêu đề
                dgv_dsChiPhi.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
                //căn giữa tiêu đề
                dgv_dsChiPhi.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //ẩn cột
                dgv_dsChiPhi.Columns["LoaiChiPhi"].Visible = false;
                //định dạng tiền
                dgv_dsChiPhi.Columns["SoTien"].DefaultCellStyle.Format = "N0";

                //hiển thị tràn viền
                dgv_dsChiPhi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void KhoiTaoLoaiChiPhi()
        {
            try
            {
                // đổi tên cột
                dgv_dsLoaiChiPhi.Columns["MaLoaiChiPhi"].HeaderText = "Mã loại chi phí";
                dgv_dsLoaiChiPhi.Columns["TenLoaiChiPhi"].HeaderText = "Tên loại chi phí";
                dgv_dsLoaiChiPhi.Columns["MoTa"].HeaderText = "Mô tả";
                dgv_dsLoaiChiPhi.Columns["TongTien"].HeaderText = "Số tiền";
                dgv_dsLoaiChiPhi.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";
                //in đậm tiêu đề
                dgv_dsLoaiChiPhi.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
                //căn giữa tiêu đề
                dgv_dsLoaiChiPhi.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //ẩn cột
                dgv_dsLoaiChiPhi.Columns["SanPham"].Visible = false;

                //định dạng tiền
                dgv_dsLoaiChiPhi.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                //hiển thị full bảng
                dgv_dsLoaiChiPhi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //load dữ liệu chi phí
        private void HienThiChiPhi(string maLoaiChiPhi)
        {
            try
            {
                // Lấy danh sách chi phí từ cơ sở dữ liệu
                var danhSachChiPhi = _chiPhiBLL.LayChiPhiTheoMaLoaiChiPhi(maLoaiChiPhi, maSanPham);

                // Tạo BindingList và gán làm DataSource
                if (danhSachChiPhi != null)
                {
                    _bindingListChiPhi = new BindingList<ChiPhi>(danhSachChiPhi);
                    dgv_dsChiPhi.DataSource = _bindingListChiPhi;

                    // Khởi tạo giao diện DataGridView
                    KhoiTaoChiPhi();
                    themCotSoThuTu(dgv_dsChiPhi);

                    // Sự kiện RowPostPaint để hiển thị số thứ tự
                    dgv_dsChiPhi.RowPostPaint -= dgvSanPham_RowPostPaint;
                    dgv_dsChiPhi.RowPostPaint += dgvSanPham_RowPostPaint;

                    dgv_dsChiPhi.Invalidate();
                    dgv_dsChiPhi.Refresh();
                }
                else
                {
                    // Làm sạch DataGridView nếu không có dữ liệu
                    dgv_dsChiPhi.DataSource = null;
                    MessageBox.Show("Không có dữ liệu chi phí!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị chi phí: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //load dữ liệu loại chi phí
        private void HienThiLoaiChiPhi()
        {
            try
            {
                var danhSachLoaiChiPhi = _loaiChiPhiBLL.LayDanhSachLoaiChiPhi(maSanPham);

                // Tạo BindingList và gán làm DataSource
                _bindingListLoaiChiPhi = new BindingList<LoaiChiPhi>(danhSachLoaiChiPhi);
                dgv_dsLoaiChiPhi.DataSource = _bindingListLoaiChiPhi;
                KhoiTaoLoaiChiPhi();
                themCotSoThuTu(dgv_dsLoaiChiPhi);
                dgv_dsLoaiChiPhi.RowPostPaint -= dgvSanPham_RowPostPaint;
                dgv_dsLoaiChiPhi.RowPostPaint += dgvSanPham_RowPostPaint;
                dgv_dsLoaiChiPhi.Invalidate();
                dgv_dsLoaiChiPhi.Refresh();
            }
            catch
            {
                MessageBox.Show("Lỗi load dữ liệu loại chi phí");
            }
        }
    }
}
