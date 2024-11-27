using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DevExpress.Xpo.Helpers;
using DTO;
namespace GUI
{
    public partial class frm_quanLyKhoHang : Form
    {
        SanPhamBLL spBll = new SanPhamBLL();
        ChiTietThanhPhanBLL cttpBLL = new ChiTietThanhPhanBLL();
        List<SanPham> lstSanPham = new List<SanPham>();
        List<ChiTietThanhPhan> lstCTTP = new List<ChiTietThanhPhan>();
        public frm_quanLyKhoHang()
        {
            InitializeComponent();
            
            this.Load += Frm_quanLyKhoHang_Load;
            themXoaSuaSanPham.ThemClicked += ThemXoaSuaSanPham_ThemClicked;
            themXoaSuaSanPham.HuyThemClicked += ThemXoaSuaSanPham_HuyThemClicked;
            themXoaSuaSanPham.XoaClicked += ThemXoaSuaSanPham_XoaClicked;
            themXoaSuaSanPham.SuaClicked += ThemXoaSuaSanPham_SuaClicked;
            themXoaSuaSanPham.LuuClicked += ThemXoaSuaSanPham_LuuClicked;

            themXoaSuaCTTP.ThemClicked += ThemXoaSuaChiTietThanhPhan_ThemClicked;
            themXoaSuaCTTP.XoaClicked += ThemXoaSuaChiTietThanhPhan_XoaClicked;
            themXoaSuaCTTP.SuaClicked += ThemXoaSuaChiTietThanhPhan_SuaClicked;
            themXoaSuaCTTP.LuuClicked += ThemXoaSuaChiTietThanhPhan_LuuClicked;
        }

        private void ThemXoaSuaSanPham_LuuClicked(object sender, EventArgs e)
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
                    List<SanPham> temp = (List<SanPham>) dgv_dsSanPham.DataSource;
                    // Thực hiện lưu dữ liệu
                    bool kq = spBll.CapNhatThemXoaSua(temp);
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

                MessageBox.Show(ex.Message);
            }
        }

        private void LoadLaiDanhSachSanPham()
        {
            try
            {
                //Tắt binding + selection changed
                TatDataBindingDataGridViewSanPham();
                dgv_dsSanPham.SelectionChanged -= Dgv_dsSanPham_SelectionChanged;
                //Sau khi tắt xong thì lòad lại
                spBll = new SanPhamBLL();
                lstSanPham = spBll.LayDanhSachSanPham();
                dgv_dsSanPham.DataSource = null;
                dgv_dsSanPham.Invalidate();
                dgv_dsSanPham.Refresh();
                dgv_dsSanPham.DataSource = lstSanPham;
                dgv_dsSanPham.AllowUserToAddRows = false;
                dgv_dsSanPham.AutoGenerateColumns = false;
                dgv_dsSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
                dgv_dsSanPham.MultiSelect = false;
                dgv_dsSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv_dsSanPham.Refresh();
                dgv_dsSanPham.Columns[0].HeaderText = "Mã sản phẩm";
                dgv_dsSanPham.Columns[1].HeaderText = "Tên sản phẩm";
                dgv_dsSanPham.Columns[2].HeaderText = "Mô tả";
                dgv_dsSanPham.Columns[3].HeaderText = "Giá";
                dgv_dsSanPham.Columns[4].HeaderText = "Danh mục";
                dgv_dsSanPham.Columns[5].HeaderText = "Số lượng tồn";
                dgv_dsSanPham.Columns[6].HeaderText = "Ngày phát hành";
                dgv_dsSanPham.Columns[7].HeaderText = "Mức độ ảnh hưởng";
                dgv_dsSanPham.SelectionChanged += Dgv_dsSanPham_SelectionChanged;
                TatDataBindingDataGridViewSanPham();
                BatDataBindingDataGridViewSanPham();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void ThemXoaSuaSanPham_HuyThemClicked(object sender, EventArgs e)
        {
            try
            {
                txtMaSanPham.Enabled = false;
                BatDataBindingDataGridViewSanPham();
                dgv_dsSanPham.SelectionChanged += Dgv_dsSanPham_SelectionChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ThemXoaSuaSanPham_ThemClicked(object sender, EventArgs e)
        {
            try
            {
                //Nêu nút hủy bị ẩn tức là nút thêm chưa được nhấn lần đầu
                if (themXoaSuaSanPham.BtnHuyThem.Enabled == false)
                {
                    //Bật txtMaSanPham
                    txtMaSanPham.Enabled = true;
                    //Nếu như nút thêm được nhấn lần đầu thì tắt binding và tắt seletion changed
                    TatDataBindingDataGridViewSanPham();
                    dgv_dsSanPham.SelectionChanged -= Dgv_dsSanPham_SelectionChanged;
                    //Sau đó xóa hết các textbox
                    XoaTextBoxSanPham();
                    //Sau đó ẩn các nút Luu Xoa Sua để người dùng không nhấn được                
                    themXoaSuaSanPham.BtnXoa.Enabled = false;
                    themXoaSuaSanPham.BtnSua.Enabled = false;
                    themXoaSuaSanPham.BtnLuu.Enabled = false;
                    //Đồng thời cho nút hủy lưu sáng lên để có thể hủy lưu
                    themXoaSuaSanPham.BtnHuyThem.Enabled = true;
                    //Đổi image của btnThem thành dấu tick Xanh
                    themXoaSuaSanPham.BtnThem.Image = Properties.Resources.icons8_tick_35;
                }
                else //Ngược lại btnHuyTHem = true tức là btnThem đang ở trạng thái chờ xác nhận
                {
                    if (KiemTraRongTextBoxSanPham() == false) //Nếu tất cả text box đều nhập giá trị
                    {
                        //Lấy sản phẩm từ text box
                        SanPham sp = LaySanPhamTuGiaoDien();
                        //Thêm sản phẩm vào listSanPham
                        if (lstSanPham.Where(t => string.Equals(t.MaSanPham, sp.MaSanPham, StringComparison.OrdinalIgnoreCase)).FirstOrDefault() != null)
                        //Phân biệt hoa thường sp001 và SP001 tức là trùng sản phẩm
                        {
                            //Đã có sản phẩm này
                            MessageBox.Show("Đã tồn tại mã sản phẩm này !!!");
                            txtMaSanPham.Focus();
                            //Return để cho người dùng nhập lại
                            return;
                        }
                        else //Chưa có sản phẩm náy
                        {
                            ThemSanPhamVaoDataGridView(sp);
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
                MessageBox.Show(ex.Message);
            }

        }

        private void ThemXoaSuaSanPham_SuaClicked(object sender, EventArgs e)
        {
            try
            {
                if (KiemTraRongTextBoxSanPham() == false)
                {
                    SanPham sp = LaySanPhamTuGiaoDien();
                    XoaSanPhamDuocChon();
                    ThemSanPhamVaoDataGridView(sp);
                }
                else
                {
                    MessageBox.Show("Chưa nhập đầy đủ thông tin của sản phẩm");
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void ThemXoaSuaSanPham_XoaClicked(object sender, EventArgs e)
        {
            try
            {
                XoaSanPhamDuocChon();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void XoaSanPhamDuocChon()
        {
            try
            {
                SanPham spDuocChon = (SanPham)dgv_dsSanPham.CurrentRow.DataBoundItem;
                //Kiểm tra xem thành phần có nguyên liệu nào hay chưa          
                List<ChiTietThanhPhan> lstCTTP = cttpBLL.LayCTTP_CuaSanPham(spDuocChon.MaSanPham);
                if (lstCTTP == null || lstCTTP.Count == 0)
                {
                    //Nếu không có chi tiết thành phần nào thì xóa được
                    lstSanPham.Remove(spDuocChon);
                    //Xóa grid view và cập nhật lại list mới cho grid view
                    //Trước khi xóa tắt sự kiện selection Changed để không bị lỗi
                    //Tắt luôn databinding
                    TatDataBindingDataGridViewSanPham();
                    dgv_dsSanPham.SelectionChanged -= Dgv_dsSanPham_SelectionChanged;
                    dgv_dsSanPham.DataSource = null;
                    dgv_dsSanPham.DataSource = lstSanPham;
                    //dgv_dsSanPham.Invalidate();
                    dgv_dsSanPham.Refresh();
                    dgv_dsSanPham.Rows[0].Selected = true;
                    //Đã xóa sản phẩm
                    //Bật data binding cho sản phẩm
                    //Xóa text
                    XoaTextBoxSanPham();
                    BatDataBindingDataGridViewSanPham();
                    //Bật lại selection changed
                    dgv_dsSanPham.SelectionChanged += Dgv_dsSanPham_SelectionChanged;
                }
                else
                {
                    MessageBox.Show("Không thể xóa sản phẩm này vì có dữ liệu trong bảng chi tiết thành phần");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Dgv_dsSanPham_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                BatDataBindingDataGridViewSanPham();
                string masp = dgv_dsSanPham.SelectedRows[0].Cells["MaSanPham"].Value.ToString();
                //SanPham sp = spBll.LaySanPhamTheoMa(masp);

                lstCTTP = cttpBLL.LayCTTP_CuaSanPham(masp);
                if (lstCTTP != null && lstCTTP.Count > 0)
                {
                    //Load dgvChiTietThanhPhan
                    LoadChiTietThanhPhan();
                }
                else
                {
                    //Tắt selection changed
                    dgv_ChiTietThanhPhan.SelectionChanged -= Dgv_ChiTietThanhPhan_SelectionChanged;
                    dgv_ChiTietThanhPhan.DataSource = null;
                    //Xóa text box nguyen lieu
                    XoaTextBoxNguyenLieu();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void LoadChiTietThanhPhan()
        {
            dgv_ChiTietThanhPhan.DataSource = lstCTTP;
            dgv_ChiTietThanhPhan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_ChiTietThanhPhan.MultiSelect = false;
            dgv_ChiTietThanhPhan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_ChiTietThanhPhan.SelectionChanged += Dgv_ChiTietThanhPhan_SelectionChanged;
            //dgv_ChiTietThanhPhan.Rows[1].Selected = true;
            //dgv_ChiTietThanhPhan.Rows[0].Selected = true;
            dgv_ChiTietThanhPhan.Columns[3].Visible = false;
            dgv_ChiTietThanhPhan.Columns[4].Visible = false;
        }

        private void XoaTextBoxNguyenLieu()
        {
            txtMaNguyenLieu.Clear();
            txtTenNguyenLieu.Clear();
            txtMoTaNguyenLieu.Clear();
            txtDanhGiaChatLuongNguyenLieu.Clear();
            txtPhanTramNguyenLieu.Clear();
        }

        private void Dgv_ChiTietThanhPhan_SelectionChanged(object sender, EventArgs e)
        {
            List<ChiTietThanhPhan> lstCTTP = (List<ChiTietThanhPhan>) dgv_ChiTietThanhPhan.DataSource;
            if (lstCTTP != null && lstCTTP.Count > 0)
            {
                string maNguyenLieu = dgv_ChiTietThanhPhan.CurrentRow.Cells["MaNguyenLieu"].Value.ToString();
                string phanTramNguyenLieu = dgv_ChiTietThanhPhan.CurrentRow.Cells["PhanTramNguyenLieu"].Value.ToString();
                NguyenLieuBLL nlBLl = new NguyenLieuBLL();
                NguyenLieu nguyenLieu = nlBLl.LayNguyenLieu(maNguyenLieu);
                txtMaNguyenLieu.Enabled = false;
                txtTenNguyenLieu.Enabled = false;
                txtMoTaNguyenLieu.Enabled = false;
                txtDanhGiaChatLuongNguyenLieu.Enabled = false;

                txtMaNguyenLieu.Text = nguyenLieu.MaNguyenLieu;
                txtTenNguyenLieu.Text = nguyenLieu.TenNguyenLieu;
                txtMoTaNguyenLieu.Text = nguyenLieu.MoTa;
                txtDanhGiaChatLuongNguyenLieu.Text = nguyenLieu.DanhGiaChatLuong.ToString();
                txtPhanTramNguyenLieu.Text = phanTramNguyenLieu;
            }
        }       

        private void ThemSanPhamVaoDataGridView(SanPham sp)
        {
            try
            {
                //Thêm vào list Sản phẩm
                lstSanPham.Add(sp);
                //Xóa grid view và cập nhật lại list mới cho grid view
                //Trước khi thêm tắt sự kiện selection Changed để không bị lỗi
                TatDataBindingDataGridViewSanPham();
                dgv_dsSanPham.SelectionChanged -= Dgv_dsSanPham_SelectionChanged;
                dgv_dsSanPham.DataSource = null;
                dgv_dsSanPham.Invalidate();
                dgv_dsSanPham.Refresh();
                dgv_dsSanPham.DataSource = lstSanPham;
                //Đã xêm sản phẩm xong
                //Ẩn đi txtMaSanPham
                txtMaSanPham.Enabled = false;
                //Trả lại các nút như ban đầu
                themXoaSuaSanPham.BtnXoa.Enabled = true;
                themXoaSuaSanPham.BtnSua.Enabled = true;
                themXoaSuaSanPham.BtnLuu.Enabled = true;
                themXoaSuaSanPham.BtnHuyThem.Enabled = false;
                themXoaSuaSanPham.BtnThem.Image = Properties.Resources.icons8_add_35;
                //Bật data binding cho sản phẩm
                BatDataBindingDataGridViewSanPham();
                //Bật lại selection changed
                dgv_dsSanPham.SelectionChanged += Dgv_dsSanPham_SelectionChanged;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private SanPham LaySanPhamTuGiaoDien()
        {
            SanPham sp = new SanPham();
            sp.MaSanPham = txtMaSanPham.Text;
            sp.TenSanPham = txtTenSanPham.Text;
            sp.MoTa = txtMoTa.Text;
            sp.Gia = decimal.Parse(txtGia.Text);
            sp.DanhMuc = txtDanhMuc.Text;
            sp.SoLuongTon = int.Parse(txtSoLuongTon.Text);
            sp.NgayPhatHanh = dtpNgayPhatHanh.Value.Date;
            sp.MucDoAnhHuongTongNguyenLieu = decimal.Parse(txtMucDoAnhHuongNguyenLieu.Text);
            return sp;
        }

        private bool KiemTraRongTextBoxSanPham()
        {
            if (String.IsNullOrEmpty(txtDanhMuc.Text))
            {
                return true;
            }
            if (String.IsNullOrEmpty(txtMaSanPham.Text))
            {
                return true;
            }
            if (String.IsNullOrEmpty(txtTenSanPham.Text))
            {
                return true;
            }
            if (String.IsNullOrEmpty(txtGia.Text))
            {
                return true;
            }
            if (String.IsNullOrEmpty(txtMoTa.Text))
            {
                return true;
            }
            if (String.IsNullOrEmpty(txtMucDoAnhHuongNguyenLieu.Text))
            {
                return true;
            }
            if (String.IsNullOrEmpty(txtSoLuongTon.Text))
            {
                return true;
            }
            return false;
        }

        private void XoaTextBoxSanPham()
        {
            try
            {
                txtDanhMuc.Clear();
                txtGia.Clear();
                txtMaSanPham.Clear();
                txtMoTa.Clear();
                txtMucDoAnhHuongNguyenLieu.Clear();
                txtSoLuongTon.Clear();
                txtTenSanPham.Clear();
                dtpNgayPhatHanh.Value = DateTime.Now.Date;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Frm_quanLyKhoHang_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDanhSachSanPham();
                txtMaSanPham.Enabled = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void LoadDanhSachSanPham()
        {
            try
            {
                lstSanPham = spBll.LayDanhSachSanPham();
                dgv_dsSanPham.DataSource = lstSanPham;
                dgv_dsSanPham.AllowUserToAddRows = false;
                dgv_dsSanPham.AutoGenerateColumns = false;
                dgv_dsSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
                dgv_dsSanPham.MultiSelect = false;
                dgv_dsSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv_dsSanPham.Columns[0].HeaderText = "Mã sản phẩm";
                dgv_dsSanPham.Columns[1].HeaderText = "Tên sản phẩm";
                dgv_dsSanPham.Columns[2].HeaderText = "Mô tả";
                dgv_dsSanPham.Columns[3].HeaderText = "Giá";
                dgv_dsSanPham.Columns[4].HeaderText = "Danh mục";
                dgv_dsSanPham.Columns[5].HeaderText = "Số lượng tồn";
                dgv_dsSanPham.Columns[6].HeaderText = "Ngày phát hành";
                dgv_dsSanPham.Columns[7].HeaderText = "Mức độ ảnh hưởng";
                dgv_dsSanPham.SelectionChanged += Dgv_dsSanPham_SelectionChanged;
                TatDataBindingDataGridViewSanPham();
                BatDataBindingDataGridViewSanPham();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void TatDataBindingDataGridViewSanPham()
        {
            try
            {
                // Xóa các binding cũ (nếu có)
                txtMaSanPham.DataBindings.Clear();
                txtTenSanPham.DataBindings.Clear();
                txtMoTa.DataBindings.Clear();
                txtGia.DataBindings.Clear();
                txtDanhMuc.DataBindings.Clear();
                txtSoLuongTon.DataBindings.Clear();
                txtMucDoAnhHuongNguyenLieu.DataBindings.Clear();
                dtpNgayPhatHanh.DataBindings.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void BatDataBindingDataGridViewSanPham()
        {
            try
            {
                TatDataBindingDataGridViewSanPham();
                // Ràng buộc dữ liệu từ DataGridView vào các điều khiển
                txtMaSanPham.Text = dgv_dsSanPham.CurrentRow.Cells["MaSanPham"].Value.ToString();
                txtTenSanPham.Text = dgv_dsSanPham.CurrentRow.Cells["TenSanPham"].Value.ToString();
                txtMoTa.Text = dgv_dsSanPham.CurrentRow.Cells["MoTa"].Value.ToString();
                txtGia.Text = dgv_dsSanPham.CurrentRow.Cells["Gia"].Value.ToString();
                txtDanhMuc.Text = dgv_dsSanPham.CurrentRow.Cells["DanhMuc"].Value.ToString();
                txtSoLuongTon.Text = dgv_dsSanPham.CurrentRow.Cells["SoLuongTon"].Value.ToString();
                dtpNgayPhatHanh.Text = dgv_dsSanPham.CurrentRow.Cells["NgayPhatHanh"].Value.ToString();
                txtMucDoAnhHuongNguyenLieu.Text = dgv_dsSanPham.CurrentRow.Cells["MucDoAnhHuongTongNguyenLieu"].Value.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void ThemXoaSuaChiTietThanhPhan_ThemClicked(object sender, EventArgs e)
        {
            try
            {
                frm_themChiTietThanhPhanNguyenLieu frm = new frm_themChiTietThanhPhanNguyenLieu();
                frm.HoanTatClicked += Frm_HoanTatClicked;
                frm.ShowDialog();
                frm.StartPosition = FormStartPosition.CenterScreen;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
        }

        private void Frm_HoanTatClicked(object sender, (string maNguyenLieu, decimal phanTramNguyenLieu) e)
        {
            try
            {
                // Nhận dữ liệu từ form thêm chi tiết
                string maNguyenLieu = e.maNguyenLieu;
                decimal phanTramNguyenLieu = e.phanTramNguyenLieu;
                ChiTietThanhPhan cttpTemp = new ChiTietThanhPhan();
                string maSanPham = dgv_dsSanPham.CurrentRow.Cells["MaSanPham"].Value.ToString();
                cttpTemp.MaSanPham = maSanPham;
                cttpTemp.MaNguyenLieu = maNguyenLieu;
                cttpTemp.PhanTramNguyenLieu = phanTramNguyenLieu;
                //Lấy chi tiết thành phần từ form mới
                //Thêm sản phẩm vào listSanPham
                if (lstCTTP.Where(t => string.Equals(t.MaNguyenLieu, cttpTemp.MaNguyenLieu, StringComparison.OrdinalIgnoreCase)).FirstOrDefault() != null)
                //Phân biệt hoa thường sp001 và SP001 tức là trùng sản phẩm
                {
                    //Đã có sản phẩm này
                    MessageBox.Show("Đã tồn tại nguyên liệu này !!!");
                    txtMaSanPham.Focus();
                    //Return để cho người dùng nhập lại
                    return;
                }
                else //Chưa có sản phẩm náy
                {
                    ThemCTTPVaoDataGridView(cttpTemp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ThemCTTPVaoDataGridView(ChiTietThanhPhan cttpTemp)
        {
            try
            {
                //Thêm vào list Sản phẩm
                lstCTTP.Add(cttpTemp);
                //Tắt binding + selection changed
                dgv_ChiTietThanhPhan.SelectionChanged -= Dgv_ChiTietThanhPhan_SelectionChanged;
                //Sau khi tắt xong thì lòad lại
                dgv_ChiTietThanhPhan.DataSource = null;
                dgv_ChiTietThanhPhan.Invalidate();
                dgv_ChiTietThanhPhan.Refresh();
                dgv_ChiTietThanhPhan.DataSource = lstCTTP;
                dgv_ChiTietThanhPhan.AllowUserToAddRows = false;
                dgv_ChiTietThanhPhan.AutoGenerateColumns = false;
                dgv_ChiTietThanhPhan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_ChiTietThanhPhan.MultiSelect = false;
                dgv_ChiTietThanhPhan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv_ChiTietThanhPhan.Refresh();
                dgv_ChiTietThanhPhan.Columns[0].HeaderText = "Mã sản phẩm";
                dgv_ChiTietThanhPhan.Columns[1].HeaderText = "Mã nguyên liệu";
                dgv_ChiTietThanhPhan.Columns[2].HeaderText = "Phần trăm thành phần";
                dgv_ChiTietThanhPhan.Columns[3].Visible = false;
                dgv_ChiTietThanhPhan.Columns[4].Visible = false;
                dgv_ChiTietThanhPhan.SelectionChanged += Dgv_ChiTietThanhPhan_SelectionChanged;
                //dgv_ChiTietThanhPhan.Rows[1].Selected = true;
                //dgv_ChiTietThanhPhan.Rows[0].Selected = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void ThemXoaSuaChiTietThanhPhan_SuaClicked(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtPhanTramNguyenLieu.Text) == false)
                {
                    dgv_ChiTietThanhPhan.CurrentRow.Cells["PhanTramNguyenLieu"].Value = txtPhanTramNguyenLieu.Text;
                }
                else
                {
                    MessageBox.Show("Chưa nhập thông tin phần trăm nguyên liệu");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ThemXoaSuaChiTietThanhPhan_XoaClicked(object sender, EventArgs e)
        {
            try
            {
                XoaChiTietThanhPhanDuocChon();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void XoaChiTietThanhPhanDuocChon()
        {
            try
            {
                ChiTietThanhPhan cttpDuocChon = (ChiTietThanhPhan)dgv_ChiTietThanhPhan.CurrentRow.DataBoundItem;
                lstCTTP.Remove(cttpDuocChon);
                //Xóa grid view và cập nhật lại list mới cho grid view
                //Trước khi xóa tắt sự kiện selection Changed để không bị lỗi
                dgv_ChiTietThanhPhan.SelectionChanged -= Dgv_ChiTietThanhPhan_SelectionChanged;
                dgv_ChiTietThanhPhan.DataSource = null;
                dgv_ChiTietThanhPhan.DataSource = lstCTTP;
                //dgv_dsSanPham.Invalidate();
                dgv_ChiTietThanhPhan.Refresh();
                //Đã xóa sản phẩm
                //Bật data binding cho sản phẩm
                //Xóa text
                XoaTextBoxNguyenLieu();
                //Bật lại selection changed
                dgv_ChiTietThanhPhan.Columns[0].HeaderText = "Mã sản phẩm";
                dgv_ChiTietThanhPhan.Columns[1].HeaderText = "Mã nguyên liệu";
                dgv_ChiTietThanhPhan.Columns[2].HeaderText = "Phần trăm thành phần";
                dgv_ChiTietThanhPhan.Columns[3].Visible = false;
                dgv_ChiTietThanhPhan.Columns[4].Visible = false;
                dgv_ChiTietThanhPhan.SelectionChanged += Dgv_ChiTietThanhPhan_SelectionChanged;
                //dgv_ChiTietThanhPhan.Rows[1].Selected = true;
                //dgv_ChiTietThanhPhan.Rows[0].Selected = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ThemXoaSuaChiTietThanhPhan_LuuClicked(object sender, EventArgs e)
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
                    // Lấy danh sách chi tiết thành phần từ DataGridView
                    List<ChiTietThanhPhan> temp = (List<ChiTietThanhPhan>)dgv_ChiTietThanhPhan.DataSource;

                    // Thực hiện lưu dữ liệu qua lớp BLL
                    string maSanPham = dgv_dsSanPham.CurrentRow.Cells["MaSanPham"].Value.ToString();
                    bool kq = cttpBLL.CapNhatThemXoaSua(temp, maSanPham); // ctpBll là lớp quản lý nghiệp vụ của ChiTietThanhPhan

                    if (kq == true)
                    {
                        MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Sau khi lưu thành công, load lại danh sách
                        LoadLaiDanhSachChiTietThanhPhan();
                    }
                    else
                    {
                        MessageBox.Show("Lưu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLaiDanhSachChiTietThanhPhan()
        {
            try
            {
                //Tắt binding + selection changed
                dgv_ChiTietThanhPhan.SelectionChanged -= Dgv_ChiTietThanhPhan_SelectionChanged;
                //Sau khi tắt xong thì lòad lại
                cttpBLL = new ChiTietThanhPhanBLL();
                lstCTTP = cttpBLL.LayCTTP_CuaSanPham(dgv_dsSanPham.CurrentRow.Cells["MaSanPham"].Value.ToString());
                dgv_ChiTietThanhPhan.DataSource = null;
                dgv_ChiTietThanhPhan.Invalidate();
                dgv_ChiTietThanhPhan.Refresh();
                dgv_ChiTietThanhPhan.DataSource = lstCTTP;
                dgv_ChiTietThanhPhan.AllowUserToAddRows = false;
                dgv_ChiTietThanhPhan.AutoGenerateColumns = false;
                dgv_ChiTietThanhPhan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_ChiTietThanhPhan.MultiSelect = false;
                dgv_ChiTietThanhPhan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv_ChiTietThanhPhan.Refresh();
                dgv_ChiTietThanhPhan.Columns[0].HeaderText = "Mã sản phẩm";
                dgv_ChiTietThanhPhan.Columns[1].HeaderText = "Mã nguyên liệu";
                dgv_ChiTietThanhPhan.Columns[2].HeaderText = "Phần trăm thành phần";
                dgv_ChiTietThanhPhan.Columns[3].Visible = false;
                dgv_ChiTietThanhPhan.Columns[4].Visible = false;
                dgv_ChiTietThanhPhan.SelectionChanged += Dgv_ChiTietThanhPhan_SelectionChanged;
                //dgv_ChiTietThanhPhan.Rows[1].Selected = true;
                //dgv_ChiTietThanhPhan.Rows[0].Selected = true;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
