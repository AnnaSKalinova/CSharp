CREATE DATABASE DateFunctions
USE DateFunctions
--18
SELECT ProductName, OrderDate,
		DATEADD(DAY, 3, OrderDate) AS 'Pay Due',
		DATEADD(MONTH, 1, OrderDate) AS 'Deliver Due'
FROM Orders
--19
CREATE TABLE People (
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL,
Birthdate DATETIME2 NOT NULL
)

INSERT INTO People
VALUES
('Victor', '2000-12-07 00:00:00.000'),
('Steven', '1992-09-10 00:00:00.000'),
('Stephen', '21910-09-19 00:00:00.000'),
('John', '2010-01-06 00:00:00.000')

SELECT * FROM People
