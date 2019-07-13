IF DB_ID('Foo') IS NULL
BEGIN
   CREATE DATABASE Foo
END

GO
USE Foo

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Thing'))
BEGIN
    CREATE TABLE Thing (
        ID INT IDENTITY(1,1) PRIMARY KEY,
        [Name] NVARCHAR(100) NOT NULL
    )
    INSERT INTO Thing ([Name]) 
    VALUES
        ('thing1'),
        ('thing2'),
        ('thing3')
END

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'OtherThing'))
BEGIN
    CREATE TABLE OtherThing (
        ID INT IDENTITY(1001,1) PRIMARY KEY,
        ThingID INT,
        [Name] NVARCHAR(100) NOT NULL
    )
    INSERT INTO OtherThing (ThingID, [Name]) 
    VALUES
        (1, 'otherthing1'),
        (3, 'otherthing2')
END
