-- Consultas simples
SELECT * FROM livros;

----------------------------------------------------------------------------------------------------
-- Criação das tabelas
CREATE TABLE livros
(
	id INT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
	titulo VARCHAR(255) NOT NULL
);

----------------------------------------------------------------------------------------------------
-- Inserção de dados
INSERT INTO livros (titulo)
VALUES
	('Domain Driven Design'), 
	('Test Driven Development'), 
	('The Mythical Man-Month')
;
