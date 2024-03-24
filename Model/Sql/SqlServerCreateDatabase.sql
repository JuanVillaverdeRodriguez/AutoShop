


 /******************************************************************************/
 /*** PATH to store the db files. This path must exists in the local system. ***/
 /******************************************************************************/
 DECLARE @Default_DB_Path as VARCHAR(64)  
 SET @Default_DB_Path = N'C:\SourceCode\DataBase\'
 
USE [master]


/***** Drop database if already exists  ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = 'practicamad')
DROP DATABASE [practicamad]


USE [master]


/* DataBase Creation */

	                              
DECLARE @sql nvarchar(500)

SET @sql = 
  N'CREATE DATABASE [practicamad] 
    ON PRIMARY ( NAME = practicamad, FILENAME = "' + @Default_DB_Path + N'practicamad.mdf")
    LOG ON ( NAME = practicamad_log, FILENAME = "' + @Default_DB_Path + N'practicamad.ldf")'

EXEC(@sql)
PRINT N'Database [PracticaMaD] created.'
GO
