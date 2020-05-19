CREATE TABLE users (
	users_id INTEGER PRIMARY KEY AUTOINCREMENT,
	name TEXT NOT NULL
);

CREATE TABLE orders (
	orders_id INTEGER PRIMARY KEY AUTOINCREMENT,
	users_id INTEGER NOT NULL,
	status INTEGER NOT NULL,
	FOREIGN KEY(users_id) REFERENCES users(users_id)
);

INSERT INTO users(name)
VALUES 
	('Анна'),
	('Павел'),
	('Иван'),
	('Елена'),
	('Мария');

INSERT INTO orders(users_id, status)
VALUES 
	(1, 1),
	(1, 0),
	(1, 1),
	(2, 0),
	(2, 0),
	(3, 1),
	(4, 0),
	(4, 0),
	(5, 1),
	(1, 1),
	(1, 1),
	(1, 1),
	(1, 1);

--  1) Выбрать всех пользователей из таблицы users, у которых ВСЕ записи в таблице orders 
-- имеют status = 0.
SELECT users.name 
FROM users 
EXCEPT
SELECT users.name  FROM users
	LEFT JOIN orders ON users.users_id = orders.users_id 
WHERE orders.status <> 0;

-- 2) Выбрать всех пользователей из таблицы users, у которых больше 5 записей
-- в таблице orders имеют status = 1.
SELECT 
	users.name
FROM users
LEFT JOIN orders ON users.users_id = orders.users_id
WHERE orders.status = 1
GROUP BY orders.users_id
HAVING COUNT(orders.orders_id) > 5;