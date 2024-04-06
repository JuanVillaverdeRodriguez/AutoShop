USE [practicamad]

/* ************ Insert data ************ */

INSERT INTO Workshop(workshop_name, postal_code) VALUES ('La Fabrica de Chocolate', 27001);
INSERT INTO Workshop(workshop_name, postal_code) VALUES ('UDC', 15005);

INSERT INTO Usuario(alias, user_name, user_surname, password, email, language, country, workshopId) VALUES ('pelotudo01', 'User1', 'lastName1', 'n4bQgYhMfWWaL+qgxVrQFaO/TxsrC4Is0V1sFbDwCgg=', 'admin@admin.com', 'en', 'ES', 1);
INSERT INTO Usuario(alias, user_name, user_surname, password, email, language, country, workshopId) VALUES ('huevudo02', 'User2', 'lastName2', 'n4bQgYhMfWWaL+qgxVrQFaO/TxsrC4Is0V1sFbDwCgg=', 'test@test.com', 'es',  'UK', 1);
INSERT INTO Usuario(alias, user_name, user_surname, password, email, language, country, workshopId) VALUES ('melocotonero03', 'User3', 'lastName3', 'n4bQgYhMfWWaL+qgxVrQFaO/TxsrC4Is0V1sFbDwCgg=', 'admin@admin.com', 'en',  'ES', 1);
INSERT INTO Usuario(alias, user_name, user_surname, password, email, language, country, workshopId) VALUES ('pelusillo04', 'User4', 'lastName4', 'n4bQgYhMfWWaL+qgxVrQFaO/TxsrC4Is0V1sFbDwCgg=', 'admin@admin.com', 'fr', 'US', 2);
INSERT INTO Usuario(alias, user_name, user_surname, password, email, language, country, workshopId) VALUES ('fritanga05', 'User5', 'lastName5', 'n4bQgYhMfWWaL+qgxVrQFaO/TxsrC4Is0V1sFbDwCgg=', 'admin@admin.com', 'en',  'UG', 2);

INSERT INTO Category(categoryName) VALUES ('Neumaticos');
INSERT INTO Category(categoryName, fatherId) VALUES ('Neumaticos de invierno', 1);

INSERT INTO Card(card_number, userId, type, csv, expiration_date, defaultCard) VALUES (2349234234, 1, 'visa', 777, CONVERT(DATETIME, '30/10/2023 14:30:00', 103), 1);
INSERT INTO Card(card_number, userId, type, csv, expiration_date, defaultCard) VALUES (2349234235, 2, 'mastercard', 888, CONVERT(DATETIME, '30/10/2023 14:30:00', 103), 1);
INSERT INTO Card(card_number, userId, type, csv, expiration_date, defaultCard) VALUES (2349234232, 3, 'visa', 999, CONVERT(DATETIME, '30/10/2023 14:30:00', 103), 1);
INSERT INTO Card(card_number, userId, type, csv, expiration_date, defaultCard) VALUES (2349234239, 4, 'visa', 111, CONVERT(DATETIME, '30/10/2023 14:30:00', 103), 1);
INSERT INTO Card(card_number, userId, type, csv, expiration_date, defaultCard) VALUES (2349234231, 5, 'mastercardd', 222, CONVERT(DATETIME, '30/10/2023 14:30:00', 103), 1);

INSERT INTO Product(name, prize, date, stock, categoryId) VALUES ('Pirelli 289', 125, CONVERT(DATETIME, '30/12/2023 19:34:33', 103), 2, 2);
INSERT INTO Product(name, prize, date, stock, categoryId) VALUES ('Firetruck 881', 150, CONVERT(DATETIME, '5/10/2023 11:32:35', 103), 12, 2);
INSERT INTO Product(name, prize, date, stock, categoryId) VALUES ('michelin gcv12', 200, CONVERT(DATETIME, '26/7/2023 17:22:48', 103), 1, 1);

INSERT INTO Property(productId, property_name, property_value) VALUES (1, 'diametro', '25 cm');
INSERT INTO Property(productId, property_name, property_value) VALUES (1, 'grosor', 'bien gordo');
INSERT INTO Property(productId, property_name, property_value) VALUES (2, 'diametro', '30 cm');
INSERT INTO Property(productId, property_name, property_value) VALUES (2, 'grosor', 'no tan gordo');
INSERT INTO Property(productId, property_name, property_value) VALUES (3, 'diametro', '35 cm');
INSERT INTO Property(productId, property_name, property_value) VALUES (3, 'grosor', 'finito');

INSERT INTO Purchase(card_number, targetPostalCode, date, descriptiveName, urgent) VALUES (2349234234, 36121, CONVERT(DATETIME, '7/10/2023 14:30:00', 103), 'default description1', 1);
INSERT INTO Purchase(card_number, targetPostalCode, date, descriptiveName, urgent) VALUES (2349234234, 36121, CONVERT(DATETIME, '9/10/2023 14:39:30', 103), 'default description2', 0);

INSERT INTO PurchaseLine(purchaseId, productId, prize, quantity) VALUES (1, 2, 12, 2);
INSERT INTO PurchaseLine(purchaseId, productId, prize, quantity) VALUES (1, 3, 12, 2);
INSERT INTO PurchaseLine(purchaseId, productId, prize, quantity) VALUES (2, 1, 10, 2);