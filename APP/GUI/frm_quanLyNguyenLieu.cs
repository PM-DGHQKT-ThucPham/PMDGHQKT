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
    public partial class frm_quanLyNguyenLieu : Form
    {
        List<NguyenLieu> lstNguyenLieu = new List<NguyenLieu>();
        NguyenLieuBLL nguyenLieuBll = new NguyenLieuBLL();
        ChiTietThanhPhanBLL cttpBLL = new ChiTietThanhPhanBLL();
        public frm_quanLyNguyenLieu()
        {
            InitializeComponent();
            this.Load += Frm_quanLyNguyenLieu_Load;
            themXoaSuaNguyenLieu.ThemClicked += ThemXoaSuaNguyenLieu_ThemClicked;
            themXoaSuaNguyenLieu.HuyThemClicked += ThemXoaSuaNguyenLieu_HuyThemClicked;
            themXoaSuaNguyenLieu.XoaClicked += ThemXoaSuaNguyenLieu_XoaClicked;
            themXoaSuaNguyenLieu.SuaClicked += ThemXoaSuaNguyenLieu_SuaClicked;
            themXoaSuaNguyenLieu.LuuClicked += ThemXoaSuaNguyenLieu_LuuClicked;
        }
        private void ThemXoaSuaNguyenLieu_LuuClicked(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn lưu các thay đổi không?",
                    "Xác nhận lưu",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                // Kiểm tra người dùng chọn Yes hay No
                if (result == DialogResult.Yes)
                {
                    List<NguyenLieu> temp = (List<NguyenLieu>)dgv_dsNguyenLieu.DataSource;
                    // Thực hiện lưu dữ liệu
                    bool kq = nguyenLieuBll.CapNhatThemXoaSuaNguyenLieu(temp);
                    if (kq == true)
                    {
                        MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Sau khi lưu thành công, load lại GridView
                        LoadLaiDanhSachNguyenLieu();
                    }
                    else
                    {
                        MessageBox.Show("Lưu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadLaiDanhSachNguyenLieu()
        {
            try
            {
                // Tắt selection changed để tránh lỗi khi cập nhật
                dgv_dsNguyenLieu.SelectionChanged -= Dgv_dsNguyenLieu_SelectionChanged;
                // Sau khi tắt xong thì load lại
                nguyenLieuBll = new NguyenLieuBLL();
                lstNguyenLieu = nguyenLieuBll.LayTatCaDanhSachNguyenLieu();
                dgv_dsNguyenLieu.DataSource = null;
                dgv_dsNguyenLieu.Invalidate();
                dgv_dsNguyenLieu.Refresh();
                dgv_dsNguyenLieu.DataSource = lstNguyenLieu;
                dgv_dsNguyenLieu.AllowUserToAddRows = false;
                dgv_dsNguyenLieu.AutoGenerateColumns = false;
                dgv_dsNguyenLieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_dsNguyenLieu.MultiSelect = false;
                dgv_dsNguyenLieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv_dsNguyenLieu.Refresh();
                dgv_dsNguyenLieu.Columns[0].HeaderText = "Mã nguyên liệu";
                dgv_dsNguyenLieu.Columns[1].HeaderText = "Tên nguyên liệu";
                dgv_dsNguyenLieu.Columns[2].HeaderText = "Mô tả";
                dgv_dsNguyenLieu.Columns[3].HeaderText = "Đánh giá chất lượng";
                dgv_dsNguyenLieu.SelectionChanged += Dgv_dsNguyenLieu_SelectionChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ThemXoaSuaNguyenLieu_SuaClicked(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu các TextBox không bị trống
                if (KiemTraRongTextBoxNguyenLieu() == false)
                {
                    // Nếu không có trường nào trống
                    NguyenLieu nl = LayNguyenLieuTuGiaoDien();
                    // Cập nhật thông tin nguyên liệu vào DataGridView
                    dgv_dsNguyenLieu.CurrentRow.Cells["TenNguyenLieu"].Value = nl.TenNguyenLieu;
                    dgv_dsNguyenLieu.CurrentRow.Cells["MoTa"].Value = nl.MoTa;
                    dgv_dsNguyenLieu.CurrentRow.Cells["DanhGiaChatLuong"].Value = nl.DanhGiaChatLuong;
                }
                else
                {
                    MessageBox.Show("Có thông tin đang trống. Vui lòng kiểm tra lại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ThemXoaSuaNguyenLieu_XoaClicked(object sender, EventArgs e)
        {
            try
            {
                XoaNguyenLieuDuocChon();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void XoaNguyenLieuDuocChon()
        {
            try
            {
                // Lấy nguyên liệu được chọn từ DataGridView
                NguyenLieu nlDuocChon = (NguyenLieu)dgv_dsNguyenLieu.CurrentRow.DataBoundItem;

                // Kiểm tra xem nguyên liệu có liên kết với chi tiết thành phần nào hay không
                List<ChiTietThanhPhan> lstCTTP = cttpBLL.LayCTTP_CuaNguyenLieu(nlDuocChon.MaNguyenLieu);
                if (lstCTTP == null || lstCTTP.Count == 0)
                {
                    // Nếu không có chi tiết thành phần nào thì có thể xóa
                    lstNguyenLieu.Remove(nlDuocChon);

                    // Xóa grid view và cập nhật lại danh sách mới cho grid view
                    //Xóa Selection Changed tránh lỗi
                    dgv_dsNguyenLieu.SelectionChanged -= Dgv_dsNguyenLieu_SelectionChanged;
                    dgv_dsNguyenLieu.DataSource = null;
                    dgv_dsNguyenLieu.DataSource = lstNguyenLieu;
                    dgv_dsNguyenLieu.Refresh();
                    //dgv_dsNguyenLieu.Rows[0].Selected = true;

                    // Đã xóa nguyên liệu
                    // Xóa text trong textbox
                    XoaTextBoxNguyenLieu();
                    // Bật lại sự kiện SelectionChanged
                    dgv_dsNguyenLieu.SelectionChanged += Dgv_dsNguyenLieu_SelectionChanged;
                }
                else
                {
                    // Nếu có liên kết với chi tiết thành phần, không cho phép xóa
                    MessageBox.Show("Không thể xóa nguyên liệu này vì có dữ liệu trong bảng chi tiết thành phần.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void ThemXoaSuaNguyenLieu_HuyThemClicked(object sender, EventArgs e)
        {
            try
            {
                txtMaNguyenLieu.Enabled = false;
                BatDataBindingDataGridViewNguyenLieu();
                dgv_dsNguyenLieu.SelectionChanged += Dgv_dsNguyenLieu_SelectionChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ThemXoaSuaNguyenLieu_ThemClicked(object sender, EventArgs e)
        {
            try
            {
                // Nêu nút hủy bị ẩn tức là nút thêm chưa được nhấn lần đầu
                if (themXoaSuaNguyenLieu.BtnHuyThem.Enabled == false)
                {
                    // Bật txtMaNguyenLieu
                    txtMaNguyenLieu.Enabled = true;
                    // Nếu như nút thêm được nhấn lần đầu thì tắt selection changed
                    dgv_dsNguyenLieu.SelectionChanged -= Dgv_dsNguyenLieu_SelectionChanged;
                    // Sau đó xóa hết các textbox
                    XoaTextBoxNguyenLieu();
                    // Sau đó ẩn các nút Lưu Xóa Sửa để người dùng không nhấn được
                    themXoaSuaNguyenLieu.BtnXoa.Enabled = false;
                    themXoaSuaNguyenLieu.BtnSua.Enabled = false;
                    themXoaSuaNguyenLieu.BtnLuu.Enabled = false;
                    // Đồng thời cho nút hủy lưu sáng lên để có thể hủy lưu
                    themXoaSuaNguyenLieu.BtnHuyThem.Enabled = true;
                    // Đổi image của btnThem thành dấu tick Xanh
                    themXoaSuaNguyenLieu.BtnThem.Image = Properties.Resources.icons8_tick_35;
                }
                else // Ngược lại btnHuyThem = true tức là btnThem đang ở trạng thái chờ xác nhận
                {
                    if (KiemTraRongTextBoxNguyenLieu() == false) // Nếu tất cả text box đều nhập giá trị
                    {
                        // Lấy nguyên liệu từ text box
                        NguyenLieu nl = LayNguyenLieuTuGiaoDien();
                        // Thêm nguyên liệu vào listNguyenLieu
                        if (lstNguyenLieu.Where(t => string.Equals(t.MaNguyenLieu, nl.MaNguyenLieu, StringComparison.OrdinalIgnoreCase)).FirstOrDefault() != null)
                        {
                            // Đã có nguyên liệu này
                            MessageBox.Show("Đã tồn tại mã nguyên liệu này !!!");
                            txtMaNguyenLieu.Focus();
                            // Return để cho người dùng nhập lại
                            return;
                        }
                        else // Chưa có nguyên liệu này
                        {
                            ThemNguyenLieuVaoDataGridView(nl);
                        }
                    }
                    else
                    {
                        // Thông báo chưa nhập
                        MessageBox.Show("Chưa nhập đầy đủ các giá trị của nguyên liệu. Vui lòng kiểm tra lại");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ThemNguyenLieuVaoDataGridView(NguyenLieu nl)
        {
            try
            {
                // Thêm vào list Nguyên liệu
                lstNguyenLieu.Add(nl);
                // Xóa grid view và cập nhật lại list mới cho grid view
                // Trước khi thêm tắt sự kiện selection Changed để không bị lỗi
                dgv_dsNguyenLieu.SelectionChanged -= Dgv_dsNguyenLieu_SelectionChanged;
                dgv_dsNguyenLieu.DataSource = null;
                dgv_dsNguyenLieu.Invalidate();
                dgv_dsNguyenLieu.Refresh();
                dgv_dsNguyenLieu.DataSource = lstNguyenLieu;
                // Đã thêm nguyên liệu xong
                // Ẩn đi txtMaNguyenLieu
                txtMaNguyenLieu.Enabled = false;
                // Trả lại các nút như ban đầu
                themXoaSuaNguyenLieu.BtnXoa.Enabled = true;
                themXoaSuaNguyenLieu.BtnSua.Enabled = true;
                themXoaSuaNguyenLieu.BtnLuu.Enabled = true;
                themXoaSuaNguyenLieu.BtnHuyThem.Enabled = false;
                themXoaSuaNguyenLieu.BtnThem.Image = Properties.Resources.icons8_add_35;
                // Bật data binding cho nguyên liệu
                BatDataBindingDataGridViewNguyenLieu();
                // Bật lại selection changed
                dgv_dsNguyenLieu.SelectionChanged += Dgv_dsNguyenLieu_SelectionChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private NguyenLieu LayNguyenLieuTuGiaoDien()
        {
            NguyenLieu nl = new NguyenLieu();
            nl.MaNguyenLieu = txtMaNguyenLieu.Text;
            nl.TenNguyenLieu = txtTenNguyenLieu.Text;
            nl.MoTa = txtMoTaNguyenLieu.Text;
            nl.DanhGiaChatLuong = decimal.Parse(txtDanhGiaChatLuongNguyenLieu.Text);
            return nl;
        }

        private bool KiemTraRongTextBoxNguyenLieu()
        {
            if (String.IsNullOrEmpty(txtMaNguyenLieu.Text))
            {
                return true;
            }
            if (String.IsNullOrEmpty(txtTenNguyenLieu.Text))
            {
                return true;
            }
            if (String.IsNullOrEmpty(txtMoTaNguyenLieu.Text))
            {
                return true;
            }
            if (String.IsNullOrEmpty(txtDanhGiaChatLuongNguyenLieu.Text))
            {
                return true;
            }
            return false;
        }

        private void XoaTextBoxNguyenLieu()
        {
            try
            {
                txtMaNguyenLieu.Clear();
                txtMoTaNguyenLieu.Clear();
                txtTenNguyenLieu.Clear();
                txtDanhGiaChatLuongNguyenLieu.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void Frm_quanLyNguyenLieu_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDanhSachNguyenLieu();
                txtMaNguyenLieu.Enabled = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void LoadDanhSachNguyenLieu()
        {
            try
            {
                lstNguyenLieu = nguyenLieuBll.LayTatCaDanhSachNguyenLieu();
                dgv_dsNguyenLieu.DataSource = lstNguyenLieu;
                dgv_dsNguyenLieu.AllowUserToAddRows = false;
                dgv_dsNguyenLieu.AutoGenerateColumns = false;
                dgv_dsNguyenLieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_dsNguyenLieu.MultiSelect = false;
                dgv_dsNguyenLieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv_dsNguyenLieu.Columns[0].HeaderText = "Mã nguyên liệu";
                dgv_dsNguyenLieu.Columns[1].HeaderText = "Tên nguyên liệu";
                dgv_dsNguyenLieu.Columns[2].HeaderText = "Mô tả";
                dgv_dsNguyenLieu.Columns[3].HeaderText = "Đánh giá chất lượng";
                dgv_dsNguyenLieu.SelectionChanged += Dgv_dsNguyenLieu_SelectionChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Dgv_dsNguyenLieu_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                // Ràng buộc dữ liệu từ DataGridView vào các điều khiển
                BatDataBindingDataGridViewNguyenLieu();

                // Lấy mã nguyên liệu từ dòng được chọn
                string maNguyenLieu = dgv_dsNguyenLieu.SelectedRows[0].Cells["MaNguyenLieu"].Value.ToString();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show(ex.Message);
            }
        }

        private void BatDataBindingDataGridViewNguyenLieu()
        {
                try
                {
                    // Ràng buộc dữ liệu từ DataGridView vào các điều khiển
                    txtMaNguyenLieu.Text = dgv_dsNguyenLieu.CurrentRow.Cells["MaNguyenLieu"].Value.ToString();
                    txtTenNguyenLieu.Text = dgv_dsNguyenLieu.CurrentRow.Cells["TenNguyenLieu"].Value.ToString();
                    txtMoTaNguyenLieu.Text = dgv_dsNguyenLieu.CurrentRow.Cells["MoTa"].Value.ToString();
                    txtDanhGiaChatLuongNguyenLieu.Text = dgv_dsNguyenLieu.CurrentRow.Cells["DanhGiaChatLuong"].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }
    }
}
