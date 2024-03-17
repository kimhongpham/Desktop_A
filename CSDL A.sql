CREATE DATABASE game_databaseA;

USE game_databaseA;

CREATE TABLE Games (
    GameID INT PRIMARY KEY,
    GameName NVARCHAR(100) NOT NULL,
    NGAYPHATHANH DATE,
    THELOAI NVARCHAR(50)
);

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
drop table users;

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
