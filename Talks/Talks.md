# EF Core Talks

## 0 - O que é?
	- É um ORM completo, desenvolvido pela Microsoft.
	- ORM = Object-Relational Mapper
	- PostgreSQL <=> EF Core <=> C#

## 1 - Por quê usar?
	- Ao abstrair o banco de dados, o desenvolvimento é facilitado.
	- Não é necessário ficar mantendo um monte de SQL.
	- Nos dá várias features:
		- Criar e manter schemas alinhados com o código e suas mudanças.
		- Geração e execução de SQL.
		- Gerenciamento de transações.
		- Trackeamento de objetos.
	- Outras opções:
		- ADO.NET (nativo do .NET, mais baixo nível, dá muito trabalho).
		- Dapper (micro ORM, performático, faz o básico muito bem).

## 2 - DbContext
	- Classe que abstrai o banco de dados.
	- Nos dá vários recursos:
		- Abertura e gerenciamento de conexões com o banco.
		- Operações de CRUD:
			- Adicionar, obter, modificar e deletar dados.
		- Change Tracking:
			- Detectar mudanças em objetos e gerar updates (SQL).
		- Model building: (NÃO TÁ CLARO O QUE É????)
			- Modelo conceitual do domínio, baseado em convenção e configuração.
			- Modelo e seus mapeamentos são mantidos em memória enquanto a aplicação está de pé.
		- Data Mapping:
			- Camada de mapeamento de dados.
			- Responsável por mapear os resultados das queries SQL em tipos do C#.
		- Object caching:
			- Pode manter objetos em cache, para n precisar ir no banco várias vezes.
		- Transaction management:
			- DbContext.SaveChanges();
			- Unit Of Work

## 3 - Change Tracker
    - Quando o SaveChanges() é chamado, o EF precisa saber o 'estado' dos objetos para poder atualizar o banco (gerar o SQL correto).
    - Possíveis estados:
        - Added     (objeto NÃO existe no banco e deve ser salvo nele)
        - Unchanged (objeto existe no banco e não deve ser alterado)
        - Modified  (objeto existe no banco, foi modificado pela aplicação e deve ter as propriedades modificadas atualizadas no banco)
        - Deleted   (objeto existe no banco e deve ser deletado)
    - Um objeto passa a estar sendo trackeado pelo EF quando:
        - É instanciado pelo EF, através de dados vindos do banco.
        - É vinculado ao contexto via métodos:
            - Add    (seta o estado do objeto para 'Added')
            - Attach (fala pro EF que o objeto já existe no banco e seta o estado pra 'Unchanged')
            - Update (seta o estado do objeto para 'Modified')
            - Remove (seta o estado do objeto para 'Deleted')
            - Entry(objeto) => setar estado manualmente (outros objetos no grafo não são afetados)

## 4 - DbSet<Entity>
    - Representa uma coleção da entidade em memória e serve de gateway para realizar operações no banco que envolvem a entidade.
    - É uma implementação do Repository Pattern.
    - Habilita a realização de operações básicas de CRUD (Create, Read, Update, Delete).
    - Buscando dados:
        - DbSet => Query usando LINQ => Expression Tree => Provider => SQL => Execução da query no banco => Mapeamento pra objetos
		- Dá pra filtrar, ordenar, agrupar, incluir (joins)...
		- Tipos anônimos e Query Types
		- AsNoTracking:
			- Usar quando os dados obtidos não serão alterados (read-only)
			- Geralmente aumenta a performace da query
			- NoTrackingWithIdentityResolution (otimização de memória)

## 5 - Model
	- Modelo conceitual do domínio da aplicação, que é mapeado para tabelas no banco.

## 6 - Relationships
	- One To Many:
		- Uma Editora pode publicar muitos Livros.
	- Many To Many:
		- Um Leitor pode ter vários Livros em sua Estante. Um Livro pode estar na Estante de vários Leitores.
		- Um Autor pode escrever vários Livros. Um Livro pode ser escrito por vários Autores.
	- One To One:
		- Um Autor possui uma Biografia. Uma Biografia está associada à um Autor.

## 7 - Conventions
	- Servem bem para modelos simples.

## 8 - Configuration
	- Permite sobescrever o comportamento padrão do EF (Conventions).
	- Pode ser feita via [Attributes] ou via Fluent().API().

## 9 - Fluent API
	- OnModelCreating(ModelBuilder modelBuilder):
		- Responsável por criar o modelo e os mapeamentos em memória.
	- Provê métodos para configurar vários aspectos do modelo:	
		- Model-wide
		- Types
		- Properties

## ? - Query Types
	- São DTOs (reado-only objects)
	- Não podem ser trackeados
	- Usados para mapear resultados de tabelas e views
	- FromSql => É análogo ao que temos com o Dapper

# Referências:
	- https://www.learnentityframeworkcore.com
