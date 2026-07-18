INSERT INTO Areas ( AreaName, Description) 
		 VALUES (N'Tầng 01', N'Sảnh chính' ),
				(N'Tầng 02', N'Lầu 01-Bàn đôi-bàn nhóm' ),
				(N'Tầng 03', N'Lầu 02 - Phòng họp' ),
				(N'Tầng 04', N'Chỉ dành Đặc tiệc' )
select * from Bills
select * from BillDetails
--Bàn Tầng --
DECLARE @AreaID INT = 1;              -- KHU VỰC (AreaID)
DECLARE @TotalTable INT = 40;         -- SỐ LƯỢNG BÀN
DECLARE @Prefix NVARCHAR(10) = '01';  -- Mã khu vực hiển thị (T01, T02,...)

DECLARE @i INT = 1;

WHILE @i <= @TotalTable
BEGIN
    INSERT INTO CafeTables (TableName, AreaID, Status)
    VALUES
    (
        N'T' + @Prefix + '-' + RIGHT('00' + CAST(@i AS NVARCHAR(2)), 2),
        @AreaID,
        0
    );

    SET @i += 1;
END;

INSERT INTO Categories(CategoryName, IsActive)
VALUES
(N'Cà phê',1),
(N'Trà',1),
(N'Trà sữa',1),
(N'Nước ép',1),
(N'Sinh tố',1),
(N'Đá xay',1),
(N'Nước ngọt',1),
(N'Bánh ngọt',1),
(N'Đồ ăn nhẹ',1),
(N'Topping',1);
				--cafe--
INSERT INTO Foods(FoodName, CategoryID, Price, IsActive)
VALUES
(N'Cà phê đen',1,25000,1),
(N'Cà phê sữa',1,30000,1),
(N'Bạc xỉu',1,35000,1),
(N'Americano',1,45000,1),
(N'Latte',1,50000,1),
(N'Cappuccino',1,50000,1),
(N'Mocha',1,55000,1),
(N'Espresso',1,40000,1);
--trà--
INSERT INTO Foods(FoodName, CategoryID, Price, IsActive)
VALUES
(N'Trà đào cam sả',2,45000,1),
(N'Trà vải',2,40000,1),
(N'Trà chanh',2,25000,1),
(N'Trà tắc',2,25000,1),
(N'Trà sen vàng',2,45000,1),
(N'Trà nhãn',2,45000,1);
--tra sua
INSERT INTO Foods(FoodName, CategoryID, Price, IsActive)
VALUES
(N'Trà sữa truyền thống',3,40000,1),
(N'Trà sữa Matcha',3,45000,1),
(N'Trà sữa Socola',3,45000,1),
(N'Trà sữa Khoai môn',3,45000,1),
(N'Trà sữa Olong',3,50000,1),
(N'Trà sữa Than tre',3,50000,1);
--nuoc ep
INSERT INTO Foods(FoodName, CategoryID, Price, IsActive)
VALUES
(N'Nước ép cam',4,45000,1),
(N'Nước ép thơm',4,45000,1),
(N'Nước ép dưa hấu',4,45000,1),
(N'Nước ép táo',4,50000,1),
(N'Nước ép ổi',4,45000,1);
-- sinh to
INSERT INTO Foods(FoodName, CategoryID, Price, IsActive)
VALUES
(N'Sinh tố bơ',5,50000,1),
(N'Sinh tố xoài',5,50000,1),
(N'Sinh tố dâu',5,50000,1),
(N'Sinh tố chuối',5,45000,1),
(N'Sinh tố sapoche',5,50000,1);
-- da xay
INSERT INTO Foods(FoodName, CategoryID, Price, IsActive)
VALUES
(N'Cookies đá xay',6,55000,1),
(N'Matcha đá xay',6,55000,1),
(N'Socola đá xay',6,55000,1),
(N'Oreo đá xay',6,60000,1),
(N'Caramel đá xay',6,60000,1);
--nuoc ngot
INSERT INTO Foods(FoodName, CategoryID, Price, IsActive)
VALUES
(N'Coca Cola',7,20000,1),
(N'Pepsi',7,20000,1),
(N'7Up',7,20000,1),
(N'Sting',7,20000,1),
(N'Aquafina',7,15000,1),
(N'Red Bull',7,25000,1);
-- banh ngot
INSERT INTO Foods(FoodName, CategoryID, Price, IsActive)
VALUES
(N'Tiramisu',8,45000,1),
(N'Cheesecake',8,50000,1),
(N'Bánh su kem',8,35000,1),
(N'Bánh mousse',8,45000,1),
(N'Brownie',8,40000,1);
-- do an nhe
INSERT INTO Foods(FoodName, CategoryID, Price, IsActive)
VALUES
(N'Khoai tây chiên',9,40000,1),
(N'Xúc xích',9,35000,1),
(N'Cá viên chiên',9,40000,1),
(N'Gà viên chiên',9,45000,1),
(N'Khô gà lá chanh',9,50000,1);
--topping 
INSERT INTO Foods(FoodName, CategoryID, Price, IsActive)
VALUES
(N'Trân châu đen',10,10000,1),
(N'Trân châu trắng',10,10000,1),
(N'Thạch trái cây',10,10000,1),
(N'Kem cheese',10,15000,1),
(N'Pudding trứng',10,10000,1);