# Mentoria

# 00 - 19/08/2021

- Como é a evolução na carreira?
    - Estagiário, Júnior, Pleno, Sênior, Arquiteto?
    - Ser especialista, mas conhecer um pouco de tudo?
    - Trabalhar para empresas no exterior?

- O que estudar? Com qual prioridade? Em que ordem?
    - Base sólida em fundamentos: Redes, SO, Arquitetura, Algoritmos, Estruturas de Dados...
    - Conhecimento prático: Git, Testes, .Net, C#, SQL, Docker, HTTP, Desenvolvimento Web...
    - Primeiro aprender a utilizar as ferramentas para depois entender como elas funcionam?

- No .Net / C#, o que aprender antes?
    - EF Core, LINQ, Middlewares, Dependency Injection...
    - Lambda, Threads, Tasks, Reflection, Nuget, Delegates, Events...
    - Roadmap?

- Próximos passos no projeto:
    - Montar API e casos de uso?
        - Como Leitor, quero poder vincular um Livro à minha Estante.
        - Como Leitor, quero fazer um review de um Livro que está na minha Estante.
        - Como Autor, quero poder ver informações acerca dos meus Livros.
    - Services?
        - Cada caso de uso seria um?
    - Testes?
        - Dos 3 tipos?

# 01 - 24/08/2021

- Como definir casos de uso / features?

- Como testar?
    - Como obter dados para os testes?
    - Como subir o banco para testes de integração?
    - Limpar o banco a cada teste e reusar?
    - Testes lentos, o que fazer?

- EF Core:
    - Como funcionam as migrations?

- Implemntar de ponta a ponta:
    - Como Leitor, quero poder adicionar um Livro à minha Estante.
    - Tbm posso Categorizar meus livros de maneira customizada.

# 02 - 14/09/2021

- Implementar as funcionalidades:
    - Casdastrar um livro
    - Vincular um livro à um leitor
    - Vincular um livro à um autor
    - Fazer um review de um livro

- Como lidar com a referência circular do EF?
    - Todos os objetos tão replicados em memória?

- Como adicionar dados mais facilmente para testar a aplicação?

- Como lidar com as migrations?
    - Dá pra ficar criando e apagando o banco toda hora?
