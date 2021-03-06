--14
CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories
(
Id INT NOT NULL IDENTITY PRIMARY KEY,
Category NVARCHAR(100) NOT NULL,
DailyRate DECIMAL NOT NULL,
WeeklyRate DECIMAL NOT NULL,
MonthlyRate DECIMAL NOT NULL,
WeekendRate DECIMAL NOT NULL
)
 
CREATE TABLE Cars
(
Id INT NOT NULL IDENTITY PRIMARY KEY,
PlateNumber NVARCHAR(15) NOT NULL,
Make NVARCHAR(100) NOT NULL,
Model NVARCHAR(100) NOT NULL,
CarYear DATE NOT NULL,
CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
Doors INT NOT NULL,
Picture VARBINARY(MAX),
Condition NVARCHAR(MAX),
Available BIT NOT NULL
)
 
CREATE TABLE Employees
(
Id INT NOT NULL IDENTITY PRIMARY KEY,
FirstName NVARCHAR(100) NOT NULL,
LastName NVARCHAR(100) NOT NULL,
Title NVARCHAR(50),
Notes NVARCHAR(MAX)
)
 
CREATE TABLE Customers
(
Id INT NOT NULL IDENTITY PRIMARY KEY,
DriverLicenceNumber NVARCHAR(30) NOT NULL UNIQUE,
FullName NVARCHAR(200) NOT NULL,
[Address] NVARCHAR(MAX) NOT NULL,
City NVARCHAR(100) NOT NULL,
ZIPCode INT NOT NULL,
Notes NVARCHAR(MAX)
)
 
CREATE TABLE RentalOrders
(
Id INT NOT NULL IDENTITY PRIMARY KEY,
EmployeeId INT NOT NULL,
CONSTRAINT FK_RentalOrders_Employees FOREIGN KEY (EmployeeId) REFERENCES Employees (Id),
CustomerId INT NOT NULL,
CONSTRAINT FK_RentalOrders_Customers FOREIGN KEY (CustomerId) REFERENCES Customers (Id),
CarId INT NOT NULL,
CONSTRAINT FK_RentalOrders_Cars FOREIGN KEY (CarId) REFERENCES Cars (Id),
TankLevel NVARCHAR(100) NOT NULL,
KilometrageStart INT NOT NULL,
KilometrageEnd INT NOT NULL,
CONSTRAINT chk_Kilometers
CHECK (KilometrageEnd >= KilometrageStart),
TotalKilometrage INT NOT NULL,
StartDate DATE NOT NULL,
EndDate DATE NOT NULL,
CONSTRAINT chk_Date
CHECK (EndDate >= StartDate),
TotalDays INT NOT NULL,
RateApplied DECIMAL NOT NULL,
TaxRate DECIMAL NOT NULL,
OrderStatus NVARCHAR(200) NOT NULL,
Notes NVARCHAR(MAX)
)
 
 
INSERT Categories
(Category, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES
('Cheap', 10.50, 70, 220.20, 20),
('Budget', 15.50, 100, 250.20, 30),
('Lux', 40, 200, 500, 100)
 
INSERT Cars
(PlateNumber, Make, Model, CarYear, CategoryId, Doors, Condition, Available)
VALUES
('CA1010BA', 'Opel', 'Vectra', '2000-11-24', 1, 4, 'Good', 1),
('CA2020BA', 'Ford', 'Fiesta', '2000-11-24', 2, 4, 'Good', 1),
('CA3030BA', 'Tesla', 'Model S', '2016-11-24', 3, 4, 'New', 1)
INSERT Employees
( FirstName, LastName, Title, Notes)
VALUES
( 'Sange', 'Hindululu', 'Mr', 'Cheap Labor'),
( 'Ivan', 'Ivanov', 'Sir', 'Crazy'),
( 'Penka', 'Teslova', 'Ms', 'Cool name')
 
INSERT Customers
(DriverLicenceNumber, FullName, [Address], City, ZIPCode)
VALUES
('ZZA46656', 'Ivan Vankov', 'Gorno Nadolnishe', 'Kichuka', 1000),
('ZZA43236', 'Petar Vankov', 'Sredno Nadolnishe', 'Kichuka', 1001),
('ZZA45466', 'Gosho Vankov', 'Dolno Nadolnishe', 'Kichuka', 1002)
 
INSERT RentalOrders
(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
VALUES
(1, 2, 3, 'full', 100, 200, 100, '2017-01-17', '2017-01-19', 1, 10.0, 10.0, 'confirmed', 'None'),
(1, 2, 3, 'full', 100, 200, 100, '2017-01-17', '2017-01-18', 1, 10.0, 10.0, 'on hold', 'None'),
(1, 2, 3, 'not full', 100, 200, 100, '2017-01-17', '2017-01-25', 1, 10.0, 10.0, 'not confirmed', 'None')

