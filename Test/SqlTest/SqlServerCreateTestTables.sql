USE [practicamad_test]


/* ********** Drop Tables if existing *********** */

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Property]') AND type in ('U'))
DROP TABLE [Property]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Purchase]') AND type in ('U')) 
DROP TABLE [Purchase]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Product]') AND type in ('U'))
DROP TABLE [Product]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Category]') AND type in ('U'))
DROP TABLE [Category]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Card]') AND type in ('U')) 
DROP TABLE [Card]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Usuario]') AND type in ('U'))
DROP TABLE [Usuario]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Workshop]') AND type in ('U')) 
DROP TABLE [Workshop]
GO






/* Create tables */

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
/* igual no hace falta el categoryId */

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

/* Card */

CREATE TABLE Card (
	card_number BIGINT NOT NULL,
	userId BIGINT NOT NULL,
	type varchar(20) NOT NULL,
	csv int NOT NULL,
	expiration_date DATETIME NOT NULL,
	defaultCard BIT NOT NULL,

	CONSTRAINT [PK_Card] PRIMARY KEY (card_number),
	CONSTRAINT [FK_Card_Usuario] FOREIGN KEY (userId) REFERENCES Usuario (userId)
)

PRINT N'Table Card created'
GO

/* Purchase */

CREATE TABLE Purchase (
	purchaseId BIGINT NOT NULL,
	productId BIGINT NOT NULL,
	card_number BIGINT NOT NULL,
	targetPostalCode int NOT NULL,
	prize float NOT NULL,
	quantity int NOT NULL,
	date DATETIME NOT NULL,
	descriptiveName varchar(200) NOT NULL,

	CONSTRAINT [PK_Purchase] PRIMARY KEY (purchaseId, productId),
	CONSTRAINT [FK_Purchase_Product] FOREIGN KEY (productId) REFERENCES Product (productId),
	CONSTRAINT [FK_Purchase_Card] FOREIGN KEY (card_number) REFERENCES Card (card_number)
)

PRINT N'Table Purchase created'
GO

/* Inicializamos la tabla de tests con algunas entradas que se utilizarán al ejecutar las pruebas */

INSERT INTO Workshop(workshop_name, postal_code, country) VALUES ('UDC', 11111, 'ES');

INSERT INTO Card(card_number, userId, type, csv, expiration_date, defaultCard) VALUES (2349234234, 1, 'visa', 777, CONVERT(DATETIME, '30/10/2023 14:30:00', 103), 0);
INSERT INTO Card(card_number, userId, type, csv, expiration_date, defaultCard) VALUES (2349234234, 3, 'visa', 777, CONVERT(DATETIME, '30/10/2023 14:30:00', 103), 1);


INSERT INTO Usuario(alias, user_name, user_surname, password, email, language, workshopId) VALUES ('initialized1', 'init', 'user1', 'password', 'admin@admin.com', 'en', 1);
INSERT INTO Usuario(alias, user_name, user_surname, password, email, language, workshopId) VALUES ('initialized2', 'init', 'user2', 'password', 'admin@admin.com', 'en', 1);
INSERT INTO Usuario(alias, user_name, user_surname, password, email, language, workshopId) VALUES ('initialized3', 'init', 'user3', 'password', 'admin@admin.com', 'en', 1);



INSERT INTO Category(categoryName) VALUES ('Neumaticos');
INSERT INTO Category(categoryName, fatherId) VALUES ('Neumaticos de invierno', 1);

INSERT INTO Product(name, prize, date, stock, categoryId) VALUES ('Pirelli 289', 125, CONVERT(DATETIME, '30/12/2023 19:34:33', 103), 2, 2);
INSERT INTO Product(name, prize, date, stock, categoryId) VALUES ('Firetruck 881', 150, CONVERT(DATETIME, '5/10/2023 11:32:35', 103), 12, 2);
INSERT INTO Product(name, prize, date, stock, categoryId) VALUES ('michelin gcv12', 200, CONVERT(DATETIME, '26/7/2023 17:22:48', 103), 1, 1);