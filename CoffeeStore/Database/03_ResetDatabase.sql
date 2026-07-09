DELETE FROM BillDetails;
DELETE FROM Bills;
DELETE FROM Foods;
DELETE FROM Categories;
DELETE FROM CafeTables;
DELETE FROM Areas;
DELETE FROM Users;
DELETE FROM Roles;


DBCC CHECKIDENT ('BillDetails', RESEED, 0);
DBCC CHECKIDENT ('Bills', RESEED, 0);
DBCC CHECKIDENT ('Foods', RESEED, 0);
DBCC CHECKIDENT ('Categories', RESEED, 0);
DBCC CHECKIDENT ('CafeTables', RESEED, 0);
DBCC CHECKIDENT ('Areas', RESEED, 0);
DBCC CHECKIDENT ('Users', RESEED, 0);
DBCC CHECKIDENT ('Roles', RESEED, 0);

insert into Roles values (1,N'Admin')
insert into Users values (N'Admin',N'123',N'Lư Thanh Trí',1)

--UPDATE CafeTables
--SET Status = 0;