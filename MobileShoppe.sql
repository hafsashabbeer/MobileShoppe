CREATE DATABASE MobileShoppe
USE MobileShoppe

CREATE TABLE [User]
(
	UserName NVARCHAR(20) PRIMARY KEY,
	[Password] NVARCHAR(20) NOT NULL,
	EmployeeName NVARCHAR(20) NOT NULL,
	[Address] NVARCHAR(20) NOT NULL,
	MobileNumber NVARCHAR(20) NOT NULL,
	Hint NVARCHAR(20) NOT NULL,
	IsAdmin INT NOT NULL
)

CREATE TABLE Company
(
	CompanyId INT IDENTITY(101,1) PRIMARY KEY ,
	CompanyName NVARCHAR(20) NOT NULL 
)

CREATE TABLE Model
(
	ModelId INT IDENTITY(201,1) PRIMARY KEY,
	CompanyId INT FOREIGN KEY REFERENCES Company(CompanyId),
	ModelNum NVARCHAR(20) NOT NULL,
	AvailableQty INT NOT NULL
)

CREATE TABLE [Transaction]
(
	TransId INT IDENTITY(301,1) PRIMARY KEY,
	ModelId INT FOREIGN KEY REFERENCES Model(ModelId),
	Quantity NVARCHAR(10) NOT NULL,
	[Date] DATE NOT NULL,
	Amount NVARCHAR(20) NOT NULL
)

CREATE TABLE Mobile
(
	ModelId INT FOREIGN KEY REFERENCES Model(ModelId),
	IMEINO NVARCHAR(20) PRIMARY KEY,
	[Status] NVARCHAR(20) NOT NULL,
	Warranty NVARCHAR(20) NOT NULL,
	Price NVARCHAR(20) NOT NULL,
)

CREATE TABLE Customer
(
	CustomerId INT IDENTITY(401,1) PRIMARY KEY,
	CustomerName NVARCHAR(20) NOT NULL,
	MobileNumber NVARCHAR(20) NOT NULL,
	EmailId NVARCHAR(20) NOT NULL,
	[Address] NVARCHAR(20) NOT NULL
)

CREATE TABLE Sales
(
	SalesId INT IDENTITY(501,1) PRIMARY KEY,
	IMEINO NVARCHAR(20) FOREIGN KEY REFERENCES Mobile(IMEINO),
	PurchaseDate DATE NOT NULL,
	Price INT NOT NULL,
	CustomerId INT FOREIGN KEY REFERENCES Customer(CustomerId)
)

DROP PROCEDURE CheckCredentials
CREATE PROCEDURE CheckCredentials
@UserName NVARCHAR(20),
@Password NVARCHAR(20)
AS
BEGIN

SELECT IsAdmin FROM [User]
WHERE UserName = @UserName AND [Password] = @Password

END

EXECUTE CheckCredentials @UserName = 'Admin', @Password = 'Admin'


INSERT INTO [User]
VALUES 
(
	'Admin',
	'Admin',
	'Admin',
	'Hyderabad',
	'9860564321',
	'Admin',
	1
)

SELECT * FROM Company

CREATE PROCEDURE AddCompany
@CompanyName NVARCHAR(20)
AS
BEGIN

INSERT INTO Company (CompanyName) VALUES (@CompanyName)

END

SELECT CompanyId,CompanyName FROM Company

DECLARE @ModelNum NVARCHAR(20), @AvailableQty INT 
DECLARE @CompanyId INT

DECLARE @Id INT = (SELECT CompanyId FROM Company 
WHERE CompanyName=@CompanyName)
INSERT INTO Model (CompanyId, ModelNum, AvailableQty) VALUES (@Id, @ModelNum, @AvailableQty)


INSERT INTO Model (CompanyId, ModelNum, AvailableQty) VALUES (@CompanyId, @ModelNum, @AvailableQty)

SELECT * FROM Model

CREATE PROCEDURE SpGetCompanyId
AS
BEGIN
IF (NOT EXISTS (SELECT 1 FROM [Company]))
BEGIN
	SELECT IDENT_CURRENT('Company')
END
ELSE
BEGIN
    SELECT IDENT_CURRENT('Company') + IDENT_INCR('Company')
END
END


CREATE PROCEDURE SpGetModelId
AS
BEGIN
IF (NOT EXISTS (SELECT 1 FROM Model))
BEGIN
	SELECT IDENT_CURRENT('Model')
END
ELSE
BEGIN
    SELECT IDENT_CURRENT('Model') + IDENT_INCR('Model')
END
END


CREATE PROCEDURE SpGetTranId
AS
BEGIN
IF (NOT EXISTS (SELECT 1 FROM [Transaction]))
BEGIN
	SELECT IDENT_CURRENT('Transaction')
END
ELSE
BEGIN
    SELECT IDENT_CURRENT('Transaction') + IDENT_INCR('Transaction')
END
END
DECLARE @CompanyId INT = 102
SELECT ModelId,ModelNum FROM Model WHERE CompanyId = @CompanyId
SELECT * FROM Model

INSERT INTO [Transaction] (TransId,ModelId,Quantity,[Date],Amount)VALUES
(@TransactionId,@ModelId,@Quantity,@Date,@Amount)

DELETE FROM Model WHERE ModelId = 204

UPDATE Model 
SET AvailableQty = @Quantity
WHERE ModelId = @ModelId

SELECT * FROM [Transaction]
SELECT * FROM Model

INSERT INTO Mobile ( ModelId, IMEINO, Status, Warranty, Price ) VALUES @ModelId, @IMEINO, @Status, @Warranty, @Price

SELECT * FROM Mobile
SELECT * FROM Model
SELECT * FROM [Transaction]
SELECT * FROM Sales
SELECT * FROM [User]

CREATE PROCEDURE SpGetCustId
AS
BEGIN
IF (NOT EXISTS (SELECT 1 FROM Customer))
BEGIN
	SELECT IDENT_CURRENT('Customer')
END
ELSE
BEGIN
    SELECT IDENT_CURRENT('Customer') + IDENT_INCR('Customer')
END
END

INSERT INTO Customer (CustomerName, MobileNumber, EmailId,[Address]) VALUES (@CustomerName,@MobileNumber,@EmailId,@Address)
INSERT INTO Sales (IMEINO,PurchaseDate,Price,CustomerId) VALUES(@IMEINO,@PurchaseDate,@Price,@CustomerId)

DECLARE @Val INT
SELECT @Val=CustomerId FROM Customer WHERE CustomerName = 'abc' 
PRINT @Val

SELECT * FROM Company
SELECT CompanyName FROM Company WHERE CompanyId = @CompanyId
SELECT ModelNum FROM Model WHERE ModelId = @ModelId
SELECT IMEINO FROM Mobile WHERE ModelId = @ModelId

DECLARE @IMEI NVARCHAR
SELECT @IMEI = IMEINO FROM Mobile WHERE ModelId = 201
SELECT Warranty FROM Mobile WHERE IMEINO=@IMEI

SELECT * FROM Sales
SELECT * FROM Customer
SELECT * FROM Mobile
SELECT * FROM Model

DECLARE @Date DATE
SELECT @Date= GETDATE()
PRINT @Date

UPDATE Mobile
SET [Status] ='Sold'
WHERE IMEINO = @IMEINO

UPDATE Model
SET AvailableQty = AvailableQty - 1
WHERE ModelId = @ModelId

DECLARE @ModelId INT
SELECT @ModelId = ModelId FROM Mobile WHERE IMEINO = 489005732897 
UPDATE Model SET AvailableQty = AvailableQty - 1 WHERE ModelId = @ModelId

SELECT * FROM Model

INSERT INTO [User] (UserName, [Password], EmployeeName, [Address],MobileNumber, Hint, IsAdmin) 
VALUES (@UserName, @Password, @EmployeeName, @Address, @MobileNumber, @Hint, 0)

SELECT * FROM [User]
 
SELECT [Password] FROM [User] WHERE Hint = @Hint AND UserName = @UserName

SELECT  AvailableQty FROM Model WHERE CompanyId = @CompanyId AND ModelId = @ModelId


DECLARE @Id INT
SELECT @Id = CustomerId FROM Sales WHERE IMEINO = @IMEINO
SELECT CustomerName,MobileNumber,EmailId,[Address] FROM Customer WHERE CustomerId = @Id

DELETE FROM Sales WHERE SalesId = '508'
DELETE FROM Customer WHERE CustomerId = '408'

SELECT * FROM Sales
SELECT * FROM Company
SELECT * FROM Model
SELECT * FROM Mobile


SELECT SalesId, CompanyName, Sales.IMEINO, ModelNum, Sales.Price FROM Model 
INNER JOIN Company
ON Model.CompanyId = Company.CompanyId
INNER JOIN Mobile
ON Model.ModelId = Mobile.ModelId
INNER JOIN Sales
ON Mobile.IMEINO = Sales.IMEINO
WHERE PurchaseDate = '2021-06-05'

SELECT SUM(Price) AS Total FROM Sales WHERE PurchaseDate = '2021-06-05'

INSERT INTO Sales (IMEINO, PurchaseDate, Price, CustomerId) 
VALUES('9087654321', '2021-06-05', '20000', 409)

SELECT * FROM Customer

SELECT SalesId, CompanyName, Sales.IMEINO, ModelNum, Sales.Price FROM Model 
INNER JOIN Company
ON Model.CompanyId = Company.CompanyId
INNER JOIN Mobile
ON Model.ModelId = Mobile.ModelId
INNER JOIN Sales
ON Mobile.IMEINO = Sales.IMEINO
WHERE PurchaseDate >=  AND PurchaseDate <= 










