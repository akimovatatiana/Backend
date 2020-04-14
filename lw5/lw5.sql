-- 2.  Добавьте таблицы
CREATE TABLE dvd (
	dvd_id	INTEGER PRIMARY KEY AUTOINCREMENT,
	title	INTEGER NOT NULL,
	production_year	INTEGER NOT NULL
);

CREATE TABLE customer (
	customer_id	INTEGER PRIMARY KEY AUTOINCREMENT,
	first_name	TEXT NOT NULL,
	last_name	TEXT NOT NULL,
	passport_code	INTEGER NOT NULL,
	registration_date	TEXT NOT NULL
);

CREATE TABLE offer (
	offer_id	INTEGER PRIMARY KEY AUTOINCREMENT,
	dvd_id	INTEGER NOT NULL,
	customer_id	INTEGER NOT NULL,
	offer_date	TEXT NOT NULL,
	return_date	TEXT NOT NULL,
	FOREIGN KEY(dvd_id) REFERENCES dvd(dvd_id),
	FOREIGN KEY(customer_id) REFERENCES customer(customer_id)
);

-- 3.  Подготовьте SQL запросы для заполнения таблиц данными.
INSERT INTO dvd (title, production_year) 
VALUES 
	('Жизнь прекрасна', 1997), 
	('Король Лев', 1994), 
	('Ходячий замок', 2004), 
	('Начало', 2010), 
	('Игры разума', 2001), 
	('Как приручить дракона', 2010),
	('Матрица', 1999), 
	('Назад в будущее', 1985), 
	('История игрушек: Большой побег', 2010);

INSERT INTO customer (first_name, last_name, passport_code, registration_date) 
VALUES
	('Иван', 'Иванов', 123456, '2020-01-20'), 
	('Анна', 'Владимирова', 654321, '2020-02-03'), 
	('Елена', 'Петрова', 654123, '2020-02-11');

INSERT INTO offer (dvd_id, customer_id, offer_date, return_date) 
VALUES 
	(1, 2, '2020-02-03', '2020-02-13'), 
	(2, 1, '2020-01-20', '2020-01-30'), 
	(3, 3, '2020-02-15', '2020-02-25'),
	(4, 2, '2020-04-10', '2020-04-20'),
	(6, 3, '2020-04-08', '2020-04-18');

-- 4.  Подготовьте SQL запрос получения списка всех DVD, год выпуска которых 2010, 
--	отсортированных в алфавитном порядке по названию DVD.
SELECT * 
FROM dvd 
WHERE production_year = 2010 
ORDER BY title ASC;

--5.  Подготовьте SQL запрос для получения списка DVD дисков, которые в настоящее время
--	находятся у клиентов.
SELECT 
	dvd.dvd_id, 
	dvd.title, 
	dvd.production_year 
FROM dvd
INNER JOIN offer ON dvd.dvd_id = offer.dvd_id
WHERE 
	offer.offer_date <= date('now') AND date('now') < offer.return_date;

--6.  Напишите SQL запрос для получения списка клиентов, которые брали какие-либо DVD 
--	диски в текущем году. В результатах запроса необходимо также отразить какие диски 
--	брали клиенты.
SELECT 
	customer.customer_id, 
	customer.first_name, 
	customer.last_name, 
	dvd.dvd_id, 
	dvd.title,
	dvd.production_year
FROM customer
INNER JOIN offer ON customer.customer_id = offer.customer_id
INNER JOIN dvd ON dvd.dvd_id = offer.dvd_id
WHERE 
	offer.offer_date = date(strftime('%Y', date('now')) || strftime('-%m-%d', offer_date));