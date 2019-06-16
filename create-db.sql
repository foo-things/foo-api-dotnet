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
        ('asdf'),
        ('fdsa'),
        ('blah')
END
