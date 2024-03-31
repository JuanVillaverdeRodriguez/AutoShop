DECLARE @Default_DB_Path as VARCHAR(64)  
SET @Default_DB_Path = N'C:\SourceCode\DataBase\'
 
USE [master]


/***** Drop database if already exists  ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = 'practicamad_test')
DROP DATABASE [practicamad_test]


USE [master]


/* DataBase Creation */

	                              
DECLARE @sql nvarchar(500)

SET @sql = 
  N'CREATE DATABASE [practicamad_test] 
    ON PRIMARY ( NAME = practicamad_test, FILENAME = "' + @Default_DB_Path + N'practicamad_test.mdf")
    LOG ON ( NAME = practicamad_test_log, FILENAME = "' + @Default_DB_Path + N'practicamad_test.ldf")'

EXEC(@sql)
PRINT N'Database [PracticaMaD_Test] created.'
GO