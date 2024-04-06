USE [practicamad_test]

/* Inicializamos la tabla de tests con algunas entradas que se utilizarán al ejecutar las pruebas */
INSERT INTO Workshop(workshop_name, postal_code) VALUES ('UDC', 11111);

INSERT INTO Usuario(alias, user_name, user_surname, password, email, language, country, workshopId) VALUES ('initialized1', 'init', 'user1', 'password', 'admin@admin.com', 'en', 'ES', 1);
INSERT INTO Usuario(alias, user_name, user_surname, password, email, language, country, workshopId) VALUES ('initialized2', 'init', 'user2', 'password', 'admin@admin.com', 'en', 'ES', 1);
INSERT INTO Usuario(alias, user_name, user_surname, password, email, language, country, workshopId) VALUES ('initialized3', 'init', 'user3', 'password', 'admin@admin.com', 'en', 'ES', 1);

INSERT INTO Category(categoryName) VALUES ('Neumaticos');
INSERT INTO Category(categoryName, fatherId) VALUES ('Neumaticos de invierno', 1);

INSERT INTO Card(card_number, userId, type, csv, expiration_date, defaultCard) VALUES (2349234234, 1, 'visa', 777, CONVERT(DATETIME, '30/10/2023 14:30:00', 103), 0);
INSERT INTO Card(card_number, userId, type, csv, expiration_date, defaultCard) VALUES (2349234236, 3, 'visa', 777, CONVERT(DATETIME, '30/10/2023 14:30:00', 103), 1);

INSERT INTO Product(name, prize, date, stock, categoryId) VALUES ('Pirelli 289', 125, CONVERT(DATETIME, '30/12/2023 19:34:33', 103), 2, 2);
INSERT INTO Product(name, prize, date, stock, categoryId) VALUES ('Firetruck 881', 150, CONVERT(DATETIME, '5/10/2023 11:32:35', 103), 12, 2);
INSERT INTO Product(name, prize, date, stock, categoryId) VALUES ('michelin gcv12', 200, CONVERT(DATETIME, '26/7/2023 17:22:48', 103), 1, 1);

INSERT INTO Property(productId, property_name, property_value) VALUES (1, 'diametro', '25 cm');
INSERT INTO Property(productId, property_name, property_value) VALUES (1, 'grosor', '4 cm');
INSERT INTO Property(productId, property_name, property_value) VALUES (2, 'diametro', '30 cm');
INSERT INTO Property(productId, property_name, property_value) VALUES (2, 'grosor', '4.5 cm');
INSERT INTO Property(productId, property_name, property_value) VALUES (3, 'diametro', '35 cm');
INSERT INTO Property(productId, property_name, property_value) VALUES (3, 'grosor', '3.2 cm');