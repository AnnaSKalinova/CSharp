--13
CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors(
Id INT PRIMARY KEY,
DirectorName NVARCHAR(50) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Genres(
Id INT PRIMARY KEY,
GenreName NVARCHAR(50) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Categories(
Id INT PRIMARY KEY,
CategoryName NVARCHAR(50) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Movies(
Id INT PRIMARY KEY,
Title NVARCHAR(50) NOT NULL,
DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
CopyrightYear INT,
[Length] INT NOT NULL,
GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
Rating DECIMAL(2,1),
Notes NVARCHAR(MAX)
)

INSERT INTO Directors(Id, DirectorName, Notes)
	VALUES
		(1, 'Pesho', NULL),
		(2, 'Gosho', 'Mnogo hubav film'),
		(3, 'Yana', NULL),
		(4, 'Vanya', NULL),
		(5, 'Stamat', 'Oshte po-hubav film')

INSERT INTO Genres(Id, GenreName, Notes)
	VALUES
		(1, 'Drama', NULL),
		(2, 'Action', 'nqkakvi notes'),
		(3, 'Comedy', NULL),
		(4, 'Fantasy', 'nqkakvi drugi notes'),
		(5, 'Romance', NULL)

INSERT INTO Categories(Id, CategoryName, Notes)
	VALUES	
		(1, '1', NULL),
		(2, '2', NULL),
		(3, '3', NULL),
		(4, '4', NULL),
		(5, '5', NULL)

INSERT INTO Movies(Id, Title, DirectorId, CopyrightYear, 
				[Length], GenreId, CategoryId, Rating, Notes)
	VALUES
		(1, '1', 2, 1985, 120, 3, 4, 5.9, NULL),
		(2, '2', 3, 2015, 135, 1, 2, 6.8, NULL),
		(3, '3', 1, 2009, 141, 5, 3, 8.7, NULL),
		(4, '4', 5, 1978, 115, 4, 1, 6.3, NULL),
		(5, '5', 4, 2000, 160, 2, 5, 7.8, NULL)
