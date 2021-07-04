-- Consultas simples
SELECT * FROM departamentos;
SELECT * FROM professores;
SELECT * FROM cursos;
SELECT * FROM turmas;
SELECT * FROM disciplinas;

----------------------------------------------------------------------------------------------------
-- Consultas complexas
-- Todas as disciplinas de um dado curso
SELECT
	curso.nome,
	disciplina.nome,
	disciplina.descricao,
	disciplina.carga_horaria
FROM
	cursos curso
INNER JOIN
	disciplinas disciplina
INNER JOIN
	cursos_disciplinas cd

----------------------------------------------------------------------------------------------------
-- Criação das tabelas
CREATE TABLE departamentos
(
	id INT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
	nome VARCHAR(255) NOT NULL
);
CREATE TABLE professores
(
	id INT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
	nome VARCHAR(50) NOT NULL,
	sobrenome VARCHAR(150) NOT NULL,
	departamento_id INT NOT NULL REFERENCES departamentos(id)		
);
CREATE TABLE cursos
(
	id INT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
	nome VARCHAR(50) NOT NULL,
	departamento_id INT NOT NULL REFERENCES departamentos(id)
);
CREATE TABLE turmas
(
	id INT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
	ano VARCHAR(4) NOT NULL,
	curso_id INT NOT NULL REFERENCES cursos(id)
);
CREATE TABLE disciplinas
(
	id INT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
	nome VARCHAR(50) NOT NULL,
	descricao VARCHAR(500) NOT NULL,
	carga_horaria INT NOT NULL,
	departamento_id INT NOT NULL REFERENCES departamentos(id)
);
CREATE TABLE disciplinas_professores
(
	disciplina_id INT NOT NULL REFERENCES disciplinas(id),
	professor_id INT NOT NULL REFERENCES professores(id),
	PRIMARY KEY (disciplina_id, professor_id)
);
CREATE TABLE cursos_disciplinas
(
	curso_id INT NOT NULL REFERENCES cursos(id),
	disciplina_id INT NOT NULL REFERENCES disciplinas(id),
	PRIMARY KEY (curso_id, disciplina_id)		
);
CREATE TABLE alunos
(
	id INT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
	nome VARCHAR(50) NOT NULL,
	sobrenome VARCHAR(150) NOT NULL,
	cpf VARCHAR(11) NOT NULL,
	email VARCHAR(50) NOT NULL,
	curso_id INT NOT NULL REFERENCES cursos(id),
	turma_id INT NOT NULL REFERENCES turmas(id)
);
CREATE TABLE alunos_disciplinas
(
	aluno_id INT NOT NULL REFERENCES alunos(id),
	disciplina_id INT NOT NULL REFERENCES disciplinas(id),
	PRIMARY KEY (aluno_id, disciplina_id)
);

----------------------------------------------------------------------------------------------------
-- Inserção de dados
INSERT INTO departamentos (nome)
VALUES
	('Computação'), ('Matemática'), ('Física'),
	('Artes'), ('Direito'), ('Química'),
	('Comunicações'), ('Filosofia'), ('Medicina')
;
INSERT INTO professores (nome, sobrenome, departamento_id)
VALUES
	('Elliot', 'Alderson', 1),
	('João', 'Silva', 2),
	('Maria', 'Gomes', 3)
;
INSERT INTO cursos (nome, departamento_id)
VALUES
	('Ciência da Computação', 1),
	('Estatística', 2),
	('Física Teórica', 3)
;
INSERT INTO turmas (ano, curso_id)
VALUES
	('2018', 1),
	('2020', 2),
	('2021', 3)
;
INSERT INTO disciplinas (nome, descricao, carga_horaria, departamento_id)
VALUES
	('Estruturas de Dados', 'Aborda as principais ED para armazenamento e manipulação de informações.', 42, 1)
;
INSERT INTO disciplinas_professores (disciplina_id, professor_id)
VALUES
	(1 , 1)
;
INSERT INTO cursos_disciplinas (curso_id, disciplina_id)
VALUES
	(1 , 1)
;
INSERT INTO alunos (nome, sobrenome, cpf, email, curso_id, turma_id)
VALUES
	('Zaqueu', 'Cavalcante', '12345678910', 'zaqueudovale@gmail.com', 1, 1)
;
