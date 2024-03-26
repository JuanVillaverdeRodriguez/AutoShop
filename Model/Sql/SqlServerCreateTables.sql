/* 
 * SQL Server Script
 * 
 * This script can be directly executed to configure the test database from
 * PCs located at CECAFI Lab. The database and the corresponding users are 
 * already created in the sql server, so it will create the tables needed 
 * in the samples. 
 * 
 * In a local environment (for example, with the SQLServerExpress instance 
 * included in the VStudio installation) it will be necessary to create the 
 * database and the user required by the connection string. So, the following
 * steps are needed:
 *
 *      Configure within the CREATE DATABASE sql-sentence the path where 
 *      database and log files will be created  
 *
 * This script can be executed from MS Sql Server Management Studio Express,
 * but also it is possible to use a command Line syntax:
 *
 *    > sqlcmd.exe -U [user] -P [password] -I -i SqlServerCreateTables.sql
 *
 */

 
USE [practicamad]


/* ********** Drop Table Property if already exists *********** */

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Property]') AND type in ('U'))
DROP TABLE [Property]
GO



/* ********** Drop Table Product if already exists *********** */

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Product]') AND type in ('U'))
DROP TABLE [Product]
GO

/* ********** Drop Table Category if already exists *********** */

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Category]') AND type in ('U'))
DROP TABLE [Category]
GO

/* ********** Drop Table Cardd if already exists *********** */

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Card]') AND type in ('U')) 
DROP TABLE [Card]
GO

/* ********** Drop Table User if already exists *********** */


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Usuario]') AND type in ('U'))
DROP TABLE [Usuario]
GO


/* ********** Drop Table Workshop if already exists *********** */

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Workshop]') AND type in ('U')) 
DROP TABLE [Workshop]
GO








/*  Category */

CREATE TABLE Category (
	categoryId bigint IDENTITY(1,1) NOT NULL,
	categoryName varchar(30) NOT NULL,
	fatherId BIGINT,

	CONSTRAINT [PK_Category] PRIMARY KEY (categoryId),
	CONSTRAINT [FK_Category_Category] FOREIGN KEY (fatherId) REFERENCES Category (categoryId),
	CONSTRAINT [UK_CategoryName] UNIQUE (categoryName)
)


PRINT N'Table Category created.'
GO

/* Product */

CREATE TABLE Product(
	productId bigint IDENTITY(1,1) NOT NULL,
	name varchar(80) NOT NULL,
	prize float NOT NULL,
	date DATETIME NOT NULL,
	stock int NOT NULL,
	categoryId BIGINT NOT NULL,

	CONSTRAINT [PK_Product] PRIMARY KEY (productId),
	CONSTRAINT [FK_Product_Category] FOREIGN KEY (categoryId) REFERENCES Category (categoryId)

)

PRINT N'Table Product created.'
GO

/* Property */
/*la primera linea no estoy muy seguro, la PK serían productId y name, igual no hace falta el categoryId aqui la verdad*/

CREATE TABLE Property (
	productId  bIGINT NOT NULL,
	property_name VARCHAR(80) NOT NULL,
	property_value VARCHAR(80) NOT NULL,
	categoryId BIGINT NOT NULL,

	CONSTRAINT [PK_Property] PRIMARY KEY (productId, property_name),
	CONSTRAINT [FK_Property_Product] FOREIGN KEY (productId) REFERENCES Product (productId),
	CONSTRAINT [FK_Property_Category] FOREIGN KEY (categoryId) REFERENCES Category (categoryId) 

)

PRINT N'Table Property created.'
GO

/* Workshop */

CREATE TABLE Workshop (
	workshopId bigint IDENTITY(1, 1) NOT NULL,
	workshop_name varchar(30) NOT NULL,
	postal_code int NOT NULL,
	Country varchar(2) NOT NULL,

	CONSTRAINT [PK_Workshop] PRIMARY KEY (workshopId)
)

PRINT N'Table Workshop created.'
GO

GO


/*  User */

CREATE TABLE Usuario (
	userId bigint IDENTITY(1,1) NOT NULL,
	user_name varchar(30) NOT NULL,
	user_surname varchar(30) NOT NULL,
	email varchar(80) NOT NULL,
	alias varchar(30) NOT NULL,
	password varchar(50) NOT NULL,
	language varchar(2),
	workshopId BIGINT NOT NULL,

	CONSTRAINT [PK_Usuario] PRIMARY KEY (userId),
	CONSTRAINT [FK_Usuario_Workshop] FOREIGN KEY (workshopId) REFERENCES Workshop (workshopId),
	CONSTRAINT [UK_alias] UNIQUE (alias)
)

CREATE NONCLUSTERED INDEX [IX_UserByAlias]
ON [Usuario] ([alias] ASC)

PRINT N'Table User created.'
GO

/* Card aqui creo que el card number tampoco esta bien?? */

CREATE TABLE Card (
	card_number bigint IDENTITY(1, 1) NOT NULL,
	userId BIGINT NOT NULL,
	type varchar(20) NOT NULL,
	csv int NOT NULL,
	expiration_date DATETIME NOT NULL,

	CONSTRAINT [PK_Card] PRIMARY KEY (card_number),
	CONSTRAINT [FK_Card_Usuario] FOREIGN KEY (userId) REFERENCES Usuario (userId)
)

PRINT N'Table Card created'
GO




/* ************ Insert data into tables ************ */

INSERT INTO Workshop(workshop_name, postal_code, country) VALUES ('La Fabrica de Chocolate', 27001, 'ES');
INSERT INTO Workshop(workshop_name, postal_code, country) VALUES ('UDC', 15005, 'ES');

INSERT INTO Usuario(alias, user_name, user_surname, password, email, language, workshopId) VALUES ('pelotudo01', 'User1', 'lastName1', 'n4bQgYhMfWWaL+qgxVrQFaO/TxsrC4Is0V1sFbDwCgg=', 'admin@admin.com', 'en', 1);
INSERT INTO Usuario(alias, user_name, user_surname, password, email, language, workshopId) VALUES ('huevudo02', 'User2', 'lastName2', 'n4bQgYhMfWWaL+qgxVrQFaO/TxsrC4Is0V1sFbDwCgg=', 'test@test.com', 'es', 1);
INSERT INTO Usuario(alias, user_name, user_surname, password, email, language, workshopId) VALUES ('melocotonero03', 'User3', 'lastName3', 'n4bQgYhMfWWaL+qgxVrQFaO/TxsrC4Is0V1sFbDwCgg=', 'admin@admin.com', 'en', 1);
INSERT INTO Usuario(alias, user_name, user_surname, password, email, language, workshopId) VALUES ('pelusillo04', 'User4', 'lastName4', 'n4bQgYhMfWWaL+qgxVrQFaO/TxsrC4Is0V1sFbDwCgg=', 'admin@admin.com', 'fr', 2);
INSERT INTO Usuario(alias, user_name, user_surname, password, email, language, workshopId) VALUES ('fritanga05', 'User5', 'lastName5', 'n4bQgYhMfWWaL+qgxVrQFaO/TxsrC4Is0V1sFbDwCgg=', 'admin@admin.com', 'en', 2);


INSERT INTO Category(categoryName) VALUES ('Neumaticos');
INSERT INTO Category(categoryName, fatherId) VALUES ('Neumaticos de invierno', 1);


INSERT INTO Card(userId, type, csv, expiration_date) VALUES (1, 'visa', 777, CONVERT(DATETIME, '30/10/2023 14:30:00', 103));
INSERT INTO Card(userId, type, csv, expiration_date) VALUES (2, 'mastercard', 888, CONVERT(DATETIME, '30/10/2023 14:30:00', 103));
INSERT INTO Card(userId, type, csv, expiration_date) VALUES (3, 'visa', 999, CONVERT(DATETIME, '30/10/2023 14:30:00', 103));
INSERT INTO Card(userId, type, csv, expiration_date) VALUES (4, 'visa', 111, CONVERT(DATETIME, '30/10/2023 14:30:00', 103));
INSERT INTO Card(userId, type, csv, expiration_date) VALUES (5, 'mastercardd', 222, CONVERT(DATETIME, '30/10/2023 14:30:00', 103));


INSERT INTO Product(name, prize, date, stock, categoryId) VALUES ('Pirelli 289', 125, CONVERT(DATETIME, '30/10/2023 14:30:00', 103), 2, 2);
INSERT INTO Product(name, prize, date, stock, categoryId) VALUES ('Firetruck 881', 150, CONVERT(DATETIME, '30/10/2023 14:30:00', 103), 12, 2);
INSERT INTO Product(name, prize, date, stock, categoryId) VALUES ('michelin gcv12', 200, CONVERT(DATETIME, '30/10/2023 14:30:00', 103), 1, 1);


INSERT INTO Property(productId, property_name, property_value, categoryId) VALUES (1, 'diametro', '25 cm', 2);
INSERT INTO Property(productId, property_name, property_value, categoryId) VALUES (1, 'grosor', 'bien gordo', 2);
INSERT INTO Property(productId, property_name, property_value, categoryId) VALUES (2, 'diametro', '30 cm', 2);
INSERT INTO Property(productId, property_name, property_value, categoryId) VALUES (2, 'grosor', 'no tan gordo', 2);
INSERT INTO Property(productId, property_name, property_value, categoryId) VALUES (3, 'diametro', '35 cm', 1);
INSERT INTO Property(productId, property_name, property_value, categoryId) VALUES (3, 'grosor', 'finito', 1);