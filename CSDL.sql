CREATE DATABASE game_databaseA;

USE game_databaseA;

CREATE TABLE Games (
    GameID INT PRIMARY KEY,
    GameName NVARCHAR(100) NOT NULL,
    NGAYPHATHANH DATE,
    GameDescription NVARCHAR(255)
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
CREATE TABLE GameState 
(
    ID INT PRIMARY KEY IDENTITY,
    UserID INT,
    Level INT,
    Score INT,
    Rows INT,
    Cols INT,
    MaxFlips INT,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
select *from Games;
select *from Users;
select *from UserGames;
select *from GameSessions;

--Bảng thành tích của username 
SELECT 
    g.GameID,
    g.GameName AS GameName,
    MAX(gs.Score) AS HighestScore,
    DENSE_RANK() OVER(ORDER BY MAX(gs.Score) DESC) AS Ranking
FROM 
    GameSessions gs
    JOIN Games g ON gs.GameID = g.GameID
    JOIN Users u ON gs.UserID = u.UserID
WHERE 
    u.UserID = '8'
GROUP BY 
    g.GameID, g.GameName
ORDER BY 
    g.GameID;

select *
from GameSessions gs
where gameid ='3';

--Lấy ra người có điêmr cao nhất của từng game
SELECT U.UserName, G.GameID, G.Score
FROM (
  SELECT GameID, Score, UserID,
    ROW_NUMBER() OVER (PARTITION BY GameID ORDER BY Score DESC) AS Rank
  FROM GameSessions
) G
JOIN Users U ON G.UserID = U.UserID
WHERE G.Rank = 1;

--Bảng thành tích của username 
    SELECT 
    GameID, GameName, HighestScore, Ranking
FROM
    (SELECT 
        GameID, GameName, UserID, HighestScore,
        RANK() OVER (PARTITION BY GameID ORDER BY HighestScore DESC) AS Ranking
    FROM
        (SELECT
            g.GameID, g.GameName, gs.UserID, MAX(gs.Score) AS HighestScore
        FROM
            GameSessions gs
        JOIN
            Games g ON gs.GameID = g.GameID
        GROUP BY
            g.GameID, g.GameName, gs.UserID) AS subquery) AS ranks
WHERE
    UserID = 39
ORDER BY
    GameID;

--Biểu đồ cột so sánh số lượng người chơi 3 trò chơi:
SELECT CONVERT(date, StartDate) AS GameDate,
                (SELECT GameName FROM Games WHERE GameID = gs.GameID) AS GameName,
                COUNT(*) AS PlayersCount
            FROM GameSessions gs
            WHERE gs.GameID IN (1, 2, 3)
                AND StartDate IS NOT NULL
            GROUP BY CONVERT(date, StartDate), gs.GameID
            ORDER BY CONVERT(date, StartDate);

--Số lượt chơi từng game
SELECT TOP 3 g.GameName, COUNT(*) 
FROM GameSessions gs 
JOIN Games g ON gs.GameID = g.GameID 
GROUP BY g.GameName 
ORDER BY COUNT(*) DESC;
-- danh sách 5 tên người dùng có lượt chơi nhiều nhất trong bảng GameSessions.
SELECT TOP 5 u.username, COUNT(*) 
FROM GameSessions gs 
JOIN users u ON gs.userid = u.userid 
GROUP BY u.username 
ORDER BY COUNT(*) DESC;
SELECT GameID, GameName, HighestScore, Ranking
FROM (SELECT GameID, GameName, UserID, HighestScore,RANK() OVER (PARTITION BY GameID ORDER BY HighestScore DESC) AS Ranking
      FROM (SELECT g.GameID, g.GameName, gs.UserID, MAX(gs.Score) AS HighestScore
            FROM GameSessions gs
            JOIN Games g ON gs.GameID = g.GameID
            GROUP BY g.GameID, g.GameName, gs.UserID) AS subquery) AS ranks
            WHERE UserID = 9
            ORDER BY GameID;
--