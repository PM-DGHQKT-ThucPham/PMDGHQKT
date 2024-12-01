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
    public partial class frm_LoaiTieuChi : Form
    {
        List<TieuChi> lsttieuChi = new List<TieuChi>();
        TieuChiBLL tieuChiBll = new TieuChiBLL();
        SanPham_TieuChiBLL cttcBLL = new SanPham_TieuChiBLL();
        public frm_LoaiTieuChi()
        {
            InitializeComponent();
            this.Load += Frm_quatcytieuChi_Load;
            themXoaSuaTieuChi.ThemClicked += ThemXoaSuatieuChi_ThemClicked;
            themXoaSuaTieuChi.HuyThemClicked += ThemXoaSuatieuChi_HuyThemClicked;
            themXoaSuaTieuChi.XoaClicked += ThemXoaSuatieuChi_XoaClicked;
            themXoaSuaTieuChi.SuaClicked += ThemXoaSuatieuChi_SuaClicked;
            themXoaSuaTieuChi.LuuClicked += ThemXoaSuatieuChi_LuuClicked;
        }
        private void ThemXoaSuatieuChi_LuuClicked(object sender, EventArgs e)
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
                    List<TieuChi> temp = (List<TieuChi>)dgv_dsTieuChi.DataSource;
                    // Thực hiện lưu dữ liệu
                    bool kq = tieuChiBll.CapNhatThemXoaSuaTieuChi(temp);
                    if (kq == true)
                    {
                        MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Sau khi lưu thành công, load lại GridView
                        LoadLaiDanhSachtieuChi();
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
        private void LoadLaiDanhSachtieuChi()
        {
            try
            {
                // Tắt selection changed để tránh lỗi khi cập nhật
                dgv_dsTieuChi.SelectionChanged -= Dgv_dstieuChi_SelectionChanged;
                // Sau khi tắt xong thì load lại
                tieuChiBll = new TieuChiBLL();
                lsttieuChi = tieuChiBll.LayTatCaDanhSachTieuChi();
                dgv_dsTieuChi.DataSource = null;
                dgv_dsTieuChi.Invalidate();
                dgv_dsTieuChi.Refresh();
                dgv_dsTieuChi.DataSource = lsttieuChi;
                dgv_dsTieuChi.AllowUserToAddRows = false;
                dgv_dsTieuChi.AutoGenerateColumns = false;
                dgv_dsTieuChi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_dsTieuChi.MultiSelect = false;
                dgv_dsTieuChi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv_dsTieuChi.Refresh();
                dgv_dsTieuChi.Columns[0].HeaderText = "Mã Tiêu chí";
                dgv_dsTieuChi.Columns[1].HeaderText = "Tên Tiêu Chí";
                dgv_dsTieuChi.SelectionChanged += Dgv_dstieuChi_SelectionChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ThemXoaSuatieuChi_SuaClicked(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu các TextBox không bị trống
                if (KiemTraRongTextBoxtieuChi() == false)
                {
                    // Nếu không có trường nào trống
                    TieuChi tc = LaytieuChiTuGiaoDien();
                    // Cập nhật thông tin nguyên liệu vào DataGridView
                    dgv_dsTieuChi.CurrentRow.Cells["TenTieuChi"].Value = tc.TenTieuChi;
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
        private void ThemXoaSuatieuChi_XoaClicked(object sender, EventArgs e)
        {
            try
            {
                XoatieuChiDuocChon();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void XoatieuChiDuocChon()
        {
            try
            {
                // Lấy nguyên liệu được chọn từ DataGridView
                TieuChi tcDuocChon = (TieuChi)dgv_dsTieuChi.CurrentRow.DataBoundItem;

                // Kiểm tra xem nguyên liệu có liên kết với chi tiết thành phần nào hay không
                List<TieuChi_SanPham> lstCTTC = cttcBLL.LayCTTC_CuaTieuChi(tcDuocChon.MaTieuChi);
                if (lstCTTC == null || lstCTTC.Count == 0)
                {
                    // Nếu không có chi tiết thành phần nào thì có thể xóa
                    lsttieuChi.Remove(tcDuocChon);

                    // Xóa grid view và cập nhật lại danh sách mới cho grid view
                    //Xóa Selection Changed tránh lỗi
                    dgv_dsTieuChi.SelectionChanged -= Dgv_dstieuChi_SelectionChanged;
                    dgv_dsTieuChi.DataSource = null;
                    dgv_dsTieuChi.DataSource = lsttieuChi;
                    dgv_dsTieuChi.Refresh();
                    //dgv_dstieuChi.Rows[0].Selected = true;

                    // Đã xóa nguyên liệu
                    // Xóa text trong textbox
                    XoaTextBoxtieuChi();
                    // Bật lại sự kiện SelectionChanged
                    dgv_dsTieuChi.SelectionChanged += Dgv_dstieuChi_SelectionChanged;
                }
                else
                {
                    // Nếu có liên kết với chi tiết thành phần, không cho phép xóa
                    MessageBox.Show("Không thể xóa tiêu chí này vì có dữ liệu trong bảng sản phẩm - tiêu chí.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void ThemXoaSuatieuChi_HuyThemClicked(object sender, EventArgs e)
        {
            try
            {
                txtMaTieuChi.Enabled = false;
                BatDataBindingDataGridViewtieuChi();
                dgv_dsTieuChi.SelectionChanged += Dgv_dstieuChi_SelectionChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ThemXoaSuatieuChi_ThemClicked(object sender, EventArgs e)
        {
            try
            {
                // Nêu nút hủy bị ẩn tức là nút thêm chưa được nhấn lần đầu
                if (themXoaSuaTieuChi.BtnHuyThem.Enabled == false)
                {
                    // Bật txtMatieuChi
                    txtMaTieuChi.Enabled = true;
                    // Nếu như nút thêm được nhấn lần đầu thì tắt selection changed
                    dgv_dsTieuChi.SelectionChanged -= Dgv_dstieuChi_SelectionChanged;
                    // Sau đó xóa hết các textbox
                    XoaTextBoxtieuChi();
                    // Sau đó ẩn các nút Lưu Xóa Sửa để người dùng không nhấn được
                    themXoaSuaTieuChi.BtnXoa.Enabled = false;
                    themXoaSuaTieuChi.BtnSua.Enabled = false;
                    themXoaSuaTieuChi.BtnLuu.Enabled = false;
                    // Đồng thời cho nút hủy lưu sáng lên để có thể hủy lưu
                    themXoaSuaTieuChi.BtnHuyThem.Enabled = true;
                    // Đổi image của btnThem thành dấu tick Xanh
                    themXoaSuaTieuChi.BtnThem.Image = Properties.Resources.icons8_tick_35;
                }
                else // Ngược lại btnHuyThem = true tức là btnThem đang ở trạng thái chờ xác nhận
                {
                    if (KiemTraRongTextBoxtieuChi() == false) // Nếu tất cả text box đều nhập giá trị
                    {
                        // Lấy nguyên liệu từ text box
                        TieuChi tc = LaytieuChiTuGiaoDien();
                        // Thêm nguyên liệu vào listtieuChi
                        if (lsttieuChi.Where(t => string.Equals(t.MaTieuChi, tc.MaTieuChi, StringComparison.OrdinalIgnoreCase)).FirstOrDefault() != null)
                        {
                            // Đã có nguyên liệu này
                            MessageBox.Show("Đã tồn tại mã tiêu chí này !!!");
                            txtMaTieuChi.Focus();
                            // Return để cho người dùng nhập lại
                            return;
                        }
                        else // Chưa có nguyên liệu này
                        {
                            ThemtieuChiVaoDataGridView(tc);
                        }
                    }
                    else
                    {
                        // Thông báo chưa nhập
                        MessageBox.Show("Chưa nhập đầy đủ các giá trị của tiêu chí. Vui lòng kiểm tra lại");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ThemtieuChiVaoDataGridView(TieuChi tc)
        {
            try
            {
                // Thêm vào list Nguyên liệu
                lsttieuChi.Add(tc);
                // Xóa grid view và cập nhật lại list mới cho grid view
                // Trước khi thêm tắt sự kiện selection Changed để không bị lỗi
                dgv_dsTieuChi.SelectionChanged -= Dgv_dstieuChi_SelectionChanged;
                dgv_dsTieuChi.DataSource = null;
                dgv_dsTieuChi.Invalidate();
                dgv_dsTieuChi.Refresh();
                dgv_dsTieuChi.DataSource = lsttieuChi;
                // Đã thêm nguyên liệu xong
                // Ẩn đi txtMatieuChi
                txtMaTieuChi.Enabled = false;
                // Trả lại các nút như ban đầu
                themXoaSuaTieuChi.BtnXoa.Enabled = true;
                themXoaSuaTieuChi.BtnSua.Enabled = true;
                themXoaSuaTieuChi.BtnLuu.Enabled = true;
                themXoaSuaTieuChi.BtnHuyThem.Enabled = false;
                themXoaSuaTieuChi.BtnThem.Image = Properties.Resources.icons8_add_35;
                // Bật data binding cho nguyên liệu
                BatDataBindingDataGridViewtieuChi();
                // Bật lại selection changed
                dgv_dsTieuChi.SelectionChanged += Dgv_dstieuChi_SelectionChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private TieuChi LaytieuChiTuGiaoDien()
        {
            TieuChi tc = new TieuChi();
            tc.MaTieuChi = txtMaTieuChi.Text;
            tc.TenTieuChi = txtTenTieuChi.Text;
            return tc;
        }

        private bool KiemTraRongTextBoxtieuChi()
        {
            if (String.IsNullOrEmpty(txtMaTieuChi.Text))
            {
                return true;
            }
            if (String.IsNullOrEmpty(txtTenTieuChi.Text))
            {
                return true;
            }
            return false;
        }

        private void XoaTextBoxtieuChi()
        {
            try
            {
                txtMaTieuChi.Clear();
                txtTenTieuChi.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void Frm_quatcytieuChi_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDanhSachtieuChi();
                txtMaTieuChi.Enabled = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void LoadDanhSachtieuChi()
        {
            try
            {
                lsttieuChi = tieuChiBll.LayTatCaDanhSachTieuChi();
                dgv_dsTieuChi.DataSource = lsttieuChi;
                dgv_dsTieuChi.AllowUserToAddRows = false;
                dgv_dsTieuChi.AutoGenerateColumns = false;
                dgv_dsTieuChi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_dsTieuChi.MultiSelect = false;
                dgv_dsTieuChi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv_dsTieuChi.Columns[0].HeaderText = "Mã tiêu chí";
                dgv_dsTieuChi.Columns[1].HeaderText = "Tên tiêu chí";
                dgv_dsTieuChi.SelectionChanged += Dgv_dstieuChi_SelectionChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Dgv_dstieuChi_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                // Ràng buộc dữ liệu từ DataGridView vào các điều khiển
                BatDataBindingDataGridViewtieuChi();

                // Lấy mã nguyên liệu từ dòng được chọn
                string matieuChi = dgv_dsTieuChi.SelectedRows[0].Cells["MaTieuChi"].Value.ToString();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show(ex.Message);
            }
        }

        private void BatDataBindingDataGridViewtieuChi()
        {
            try
            {
                // Ràng buộc dữ liệu từ DataGridView vào các điều khiển
                txtMaTieuChi.Text = dgv_dsTieuChi.CurrentRow.Cells["MaTieuChi"].Value.ToString();
                txtTenTieuChi.Text = dgv_dsTieuChi.CurrentRow.Cells["TenTieuChi"].Value.ToString();
                //txtMoTatieuChi.Text = dgv_dsTieuChi.CurrentRow.Cells["MoTa"].Value.ToString();
                //txtDanhGiaChatLuongtieuChi.Text = dgv_dsTieuChi.CurrentRow.Cells["DanhGiaChatLuong"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
