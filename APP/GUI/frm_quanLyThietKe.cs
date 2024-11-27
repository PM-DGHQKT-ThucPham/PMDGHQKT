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
    public partial class frm_quanLyThietKe : Form
    {
        private List<ThietKe> danhSachThietKe = new List<ThietKe>();
        public frm_quanLyThietKe()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Người dùng chỉ có thể nhập các ký tự số hoặc dấu chấm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDanhGiaThamMy_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtDanhGiaThamMy_TextChanged(object sender, EventArgs e)
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
                txtMaThietKe.Enabled = true;
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
                ThietKe thietKe = new ThietKe()
                {
                    MaThietKe = txtMaThietKe.Text,
                    MaSanPham = cboSanPham.SelectedValue.ToString(),
                    MoTa = txtMoTa.Text,
                    DanhGiaThamMy = Convert.ToDecimal(txtDanhGiaThamMy.Text),
                    DanhGiaTienDung = Convert.ToDecimal(txtDanhGiaTienDung.Text),
                    MucDoAnhHuong = Convert.ToDecimal(txtMucDoAnhHuong.Text),
                };
                // Thêm thiết kế vào datagridview thietke
                dgvThietKe.DataSource = ThemThietKe(thietKe);
                // Hiện dữ liệu lên các textbox ứng với thiết kế đang được chọn trên datagridview
                if (dgvThietKe.Rows.Count > 0 && dgvThietKe.CurrentRow != null)
                {
                    string maThietKe = dgvThietKe.CurrentRow.Cells["MaThietKe"].Value.ToString();
                    HienDuLieuTextBox(maThietKe);
                }
                themXoaSua.BtnThem.Image = Properties.Resources.icons8_add_35;
                themXoaSua.BtnHuyThem.Enabled = false;
                themXoaSua.BtnSua.Enabled = true;
                themXoaSua.BtnXoa.Enabled = true;
                themXoaSua.BtnLuu.Enabled = true;
                txtMaThietKe.Enabled = false;
            }
        }

        /// <summary>
        /// Kiểm tra các textbox có rỗng không
        /// </summary>
        /// <returns>Trả về true nếu 1 trong các textbox chi tiết là rỗng, false nếu đã điền đầy đủ</returns>
        private bool KiemTraCacTextBoxRong()
        {
            if(txtMaThietKe.Text.Length <= 0)
            {
                return true;
            }
            if (txtDanhGiaThamMy.Text.Length <= 0)
            {
                return true;
            }
            if (txtDanhGiaTienDung.Text.Length <= 0)
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
        /// Thêm thiết kế vào datagridview thiết kế
        /// </summary>
        /// <param name="thietKe">Đối tượng thiết kế cần thêm</param>
        /// <returns>Danh sách thiết kế hiện tại sau khi thêm</returns>
        private object ThemThietKe(ThietKe thietKe)
        {
            // Kiểm tra mã thiết kế trong DataGridView
            foreach (DataGridViewRow row in dgvThietKe.Rows)
            {
                if (row.Cells["MaThietKe"].Value.ToString() == thietKe.MaThietKe)
                {
                    MessageBox.Show("Mã thiết kế đã tồn tại trong danh sách. Vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return dgvThietKe.DataSource; // Giữ nguyên dữ liệu hiện tại
                }
            }

            // Giả định kiểm tra tồn tại trong cơ sở dữ liệu
            if (KiemTraMaThietKeTonTai(thietKe.MaThietKe))
            {
                MessageBox.Show("Mã thiết kế đã tồn tại trong cơ sở dữ liệu. Vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return dgvThietKe.DataSource; // Giữ nguyên dữ liệu hiện tại
            }

            // Nếu không trùng, thêm thiết kế vào danh sách
            danhSachThietKe.Add(thietKe);

            // Cập nhật lại DataGridView
            dgvThietKe.DataSource = null; // Reset lại nguồn dữ liệu
            dgvThietKe.DataSource = danhSachThietKe;
            DinhDangDGVThietKe();

            MessageBox.Show("Thêm thiết kế thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return danhSachThietKe;
        }

        /// <summary>
        /// Kiểm tra mã thiết kế đã tồn tại trong cơ sở dữ liệu chưa
        /// </summary>
        /// <param name="maThietKe"></param>
        /// <returns>Trả về true nếu đã tồn tại, false nếu chưa tồn tại</returns>
        private bool KiemTraMaThietKeTonTai(string maThietKe)
        {
            ThietKeBLL thietKeBLL = new ThietKeBLL();
            bool tonTai = thietKeBLL.LayDanhSachThietKe().Any(x => x.MaThietKe == maThietKe);
            return tonTai;
        }

        /// <summary>
        /// Hiển thị dữ liệu thiết kế lên các textbox dựa trên mã thiết kế
        /// </summary>
        /// <param name="maThietKe"></param>
        private void HienDuLieuTextBox(string maThietKe)
        {
            ThietKe thietKe = LayThietKeTheoMa(maThietKe);
            txtMaThietKe.Text = thietKe.MaThietKe;
            txtDanhGiaThamMy.Text = thietKe.DanhGiaThamMy.ToString();
            txtDanhGiaTienDung.Text = thietKe.DanhGiaTienDung.ToString();
            txtMucDoAnhHuong.Text = thietKe.MucDoAnhHuong.ToString();
            txtMoTa.Text = thietKe.MoTa;
        }

        /// <summary>
        /// Lấy thông tin thiết kế dựa vào mã thiết kế
        /// </summary>
        /// <param name="maThietKe"></param>
        /// <returns></returns>
        private ThietKe LayThietKeTheoMa(string maThietKe)
        {
            ThietKeBLL thietKeBLL = new ThietKeBLL();
            ThietKe thietKe = thietKeBLL.LayDanhSachThietKe().Where(x => x.MaThietKe == maThietKe).FirstOrDefault();
            return thietKe;
        }

        /// <summary>
        /// Xóa dữ liệu trong các textbox
        /// </summary>
        private void XoaDuLieuTextBox()
        {
            txtMaThietKe.Text = "";
            txtDanhGiaThamMy.Text = "";
            txtDanhGiaTienDung.Text = "";
            txtMucDoAnhHuong.Text = "";
            txtMoTa.Text = "";
        }

        /// <summary>
        /// Xử lý sự kiện load form lần đầu tiên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_quanLyThietKe_Load(object sender, EventArgs e)
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
        /// Xử lý sự kiện khi người dùng chọn sản phẩm từ combobox sẽ hiển thị thông tin thiết kế vào datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSanPham.Items.Count > 0)
            {
                string maSanPham = cboSanPham.SelectedValue.ToString();
                LoadDGVThietKe(maSanPham);
            }
            danhSachThietKe = null;
            danhSachThietKe = DanhSachThietKe(cboSanPham.SelectedValue.ToString());
        }

        /// <summary>
        /// Load dữ liệu vào DataGridView hiển thị thông tin thiết kế của sản phẩm
        /// </summary>
        /// <param name="maSanPham"></param>
        private void LoadDGVThietKe(string maSanPham)
        {
            dgvThietKe.DataSource = DanhSachThietKe(maSanPham);
            DinhDangDGVThietKe();
        }

        /// <summary>
        /// Định dạng DataGridView hiển thị thông tin thiết kế
        /// </summary>
        private void DinhDangDGVThietKe()
        {
            // Đặt chế độ tự động fill cho DataGridView
            dgvThietKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThietKe.AllowUserToResizeColumns = false;

            // Đặt tiêu đề cột và ẩn các cột không cần thiết
            dgvThietKe.Columns["MaThietKe"].HeaderText = "Mã thiết kế";
            dgvThietKe.Columns["MaSanPham"].Visible = false;
            dgvThietKe.Columns["MoTa"].HeaderText = "Mô tả";
            dgvThietKe.Columns["DanhGiaThamMy"].HeaderText = "Đánh giá thẩm mỹ";
            dgvThietKe.Columns["DanhGiaTienDung"].HeaderText = "Đánh giá tiện dụng";
            dgvThietKe.Columns["MucDoAnhHuong"].HeaderText = "Mức độ ảnh hưởng";
            dgvThietKe.Columns["HinhAnh"].Visible = false;
            dgvThietKe.Columns["SanPham"].Visible = false;

            // Sắp xếp lại thứ tự các cột (Mô tả là cột cuối cùng)
            dgvThietKe.Columns["MoTa"].DisplayIndex = dgvThietKe.Columns.Count - 1;

            // Căn lề phải cho các cột đánh giá và mức độ ảnh hưởng
            dgvThietKe.Columns["DanhGiaThamMy"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvThietKe.Columns["DanhGiaTienDung"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvThietKe.Columns["MucDoAnhHuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Tăng kích thước cột "Mô tả" để là cột lớn nhất
            dgvThietKe.Columns["MoTa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            foreach (DataGridViewColumn col in dgvThietKe.Columns)
            {
                if (col.Name != "MoTa")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
            }

            // Thiết lập tự động xuống dòng cho cột "Mô tả"
            dgvThietKe.Columns["MoTa"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Đặt chiều cao dòng tự động để phù hợp nội dung
            dgvThietKe.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        /// <summary>
        /// Lấy danh sách thiết kế từ database dựa vào mã sản phẩm
        /// </summary>
        /// <param name="maSanPham">Mã sản phẩm</param>
        /// <returns>Danh sách thiết kế</returns>
        private List<ThietKe> DanhSachThietKe(string maSanPham)
        {
            ThietKeBLL thietKeBLL = new ThietKeBLL();
            List<ThietKe> lstThietKe = new List<ThietKe>();
            lstThietKe = thietKeBLL.LayDanhSachThietKe().Where(x => x.MaSanPham == maSanPham).ToList();
            return lstThietKe;
        }

        /// <summary>
        /// Xử lý sự kiện khi chọn 1 thiết kế trong dgv thì các textbox sẽ hiển thị tương ứng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvThietKe_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvThietKe.Rows.Count > 0)
            {
                DataGridViewRow row = dgvThietKe.CurrentRow;
                if (row != null && row.Cells["MaThietKe"].Value != null)
                {
                    txtMaThietKe.Text = row.Cells["MaThietKe"].Value.ToString();
                    txtMoTa.Text = row.Cells["MoTa"].Value.ToString();
                    txtDanhGiaThamMy.Text = row.Cells["DanhGiaThamMy"].Value.ToString();
                    txtDanhGiaTienDung.Text = row.Cells["DanhGiaTienDung"].Value.ToString();
                    txtMucDoAnhHuong.Text = row.Cells["MucDoAnhHuong"].Value.ToString();
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi người dùng click vào nút Huỷ thêm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void themXoaSua_HuyThemClicked(object sender, EventArgs e)
        {
            string maThietKe = dgvThietKe.CurrentRow.Cells["MaThietKe"].Value.ToString();
            HienDuLieuTextBox(maThietKe);
        }

        /// <summary>
        /// Xử lý sự kiện khi người dùng click vào nút Xoá
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void themXoaSua_XoaClicked(object sender, EventArgs e)
        {
            // Kiểm tra nếu không có dòng nào được chọn
            if (dgvThietKe.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn thiết kế để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã thiết kế từ dòng đang chọn
            string maThietKe = dgvThietKe.CurrentRow.Cells["MaThietKe"].Value.ToString();

            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa thiết kế với mã '{maThietKe}' không?",
                                                  "Xác nhận xóa",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Xóa thiết kế khỏi danh sách
                ThietKe thietKeCanXoa = danhSachThietKe.FirstOrDefault(tk => tk.MaThietKe == maThietKe);
                if (thietKeCanXoa != null)
                {
                    danhSachThietKe.Remove(thietKeCanXoa);

                    // Cập nhật lại DataGridView
                    dgvThietKe.DataSource = null;
                    dgvThietKe.DataSource = danhSachThietKe;
                    DinhDangDGVThietKe();

                    MessageBox.Show("Xóa thiết kế thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thiết kế để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi người dùng click vào nút Lưu
        /// Lấy danh sách thiết kế từ dgv để update vào cơ sở dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void themXoaSua_LuuClicked(object sender, EventArgs e)
        {
            // Lấy danh sách thiết kế từ DataGridView
            List<ThietKe> danhSachThietKe = new List<ThietKe>();

            foreach (DataGridViewRow row in dgvThietKe.Rows)
            {
                // Nếu dòng dữ liệu không phải dòng trống và có mã thiết kế
                if (row.Cells["MaThietKe"].Value != null && !string.IsNullOrEmpty(row.Cells["MaThietKe"].Value.ToString()))
                {
                    ThietKe thietKe = new ThietKe()
                    {
                        MaThietKe = row.Cells["MaThietKe"].Value.ToString(),
                        MaSanPham = row.Cells["MaSanPham"].Value.ToString(),
                        MoTa = row.Cells["MoTa"].Value.ToString(),
                        DanhGiaThamMy = Convert.ToDecimal(row.Cells["DanhGiaThamMy"].Value),
                        DanhGiaTienDung = Convert.ToDecimal(row.Cells["DanhGiaTienDung"].Value),
                        MucDoAnhHuong = Convert.ToDecimal(row.Cells["MucDoAnhHuong"].Value)
                    };
                    danhSachThietKe.Add(thietKe);
                }
            }

            // Gọi phương thức cập nhật danh sách thiết kế vào cơ sở dữ liệu
            ThietKeBLL thietKeBLL = new ThietKeBLL();
            bool ketQua = thietKeBLL.CapNhatThietKeDuaTrenDanhSachThietKe(danhSachThietKe);

            // Nếu cập nhật thành công
            if (ketQua)
            {
                MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Sau khi lưu thành công, cập nhật lại DataGridView với dữ liệu mới
                dgvThietKe.DataSource = null; // Reset lại DataSource
                dgvThietKe.DataSource = danhSachThietKe; // Đặt lại nguồn dữ liệu
                DinhDangDGVThietKe(); // Nếu có phương thức để định dạng lại DataGridView
            }
            else
            {
                MessageBox.Show("Cập nhật thiết kế không thành công. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi người dùng click vào nút Sửa
        /// Thiết kế đang được chọn ở dgv sẽ hiển thị lên các textbox để người dùng chỉnh sửa
        /// Cập nhật thông tin thiết kế dựa vào các textbox có liên quan vào datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void themXoaSua_SuaClicked(object sender, EventArgs e)
        {
            // Kiểm tra nếu người dùng đã chọn một dòng trong DataGridView
            if (dgvThietKe.SelectedRows.Count > 0)
            {
                // Lấy dòng đã chọn trong DataGridView
                DataGridViewRow selectedRow = dgvThietKe.SelectedRows[0];

                // Lấy thông tin từ các TextBox
                string maThietKe = txtMaThietKe.Text;
                string maSanPham = cboSanPham.SelectedValue.ToString();
                string moTa = txtMoTa.Text;
                decimal danhGiaThamMy = Convert.ToDecimal(txtDanhGiaThamMy.Text);
                decimal danhGiaTienDung = Convert.ToDecimal(txtDanhGiaTienDung.Text);
                decimal mucDoAnhHuong = Convert.ToDecimal(txtMucDoAnhHuong.Text);

                // Cập nhật lại các giá trị vào DataGridView
                selectedRow.Cells["MaThietKe"].Value = maThietKe;
                selectedRow.Cells["MaSanPham"].Value = maSanPham;
                selectedRow.Cells["MoTa"].Value = moTa;
                selectedRow.Cells["DanhGiaThamMy"].Value = danhGiaThamMy;
                selectedRow.Cells["DanhGiaTienDung"].Value = danhGiaTienDung;
                selectedRow.Cells["MucDoAnhHuong"].Value = mucDoAnhHuong;

                // Cập nhật lại danh sách thiết kế (danhSachThietKe) nếu cần thiết
                var thietKeToUpdate = danhSachThietKe.FirstOrDefault(tk => tk.MaThietKe == maThietKe);
                if (thietKeToUpdate != null)
                {
                    thietKeToUpdate.MaThietKe = maThietKe;
                    thietKeToUpdate.MaSanPham = maSanPham;
                    thietKeToUpdate.MoTa = moTa;
                    thietKeToUpdate.DanhGiaThamMy = danhGiaThamMy;
                    thietKeToUpdate.DanhGiaTienDung = danhGiaTienDung;
                    thietKeToUpdate.MucDoAnhHuong = mucDoAnhHuong;
                }

                // Hiển thị thông báo thành công
                MessageBox.Show("Cập nhật thiết kế thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Sau khi lưu thành công, cập nhật lại DataGridView với dữ liệu mới
                dgvThietKe.Refresh(); // Refresh lại DataGridView
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một thiết kế để chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
