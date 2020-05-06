CREATE TABLE PC (
	id	INTEGER PRIMARY KEY AUTOINCREMENT,
	cpu	INTEGER NOT NULL,
	memory	INTEGER NOT NULL,
	hdd INTEGER NOT NULL
);

INSERT INTO PC (cpu, memory, hdd)
VALUES
	(1600, 2000, 500),
	(2400, 3000, 800),
	(3200, 3000, 1200),
	(2400, 2000, 500);

-- 1)  Тактовые частоты CPU тех компьютеров, у которых объем памяти 3000 Мб.	
SELECT 
	id,
	cpu,
	memory
FROM PC
WHERE memory = 3000;

-- 2) Минимальный объём жесткого диска, установленного в компьютере на складе.
SELECT 
	MIN(hdd) AS hdd
FROM PC;

-- 3) Количество компьютеров с минимальным объемом жесткого диска, доступного на складе.
SELECT 
	COUNT(id) AS count, 
	hdd 
FROM PC 
WHERE 
	hdd = (SELECT MIN(hdd) FROM PC)
GROUP BY hdd;