using DevExpress.Internal;
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
using BLL;
using DevExpress.XtraEditors.Filtering.Templates;
namespace GUI
{
    public partial class frm_quanLyThiTruong : Form
    {
        List<ThiTruong> lstThiTruong = new List<ThiTruong> ();
        ThiTruongBLL thiTruongBll = new ThiTruongBLL ();
        public frm_quanLyThiTruong()
        {
            InitializeComponent();
            this.Load += Frm_quanLyThiTruong_Load;
            themXoaSuaThiTruong.ThemClicked += ThemXoaSuaThiTruong_ThemClicked;
            themXoaSuaThiTruong.HuyThemClicked += ThemXoaSuaThiTruong_HuyThemClicked;
            themXoaSuaThiTruong.XoaClicked += ThemXoaSuaThiTruong_XoaClicked;
            themXoaSuaThiTruong.SuaClicked += ThemXoaSuaThiTruong_SuaClicked;
            themXoaSuaThiTruong.LuuClicked += ThemXoaSuaThiTruong_LuuClicked;
            
        }
        //Bước 6
        private void ThemXoaSuaThiTruong_LuuClicked(object sender, EventArgs e)
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
                    List<ThiTruong> temp = (List<ThiTruong>)dgv_dsThiTruong.DataSource;
                    // Thực hiện lưu dữ liệu
                    bool kq = thiTruongBll.CapNhatThemXoaSuaThiTruong(temp, cbbSanPham.SelectedValue.ToString());
                    if (kq == true)
                    {
                        MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Sau khi lưu thành công, load lại GridView
                        LoadLaiDanhSachThiTruong();
                    }
                    else
                    {
                        MessageBox.Show("Lưu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Trục trặc khi lưu"+ex.Message);
            }
        }
        private void LoadLaiDanhSachThiTruong()
        {
            try
            {
                // Tắt selection changed để tránh lỗi khi cập nhật
                dgv_dsThiTruong.SelectionChanged -= Dgv_dsThiTruong_SelectionChanged;

                // Load lại danh sách thị trường từ database
                thiTruongBll = new ThiTruongBLL();
                lstThiTruong = thiTruongBll.LayDanhSachThiTruongCuaSanPham(cbbSanPham.SelectedValue.ToString());

                // Cập nhật DataGridView với danh sách thị trường mới
                if (lstThiTruong != null && lstThiTruong.Count > 0)
                {
                    dgv_dsThiTruong.DataSource = null;
                    dgv_dsThiTruong.Invalidate();
                    dgv_dsThiTruong.Refresh();
                    dgv_dsThiTruong.DataSource = lstThiTruong;

                    // Cấu hình lại DataGridView
                    dgv_dsThiTruong.AllowUserToAddRows = false;
                    dgv_dsThiTruong.AutoGenerateColumns = false;
                    dgv_dsThiTruong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgv_dsThiTruong.MultiSelect = false;
                    dgv_dsThiTruong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgv_dsThiTruong.Refresh();

                    // Đặt tiêu đề cho các cột
                    dgv_dsThiTruong.Columns[0].HeaderText = "Mã thị trường";
                    dgv_dsThiTruong.Columns[1].HeaderText = "Loại thị trường";
                    dgv_dsThiTruong.Columns[2].HeaderText = "Mô tả";
                    dgv_dsThiTruong.Columns[3].HeaderText = "Giá trị";
                    dgv_dsThiTruong.Columns[4].HeaderText = "Thời gian";
                    dgv_dsThiTruong.Columns[5].Visible = false;
                    dgv_dsThiTruong.Columns[6].Visible = false;

                    // Bật lại sự kiện SelectionChanged
                    BatDataBindingDataGridViewThiTruong();
                    dgv_dsThiTruong.SelectionChanged += Dgv_dsThiTruong_SelectionChanged;
                }
                else
                {
                    dgv_dsThiTruong.SelectionChanged -= Dgv_dsThiTruong_SelectionChanged;
                    dgv_dsThiTruong.DataSource = null;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load lai danh sách : " + ex.Message);
            }
        }




        //Bước 5
        private void ThemXoaSuaThiTruong_SuaClicked(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu các TextBox không bị trống
                if (KiemTraRongTextBoxThiTruong() == false)
                {
                    // Nếu không có trường nào trống
                    ThiTruong tt = LayThiTruongTuGiaoDien();
                    // Cập nhật thông tin thị trường vào DataGridView
                    dgv_dsThiTruong.CurrentRow.Cells["LoaiThiTruong"].Value = tt.LoaiThiTruong;
                    dgv_dsThiTruong.CurrentRow.Cells["MoTa"].Value = tt.MoTa;
                    dgv_dsThiTruong.CurrentRow.Cells["GiaTri"].Value = tt.GiaTri;
                    dgv_dsThiTruong.CurrentRow.Cells["ThoiGian"].Value = tt.ThoiGian;
                }
                else
                {
                    MessageBox.Show("Có thông tin đang trống. Vui lòng kiểm tra lại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa : "+ex.Message);
            }
        }


        //Bước 4
        private void ThemXoaSuaThiTruong_XoaClicked(object sender, EventArgs e)
        {
            try
            {
                XoaThiTruongDuocChon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa : "+ex.Message);
            }
        }
        private void XoaThiTruongDuocChon()
        {
            try
            {
                // Lấy thị trường được chọn từ DataGridView
                ThiTruong ttDuocChon = (ThiTruong)dgv_dsThiTruong.CurrentRow.DataBoundItem;
                // Nếu không có dữ liệu liên kết thì có thể xóa
                lstThiTruong.Remove(ttDuocChon);

                // Xóa grid view và cập nhật lại danh sách mới cho grid view
                dgv_dsThiTruong.SelectionChanged -= Dgv_dsThiTruong_SelectionChanged;
                dgv_dsThiTruong.DataSource = null;
                dgv_dsThiTruong.DataSource = lstThiTruong;
                dgv_dsThiTruong.Refresh();

                // Đã xóa thị trường
                // Xóa text trong textbox
                XoaTextBoxThiTruong();
                // Bật lại sự kiện SelectionChanged
                dgv_dsThiTruong.SelectionChanged += Dgv_dsThiTruong_SelectionChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa thị trường được chọn : " + ex.Message);
            }
        }


        //Bước 3
        private void ThemXoaSuaThiTruong_HuyThemClicked(object sender, EventArgs e)
        {
            try
            {
                txtMaThiTruong.Enabled = false;
                BatDataBindingDataGridViewThiTruong();
                dgv_dsThiTruong.SelectionChanged += Dgv_dsThiTruong_SelectionChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lõi khi hủy thêm :"+ex.Message);
            }
        }

        //Bước 2
        private void ThemXoaSuaThiTruong_ThemClicked(object sender, EventArgs e)
        {
            try
            {
                // Nếu nút hủy bị ẩn tức là nút thêm chưa được nhấn lần đầu
                if (themXoaSuaThiTruong.BtnHuyThem.Enabled == false)
                {
                    // Bật txtMaThiTruong
                    txtMaThiTruong.Enabled = true;
                    // Nếu như nút thêm được nhấn lần đầu thì tắt selection changed
                    dgv_dsThiTruong.SelectionChanged -= Dgv_dsThiTruong_SelectionChanged;
                    // Sau đó xóa hết các textbox
                    XoaTextBoxThiTruong();
                    // Ẩn các nút Lưu Xóa Sửa để người dùng không nhấn được
                    themXoaSuaThiTruong.BtnXoa.Enabled = false;
                    themXoaSuaThiTruong.BtnSua.Enabled = false;
                    themXoaSuaThiTruong.BtnLuu.Enabled = false;
                    // Đồng thời cho nút hủy lưu sáng lên để có thể hủy lưu
                    themXoaSuaThiTruong.BtnHuyThem.Enabled = true;
                    // Đổi image của btnThem thành dấu tick Xanh
                    themXoaSuaThiTruong.BtnThem.Image = Properties.Resources.icons8_tick_35;
                }
                else // Ngược lại btnHuyThem = true tức là btnThem đang ở trạng thái chờ xác nhận
                {
                    if (KiemTraRongTextBoxThiTruong() == false) // Nếu tất cả text box đều nhập giá trị
                    {
                        // Lấy thị trường từ text box
                        ThiTruong tt = LayThiTruongTuGiaoDien();
                        // Thêm thị trường vào listThiTruong
                        if (lstThiTruong.Where(t => string.Equals(t.MaThiTruong, tt.MaThiTruong, StringComparison.OrdinalIgnoreCase)).FirstOrDefault() != null)
                        {
                            // Đã có thị trường này
                            MessageBox.Show("Đã tồn tại mã thị trường này !!!");
                            txtMaThiTruong.Focus();
                            // Return để cho người dùng nhập lại
                            return;
                        }
                        else // Chưa có thị trường này
                        {
                            ThemThiTruongVaoDataGridView(tt);
                        }
                    }
                    else
                    {
                        // Thông báo chưa nhập
                        MessageBox.Show("Chưa nhập đầy đủ các giá trị của thị trường. Vui lòng kiểm tra lại");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm:"+ex.Message);
            }
        }
        private void ThemThiTruongVaoDataGridView(ThiTruong tt)
        {
            try
            {
                // Thêm vào list Thị Trường
                lstThiTruong.Add(tt);
                // Xóa grid view và cập nhật lại list mới cho grid view
                dgv_dsThiTruong.SelectionChanged -= Dgv_dsThiTruong_SelectionChanged;
                dgv_dsThiTruong.DataSource = null;
                dgv_dsThiTruong.Invalidate();
                dgv_dsThiTruong.Refresh();
                dgv_dsThiTruong.DataSource = lstThiTruong;
                // Đã thêm thị trường xong
                // Ẩn đi txtMaThiTruong
                txtMaThiTruong.Enabled = false;
                // Trả lại các nút như ban đầu
                themXoaSuaThiTruong.BtnXoa.Enabled = true;
                themXoaSuaThiTruong.BtnSua.Enabled = true;
                themXoaSuaThiTruong.BtnLuu.Enabled = true;
                themXoaSuaThiTruong.BtnHuyThem.Enabled = false;
                themXoaSuaThiTruong.BtnThem.Image = Properties.Resources.icons8_add_35;
                // Bật data binding cho thị trường
                BatDataBindingDataGridViewThiTruong();
                // Bật lại selection changed
                dgv_dsThiTruong.SelectionChanged += Dgv_dsThiTruong_SelectionChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm vào grid view"+ex.Message);
            }
        }

        private ThiTruong LayThiTruongTuGiaoDien()
        {
            ThiTruong tt = new ThiTruong();
            tt.MaThiTruong = txtMaThiTruong.Text;
            tt.LoaiThiTruong = txtLoaiThiTruong.Text;
            tt.MoTa = txtMoTa.Text;
            tt.GiaTri = decimal.Parse(txtGiaTri.Text);
            tt.ThoiGian = dateTimePickerThoiGian.Value; // Đảm bảo rằng định dạng ngày hợp lệ
            return tt;
        }

        private bool KiemTraRongTextBoxThiTruong()
        {
            if (String.IsNullOrEmpty(txtMaThiTruong.Text))
            {
                return true;
            }
            if (String.IsNullOrEmpty(txtLoaiThiTruong.Text))
            {
                return true;
            }
            if (String.IsNullOrEmpty(txtMoTa.Text))
            {
                return true;
            }
            if (String.IsNullOrEmpty(txtGiaTri.Text))
            {
                return true;
            }
            return false;
        }

        private void XoaTextBoxThiTruong()
        {
            try
            {
                txtMaThiTruong.Clear();
                txtLoaiThiTruong.Clear();
                txtGiaTri.Clear();
                txtMoTa.Clear();
                dateTimePickerThoiGian.Value = DateTime.Now.Date;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //Bước 1
        private void Frm_quanLyThiTruong_Load(object sender, EventArgs e)
        {
            try
            {
                LoadComboboxSanPham();
                //LoadDanhSachThiTruong();
                txtMaThiTruong.Enabled = false;  // Không cho phép chỉnh sửa Mã Thị Trường khi mới tải form
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load form"+ex.Message);
            }
        }

        private void LoadComboboxSanPham()
        {
            SanPhamBLL sanPhamBLL = new SanPhamBLL();
            List<SanPham> lstSanPham = sanPhamBLL.LayDanhSachSanPham();
            cbbSanPham.DataSource = lstSanPham;
            cbbSanPham.ValueMember = "MaSanPham";
            cbbSanPham.DisplayMember = "TenSanPham";
            cbbSanPham.SelectedIndex = -1;
            cbbSanPham.SelectedIndex = 0;
            cbbSanPham.SelectedIndexChanged += CbbSanPham_SelectedIndexChanged;
        }

        private void CbbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDanhSachThiTruong();
        }

        private void LoadDanhSachThiTruong()
        {
            try
            {
                string masanpham = cbbSanPham.SelectedValue.ToString();
                lstThiTruong = thiTruongBll.LayDanhSachThiTruongCuaSanPham(masanpham); // Lấy dữ liệu từ BLL
                if (lstThiTruong != null && lstThiTruong.Count > 0)
                {
                    dgv_dsThiTruong.SelectionChanged -= Dgv_dsThiTruong_SelectionChanged;
                    dgv_dsThiTruong.DataSource = lstThiTruong;
                    dgv_dsThiTruong.AllowUserToAddRows = false;
                    dgv_dsThiTruong.AutoGenerateColumns = false;
                    dgv_dsThiTruong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgv_dsThiTruong.MultiSelect = false;
                    dgv_dsThiTruong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgv_dsThiTruong.Columns[0].HeaderText = "Mã thị trường";
                    dgv_dsThiTruong.Columns[1].HeaderText = "Loại thị trường";
                    dgv_dsThiTruong.Columns[2].HeaderText = "Mô tả";
                    dgv_dsThiTruong.Columns[3].HeaderText = "Giá trị";
                    dgv_dsThiTruong.Columns[4].HeaderText = "Thời gian";
                    dgv_dsThiTruong.Columns[5].Visible = false;
                    dgv_dsThiTruong.Columns[6].Visible = false;
                    dgv_dsThiTruong.Rows[0].Selected = true;
                    BatDataBindingDataGridViewThiTruong();
                    dgv_dsThiTruong.SelectionChanged += Dgv_dsThiTruong_SelectionChanged;
                }
                else
                {
                    dgv_dsThiTruong.SelectionChanged -= Dgv_dsThiTruong_SelectionChanged;
                    dgv_dsThiTruong.DataSource = null;
                    XoaTextBoxThiTruong();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi Load" + ex.Message);
            }
        }
        private void Dgv_dsThiTruong_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                // Ràng buộc dữ liệu từ DataGridView vào các điều khiển
                BatDataBindingDataGridViewThiTruong();

                // Lấy mã thị trường từ dòng được chọn
                string maThiTruong = dgv_dsThiTruong.SelectedRows[0].Cells["MaThiTruong"].Value.ToString();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("Lỗi khi Selection Changed DGV Danh sách thị trường"+ex.Message);
            }
        }
        private void BatDataBindingDataGridViewThiTruong()
        {
            try
            {
                // Ràng buộc dữ liệu từ DataGridView vào các điều khiển
                txtMaThiTruong.Text = dgv_dsThiTruong.CurrentRow.Cells["MaThiTruong"].Value.ToString();
                txtLoaiThiTruong.Text = dgv_dsThiTruong.CurrentRow.Cells["LoaiThiTruong"].Value.ToString();
                txtMoTa.Text = dgv_dsThiTruong.CurrentRow.Cells["MoTa"].Value.ToString();
                txtGiaTri.Text = dgv_dsThiTruong.CurrentRow.Cells["GiaTri"].Value.ToString();
                dateTimePickerThoiGian.Value = DateTime.Parse(dgv_dsThiTruong.CurrentRow.Cells["ThoiGian"].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi binding"+ex.Message);
            }
        }



    }
}
