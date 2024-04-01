# Tên Dự Án

XÂY DỰNG ỨNG DỤNG CHƠI GAME SỬ DỤNG WINFORM.

## Cài Đặt

Hướng dẫn cài đặt dự án trên máy tính của bạn.

1. **Clone** dự án từ GitHub:

    ```
    git clone https://github.com/Beomkimhong/Desktop_A.git
    ```hoặc
    git clone git@github.com:Beomkimhong/Desktop_A.git
    Nếu cả hai cách trên đều không thể thực hiện được bạn có thể tải file ZIP và giải nén nó

2. **Di chuyển** vào thư mục dự án:

    ```Truy cập
    Gaming Dashboard.sln
    ```để chạy chương trình

3. **Cài đặt** các phụ thuộc:

    ```Kết nối cơ sở dữ liệu
    Đồ án NHÓM CUỐI KỲ
PHÁT TRIỂN ỨNG DỤNG DESKTOP
ĐỀ TÀI: XÂY DỰNG ỨNG DỤNG CHƠI GAME SỬ DỤNG WINFORM
CHƯƠNG III: ĐIỀU CHỈNH, MỞ RỘNG VÀ PHÁT TRIỂN ỨNG DỤNG
Vì server cũ bị sập nên bạn có thể kết nối cơ sở dữ liệu bằng server mới như sau : 
Server name : Game_db.mssql.somee.com
username : duyennguyen_SQLLogin_1
Password :6kre9zfjp3
3.4 Kết nối cơ sở dữ liệu
    ```

## Sử Dụng

'''Đăng nhập bằng tài khoản admin để chạy toàn bộ chức năng của đồ án 
Email : louica0107@gmail.com
Pass : 999999
'''Hoặc đăng ký tài khoản mới để sử dụng các chức năng ngoại trừ Admin

## Liên Hệ

Liên hệ với tôi qua email: sugahong0107@gmail.com
##**Note** :
Vì server cũ đã bị sập nên bạn muốn chạy chương trình hãy thay code ở Kết nối.cs của project Admin từ dòng 15 đến dòng 19 bằng đoạn code sau : 
DataSource = "Game_db.mssql.somee.com",
InitialCatalog = "Game_db",
UserID = "duyennguyen_SQLLogin_1",
Password = "6kre9zfjp3",
TrustServerCertificate = true,
PacketSize = 4096,
PersistSecurityInfo = false
--Sau đó tiến hành chạy như bình thường.
