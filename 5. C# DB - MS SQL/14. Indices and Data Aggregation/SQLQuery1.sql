USE Gringotts
--1
SELECT COUNT(*) AS Count
FROM WizzardDeposits
--2
SELECT MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits
--3
SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits
GROUP BY DepositGroup
--4
SELECT TOP(2) DepositGroup 
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)
--5
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
GROUP BY DepositGroup
--6
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
--7
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC
--8
SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup
--9
SELECT 
	CASE 
		WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
		WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
		WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
		WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
		WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
		WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
		WHEN Age >= 61 THEN '[61+]'
	END AS AgeGroup,
	COUNT(*) AS WizardCount
FROM WizzardDeposits
GROUP BY 
	CASE
		WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
		WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
		WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
		WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
		WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
		WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
		WHEN Age >= 61 THEN '[61+]'
	END
--10
SELECT LEFT(FirstName, 1) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1)
ORDER BY FirstLetter
--11
SELECT DepositGroup,
	   IsDepositExpired,
	   AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate >= '1985-01-01'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired
--12
SELECT
	   SUM(ResultTable.[Difference]) AS SumDifference
FROM
	(SELECT DepositAmount - 
		(SELECT DepositAmount 
		 FROM WizzardDeposits 
		 WHERE Id = wd.Id + 1) 
		AS [Difference] 
	FROM WizzardDeposits AS wd)
	AS ResultTable
USE SoftUni
--13
SELECT DepartmentID, SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID
--14
SELECT DepartmentID, MIN(Salary) AS MinimumSalary
FROM Employees
WHERE HireDate > '2000-01-01'
GROUP BY DepartmentID
HAVING DepartmentID IN (2, 5, 7)
--15
SELECT *
  INTO NewTable
  FROM Employees
 WHERE Salary > 30000;

DELETE FROM NewTable
 WHERE ManagerID = 42
 
UPDATE NewTable
SET Salary += 5000
WHERE DepartmentId =1 

SELECT DepartmentID, AVG(Salary) AS [AverageSalary]
  FROM NewTable
 GROUP BY DepartmentID
--16
SELECT DepartmentID, MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000
--17
SELECT COUNT(*) AS [Count]
FROM Employees
WHERE ManagerID IS NULL