USE [practicamad]

/* ************ Insert data ************ */

INSERT INTO Workshop(workshop_name, postal_code) VALUES ('USC', 27001);
INSERT INTO Workshop(workshop_name, postal_code) VALUES ('UDC', 15005);

INSERT INTO Usuario(alias, user_name, user_surname, password, email, language, country, workshopId) VALUES ('Raul', 'User1', 'lastName1', '1234', 'juan@admin.com', 'en', 'ES', 1);
INSERT INTO Usuario(alias, user_name, user_surname, password, email, language, country, workshopId) VALUES ('David', 'User2', 'lastName2', '1234', 'pablo@test.com', 'es',  'UK', 1);
INSERT INTO Usuario(alias, user_name, user_surname, password, email, language, country, workshopId) VALUES ('Ana', 'User3', 'lastName3', '1234', 'pedro@esteno.com', 'en',  'ES', 1);
INSERT INTO Usuario(alias, user_name, user_surname, password, email, language, country, workshopId) VALUES ('Alberto', 'User4', 'lastName4', '1234', 'siadmin@admin.com', 'fr', 'US', 2);
INSERT INTO Usuario(alias, user_name, user_surname, password, email, language, country, workshopId) VALUES ('Guillermo', 'User5', 'lastName5', '1234', 'noadmin@admin.com', 'en',  'UG', 2);

INSERT INTO Category(categoryName) VALUES ('Neumaticos');
INSERT INTO Category(categoryName, fatherId) VALUES ('Neumaticos de invierno', 1);
INSERT INTO Category(categoryName) VALUES ('Filtros de aceite');


INSERT INTO Card(card_number, userId, type, csv, expiration_date, defaultCard) VALUES (2349234234, 1, 'visa', 777, CONVERT(DATETIME, '30/10/2023 14:30:00', 103), 1);
INSERT INTO Card(card_number, userId, type, csv, expiration_date, defaultCard) VALUES (2349234235, 2, 'mastercard', 888, CONVERT(DATETIME, '30/10/2023 14:30:00', 103), 1);
INSERT INTO Card(card_number, userId, type, csv, expiration_date, defaultCard) VALUES (2349234232, 3, 'visa', 999, CONVERT(DATETIME, '30/10/2023 14:30:00', 103), 1);
INSERT INTO Card(card_number, userId, type, csv, expiration_date, defaultCard) VALUES (2349234239, 4, 'visa', 111, CONVERT(DATETIME, '30/10/2023 14:30:00', 103), 1);
INSERT INTO Card(card_number, userId, type, csv, expiration_date, defaultCard) VALUES (2349234231, 5, 'mastercardd', 222, CONVERT(DATETIME, '30/10/2023 14:30:00', 103), 1);

INSERT INTO Product(name, prize, date, stock, categoryId) VALUES ('Nankang SNOW SV-2 JY019', 44.85, CONVERT(DATETIME, '30/12/2023 19:34:33', 103), 8, 2);
INSERT INTO Product(name, prize, date, stock, categoryId) VALUES ('Nankang SV-3 Winter JY215', 45.73, CONVERT(DATETIME, '5/10/2023 11:32:35', 103), 12, 2);
INSERT INTO Product(name, prize, date, stock, categoryId) VALUES ('Superia Bluewin HP SV102', 45, CONVERT(DATETIME, '5/10/2023 11:32:35', 103), 10, 2);
INSERT INTO Product(name, prize, date, stock, categoryId) VALUES ('Superia Bluewin HP SV103', 45.25, CONVERT(DATETIME, '5/10/2023 11:32:35', 103), 7, 2);
INSERT INTO Product(name, prize, date, stock, categoryId) VALUES ('Taurus 601 MS 3PMSF TL 880073', 42.02, CONVERT(DATETIME, '5/10/2023 11:32:35', 103), 3, 2);
INSERT INTO Product(name, prize, date, stock, categoryId) VALUES ('Tristar Snowpower HP TU239', 43, CONVERT(DATETIME, '5/10/2023 11:32:35', 103), 6, 2);
INSERT INTO Product(name, prize, date, stock, categoryId) VALUES ('Atlas Polarbear HP AX300', 45.54, CONVERT(DATETIME, '5/10/2023 11:32:35', 103), 16, 2);
INSERT INTO Product(name, prize, date, stock, categoryId) VALUES ('Roadstone Eurovis Alpine 15293C', 43.20, CONVERT(DATETIME, '26/7/2023 17:22:48', 103), 2, 1);
INSERT INTO Product(name, prize, date, stock, categoryId) VALUES ('Sailun Atrezzo 4Seasons', 40, CONVERT(DATETIME, '26/7/2023 17:22:48', 103), 7, 1);
INSERT INTO Product(name, prize, date, stock, categoryId) VALUES ('MANN-FILTER W 712-52', 8, CONVERT(DATETIME, '30/12/2023 19:34:33', 103), 23, 3);
INSERT INTO Product(name, prize, date, stock, categoryId) VALUES ('MANN-FILTER W 811-80', 6.01, CONVERT(DATETIME, '30/12/2023 19:34:33', 103), 2, 3);
INSERT INTO Product(name, prize, date, stock, categoryId) VALUES ('MAHLE ORIGINAL OX 188D', 6.68, CONVERT(DATETIME, '30/12/2023 19:34:33', 103), 10, 3);
INSERT INTO Product(name, prize, date, stock, categoryId) VALUES ('MANN-FILTER W 712-95', 9.68, CONVERT(DATETIME, '30/12/2023 19:34:33', 103), 5, 3);


INSERT INTO Property(productId, property_name, property_value) VALUES (1, 'Anchura', '175 cm');
INSERT INTO Property(productId, property_name, property_value) VALUES (1, 'Altura', '70 cm');
INSERT INTO Property(productId, property_name, property_value) VALUES (1, 'Tipo', 'R');
INSERT INTO Property(productId, property_name, property_value) VALUES (1, 'Diametro', '13');
INSERT INTO Property(productId, property_name, property_value) VALUES (1, 'Indice de carga', '82');

INSERT INTO Property(productId, property_name, property_value) VALUES (2, 'Anchura', '155 cm');
INSERT INTO Property(productId, property_name, property_value) VALUES (2, 'Altura', '65 cm');
INSERT INTO Property(productId, property_name, property_value) VALUES (2, 'Tipo', 'R');
INSERT INTO Property(productId, property_name, property_value) VALUES (2, 'Diametro', '13');
INSERT INTO Property(productId, property_name, property_value) VALUES (2, 'Indice de carga', '73');

INSERT INTO Property(productId, property_name, property_value) VALUES (3, 'Anchura', '155 cm');
INSERT INTO Property(productId, property_name, property_value) VALUES (3, 'Altura', '70 cm');
INSERT INTO Property(productId, property_name, property_value) VALUES (3, 'Tipo', 'R');
INSERT INTO Property(productId, property_name, property_value) VALUES (3, 'Diametro', '13');
INSERT INTO Property(productId, property_name, property_value) VALUES (3, 'Indice de carga', '75');

INSERT INTO Property(productId, property_name, property_value) VALUES (4, 'Anchura', '165 cm');
INSERT INTO Property(productId, property_name, property_value) VALUES (4, 'Altura', '70 cm');
INSERT INTO Property(productId, property_name, property_value) VALUES (4, 'Tipo', 'R');
INSERT INTO Property(productId, property_name, property_value) VALUES (4, 'Diametro', '13');
INSERT INTO Property(productId, property_name, property_value) VALUES (4, 'Indice de carga', '79');

INSERT INTO Property(productId, property_name, property_value) VALUES (5, 'Anchura', '175 cm');
INSERT INTO Property(productId, property_name, property_value) VALUES (5, 'Altura', '70 cm');
INSERT INTO Property(productId, property_name, property_value) VALUES (5, 'Tipo', 'R');
INSERT INTO Property(productId, property_name, property_value) VALUES (5, 'Diametro', '13');
INSERT INTO Property(productId, property_name, property_value) VALUES (5, 'Indice de carga', '82');

INSERT INTO Property(productId, property_name, property_value) VALUES (6, 'Anchura', '155 cm');
INSERT INTO Property(productId, property_name, property_value) VALUES (6, 'Altura', '80 cm');
INSERT INTO Property(productId, property_name, property_value) VALUES (6, 'Tipo', 'R');
INSERT INTO Property(productId, property_name, property_value) VALUES (6, 'Diametro', '13');
INSERT INTO Property(productId, property_name, property_value) VALUES (6, 'Indice de carga', '79');
INSERT INTO Property(productId, property_name, property_value) VALUES (6, 'Indice de velocidad', 'T');
INSERT INTO Property(productId, property_name, property_value) VALUES (6, 'M+S', 'Si');

INSERT INTO Property(productId, property_name, property_value) VALUES (7, 'Anchura', '155 cm');
INSERT INTO Property(productId, property_name, property_value) VALUES (7, 'Altura', '80 cm');
INSERT INTO Property(productId, property_name, property_value) VALUES (7, 'Tipo', 'R');
INSERT INTO Property(productId, property_name, property_value) VALUES (7, 'Diametro', '13');
INSERT INTO Property(productId, property_name, property_value) VALUES (7, 'Indice de carga', '79');

INSERT INTO Property(productId, property_name, property_value) VALUES (8, 'Anchura', '195 cm');
INSERT INTO Property(productId, property_name, property_value) VALUES (8, 'Altura', '65 cm');
INSERT INTO Property(productId, property_name, property_value) VALUES (8, 'Tipo', 'R');
INSERT INTO Property(productId, property_name, property_value) VALUES (8, 'Diametro', '15');
INSERT INTO Property(productId, property_name, property_value) VALUES (8, 'Indice de carga', '91');

INSERT INTO Property(productId, property_name, property_value) VALUES (9, 'Anchura', '155 cm');
INSERT INTO Property(productId, property_name, property_value) VALUES (9, 'Altura', '60 cm');
INSERT INTO Property(productId, property_name, property_value) VALUES (9, 'Tipo', 'R');
INSERT INTO Property(productId, property_name, property_value) VALUES (9, 'Diametro', '13');
INSERT INTO Property(productId, property_name, property_value) VALUES (9, 'Indice de carga', '73');

INSERT INTO Property(productId, property_name, property_value) VALUES (10, 'Tipo de filtro', 'filtro enroscable');
INSERT INTO Property(productId, property_name, property_value) VALUES (10, 'Altura', '92 mm');
INSERT INTO Property(productId, property_name, property_value) VALUES (10, 'Medida de rosca', '3 / 4-16 UNF');
INSERT INTO Property(productId, property_name, property_value) VALUES (10, 'Diametro', '76 mm');

INSERT INTO Property(productId, property_name, property_value) VALUES (11, 'Tipo de filtro', 'filtro enroscable');
INSERT INTO Property(productId, property_name, property_value) VALUES (11, 'Altura', '75 mm');
INSERT INTO Property(productId, property_name, property_value) VALUES (11, 'Medida de rosca', 'M 20 X 1.5');
INSERT INTO Property(productId, property_name, property_value) VALUES (11, 'Diametro', '80 mm');

INSERT INTO Property(productId, property_name, property_value) VALUES (12, 'Tipo de filtro', 'Cartucho filtrante');
INSERT INTO Property(productId, property_name, property_value) VALUES (12, 'Altura', '140,7 mm');
INSERT INTO Property(productId, property_name, property_value) VALUES (12, 'Peso neto', '101,79 g');
INSERT INTO Property(productId, property_name, property_value) VALUES (12, 'Diametro', '71,5 mm');

INSERT INTO Property(productId, property_name, property_value) VALUES (13, 'Tipo de filtro', 'filtro enroscable');
INSERT INTO Property(productId, property_name, property_value) VALUES (13, 'Altura', '79 mm');
INSERT INTO Property(productId, property_name, property_value) VALUES (13, 'Medida de rosca', '3 / 4-16 UNF-1B');
INSERT INTO Property(productId, property_name, property_value) VALUES (13, 'Diametro', '76 mm');


INSERT INTO Purchase(card_number, targetPostalCode, date, descriptiveName, urgent) VALUES (2349234234, 36121, CONVERT(DATETIME, '7/10/2023 14:30:00', 103), 'default description1', 1);
INSERT INTO Purchase(card_number, targetPostalCode, date, descriptiveName, urgent) VALUES (2349234234, 36121, CONVERT(DATETIME, '9/10/2023 14:39:30', 103), 'default description2', 0);

INSERT INTO PurchaseLine(purchaseId, productId, prize, quantity) VALUES (1, 2, 12, 2);
INSERT INTO PurchaseLine(purchaseId, productId, prize, quantity) VALUES (1, 3, 12, 2);
INSERT INTO PurchaseLine(purchaseId, productId, prize, quantity) VALUES (2, 1, 10, 2);