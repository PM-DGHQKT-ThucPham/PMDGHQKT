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
    public partial class frm_quanLyHieuSuat : Form
    {
        private List<HieuSuat> danhSachHieuSuat = new List<HieuSuat>();
        public frm_quanLyHieuSuat()
        {
            InitializeComponent();
            this.themXoaSua.ThemClicked += themXoaSua_ThemClicked;
        }

        /// <summary>
        /// Người dùng chỉ có thể nhập các ký tự số hoặc dấu chấm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDanhGiaChucNang_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Cho phép nhập số, phím xóa (Backspace), và dấu chấm (.) để nhập số thập phân
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Ngăn ký tự không hợp lệ
            }

            // Ngăn người dùng nhập nhiều hơn một dấu chấm
            if (e.KeyChar == '.' && textBox.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Nếu nhập số lớn hơn 10, một thông báo sẽ hiện ra và giá trị sẽ tự động reset về 10.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDanhGiaChucNang_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (double.TryParse(textBox.Text, out double value))
            {
                // Kiểm tra giá trị nhập vào phải <= 10
                if (value > 10)
                {
                    MessageBox.Show("Giá trị không được lớn hơn 10.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox.Text = "10"; // Reset về giá trị tối đa
                    textBox.SelectionStart = textBox.Text.Length; // Đặt con trỏ ở cuối text
                }
            }
            else if (!string.IsNullOrEmpty(textBox.Text))
            {
                // Nếu giá trị không phải số hợp lệ, xóa text
                textBox.Text = "";
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi người dùng click vào nút Thêm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void themXoaSua_ThemClicked(object sender, EventArgs e)
        {
            // Nếu nút huỷ thêm đang ẩn thì hiện lên, ẩn các nút khác
            if (themXoaSua.BtnHuyThem.Enabled == false)
            {
                themXoaSua.BtnHuyThem.Enabled = true;
                themXoaSua.BtnThem.Image = Properties.Resources.icons8_tick_35;
                themXoaSua.BtnSua.Enabled = false;
                themXoaSua.BtnXoa.Enabled = false;
                themXoaSua.BtnLuu.Enabled = false;
                txtMaHieuSuat.Enabled = true;
                // Xoá dữ liệu các textbox liên quan
                XoaDuLieuTextBox();
            }
            else
            {
                // Lấy thông tin từ các textbox để tạo ra 1 đối tượng thiết kế
                if (KiemTraCacTextBoxRong())
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin thiết kế!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                HieuSuat hs = new HieuSuat()
                {
                    MaHieuSuat = txtMaHieuSuat.Text,
                    MaSanPham = cboSanPham.SelectedValue.ToString(),
                    DanhGiaChucNang = decimal.Parse(txtDanhGiaChucNang.Text),
                    DanhGiaTocDo = decimal.Parse(txtDanhGiaTocDo.Text),
                    MucDoAnhHuong = decimal.Parse(txtMucDoAnhHuong.Text),
                    MoTa = txtMoTa.Text
                };

                // Thêm thiết kế vào datagridview thietke
                dgvHieuSuat.DataSource = ThemHieuSuat(hs);
                // Hiện dữ liệu lên các textbox ứng với thiết kế đang được chọn trên datagridview
                if (dgvHieuSuat.Rows.Count > 0 && dgvHieuSuat.CurrentRow != null)
                {
                    string maHieuSuat = dgvHieuSuat.CurrentRow.Cells["MaHieuSuat"].Value.ToString();
                    HienDuLieuTextBox(maHieuSuat);
                }
                themXoaSua.BtnThem.Image = Properties.Resources.icons8_add_35;
                themXoaSua.BtnHuyThem.Enabled = false;
                themXoaSua.BtnSua.Enabled = true;
                themXoaSua.BtnXoa.Enabled = true;
                themXoaSua.BtnLuu.Enabled = true;
                txtMaHieuSuat.Enabled = false;
            }
        }

        /// <summary>
        /// Hiện dữ liệu hiệu suất đang được chọn trên DataGridView lên các textbox
        /// </summary>
        /// <param name="maHieuSuat"></param>
        private void HienDuLieuTextBox(string maHieuSuat)
        {
            if (dgvHieuSuat.DataSource != null)
            {
                //HieuSuat hs = LayHieuSuatTheoMa(maHieuSuat);
                //if (hs != null)
                {
                    txtMaHieuSuat.Text = dgvHieuSuat.CurrentRow.Cells[0].Value.ToString();
                    //txtDanhGiaChucNang.Text = hs.DanhGiaChucNang.ToString();
                    //txtDanhGiaTocDo.Text = hs.DanhGiaTocDo.ToString();
                    //txtMucDoAnhHuong.Text = hs.MucDoAnhHuong.ToString();
                    //txtMoTa.Text = hs.MoTa;
                }
                //else
                {
                    MessageBox.Show("Không tìm thấy hiệu suất với mã này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Lấy thông tin hiệu suất dựa vào mã hiệu suất
        /// </summary>
        /// <param name="maHieuSuat"></param>
        /// <returns></returns>
        private HieuSuat LayHieuSuatTheoMa(string maHieuSuat)
        {
            HieuSuatBLL hieuSuatBLL = new HieuSuatBLL();
            return hieuSuatBLL.LayDanhSachHieuSuat().Where(x => x.MaHieuSuat == maHieuSuat).FirstOrDefault();
        }

        /// <summary>
        /// Xóa dữ liệu trong các textbox
        /// </summary>
        private void XoaDuLieuTextBox()
        {
            txtMaHieuSuat.Text = "";
            txtDanhGiaChucNang.Text = "";
            txtDanhGiaTocDo.Text = "";
            txtMucDoAnhHuong.Text = "";
            txtMoTa.Text = "";
        }

        /// <summary>
        /// Kiểm tra các textbox có rỗng không
        /// </summary>
        /// <returns>Trả về true nếu 1 trong các textbox chi tiết là rỗng, false nếu đã điền đầy đủ</returns>
        private bool KiemTraCacTextBoxRong()
        {
            if (txtMaHieuSuat.Text.Length <= 0)
            {
                return true;
            }
            if (txtDanhGiaChucNang.Text.Length <= 0)
            {
                return true;
            }
            if (txtDanhGiaTocDo.Text.Length <= 0)
            {
                return true;
            }
            if (txtMucDoAnhHuong.Text.Length <= 0)
            {
                return true;
            }
            if (txtMoTa.Text.Length <= 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Thêm hiệu suất vào datagridview hiệu suất
        /// </summary>
        /// <param name="thietKe">Đối tượng thiết kế cần thêm</param>
        /// <returns>Danh sách thiết kế hiện tại sau khi thêm</returns>
        private object ThemHieuSuat(HieuSuat hieuSuat)
        {
            // Kiểm tra mã thiết kế trong DataGridView
            foreach (DataGridViewRow row in dgvHieuSuat.Rows)
            {
                if (row.Cells["MaHieuSuat"].Value.ToString() == hieuSuat.MaHieuSuat)
                {
                    MessageBox.Show("Mã hiệu suất đã tồn tại trong danh sách. Vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return dgvHieuSuat.DataSource; // Giữ nguyên dữ liệu hiện tại
                }
            }

            // Giả định kiểm tra tồn tại trong cơ sở dữ liệu
            if (KiemTraMaHieuSuatTonTai(hieuSuat.MaHieuSuat))
            {
                MessageBox.Show("Mã hiệu suất đã tồn tại trong cơ sở dữ liệu. Vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return dgvHieuSuat.DataSource; // Giữ nguyên dữ liệu hiện tại
            }

            // Nếu không trùng, thêm thiết kế vào danh sách
            danhSachHieuSuat.Add(hieuSuat);

            // Cập nhật lại DataGridView
            dgvHieuSuat.DataSource = null; // Reset lại nguồn dữ liệu
            dgvHieuSuat.DataSource = danhSachHieuSuat;
            DinhDangDGVHieuSuat();

            MessageBox.Show("Thêm thiết kế thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return danhSachHieuSuat;
        }

        /// <summary>
        /// Định dạng DataGridView hiển thị thông tin hiệu suất
        /// </summary>
        private void DinhDangDGVHieuSuat()
        {
            // Đặt chế độ tự động fill cho DataGridView
            dgvHieuSuat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHieuSuat.AllowUserToResizeColumns = false;

            // Đặt tiêu đề cột và ẩn các cột không cần thiết
            dgvHieuSuat.Columns["MaHieuSuat"].HeaderText = "Mã hiệu suất";
            dgvHieuSuat.Columns["MaSanPham"].Visible = false;
            dgvHieuSuat.Columns["MoTa"].HeaderText = "Mô tả";
            dgvHieuSuat.Columns["DanhGiaChucNang"].HeaderText = "Đánh giá chức năng";
            dgvHieuSuat.Columns["DanhGiaTocDo"].HeaderText = "Đánh giá tốc độ";
            dgvHieuSuat.Columns["MucDoAnhHuong"].HeaderText = "Mức độ ảnh hưởng";
            dgvHieuSuat.Columns["SanPham"].Visible = false;

            // Sắp xếp lại thứ tự các cột (Mô tả là cột cuối cùng)
            dgvHieuSuat.Columns["MoTa"].DisplayIndex = dgvHieuSuat.Columns.Count - 1;

            // Căn lề phải cho các cột đánh giá và mức độ ảnh hưởng
            dgvHieuSuat.Columns["DanhGiaChucNang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvHieuSuat.Columns["DanhGiaTocDo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvHieuSuat.Columns["MucDoAnhHuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Tăng kích thước cột "Mô tả" để là cột lớn nhất
            dgvHieuSuat.Columns["MoTa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            foreach (DataGridViewColumn col in dgvHieuSuat.Columns)
            {
                if (col.Name != "MoTa")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
            }

            // Thiết lập tự động xuống dòng cho cột "Mô tả"
            dgvHieuSuat.Columns["MoTa"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Đặt chiều cao dòng tự động để phù hợp nội dung
            dgvHieuSuat.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        /// <summary>
        /// Kiểm tra mã hiệu suất đã tồn tại trong cơ sở dữ liệu chưa
        /// </summary>
        /// <param name="maThietKe"></param>
        /// <returns>Trả về true nếu đã tồn tại, false nếu chưa tồn tại</returns>
        private bool KiemTraMaHieuSuatTonTai(string maHieuSuat)
        {
            HieuSuatBLL hieuSuatBLL = new HieuSuatBLL();
            bool tonTai = hieuSuatBLL.LayDanhSachHieuSuat().Any(x => x.MaHieuSuat == maHieuSuat);
            return tonTai;
        }

        /// <summary>
        /// Xử lý sự kiện khi form được load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_quanLyHieuSuat_Load(object sender, EventArgs e)
        {
            // Load dữ liệu vào combobox SanPham
            cboSanPham.DataSource = DanhSachSanPham();
            cboSanPham.DisplayMember = "TenSanPham";
            cboSanPham.ValueMember = "MaSanPham";
        }

        /// <summary>
        /// Lấy danh sách sản phẩm từ database
        /// </summary>
        /// <returns>Trả về danh sách sản phẩm từ database</returns>
        private List<SanPham> DanhSachSanPham()
        {
            SanPhamBLL spBLL = new SanPhamBLL();
            List<SanPham> lstSanPham = new List<SanPham>();
            lstSanPham = spBLL.LayDanhSachSanPham();
            return lstSanPham;
        }

        /// <summary>
        /// Xử lý sự kiện khi người dùng chọn sản phẩm khác
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSanPham.Items.Count > 0)
            {
                string maSanPham = cboSanPham.SelectedValue.ToString();
                LoadDGVHieuSuat(maSanPham);
            }
            danhSachHieuSuat = null;
            danhSachHieuSuat = DanhSachHieuSuat(cboSanPham.SelectedValue.ToString());
        }

        /// <summary>
        /// Load dữ liệu hiệu suất vào DataGridView hiệu suất
        /// </summary>
        /// <param name="maSanPham"></param>
        private void LoadDGVHieuSuat(string maSanPham)
        {
            dgvHieuSuat.DataSource = DanhSachHieuSuat(maSanPham);
            DinhDangDGVHieuSuat();
        }

        /// <summary>
        /// Lấy danh sách hiệu suất từ database dựa vào mã sản phẩm
        /// </summary>
        /// <param name="maSanPham"></param>
        /// <returns></returns>
        private List<HieuSuat> DanhSachHieuSuat(string maSanPham)
        {
            HieuSuatBLL hieuSuat = new HieuSuatBLL();
            return hieuSuat.LayDanhSachHieuSuat().Where(x => x.MaSanPham == maSanPham).ToList();
        }

        /// <summary>
        /// Hiển thị dữ liệu hiệu suất lên các textbox khi người dùng chọn dòng trên DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvHieuSuat_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHieuSuat.Rows.Count > 0)
            {
                DataGridViewRow row = dgvHieuSuat.CurrentRow;
                if (row != null && row.Cells["MaHieuSuat"].Value != null)
                {
                    txtMaHieuSuat.Text = row.Cells["MaHieuSuat"].Value.ToString();
                    txtMoTa.Text = row.Cells["MoTa"].Value.ToString();
                    txtDanhGiaChucNang.Text = row.Cells["DanhGiaChucNang"].Value.ToString();
                    txtDanhGiaTocDo.Text = row.Cells["DanhGiaTocDo"].Value.ToString();
                    txtMucDoAnhHuong.Text = row.Cells["MucDoAnhHuong"].Value.ToString();
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi người dùng click vào nút Huỷ thêm sẽ hiện dữ liệu lên textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void themXoaSua_HuyThemClicked(object sender, EventArgs e)
        {
            string maHieuSuat = dgvHieuSuat.CurrentRow.Cells["MaHieuSuat"].Value.ToString();
            HienDuLieuTextBox(maHieuSuat);
        }

        /// <summary>
        /// Xử lý sự kiện khi người dùng click vào nút Xoá
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void themXoaSua_XoaClicked(object sender, EventArgs e)
        {
            // Kiểm tra nếu không có dòng nào được chọn
            if (dgvHieuSuat.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn hiệu suất để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã thiết kế từ dòng đang chọn
            string maHieuSuat = dgvHieuSuat.CurrentRow.Cells["MaHieuSuat"].Value.ToString();

            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa hiệu suất với mã '{maHieuSuat}' không?",
                                                  "Xác nhận xóa",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Xóa hiệu suất khỏi danh sách
                HieuSuat hieuSuatCanXoa = danhSachHieuSuat.FirstOrDefault(hs => hs.MaHieuSuat == maHieuSuat);
                if (hieuSuatCanXoa != null)
                {
                    danhSachHieuSuat.Remove(hieuSuatCanXoa);

                    // Cập nhật lại DataGridView
                    dgvHieuSuat.DataSource = null;
                    dgvHieuSuat.DataSource = danhSachHieuSuat;
                    DinhDangDGVHieuSuat();

                    MessageBox.Show("Xóa hiệu suất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hiệu suất để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi người dùng click vào nút Lưu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void themXoaSua_LuuClicked(object sender, EventArgs e)
        {
            // Lấy danh sách hiệu suất từ DataGridView
            List<HieuSuat> danhSachHieuSuat = new List<HieuSuat>();

            foreach (DataGridViewRow row in dgvHieuSuat.Rows)
            {
                // Nếu dòng dữ liệu không phải dòng trống và có mã hiệu suất
                if (row.Cells["MaHieuSuat"].Value != null && !string.IsNullOrEmpty(row.Cells["MaHieuSuat"].Value.ToString()))
                {
                    HieuSuat hieuSuat = new HieuSuat()
                    {
                        MaHieuSuat = row.Cells["MaHieuSuat"].Value.ToString(),
                        MaSanPham = row.Cells["MaSanPham"].Value.ToString(),
                        MoTa = row.Cells["MoTa"].Value.ToString(),
                        DanhGiaChucNang = Convert.ToDecimal(row.Cells["DanhGiaChucNang"].Value),
                        DanhGiaTocDo = Convert.ToDecimal(row.Cells["DanhGiaTocDo"].Value),
                        MucDoAnhHuong = Convert.ToDecimal(row.Cells["MucDoAnhHuong"].Value)
                    };
                    danhSachHieuSuat.Add(hieuSuat);
                }
            }

            // Gọi phương thức cập nhật danh sách hiệu suất vào cơ sở dữ liệu         
            HieuSuatBLL hieuSuatBLL = new HieuSuatBLL();
            bool ketQuaHieuSuat = hieuSuatBLL.CapNhatHieuSuatDuaTrenDanhSachHieuSuat(danhSachHieuSuat);

            // Nếu cập nhật thành công
            if (ketQuaHieuSuat)
            {
                MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Sau khi lưu thành công, cập nhật lại DataGridView với dữ liệu mới
                dgvHieuSuat.DataSource = null; // Reset lại DataSource
                dgvHieuSuat.DataSource = danhSachHieuSuat; // Đặt lại nguồn dữ liệu
                DinhDangDGVHieuSuat(); // Nếu có phương thức để định dạng lại DataGridView
            }
            else
            {
                MessageBox.Show("Cập nhật hiệu suất không thành công. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi người dùng click vào nút Sửa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void themXoaSua_SuaClicked(object sender, EventArgs e)
        {
            // Kiểm tra nếu người dùng đã chọn một dòng trong DataGridView
            if (dgvHieuSuat.SelectedRows.Count > 0)
            {
                // Lấy dòng đã chọn trong DataGridView
                DataGridViewRow selectedRow = dgvHieuSuat.SelectedRows[0];

                // Lấy thông tin từ các TextBox
                string maHieuSuat = txtMaHieuSuat.Text;
                string maSanPham = cboSanPham.SelectedValue.ToString();
                string moTa = txtMoTa.Text;
                decimal danhGiaChucNang = Convert.ToDecimal(txtDanhGiaChucNang.Text);
                decimal danhGiaTocDo = Convert.ToDecimal(txtDanhGiaTocDo.Text);
                decimal mucDoAnhHuong = Convert.ToDecimal(txtMucDoAnhHuong.Text);

                // Cập nhật lại các giá trị vào DataGridView
                selectedRow.Cells["MaHieuSuat"].Value = maHieuSuat;
                selectedRow.Cells["MaSanPham"].Value = maSanPham;
                selectedRow.Cells["MoTa"].Value = moTa;
                selectedRow.Cells["DanhGiaChucNang"].Value = danhGiaChucNang;
                selectedRow.Cells["DanhGiaTocDo"].Value = danhGiaTocDo;
                selectedRow.Cells["MucDoAnhHuong"].Value = mucDoAnhHuong;

                // Cập nhật lại danh sách hiệu suất (danhDachHieuSuat) nếu cần thiết
                var hieuSuatToUpdate = danhSachHieuSuat.FirstOrDefault(hs => hs.MaHieuSuat == maHieuSuat);
                if (hieuSuatToUpdate != null)
                {
                    hieuSuatToUpdate.MaHieuSuat = maHieuSuat;
                    hieuSuatToUpdate.MaSanPham = maSanPham;
                    hieuSuatToUpdate.MoTa = moTa;
                    hieuSuatToUpdate.DanhGiaChucNang = danhGiaChucNang;
                    hieuSuatToUpdate.DanhGiaTocDo = danhGiaTocDo;
                    hieuSuatToUpdate.MucDoAnhHuong = mucDoAnhHuong;
                }

                // Hiển thị thông báo thành công
                MessageBox.Show("Cập nhật hiệu suất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Sau khi lưu thành công, cập nhật lại DataGridView với dữ liệu mới
                dgvHieuSuat.Refresh(); // Refresh lại DataGridView
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hiệu suất để chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
