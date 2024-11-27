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
        DoBenBLL doBenBLL = new DoBenBLL();
        List<DoBen> lstDoBen = new List<DoBen>();
        public frm_quanLyChatLuong()
        {
            InitializeComponent();
            themXoaSuaDoBen.ThemClicked += ThemXoaSuaDoBen_ThemClicked;
            themXoaSuaDoBen.HuyThemClicked += ThemXoaSuaDoBen_HuyThemClicked;
            themXoaSuaDoBen.XoaClicked += ThemXoaSuaDoBen_XoaClicked;
            themXoaSuaDoBen.SuaClicked += ThemXoaSuaDoBen_SuaClicked;
            themXoaSuaDoBen.LuuClicked += ThemXoaSuaDoBen_LuuClicked;
        }

        private void frm_quanLyChatLuong_Load(object sender, EventArgs e)
        {
            try
            {
                LoadComboboxSanPham();
                LoadDanhSachSanPham();
                txtMaDoBen.Enabled = false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void LoadDGVDoBen()
        {
            DoBenBLL doBenBLL = new DoBenBLL();

        }

        private void LoadComboboxSanPham()
        {
            SanPhamBLL sanPhamBLL = new SanPhamBLL();
            List<SanPham> sanPhams = sanPhamBLL.LayDanhSachSanPham();
            cboSanPham.DataSource = sanPhams;
            cboSanPham.DisplayMember = "TenSanPham";
            cboSanPham.ValueMember = "MaSanPham";
        }

        private void ThemXoaSuaDoBen_LuuClicked(object sender, EventArgs e)
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
                    List<DoBen> temp = (List<DoBen>)dgvDoBen.DataSource;
                    // Thực hiện lưu dữ liệu
                    bool kq = doBenBLL.CapNhatDoBenDuaTrenDanhSach(temp);
                    if (kq == true)
                    {
                        MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Sau khi lưu thành công load lại GridView
                        LoadLaiDanhSachSanPham();
                    }
                    else
                    {
                        MessageBox.Show("Lưu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void LoadLaiDanhSachSanPham()
        {
            try
            {
                //Tắt binding + selection changed
                TatDataBindingDataGridViewSanPham();
                dgvDoBen.SelectionChanged -= dgvDoBen_SelectionChanged;
                //Sau khi tắt xong thì lòad lại
                lstDoBen = doBenBLL.LayDanhSachDoBen();
                dgvDoBen.DataSource = lstDoBen;
                dgvDoBen.AllowUserToAddRows = false;
                dgvDoBen.AutoGenerateColumns = false;
                dgvDoBen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
                dgvDoBen.MultiSelect = false;
                dgvDoBen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                DinhDangDGVDoBen();


                dgvDoBen.SelectionChanged += dgvDoBen_SelectionChanged;
                TatDataBindingDataGridViewSanPham();
                BatDataBindingDataGridViewSanPham();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void ThemXoaSuaDoBen_SuaClicked(object sender, EventArgs e)
        {
            try
            {
                if (KiemTraRongTextBox() == false)
                {
                    DoBen db = LayDoBenTuGiaoDien();
                    XoaSanPhamDuocChon();
                    ThemSanPhamVaoDataGridView(db);
                }
                else
                {
                    MessageBox.Show("Chưa nhập đầy đủ thông tin của sản phẩm");
                    return;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void ThemXoaSuaDoBen_XoaClicked(object sender, EventArgs e)
        {
            try
            {
                XoaSanPhamDuocChon();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void XoaSanPhamDuocChon()
        {
            try
            {
                DoBen dbDuocChon = (DoBen)dgvDoBen.CurrentRow.DataBoundItem;

                //Nếu không có chi tiết thành phần nào thì xóa được
                lstDoBen.Remove(dbDuocChon);
                //Xóa grid view và cập nhật lại list mới cho grid view
                //Trước khi xóa tắt sự kiện selection Changed để không bị lỗi
                //Tắt luôn databinding
                TatDataBindingDataGridViewSanPham();
                dgvDoBen.SelectionChanged -= dgvDoBen_SelectionChanged;
                dgvDoBen.DataSource = null;
                dgvDoBen.DataSource = lstDoBen;
                //dgvDoBen.Invalidate();
                dgvDoBen.Refresh();
                dgvDoBen.Rows[0].Selected = true;
                //Đã xóa sản phẩm
                //Bật data binding cho sản phẩm
                //Xóa text
                XoaTextBoxDoBen();
                BatDataBindingDataGridViewSanPham();
                //Bật lại selection changed
                dgvDoBen.SelectionChanged += dgvDoBen_SelectionChanged;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dgvDoBen_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                BatDataBindingDataGridViewSanPham();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void ThemXoaSuaDoBen_HuyThemClicked(object sender, EventArgs e)
        {
            try
            {
                txtMaDoBen.Enabled = false;
                BatDataBindingDataGridViewSanPham();
                dgvDoBen.SelectionChanged += dgvDoBen_SelectionChanged;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ThemXoaSuaDoBen_ThemClicked(object sender, EventArgs e)
        {
            try
            {
                //Nêu nút hủy bị ẩn tức là nút thêm chưa được nhấn lần đầu
                if (themXoaSuaDoBen.BtnHuyThem.Enabled == false)
                {
                    //Bật txtMaSanPham
                    txtMaDoBen.Enabled = true;
                    //Nếu như nút thêm được nhấn lần đầu thì tắt binding và tắt seletion changed
                    TatDataBindingDataGridViewSanPham();
                    dgvDoBen.SelectionChanged -= dgvDoBen_SelectionChanged;
                    //Sau đó xóa hết các textbox
                    XoaTextBoxDoBen();
                    //Sau đó ẩn các nút Luu Xoa Sua để người dùng không nhấn được                
                    themXoaSuaDoBen.BtnXoa.Enabled = false;
                    themXoaSuaDoBen.BtnSua.Enabled = false;
                    themXoaSuaDoBen.BtnLuu.Enabled = false;
                    //Đồng thời cho nút hủy lưu sáng lên để có thể hủy lưu
                    themXoaSuaDoBen.BtnHuyThem.Enabled = true;
                    //Đổi image của btnThem thành dấu tick Xanh
                    themXoaSuaDoBen.BtnThem.Image = Properties.Resources.icons8_tick_35;
                }
                else //Ngược lại btnHuyTHem = true tức là btnThem đang ở trạng thái chờ xác nhận
                {
                    if (KiemTraRongTextBox() == false) //Nếu tất cả text box đều nhập giá trị
                    {
                        //Lấy sản phẩm từ text box
                        DoBen db = LayDoBenTuGiaoDien();
                        //Thêm sản phẩm vào listSanPham
                        if (lstDoBen.Where(t => string.Equals(t.MaDoBen, db.MaDoBen, StringComparison.OrdinalIgnoreCase)).FirstOrDefault() != null)
                        //Phân biệt hoa thường sp001 và SP001 tức là trùng sản phẩm
                        {
                            //Đã có sản phẩm này
                            MessageBox.Show("Đã tồn tại mã độ bền này !!!");
                            txtMaDoBen.Focus();
                            //Return để cho người dùng nhập lại
                            return;
                        }
                        else //Chưa có sản phẩm náy
                        {
                            ThemSanPhamVaoDataGridView(db);
                        }
                    }
                    else
                    {
                        //Thông báo chưa nhập
                        MessageBox.Show("Chưa nhập đầy đủ các giá trị của sản phẩm. Vui lòng kiểm tra lại");
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void ThemSanPhamVaoDataGridView(DoBen db)
        {
            try
            {
                //Thêm vào list Sản phẩm
                lstDoBen.Add(db);
                //Xóa grid view và cập nhật lại list mới cho grid view
                //Trước khi thêm tắt sự kiện selection Changed để không bị lỗi
                TatDataBindingDataGridViewSanPham();
                dgvDoBen.SelectionChanged -= dgvDoBen_SelectionChanged;
                dgvDoBen.DataSource = null;
                dgvDoBen.Invalidate();
                dgvDoBen.Refresh();
                dgvDoBen.DataSource = lstDoBen;
                //Đã xêm sản phẩm xong
                //Ẩn đi txtMaSanPham
                txtMaDoBen.Enabled = false;
                //Trả lại các nút như ban đầu
                themXoaSuaDoBen.BtnXoa.Enabled = true;
                themXoaSuaDoBen.BtnSua.Enabled = true;
                themXoaSuaDoBen.BtnLuu.Enabled = true;
                themXoaSuaDoBen.BtnHuyThem.Enabled = false;
                themXoaSuaDoBen.BtnThem.Image = Properties.Resources.icons8_add_35;
                //Bật data binding cho sản phẩm
                BatDataBindingDataGridViewSanPham();
                //Bật lại selection changed
                dgvDoBen.SelectionChanged += dgvDoBen_SelectionChanged;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private DoBen LayDoBenTuGiaoDien()
        {
            try
            {
                DoBen db = new DoBen()
                {
                    MaDoBen = txtMaDoBen.Text,
                    MaSanPham = cboSanPham.SelectedValue.ToString(),
                    TuoiThoNgay = Convert.ToInt32(txtTuoiThoNgay.Text),
                    DanhGiaDoBen = Convert.ToDecimal(txtDanhGiaDoBen.Text),
                    MucDoAnhHuong = Convert.ToDecimal(txtMucDoAnhHuong.Text),
                    MoTa = txtMoTaChiTiet.Text
                };
                return db;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private bool KiemTraRongTextBox()
        {
            try
            {
                // Kiểm tra rỗng
                if (string.IsNullOrWhiteSpace(txtMaDoBen.Text) ||
                    string.IsNullOrWhiteSpace(txtTuoiThoNgay.Text) ||
                    string.IsNullOrWhiteSpace(txtDanhGiaDoBen.Text) ||
                    string.IsNullOrWhiteSpace(txtMucDoAnhHuong.Text) ||
                    string.IsNullOrWhiteSpace(txtMoTaChiTiet.Text))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void XoaTextBoxDoBen()
        {
            try
            {
                // Xóa text
                txtMaDoBen.Text = "";
                txtTuoiThoNgay.Text = "";
                txtDanhGiaDoBen.Text = "";
                txtMucDoAnhHuong.Text = "";
                txtMoTaChiTiet.Text = "";

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void Frm_quanLyKhoHang_Load(object sender, EventArgs e)
        {

        }

        private void LoadDanhSachSanPham()
        {
            try
            {
                lstDoBen = doBenBLL.LayDanhSachDoBen();
                dgvDoBen.DataSource = lstDoBen;
                dgvDoBen.AllowUserToAddRows = false;
                dgvDoBen.AutoGenerateColumns = false;
                dgvDoBen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
                dgvDoBen.MultiSelect = false;
                dgvDoBen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DinhDangDGVDoBen();

                dgvDoBen.SelectionChanged += dgvDoBen_SelectionChanged;
                TatDataBindingDataGridViewSanPham();
                BatDataBindingDataGridViewSanPham();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void DinhDangDGVDoBen()
        {
            // Đặt tiêu đề cho các cột
            dgvDoBen.Columns["MaDoBen"].HeaderText = "Mã độ bền";
            dgvDoBen.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";
            dgvDoBen.Columns["TuoiThoNgay"].HeaderText = "Tuổi thọ ngày";
            dgvDoBen.Columns["DanhGiaDoBen"].HeaderText = "Đánh giá độ bền";
            dgvDoBen.Columns["MucDoAnhHuong"].HeaderText = "Mức độ ảnh hưởng";
            dgvDoBen.Columns["MoTa"].HeaderText = "Mô tả";

            // Ẩn cột không cần thiết
            dgvDoBen.Columns["SanPham"].Visible = false;

            // Căn trái nội dung các cột
            dgvDoBen.Columns["TuoiThoNgay"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDoBen.Columns["DanhGiaDoBen"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDoBen.Columns["MucDoAnhHuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Tự động xuống dòng cho cột Mô tả
            dgvDoBen.Columns["MoTa"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Tự động điều chỉnh chiều cao của hàng
            dgvDoBen.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Đặt cột Mô tả ở vị trí cuối cùng
            dgvDoBen.Columns["MoTa"].DisplayIndex = dgvDoBen.Columns.Count - 1;

            // Fill toàn bộ chiều rộng DataGridView
            dgvDoBen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Tùy chỉnh FillWeight cho các cột
            dgvDoBen.Columns["MoTa"].FillWeight = 70; // Cột Mô tả rộng hơn các cột khác
            dgvDoBen.Columns["MaDoBen"].FillWeight = 6;
            dgvDoBen.Columns["MaSanPham"].FillWeight = 6;
            dgvDoBen.Columns["TuoiThoNgay"].FillWeight = 6;
            dgvDoBen.Columns["DanhGiaDoBen"].FillWeight = 6;
            dgvDoBen.Columns["MucDoAnhHuong"].FillWeight = 6;
        }




        private void TatDataBindingDataGridViewSanPham()
        {
            try
            {
                // Xóa các binding cũ (nếu có)
                txtMaDoBen.DataBindings.Clear();
                txtTuoiThoNgay.DataBindings.Clear();
                txtMoTaChiTiet.DataBindings.Clear();
                txtDanhGiaDoBen.DataBindings.Clear();
                txtMucDoAnhHuong.DataBindings.Clear();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void BatDataBindingDataGridViewSanPham()
        {
            try
            {
                TatDataBindingDataGridViewSanPham();
                // Ràng buộc dữ liệu từ DataGridView vào các điều khiển
                txtMaDoBen.Text = dgvDoBen.CurrentRow.Cells["MaDoBen"].Value.ToString();
                txtTuoiThoNgay.Text = dgvDoBen.CurrentRow.Cells["TuoiThoNgay"].Value.ToString();
                txtMoTaChiTiet.Text = dgvDoBen.CurrentRow.Cells["MoTa"].Value.ToString();
                txtDanhGiaDoBen.Text = dgvDoBen.CurrentRow.Cells["DanhGiaDoBen"].Value.ToString();
                txtMucDoAnhHuong.Text = dgvDoBen.CurrentRow.Cells["MucDoAnhHuong"].Value.ToString();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
