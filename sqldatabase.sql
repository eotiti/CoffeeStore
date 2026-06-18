CREATE DATABASE CafeManagement
GO
USE CafeManagement
GO
CREATE TABLE Roles
(
    RoleID INT PRIMARY KEY,
    RoleName NVARCHAR(50) NOT NULL
)
GO
INSERT INTO Roles(RoleID,RoleName)
VALUES
(1,'Admin'),
(2,'User'),
(3,'Customer')
GO
CREATE TABLE Users
(
    UserID INT IDENTITY(1,1) PRIMARY KEY,

    UserName NVARCHAR(50) NOT NULL UNIQUE,

    Pass NVARCHAR(100) NOT NULL,

    FullName NVARCHAR(100),

    RoleID INT NOT NULL,

    IsActive int default 0,

    CONSTRAINT FK_Users_Roles
    FOREIGN KEY(RoleID)
    REFERENCES Roles(RoleID)
)
GO
INSERT INTO Users(UserName,Password,FullName,RoleID)
VALUES('nhanvien01','123',N'Quản trị hệ thống',1)
GO
CREATE TABLE Areas
(
    AreaID INT IDENTITY(1,1) PRIMARY KEY,

    AreaName NVARCHAR(100) NOT NULL,

    Description NVARCHAR(255)
)
GO
INSERT INTO Areas
(
    AreaName,
    Description
)
VALUES
(N'Tầng 1',N'Khu vực trong nhà'),
(N'Tầng 2',N'Khu vực máy lạnh'),
(N'Sân vườn',N'Khu vực ngoài trời')
GO
CREATE TABLE CafeTables
(
    TableID INT IDENTITY(1,1) PRIMARY KEY,

    TableName NVARCHAR(50) NOT NULL,

    AreaID INT NOT NULL,

    Status INT DEFAULT 0,

    CONSTRAINT FK_CafeTables_Areas
    FOREIGN KEY(AreaID)
    REFERENCES Areas(AreaID)
)
GO
INSERT INTO CafeTables
(
    TableName,
    AreaID
)
VALUES
('B01',1),
('B02',1),
('B03',1),

('A01',2),
('A02',2),

('S01',3),
('S02',3)
GO
CREATE TABLE Categories
(
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,

    CategoryName NVARCHAR(100) NOT NULL,
	IsActive BIT DEFAULT 1
)
GO
INSERT INTO Categories(CategoryName)
VALUES
(N'Cafe'),
(N'Trà sữa'),
(N'Nước ép'),
(N'Sinh tố')
GO
CREATE TABLE Foods
(
    FoodID INT IDENTITY(1,1) PRIMARY KEY,

    FoodName NVARCHAR(100) NOT NULL,

    CategoryID INT NOT NULL,

    Price DECIMAL(18,0) NOT NULL,

    IsActive BIT DEFAULT 1,

    CONSTRAINT FK_Foods_Categories
    FOREIGN KEY(CategoryID)
    REFERENCES Categories(CategoryID)
)
GO
INSERT INTO Foods
(
    FoodName,
    CategoryID,
    Price
)
VALUES
(N'Cafe đen',1,25000),
(N'Cafe sữa',1,30000),
(N'Trà đào',2,35000),
(N'Nước cam',3,40000)
GO
CREATE TABLE Bills
(
    BillID INT IDENTITY(1,1) PRIMARY KEY,

    TableID INT NOT NULL,

    UserID INT NOT NULL,

    CreatedDate DATETIME DEFAULT GETDATE(),

    Status INT DEFAULT 0
)
GO
CREATE TABLE BillDetails
(
    BillDetailID INT IDENTITY(1,1) PRIMARY KEY,

    BillID INT NOT NULL,

    FoodID INT NOT NULL,

    Quantity INT NOT NULL,

    UnitPrice DECIMAL(18,0) NOT NULL,

    Amount DECIMAL(18,0) NOT NULL,

    CONSTRAINT FK_BillDetails_Bills
    FOREIGN KEY(BillID)
    REFERENCES Bills(BillID),

    CONSTRAINT FK_BillDetails_Foods
    FOREIGN KEY(FoodID)
    REFERENCES Foods(FoodID)
)
GO
SELECT * FROM Roles
SELECT * FROM Users
SELECT * FROM Areas
SELECT * FROM CafeTables
SELECT * FROM Categories
SELECT * FROM Foods