USE Minions
--7
CREATE TABLE People(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Heigth DECIMAL(5, 2),
	[Weight] DECIMAL(5, 2),
	Gender CHAR(1) NOT NULL
		CHECK(Gender = 'f' OR Gender = 'm'),
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People([Name], Heigth, [Weight], Gender, Birthdate, Biography)
	VALUES
		('Pesho', 175, 80, 'm', '05.20.1984', NULL),
		('Gosho', 190, 100, 'm', '03.15.1979', NULL),
		('Yana', 165, 54, 'f', '09.05.1989', NULL),
		('Katya', 169, 58, 'f', '11.10.1991', NULL),
		('Stamat', 181, 92, 'm', '12.01.1995', NULL)
--8
CREATE TABLE Users(
	Id BIGINT PRIMARY KEY IDENTITY NOT NULL,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX)
	CHECK(DATALENGTH(ProfilePicture) <= 900 * 1024),
	LastLoginTime DATETIME2 NOT NULL,
	IsDeleted BIT NOT NULL
)

INSERT Users(Username, [Password], LastLoginTime, IsDeleted)
	VALUES
		('Pesho0', '123456', '05.19.2020', 0),
		('Pesho1', '123456', '05.19.2020', 1),
		('Pesho2', '123456', '05.19.2020', 0),
		('Pesho3', '123456', '05.19.2020', 0),
		('Pesho4', '123456', '05.19.2020', 1)

SELECT * FROM Users

DELETE FROM Users
WHERE Id = 5

SET IDENTITY_INSERT Users ON

INSERT Users(Id, Username, [Password], LastLoginTime, IsDeleted)
	VALUES
		(5, 'Pesho6', '123456', '05.19.2020', 0)

SET IDENTITY_INSERT Users OFF
--9
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07115F57DF

ALTER TABLE Users
ADD CONSTRAINT PK_Users_CompositeIdUsername
PRIMARY KEY(Id, Username)
--10
ALTER TABLE Users
ADD CONSTRAINT CK_Users_PasswordLength
CHECK(LEN([Password]) >= 5)
--11
ALTER TABLE Users
ADD CONSTRAINT DF_Users_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime
--12
ALTER TABLE Users
DROP CONSTRAINT PK_Users_CompositeIdUsername

ALTER TABLE Users
ADD CONSTRAINT PK_Users_Id
PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT CK_Users_UsernameLength
CHECK(LEN(Username) >= 3)




