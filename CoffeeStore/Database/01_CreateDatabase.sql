CREATE DATABASE CoffeeManagement;
GO

USE CoffeeManagement;
GO

/*=====================================================
    Roles
=====================================================*/

CREATE TABLE Roles
(
    RoleID INT IDENTITY(1,1) PRIMARY KEY,
    RoleName NVARCHAR(50) NOT NULL
);
GO

/*=====================================================
    Users
=====================================================*/

CREATE TABLE Users
(
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    UserName NVARCHAR(50) NOT NULL,
    Password NVARCHAR(100) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    RoleID INT NOT NULL,
    IsActive BIT DEFAULT 1,

    CONSTRAINT FK_Users_Roles
        FOREIGN KEY(RoleID)
        REFERENCES Roles(RoleID)
);
GO

/*=====================================================
    Areas
=====================================================*/

CREATE TABLE Areas
(
    AreaID INT IDENTITY(1,1) PRIMARY KEY,
    AreaName NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255)
);
GO

/*=====================================================
    CafeTables
=====================================================*/

CREATE TABLE CafeTables
(
    TableID INT IDENTITY(1,1) PRIMARY KEY,
    TableName NVARCHAR(50) NOT NULL,
    AreaID INT NOT NULL,
    Status INT DEFAULT 0,

    CONSTRAINT FK_CafeTables_Areas
        FOREIGN KEY(AreaID)
        REFERENCES Areas(AreaID)
);
GO

/*=====================================================
    Categories
=====================================================*/

CREATE TABLE Categories
(
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL,
    IsActive BIT DEFAULT 1
);
GO

/*=====================================================
    Foods
=====================================================*/

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
);
GO

/*=====================================================
    Bills
=====================================================*/

CREATE TABLE Bills
(
    BillID INT IDENTITY(1,1) PRIMARY KEY,
    TableID INT NOT NULL,
    UserID INT NOT NULL,
    CreatedDate DATETIME DEFAULT GETDATE(),
    Status INT DEFAULT 0,
    TotalAmount DECIMAL(18,0) DEFAULT 0,
    PaidDate DATETIME NULL,

    CONSTRAINT FK_Bills_CafeTables
        FOREIGN KEY(TableID)
        REFERENCES CafeTables(TableID),
    CONSTRAINT FK_Bills_Users
        FOREIGN KEY(UserID)
        REFERENCES Users(UserID)
);
GO

/*=====================================================
    BillDetails
=====================================================*/

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
);
GO