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
    public partial class frm_quanLyGiaCa : Form
    {
        List<GiaCa> danhSachGiaCaCuaSanPham = new List<GiaCa>();
        public frm_quanLyGiaCa()
        {
            InitializeComponent();
        }

        private void txtDanhGiaGiaTri_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDanhGiaGiaTri_TextChanged(object sender, EventArgs e)
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
                txtMaGiaCa.Enabled = true;
                // Xoá dữ liệu các textbox liên quan
                XoaDuLieuTextBox();
            }
            else
            {
                // Lấy thông tin từ các textbox để tạo ra 1 đối tượng giá cả
                if (KiemTraCacTextBoxRong())
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin giá cả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                GiaCa gc = new GiaCa()
                {
                    MaGiaCa = txtMaGiaCa.Text,
                    MaSanPham = cboSanPham.SelectedValue.ToString(),
                    MoTa = txtMoTa.Text,
                    DanhGiaGiaTri = decimal.Parse(txtDanhGiaGiaTri.Text),
                    ChiPhiBaoTri = decimal.Parse(txtChiPhiBaoTri.Text),
                    MucDoAnhHuong = decimal.Parse(txtMucDoAnhHuong.Text)
                };

                // Thêm giá cả vào dgvGiaCa
                dgvGiaCa.DataSource = ThemGiaCa(gc);
                // Hiện dữ liệu lên các textbox ứng với thiết kế đang được chọn trên datagridview
                if (dgvGiaCa.Rows.Count > 0 && dgvGiaCa.CurrentRow != null)
                {
                    string maGiaCa = dgvGiaCa.CurrentRow.Cells["MaGiaCa"].Value.ToString();
                    HienDuLieuTextBox(maGiaCa);
                }
                themXoaSua.BtnThem.Image = Properties.Resources.icons8_add_35;
                themXoaSua.BtnHuyThem.Enabled = false;
                themXoaSua.BtnSua.Enabled = true;
                themXoaSua.BtnXoa.Enabled = true;
                themXoaSua.BtnLuu.Enabled = true;
                txtMaGiaCa.Enabled = false;
            }
        }

        private void HienDuLieuTextBox(string maGiaCa)
        {
            GiaCa gc = LayGiaCaTheoMa(maGiaCa);
            if (gc != null)
            {
                txtMaGiaCa.Text = gc.MaGiaCa;
                txtDanhGiaGiaTri.Text = Convert.ToString(gc.DanhGiaGiaTri);
                txtChiPhiBaoTri.Text = Convert.ToString(gc.ChiPhiBaoTri);
                txtMucDoAnhHuong.Text = Convert.ToString(gc.MucDoAnhHuong);
                txtMoTa.Text = gc.MoTa;
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Lấy giá cả theo mã giá cả
        /// </summary>
        /// <param name="maGiaCa"></param>
        /// <returns></returns>
        private GiaCa LayGiaCaTheoMa(string maGiaCa)
        {
            GiaCaBLL giaCaBLL = new GiaCaBLL();
            return giaCaBLL.LayDanhSachGiaCa().FirstOrDefault(x => x.MaGiaCa == maGiaCa);
        }

        private object ThemGiaCa(GiaCa gc)
        {
            // Kiểm tra mã giá cả trong DataGridView
            foreach (DataGridViewRow row in dgvGiaCa.Rows)
            {
                if (row.Cells["MaGiaCa"].Value.ToString() == gc.MaGiaCa)
                {
                    MessageBox.Show("Mã giá cả đã tồn tại trong danh sách. Vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return dgvGiaCa.DataSource; // Giữ nguyên dữ liệu hiện tại
                }
            }

            // Giả định kiểm tra tồn tại trong cơ sở dữ liệu
            if (KiemTraMaGiaCaTonTai(gc.MaGiaCa))
            {
                MessageBox.Show("Mã giá cả đã tồn tại trong cơ sở dữ liệu. Vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return dgvGiaCa.DataSource; // Giữ nguyên dữ liệu hiện tại
            }

            // Nếu không trùng, thêm giá cả vào danh sách
            danhSachGiaCaCuaSanPham.Add(gc);

            // Cập nhật lại DataGridView
            dgvGiaCa.DataSource = null; // Reset lại nguồn dữ liệu
            dgvGiaCa.DataSource = danhSachGiaCaCuaSanPham;
            DinhDangDGVGiaCa();

            MessageBox.Show("Thêm giá cả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return danhSachGiaCaCuaSanPham;
        }

        /// <summary>
        /// Định dạng DataGridView hiển thị danh sách giá cả
        /// </summary>
        private void DinhDangDGVGiaCa()
        {
            // Đặt chế độ tự động fill cho DataGridView
            dgvGiaCa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGiaCa.AllowUserToResizeColumns = false;

            // Đặt tiêu đề cột và ẩn các cột không cần thiết
            dgvGiaCa.Columns["MaGiaCa"].HeaderText = "Mã giá cả";
            dgvGiaCa.Columns["MaSanPham"].Visible = false;
            dgvGiaCa.Columns["MoTa"].HeaderText = "Mô tả";
            dgvGiaCa.Columns["DanhGiaGiaTri"].HeaderText = "Đánh giá giá trị";
            dgvGiaCa.Columns["ChiPhiBaoTri"].HeaderText = "Đánh giá chi phí bảo trì";
            dgvGiaCa.Columns["MucDoAnhHuong"].HeaderText = "Mức độ ảnh hưởng";
            dgvGiaCa.Columns["SanPham"].Visible = false;

            // Sắp xếp lại thứ tự các cột (Mô tả là cột cuối cùng)
            dgvGiaCa.Columns["MoTa"].DisplayIndex = dgvGiaCa.Columns.Count - 1;

            // Căn lề phải cho các cột đánh giá và mức độ ảnh hưởng
            dgvGiaCa.Columns["DanhGiaGiaTri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvGiaCa.Columns["ChiPhiBaoTri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvGiaCa.Columns["MucDoAnhHuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Tăng kích thước cột "Mô tả" để là cột lớn nhất
            dgvGiaCa.Columns["MoTa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            foreach (DataGridViewColumn col in dgvGiaCa.Columns)
            {
                if (col.Name != "MoTa")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
            }

            // Thiết lập tự động xuống dòng cho cột "Mô tả"
            dgvGiaCa.Columns["MoTa"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Đặt chiều cao dòng tự động để phù hợp nội dung
            dgvGiaCa.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        /// <summary>
        /// Kiểm tra sự tồn tại của giá cả trong database
        /// </summary>
        /// <param name="maGiaCa"></param>
        /// <returns>true nếu có tồn tại, false nếu không tồn tại</returns>
        private bool KiemTraMaGiaCaTonTai(string maGiaCa)
        {
            GiaCaBLL giaCaBLL = new GiaCaBLL();
            bool tonTai = giaCaBLL.LayDanhSachGiaCa().Any(x => x.MaGiaCa == maGiaCa);
            return tonTai;
        }

        /// <summary>
        /// Xóa dữ liệu trong các textbox
        /// </summary>
        private void XoaDuLieuTextBox()
        {
            txtMaGiaCa.Text = "";
            txtDanhGiaGiaTri.Text = "";
            txtChiPhiBaoTri.Text = "";
            txtMucDoAnhHuong.Text = "";
            txtMoTa.Text = "";
        }

        /// <summary>
        /// Kiểm tra các textbox có rỗng không
        /// </summary>
        /// <returns>Trả về true nếu 1 trong các textbox chi tiết là rỗng, false nếu đã điền đầy đủ</returns>
        private bool KiemTraCacTextBoxRong()
        {
            if (txtMaGiaCa.Text.Length <= 0)
            {
                return true;
            }
            if (txtDanhGiaGiaTri.Text.Length <= 0)
            {
                return true;
            }
            if (txtChiPhiBaoTri.Text.Length <= 0)
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

        private void frm_quanLyGiaCa_Load(object sender, EventArgs e)
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

        private void cboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSanPham.Items.Count > 0)
            {
                string maSanPham = ((SanPham)cboSanPham.SelectedItem).MaSanPham;
                LoadDGVGiaCa(maSanPham);
            }
            danhSachGiaCaCuaSanPham = null;
            danhSachGiaCaCuaSanPham = DanhSachGiaCa(cboSanPham.SelectedValue.ToString());
        }

        /// <summary>
        /// Lấy danh sách giá cả từ database
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private List<GiaCa> DanhSachGiaCa(string v)
        {
            GiaCaBLL giaCaBLL = new GiaCaBLL();
            return giaCaBLL.LayDanhSachGiaCa().Where(x => x.MaSanPham == v).ToList();
        }

        /// <summary>
        /// Load dữ liệu giá cả vào DataGridView giá cả
        /// </summary>
        /// <param name="maSanPham"></param>
        private void LoadDGVGiaCa(string maSanPham)
        {
            danhSachGiaCaCuaSanPham = DanhSachGiaCa(maSanPham);
            dgvGiaCa.DataSource = null;
            dgvGiaCa.DataSource = danhSachGiaCaCuaSanPham;
            DinhDangDGVGiaCa();
        }

        /// <summary>
        /// Hiển thị dữ liệu giá cả lên các textbox khi người dùng chọn dòng trên DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvGiaCa_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGiaCa.Rows.Count > 0)
            {
                DataGridViewRow row = dgvGiaCa.CurrentRow;
                if (row != null && row.Cells["MaGiaCa"].Value != null)
                {
                    txtMaGiaCa.Text = row.Cells["MaGiaCa"].Value.ToString();
                    txtMoTa.Text = row.Cells["MoTa"].Value.ToString();
                    txtDanhGiaGiaTri.Text = row.Cells["DanhGiaGiaTri"].Value.ToString();
                    txtChiPhiBaoTri.Text = row.Cells["ChiPhiBaoTri"].Value.ToString();
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
            string maGiaCa = dgvGiaCa.CurrentRow.Cells["MaGiaCa"].Value.ToString();
            HienDuLieuTextBox(maGiaCa);
        }

        /// <summary>
        /// Xử lý sự kiện khi người dùng click vào nút Xoá
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void themXoaSua_XoaClicked(object sender, EventArgs e)
        {
            // Kiểm tra nếu không có dòng nào được chọn
            if (dgvGiaCa.CurrentRow.Cells == null)
            {
                MessageBox.Show("Vui lòng chọn giá cả để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã giá cả từ dòng đang chọn
            string maGiaCa = dgvGiaCa.CurrentRow.Cells["MaGiaCa"].Value.ToString();

            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa giá cả với mã '{maGiaCa}' không?",
                                                  "Xác nhận xóa",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Xóa giá cả khỏi danh sách
                GiaCa giaCaCanXoa = danhSachGiaCaCuaSanPham.FirstOrDefault(gc => gc.MaGiaCa == maGiaCa);  
                
                if (giaCaCanXoa != null)
                {
                    danhSachGiaCaCuaSanPham.Remove(giaCaCanXoa);

                    // Cập nhật lại DataGridView
                    dgvGiaCa.DataSource = null;
                    dgvGiaCa.DataSource = danhSachGiaCaCuaSanPham;
                    DinhDangDGVGiaCa();

                    MessageBox.Show("Xóa giá cả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy giá cả để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // Lấy danh sách giá cả từ DataGridView
            List<GiaCa> danhSachGiaCa = new List<GiaCa>();

            foreach (DataGridViewRow row in dgvGiaCa.Rows)
            {
                // Nếu dòng dữ liệu không phải dòng trống và có mã giá cả
                if (row.Cells["MaGiaCa"].Value != null && !string.IsNullOrEmpty(row.Cells["MaGiaCa"].Value.ToString()))
                {
                    GiaCa giaCa = new GiaCa()
                    {
                        MaGiaCa = row.Cells["MaGiaCa"].Value.ToString(),
                        MaSanPham = row.Cells["MaSanPham"].Value.ToString(),
                        MoTa = row.Cells["MoTa"].Value.ToString(),
                        DanhGiaGiaTri = Convert.ToDecimal(row.Cells["DanhGiaGiaTri"].Value),
                        ChiPhiBaoTri = Convert.ToDecimal(row.Cells["ChiPhiBaoTri"].Value),
                        MucDoAnhHuong = Convert.ToDecimal(row.Cells["MucDoAnhHuong"].Value)
                    };
                    danhSachGiaCa.Add(giaCa);
                }
            }

            // Gọi phương thức cập nhật danh sách giá cả vào cơ sở dữ liệu
            string maSanPham = dgvGiaCa.CurrentRow.Cells["MaSanPham"].Value.ToString();
            GiaCaBLL giaCaBLL = new GiaCaBLL();
            bool ketQuaGiaCa = giaCaBLL.CapNhatGiaCaDuaTrenDanhSachGiaCa(danhSachGiaCa, maSanPham);

            // Nếu cập nhật thành công
            if (ketQuaGiaCa)
            {
                MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Sau khi lưu thành công, cập nhật lại DataGridView với dữ liệu mới
                dgvGiaCa.DataSource = null; // Reset lại DataSource
                dgvGiaCa.DataSource = danhSachGiaCa; // Đặt lại nguồn dữ liệu
                DinhDangDGVGiaCa(); // Nếu có phương thức để định dạng lại DataGridView
            }
            else
            {
                MessageBox.Show("Cập nhật giá cả không thành công. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (dgvGiaCa.SelectedRows.Count > 0)
            {
                // Lấy dòng đã chọn trong DataGridView
                DataGridViewRow selectedRow = dgvGiaCa.SelectedRows[0];

                // Lấy thông tin từ các TextBox
                string maGiaCa = txtMaGiaCa.Text;
                string maSanPham = cboSanPham.SelectedValue.ToString();
                string moTa = txtMoTa.Text;
                decimal danhGiaGiaTri = Convert.ToDecimal(txtDanhGiaGiaTri.Text);
                decimal chiPhiBaoTri = Convert.ToDecimal(txtChiPhiBaoTri.Text);
                decimal mucDoAnhHuong = Convert.ToDecimal(txtMucDoAnhHuong.Text);

                // Cập nhật lại các giá trị vào DataGridView
                selectedRow.Cells["MaGiaCa"].Value = maGiaCa;
                selectedRow.Cells["MaSanPham"].Value = maSanPham;
                selectedRow.Cells["MoTa"].Value = moTa;
                selectedRow.Cells["DanhGiaGiaTri"].Value = danhGiaGiaTri;
                selectedRow.Cells["ChiPhiBaoTri"].Value = chiPhiBaoTri;
                selectedRow.Cells["MucDoAnhHuong"].Value = mucDoAnhHuong;

                // Cập nhật lại danh sách giá cả (danhSachGiaCa) nếu cần thiết
                var giaCaToUpdate = danhSachGiaCaCuaSanPham.FirstOrDefault(gc => gc.MaGiaCa == maGiaCa);
                if (giaCaToUpdate != null)
                {
                    giaCaToUpdate.MaGiaCa = maGiaCa;
                    giaCaToUpdate.MaSanPham = maSanPham;
                    giaCaToUpdate.MoTa = moTa;
                    giaCaToUpdate.DanhGiaGiaTri = danhGiaGiaTri;
                    giaCaToUpdate.ChiPhiBaoTri = chiPhiBaoTri;
                    giaCaToUpdate.MucDoAnhHuong = mucDoAnhHuong;
                }

                // Hiển thị thông báo thành công
                MessageBox.Show("Cập nhật giá cả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Sau khi lưu thành công, cập nhật lại DataGridView với dữ liệu mới
                dgvGiaCa.Refresh(); // Refresh lại DataGridView
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hiệu suất để chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
