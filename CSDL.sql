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
