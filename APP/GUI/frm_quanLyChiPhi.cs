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

            t.BtnThem.Click += BtnThem_Click;
            t.BtnXoa.Click += BtnXoa_Click;
            t.BtnSua.Click += BtnSua_Click;
            t.BtnLuu.Click += BtnLuu_Click;
            t.BtnHuyThem.Click += BtnHuyThem_Click;
            btn_clear.Click += Btn_clear_Click;

            // Cấu hình DataGridView
            dgv_dsLoaiChiPhi.AllowUserToAddRows = true;
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

        private void BtnHuyThem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            // Hiển thị nút Lưu và Hủy
            t.BtnLuu.Visible = true;
            t.BtnHuyThem.Visible = true;

            // Kích hoạt chế độ nhập liệu
            txt_maLoaiChiPhi.Enabled = true; // Mã chi phí
            txt_tenLoaiChiPhi.Enabled = true; // Tên chi phí
            txt_tongTien.Enabled = true; // Số tiền

            // Kiểm tra nếu người dùng chưa lưu dòng hiện tại
            if (!string.IsNullOrEmpty(txt_maLoaiChiPhi.Text) || !string.IsNullOrEmpty(txt_tenLoaiChiPhi.Text) || !string.IsNullOrEmpty(txt_tongTien.Text))
            {
                DialogResult result = MessageBox.Show("Bạn có muốn lưu dòng hiện tại trước khi thêm dòng mới không?",
                                                      "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Lưu dòng hiện tại vào DataGridView
                    ThemLoaiChiPhiVaoDataGridView();
                }
            }

            // Xóa trắng các trường nhập liệu để nhập dòng mới
            txt_maLoaiChiPhi.Text = string.Empty;
            txt_tenLoaiChiPhi.Text = string.Empty;
            txt_tongTien.Text = string.Empty;

            // Kích hoạt các trường nhập liệu
            txt_maLoaiChiPhi.Enabled = true;
            txt_tenLoaiChiPhi.Enabled = true;
            txt_tongTien.Enabled = true;

            MessageBox.Show("Sẵn sàng để thêm dòng mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Vô hiệu hóa các nút khác
            t.BtnThem.Enabled = false;
            t.BtnLuu.Enabled = false;
            t.BtnXoa.Enabled = false;
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
    }
}
