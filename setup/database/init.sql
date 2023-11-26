USE master
GO

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'MyTestDataBase')
BEGIN
  CREATE DATABASE MyTestDataBase;
END;
GO

USE MyTestDataBase;
GO
