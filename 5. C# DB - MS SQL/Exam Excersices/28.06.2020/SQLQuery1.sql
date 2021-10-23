CREATE DATABASE ColonialJourney
USE ColonialJourney
--1
CREATE TABLE Planets(
Id INT IDENTITY PRIMARY KEY,
[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE Spaceports(
Id INT IDENTITY PRIMARY KEY,
[Name] VARCHAR(50) NOT NULL,
PlanetId INT NOT NULL FOREIGN KEY REFERENCES Planets(Id)
)

CREATE TABLE Spaceships(
Id INT IDENTITY PRIMARY KEY,
[Name] VARCHAR(50) NOT NULL,
Manufacturer VARCHAR(30) NOT NULL,
LightSpeedRate INT DEFAULT (0)
)

CREATE TABLE Colonists(
Id INT IDENTITY PRIMARY KEY,
FirstName VARCHAR(20) NOT NULL,
LastName VARCHAR(20) NOT NULL,
Ucn VARCHAR(10) NOT NULL UNIQUE,
BirthDate DATE NOT NULL
)

CREATE TABLE Journeys(
Id INT IDENTITY PRIMARY KEY,
JourneyStart DATETIME2 NOT NULL,
JourneyEnd DATETIME2 NOT NULL,
Purpose VARCHAR(11)
CHECK(Purpose IN 
		('Medical', 'Technical', 'Educational', 'Military')),
DestinationSpaceportId INT NOT NULL
FOREIGN KEY  REFERENCES Spaceports(Id),
SpaceshipId INT NOT NULL
FOREIGN KEY REFERENCES Spaceships(Id)
)

ALTER TABLE Journeys
ADD CONSTRAINT ck_Dates
CHECK (JourneyStart < JourneyEnd)

CREATE TABLE TravelCards(
Id INT IDENTITY PRIMARY KEY,
CardNumber VARCHAR(10) NOT NULL UNIQUE,
JobDuringJourney VARCHAR(8)
CHECK(JobDuringJourney IN 
		('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook')),
ColonistId INT NOT NULL
FOREIGN KEY  REFERENCES Colonists(Id),
JourneyId INT NOT NULL
FOREIGN KEY  REFERENCES Journeys(Id)
)

--2
INSERT INTO Planets([Name])
VALUES
	('Mars'),
	('Earth'),
	('Jupiter'),
	('Saturn')
INSERT INTO Spaceships([Name], Manufacturer, LightSpeedRate)
VALUES
	('Golf', 'VW', 3),
	('WakaWaka', 'Wakanda', 4),
	('Falcon9', 'SpaceX', 1),
	('Bed', 'Vidolov', 6)

--3
SELECT * FROM Spaceships
UPDATE Spaceships
SET LightSpeedRate += 1
WHERE Id BETWEEN 8 AND 12

--4
SELECT * FROM Journeys
DELETE FROM TravelCards
WHERE JourneyId IN (1, 2, 3)

DELETE FROM Journeys
WHERE Id IN (1, 2, 3)

--5
SELECT Id,
	   FORMAT(JourneyStart, 'dd/MM/yyyy'),
	   FORMAT(JourneyEnd, 'dd/MM/yyyy') FROM Journeys
WHERE Purpose = 'Military'
ORDER BY JourneyStart

--6
SELECT c.Id AS id, FirstName + ' ' + LastName AS full_name
FROM Colonists AS c
JOIN TravelCards AS tc ON c.Id = tc.ColonistId
WHERE JobDuringJourney = 'Pilot'
ORDER BY c.Id

--7
SELECT COUNT(c.Id) FROM Colonists AS C
JOIN TravelCards AS tc ON c.Id = tc.ColonistId
JOIN Journeys AS j ON tc.JourneyId = j.Id
WHERE Purpose = 'Technical'

--8
SELECT [Name], Manufacturer
FROM Colonists AS c
JOIN TravelCards tc ON tc.ColonistId = c.id
JOIN Journeys j on tc.JourneyId = j.id
JOIN Spaceships ss on j.SpaceshipId = ss.id
WHERE JobDuringJourney = 'Pilot'
	  AND DATEDIFF(YEAR, c.BirthDate, '01/01/2019') < 30
ORDER BY ss.[Name]

--9
SELECT p.[Name] AS PlanetName,
	   COUNT(j.Id) AS JourneysCount
FROM Planets AS p
JOIN Spaceports AS sp ON p.Id = sp.PlanetId
JOIN Journeys AS j ON sp.Id = j.DestinationSpaceportId
GROUP BY p.[Name]
ORDER BY JourneysCount DESC,
	  p.[Name]

--10
SELECT * FROM(
		SELECT JobDuringJourney,
			c.FirstName + ' ' + c.LastName AS FullName,
			DENSE_RANK()
				OVER(PARTITION BY JobDuringJourney 
				ORDER BY BirthDate)
				AS JobRank
		FROM TravelCards AS tc
		JOIN Colonists AS c ON tc.ColonistId = c.Id) AS ordered
WHERE JobRank = 2

--11
GO
CREATE FUNCTION dbo.udf_GetColonistsCount(@PlanetName VARCHAR (30))
RETURNS INT
AS
BEGIN	
	RETURN(SELECT COUNT(c.Id) FROM Colonists AS c
	JOIN TravelCards AS tc ON tc.ColonistId = c.Id
	JOIN Journeys AS j ON tc.JourneyId = j.Id
	JOIN Spaceports AS sp ON sp.Id = j.DestinationSpaceportId
	JOIN Planets AS p ON sp.PlanetId = p.Id
	WHERE p.[Name] = @PlanetName)
END
GO
SELECT dbo.udf_GetColonistsCount('Otroyphus')

--12
GO
CREATE PROC usp_ChangeJourneyPurpose
		(@JourneyId INT, @NewPurpose VARCHAR(30))
AS
BEGIN
	IF (SELECT Id FROM Journeys
		WHERE Id = @JourneyId) IS NULL
	BEGIN 
		;THROW 51000, 'The journey does not exist!', 1
	END
	IF (SELECT Purpose FROM Journeys
		WHERE Id = @JourneyId) = @NewPurpose
	BEGIN
		;THROW 51000, 'You cannot change the purpose!', 2
	END
	ELSE
	BEGIN
		UPDATE Journeys
			SET Purpose = @NewPurpose
	END
END

EXEC usp_ChangeJourneyPurpose 4, 'Technical'