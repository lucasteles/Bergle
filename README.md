# Bergle

## 0 - Sim, isso é um monte de CRUD

Só que bem feito.

## 1 - Pra quê serve?

Para exposição, avaliação e venda de livros.

## 2 - Por quê fiz?

Para tentar aplicar na prática um pouco de cada um desses tópicos/conceitos:

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

Um **Livro** *possui* um ou mais **Autores**.

Um **Autor** pode *ter escrito* um ou mais **Livros**.

Um **Livro** pode *pertencer* a uma ou mais **Categorias**.

Um **Livro** pode *ter* nenhuma, uma ou mais **Avaliações**, feitas por **Leitores**.

Cada **Avaliação** é *composta* por uma **Nota** (de 1 a 5 estrelas) e por uma **Descrição**.

Um **Leitor** pode *comprar* um ou mais **Livros**, dentro de um **Pedido**.

Um **Livro** *possui* um **Preço Normal** e eventualmente um **Preço Promocional**.

Um **Leitor** pode *consultar* os livros que já comprou ou que deseja comprar em sua **Estante**.

## 4 - Consultas básicas

- Qual a avaliação média de um determinado livro?

- Qual o melhor livro da categoria tal?

- Qual o melhor livro do autor tal?

## 5 - Novas Features (manter a integridade conceitual)

- Possibilitar que **Leitores** possam revender seus livros (sebo)
- Criação de **Grupos de Leitura**, para discusão sobre um **Livro** ou **Autor**.

## 6 - Sistemas 'análogos'

- [Saraiva](https://www.saraiva.com.br/)
- [Estante Virtual](https://www.estantevirtual.com.br/)
- [Traça](https://www.traca.com.br/)
- [Livraria Cultura](https://www3.livrariacultura.com.br/)
- [Travessa](https://www.travessa.com.br/)
- []()
- []()

## Referências
- [Curso de Modelagem de Dados - Bóson Treinamentos](https://www.youtube.com/playlist?list=PLucm8g_ezqNoNHU8tjVeHmRGBFnjDIlxD)
- [Curso de Vue.js](https://www.youtube.com/watch?v=ArC_Tfmgfb0&list=WL&index=2)
- [Ciência da Computação](https://teachyourselfcs.com/)
- [Dotnet Core Roadmap](https://github.com/MoienTajik/AspNetCore-Developer-Roadmap)
