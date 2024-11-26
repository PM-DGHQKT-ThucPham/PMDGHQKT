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
using DTO;
namespace GUI
{
    public partial class frm_quanLyKhoHang : Form
    {
        SanPhamBLL spBll = new SanPhamBLL();
        ChiTietThanhPhanBLL cttpBLL = new ChiTietThanhPhanBLL();
        List<SanPham> lstSanPham = new List<SanPham>();
        public frm_quanLyKhoHang()
        {
            InitializeComponent();
            
            this.Load += Frm_quanLyKhoHang_Load;
            themXoaSuaSanPham.ThemClicked += ThemXoaSuaSanPham_ThemClicked;
            themXoaSuaSanPham.HuyThemClicked += ThemXoaSuaSanPham_HuyThemClicked;
            themXoaSuaSanPham.XoaClicked += ThemXoaSuaSanPham_XoaClicked;
            themXoaSuaSanPham.SuaClicked += ThemXoaSuaSanPham_SuaClicked;
            themXoaSuaSanPham.LuuClicked += ThemXoaSuaSanPham_LuuClicked;
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

                throw ex;
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

                throw ex;
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
                throw ex;
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


    }
}
