# Fadmin

Nesse projeto pretendo aplicar um pouco de cada um desses tópicos:

	- DDD
	- TDD
	- SOLID
	- POO
	- CI/CD
	- Agile
	- XP
	- Design Patterns
	- Clean Code
	- Refactoring
	- Software Design
	- Arquitetura de Software

## Pendências
- Como levar em conta a dinâmica temporal do sistema?
- A cada semestre um novo ciclo recomeça
- O que vai compor o histórico de um Aluno?
- Um Professor vai possuir histórico também?

## Inspirações e fontes de dados
- [USP](https://www5.usp.br/institucional/escolas-faculdades-e-institutos/)

## Banco de Dados para Gerenciamento de uma Faculdade

### [Diagrama Entidade Relacionamento](https://app.diagrams.net/#HZaqueuCavalcante%2Ffadmin%2Fmain%2FDocs%2FDiagramas.drawio)

O objetivo do sistema é gerenciar:
- Alunos
- Professores
- Turmas
- Cursos
- Disciplinas
- Semestres
- Históricos
- Projetos
- Notas
- Livros / Biblioteca

Fases do Projeto:
- Levantamento dos Requisitos (Regras de Negócio)
- Idetificação das Entidades, Atributos e Relacionamentos
- Modelo E-R
- Diagrama E-R
- Dicionário de Dados
- Normalização
- Implementação
- Testes Básicos

### Levantamento de Requisitos (Regras de Negócio)

- Um Aluno só pode estar matriculado em um Curso por vez
- Cada Aluno possui um Código de Identificação (RA)
- Cursos são compostos por Disciplinas
- Cada Disciplina:
	- Terá no máximo 30 Alunos por Turma
	- Pode ser obrigatória ou optativa, dependendo do Curso
	- Pertence à um Departamento específico
	- Possui um código de identificação
	- Pode ter ou ser um pré-requisito para outra
- Alunos podem trancar Matrícula, não estando então matriculados em nenhuma Disciplina no Semestre
- Em cada Semestre, cada Aluno pode se matricular em no máximo 9 Disciplinas
- Um Aluno pode ser aprovado ou reprovado em uma Disciplina
- A Faculdade terá no máximo 3000 Alunos, matriculados simultaneamente em 10 Cursos distintos
- Entram 300 Alunos novos por ano
- Existem 90 Disciplinas disponíveis no total
- Um Histórico Escolar traz todas as Disciplinas cursadas por um Aluno, incluindo:
	- Nota final
	- Frequência (presenças e faltas)
	- Período do Curso realizado
- Professores podem ser cadastrados, mesmo sem lecionar nenhuma disciplina
- Existem 40 Professores na Faculdade
- Cada Professor:
	- Irá lecionar no máximo 4 Disciplinas diferentes
	- É vinculado à um Departamento
	- É identificado por um Código de Identificação

### Idetificação das Entidades, Atributos e Relacionamentos

- Aluno:
	- Id
	- Nome
	- CursoId
- Professor:
	- Id
	- Nome
	- DepartamentoId
- Disciplina:
	- Id
	- Nome
	- Descrição
	- Ementa
	- DepartamentoId
	- Quantidade de Alunos matriculados
- Curso:
	- Id
	- Nome
	- DepartamentoId
- Departamento:
	- Id
	- Nome
- Turma
- Matrícula
- Semestre
- Histórico Escolar

Conteúdo curso de Ciência da Computação, https://teachyourselfcs.com/

	1 - Programming
	2 - Computer Architecture
	3 - Algorithms and Data Structures
	4 - Math for Computer Science
	5 - Operating Systems
	6 - Computer Networks
	7 - Databases
	8 - Compilers
	9 - Distributed Systems
	
## Referências
- [Curso de Modelagem de Dados - Bóson Treinamentos](https://www.youtube.com/playlist?list=PLucm8g_ezqNoNHU8tjVeHmRGBFnjDIlxD)
- [Curso de Vue.js](https://www.youtube.com/watch?v=ArC_Tfmgfb0&list=WL&index=2)
