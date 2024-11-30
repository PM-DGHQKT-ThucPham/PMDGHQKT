<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Đề tài: Hệ thống đánh giá hiệu quả kinh tế sản phẩm thực phẩm</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            line-height: 1.6;
            margin: 20px;
            background-color: #f9f9f9;
            color: #333;
        }
        h1, h2, h3 {
            color: #0056b3;
        }
        table {
            width: 100%;
            border-collapse: collapse;
            margin: 20px 0;
        }
        table, th, td {
            border: 1px solid #ccc;
        }
        th, td {
            padding: 10px;
            text-align: left;
        }
        th {
            background-color: #f4f4f4;
        }
        ul {
            margin: 10px 0 20px 20px;
        }
    </style>
</head>
<body>

    <h1>Đề tài: Hệ thống đánh giá hiệu quả kinh tế sản phẩm thực phẩm</h1>

    <h2>Thành viên nhóm</h2>
    <table>
        <tr>
            <th>STT</th>
            <th>Tên thành viên</th>
            <th>Chức vụ</th>
        </tr>
        <tr>
            <td>1</td>
            <td>Ngô Thành Quang</td>
            <td>Nhóm trưởng</td>
        </tr>
        <tr>
            <td>2</td>
            <td>Hoàng Đức Quân</td>
            <td>Thành viên</td>
        </tr>
        <tr>
            <td>3</td>
            <td>Lê Thanh Yên</td>
            <td>Thành viên</td>
        </tr>
    </table>

    <h2>Giới thiệu đề tài</h2>
    <p>
        Hệ thống đánh giá hiệu quả kinh tế sản phẩm thực phẩm là một ứng dụng WinForms nhằm hỗ trợ doanh nghiệp quản lý hiệu quả 
        các thông tin sản phẩm, nhân viên, và các tiêu chí đánh giá. Hệ thống cung cấp công cụ phân tích chi phí, doanh thu, 
        và lợi nhuận để đánh giá hiệu quả kinh tế của từng sản phẩm.
    </p>

    <h2>Công nghệ sử dụng</h2>
    <ul>
        <li><strong>WinForms:</strong> Giao diện chính của ứng dụng, hỗ trợ nhập liệu, quản lý, và tạo báo cáo.</li>
        <li><strong>SQL Server:</strong> Quản lý cơ sở dữ liệu sản phẩm, chi phí, doanh thu và tiêu chí đánh giá.</li>
        <li><strong>C#:</strong> Ngôn ngữ lập trình chính để phát triển các chức năng.</li>
        <li><strong>Crystal Reports:</strong> Công cụ tạo báo cáo chi tiết và biểu đồ phân tích.</li>
    </ul>

    <h2>Danh sách chức năng hệ thống</h2>
    <h3>1. Quản lý sản phẩm</h3>
    <ul>
        <li>Nhập, sửa, xóa thông tin sản phẩm.</li>
        <li>Phân loại sản phẩm theo nhóm.</li>
    </ul>

    <h3>2. Quản lý chi phí</h3>
    <ul>
        <li>Nhập chi phí nguyên liệu, sản xuất, phân phối.</li>
        <li>Tổng hợp chi phí theo sản phẩm và kỳ kinh doanh.</li>
    </ul>

    <h3>3. Quản lý doanh thu</h3>
    <ul>
        <li>Nhập doanh thu theo sản phẩm và thời gian.</li>
        <li>Tổng hợp và so sánh doanh thu giữa các sản phẩm.</li>
    </ul>

    <h3>4. Quản lý nhân viên</h3>
    <ul>
        <li>Thêm, sửa, xóa thông tin nhân viên.</li>
        <li>Phân quyền cho nhân viên và quản lý trạng thái tài khoản.</li>
    </ul>

    <h3>5. Quản lý các tiêu chí đánh giá</h3>
    <ul>
        <li>Thiết lập và quản lý các tiêu chí như hiệu quả kinh tế, chất lượng, độ phổ biến.</li>
        <li>Phân tích và đánh giá theo các tiêu chí được định sẵn.</li>
    </ul>

    <h3>6. Đánh giá hiệu quả kinh tế</h3>
    <ul>
        <li>Phân tích lợi nhuận gộp, lợi nhuận ròng.</li>
        <li>Hiển thị biểu đồ trực quan và so sánh hiệu quả giữa các sản phẩm.</li>
    </ul>

    <h3>7. Báo cáo</h3>
    <ul>
        <li>Xuất báo cáo về sản phẩm, chi phí, doanh thu, và tiêu chí đánh giá.</li>
        <li>Hỗ trợ xuất ra file PDF hoặc Excel.</li>
    </ul>

    <h2>Phân công công việc</h2>
<table>
    <tr>
        <th>Chức năng</th>
        <th>Hoàng Đức Quân</th>
        <th>Lê Thanh Yên</th>
        <th>Ngô Thành Quang</th>
    </tr>
    <tr>
        <td>Quản lý sản phẩm</td>
        <td>Nhập, sửa, xóa sản phẩm</td>
        <td>Quản lý danh mục sản phẩm</td>
        <td>Phân loại sản phẩm, xử lý lỗi dữ liệu</td>
    </tr>
    <tr>
        <td>Quản lý chi phí</td>
        <td>Nhập chi phí sản xuất</td>
        <td>Tổng hợp chi phí theo sản phẩm</td>
        <td>Phân tích chi phí, báo cáo chi phí</td>
    </tr>
    <tr>
        <td>Quản lý doanh thu</td>
        <td>Nhập doanh thu, cập nhật</td>
        <td>Tạo báo cáo doanh thu chi tiết</td>
        <td>So sánh doanh thu theo thời gian</td>
    </tr>
    <tr>
        <td>Quản lý nhân viên</td>
        <td>Thêm, sửa, xóa thông tin nhân viên</td>
        <td>Phân quyền nhân viên</td>
        <td>Quản lý tài khoản, trạng thái nhân viên</td>
    </tr>
    <tr>
        <td>Quản lý tiêu chí đánh giá</td>
        <td>Tạo và chỉnh sửa các tiêu chí</td>
        <td>Phân tích tiêu chí theo sản phẩm</td>
        <td>Thiết lập tiêu chí mới theo yêu cầu</td>
    </tr>
    <tr>
        <td>Đánh giá hiệu quả kinh tế</td>
        <td>Phân tích biểu đồ hiệu quả</td>
        <td>Tính toán lợi nhuận từng sản phẩm</td>
        <td>So sánh hiệu quả giữa các sản phẩm</td>
    </tr>
    <tr>
        <td>Báo cáo</td>
        <td>Tạo báo cáo tổng hợp</td>
        <td>Xuất file báo cáo PDF</td>
        <td>Xuất file báo cáo Excel</td>
    </tr>
</table>


    <h2>Kết luận</h2>
    <p>
        Hệ thống đánh giá hiệu quả kinh tế sản phẩm thực phẩm giúp doanh nghiệp quản lý hiệu quả sản phẩm và nhân viên, đồng thời 
        cung cấp công cụ phân tích và báo cáo toàn diện. Với giao diện WinForms thân thiện và các chức năng mạnh mẽ, hệ thống là một 
        giải pháp lý tưởng cho các doanh nghiệp sản xuất thực phẩm.
    </p>

</body>
</html>
