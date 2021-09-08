using System;
using System.Collections.Generic;
using Bergle.Domain;
using static Bergle.Domain.Capa;

namespace Bergle.Data
{
    public static class DbSeeder
    {
        public static void Seed(this BergleContext db)
        {
            // Autores
            var asimov = new Autor(nome: "Isaac Asimov");
            var brooks = new Autor(nome: "Frederick Brooks");
            var fowler = new Autor(nome: "Martin Fowler");

            // Biografias
            var asimovBiografia = new Biografia
            {
                Autor = asimov,
                Descricao = "Foi um escritor norte-americano, nascido na Rússia, autor de obras de ficção científica e divulgação científica.",
                Nascimento = new DateTime(1920, 02, 02),
                Falecimento = new DateTime(1992, 04, 06)
            };

            var brooksBiografia = new Biografia
            {
                Autor = brooks,
                Descricao = "É um engenheiro de software estadunidense, conhecido pelo gerenciamento do projeto do OS/360 e pelo livro The Mythical Man-Month.",
                Nascimento = new DateTime(1920, 02, 02)
            };

            var fowlerBiografia = new Biografia
            {
                Autor = fowler,
                Descricao = "É um autor especializado em análise OO, UML, padrões de projeto e metodologias de desenvolvimento ágil de software, incluindo XP.",
                Nascimento = new DateTime(1963, 12, 18)
            };

            // Leitores
            var alice = new Leitor("Alice");
            var ze = new Leitor("Zé");
            var eloa = new Leitor("Eloá");
            var maria = new Leitor("Maria");
            var joao = new Leitor("João");

            // Livros
            var livros = new List<Livro>
            {
                new Livro(
                    titulo: "Fundação",
                    ano: 1942,
                    capa: Comum,
                    edicao: 2,
                    autores: new HashSet<Autor>() { asimov },
                    leitores: new HashSet<Leitor>() { alice, joao },
                    sinopse: "O Império Galático possui 12 mil anos. E possui pujança, grandeza e estabilidade. Ao menos em sua fachada. Mas ele está em pleno declínio, lento e gradual. E, no final, culminará com uma regressão violenta da sociedade e a conseqüente destruição do conhecimento. Preocupados com isso, um grupo de cientistas traça um plano pela preservação do conhecimento adquirido."
                ),
                new Livro(
                    titulo: "Fundação e Império",
                    ano: 1952,
                    capa: Dura,
                    edicao: 1,
                    autores: new HashSet<Autor>() { asimov },
                    leitores: new HashSet<Leitor>() { alice },
                    sinopse: "O Império Galático está à beira do colapso. Ainda assim, numa tentativa ousada, o General Bel Riose decide lançar um ataque contra a Fundação. Mas será que a ofensiva desesperada irá impedir o destino profetizado há séculos por Hari Seldon? E quem seria, afinal, o Mulo?"
                ),
                new Livro(
                    titulo: "Refactoring - Improving the Design of Existing Code",
                    ano: 1999,
                    capa: Dura,
                    edicao: 1,
                    autores: new HashSet<Autor>() { fowler },
                    leitores: new HashSet<Leitor>() { ze },
                    sinopse: "In this book, Martin Fowler breaks new ground, demystifying these master practices and demonstrating how software practitioners can realize the significant benefits of this new process."
                ),
                new Livro(
                    titulo: "The Mythical Man-Month",
                    ano: 1975,
                    capa: Dura,
                    edicao: 1,
                    autores: new HashSet<Autor>() { brooks },
                    leitores: new HashSet<Leitor>() { alice, eloa, ze, joao, maria },
                    sinopse: "Few books on software project management have been as influential and timeless as The Mythical Man-Month. With a blend of software engineering facts and thought-provoking opinions, Fred Brooks offers insight for anyone managing complex projects. These essays draw from his experience as project manager for the IBM System/360 computer family and then for OS/360, its massive software system. Now, 20 years after the initial publication of his book, Brooks has revisited his original ideas and added new thoughts and advice, both for readers already familiar with his work and for readers discovering it for the first time."
                ),
                new Livro(
                    titulo: "Patterns of Enterprise Application Architecture",
                    ano: 2002,
                    capa: Comum,
                    edicao: 3,
                    autores: new HashSet<Autor>() { brooks, fowler, asimov },
                    leitores: new HashSet<Leitor>() { ze },
                    sinopse: "The practice of enterprise application development has benefited from the emergence of many new enabling technologies. Multi-tiered object-oriented platforms, such as Java and .NET, have become commonplace. These new tools and technologies are capable of building powerful applications, but they are not easily implemented. Common failures in enterprise applications often occur because their developers do not understand the architectural lessons that experienced object developers have learned."
                ),
            };

            // Editoras
            var editora = new Editora
            {
                Nome = "Editora IDE",
                Publicacoes = new HashSet<Livro>( livros )
            };

            // Categorias
            var categorias = new HashSet<Categoria>
            {
                new Categoria()
                {
                    Nome = "Ficção Científica",
                    Livros = new HashSet<Livro>{ livros[0], livros[1] }
                },
                new Categoria()
                {
                    Nome = "Engenharia de Software",
                    Livros = new HashSet<Livro>{ livros[2], livros[3], livros[4] }
                }
            };

            // Reviews e apoios
            var reviews = new List<Review>
            {
                new Review(
                    livro: livros[0],
                    reviewer: alice,
                    titulo: "Não passei da segunda parte",
                    descricao: "A primeira parte é muito boa, com personagens cheios de conteúdo. Uma pena eles serem descartados logo em seguida.",
                    avaliacao: 3
                )
            };

            reviews[0].Adicionar(ze);

            // Subcategorias
            var subcategoria = new Subcategoria
            {
                Nome = "Clássicos",
                Criador = alice,
                Livros = new HashSet<Livro>{ livros[3] }
            };

            // Clubes
            var clube = new Clube
            {
                Nome = "Finer Things Club",
                Descricao = "Is “the most exclusive club” at Dunder Mifflin’s Scranton branch. The members met monthly in the break room to discuss books, art and culture “in a very civilized way.” The rules, according to member Pam Beesly are that: “there is no paper, no plastic and no work talk allowed.”",
                Membros = new HashSet<Leitor>{ alice, eloa, ze }
            };

            db.Livros.AddRange(livros);
            db.Editoras.AddRange(editora);
            db.Categorias.AddRange(categorias);
            db.Subcategorias.AddRange(subcategoria);
            db.Reviews.AddRange(reviews);
            db.Biografias.AddRange(asimovBiografia, brooksBiografia, fowlerBiografia);
            db.Clubes.AddRange(clube);

            db.SaveChanges();
            Console.WriteLine("Dados adicionados com sucesso...");
        }
    }
}
