# \# CoffeeStore

# \-Bài tập C#.NET Windows Form 

# Ứng dụng được xây dựng cấu trúc theo lớp (Layers) dựa trên các Controls cơ bản như Button, panel, textbox,v.v... chủ yếu thiên hướng về Giáo dục nhưng vẫn dựa trên Logic phần mềm bán hàng thực tế.

# Lưu ý: vì đây là phần mềm ví dụ để nghiên cứu và làm quen với các Cấu trúc, Controls, toolbox của Visual Studio nên một số tính năng sẽ không như mong muốn nhằm làm rõ cách hoạt động của Controls đó 

# ===-HƯỚNG DẪN-===

# 1\. Tạo CSDL CafeManagment như hình (có trong Database => 01_CreateDatabase.sql)
<img width="1077" height="532" alt="image" src="https://github.com/user-attachments/assets/7873401e-44b8-4694-98df-9809c30433ae" />
     
# 2\. Cấu hình lại App.config trong thẻ ConnectionString để cấu hình kết nối CSDL

<connectionStrings>
	<add
	  name="DefaultConnection"
	  connectionString="Server=<Tên server SQL>;Database=<Tên Database>;User ID=<tên user thường là sa>;Password=<mật khẩu>"
	  providerName="System.Data.SqlClient"/>
</connectionStrings>

# 3\. chạy file 02_InsertSampleData.sql để lấy data mẫu có sẵn

# &#x20;  Hoặc chạy file 03_ResetDatabase.sql để tự tạo data từ đầu. (Lưu ý:  sẽ tự tạo 1 dữ liệu người dùng mặc định là Admin có pass là: 123)

# 4\. RUN APP

