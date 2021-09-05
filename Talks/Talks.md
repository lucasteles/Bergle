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
		- Model building:
			- Modelo conceitual do domínio, baseado em convenção e configuração.
			- Modelo e seus mapeamentos são mantidos em memória enquanto a aplicação está de pé.
		- Data Mapping:
			- Camada de mapeamento de dados.
			- Responsável por mapear os resultados das queries SQL em tipos do C#.
		- Object caching:
			- Pode manter objetos em cache, para não precisar ir no banco várias vezes.
		- Transaction management:
			- DbContext.SaveChanges();
			- Unit Of Work

## 3 - DbSet<Entity>
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

## 4 - Change Tracker
	- Cenário: vou no banco, pego alguns dados, altero eles e quero mandar de volta pro banco...
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
		- Propriedades, tipos, chaves, colunas, índices, restrições...
		- Relacionamentos entre entidades

## 10 - Connection Strings
	- Colocar no DbContext.OnConfiguring()
	- Configurar como um Service no Startup
	- Usar arquivos de configuração baseados em ambiente (appsettings.json)

## 11 - Inheritance
	- Table Per Hierarchy (TPH)
	- Table Per Type (TPT)
	- Table Per Concrete Type (TPC)
	- Usamos na Authorizer Transaction?

## 12 - Concurrency Management
	- O que fazer quando diferentes usuários buscam a mesma informação no banco e a modificam em paralelo?
	- No caso da gente, transações em paralelo consumindo saldo
	- Tipos:
		- Last In Wins:
			- Nesse caso, não é necessário gerenciar
		- Pessimistic Concurrency:
			- Bloquear o acesso aos dados, até que ninguém esteja utilizando eles
			- Pode ser complexa de implementar e computacionalmente cara
			- Não é suportada pelo EF Core
		- Optimistic Concurrency:
			- Um user tentando alterar o telefone de uma loja e outro tentando alterar o endereço dela
			- Evitar que um sobrescreva a informação fornecida pelo outro
			- Suportada pelo EF Core
			- Levanta um excessão caso ocorra conflito de concorrência
	- Detectando conflitos:
		- Concurrency tokens:
			- 
		- Rowversion:
			- 

## 13 - Migrations
	- Jeito de manter código e banco sincronizados (um GIT pro bancos de dados?)
	- Possibilitam que eu mude o modelo e propague as mudanças até o banco
	- São gerenciadas através de comandos na CLI:
		- Criação:
			- dotnet ef migrations add <name of migration>
			- O EF compara o modelo atual com o descrito na última migration (se existir) e gera a nova migration
			- Up: contém todo código necessário para levar o banco do estado da última migration até o estado atual do modelo
			- Down: reverte as alterações até o estado da migration anterior
		- Aplicação:
			- dotnet ef database update
			- Se não for específicada, todas as migrations pendentes serão aplicadas
			- Todas as migrations aplicadas ficam na tabela __EFMigrationsHistory
		- Remoção:
			- dotnet ef migrations remove
			- Remove a última migration (arquivo) e reverte o Model Snapshot para o estado da migration anterior
			- Para remover uma migration que já foi commitada, é preciso revertê-la antes
		- Reversão:
			- dotnet ef database update <name of migration>
			- Leva o banco até o estado da migration especificada
			- Modifica a tabela __EFMigrationsHistory
			- Para remover os arquivos de migração e alterar o Model Snapshot, usar o comando remove
		- Aplicação em um banco remoto:
			- dotnet ef migrations script
			- Gera o sql resultante das migrations, que pode ser executado em um banco remoto
		- Raw sql:
			- Usar MigrationBuilder.Sql para rodar commandos sql em uma migration
			- Usamos para gerar views, por exemplo
	- Model Snapshot:
		- Representa o estado atual do modelo
		- É criado junto com a primeira migration e atualizado a cada nova
		- Permite que o EF calcule as mudanças necessárias para atualizar o banco de dados com o modelo
	- Commands:
		- dotnet ef database:
			- drop
			- update
		- dotnet ef dbcontext:
			- info
			- list
		- dotnet ef migrations:
			- add
			- list
			- remove
			- script (mostra o sql que é executado no banco quando a migração é aplicada)

## 14 - Raw SQL
	- Dá pra escrever suas próprias queries SQL e executar comandos.
	- DbSet.FromSqlRaw() e Database.ExecuteSqlCommand()
	- É análogo ao que temos com o Dapper

## 15 - Lazy Loading
	- Adiar a ida ao banco, até que seja realmente necessária
	- Não use, a menos que saiba o que está fazendo

# Referências:
	- https://www.learnentityframeworkcore.com
