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
    public partial class frm_SanPham_TieuChi : Form
    {
        SanPhamBLL spBll = new SanPhamBLL();
        SanPham_TieuChiBLL cttcBLL = new SanPham_TieuChiBLL();
        List<SanPham> lstSanPham = new List<SanPham>();
        List<TieuChi_SanPham> lstCTTC = new List<TieuChi_SanPham>();
        public frm_SanPham_TieuChi()
        {
            InitializeComponent();

            this.Load += Frm_quanLyKhoHang_Load;
            themXoaSuaSanPham.ThemClicked += ThemXoaSuaSanPham_ThemClicked;
            themXoaSuaSanPham.HuyThemClicked += ThemXoaSuaSanPham_HuyThemClicked;
            themXoaSuaSanPham.XoaClicked += ThemXoaSuaSanPham_XoaClicked;
            themXoaSuaSanPham.SuaClicked += ThemXoaSuaSanPham_SuaClicked;
            themXoaSuaSanPham.LuuClicked += ThemXoaSuaSanPham_LuuClicked;

            themXoaSuaCTTP.ThemClicked += ThemXoaSuaTieuChi_SanPham_ThemClicked;
            themXoaSuaCTTP.XoaClicked += ThemXoaSuaTieuChi_SanPham_XoaClicked;
            themXoaSuaCTTP.SuaClicked += ThemXoaSuaTieuChi_SanPham_SuaClicked;
            themXoaSuaCTTP.LuuClicked += ThemXoaSuaTieuChi_SanPham_LuuClicked;
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
                //txtMucDoAnhHuongNguyenLieu.DataBindings.Clear();
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
                    List<SanPham> temp = (List<SanPham>)dgv_dsSanPham.DataSource;
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

        private void ThemSanPhamVaoDataGridView(SanPham sp)
        {
            try
            {
                //Thêm vào list Sản phẩm
                lstSanPham.Add(sp);
                //Xóa grid view và cập nhật lại list mới cho grid view
                //Trước khi thêm tắt sự kiện selection Changed để không bị lỗi
                
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

        private void ThemXoaSuaSanPham_SuaClicked(object sender, EventArgs e)
        {
            try
            {
                if (KiemTraRongTextBoxSanPham() == false)
                {
                    if (KiemTraRongTextBoxSanPham() == false) //Tất cả đều nhập
                    {
                        SanPham sp = LaySanPhamTuGiaoDien();
                        dgv_dsSanPham.CurrentRow.Cells["TenSanPham"].Value = sp.TenSanPham;
                        dgv_dsSanPham.CurrentRow.Cells["MoTa"].Value = sp.MoTa;
                        dgv_dsSanPham.CurrentRow.Cells["Gia"].Value = sp.Gia;
                        dgv_dsSanPham.CurrentRow.Cells["DanhMuc"].Value = sp.DanhMuc;
                        dgv_dsSanPham.CurrentRow.Cells["SoLuongTon"].Value = sp.SoLuongTon;
                        dgv_dsSanPham.CurrentRow.Cells["NgayPhatHanh"].Value = sp.NgayPhatHanh;
                        dgv_dsSanPham.CurrentRow.Cells["MucDoAnhHuongTongNguyenLieu"].Value = sp.MucDoAnhHuongTongNguyenLieu;
                    }
                    else
                    {
                        MessageBox.Show("Có thông tin đang trống");
                    }
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
                //Kiểm tra xem thành phần có tiêu chí nào hay chưa          
                List<TieuChi_SanPham> lstCTTC = cttcBLL.LayCTTC_CuaSanPham(spDuocChon.MaSanPham);
                
                if (lstCTTC == null || lstCTTC.Count == 0)
                {
                    //Nếu không có chi tiết thành phần nào thì xóa được
                    lstSanPham.Remove(spDuocChon);
                    //Xóa grid view và cập nhật lại list mới cho grid view
                    //Trước khi xóa tắt sự kiện selection Changed để không bị lỗi
                    //Tắt luôn databinding
                    
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
                    MessageBox.Show("Không thể xóa sản phẩm này vì có dữ liệu trong bảng sản phẩm tiêu chí");
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

                lstCTTC = cttcBLL.LayCTTC_CuaSanPham(masp);
                if (lstCTTC != null && lstCTTC.Count > 0)
                {
                    //Load dgvTieuChi_SanPham
                    LoadTieuChi_SanPham();
                }
                else
                {
                    //Tắt selection changed
                    dgv_TieuChi_SanPham.SelectionChanged -= Dgv_TieuChi_SanPham_SelectionChanged;
                    dgv_TieuChi_SanPham.DataSource = null;
                    //Xóa text box nguyen lieu
                    XoaTextBoxTieuChi();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void LoadTieuChi_SanPham()
        {
            dgv_TieuChi_SanPham.DataSource = lstCTTC;
            dgv_TieuChi_SanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_TieuChi_SanPham.MultiSelect = false;
            dgv_TieuChi_SanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_TieuChi_SanPham.SelectionChanged += Dgv_TieuChi_SanPham_SelectionChanged;
            //dgv_TieuChi_SanPham.Rows[1].Selected = true;
            //dgv_TieuChi_SanPham.Rows[0].Selected = true;
            dgv_TieuChi_SanPham.Columns[3].Visible = false;
            dgv_TieuChi_SanPham.Columns[4].Visible = false;
        }

        private void XoaTextBoxTieuChi()
        {
            txtMaTieuChi.Clear();
            txtTenTieuChi.Clear();
            txtTrongSo.Clear();
        }

        private void Dgv_TieuChi_SanPham_SelectionChanged(object sender, EventArgs e)
        {
            List<TieuChi_SanPham> lstCTTC = (List<TieuChi_SanPham>)dgv_TieuChi_SanPham.DataSource;
            if (lstCTTC != null && lstCTTC.Count > 0)
            {
                string maTieuChi = dgv_TieuChi_SanPham.CurrentRow.Cells["MaTieuChi"].Value.ToString();
                string trongSo = dgv_TieuChi_SanPham.CurrentRow.Cells["TrongSo"].Value.ToString();
                TieuChiBLL nlBLl = new TieuChiBLL();
                TieuChi TieuChi = nlBLl.LayTieuChi(maTieuChi);
                txtMaTieuChi.Enabled = false;
                txtTenTieuChi.Enabled = false;

                txtMaTieuChi.Text = TieuChi.MaTieuChi;
                txtTenTieuChi.Text = TieuChi.TenTieuChi;
                txtTrongSo.Text = trongSo;
            }
        }







        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void ThemXoaSuaTieuChi_SanPham_ThemClicked(object sender, EventArgs e)
        {
            try
            {
                frm_themTieuChi_SanPhamTieuChi frm = new frm_themTieuChi_SanPhamTieuChi();
                frm.HoanTatClicked += Frm_HoanTatClicked;
                frm.ShowDialog();
                frm.StartPosition = FormStartPosition.CenterScreen;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Frm_HoanTatClicked(object sender, (string maTieuChi, decimal trongSo) e)
        {
            try
            {
                // Nhận dữ liệu từ form thêm chi tiết
                string maTieuChi = e.maTieuChi;
                decimal trongSo = e.trongSo;
                TieuChi_SanPham cttpTemp = new TieuChi_SanPham();
                string maSanPham = dgv_dsSanPham.CurrentRow.Cells["MaSanPham"].Value.ToString();
                cttpTemp.MaSanPham = maSanPham;
                cttpTemp.MaTieuChi = maTieuChi;
                cttpTemp.TrongSo = trongSo;
                //Lấy chi tiết thành phần từ form mới
                //Thêm sản phẩm vào listSanPham
                if (lstCTTC.Where(t => string.Equals(t.MaTieuChi, cttpTemp.MaTieuChi, StringComparison.OrdinalIgnoreCase)).FirstOrDefault() != null)
                //Phân biệt hoa thường sp001 và SP001 tức là trùng sản phẩm
                {
                    //Đã có sản phẩm này
                    MessageBox.Show("Đã tồn tại tiêu chí này !!!");
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

        private void ThemCTTPVaoDataGridView(TieuChi_SanPham cttpTemp)
        {
            try
            {
                //Thêm vào list Sản phẩm
                lstCTTC.Add(cttpTemp);
                //Tắt binding + selection changed
                dgv_TieuChi_SanPham.SelectionChanged -= Dgv_TieuChi_SanPham_SelectionChanged;
                //Sau khi tắt xong thì lòad lại
                dgv_TieuChi_SanPham.DataSource = null;
                dgv_TieuChi_SanPham.Invalidate();
                dgv_TieuChi_SanPham.Refresh();
                dgv_TieuChi_SanPham.DataSource = lstCTTC;
                dgv_TieuChi_SanPham.AllowUserToAddRows = false;
                dgv_TieuChi_SanPham.AutoGenerateColumns = false;
                dgv_TieuChi_SanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_TieuChi_SanPham.MultiSelect = false;
                dgv_TieuChi_SanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv_TieuChi_SanPham.Refresh();
                dgv_TieuChi_SanPham.Columns[0].HeaderText = "Mã tiêu chí";
                dgv_TieuChi_SanPham.Columns[1].HeaderText = "Mã sản phẩm";
                dgv_TieuChi_SanPham.Columns[2].HeaderText = "Trọng số";
                dgv_TieuChi_SanPham.Columns[3].Visible = false;
                dgv_TieuChi_SanPham.Columns[4].Visible = false;
                dgv_TieuChi_SanPham.SelectionChanged += Dgv_TieuChi_SanPham_SelectionChanged;
                //dgv_TieuChi_SanPham.Rows[1].Selected = true;
                //dgv_TieuChi_SanPham.Rows[0].Selected = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void ThemXoaSuaTieuChi_SanPham_SuaClicked(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtTrongSo.Text) == false)
                {
                    dgv_TieuChi_SanPham.CurrentRow.Cells["TrongSo"].Value = txtTrongSo.Text;
                }
                else
                {
                    MessageBox.Show("Chưa nhập thông tin trọng số");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ThemXoaSuaTieuChi_SanPham_XoaClicked(object sender, EventArgs e)
        {
            try
            {
                XoaTieuChi_SanPhamDuocChon();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void XoaTieuChi_SanPhamDuocChon()
        {
            try
            {
                TieuChi_SanPham cttpDuocChon = (TieuChi_SanPham)dgv_TieuChi_SanPham.CurrentRow.DataBoundItem;
                lstCTTC.Remove(cttpDuocChon);
                //Xóa grid view và cập nhật lại list mới cho grid view
                //Trước khi xóa tắt sự kiện selection Changed để không bị lỗi
                dgv_TieuChi_SanPham.SelectionChanged -= Dgv_TieuChi_SanPham_SelectionChanged;
                dgv_TieuChi_SanPham.DataSource = null;
                dgv_TieuChi_SanPham.DataSource = lstCTTC;
                //dgv_dsSanPham.Invalidate();
                dgv_TieuChi_SanPham.Refresh();
                //Đã xóa sản phẩm
                //Bật data binding cho sản phẩm
                //Xóa text
                XoaTextBoxTieuChi();
                //Bật lại selection changed
                dgv_TieuChi_SanPham.Columns[0].HeaderText = "Mã sản phẩm";
                dgv_TieuChi_SanPham.Columns[1].HeaderText = "Mã tiêu chí";
                dgv_TieuChi_SanPham.Columns[2].HeaderText = "Trọng số";
                dgv_TieuChi_SanPham.Columns[3].Visible = false;
                dgv_TieuChi_SanPham.Columns[4].Visible = false;
                dgv_TieuChi_SanPham.SelectionChanged += Dgv_TieuChi_SanPham_SelectionChanged;
                //dgv_TieuChi_SanPham.Rows[1].Selected = true;
                //dgv_TieuChi_SanPham.Rows[0].Selected = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ThemXoaSuaTieuChi_SanPham_LuuClicked(object sender, EventArgs e)
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
                    List<TieuChi_SanPham> temp = (List<TieuChi_SanPham>)dgv_TieuChi_SanPham.DataSource;

                    // Thực hiện lưu dữ liệu qua lớp BLL
                    string maSanPham = dgv_dsSanPham.CurrentRow.Cells["MaSanPham"].Value.ToString();
                    bool kq = cttcBLL.CapNhatThemXoaSua(temp, maSanPham); // ctpBll là lớp quản lý nghiệp vụ của TieuChi_SanPham

                    if (kq == true)
                    {
                        MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Sau khi lưu thành công, load lại danh sách
                        LoadLaiDanhSachTieuChi_SanPham();
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

        private void LoadLaiDanhSachTieuChi_SanPham()
        {
            try
            {
                //Tắt binding + selection changed
                dgv_TieuChi_SanPham.SelectionChanged -= Dgv_TieuChi_SanPham_SelectionChanged;
                //Sau khi tắt xong thì lòad lại
                cttcBLL = new SanPham_TieuChiBLL();
                lstCTTC = cttcBLL.LayCTTC_CuaSanPham(dgv_dsSanPham.CurrentRow.Cells["MaSanPham"].Value.ToString());
                dgv_TieuChi_SanPham.DataSource = null;
                dgv_TieuChi_SanPham.Invalidate();
                dgv_TieuChi_SanPham.Refresh();
                dgv_TieuChi_SanPham.DataSource = lstCTTC;
                dgv_TieuChi_SanPham.AllowUserToAddRows = false;
                dgv_TieuChi_SanPham.AutoGenerateColumns = false;
                dgv_TieuChi_SanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_TieuChi_SanPham.MultiSelect = false;
                dgv_TieuChi_SanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv_TieuChi_SanPham.Refresh();
                dgv_TieuChi_SanPham.Columns[0].HeaderText = "Mã tiêu chí";
                dgv_TieuChi_SanPham.Columns[1].HeaderText = "Mã sản phẩm";
                dgv_TieuChi_SanPham.Columns[2].HeaderText = "Trọng số";
                dgv_TieuChi_SanPham.Columns[3].Visible = false;
                dgv_TieuChi_SanPham.Columns[4].Visible = false;
                dgv_TieuChi_SanPham.SelectionChanged += Dgv_TieuChi_SanPham_SelectionChanged;
                //dgv_TieuChi_SanPham.Rows[1].Selected = true;
                //dgv_TieuChi_SanPham.Rows[0].Selected = true;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
