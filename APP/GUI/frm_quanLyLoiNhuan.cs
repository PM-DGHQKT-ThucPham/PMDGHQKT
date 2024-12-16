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
    public partial class frm_quanLyLoiNhuan : Form
    {
        SanPhamBLL _sanPhamBLL = new SanPhamBLL();
        LoiNhuanBLL _loiNhuanBLL = new LoiNhuanBLL();
        DoanhThuBLL _doanhThuBLL = new DoanhThuBLL();
        ChiPhiBLL _chiPhiBLL = new ChiPhiBLL();

        List<SanPham> _lstSanPham= new List<SanPham>();
        List<LoiNhuan> _lstLoiNhuan = new List<LoiNhuan>();
        List<DoanhThu> _lstDoanhThu = new List<DoanhThu>();
        List<ChiPhi> _lstChiPhi = new List<ChiPhi>();
        private string maSanPham = string.Empty;
        public frm_quanLyLoiNhuan()
        {
            InitializeComponent();
            Load += Frm_quanLyLoiNhuan_Load;
        }

        private void Frm_quanLyLoiNhuan_Load(object sender, EventArgs e)
        {
            LoadComboBoxSanPham();
            HienThiDoanhThu();
            HienThiChiPhi();
            _lstLoiNhuan = _loiNhuanBLL.LayTatCaLoiNhuanTheoMaSanPham(maSanPham);
            HienThiLoiNhuan(_lstLoiNhuan);
            dgv_dsLoiNhuan.SelectionChanged += Dgv_dsLoiNhuan_SelectionChanged;
            btn_timKiem.Click += Btn_timKiem_Click;
            btn_capNhat.Click += Btn_capNhat_Click;
            btn_themLN.Click += Btn_themLN_Click;
        }

        private void Btn_themLN_Click(object sender, EventArgs e)
        {
            // Tạo mã lợi nhuận tự động
            string maLoiNhuan = TaoMaLoiNhuan(maSanPham);

            if (maLoiNhuan != null)
            {
                // Lấy các thông tin khác từ giao diện
                var loiNhuanMoi = new LoiNhuan
                {
                    MaSanPham = maSanPham,
                    LoiNhuanGop = 0,
                    LoiNhuanRong = 0,
                    MaLoiNhuan = maLoiNhuan // Gán mã lợi nhuận tự động vào bản ghi
                };

                // Thêm lợi nhuận vào cơ sở dữ liệu
                if (_loiNhuanBLL.ThemLoiNhuan(loiNhuanMoi))
                {
                    MessageBox.Show("Thêm tháng mới thành công!");
                    // Tải lại dữ liệu lên DataGridView
                    LoadLaiTrang();
                }
                else
                {
                    MessageBox.Show("Thêm tháng mới thất bại!");
                }
            }
            else
            {
                MessageBox.Show("Lỗi tạo mã lợi nhuận.");
            }
        }
        public string TaoMaLoiNhuan(string maSanPham)
        {
            try
            {
                // Lấy tháng và năm hiện tại với định dạng "yyMM" để giảm độ dài mã
                string thangNam = DateTime.Now.ToString("yyMM");

                // Tạo mã lợi nhuận theo định dạng: "LN-yyMM-MaSanPham"
                string maLoiNhuan = $"LN{thangNam}{maSanPham}";

                // Loại bỏ các số 0 dư thừa sau "LN"
                maLoiNhuan = maLoiNhuan.Replace("0", string.Empty);

                return maLoiNhuan;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo mã lợi nhuận: " + ex.Message);
                return null;
            }
        }

        private void Btn_capNhat_Click(object sender, EventArgs e)
        {
            //cập nhập dòng lợi nhuận được chọn
            if (dgv_dsLoiNhuan.CurrentRow != null)
            {
                LoiNhuan ln = (LoiNhuan)dgv_dsLoiNhuan.CurrentRow.DataBoundItem;
                if (ln != null)
                {
                    //tính toán lợi nhuận gộp và ròng
                    decimal loiNhuanGop = _loiNhuanBLL.TinhLoiNhuanGop(maSanPham, ln.ThoiGian.Value.Month, ln.ThoiGian.Value.Year);
                    decimal loiNhuanRong = _loiNhuanBLL.TinhLoiNhuanRong(maSanPham, ln.ThoiGian.Value.Month, ln.ThoiGian.Value.Year);
                    ln.MoTa = txt_moTaLoiNhuan.Text;
                    if (_loiNhuanBLL.CapNhatLoiNhuanTheoThang(ln.ThoiGian.Value.Month, ln.ThoiGian.Value.Year,maSanPham))
                    {
                        MessageBox.Show("Cập nhật lợi nhuận thành công");
                        _lstLoiNhuan = _loiNhuanBLL.LayTatCaLoiNhuanTheoMaSanPham(maSanPham);
                        HienThiLoiNhuan(_lstLoiNhuan);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật lợi nhuận thất bại");
                    }
                }
            }
        }

        private void Dgv_dsLoiNhuan_SelectionChanged(object sender, EventArgs e)
        {
            // Lấy dòng được chọn trong DataGridView danh sách lợi nhuận hiện tại hiện lên các control
            //lấy current row
            if(dgv_dsLoiNhuan.CurrentRow != null)
            {
                LoiNhuan ln = (LoiNhuan)dgv_dsLoiNhuan.CurrentRow.DataBoundItem;
                if (ln != null)
                {
                    txt_maLoiNhuan.Text = ln.MaLoiNhuan;
                    dtp_thoiGian.Value = ln.ThoiGian.Value;
                    txt_loiNhuanGop.Text = ln.LoiNhuanGop.ToString();
                    txt_loiNhuanRong.Text = ln.LoiNhuanRong.ToString();
                    txt_moTaLoiNhuan.Text = ln.MoTa;
                }
                //tính tỉ lệ lợi nhuận gộp và ròng
                // Lấy lợi nhuận gộp và ròng từ BLL
                decimal loiNhuanGop = _loiNhuanBLL.TinhLoiNhuanGop(maSanPham, ln.ThoiGian.Value.Month, ln.ThoiGian.Value.Year);
                decimal loiNhuanRong = _loiNhuanBLL.TinhLoiNhuanRong(maSanPham, ln.ThoiGian.Value.Month, ln.ThoiGian.Value.Year);
                // Lấy doanh thu của sản phẩm trong cùng tháng và năm để tính tỷ lệ
                List<DoanhThu> doanhThus = _doanhThuBLL.LayDoanhThuTheoThang(ln.ThoiGian.Value.Month, ln.ThoiGian.Value.Year, maSanPham);
                //tính tổng doanh thu
                decimal? totalDoanhThu = doanhThus?.Sum(dt => dt.SoTien);
                DoanhThu doanhThu = new DoanhThu { SoTien = totalDoanhThu ?? 0 };
                Decimal doanhThuThang = doanhThu?.SoTien ?? 0;
                // Kiểm tra để tránh chia cho 0
                if (doanhThuThang != 0)
                {
                    // Tính tỷ lệ lợi nhuận gộp và lợi nhuận ròng
                    decimal tyLeLoiNhuanGop = (loiNhuanGop / doanhThuThang) * 100;
                    decimal tyLeLoiNhuanRong = (loiNhuanRong / doanhThuThang) * 100;

                    // Cập nhật lên giao diện
                    txt_tyLeLoiNhuanGop.Text = tyLeLoiNhuanGop.ToString("F2") + '%'; // Hiển thị 2 chữ số sau dấu phẩy
                    txt_tyLeLoiNhuanRong.Text = tyLeLoiNhuanRong.ToString("F2") + '%'; // Hiển thị 2 chữ số sau dấu phẩy
                }
                else
                {
                    // Nếu doanh thu = 0, tỉ lệ lợi nhuận gộp và ròng sẽ là 0%
                    txt_tyLeLoiNhuanGop.Text = "0%";
                    txt_tyLeLoiNhuanRong.Text = "0%";
                }

                //hiển thị doanh thu theo tháng
                List<DoanhThu> lstDoanhThu = _doanhThuBLL.LayDoanhThuTheoThang(ln.ThoiGian.Value.Month, ln.ThoiGian.Value.Year, maSanPham);
                dgv_dsDoanhThu.DataSource = lstDoanhThu;
                themCotSoThuTu(dgv_dsDoanhThu);
                KhoiTaoDoanhThu();
                dgv_dsDoanhThu.RowPostPaint -= Dgv_dsDoanhThu_RowPostPaint;
                dgv_dsDoanhThu.RowPostPaint += Dgv_dsDoanhThu_RowPostPaint;
                //hiển thị chi phí theo tháng
                List<ChiPhi> lstChiPhi = _chiPhiBLL.LayChiPhiTheoThangNam(ln.ThoiGian.Value.Month, ln.ThoiGian.Value.Year, maSanPham);
                dgv_dsChiPhi.DataSource = lstChiPhi;
                themCotSoThuTu(dgv_dsChiPhi);
                KhoiTaoChiPhi();
                dgv_dsChiPhi.RowPostPaint -= Dgv_dsChiPhi_RowPostPaint;
                dgv_dsChiPhi.RowPostPaint += Dgv_dsChiPhi_RowPostPaint;
            }
        }

        private void Btn_timKiem_Click(object sender, EventArgs e)
        {
            try
            {
                //lấy ngày tháng năm từ datetimepicker
                DateTime ngay = dtp_thoiGian.Value;
                //lấy danh lợi nhuận theo tháng năm
                _lstLoiNhuan = _loiNhuanBLL.LayLoiNhuanTheoThangNam(ngay.Month, ngay.Year, maSanPham);
                if (_lstLoiNhuan != null)
                {
                    dgv_dsLoiNhuan.DataSource = _lstLoiNhuan;
                    themCotSoThuTu(dgv_dsLoiNhuan);
                    KhoiTaoLoiNhuan();
                    dgv_dsLoiNhuan.RowPostPaint -= Dgv_dsLoiNhuan_RowPostPaint;
                    dgv_dsLoiNhuan.RowPostPaint += Dgv_dsLoiNhuan_RowPostPaint;
                }

            }
            catch
            {
                MessageBox.Show("Không tìm thấy kết quả nào");
            }
        }
        private void Cbo_sanPham_SelectedValueChanged(object sender, EventArgs e)
        {
            maSanPham = cbo_sanPham.SelectedValue.ToString();
            LoadLaiTrang();
        }


        //viết hàm xử lý
        //load lại trang
        private void LoadLaiTrang()
        {
            HienThiDoanhThu();
            HienThiChiPhi();
            _lstLoiNhuan = _loiNhuanBLL.LayTatCaLoiNhuanTheoMaSanPham(maSanPham);
            HienThiLoiNhuan(_lstLoiNhuan);
        }
        //load combo box sản phẩm
        private void LoadComboBoxSanPham()
        {
            try
            {
                _lstSanPham = _sanPhamBLL.LayDanhSachSanPham();
                if (_lstSanPham != null)
                {
                    cbo_sanPham.DataSource = _lstSanPham;
                    cbo_sanPham.DisplayMember = "TenSanPham";
                    cbo_sanPham.ValueMember = "MaSanPham";
                    cbo_sanPham.SelectedIndex = 0;
                    cbo_sanPham.SelectedValueChanged += Cbo_sanPham_SelectedValueChanged;
                }
            }
            catch
            {
                MessageBox.Show("Không tìm thấy sản phẩm nào");
            }
        }


        private void HienThiLoiNhuan(List<LoiNhuan> _lst)
        {
            try
            {
                _lstLoiNhuan = _lst;
                if (_lstLoiNhuan != null)
                {
                    dgv_dsLoiNhuan.DataSource = _lstLoiNhuan;
                    themCotSoThuTu(dgv_dsLoiNhuan);
                    KhoiTaoLoiNhuan();
                    dgv_dsLoiNhuan.RowPostPaint -= Dgv_dsLoiNhuan_RowPostPaint;
                    dgv_dsLoiNhuan.RowPostPaint += Dgv_dsLoiNhuan_RowPostPaint;
                }
            }
            catch
            {
                MessageBox.Show("Không tìm thấy lợi nhuận nào");
            }
        }
        private void Dgv_dsLoiNhuan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && dgv_dsLoiNhuan.Columns.Contains("SoThuTu"))
                {
                    // Cập nhật số thứ tự cho mỗi dòng
                    dgv_dsLoiNhuan.Rows[e.RowIndex].Cells["SoThuTu"].Value = (e.RowIndex + 1).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật số thứ tự: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KhoiTaoLoiNhuan()
        {
            try
            {
                // Kiểm tra xem dgv_dsLoiNhuan có phải là null không
                if (dgv_dsLoiNhuan == null)
                {
                    MessageBox.Show("DataGridView lợi nhuận chưa được khởi tạo.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Đổi tên cột
                dgv_dsLoiNhuan.Columns["MaLoiNhuan"].HeaderText = "Mã lợi nhuận";
                dgv_dsLoiNhuan.Columns["ThoiGian"].HeaderText = "Thời gian";
                dgv_dsLoiNhuan.Columns["LoiNhuanGop"].HeaderText = "Lợi nhuận gộp";
                dgv_dsLoiNhuan.Columns["LoiNhuanRong"].HeaderText = "Lợi nhuận ròng";
                dgv_dsLoiNhuan.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";
                dgv_dsLoiNhuan.Columns["MoTa"].HeaderText = "Mô tả";
                // In đậm tiêu đề cột
                dgv_dsLoiNhuan.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);

                // Căn giữa tiêu đề cột
                dgv_dsLoiNhuan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //autofill
                dgv_dsLoiNhuan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                // Ẩn cột không cần thiết (ví dụ như cột "LoaiDoanhThu" nếu không cần thiết)
                if (dgv_dsLoiNhuan.Columns.Contains("LoaiDoanhThu"))
                {
                    dgv_dsLoiNhuan.Columns["LoaiDoanhThu"].Visible = false;
                }

                // Định dạng cột "SoTien" là tiền
                if (dgv_dsLoiNhuan.Columns.Contains("LoiNhuanGop"))
                {
                    dgv_dsLoiNhuan.Columns["LoiNhuanGop"].DefaultCellStyle.Format = "N0"; // Định dạng tiền với dấu phân cách hàng nghìn
                    // Căn phải nội dung của cột SoTien
                    dgv_dsLoiNhuan.Columns["LoiNhuanGop"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (dgv_dsLoiNhuan.Columns.Contains("LoiNhuanRong"))
                {
                    dgv_dsLoiNhuan.Columns["LoiNhuanRong"].DefaultCellStyle.Format = "N0"; // Định dạng tiền với dấu phân cách hàng nghìn
                    // Căn phải nội dung của cột SoTien
                    dgv_dsLoiNhuan.Columns["LoiNhuanRong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                //mô tả ở cuối
                if (dgv_dsLoiNhuan.Columns.Contains("MoTa"))
                {
                    //hiển thị cuối 
                    dgv_dsLoiNhuan.Columns["MoTa"].DisplayIndex = dgv_dsLoiNhuan.Columns.Count - 1;
                    //tự động xuống dòng
                    dgv_dsLoiNhuan.Columns["MoTa"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                }
                //ẩn cột sản phẩm   
                if (dgv_dsLoiNhuan.Columns.Contains("SanPham"))
                {
                    dgv_dsLoiNhuan.Columns["SanPham"].Visible = false;
                }
                // FillWeight cho các cột
                dgv_dsLoiNhuan.Columns["SoThuTu"].FillWeight = 7;  // Cột STT chiếm 5% chiều rộng
                dgv_dsLoiNhuan.Columns["MaLoiNhuan"].FillWeight = 15;
                dgv_dsLoiNhuan.Columns["ThoiGian"].FillWeight = 15;
                dgv_dsLoiNhuan.Columns["LoiNhuanGop"].FillWeight = 20;
                dgv_dsLoiNhuan.Columns["LoiNhuanRong"].FillWeight = 20;
                dgv_dsLoiNhuan.Columns["MaSanPham"].FillWeight = 15;
                dgv_dsLoiNhuan.Columns["MoTa"].FillWeight = 23;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo DataGridView lợi nhuận: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void HienThiDoanhThu()
        {
            try
            {
                _lstDoanhThu = _doanhThuBLL.LayDanhSachDoanhThu(maSanPham);
                if (_lstDoanhThu != null)
                {
                    dgv_dsDoanhThu.DataSource = _lstDoanhThu;
                    themCotSoThuTu(dgv_dsDoanhThu);
                    KhoiTaoDoanhThu();
                    dgv_dsDoanhThu.RowPostPaint -= Dgv_dsDoanhThu_RowPostPaint;
                    dgv_dsDoanhThu.RowPostPaint += Dgv_dsDoanhThu_RowPostPaint;
                }
            }
            catch
            {
                MessageBox.Show("Không tìm thấy doanh thu nào cả");
            }
        }

        private void Dgv_dsDoanhThu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && dgv_dsDoanhThu.Columns.Contains("SoThuTu"))
                {
                    // Cập nhật số thứ tự cho mỗi dòng
                    dgv_dsDoanhThu.Rows[e.RowIndex].Cells["SoThuTu"].Value = (e.RowIndex + 1).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật số thứ tự: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //hiển thị  chi phí
        private void HienThiChiPhi()
        {
            try
            {
                _lstChiPhi = _chiPhiBLL.LayDanhSachChiPhi(maSanPham);
                if (_lstChiPhi.Count > 0)
                {
                    dgv_dsChiPhi.DataSource = _lstChiPhi;
                    themCotSoThuTu(dgv_dsChiPhi);
                    KhoiTaoChiPhi();
                    dgv_dsChiPhi.RowPostPaint -= Dgv_dsChiPhi_RowPostPaint;
                    dgv_dsChiPhi.RowPostPaint += Dgv_dsChiPhi_RowPostPaint;
                }
            }
            catch
            {
                MessageBox.Show("Không tìm thấy chi phí nào");
            }
        }

        private void Dgv_dsChiPhi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && dgv_dsChiPhi.Columns.Contains("SoThuTu"))
                {
                    // Cập nhật số thứ tự cho mỗi dòng
                    dgv_dsChiPhi.Rows[e.RowIndex].Cells["SoThuTu"].Value = (e.RowIndex + 1).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật số thứ tự: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void themCotSoThuTu(DataGridView dgv_dsDoanhThu)
        {
            try
            {
                // Kiểm tra xem cột "SoThuTu" đã tồn tại chưa
                if (dgv_dsDoanhThu.Columns["SoThuTu"] == null)
                {
                    // Tạo cột mới cho số thứ tự
                    DataGridViewTextBoxColumn soThuTuColumn = new DataGridViewTextBoxColumn
                    {
                        Name = "SoThuTu", // Tên cột
                        HeaderText = "STT", // Tiêu đề cột
                        Width = 40, // Độ rộng cột
                        ReadOnly = true // Không cho phép chỉnh sửa
                    };

                    // Thêm cột số thứ tự vào đầu DataGridView
                    dgv_dsDoanhThu.Columns.Insert(0, soThuTuColumn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm cột số thứ tự: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // khởi tạo form
        private void KhoiTaoDoanhThu()
        {
            try
            {
                // Kiểm tra xem dgv_dsDoanhThu có phải là null không
                if (dgv_dsDoanhThu == null)
                {
                    MessageBox.Show("DataGridView doanh thu chưa được khởi tạo.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Đổi tên cột
                dgv_dsDoanhThu.Columns["MaDoanhThu"].HeaderText = "Mã doanh thu";
                dgv_dsDoanhThu.Columns["MoTa"].HeaderText = "Mô Tả";
                dgv_dsDoanhThu.Columns["SoTien"].HeaderText = "Số tiền";
                dgv_dsDoanhThu.Columns["ThoiGian"].HeaderText = "Thời gian";
                dgv_dsDoanhThu.Columns["MaLoaiDoanhThu"].HeaderText = "Mã loại doanh thu";

                // In đậm tiêu đề cột
                dgv_dsDoanhThu.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);

                // Căn giữa tiêu đề cột
                dgv_dsDoanhThu.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Ẩn cột không cần thiết (ví dụ như cột "LoaiDoanhThu" nếu không cần thiết)
                if (dgv_dsDoanhThu.Columns.Contains("LoaiDoanhThu"))
                {
                    dgv_dsDoanhThu.Columns["LoaiDoanhThu"].Visible = false;
                }

                // Định dạng cột "SoTien" là tiền
                if (dgv_dsDoanhThu.Columns.Contains("SoTien"))
                {
                    dgv_dsDoanhThu.Columns["SoTien"].DefaultCellStyle.Format = "N0"; // Định dạng tiền với dấu phân cách hàng nghìn
                    // Căn phải nội dung của cột SoTien
                    dgv_dsDoanhThu.Columns["SoTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                // Sửa lại thứ tự hiển thị của cột "MoTa"
                if (dgv_dsDoanhThu.Columns.Contains("MoTa"))
                {
                    dgv_dsDoanhThu.Columns["MoTa"].DisplayIndex = dgv_dsDoanhThu.Columns.Count - 1; // Đưa cột MoTa vào cuối cùng
                }

                // Hiển thị toàn bộ bảng, tự động thay đổi kích thước cột
                dgv_dsDoanhThu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Cập nhật lại FillWeight cho các cột sao cho tổng cộng = 100
                dgv_dsDoanhThu.Columns["SoThuTu"].FillWeight = 5;  // Cột STT chiếm 5% chiều rộng
                dgv_dsDoanhThu.Columns["MaDoanhThu"].FillWeight = 15;
                dgv_dsDoanhThu.Columns["MoTa"].FillWeight = 35;  // MoTa chiếm phần lớn chiều rộng
                dgv_dsDoanhThu.Columns["SoTien"].FillWeight = 15;
                dgv_dsDoanhThu.Columns["ThoiGian"].FillWeight = 15;
                dgv_dsDoanhThu.Columns["MaLoaiDoanhThu"].FillWeight = 15;

                // Thiết lập tự động xuống dòng cho cột "MoTa" và "MaDoanhThu"
                if (dgv_dsDoanhThu.Columns.Contains("MoTa"))
                {
                    dgv_dsDoanhThu.Columns["MoTa"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                }

                if (dgv_dsDoanhThu.Columns.Contains("MaDoanhThu"))
                {
                    dgv_dsDoanhThu.Columns["MaDoanhThu"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                }

                // Tự động điều chỉnh chiều cao hàng dựa trên nội dung của các ô
                dgv_dsDoanhThu.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                // Nếu cần, có thể đặt chiều cao tối thiểu cho các hàng
                foreach (DataGridViewRow row in dgv_dsDoanhThu.Rows)
                {
                    row.Height = Math.Max(row.Height, 30); // Đặt chiều cao tối thiểu cho các hàng
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo DataGridView doanh thu: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void KhoiTaoChiPhi()
        {
            try
            {
                // Đổi tên cột
                dgv_dsChiPhi.Columns["MaChiPhi"].HeaderText = "Mã chi phí";
                dgv_dsChiPhi.Columns["MoTa"].HeaderText = "Tên chi phí";
                dgv_dsChiPhi.Columns["SoTien"].HeaderText = "Số tiền";
                dgv_dsChiPhi.Columns["ThoiGian"].HeaderText = "Thời gian";
                dgv_dsChiPhi.Columns["MaLoaiChiPhi"].HeaderText = "Mã loại chi phí";

                // In đậm tiêu đề
                dgv_dsChiPhi.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);

                // Căn giữa tiêu đề
                dgv_dsChiPhi.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Ẩn cột không cần thiết
                dgv_dsChiPhi.Columns["LoaiChiPhi"].Visible = false;

                // Định dạng tiền cho cột "SoTien"
                if (dgv_dsChiPhi.Columns.Contains("SoTien"))
                {
                    dgv_dsChiPhi.Columns["SoTien"].DefaultCellStyle.Format = "N0"; // Định dạng số tiền với dấu phân cách hàng nghìn
                    dgv_dsChiPhi.Columns["SoTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // Căn phải
                }

                // Đảm bảo cột "ThoiGian" có định dạng ngày tháng nếu cần
                if (dgv_dsChiPhi.Columns.Contains("ThoiGian"))
                {
                    dgv_dsChiPhi.Columns["ThoiGian"].DefaultCellStyle.Format = "dd/MM/yyyy"; // Định dạng ngày tháng (tuỳ theo yêu cầu)
                    dgv_dsChiPhi.Columns["ThoiGian"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa
                }

                // Đảm bảo cột "MoTa" luôn hiển thị cuối cùng
                if (dgv_dsChiPhi.Columns.Contains("MoTa"))
                {
                    dgv_dsChiPhi.Columns["MoTa"].DisplayIndex = dgv_dsChiPhi.Columns.Count - 1; // Đưa cột MoTa vào cuối cùng
                    dgv_dsChiPhi.Columns["MoTa"].DefaultCellStyle.WrapMode = DataGridViewTriState.True; // Bật chế độ tự động xuống dòng cho cột MoTa
                }

                // Hiển thị toàn bộ bảng, tự động thay đổi kích thước cột cho phù hợp
                dgv_dsChiPhi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // FillWeight cho các cột
                dgv_dsChiPhi.Columns["SoThuTu"].FillWeight = 7;
                dgv_dsChiPhi.Columns["MaChiPhi"].FillWeight = 15;
                dgv_dsChiPhi.Columns["MoTa"].FillWeight = 40;
                dgv_dsChiPhi.Columns["SoTien"].FillWeight = 20;
                dgv_dsChiPhi.Columns["ThoiGian"].FillWeight = 20;
                dgv_dsChiPhi.Columns["MaLoaiChiPhi"].FillWeight = 17;

                // Tự động điều chỉnh chiều cao hàng dựa trên nội dung của các ô
                dgv_dsChiPhi.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                // Nếu cần, có thể đặt chiều cao tối thiểu cho các hàng
                foreach (DataGridViewRow row in dgv_dsChiPhi.Rows)
                {
                    row.Height = Math.Max(row.Height, 30); // Đặt chiều cao tối thiểu cho các hàng
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo DataGridView chi phí: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
