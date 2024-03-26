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
select *from Games;
select *from Users;
select *from UserGames;
select *from GameSessions;
ALTER TABLE Games DROP COLUMN THELOAI;
ALTER TABLE Games ADD GameDescription NVARCHAR(255);
ALTER TABLE Games ADD GameImage varbinary(max);
DROP TABLE CauHoi
DROP TABLE Mon
DELETE FROM Games
WHERE GameName='Game 1';
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
where gs.UserID = '9' and gameid ='1';
