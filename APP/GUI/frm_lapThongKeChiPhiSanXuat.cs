using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BLL;
using DTO;

namespace GUI
{
    public partial class frm_lapThongKeChiPhiSanXuat : Form
    {
        LoaiChiPhiBLL _loaiChiPhiBLL = new LoaiChiPhiBLL();
        ChiPhiBLL _chiPhiBLL = new ChiPhiBLL();

        List<LoaiChiPhi> _lstLoaiChiPhi = new List<LoaiChiPhi>();
        List<ChiPhi> _lstChiPhi = new List<ChiPhi>();

        private SanPhamBLL _sanPhamBLL = new SanPhamBLL();
        List<SanPham> _lstSanPham = new List<SanPham>();
        string maSanPham = string.Empty;

        public frm_lapThongKeChiPhiSanXuat()
        {
            InitializeComponent();
            this.Load += Frm_lapThongKeChiPhiSanXuat_Load;
        }

        private void Frm_lapThongKeChiPhiSanXuat_Load(object sender, EventArgs e)
        {
            LoadComboBoxSanPham();
            LoadComBoBoxChucNang();
            LoadComBoBoxLoaiChiPhi();
            _lstChiPhi = _chiPhiBLL.LayDanhSachChiPhi(maSanPham);
            HienThiDuLieu(_lstChiPhi);
            HienThiChiPhiTheoLoaiChiPhi(_lstChiPhi);
            cbo_chucNang.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_loaiChiPhi.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_sanPham.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_chucNang.SelectedIndexChanged += Cbo_chucNang_SelectedIndexChanged;
            cbo_loaiChiPhi.SelectedIndexChanged += Cbo_loaiChiPhi_SelectedIndexChanged;
            btn_timKiem.Click += Btn_timKiem_Click;
            PlaceHolder.SetPlaceholder(txt_timKiem, "Nhập thông tin tìm kiếm");
            //chỉnh sửa dtp hiển thị ngày tháng năm
            dtp_ngayBatDau.Format = DateTimePickerFormat.Custom;
            dtp_ngayBatDau.CustomFormat = "dd/MM/yyyy";
            dtp_ngayKetThuc.Format = DateTimePickerFormat.Custom;
            dtp_ngayKetThuc.CustomFormat = "dd/MM/yyyy";
            dgv_dsChiPhi.SelectionChanged += Dgv_dsChiPhi_SelectionChanged;
        }

        private void Dgv_dsChiPhi_SelectionChanged(object sender, EventArgs e)
        {
            //tính tổng chi phí trên datagridview
            decimal tongChiPhi = 0;
            foreach (DataGridViewRow row in dgv_dsChiPhi.SelectedRows)
            {
                tongChiPhi += Convert.ToDecimal(row.Cells["SoTien"].Value);
            }
            txt_tongTien.Text = $"Tổng chi phí: {tongChiPhi:N0} VND";
        }

        private void Btn_timKiem_Click(object sender, EventArgs e)
        {
            try
            {
                //lấy index của combobox
                int index = cbo_chucNang.SelectedIndex;
                //lấy dữ liệu từ textbox
                string timKiem = txt_timKiem.Text;
                //lấy dữ liệu từ datetimepicker
                DateTime ngayBatDau = dtp_ngayBatDau.Value;
                DateTime ngayKetThuc = dtp_ngayKetThuc.Value;
                //tìm kiếm
                switch (index)
                {
                    case 0:
                        _lstChiPhi = _chiPhiBLL.LayDanhSachChiPhi(maSanPham);
                        break;
                    case 1:
                        _lstChiPhi = new List<ChiPhi>();
                        _lstChiPhi.Add(_chiPhiBLL.LayChiPhiTheoMaChiPhi(timKiem, maSanPham));
                        break;
                    case 2:
                        _lstChiPhi = _chiPhiBLL.LayChiPhiTheoMaLoaiChiPhi(timKiem, maSanPham);
                        break;
                    case 3:
                        _lstChiPhi = _chiPhiBLL.LayChiPhiTheoThangNam(ngayBatDau.Month, ngayBatDau.Year, maSanPham);
                        break;
                    case 4:
                        _lstChiPhi = _chiPhiBLL.LayChiPhiTheoKhoangThoiGian(ngayBatDau, ngayKetThuc, maSanPham);
                        break;
                    default:
                        break;
                }
                HienThiDuLieu(_lstChiPhi);
                HienThiChiPhiTheoLoaiChiPhi(_lstChiPhi);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Cbo_loaiChiPhi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //lấy mã loại chi phí
                string maLoaiChiPhi = cbo_loaiChiPhi.SelectedValue.ToString();
                string title = $"Chi phí sản xuất theo loại chi phí {cbo_loaiChiPhi.Text}";
                //lấy danh sách chi phí theo mã loại chi phí
                _lstChiPhi = _chiPhiBLL.LayChiPhiTheoMaLoaiChiPhi(maLoaiChiPhi, maSanPham);
                HienThiDuLieu(_lstChiPhi);
                HienThiChiPhiSanXuatTheoThang(_lstChiPhi, title);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Cbo_chucNang_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lấy index của combobox
            int index = cbo_chucNang.SelectedIndex;
            //ẩn các control
            switch (index)
            {
                case 0:
                    txt_timKiem.Enabled = false;
                    dtp_ngayBatDau.Enabled = false;
                    dtp_ngayKetThuc.Enabled = false;
                    break;
                case 1:
                    txt_timKiem.Enabled = true;
                    dtp_ngayBatDau.Enabled = false;
                    dtp_ngayKetThuc.Enabled = false;
                    break;
                case 2:
                    txt_timKiem.Enabled = true;
                    dtp_ngayBatDau.Enabled = false;
                    dtp_ngayKetThuc.Enabled = false;
                    break;
                case 3:
                    txt_timKiem.Enabled = false;
                    dtp_ngayBatDau.Enabled = true;
                    dtp_ngayKetThuc.Enabled = false;
                    break;
                case 4:
                    txt_timKiem.Enabled = false;
                    dtp_ngayBatDau.Enabled = true;
                    dtp_ngayKetThuc.Enabled = true;
                    break;
                default:
                    break;

            }

        }

        //viết hàm xử lý dữ liệu
        private void Cbo_sanPham_SelectedValueChanged(object sender, EventArgs e)
        {
            maSanPham = cbo_sanPham.SelectedValue.ToString();
            LoadLaiTrang();
        }


        // viết hàm xử lý ở đây
        //load lại trang
        private void LoadLaiTrang()
        {
            _lstChiPhi = _chiPhiBLL.LayDanhSachChiPhi(maSanPham);
            HienThiDuLieu(_lstChiPhi);
            HienThiChiPhiTheoLoaiChiPhi(_lstChiPhi);
            LoadComBoBoxLoaiChiPhi();

        }
        private void LoadComboBoxSanPham()
        {
            try
            {
                _lstSanPham = _sanPhamBLL.LayDanhSachSanPham();  // Lấy danh sách sản phẩm từ BLL

                if (_lstSanPham != null && _lstSanPham.Count > 0)
                {
                    cbo_sanPham.DataSource = _lstSanPham;
                    cbo_sanPham.DisplayMember = "TenSanPham";  // Hiển thị tên sản phẩm
                    cbo_sanPham.ValueMember = "MaSanPham";  // Gán giá trị mã sản phẩm

                    // Gán giá trị đầu tiên vào maSP
                    maSanPham = _lstSanPham.FirstOrDefault()?.MaSanPham.ToString();

                    // Chọn mục đầu tiên của ComboBox nếu có ít nhất một phần tử
                    cbo_sanPham.SelectedIndex = 0;

                    // Đăng ký sự kiện SelectedValueChanged
                    cbo_sanPham.SelectedValueChanged += Cbo_sanPham_SelectedValueChanged;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm nào");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu sản phẩm: " + ex.Message);
            }
        }
        private void HienThiChiPhiTheoLoaiChiPhi(List<ChiPhi> _lstChiPhi)
        {
            // Xóa dữ liệu cũ
            chart_chiPhi.Series.Clear();
            chart_chiPhi.Titles.Clear();
            chart_chiPhi.ChartAreas[0].RecalculateAxesScale();

            // Gắn nhãn cho biểu đồ
            chart_chiPhi.Titles.Add("Chi phí theo loại chi phí");
            chart_chiPhi.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold);

            // Tính toán tổng chi phí theo loại
            var chiPhiTheoLoai = _lstChiPhi
                .GroupBy(x => x.LoaiChiPhi.TenLoaiChiPhi)
                .Select(group => new { Loai = group.Key, TongChiPhi = group.Sum(x => x.SoTien ?? 0) })
                .ToList();

            // Tính tổng chi phí để tính phần trăm
            decimal tongChiPhiTatCa = chiPhiTheoLoai.Sum(x => x.TongChiPhi);

            // Khởi tạo Series cho biểu đồ Pie
            Series series = new Series("Chi phí")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie,
                IsValueShownAsLabel = true
            };

            // Thêm dữ liệu vào Series
            foreach (var item in chiPhiTheoLoai)
            {
                var dataPoint = new DataPoint
                {
                    AxisLabel = $"{item.Loai}", // Tên loại chi phí
                    YValues = new[] { (double)item.TongChiPhi }, // Giá trị chi phí
                    Label = $"{item.Loai}: {item.TongChiPhi:N0} ({(item.TongChiPhi / tongChiPhiTatCa):P1})" // Hiển thị tên, giá trị và %
                };
                series.Points.Add(dataPoint);
            }

            // Thêm Series vào biểu đồ
            chart_chiPhi.Series.Add(series);

            // Định dạng biểu đồ
            chart_chiPhi.Series["Chi phí"]["PieLabelStyle"] = "Outside"; // Hiển thị nhãn bên ngoài biểu đồ
            chart_chiPhi.Legends.Clear(); // Thêm chú thích nếu cần
            Legend legend = new Legend
            {
                Docking = Docking.Right
            };
            chart_chiPhi.Legends.Add(legend);

            List<ChiPhi> chiPhiCoDinh = _lstChiPhi.Where(x => x.LoaiChiPhi.TenLoaiChiPhi == "Chi phí cố định").ToList();
            List<ChiPhi> chiPhiGianTiep = _lstChiPhi.Where(x => x.LoaiChiPhi.TenLoaiChiPhi == "Chi phí gián tiếp").ToList();
            List<ChiPhi> chiPhiBienDoi = _lstChiPhi.Where(x => x.LoaiChiPhi.TenLoaiChiPhi == "Chi phí biến đổi").ToList();
            HienThiChiPhiChiTietTheoLoai(chiPhiCoDinh,chart_codinh);
            HienThiChiPhiChiTietTheoLoai(chiPhiGianTiep,chart_giantiep);
            HienThiChiPhiChiTietTheoLoai(chiPhiCoDinh,chart_biendoi);

        }
        private void HienThiChiPhiChiTietTheoLoai(List<ChiPhi> _lstChiPhi, Chart chart)
        {
            if (_lstChiPhi == null || !_lstChiPhi.Any())
            {
                MessageBox.Show("Không có dữ liệu chi phí để hiển thị.");
                return;
            }

            // Tính tổng tất cả các chi phí trong danh sách
            var tongTatCaChiPhi = _lstChiPhi.Sum(x => x.SoTien ?? 0);

            if (tongTatCaChiPhi == 0)
            {
                MessageBox.Show("Tổng chi phí bằng 0, không thể hiển thị biểu đồ.");
                return;
            }

            // Xóa dữ liệu cũ trên biểu đồ
            chart.Series.Clear();
            chart.Titles.Clear();

            // Tạo Series mới cho biểu đồ
            var series = new Series("Chi phí chi tiết")
            {
                ChartType = SeriesChartType.Pie
            };

            // Thêm dữ liệu vào biểu đồ
            foreach (var chiPhi in _lstChiPhi)
            {
                // Lấy số tiền và mô tả của chi phí
                var soTien = chiPhi.SoTien ?? 0;
                var moTa = chiPhi.MoTa ?? "Không xác định";

                // Tính phần trăm
                double phanTram = (double)soTien / (double)tongTatCaChiPhi * 100;

                // Thêm điểm vào biểu đồ
                int index = series.Points.AddXY(moTa, soTien); // Thêm điểm và lấy index
                var point = series.Points[index]; // Lấy đối tượng DataPoint từ index

                // Hiển thị % trên biểu đồ
                point.Label = $"{phanTram:F2}%";

                // Hiển thị tên + số tiền trong chú thích
                point.LegendText = $"{moTa} - {soTien:N0}";

                // Thay đổi font chữ của Label (nhãn của từng DataPoint) để làm chữ lớn hơn
                point.Font = new Font("Arial", 8); // Font cho các nhãn (Label)
            }

            // Cấu hình font cho chú thích của biểu đồ
            chart.Legends[0].Font = new Font("Arial", 8); // Font cho LegendText

            // Cấu hình biểu đồ
            chart.Series.Add(series);

            // Thay đổi kích thước biểu đồ tròn để to lên
            chart.ChartAreas[0].InnerPlotPosition = new ElementPosition(5, 5, 90, 90); // Tăng phần không gian biểu đồ tròn

            // Cấu hình Legend để hiển thị tên và số tiền trong chú thích
            chart.Legends[0].Enabled = true;
        }

        private void HienThiChiPhiSanXuatTheoThang(List<ChiPhi> _lstChiPhi, string title)
        {
            // Xóa dữ liệu cũ
            chart_chiPhi.Series.Clear();
            chart_chiPhi.Titles.Clear();
            chart_chiPhi.ChartAreas[0].RecalculateAxesScale();

            // Gắn nhãn cho biểu đồ
            chart_chiPhi.Titles.Add(title);
            chart_chiPhi.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold);

            // Tính toán tổng chi phí theo tháng
            var chiPhiTheoThang = _lstChiPhi
                .Where(x => x.ThoiGian.HasValue) // Đảm bảo dữ liệu có ngày hợp lệ
                .GroupBy(x => x.ThoiGian.Value.Month)
                .Select(group => new { Thang = group.Key, TongChiPhi = group.Sum(x => x.SoTien ?? 0) })
                .OrderBy(x => x.Thang)
                .ToList();

            // Kiểm tra xem có dữ liệu không
            if (chiPhiTheoThang.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu chi phí để hiển thị.");
                return;
            }

            // Khởi tạo Series cho biểu đồ cột
            Series series = new Series("Chi phí")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column,
                IsValueShownAsLabel = true
            };

            // Thêm dữ liệu vào Series
            foreach (var item in chiPhiTheoThang)
            {
                series.Points.AddXY($"Tháng {item.Thang}", item.TongChiPhi);
            }

            // Thêm Series vào biểu đồ
            chart_chiPhi.Series.Add(series);

            // Cấu hình trục X
            chart_chiPhi.ChartAreas[0].AxisX.Title = "Tháng";
            chart_chiPhi.ChartAreas[0].AxisX.Interval = 1;

            // Cấu hình trục Y
            chart_chiPhi.ChartAreas[0].AxisY.Title = "Chi phí (VND)";
            chart_chiPhi.ChartAreas[0].AxisY.Interval = 1000000000; // Từng 1 tỷ
            chart_chiPhi.ChartAreas[0].AxisY.Minimum = 0;

            // Cập nhật giá trị tối đa của trục Y dựa trên dữ liệu
            var maxValue = chiPhiTheoThang.Max(x => x.TongChiPhi);
            chart_chiPhi.ChartAreas[0].AxisY.Maximum = (double)(maxValue + 500000000); // Thêm 500 triệu cho không gian hiển thị

            // Đảm bảo biểu đồ được vẽ lại
            chart_chiPhi.Invalidate();
        }
        //viết hàm load combobox loại chi phí
        private void LoadComBoBoxLoaiChiPhi()
        {
            try
            {
                //tạo item mới
                _lstLoaiChiPhi = _loaiChiPhiBLL.LayDanhSachLoaiChiPhi(maSanPham);
                cbo_loaiChiPhi.DataSource = _lstLoaiChiPhi;
                cbo_loaiChiPhi.DisplayMember = "TenLoaiChiPhi";
                cbo_loaiChiPhi.ValueMember = "MaLoaiChiPhi";
                //chọn item đầu tiên
                cbo_loaiChiPhi.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //viết combobox load chức năng
        private void LoadComBoBoxChucNang()
        {
            //xoá item cũ
            cbo_chucNang.Items.Clear();
            //tạo item mới
            cbo_chucNang.Items.Add("Hiển thị tất cả");
            cbo_chucNang.Items.Add("Hiển thị theo mã chi phí");
            cbo_chucNang.Items.Add("Hiển thị theo loại chi phí");
            cbo_chucNang.Items.Add("Hiển thị theo tháng và năm");
            cbo_chucNang.Items.Add("Hiển thị theo mốc thời gian");

            //chọn item đầu tiên
            cbo_chucNang.SelectedIndex = 0;

        }
        // tạo cột số thứ tự nếu chưa có
        private void dgv_dsChiPhi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dgv_dsChiPhi.Columns.Contains("SoThuTu"))
            {
                dgv_dsChiPhi.Rows[e.RowIndex].Cells["SoThuTu"].Value = (e.RowIndex + 1).ToString();
            }
        }

        private void themCotSoThuTu(DataGridView dgvSanPham)
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

        // khởi tạo datagirdview
        private void KhoiTaoDgv()
        {
            //tạo các cột cho datagridview
            dgv_dsChiPhi.Columns["MaChiPhi"].HeaderText = "Mã chi phí";
            dgv_dsChiPhi.Columns["MaLoaiChiPhi"].HeaderText = "Mã loại chi phí";
            dgv_dsChiPhi.Columns["MoTa"].HeaderText = "Mô tả";
            dgv_dsChiPhi.Columns["SoTien"].HeaderText = "Số tiền";
            dgv_dsChiPhi.Columns["ThoiGian"].HeaderText = "Thời gian";

            // dàn đều các cột
            dgv_dsChiPhi.Columns["MaChiPhi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv_dsChiPhi.Columns["MaLoaiChiPhi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv_dsChiPhi.Columns["MoTa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv_dsChiPhi.Columns["SoTien"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv_dsChiPhi.Columns["ThoiGian"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //in đậm tiêu đề 
            dgv_dsChiPhi.Columns["MaChiPhi"].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv_dsChiPhi.Columns["MaLoaiChiPhi"].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv_dsChiPhi.Columns["MoTa"].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv_dsChiPhi.Columns["SoTien"].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv_dsChiPhi.Columns["ThoiGian"].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);


            //định dạng tiền tệ cho cột số tiền
            dgv_dsChiPhi.Columns["SoTien"].DefaultCellStyle.Format = "N0";

            //định dạng ngày tháng cho cột thời gian
            dgv_dsChiPhi.Columns["ThoiGian"].DefaultCellStyle.Format = "dd/MM/yyyy";

            //ẩn cột loai chi phí
            dgv_dsChiPhi.Columns["LoaiChiPhi"].Visible = false;
            //tên chi phí có thể xuống dòng tăng chiều cao của dòng
            dgv_dsChiPhi.Columns["MoTa"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

        }
        //hiển thị dữ liệu lên datagridview
        private void HienThiDuLieu(List<ChiPhi> dsChiPhi)
        {
            try
            {
                _lstChiPhi = dsChiPhi;
                if(_lstChiPhi != null)
                {
                    dgv_dsChiPhi.DataSource = _lstChiPhi;
                    KhoiTaoDgv();
                    themCotSoThuTu(dgv_dsChiPhi);
                    //đăng kí sự kiện
                    dgv_dsChiPhi.RowPostPaint -= dgv_dsChiPhi_RowPostPaint;
                    dgv_dsChiPhi.RowPostPaint += dgv_dsChiPhi_RowPostPaint;
                    dgv_dsChiPhi.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
