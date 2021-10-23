---1
CREATE DATABASE Minions
USE Minions
--2
CREATE TABLE Minions(
	Id INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	Age TINYINT
)

CREATE TABLE Towns(
	Id INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
)
--3
ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)
--4
INSERT INTO Towns(Id, [Name])
	VALUES
			(1, 'Sofia'),
			(2, 'Plovdiv'),
			(3, 'Varna')

INSERT INTO Minions(Id, [Name], Age, TownId)
	VALUES
			(1, 'Kevin', 22, 1),
			(2, 'Bob', 15, 3),
			(3, 'Steward', NULL, 2)
--5
TRUNCATE TABLE Minions
--6
DROP TABLE Minions
DROP TABLE Towns
