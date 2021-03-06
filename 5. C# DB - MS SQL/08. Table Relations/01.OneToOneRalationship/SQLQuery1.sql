CREATE DATABASE OneToOneRelationship

USE OneToOneRelationship

CREATE TABLE Passports(
PassportID INT NOT NULL, 
PassportNumber CHAR(8)
)

CREATE TABLE Persons(
PersonID INT NOT NULL,
FirstName NVARCHAR(50) NOT NULL,
Salary DECIMAL(7, 2) NOT NULL,
PassportID INT NOT NULL
)

INSERT INTO Passports(PassportID, PassportNumber)
VALUES
(101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2')

INSERT INTO Persons(PersonID, FirstName, Salary, PassportID)
VALUES
(1, 'Roberto', 43300.00, 102),
(2, 'Tom', 56100.00, 103),
(3, 'Yana', 60200.00, 101)

ALTER TABLE Persons
ADD CONSTRAINT PK_PersonID
PRIMARY KEY (PersonID)

ALTER TABLE Passports
ADD CONSTRAINT PK_PassportID
PRIMARY KEY (PassportID)

ALTER TABLE Persons
ADD CONSTRAINT FK_PersonsPassports
FOREIGN KEY (PassportId) REFERENCES Passports(PassportId) 

SELECT * FROM Passports
SELECT * FROM Persons