USE [practicamad]


/* ********** Drops Tables if already existing *********** */

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Property]') AND type in ('U'))
DROP TABLE [Property]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[PurchaseLine]') AND type in ('U')) 
DROP TABLE [PurchaseLine]
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






/*Creates tables*/

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
/*igual no hace falta el categoryId aqui la verdad*/

CREATE TABLE Property (
	productId  bIGINT NOT NULL,
	property_name VARCHAR(80) NOT NULL,
	property_value VARCHAR(80) NOT NULL,

	CONSTRAINT [PK_Property] PRIMARY KEY (productId, property_name),
	CONSTRAINT [FK_Property_Product] FOREIGN KEY (productId) REFERENCES Product (productId),
)

PRINT N'Table Property created.'
GO

/* Workshop */

CREATE TABLE Workshop (
	workshopId bigint IDENTITY(1, 1) NOT NULL,
	workshop_name varchar(30) NOT NULL,
	postal_code int NOT NULL,
	/*Country varchar(2) NOT NULL,*/

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
	country varchar(2) NOT NULL,
	workshopId BIGINT NOT NULL,

	CONSTRAINT [PK_Usuario] PRIMARY KEY (userId),
	CONSTRAINT [FK_Usuario_Workshop] FOREIGN KEY (workshopId) REFERENCES Workshop (workshopId),
	CONSTRAINT [UK_alias] UNIQUE (alias)
)

CREATE NONCLUSTERED INDEX [IX_UserByAlias]
ON [Usuario] ([alias] ASC)

PRINT N'Table Usuario created.'
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
	CONSTRAINT [FK_Card_Usuario] FOREIGN KEY (userId) REFERENCES Usuario (userId),
	CONSTRAINT [UK_card_number] UNIQUE (card_number)
)

PRINT N'Table Card created'
GO

/*Todas las filas de la tabla correspondientes a una misma compra deben tener el mismo purchaseId (una forma de conseguir esto puede ser a la hora de generar un nuevo pedido,
	buscar primero en la tabla el mayor purchaseId que hay, i.e 15 y porner al 16 al nuevo pedido,
	en caso de no haber ningún pedido poner 1 como primer id,
	esto se controla desde el servicio)*/

/*prize y quantity no se corresponden con el precio y stock de la tabla Product
	el prize de la tabla purchase se corresponde con el precio en el momento de la compra, este pudo cambiar con el tiempo
	asi mismo quantity tampoco se corresponde con el stock de la tabla product, aunque al producirse una compra si que se debe reducir el stock del producto comprado en la misma medida que la quantity
	del purchase realizado */

/* Purchase */

CREATE TABLE Purchase (
	purchaseId bigint IDENTITY(1,1) NOT NULL,
	card_number BIGINT NOT NULL,
	targetPostalCode int NOT NULL,
	date DATETIME NOT NULL,
	descriptiveName varchar(200) NOT NULL,
	urgent BIT NOT NULL,

	CONSTRAINT [PK_Purchase] PRIMARY KEY (purchaseId),
	CONSTRAINT [FK_Purchase_Card] FOREIGN KEY (card_number) REFERENCES Card (card_number)
)

PRINT N'Table Purchase created'
GO

CREATE TABLE PurchaseLine (
	purchaseId BIGINT NOT NULL,
	productId BIGINT NOT NULL,
	prize float NOT NULL,
	quantity int NOT NULL,

	CONSTRAINT [PK_PurchaseLine] PRIMARY KEY (purchaseId, productId),
	CONSTRAINT [FK_PurchaseLine_Product] FOREIGN KEY (productId) REFERENCES Product (productId),
	CONSTRAINT [FK_PurchaseLine_Purchase] FOREIGN KEY (purchaseId) REFERENCES Purchase (purchaseId),
)

PRINT N'Table PurchaseLine created'
GO



