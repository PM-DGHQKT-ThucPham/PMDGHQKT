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
        LoiNhuanBLL _loiNhuanBLL = new LoiNhuanBLL();
        DoanhThuBLL _doanhThuBLL = new DoanhThuBLL();
        ChiPhiBLL _chiPhiBLL = new ChiPhiBLL();

        List<LoiNhuan> _lstLoiNhuan = new List<LoiNhuan>();
        List<DoanhThu> _lstDoanhThu = new List<DoanhThu>();
        List<ChiPhi> _lstChiPhi = new List<ChiPhi>();
        private string maSanPham = "SP001";
        public frm_quanLyLoiNhuan()
        {
            InitializeComponent();
            Load += Frm_quanLyLoiNhuan_Load;
        }

        private void Frm_quanLyLoiNhuan_Load(object sender, EventArgs e)
        {
            HienThiDoanhThu();
            HienThiChiPhi();
        }

        //viết hàm xử lý

        public void HienThiDoanhThu()
        {
            try
            {
                _lstDoanhThu = _doanhThuBLL.LayDanhSachDoanhThu(maSanPham);
                if( _lstDoanhThu != null )
                {
                    dgv_dsDoanhThu.DataSource = _lstDoanhThu;
                    themCotSoThuTu(dgv_dsDoanhThu);
                    KhoiTaoDoanhThu();
                    dgv_dsDoanhThu.RowPostPaint -= Dgv_dsDoanhThu_RowPostPaint;
                    dgv_dsDoanhThu.RowPostPaint += Dgv_dsDoanhThu_RowPostPaint;
                }    
            }
            catch {
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
                if (_lstChiPhi.Count > 0) { 
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
