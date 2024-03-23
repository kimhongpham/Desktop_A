CREATE DATABASE game_databaseA;

USE game_databaseA;

CREATE TABLE Games (
    GameID INT PRIMARY KEY,
    GameName NVARCHAR(100) NOT NULL,
    NGAYPHATHANH DATE,
    THELOAI NVARCHAR(50)
);
ALTER TABLE Games DROP COLUMN THELOAI;
ALTER TABLE Games ADD GameDescription NVARCHAR(255);

CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    UserName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    Password NVARCHAR(50) NOT NULL,
    NGAYTHAMGIA DATE,
    TEN NVARCHAR(50),
    HO NVARCHAR(50),
    SDT NVARCHAR(20),
    QUOCGIA NVARCHAR(100),
    THANHPHO NVARCHAR(100),
    Address NVARCHAR(255)
);

CREATE TABLE UserGames (
    UserID INT,
    GameID INT,
    PRIMARY KEY (UserID, GameID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (GameID) REFERENCES Games(GameID)
);

CREATE TABLE GameSessions (
    GameSessionID INT PRIMARY KEY,
    GameID INT,
    UserID INT,
    StartDate DATETIME,
    EndDate DATETIME,
    Score BIGINT,
    FOREIGN KEY (GameID) REFERENCES Games(GameID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
select *from Games;
select *from Users;
select *from UserGames;
select *from CauHoi;


set ansi_nulls on
go
set quoted_identifier on
go
create table Mon
(
	MaMon int not null,
	TenMon nvarchar(200) not null,
	Constraint MON_PK primary key(MaMon)
)
go
set ansi_nulls on
go
set quoted_identifier on
go
create table CauHoi
(
	NoiDung nvarchar(4000) not null,
	Mon int not null,
	DA1 nvarchar(4000) not null,
	DA2 nvarchar(4000) not null,
	DA3 nvarchar(4000) not null,
	DA4 nvarchar(4000) not null,
	DA nvarchar (4000) not null
)
go
alter table CauHoi
add constraint FK_CAUHOI_MON foreign key(Mon) references Mon(MaMon);
----
INSERT INTO Mon VALUES
(1, 'OOP'),
(2, 'Phát triển ứng dụng desktop'),
(3, 'Khoa học dữ liệu');
----
insert into CauHoi values ('Trong lập trình hướng đối tượng, đặc điểm chính của đối tượng là gì?', 1, 'Tính đóng gói (Encapsulation)', 'Tính kế thừa (Inheritance)', 'Tính trừu tượng (Abstraction)', 'Tính đa hình (Polymorphism)', 'Tính đóng gói (Encapsulation)');

insert into CauHoi values ('Lợi ích chính của kế thừa (Inheritance) trong lập trình hướng đối tượng là gì?', 1, 'Tái sử dụng mã nguồn', 'Mở rộng chức năng', 'Tạo các lớp con', 'Triển khai tính đa hình', 'Tái sử dụng mã nguồn');

insert into CauHoi values ('Trong lập trình hướng đối tượng, đa hình (Polymorphism) có ý nghĩa gì?', 1, 'Cho phép một đối tượng thể hiện nhiều hình dạng', 'Cho phép gọi các phương thức cùng tên nhưng khác nhau', 'Cho phép sắp xếp đối tượng theo thứ tự', 'Cho phép xác định kiểu dữ liệu động', 'Cho phép một đối tượng thể hiện nhiều hình dạng');

insert into CauHoi values ('Trong lập trình hướng đối tượng, trừu tượng (Abstraction) có ý nghĩa gì?', 1, 'Tách biệt giao diện và cài đặt', 'Giảm sự phức tạp của hệ thống', 'Ẩn thông tin chi tiết', 'Tạo ra các lớp cơ sở', 'Tách biệt giao diện và cài đặt');

insert into CauHoi values ('Trong lập trình hướng đối tượng, gì là hiện thực (Implementation)?', 1, 'Triển khai các phương thức của một lớp', 'Tạo ra các đối tượng từ lớp', 'Sử dụng tính kế thừa', 'Tạo ra các lớp con', 'Triển khai các phương thức của một lớp');

insert into CauHoi values ('Phát triển ứng dụng desktop là gì?', 2, 'Là quá trình tạo ra các ứng dụng chạy trên máy tính cá nhân', 'Là việc phát triển ứng dụng chạy trên trình duyệt', 'Là quy trình tạo ra các ứng dụng di động', 'Là việc tạo ra các ứng dụng web', 'Là quá trình tạo ra các ứng dụng chạy trên máy tính cá nhân');

insert into CauHoi values ('Ngôn ngữ lập trình phổ biến cho phát triển ứng dụng desktop là gì?', 2, 'C#', 'Java', 'Python', 'JavaScript', 'C#');

insert into CauHoi values ('Các công cụ phát triển ứng dụng desktop phổ biến là gì?', 2, 'Visual Studio', 'Eclipse', 'PyCharm', 'NetBeans', 'Visual Studio');

insert into CauHoi values ('Điểm mạnh của ứng dụng desktop so với ứng dụng web là gì?', 2, 'Có thể hoạt động ngoại tuyến', 'Không cần cài đặt trình duyệt', 'Tương tác trực tiếp với hệ thống máy tính', 'Có thể chạy trên nhiều nền tảng', 'Có thể hoạt động ngoại tuyến');

insert into CauHoi values ('Quy trình phát triển ứng dụng desktop thông thường là gì?', 2, 'Thu thập yêu cầu', 'Thiết kế giao diện', 'Lập trình và kiểm thử', 'Triển khai và triển khai', 'Thu thập yêu cầu');

INSERT INTO CauHoi  VALUES ('Trong khoa học dữ liệu, khái niệm "feature extraction" ám chỉ điều gì?', 3, 'Quá trình chọn lựa các đặc trưng quan trọng từ dữ liệu ban đầu', 'Quá trình xử lý và chuẩn hóa dữ liệu', 'Quá trình phân tích và khám phá dữ liệu', 'Quá trình xây dựng mô hình dự đoán', 'Quá trình chọn lựa các đặc trưng quan trọng từ dữ liệu ban đầu');

INSERT INTO CauHoi  VALUES ('Trong khoa học dữ liệu, thuật toán "K-means" được sử dụng để làm gì?', 3, 'Phân cụm dữ liệu', 'Xây dựng mô hình hồi quy', 'Phân loại dữ liệu', 'Thực hiện phân tích thành phần chính', 'Phân cụm dữ liệu');

INSERT INTO CauHoi  VALUES ('Trong khoa học dữ liệu, khái niệm "overfitting" có ý nghĩa gì?', 3, 'Mô hình quá phù hợp với dữ liệu huấn luyện nhưng không tổng quát với dữ liệu mới', 'Mô hình không đủ phức tạp để học được mẫu trong dữ liệu', 'Mô hình không đạt độ chính xác mong muốn', 'Mô hình có khả năng tổng quát hóa tốt với dữ liệu mới', 'Mô hình quá phù hợp với dữ liệu huấn luyện nhưng không tổng quát với dữ liệu mới');

INSERT INTO CauHoi  VALUES ('Trong khoa học dữ liệu, khái niệm "cross-validation" được sử dụng để làm gì?', 3, 'Đánh giá hiệu suất mô hình trên dữ liệu thử nghiệm','Phân chia dữ liệu thành tập huấn luyện và tập kiểm tra', 'Lựa chọn thuật toán phù hợp với bài toán','Xử lý dữ liệu thiếu và nhiễu','Đánh giá hiệu suất mô hình trên dữ liệu thử nghiệm');

INSERT INTO CauHoi  VALUES ('Trong khoa học dữ liệu, khái niệm "dimensionality reduction" ám chỉ điều gì?', 3, 'Quá trình giảm số chiều của dữ liệu','Quá trình tạo ra các đặc trưng mới từ dữ liệu ban đầu', 'Quá trình tìm ra mô hình tốt nhất cho dữ liệu','Quá trình xác định độ quan trọng của các đặc trưng','Quá trình giảm số chiều của dữ liệu');


SELECT 
    UserID,
    GameID,
    COUNT(*) as PlayCount
FROM 
    GameSessions
GROUP BY 
    UserID, GameID
ORDER BY 
    UserID, PlayCount DESC;
--Để lấy thông tin chi tiết về game yêu thích của mỗi người dùng
SELECT 
    UserID,
    GameID as FavoriteGameID
FROM 
    (SELECT 
        UserID,
        GameID,
        ROW_NUMBER() OVER (PARTITION BY UserID ORDER BY COUNT(*) DESC) as RowNum
     FROM 
        GameSessions
     GROUP BY 
        UserID, GameID) as GamePlayCounts
WHERE 
    RowNum = 1;
--để lấy thông tin chi tiết về game yêu thích của mỗi người dùng
SELECT 
    f.UserID,
    g.GameName as FavoriteGameName
FROM 
    (SELECT 
        UserID,
        GameID as FavoriteGameID
     FROM 
        (SELECT 
            UserID,
            GameID,
            ROW_NUMBER() OVER (PARTITION BY UserID ORDER BY COUNT(*) DESC) as RowNum
         FROM 
            GameSessions
         GROUP BY 
            UserID, GameID) as GamePlayCounts
     WHERE 
        RowNum = 1) as f
    JOIN Games g ON f.FavoriteGameID = g.GameID;

SELECT state_desc FROM sys.databases WHERE name = 'game_databaseA1';
Get-Service | Where {$_.status -eq 'running' -and $_.DisplayName -like "sql server*"}
