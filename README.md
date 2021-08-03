# Fadmin

## 0 - Sim, isso é um monte de CRUD

Só que bem feito.

## 1 - Pra quê serve?

Esse sistema serve para gerenciar uma faculdade hipotética, onde não há provas nem notas.

Nela, o objetivo final não é obter um diploma, mas sim adquirir conhecimento e aplicá-lo no desenvolvimento de projetos ao longo da graduação.

## 2 - Por quê fiz?

Para tentar aplicar na prática um pouco de cada um desses tópicos:

	- Escrita de casos de uso efetivos
	- Técnicas de refatoração de código
	- Pricípios SOLID
	- Conceitos de Orientação à Objetos
	- Pipelines de CI/CD
	- Desenvolvimento ágil
	- eXtreme Programming
	- Design Patterns
	- Clean Code
	- Desenvolvimento de features usando Test Driven Design
	- Modelagem de software usando conceitos de Domain Driven Design
	- Arquitetura de Software
	- TODO: colocar o que mais for surgindo ao longo do projeto...

## 3 - Como funciona?

O princípio básico seguido ao longo de todo o projeto é: 
> *Manter as coisas simples*.

A **Faculdade** é *formada* por **Departamentos**.

Cada **Departamento** é responsável por *gerenciar* **Cursos** e **Disciplinas**.

Cada **Curso** é *formado* por um conjunto de **Disciplinas**.

Um **Aluno** deve *estar matriculado* em um **Curso** e *pertencer* à uma **Turma**.

Um **Professor** *pertence* à um **Departamento** e pode *ministrar* uma ou mais **Disciplinas**.

Para *concluir* um **Disciplina**, um **Aluno** deve *fazer* um ou mais **Projetos** relacionados à ela ao longo do **Semestre**.

Cada **Aluno** *possui* um **Histórico**, onde é possível *ver* quais **Disciplinas** (e consequentemente **Projetos**) já foram *concluídas* por ele.

## Referências
- [Curso de Modelagem de Dados - Bóson Treinamentos](https://www.youtube.com/playlist?list=PLucm8g_ezqNoNHU8tjVeHmRGBFnjDIlxD)
- [Curso de Vue.js](https://www.youtube.com/watch?v=ArC_Tfmgfb0&list=WL&index=2)
- [Ciência da Computação](https://teachyourselfcs.com/)
