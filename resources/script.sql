USE StroyMat;

CREATE TABLE People (
    Id INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(100),
    Password NVARCHAR(100),
    Name NVARCHAR(100),
    Surname NVARCHAR(100)
);

CREATE TABLE [Order] (
    Id INT PRIMARY KEY IDENTITY,
    ClientId INT FOREIGN KEY REFERENCES People(Id),
    Name NVARCHAR(100),
    Phone NVARCHAR(20),
    Address NVARCHAR(255)
);

CREATE TABLE Product (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100),
    Category NVARCHAR(100),
    Brand NVARCHAR(100),
    Quantity INT,
    Price DECIMAL(10, 2),
    Photo VARBINARY(MAX),
    Description NVARCHAR(MAX)
);

CREATE TABLE Basket (
    Id INT PRIMARY KEY IDENTITY,
    UserId INT FOREIGN KEY REFERENCES People(Id),
    ProductId INT FOREIGN KEY REFERENCES Product(Id),
    Name NVARCHAR(100),
    Photo VARBINARY(MAX),
    Quantity INT,
    Price DECIMAL(10, 2)
);