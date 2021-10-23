USE SoftUni
--1
SELECT FirstName, LastName FROM Employees
WHERE FirstName LIKE('SA%')
--2
SELECT FirstName, LastName FROM Employees
WHERE LastName LIKE('%ei%')
--3
SELECT FirstName FROM Employees
WHERE DepartmentID = 3 OR DepartmentID = 10 
	AND DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005
--4
SELECT FirstName, LastName FROM Employees
WHERE JobTitle NOT LIKE('%engineer%')
--5
SELECT [Name] FROM Towns
WHERE LEN([Name]) = 5 OR LEN([Name]) = 6
ORDER BY [Name]
--6
SELECT * FROM Towns
WHERE LEFT([Name], 1) LIKE '[M,K,B,E]'
ORDER BY [Name]
--7
SELECT * FROM Towns
WHERE LEFT([Name], 1) NOT LIKE '[R,B,D]' 
ORDER BY [Name]
--8
GO
CREATE VIEW V_EmployeesHiredAfter2000
AS
SELECT FirstName, LastName FROM Employees
WHERE DATEPART(YEAR, HireDate) > 2000
--9
SELECT FirstName, LastName FROM Employees
WHERE LEN(LastName) = 5
--10
SELECT EmployeeID, FirstName, LastName, Salary, 
		DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID)
	FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC
--11
SELECT * 
FROM(
	 SELECT EmployeeID, FirstName, LastName, Salary, 
		RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
	 FROM Employees
	 WHERE Salary BETWEEN 10000 AND 50000) AS RankOrderd
WHERE [Rank] = 2
ORDER BY Salary DESC

