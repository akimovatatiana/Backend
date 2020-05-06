CREATE TABLE author_book (
	id_book INTEGER PRIMARY KEY AUTOINCREMENT,
	author TEXT NOT NULL,
	title TEXT NOT NULL,
	publication_year INTEGER NOT NULL
);

INSERT INTO author_book(author, title, publication_year)
VALUES
	('Джордж Ору­элл', '1984', 1949),
	('Ральф Элли­сон', 'Невидимка', 1952),
	('Лев Толстой', 'Война и мир', 1869),
	('Лев Толстой', 'Анна Каренина', 1877),
	('Вир­джи­ния Вульф', 'К маяку', 1927),
	('Джон Керу­ак', 'В дороге', 1957),
	('Джордж Ору­элл', 'Скотный двор', 1945);
	
-- Выбрать всех авторов из таблицы без использования DISTINCT. 
-- Одинаковые авторы выводятся несколько раз.
SELECT author 
FROM author_book;

-- Выбрать всех авторов из таблицы без дубликатов c использованием DISTINCT.
-- DISTINCT удаляет дубликаты строк при выборке.
SELECT DISTINCT author FROM author_book
ORDER BY author;
