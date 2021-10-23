USE SoftUni
--1
SELECT TOP(5) EmployeeID, JobTitle, e.AddressID, a.AddressText
FROM Employees e
	JOIN Addresses a ON E.AddressID = A.AddressID
ORDER BY a.AddressID
--2
SELECT TOP(50) FirstName, LastName, t.Name, a.AddressText 
FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName
--3
SELECT EmployeeID, FirstName, LastName, d.Name AS 'DepartmentName'
FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY EmployeeID
--4
SELECT TOP(5) EmployeeID, FirstName, Salary, d.Name AS 'DepartmentName'
FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE Salary > 15000
ORDER BY d.DepartmentID
--5
SELECT TOP(3) e.EmployeeID, FirstName
FROM Employees AS e
	LEFT JOIN EmployeesProjects AS ep ON E.EmployeeID = EP.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY EmployeeID
--6
SELECT FirstName, LastName, HireDate, d.Name AS DeptName
FROM Employees AS e
	JOIN Departments AS	d ON E.DepartmentID = d.DepartmentID
WHERE HireDate > '1999-01-01'
	AND d.Name IN ('Sales', 'Finance')
ORDER BY e.HireDate
--7
SELECT TOP(5) e.EmployeeID, FirstName, p.Name
FROM Employees AS e
	JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
	JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE StartDate > 2002-08-13 AND EndDate IS NULL
ORDER BY e.EmployeeID
--8
SELECT e.EmployeeID,
		FirstName,
		CASE 
			WHEN DATEPART(YEAR, StartDate) >= 2005
			THEN NULL
			ELSE P.Name
		END
FROM Employees AS e
	JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
	JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24
--9
SELECT e.EmployeeID, e.FirstName, e.ManagerID, m.FirstName AS 'ManagerName'
FROM Employees AS e
	JOIN Employees AS m on e.ManagerID = m.EmployeeID
WHERE e.ManagerID IN (3, 7)
ORDER BY e.EmployeeID
--10
SELECT TOP(50)
	e.EmployeeID,
	CONCAT(e.FirstName, ' ', e.LastName),
	CONCAT(m.FirstName, ' ', m.LastName) AS 'ManagerName',
	d.Name
FROM Employees AS e
	JOIN Employees AS m ON e.ManagerID = m.EmployeeID
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY EmployeeID
--11
SELECT TOP(1) AVG(Salary) FROM Employees
GROUP BY DepartmentID
ORDER BY AVG(Salary) 

USE Geography
--12
SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation
FROM Peaks AS p
	JOIN MountainsCountries AS mc ON p.MountainId = mc.MountainId
	JOIN Mountains AS m ON mc.MountainId = m.Id
WHERE mc.CountryCode = 'BG'
	AND p.Elevation > 2835
ORDER BY p.Elevation DESC
--13
SELECT mc.CountryCode, COUNT(m.MountainRange)
FROM MountainsCountries AS mc
	JOIN Mountains AS m ON MC.MountainId = M.Id
GROUP BY mc.CountryCode
HAVING mc.CountryCode IN('BG', 'US', 'RU')
--14
SELECT TOP(5) c.CountryName, r.RiverName
FROM Countries AS c
	LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName
--15
SELECT ranked.ContinentCode,
       ranked.CurrencyCode,
       ranked.CurrencyUsage
FROM
(
    SELECT gbc.ContinentCode,
           gbc.CurrencyCode,
           gbc.CurrencyUsage,
           DENSE_RANK() OVER(PARTITION BY gbc.ContinentCode ORDER BY gbc.CurrencyUsage DESC) AS UsageRank
    FROM
    (
        SELECT ContinentCode,
               CurrencyCode,
               COUNT(CurrencyCode) AS CurrencyUsage
        FROM Countries
        GROUP BY ContinentCode,
                 CurrencyCode
        HAVING COUNT(CurrencyCode) > 1
    ) AS gbc
) AS ranked
WHERE ranked.UsageRank = 1
ORDER BY ranked.ContinentCode
--16
SELECT COUNT(c.CountryName)
FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
WHERE mc.CountryCode IS NULL
--17
SELECT TOP(5) 
	Max.CountryName, 
	Max.HighestPeakElevation, 
	Max.LongestRiverLength
FROM
	(SELECT CountryName, 
	MAX(p.Elevation) AS HighestPeakElevation, 
	MAX(r.Length) AS LongestRiverLength
	FROM Countries AS c
		LEFT JOIN MountainsCountries AS mc ON C.CountryCode = MC.CountryCode
		LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
		LEFT JOIN Peaks AS p ON m.Id = p.MountainId
		LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
		LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
	GROUP BY c.CountryName) AS [MAX]
ORDER BY Max.HighestPeakElevation DESC, 
		 Max.LongestRiverLength DESC, 
		 Max.CountryName DESC
--18
SELECT TOP (5) WITH TIES c.CountryName,
		ISNULL(p.PeakName, '(no highest peak)') 
		AS 'HighestPeakName',
		ISNULL(MAX(p.Elevation), 0)
		AS 'HighestPeakElevation',
		ISNULL(m.MountainRange, '(no mountain)')
		AS 'Mountain'
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
LEFT JOIN Peaks AS p ON m.Id = p.MountainId
GROUP BY c.CountryName, p.PeakName, m.MountainRange
ORDER BY c.CountryName, p.PeakName