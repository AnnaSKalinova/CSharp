--16
CREATE DATABASE Softuni

USE Softuni

CREATE TABLE Towns(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Addresses(
	Id INT PRIMARY KEY IDENTITY,
	AddressText NVARCHAR(100) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(50),
	LastName NVARCHAR(50) NOT NULL,
	JobTitle NVARCHAR(30) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
	HireDate DATE NOT NULL,
	Salary DECIMAL(7, 2) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)
--18
INSERT INTO Towns([Name])
	VALUES
		('Sofia'),
		('Plovdiv'),
		('Varna'),
		('Burgas')

INSERT INTO Departments([Name])
	VALUES
		('Engineering'),
		('Sales'),
		('Marketing'),
		('Software Developing'),
		('Quality Assurance')

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
	VALUES
		('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '02/01/2013', 3500),
		('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '03/02/2004', 4000),
		('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '08/28/2016', 525.25),
		('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '12/09/2007', 3000),
		('Peter', 'Pan', 'Pan', 'Intern', 3, '08/28/2016', 599.88)
--19
SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees
--20
SELECT * FROM Towns
ORDER BY [Name] ASC

SELECT * FROM Departments
ORDER BY [Name] ASC

SELECT * FROM Employees
ORDER BY Salary DESC
--21
SELECT [Name] FROM Towns
ORDER BY [Name] ASC

SELECT [Name] FROM Departments
ORDER BY [Name] ASC

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC
--22
UPDATE Employees
SET Salary +=  Salary * 0.1

SELECT Salary FROM Employees
--23
UPDATE Payments
SET TaxRate -= TaxRate * 0.03

SELECT TaxRate FROM Payments
--24
TRUNCATE TABLE Occupancies