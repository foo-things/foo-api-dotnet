CREATE DATABASE Foo
GO
USE Foo

CREATE TABLE Thing (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL
)
INSERT INTO Thing ([Name]) 
VALUES
    ('asdf'),
    ('fdsa'),
    ('blah')
