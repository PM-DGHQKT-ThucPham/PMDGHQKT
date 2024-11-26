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

            themXoaSuaChiPhi.ThemClicked += ThemXoaSuaChiPhi_ThemClicked;
            themXoaSuaChiPhi.HuyThemClicked += ThemXoaSuaChiPhi_HuyThemClicked;
            themXoaSuaChiPhi.XoaClicked += ThemXoaSuaChiPhi_XoaClicked;
            themXoaSuaChiPhi.SuaClicked += ThemXoaSuaChiPhi_SuaClicked;
            themXoaSuaChiPhi.LuuClicked += ThemXoaSuaChiPhi_LuuClicked;
            btn_clear.Click += Btn_clear_Click;
            // Cấu hình DataGridView
            dgv_dsLoaiChiPhi.AllowUserToAddRows = true;
        }

        private void ThemXoaSuaChiPhi_LuuClicked(object sender, EventArgs e)
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
                    List<LoaiChiPhi> temp = (List<LoaiChiPhi>)dgv_dsLoaiChiPhi.DataSource;
                    // Thực hiện lưu dữ liệu
                    bool kq = _loaiChiPhiBLL.CapNhatThemXoaSua(temp);
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

        private void ThemXoaSuaChiPhi_SuaClicked(object sender, EventArgs e)
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

                throw ex;
            }
        }

        private void ThemXoaSuaChiPhi_XoaClicked(object sender, EventArgs e)
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

        private void ThemXoaSuaChiPhi_HuyThemClicked(object sender, EventArgs e)
        {
            try
            {
                txtMaSanPham.Enabled = false;
                BatDataBindingDataGridViewSanPham();
                dgv_dsSanPham.SelectionChanged += Dgv_dsSanPham_SelectionChanged;
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
                throw ex;
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
                throw ex;
            }
        }

        private void Dgv_dsSanPham_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                BatDataBindingDataGridViewSanPham();
                string masp = dgv_dsSanPham.SelectedRows[0].Cells["MaSanPham"].Value.ToString();
                //SanPham sp = spBll.LaySanPhamTheoMa(masp);
                //Load dgvChiTietThanhPhan
                dgv_ChiTietThanhPhan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv_ChiTietThanhPhan.MultiSelect = false;
                dgv_ChiTietThanhPhan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                List<ChiTietThanhPhan> lstCTTP = cttpBLL.LayCTTP_CuaSanPham(masp);
                if (lstCTTP != null && lstCTTP.Count > 0)
                {
                    dgv_ChiTietThanhPhan.DataSource = lstCTTP;
                    dgv_ChiTietThanhPhan.Columns[3].Visible = false;
                    dgv_ChiTietThanhPhan.Columns[4].Visible = false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
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

                throw ex;
            }
        }

        private SanPham LaySanPhamTuGiaoDien()
        {
            try
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
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private bool KiemTraRongTextBoxSanPham()
        {
            try
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
            catch (Exception ex)
            {

                throw ex;
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

                throw ex;
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

                throw ex;
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

                throw ex;
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

                throw ex;
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

                throw ex;
            }
        }


        private void Btn_clear_Click(object sender, EventArgs e)
        {
            // Kích hoạt chế độ nhập liệu
            cbo_loaiChiPhi.Enabled = true; // Mã chi phí
            txt_tenLoaiChiPhi.Enabled = true; // Tên chi phí
            txt_moTaLoaiChiPhi.Enabled = true; // Mô tả
            txt_tongTien.Enabled = true; // Số tiền
            cbo_loaiChiPhi.Text = string.Empty;
            txt_tenLoaiChiPhi.Text = string.Empty;
            txt_tongTien.Text = string.Empty;
            txt_moTaLoaiChiPhi.Text = string.Empty;
        }


        private void Dgv_dsChiPhi_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                //hiển thị dòng đang chọn lên textbox
                if (dgv_dsChiPhi.CurrentRow != null)
                {
                    txt_maChiPhi.Text = dgv_dsChiPhi.CurrentRow.Cells["MaChiPhi"].Value.ToString();
                    txt_moTa.Text = dgv_dsChiPhi.CurrentRow.Cells["MoTa"].Value.ToString();
                    txt_soTien.Text = dgv_dsChiPhi.CurrentRow.Cells["SoTien"].Value.ToString();
                    dtp_thoiGian.Value = Convert.ToDateTime(dgv_dsChiPhi.CurrentRow.Cells["ThoiGian"].Value.ToString());
                    txt_maLoaiChiPhi.Text = dgv_dsChiPhi.CurrentRow.Cells["MaLoaiChiPhi"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Dgv_dsLoaiChiPhi_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                // Check if the current row is not null
                if (dgv_dsLoaiChiPhi.CurrentRow != null)
                {
                    // Check if the specific cell is not null
                    var cell = dgv_dsLoaiChiPhi.CurrentRow.Cells["MaLoaiChiPhi"];
                    if (cell != null && cell.Value != null)
                    {
                        string loaiChiPhi = cell.Value.ToString();
                        cbo_loaiChiPhi.Text = loaiChiPhi;
                        txt_tenLoaiChiPhi.Text = dgv_dsLoaiChiPhi.CurrentRow.Cells["TenLoaiChiPhi"].Value.ToString();
                        txt_moTaLoaiChiPhi.Text = dgv_dsLoaiChiPhi.CurrentRow.Cells["MoTa"].Value.ToString();
                        txt_tongTien.Text = dgv_dsLoaiChiPhi.CurrentRow.Cells["TongTien"].Value.ToString();
                        // lấy mã sản phẩm từ dgv_dsLoaiChiPhi
                        string maLoaiChiPhi = loaiChiPhi;
                        HienThiChiPhi(maLoaiChiPhi, maSanPham);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        //viết hàm xử lý ở đây

        private void LoadLaiDanhSachChiPhi()
        {
            try
            {
                //Tắt binding + selection changed
                TatDataBindingDataGridViewSanPham();
                dgv_dsLoaiChiPhi.SelectionChanged -= Dgv_dsSanPham_SelectionChanged;
                //Sau khi tắt xong thì lòad lại
                _lstLoaiChiPhi = spBll.LayDanhSachSanPham();
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

                throw ex;
            }
        }
        // thêm loại chi phí
        private void ThemLoaiChiPhiVaoDataGridView()
        {
            if(string.IsNullOrEmpty(txt_maLoaiChiPhi.Text) || string.IsNullOrEmpty(txt_tenLoaiChiPhi.Text) || string.IsNullOrEmpty(txt_tongTien.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(string.IsNullOrEmpty(txt_maLoaiChiPhi.Text) || string.IsNullOrEmpty(txt_tenLoaiChiPhi.Text) || string.IsNullOrEmpty(txt_tongTien.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(string.IsNullOrEmpty(txt_moTa.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(txt_tongTien.Text, out decimal tongTien))
            {
                MessageBox.Show("Tổng tiền phải là số hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra nếu mã loại chi phí hoặc tên loại chi phí đã tồn tại
            foreach (DataGridViewRow row in dgv_dsLoaiChiPhi.Rows)
            {
                if (row.Cells["MaLoaiChiPhi"].Value?.ToString() == txt_maLoaiChiPhi.Text)
                {
                    MessageBox.Show("Mã loại chi phí đã tồn tại! Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Thêm dữ liệu vào DataGridView
            dgv_dsLoaiChiPhi.Rows.Add(txt_maLoaiChiPhi.Text, txt_tenLoaiChiPhi.Text,txt_moTa.Text, tongTien,maSanPham);

            MessageBox.Show("Thêm dòng mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgv_dsLoaiChiPhi.Refresh();
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
            catch(Exception ex)
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
            catch(Exception ex)
            {
                throw ex;
            }

        }
        //load dữ liệu chi phí
        private void HienThiChiPhi(string maLoaiChiPhi, string maSanPham)
        {
            try
            {
                _lstChiPhi = _chiPhiBLL.LayChiPhiTheoMaLoaiChiPhi(maLoaiChiPhi, maSanPham);
                if (_lstChiPhi != null)
                {
                    dgv_dsChiPhi.DataSource = _lstChiPhi;
                    KhoiTaoChiPhi();
                    themCotSoThuTu(dgv_dsChiPhi);
                    dgv_dsChiPhi.RowPostPaint -= dgvSanPham_RowPostPaint;
                    dgv_dsChiPhi.RowPostPaint += dgvSanPham_RowPostPaint;
                    dgv_dsChiPhi.Invalidate();
                    dgv_dsChiPhi.Refresh();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi load dữ liệu chi phí");
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

        private void themXoaSua_Load(object sender, EventArgs e)
        {

        }
    }
}
