USE SoftUni
GO
--1
CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
	SELECT FirstName, LastName
	FROM Employees
WHERE Salary > 35000
EXEC usp_GetEmployeesSalaryAbove35000
GO
--2
CREATE PROC usp_GetEmployeesSalaryAboveNumber(@minSalary DECIMAL(18,4))
AS
	SELECT FirstName, LastName
	FROM Employees
WHERE Salary >= @minSalary
EXEC usp_GetEmployeesSalaryAboveNumber 48100
GO
--3
CREATE PROC usp_GetTownsStartingWith(@start VARCHAR(50))
AS
	SELECT [Name]
	FROM Towns
WHERE LEFT([Name], LEN(@start)) = @start
EXEC usp_GetTownsStartingWith 'b'
GO
--4
CREATE PROC usp_GetEmployeesFromTown(@townName NVARCHAR(50))
AS
	SELECT FirstName, LastName
	FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	JOIN Towns AS t ON a.TownID = t.TownID
WHERE t.Name = @townName
EXEC usp_GetEmployeesFromTown 'Sofia'
GO
--5
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS NVARCHAR(10) AS
BEGIN
	DECLARE @SalaryLevel VARCHAR(10)
	IF(@salary < 30000)
	BEGIN
		SET @SalaryLevel = 'Low'
	END
	ELSE IF(@salary BETWEEN 30000 AND 50000)
	BEGIN
		SET @SalaryLevel = 'Average'
	END
	ELSE IF (@salary > 50000)
	BEGIN
		SET @SalaryLevel = 'High'
	END
RETURN @SalaryLevel
END
GO
SELECT Salary, dbo.ufn_GetSalaryLevel(Salary)
FROM Employees
GO
--6
CREATE PROC usp_EmployeesBySalaryLevel(@salaryLevel VARCHAR(10))
AS
BEGIN
	SELECT FirstName, LastName
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel
END
EXEC usp_EmployeesBySalaryLevel 'high'
GO
--7
CREATE FUNCTION ufn_IsWordComprised
	(@setOfLetters NVARCHAR(10), @word NVARCHAR(50))
RETURNS BIT AS
BEGIN
	DECLARE @currentIndex INT = 1
	WHILE(@currentIndex <= LEN(@word))
		BEGIN
			DECLARE @currentLetter VARCHAR(1) = SUBSTRING(@word, @currentIndex, 1)
			IF(CHARINDEX(@currentLetter, @setOfLetters)) = 0
				BEGIN
				RETURN 0;
				END
		SET @currentIndex += 1;
		END
RETURN 1
END
GO
--8
CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (
				SELECT EmployeeID FROM Employees
				WHERE DepartmentID = @departmentId)
	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (
				SELECT EmployeeID FROM Employees
				WHERE DepartmentID = @departmentId)
	ALTER TABLE Departments
	ALTER COLUMN ManagerId INT
	UPDATE Departments
	SET ManagerID = NULL
	WHERE ManagerID IN (
				SELECT EmployeeID FROM Employees
				WHERE DepartmentID = @departmentId)
	DELETE FROM Employees
	WHERE DepartmentID = @departmentId

	DELETE FROM Departments
	WHERE DepartmentID = @departmentId

	SELECT COUNT(*) FROM Employees
	WHERE DepartmentID = @departmentId
END

EXEC usp_DeleteEmployeesFromDepartment 1
GO
--9
USE Bank
GO
CREATE PROC usp_GetHoldersFullName
AS
BEGIN
	SELECT FirstName + ' ' + LastName AS FullName
	FROM AccountHolders
END
GO
--10
CREATE PROC usp_GetHoldersWithBalanceHigherThan(@givenBalance DECIMAL(13,2))
AS
BEGIN
	SELECT ah.FirstName, ah.LastName
	FROM AccountHolders AS ah
	JOIN Accounts AS a ON ah.Id = a.AccountHolderId
	GROUP BY ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @givenBalance
	ORDER BY ah.FirstName, ah.LastName 
END
EXEC usp_GetHoldersWithBalanceHigherThan 1000
GO
--11
CREATE FUNCTION ufn_CalculateFutureValue
								(@sum DECIMAL(13,2),
								@yearlyInterestRate FLOAT,
								@numberOfYears INT)
RETURNS MONEY AS 
BEGIN
RETURN @sum * (POWER((1 + @yearlyInterestRate), @numberOfYears))
END
GO
SELECT dbo.ufn_CalculateFutureValue(1000, 0.10, 5)
--12
GO
CREATE PROC usp_CalculateFutureValueForAccount
						(@accountId INT, @interestRate AS FLOAT)
AS
BEGIN
	SELECT a.Id, 
		   ah.FirstName, 
		   ah.LastName, 
		   a.Balance, 
		   dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5)
	FROM AccountHolders AS ah
	JOIN Accounts A on ah.Id = a.AccountHolderId
	WHERE A.Id = @accountId
END
EXEC usp_CalculateFutureValueForAccount 1, 0.1
GO
--13
USE Diablo
GO
CREATE FUNCTION ufn_CashInUsersGames(@gameName varchar(max))
RETURNS @returnedTable TABLE
(
SumCash money
)
AS
BEGIN
	DECLARE @result MONEY

	SET @result = 
	(SELECT SUM(ug.Cash) AS Cash
	FROM
		(SELECT Cash, GameId, ROW_NUMBER() OVER (ORDER BY Cash DESC) AS RowNumber
		FROM UsersGames
		WHERE GameId = (SELECT Id FROM Games WHERE Name = @gameName)
		) AS ug
	WHERE ug.RowNumber % 2 != 0
	)

	INSERT INTO @returnedTable SELECT @result
	RETURN
END