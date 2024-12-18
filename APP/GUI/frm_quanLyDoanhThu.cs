using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using UC;

namespace GUI
{
    public partial class frm_quanLyDoanhThu : Form
    {
        LoaiDoanhThuBLL _loaiDoanhThuBLL = new LoaiDoanhThuBLL();
        DoanhThuBLL _doanhThuBLL = new DoanhThuBLL();
        List<LoaiDoanhThu> _lstLoaiDoanhThu = new List<LoaiDoanhThu>();
        List<DoanhThu> _lstDoanhThu = new List<DoanhThu>();
        ThemXoaSua t = new ThemXoaSua();
        private BindingList<LoaiDoanhThu> _bindingListLoaiDoanhThu;
        private BindingList<DoanhThu> _bindingListDoanhThu;
        private SanPhamBLL _sanPhamBLL = new SanPhamBLL();
        List<SanPham> _lstSanPham = new List<SanPham>();
        string maSanPham = string.Empty;
        public frm_quanLyDoanhThu()
        {
            InitializeComponent();
            this.Load += Frm_quanLyDoanhThu_Load;
        }

        private void Frm_quanLyDoanhThu_Load(object sender, EventArgs e)
        {
            LoadComboBoxSanPham();
            HienThiLoaiDoanhThu();
            dgv_dsLoaiDoanhThu.SelectionChanged += Dgv_dsLoaiDoanhThu_SelectionChanged;
            dgv_dsDoanhThu.SelectionChanged += Dgv_dsDoanhThu_SelectionChanged;
            cbo_sanPham.DropDownStyle = ComboBoxStyle.DropDownList;
            themXoaSuaDoanhThu.ThemClicked += ThemXoaSuaDoanhThu_ThemClicked;
            themXoaSuaDoanhThu.HuyThemClicked += ThemXoaSuaDoanhThu_HuyThemClicked;
            themXoaSuaDoanhThu.XoaClicked += ThemXoaSuaDoanhThu_XoaClicked;
            themXoaSuaDoanhThu.SuaClicked += ThemXoaSuaDoanhThu_SuaClicked;
            themXoaSuaDoanhThu.LuuClicked += ThemXoaSuaDoanhThu_LuuClicked;
            btn_clear.Click += Btn_clear_Click;

            dgv_dsLoaiDoanhThu.AllowUserToAddRows = true;
            themXoaSuaDT.ThemClicked += ThemXoaSuaDT_ThemClicked;
            themXoaSuaDT.XoaClicked += ThemXoaSuaDT_XoaClicked;
            themXoaSuaDT.SuaClicked += ThemXoaSuaDT_SuaClicked;
            themXoaSuaDT.LuuClicked += ThemXoaSuaDT_LuuClicked;
            themXoaSuaDT.HuyThemClicked += ThemXoaSuaDT_HuyThemClicked;
            LoadDataComboboxLoaiDoanhThu();
            btn_khoiPhuc.Click += Btn_khoiPhuc_Click;
            cbo_loaiDoanhThu.Enabled = false;
            dtp_thoiGianDoanhThu.Format = DateTimePickerFormat.Custom;
            dtp_thoiGianDoanhThu.CustomFormat = "MM/yyyy";
        }

        private void ThemXoaSuaDT_XoaClicked(object sender, EventArgs e)
        {
            try
            {
                if (dgv_dsDoanhThu.CurrentRow != null)
                {
                    // Lấy dòng doanh thu hiện tại
                    var row = dgv_dsDoanhThu.CurrentRow;
                    string maDoanhThu = row.Cells["MaDoanhThu"].Value?.ToString();

                    if (string.IsNullOrEmpty(maDoanhThu))
                    {
                        MessageBox.Show("Dữ liệu không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Kiểm tra xem có doanh thu nào liên quan đến dòng này không (có thể là các chi tiết hoặc liên kết khác)
                    var danhSachChiTietDoanhThu = _doanhThuBLL.LayDoanhThuTheoMaLoaiDoanhThu(maDoanhThu,maSanPham);
                    if (danhSachChiTietDoanhThu != null && danhSachChiTietDoanhThu.Count > 0)
                    {
                        MessageBox.Show("Không thể xóa doanh thu này vì có các chi tiết liên quan!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Xóa doanh thu
                    _bindingListDoanhThu.RemoveAt(row.Index);
                    MessageBox.Show("Xóa doanh thu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một doanh thu để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ThemXoaSuaDT_ThemClicked(object sender, EventArgs e)
        {
            try
            {
                // Nếu nút "Hủy Thêm" đang ẩn, nghĩa là đây là lần đầu nhấn nút "Thêm"
                if (!themXoaSuaDT.BtnHuyThem.Enabled)
                {
                    // Bật chế độ nhập liệu
                    txt_maDoanhThu.Enabled =txt_moTaDoanhThu.Enabled =txt_soTienDoanhThu.Enabled =true;
                    dtp_thoiGianDoanhThu.Value=DateTime.Now;

                    // Tắt binding và sự kiện SelectionChanged
                    TatDataBindingDataGridViewDoanhThu();
                    dgv_dsDoanhThu.SelectionChanged -= Dgv_dsDoanhThu_SelectionChanged;

                    // Xóa các trường nhập liệu
                    XoaTextBoxDoanhThu();

                    // Thay đổi trạng thái của các nút
                    themXoaSuaDT.BtnXoa.Enabled = false;
                    themXoaSuaDT.BtnSua.Enabled = false;
                    themXoaSuaDT.BtnLuu.Enabled = false;
                    themXoaSuaDT.BtnHuyThem.Enabled = true;

                    // Đổi biểu tượng nút "Thêm" thành dấu tick (xác nhận)
                    themXoaSuaDT.BtnThem.Image = Properties.Resources.icons8_tick_35;

                    MessageBox.Show("Sẵn sàng để thêm doanh thu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // Khi nút "Hủy Thêm" đang hiện, nghĩa là đang chờ xác nhận thêm
                {
                    // Kiểm tra dữ liệu nhập liệu
                    if (!KiemTraRongTextBoxDoanhThu())
                    {
                        // Làm sạch và chuẩn hóa giá trị số tiền
                        string rawSoTien = txt_soTienDoanhThu.Text
                        .Replace("VNĐ", "") // Loại bỏ đơn vị VNĐ
                        .Replace(".", "")    // Loại bỏ dấu chấm ngăn cách phần nghìn
                        .Replace(",", ".")   // Thay dấu phẩy bằng dấu chấm
                        .Trim();             // Xóa khoảng trắng thừa

                        // Chuyển đổi số tiền thành decimal
                        decimal soTien = decimal.TryParse(rawSoTien, out decimal parsedSoTien) ? parsedSoTien : 0;

                        // Kiểm tra giá trị rỗng hoặc null trước khi gán
                        string maDoanhThu = string.IsNullOrWhiteSpace(txt_maDoanhThu.Text)
                            ? throw new ArgumentException("Mã doanh thu không được để trống.")
                            : txt_maDoanhThu.Text;

                        string maLoaiDoanhThu = cbo_loaiDoanhThu.SelectedValue?.ToString() ??
                            throw new ArgumentException("Bạn phải chọn loại doanh thu.");

                        string moTa = txt_moTaDoanhThu.Text?.Trim() ?? "";

                        // Tạo đối tượng DoanhThu
                        DoanhThu doanhThu = new DoanhThu
                        {
                            MaDoanhThu = maDoanhThu,
                            MaLoaiDoanhThu = maLoaiDoanhThu,
                            MoTa = moTa,
                            SoTien = soTien,
                            ThoiGian = dtp_thoiGianDoanhThu.Value
                        };

                        // Kiểm tra trùng mã doanh thu
                        if (_bindingListDoanhThu.Any(d => d.MaDoanhThu.Equals(doanhThu.MaDoanhThu, StringComparison.OrdinalIgnoreCase)))
                        {
                            MessageBox.Show("Mã doanh thu đã tồn tại! Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txt_maDoanhThu.Focus();
                            return;
                        }

                        // Thêm doanh thu vào BindingList
                        _bindingListDoanhThu.Add(doanhThu);
                        dgv_dsDoanhThu.Refresh();

                        // Khôi phục trạng thái ban đầu của giao diện
                        txt_maDoanhThu.Enabled = false;

                        BatDataBindingDataGridViewDoanhThu();
                        dgv_dsDoanhThu.SelectionChanged += Dgv_dsDoanhThu_SelectionChanged;

                        // Kích hoạt lại các nút
                        themXoaSuaDT.BtnXoa.Enabled = true;
                        themXoaSuaDT.BtnSua.Enabled = true;
                        themXoaSuaDT.BtnLuu.Enabled = true;
                        themXoaSuaDT.BtnHuyThem.Enabled = false;

                        // Đổi biểu tượng nút "Thêm" về trạng thái ban đầu
                        themXoaSuaDT.BtnThem.Image = Properties.Resources.icons8_add_35;

                        MessageBox.Show("Thêm doanh thu mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm doanh thu: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_clear_Click(object sender, EventArgs e)
        {
            XoaTextBoxLoaiDoanhThu();
        }

        private void ThemXoaSuaDoanhThu_LuuClicked(object sender, EventArgs e)
        {
            try
            {
                // Lưu Loại Doanh Thu
                var danhSachLoaiDoanhThu = _bindingListLoaiDoanhThu.ToList();
                _loaiDoanhThuBLL.CapNhatThemXoaSuaLoaiDoanhThu(danhSachLoaiDoanhThu);

                // Lưu Doanh Thu
                MessageBox.Show("Lưu thành công tất cả thay đổi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiLoaiDoanhThu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ThemXoaSuaDoanhThu_XoaClicked(object sender, EventArgs e)
        {
            try
            {
                if (dgv_dsLoaiDoanhThu.CurrentRow != null)
                {
                    // Lấy loại doanh thu hiện tại
                    var row = dgv_dsLoaiDoanhThu.CurrentRow;
                    string maLoaiDoanhThu = row.Cells["MaLoaiDoanhThu"].Value?.ToString();

                    if (string.IsNullOrEmpty(maLoaiDoanhThu))
                    {
                        MessageBox.Show("Dữ liệu không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Kiểm tra doanh thu liên quan
                    var danhSachDoanhThu = _doanhThuBLL.LayDoanhThuTheoMaLoaiDoanhThu(maLoaiDoanhThu, maSanPham);
                    if (danhSachDoanhThu != null && danhSachDoanhThu.Count > 0)
                    {
                        MessageBox.Show("Không thể xóa loại doanh thu này vì có doanh thu liên quan!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Xóa loại doanh thu
                    _bindingListLoaiDoanhThu.RemoveAt(row.Index);
                    MessageBox.Show("Xóa loại doanh thu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một loại doanh thu để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ThemXoaSuaDoanhThu_SuaClicked(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn trong DataGridView không
                if (dgv_dsLoaiDoanhThu.CurrentRow != null)
                {
                    // Lấy dòng hiện tại
                    var row = dgv_dsLoaiDoanhThu.CurrentRow;

                    // Hiển thị các TextBox và cho phép người dùng sửa
                    TatBatTextBoxLoaiDoanhThu(true);  // Gọi hàm mở các TextBox
                    txt_maLoaiDoanhThu.Enabled = false; // Mã loại doanh thu không được sửa
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một loại doanh thu để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra các điều kiện khi người dùng nhấn nút sửa lần thứ hai
                if (!KiemTraRongTextBoxLoaiDoanhThu()) // Kiểm tra không rỗng
                {
                    // Cập nhật giá trị từ TextBox vào dòng (nếu dữ liệu hợp lệ)
                    var row = dgv_dsLoaiDoanhThu.CurrentRow;

                    // Cập nhật giá trị vào dòng trong DataGridView
                    row.Cells["TenLoaiDoanhThu"].Value = txt_tenLoaiDoanhThu.Text;
                    row.Cells["MoTa"].Value = txt_moTaLoaiDoanhThu.Text;

                    // Kiểm tra và cập nhật giá trị "Tổng Tiền"
                    if (decimal.TryParse(txt_tongTienDoanhThu.Text, out decimal tongTien))
                    {
                        row.Cells["TongTien"].Value = tongTien;
                    }
                    else
                    {
                        MessageBox.Show("Tổng tiền phải là số hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Kích hoạt lại các nút (nếu cần)
                    themXoaSuaDoanhThu.BtnThem.Enabled = true;
                    themXoaSuaDoanhThu.BtnXoa.Enabled = true;
                    themXoaSuaDoanhThu.BtnLuu.Enabled = true;
                    themXoaSuaDoanhThu.BtnHuyThem.Enabled = false;

                    MessageBox.Show("Sửa loại doanh thu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Cập nhật lại DataGridView để phản ánh các thay đổi
                    dgv_dsLoaiDoanhThu.Refresh();

                    // Trỏ vào dòng vừa sửa
                    dgv_dsLoaiDoanhThu.ClearSelection();
                    row.Selected = true;
                    dgv_dsLoaiDoanhThu.CurrentCell = row.Cells["TenLoaiDoanhThu"];
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa loại doanh thu: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ThemXoaSuaDoanhThu_HuyThemClicked(object sender, EventArgs e)
        {
            try
            {
                txt_maLoaiDoanhThu.Enabled = false;
                BatDataBindingDataGridViewLoaiDoanhThu();
                dgv_dsLoaiDoanhThu.SelectionChanged += Dgv_dsLoaiDoanhThu_SelectionChanged;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void ThemXoaSuaDoanhThu_ThemClicked(object sender, EventArgs e)
        {
            try
            {
                // Nếu nút "Hủy Thêm" đang ẩn, nghĩa là đây là lần đầu nhấn nút "Thêm"
                if (!themXoaSuaDoanhThu.BtnHuyThem.Enabled)
                {
                    txt_maLoaiDoanhThu.Enabled=txt_moTaLoaiDoanhThu.Enabled =txt_tenLoaiDoanhThu.Enabled =true;

                    // Tắt binding và sự kiện SelectionChanged
                    TatDataBindingDataGridViewLoaiDoanhThu();
                    dgv_dsLoaiDoanhThu.SelectionChanged -= Dgv_dsLoaiDoanhThu_SelectionChanged;

                    // Xóa các trường nhập liệu
                    XoaTextBoxLoaiDoanhThu();

                    // Thay đổi trạng thái của các nút
                    themXoaSuaDoanhThu.BtnXoa.Enabled = false;
                    themXoaSuaDoanhThu.BtnSua.Enabled = false;
                    themXoaSuaDoanhThu.BtnLuu.Enabled = false;
                    themXoaSuaDoanhThu.BtnHuyThem.Enabled = true;

                    // Đổi biểu tượng nút "Thêm" thành dấu tick (xác nhận)
                    themXoaSuaDoanhThu.BtnThem.Image = Properties.Resources.icons8_tick_35;

                    MessageBox.Show("Sẵn sàng để thêm loại doanh thu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // Khi nút "Hủy Thêm" đang hiện, nghĩa là đang chờ xác nhận thêm
                {
                    // Kiểm tra dữ liệu nhập liệu
                    if (!KiemTraRongTextBoxLoaiDoanhThu())
                    {
                        // Lấy loại doanh thu từ các TextBox
                        LoaiDoanhThu loaiDoanhThu = new LoaiDoanhThu
                        {
                            MaLoaiDoanhThu = txt_maLoaiDoanhThu.Text,
                            TenLoaiDoanhThu = txt_tenLoaiDoanhThu.Text,
                            MoTa = txt_moTaLoaiDoanhThu.Text,
                            TongTien = decimal.TryParse(txt_tongTienDoanhThu.Text, out decimal tongTien) ? tongTien : 0,
                            MaSanPham = maSanPham
                        };

                        // Kiểm tra trùng mã loại doanh thu
                        if (_bindingListLoaiDoanhThu.Any(l => l.MaLoaiDoanhThu.Equals(loaiDoanhThu.MaLoaiDoanhThu, StringComparison.OrdinalIgnoreCase)))
                        {
                            MessageBox.Show("Mã loại doanh thu đã tồn tại! Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txt_maLoaiDoanhThu.Focus();
                            return;
                        }

                        // Thêm loại doanh thu vào BindingList
                        _bindingListLoaiDoanhThu.Add(loaiDoanhThu);
                        dgv_dsLoaiDoanhThu.Refresh();

                        // Khôi phục trạng thái ban đầu của giao diện
                        txt_maLoaiDoanhThu.Enabled = false;

                        BatDataBindingDataGridViewLoaiDoanhThu();
                        dgv_dsLoaiDoanhThu.SelectionChanged += Dgv_dsLoaiDoanhThu_SelectionChanged;

                        // Kích hoạt lại các nút
                        themXoaSuaDoanhThu.BtnXoa.Enabled = true;
                        themXoaSuaDoanhThu.BtnSua.Enabled = true;
                        themXoaSuaDoanhThu.BtnLuu.Enabled = true;
                        themXoaSuaDoanhThu.BtnHuyThem.Enabled = false;

                        // Đổi biểu tượng nút "Thêm" về trạng thái ban đầu
                        themXoaSuaDoanhThu.BtnThem.Image = Properties.Resources.icons8_add_35;

                        MessageBox.Show("Thêm loại doanh thu mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm loại doanh thu: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Dgv_dsDoanhThu_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị dòng đang chọn lên TextBox
                if (dgv_dsDoanhThu.CurrentRow != null)
                {
                    // Lấy thông tin từ dòng hiện tại
                    txt_maDoanhThu.Text = dgv_dsDoanhThu.CurrentRow.Cells["MaDoanhThu"].Value?.ToString();
                    txt_moTaDoanhThu.Text = dgv_dsDoanhThu.CurrentRow.Cells["MoTa"].Value?.ToString();
                    txt_soTienDoanhThu.Text = string.Format("{0:N0} VNĐ", Convert.ToDecimal(dgv_dsDoanhThu.CurrentRow.Cells["SoTien"].Value ?? 0));

                    if (DateTime.TryParse(dgv_dsDoanhThu.CurrentRow.Cells["ThoiGian"].Value?.ToString(), out DateTime thoiGian))
                    {
                        dtp_thoiGianDoanhThu.Value = thoiGian;
                    }

                    string maLoaiDoanhThu = dgv_dsDoanhThu.CurrentRow.Cells["MaLoaiDoanhThu"].Value?.ToString();

                    // Tìm và hiển thị tên loại doanh thu trong ComboBox
                    if (!string.IsNullOrEmpty(maLoaiDoanhThu))
                    {
                        // Gán giá trị SelectedValue cho ComboBox
                        cbo_loaiDoanhThu.SelectedValue = maLoaiDoanhThu;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị doanh thu: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Dgv_dsLoaiDoanhThu_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                BatDataBindingDataGridViewLoaiDoanhThu();
                // Kiểm tra xem dòng hiện tại có phải là null không
                if (dgv_dsLoaiDoanhThu.CurrentRow != null)
                {
                    // Kiểm tra xem ô cụ thể có phải là null không
                    var cell = dgv_dsLoaiDoanhThu.CurrentRow.Cells["MaLoaiDoanhThu"];
                    if (cell != null && cell.Value != null)
                    {
                        string loaiDoanhThu = cell.Value.ToString();
                        txt_maLoaiDoanhThu.Text = loaiDoanhThu;
                        txt_tenLoaiDoanhThu.Text = dgv_dsLoaiDoanhThu.CurrentRow.Cells["TenLoaiDoanhThu"].Value.ToString();
                        txt_moTaLoaiDoanhThu.Text = dgv_dsLoaiDoanhThu.CurrentRow.Cells["MoTa"].Value.ToString();
                        txt_tongTienDoanhThu.Text = string.Format("{0:N0} VNĐ", Convert.ToDecimal(dgv_dsLoaiDoanhThu.CurrentRow.Cells["TongTien"].Value ?? 0));

                        // lấy mã sản phẩm từ dgv_dsLoaiDoanhThu
                        string maLoaiDoanhThu = loaiDoanhThu;
                        HienThiDoanhThu(maLoaiDoanhThu);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void Btn_khoiPhuc_Click(object sender, EventArgs e)
        {
            dgv_dsLoaiDoanhThu.SelectionChanged -= Dgv_dsLoaiDoanhThu_SelectionChanged;
            dgv_dsLoaiDoanhThu.DataSource = null;
            LoadLaiTrang();
        }

        private void ThemXoaSuaDT_HuyThemClicked(object sender, EventArgs e)
        {
            try
            {
                txt_maDoanhThu.Enabled = false;
                BatDataBindingDataGridViewDoanhThu();
                dgv_dsDoanhThu.SelectionChanged += Dgv_dsDoanhThu_SelectionChanged;

                themXoaSuaDT.BtnSua.Enabled = true;
                themXoaSuaDT.BtnXoa.Enabled = true;
                themXoaSuaDT.BtnLuu.Enabled = true;
                themXoaSuaDT.BtnHuyThem.Enabled = false;
                themXoaSuaDT.BtnThem.Image = Properties.Resources.icons8_add_35;

                MessageBox.Show("Hủy thao tác thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hủy thêm: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ThemXoaSuaDT_LuuClicked(object sender, EventArgs e)
        {
            try
            {
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn lưu tất cả thay đổi?",
                                                    "Xác nhận lưu",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    string maLoai = dgv_dsLoaiDoanhThu.CurrentRow.Cells["MaLoaiDoanhThu"].Value.ToString();
                    var danhSachDoanhThu = _bindingListDoanhThu.ToList();
                    bool ketQua = _doanhThuBLL.CapNhatThemXoaSuaDoanhThu(danhSachDoanhThu, maLoai);

                    if (ketQua)
                    {
                        MessageBox.Show("Lưu thay đổi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HienThiDoanhThu(maLoai);
                        //load lại trang
                        LoadLaiTrang();
                    }
                    else
                    {
                        MessageBox.Show("Lưu thay đổi thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu doanh thu: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ThemXoaSuaDT_SuaClicked(object sender, EventArgs e)
        {
            try
            {
                if (dgv_dsDoanhThu.CurrentRow != null)
                {
                    var row = dgv_dsDoanhThu.CurrentRow;

                    if (string.IsNullOrEmpty(txt_moTaDoanhThu.Text) || string.IsNullOrEmpty(txt_soTienDoanhThu.Text))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    // Lấy giá trị từ TextBox
                    string input = txt_soTienDoanhThu.Text;

                    // Loại bỏ đơn vị "VNĐ" (không phân biệt hoa/thường) và khoảng trắng
                    input = Regex.Replace(input, @"VNĐ", "", RegexOptions.IgnoreCase);

                    // Loại bỏ tất cả khoảng trắng trong chuỗi
                    input = input.Replace(" ", "");

                    // Loại bỏ tất cả ký tự không phải số, dấu chấm hoặc dấu phẩy
                    input = Regex.Replace(input, @"[^\d.,]", "");

                    // Thay dấu phẩy (,) thành dấu chấm (.) để chuẩn hóa định dạng số thập phân
                    input = input.Replace(",", ".");

                    // Kiểm tra và chuyển đổi sang kiểu decimal
                    if (!decimal.TryParse(input, out decimal soTien))
                    {
                        MessageBox.Show("Số tiền phải là một giá trị hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    row.Cells["MoTa"].Value = txt_moTaDoanhThu.Text;
                    row.Cells["SoTien"].Value = soTien;
                    row.Cells["ThoiGian"].Value = dtp_thoiGianDoanhThu.Value;

                    dgv_dsDoanhThu.Refresh();

                    MessageBox.Show("Sửa doanh thu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txt_maDoanhThu.Enabled = false;
                    themXoaSuaDT.BtnThem.Enabled = true;
                    themXoaSuaDT.BtnXoa.Enabled = true;
                    themXoaSuaDT.BtnLuu.Enabled = true;
                    themXoaSuaDT.BtnHuyThem.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một doanh thu để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa doanh thu: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //viết hàm xử lý
        private void Cbo_sanPham_SelectedValueChanged(object sender, EventArgs e)
        {
            maSanPham = cbo_sanPham.SelectedValue.ToString();
            LoadLaiTrang();
        }


        // viết hàm xử lý ở đây
        //load lại trang
        private void LoadLaiTrang()
        {
            HienThiLoaiDoanhThu();
        }
        private void LoadComboBoxSanPham()
        {
            try
            {
                _lstSanPham = _sanPhamBLL.LayDanhSachSanPham();  // Lấy danh sách sản phẩm từ BLL

                if (_lstSanPham != null && _lstSanPham.Count > 0)
                {
                    cbo_sanPham.DataSource = _lstSanPham;
                    cbo_sanPham.DisplayMember = "TenSanPham";  // Hiển thị tên sản phẩm
                    cbo_sanPham.ValueMember = "MaSanPham";  // Gán giá trị mã sản phẩm

                    // Gán giá trị đầu tiên vào maSP
                    maSanPham = _lstSanPham.FirstOrDefault()?.MaSanPham.ToString();

                    // Chọn mục đầu tiên của ComboBox nếu có ít nhất một phần tử
                    cbo_sanPham.SelectedIndex = 0;

                    // Đăng ký sự kiện SelectedValueChanged
                    cbo_sanPham.SelectedValueChanged += Cbo_sanPham_SelectedValueChanged;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm nào");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu sản phẩm: " + ex.Message);
            }
        }
        private void KhoiTaoDoanhThu()
        {
            try
            {
                // Kiểm tra xem dgv_dsDoanhThu có phải là null không
                if (dgv_dsDoanhThu == null)
                {
                    MessageBox.Show("DataGridView doanh thu chưa được khởi tạo.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Đổi tên cột
                dgv_dsDoanhThu.Columns["MaDoanhThu"].HeaderText = "Mã doanh thu";
                dgv_dsDoanhThu.Columns["MoTa"].HeaderText = "Mô Tả";
                dgv_dsDoanhThu.Columns["SoTien"].HeaderText = "Số tiền";
                dgv_dsDoanhThu.Columns["ThoiGian"].HeaderText = "Thời gian";
                //hiển thị thời gian lên dgv là tháng năm
                dgv_dsDoanhThu.Columns["ThoiGian"].DefaultCellStyle.Format = "MM/yyyy";
                dgv_dsDoanhThu.Columns["MaLoaiDoanhThu"].HeaderText = "Mã loại doanh thu";

                // In đậm tiêu đề cột
                dgv_dsDoanhThu.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);

                // Căn giữa tiêu đề cột
                dgv_dsDoanhThu.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Ẩn cột không cần thiết (ví dụ như cột "LoaiDoanhThu" nếu không cần thiết)
                if (dgv_dsDoanhThu.Columns.Contains("LoaiDoanhThu"))
                {
                    dgv_dsDoanhThu.Columns["LoaiDoanhThu"].Visible = false;
                }

                // Định dạng cột "SoTien" là tiền
                if (dgv_dsDoanhThu.Columns.Contains("SoTien"))
                {
                    dgv_dsDoanhThu.Columns["SoTien"].DefaultCellStyle.Format = "N0"; // Định dạng tiền với dấu phân cách hàng nghìn
                    // Căn phải nội dung của cột SoTien
                    dgv_dsDoanhThu.Columns["SoTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                // Sửa lại thứ tự hiển thị của cột "MoTa"
                if (dgv_dsDoanhThu.Columns.Contains("MoTa"))
                {
                    dgv_dsDoanhThu.Columns["MoTa"].DisplayIndex = dgv_dsDoanhThu.Columns.Count - 1; // Đưa cột MoTa vào cuối cùng
                }

                // Hiển thị toàn bộ bảng, tự động thay đổi kích thước cột
                dgv_dsDoanhThu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Cập nhật lại FillWeight cho các cột sao cho tổng cộng = 100
                dgv_dsDoanhThu.Columns["SoThuTu"].FillWeight = 5;  // Cột STT chiếm 5% chiều rộng
                dgv_dsDoanhThu.Columns["MaDoanhThu"].FillWeight = 15;
                dgv_dsDoanhThu.Columns["MoTa"].FillWeight = 35;  // MoTa chiếm phần lớn chiều rộng
                dgv_dsDoanhThu.Columns["SoTien"].FillWeight = 15;
                dgv_dsDoanhThu.Columns["ThoiGian"].FillWeight = 15;
                dgv_dsDoanhThu.Columns["MaLoaiDoanhThu"].FillWeight = 15;

                // Thiết lập tự động xuống dòng cho cột "MoTa" và "MaDoanhThu"
                if (dgv_dsDoanhThu.Columns.Contains("MoTa"))
                {
                    dgv_dsDoanhThu.Columns["MoTa"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                }

                if (dgv_dsDoanhThu.Columns.Contains("MaDoanhThu"))
                {
                    dgv_dsDoanhThu.Columns["MaDoanhThu"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                }

                // Tự động điều chỉnh chiều cao hàng dựa trên nội dung của các ô
                dgv_dsDoanhThu.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                // Nếu cần, có thể đặt chiều cao tối thiểu cho các hàng
                foreach (DataGridViewRow row in dgv_dsDoanhThu.Rows)
                {
                    row.Height = Math.Max(row.Height, 30); // Đặt chiều cao tối thiểu cho các hàng
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo DataGridView doanh thu: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_dsDoanhThu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && dgv_dsDoanhThu.Columns.Contains("SoThuTu"))
                {
                    // Cập nhật số thứ tự cho mỗi dòng
                    dgv_dsDoanhThu.Rows[e.RowIndex].Cells["SoThuTu"].Value = (e.RowIndex + 1).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật số thứ tự: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void themCotSoThuTu(DataGridView dgv_dsDoanhThu)
        {
            try
            {
                // Kiểm tra xem cột "SoThuTu" đã tồn tại chưa
                if (dgv_dsDoanhThu.Columns["SoThuTu"] == null)
                {
                    // Tạo cột mới cho số thứ tự
                    DataGridViewTextBoxColumn soThuTuColumn = new DataGridViewTextBoxColumn
                    {
                        Name = "SoThuTu", // Tên cột
                        HeaderText = "STT", // Tiêu đề cột
                        Width = 40, // Độ rộng cột
                        ReadOnly = true // Không cho phép chỉnh sửa
                    };

                    // Thêm cột số thứ tự vào đầu DataGridView
                    dgv_dsDoanhThu.Columns.Insert(0, soThuTuColumn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm cột số thứ tự: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiDoanhThu(string maLoai)
        {
            try
            {
                // Lấy danh sách doanh thu theo mã loại doanh thu từ BLL
                var danhSachDoanhThu = _doanhThuBLL.LayDoanhThuTheoMaLoaiDoanhThu(maLoai, maSanPham);

                // Kiểm tra nếu danh sách doanh thu không null
                if (danhSachDoanhThu != null)
                {
                    // Tạo BindingList và gán vào DataSource của DataGridView
                    _bindingListDoanhThu = new BindingList<DoanhThu>(danhSachDoanhThu);
                    dgv_dsDoanhThu.DataSource = _bindingListDoanhThu;

                    // Khởi tạo giao diện DataGridView
                    themCotSoThuTu(dgv_dsDoanhThu);
                    KhoiTaoDoanhThu();

                    // Đăng ký lại sự kiện RowPostPaint để hiển thị số thứ tự (STT)
                    dgv_dsDoanhThu.RowPostPaint -= dgv_dsDoanhThu_RowPostPaint;
                    dgv_dsDoanhThu.RowPostPaint += dgv_dsDoanhThu_RowPostPaint;

                    // Refresh và cập nhật giao diện
                    dgv_dsDoanhThu.Invalidate();
                    dgv_dsDoanhThu.Refresh();
                    //tính tổng tiền của loại doanh thu
                    decimal tongTien =(decimal)danhSachDoanhThu.Sum(dt => dt.SoTien);
                    txt_ttDoanhThu.Text ="Tổng tiền doanh thu:"+ string.Format("{0:N0} VNĐ", tongTien);
                }
                else
                {
                    // Nếu không có dữ liệu, hiển thị thông báo và làm sạch DataGridView
                    dgv_dsDoanhThu.DataSource = null;
                    MessageBox.Show("Không có dữ liệu doanh thu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có lỗi xảy ra
                MessageBox.Show($"Lỗi khi hiển thị doanh thu: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDanhSachDoanhThu(string maLoaiDoanhThu)
        {
            try
            {
                _lstDoanhThu = _doanhThuBLL.LayDoanhThuTheoMaLoaiDoanhThu(maLoaiDoanhThu,maSanPham);
                dgv_dsDoanhThu.DataSource = _lstDoanhThu;
                dgv_dsDoanhThu.AllowUserToAddRows = false;
                dgv_dsDoanhThu.AutoGenerateColumns = false;
                dgv_dsDoanhThu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
                dgv_dsDoanhThu.MultiSelect = false;
                dgv_dsDoanhThu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Đặt tiêu đề cột
                TatDataBindingDataGridViewDoanhThu();
                BatDataBindingDataGridViewDoanhThu();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách doanh thu: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TatDataBindingDataGridViewDoanhThu()
        {
            try
            {
                txt_maDoanhThu.DataBindings.Clear();
                txt_moTaDoanhThu.DataBindings.Clear();
                txt_soTienDoanhThu.DataBindings.Clear();
                cbo_loaiDoanhThu.DataBindings.Clear();
                dtp_thoiGianDoanhThu.DataBindings.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tắt ràng buộc: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BatDataBindingDataGridViewDoanhThu()
        {
            try
            {
                TatDataBindingDataGridViewDoanhThu();

                // Ràng buộc dữ liệu từ DataGridView vào TextBox
                if (dgv_dsDoanhThu.CurrentRow != null)
                {
                    txt_maDoanhThu.Text = dgv_dsDoanhThu.CurrentRow.Cells["MaDoanhThu"].Value?.ToString();
                    txt_moTaDoanhThu.Text = dgv_dsDoanhThu.CurrentRow.Cells["MoTa"].Value?.ToString();
                    txt_soTienDoanhThu.Text = dgv_dsDoanhThu.CurrentRow.Cells["SoTien"].Value?.ToString();
                    cbo_loaiDoanhThu.SelectedValue = dgv_dsDoanhThu.CurrentRow.Cells["MaLoaiDoanhThu"].Value?.ToString();
                    dtp_thoiGianDoanhThu.Value = Convert.ToDateTime(dgv_dsDoanhThu.CurrentRow.Cells["ThoiGian"].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi bật ràng buộc: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TatBatTextBoxLoaiDoanhThu(bool trangThai)
        {
            try
            {
                txt_maLoaiDoanhThu.Enabled = trangThai;
                txt_tenLoaiDoanhThu.Enabled = trangThai;
                txt_moTaLoaiDoanhThu.Enabled = trangThai;
                txt_tongTienDoanhThu.Enabled = trangThai;
            }
            catch
            {
                // Xử lý lỗi nếu cần
            }
        }
        private bool KiemTraRongTextBoxLoaiDoanhThu()
        {
            try
            {
                return string.IsNullOrEmpty(txt_maLoaiDoanhThu.Text) ||
                       string.IsNullOrEmpty(txt_tenLoaiDoanhThu.Text) ||
                       string.IsNullOrEmpty(txt_tongTienDoanhThu.Text) ||
                       string.IsNullOrEmpty(txt_moTaLoaiDoanhThu.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kiểm tra rỗng: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }
        private void XoaTextBoxLoaiDoanhThu()
        {
            try
            {
                txt_maLoaiDoanhThu.Clear();
                txt_tenLoaiDoanhThu.Clear();
                txt_moTaLoaiDoanhThu.Clear();
                txt_tongTienDoanhThu.Clear();
                txt_maLoaiDoanhThu.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa TextBox: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private LoaiDoanhThu LayLoaiDoanhThuTuGiaoDien()
        {
            try
            {
                LoaiDoanhThu loaiDoanhThu = new LoaiDoanhThu
                {
                    MaLoaiDoanhThu = txt_maLoaiDoanhThu.Text,
                    TenLoaiDoanhThu = txt_tenLoaiDoanhThu.Text,
                    MoTa = txt_moTaLoaiDoanhThu.Text,
                    TongTien = decimal.TryParse(txt_tongTienDoanhThu.Text, out decimal tongTien) ? tongTien : 0
                };
                return loaiDoanhThu;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy dữ liệu Loại Doanh Thu: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private void ThemLoaiDoanhThuVaoDataGridView()
        {
            try
            {
                if (!KiemTraRongTextBoxLoaiDoanhThu())
                {
                    LoaiDoanhThu loaiDoanhThu = LayLoaiDoanhThuTuGiaoDien();
                    if (loaiDoanhThu == null) return;

                    foreach (DataGridViewRow row in dgv_dsLoaiDoanhThu.Rows)
                    {
                        if (row.Cells["MaLoaiDoanhThu"].Value?.ToString() == loaiDoanhThu.MaLoaiDoanhThu)
                        {
                            MessageBox.Show("Mã loại doanh thu đã tồn tại! Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    _bindingListLoaiDoanhThu.Add(loaiDoanhThu);
                    MessageBox.Show("Thêm loại doanh thu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv_dsLoaiDoanhThu.Refresh();
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
        private void TatBatTextBoxDoanhThu(bool trangThai)
        {
            try
            {
                txt_maDoanhThu.Enabled = trangThai;
                txt_moTaDoanhThu.Enabled = trangThai;
                txt_soTienDoanhThu.Enabled = trangThai;
                dtp_thoiGianDoanhThu.Enabled = trangThai;
                cbo_loaiDoanhThu.Enabled = trangThai;
            }
            catch
            {
                // Xử lý lỗi nếu cần
            }
        }
        private bool KiemTraRongTextBoxDoanhThu()
        {
            try
            {
                return string.IsNullOrEmpty(txt_maDoanhThu.Text) ||
                       string.IsNullOrEmpty(txt_moTaDoanhThu.Text) ||
                       string.IsNullOrEmpty(txt_soTienDoanhThu.Text) ||
                       cbo_loaiDoanhThu.SelectedValue == null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kiểm tra rỗng: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }
        private void XoaTextBoxDoanhThu()
        {
            try
            {
                txt_maDoanhThu.Clear();
                txt_moTaDoanhThu.Clear();
                txt_soTienDoanhThu.Clear();
                dtp_thoiGianDoanhThu.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa TextBox: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private DoanhThu LayDoanhThuTuGiaoDien()
        {
            try
            {
                DoanhThu doanhThu = new DoanhThu
                {
                    MaDoanhThu = txt_maDoanhThu.Text,
                    MoTa = txt_moTaDoanhThu.Text,
                    SoTien = decimal.TryParse(txt_soTienDoanhThu.Text, out decimal soTien) ? soTien : 0,
                    ThoiGian = dtp_thoiGianDoanhThu.Value,
                    MaLoaiDoanhThu = cbo_loaiDoanhThu.SelectedValue?.ToString()
                };
                return doanhThu;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy dữ liệu Doanh Thu: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private void ThemDoanhThuVaoDataGridView()
        {
            try
            {
                if (!KiemTraRongTextBoxDoanhThu())
                {
                    DoanhThu doanhThu = LayDoanhThuTuGiaoDien();
                    if (doanhThu == null) return;

                    foreach (DataGridViewRow row in dgv_dsDoanhThu.Rows)
                    {
                        if (row.Cells["MaDoanhThu"].Value?.ToString() == doanhThu.MaDoanhThu)
                        {
                            MessageBox.Show("Mã doanh thu đã tồn tại! Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    _bindingListDoanhThu.Add(doanhThu);
                    MessageBox.Show("Thêm doanh thu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv_dsDoanhThu.Refresh();
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
        private void LoadDanhSachLoaiDoanhThu()
        {
            try
            {
                _lstLoaiDoanhThu = _loaiDoanhThuBLL.LayDanhSachLoaiDoanhThu(maSanPham);
                dgv_dsLoaiDoanhThu.DataSource = _lstLoaiDoanhThu;
                dgv_dsLoaiDoanhThu.AllowUserToAddRows = false;
                dgv_dsLoaiDoanhThu.AutoGenerateColumns = false;
                dgv_dsLoaiDoanhThu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
                dgv_dsLoaiDoanhThu.MultiSelect = false;
                dgv_dsLoaiDoanhThu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Đặt tiêu đề cột
                dgv_dsLoaiDoanhThu.Columns[0].HeaderText = "Mã Loại Doanh Thu";
                dgv_dsLoaiDoanhThu.Columns[1].HeaderText = "Tên Loại Doanh Thu";
                dgv_dsLoaiDoanhThu.Columns[2].HeaderText = "Mô Tả";
                dgv_dsLoaiDoanhThu.Columns[3].HeaderText = "Tổng Tiền";

                dgv_dsLoaiDoanhThu.SelectionChanged += Dgv_dsLoaiDoanhThu_SelectionChanged;

                TatDataBindingDataGridViewLoaiDoanhThu();
                BatDataBindingDataGridViewLoaiDoanhThu();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách loại doanh thu: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TatDataBindingDataGridViewLoaiDoanhThu()
        {
            try
            {
                txt_maLoaiDoanhThu.DataBindings.Clear();
                txt_tenLoaiDoanhThu.DataBindings.Clear();
                txt_moTaLoaiDoanhThu.DataBindings.Clear();
                txt_tongTienDoanhThu.DataBindings.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tắt ràng buộc: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void BatDataBindingDataGridViewLoaiDoanhThu()
        {
            try
            {
                // Tắt ràng buộc dữ liệu hiện tại (nếu có)
                TatDataBindingDataGridViewLoaiDoanhThu();

                // Kiểm tra xem DataGridView có dòng nào được chọn không
                if (dgv_dsLoaiDoanhThu.CurrentRow != null)
                {
                    // Kiểm tra giá trị ô trước khi gán cho TextBox để tránh NullReferenceException
                    txt_maLoaiDoanhThu.Text = dgv_dsLoaiDoanhThu.CurrentRow.Cells["MaLoaiDoanhThu"].Value?.ToString() ?? string.Empty;
                    txt_tenLoaiDoanhThu.Text = dgv_dsLoaiDoanhThu.CurrentRow.Cells["TenLoaiDoanhThu"].Value?.ToString() ?? string.Empty;
                    txt_moTaLoaiDoanhThu.Text = dgv_dsLoaiDoanhThu.CurrentRow.Cells["MoTa"].Value?.ToString() ?? string.Empty;
                    txt_tongTienDoanhThu.Text = dgv_dsLoaiDoanhThu.CurrentRow.Cells["TongTien"].Value?.ToString() ?? string.Empty;
                }
                else
                {
                    MessageBox.Show("Không có dòng nào được chọn trong DataGridView!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi bật ràng buộc: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLaiDanhSachLoaiDoanhThu()
        {
            try
            {
                TatDataBindingDataGridViewLoaiDoanhThu();
                dgv_dsLoaiDoanhThu.SelectionChanged -= Dgv_dsLoaiDoanhThu_SelectionChanged;

                // Tải lại danh sách loại doanh thu
                _lstLoaiDoanhThu = _loaiDoanhThuBLL.LayDanhSachLoaiDoanhThu(maSanPham);
                dgv_dsLoaiDoanhThu.DataSource = _lstLoaiDoanhThu;

                dgv_dsLoaiDoanhThu.SelectionChanged += Dgv_dsLoaiDoanhThu_SelectionChanged;

                TatDataBindingDataGridViewLoaiDoanhThu();
                BatDataBindingDataGridViewLoaiDoanhThu();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải lại danh sách loại doanh thu: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDataComboboxLoaiDoanhThu()
        {
            try
            {
                //lấy danh sách loại doanh thu
                List<LoaiDoanhThu> lstLoaiDoanhThu = _loaiDoanhThuBLL.LayDanhSachLoaiDoanhThu(maSanPham);
                if (lstLoaiDoanhThu != null)
                {
                    //gán dữ liệu vào combobox
                    cbo_loaiDoanhThu.DataSource = lstLoaiDoanhThu;
                    cbo_loaiDoanhThu.DisplayMember = "TenLoaiDoanhThu";
                    cbo_loaiDoanhThu.ValueMember = "MaLoaiDoanhThu";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void KhoiTaoLoaiDoanhThu()
        {
            try
            {
                // Kiểm tra xem dgv_dsLoaiDoanhThu có phải là null không
                if (dgv_dsLoaiDoanhThu == null)
                {
                    MessageBox.Show("DataGridView loại doanh thu chưa được khởi tạo.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Đổi tên cột
                dgv_dsLoaiDoanhThu.Columns["MaLoaiDoanhThu"].HeaderText = "Mã loại doanh thu";
                dgv_dsLoaiDoanhThu.Columns["TenLoaiDoanhThu"].HeaderText = "Tên loại doanh thu";
                dgv_dsLoaiDoanhThu.Columns["MoTa"].HeaderText = "Mô tả";
                dgv_dsLoaiDoanhThu.Columns["TongTien"].HeaderText = "Tổng tiền";
                dgv_dsLoaiDoanhThu.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";

                // In đậm tiêu đề cột
                dgv_dsLoaiDoanhThu.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);

                // Căn giữa tiêu đề cột
                dgv_dsLoaiDoanhThu.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Ẩn cột không cần thiết (ví dụ như cột "SanPham" nếu không cần thiết)
                if (dgv_dsLoaiDoanhThu.Columns.Contains("SanPham"))
                {
                    dgv_dsLoaiDoanhThu.Columns["SanPham"].Visible = false;
                }

                // Định dạng cột "TongTien" là tiền
                if (dgv_dsLoaiDoanhThu.Columns.Contains("TongTien"))
                {
                    dgv_dsLoaiDoanhThu.Columns["TongTien"].DefaultCellStyle.Format = "N0"; // Định dạng tiền với dấu phân cách hàng nghìn
                    dgv_dsLoaiDoanhThu.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                }

                // Sửa lại thứ tự hiển thị của cột "MoTa"
                if (dgv_dsLoaiDoanhThu.Columns.Contains("MoTa"))
                {
                    dgv_dsLoaiDoanhThu.Columns["MoTa"].DisplayIndex = dgv_dsLoaiDoanhThu.Columns.Count - 1; // Đưa cột MoTa vào cuối cùng
                }

                // Hiển thị toàn bộ bảng, tự động thay đổi kích thước cột
                dgv_dsLoaiDoanhThu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Cập nhật lại FillWeight cho các cột sao cho tổng cộng = 100
                dgv_dsLoaiDoanhThu.Columns["SoThuTu"].FillWeight = 5;  // Cột STT chiếm 5% chiều rộng
                dgv_dsLoaiDoanhThu.Columns["MaLoaiDoanhThu"].FillWeight = 15;
                dgv_dsLoaiDoanhThu.Columns["TenLoaiDoanhThu"].FillWeight = 15;
                dgv_dsLoaiDoanhThu.Columns["MoTa"].FillWeight = 25;  // MoTa chiếm phần lớn chiều rộng
                dgv_dsLoaiDoanhThu.Columns["TongTien"].FillWeight = 15;
                dgv_dsLoaiDoanhThu.Columns["MaSanPham"].FillWeight = 15; // Cột MaSanPham chiếm phần còn lại

                // Thiết lập tự động xuống dòng cho cột "MoTa" và "TenLoaiDoanhThu"
                if (dgv_dsLoaiDoanhThu.Columns.Contains("MoTa"))
                {
                    dgv_dsLoaiDoanhThu.Columns["MoTa"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                }

                if (dgv_dsLoaiDoanhThu.Columns.Contains("TenLoaiDoanhThu"))
                {
                    dgv_dsLoaiDoanhThu.Columns["TenLoaiDoanhThu"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                }

                // Tự động điều chỉnh chiều cao hàng dựa trên nội dung của các ô
                dgv_dsLoaiDoanhThu.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                // Nếu cần, có thể đặt chiều cao tối thiểu cho các hàng
                foreach (DataGridViewRow row in dgv_dsLoaiDoanhThu.Rows)
                {
                    row.Height = Math.Max(row.Height, 30); // Đặt chiều cao tối thiểu cho các hàng
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo DataGridView loại doanh thu: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_dsLoaiDoanhThu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && dgv_dsLoaiDoanhThu.Columns.Contains("SoThuTu"))
                {
                    // Cập nhật số thứ tự cho mỗi dòng
                    dgv_dsLoaiDoanhThu.Rows[e.RowIndex].Cells["SoThuTu"].Value = (e.RowIndex + 1).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật số thứ tự: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiLoaiDoanhThu()
        {
            try
            {
                _loaiDoanhThuBLL = new LoaiDoanhThuBLL();
                // Lấy danh sách loại doanh thu từ BLL (Business Logic Layer)
                var danhSachLoaiDoanhThu = _loaiDoanhThuBLL.LayDanhSachLoaiDoanhThu(maSanPham);

                // Kiểm tra nếu danh sách loại doanh thu không null
                if (danhSachLoaiDoanhThu != null)
                {
                    // Tạo BindingList và gán vào DataSource của DataGridView
                    _bindingListLoaiDoanhThu = new BindingList<LoaiDoanhThu>(danhSachLoaiDoanhThu);
                    dgv_dsLoaiDoanhThu.DataSource = _bindingListLoaiDoanhThu;

                    // Khởi tạo giao diện DataGridView
                    themCotSoThuTu(dgv_dsLoaiDoanhThu);
                    KhoiTaoLoaiDoanhThu();
                   

                    // Đăng ký lại sự kiện RowPostPaint để hiển thị số thứ tự (STT)
                    dgv_dsLoaiDoanhThu.RowPostPaint -= dgv_dsLoaiDoanhThu_RowPostPaint;
                    dgv_dsLoaiDoanhThu.RowPostPaint += dgv_dsLoaiDoanhThu_RowPostPaint;

                    // Refresh và cập nhật giao diện
                    dgv_dsLoaiDoanhThu.Invalidate();
                    dgv_dsLoaiDoanhThu.Refresh();

                    // tính tổng tiền loai doanh thu
                    decimal tongTien = (decimal)danhSachLoaiDoanhThu.Sum(ldt => ldt.TongTien);
                    txt_tongTienLoaiDoanhThu.Text = "Tổng tiền doanh thu "+string.Format("{0:N0} VNĐ", tongTien);
                }
                else
                {
                    // Nếu không có dữ liệu, hiển thị thông báo và làm sạch DataGridView
                    dgv_dsLoaiDoanhThu.DataSource = null;
                    MessageBox.Show("Không có dữ liệu loại doanh thu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có lỗi xảy ra
                MessageBox.Show($"Lỗi khi hiển thị loại doanh thu: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
