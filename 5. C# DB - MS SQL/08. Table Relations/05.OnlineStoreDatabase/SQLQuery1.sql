CREATE DATABASE OnlineStoreDatabase

USE OnlineStoreDatabase

CREATE TABLE ItemTypes(
ItemTypeID INT PRIMARY KEY,
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Items(
ItemID INT PRIMARY KEY,
[Name] VARCHAR(50) NOT NULL,
ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE Cities(
CityID INT PRIMARY KEY,
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Customers(
CustomerID INT PRIMARY KEY,
[Name] VARCHAR(50) NOT NULL,
Birthday DATE NOT NULL,
CityID INT FOREIGN KEY REFERENCES Cities(CityID)
)

CREATE TABLE Orders(
OrderID INT PRIMARY KEY,
CustomerID INT NOT NULL,
)

ALTER TABLE Orders
ADD CONSTRAINT FK_Orders_Customers
FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID)

CREATE TABLE OrderItems(
OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
ItemID INT FOREIGN KEY REFERENCES Items(ItemID),
PRIMARY KEY(OrderID, ItemID)
)