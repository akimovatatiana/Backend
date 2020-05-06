-- Значение в столбце(ах), на который наложено ограничение foreign key, может равняться null, если 
-- на столбец не наложено ограничение NOT NULL.
-- Например, есть две таблицы orders и customers. Создадим в таблице orders столбец 
-- orders.id_customer, который будет внешним ключом, ссылающимся на столбец customers.id_customer 
-- (первичный ключ) в таблице customers. Тогда каждое значение, вставляемое или обновляемое в 
-- orders.id_customer должно соответствовать значению в customers.id_customer или может быть NULL.

CREATE TABLE customers (
	id_customer INTEGER PRIMARY KEY AUTOINCREMENT,
	name TEXT NOT NULL
);

CREATE TABLE orders (
	id_order INTEGER PRIMARY KEY AUTOINCREMENT,
	id_customer INTEGER,
	FOREIGN KEY(id_customer) REFERENCES customers(id_customer)
);

INSERT INTO customers(name)
VALUES
	('Анна'),
	('Павел'),
	('Иван');

INSERT INTO orders(id_customer)
VALUES 
	(NULL),
	(1),
	(3);
	
SELECT * FROM orders;