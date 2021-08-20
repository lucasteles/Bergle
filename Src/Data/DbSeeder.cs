using System;
using System.Collections.Generic;
using Bergle.Domain;

namespace Bergle.Data
{
    public static class DbSeeder
    {
        public static bool SemearBanco()
        {
            using (var db = new BergleContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                AdicionarLivros(db);
                Console.WriteLine("Livros adicionados");
            }

            return true;
        }

        public static void AdicionarLivros(this BergleContext db)
        {
            var martinFowler = new Autor { Nome = "Martin Fowler" };
            var isaacAsimov = new Autor { Nome = "Isaac Asimov" };
            var frederickBrooks = new Autor { Nome = "Frederick P. Brooks" };
            var franzKafka = new Autor { Nome = "Franz Kafka" };

            var software = new Categoria { Nome = "Software" };
            var ficcao = new Categoria { Nome = "Ficção" };
            var novela = new Categoria { Nome = "Novela" };
            var classico = new Categoria { Nome = "Clássico" };

            var sam = new Leitor { Nome = "Sam" };
            var alice = new Leitor { Nome = "Alice" };
            var tyler = new Leitor { Nome = "Tyler" };

            var fundacaoReview = new Review
            {
                Avaliacao = 5,
                Descricao = "Um clássico absoluto da ficção científica!",
                Leitor = sam
            };

            var tmmReview = new Review
            {
                Avaliacao = 5,
                Descricao = "O melhor livro já escrito sobre desenvolvimento de software!",
                Leitor = tyler
            };

            var pOfEaaReview = new Review
            {
                Avaliacao = 3,
                Descricao = "Em C# seria melhor...",
                Leitor = alice
            };

            var books = new List<Livro>
            {
                new Livro
                {
                    Titulo = "Fundação",
                    DataDePublicacao = new DateTime(1942, 1, 1),
                    Autores = new List<Autor>() { isaacAsimov },
                    Categorias = new HashSet<Categoria>() { ficcao, classico },
                    Leitores = new List<Leitor>() { sam, alice },
                    Reviews = new List<Review>() { fundacaoReview }
                },
                new Livro
                {
                    Titulo = "Fundação e Império",
                    DataDePublicacao = new DateTime(1952, 1, 1),
                    Autores = new List<Autor>() {isaacAsimov},
                    Categorias = new HashSet<Categoria>() { ficcao },
                    Leitores = new List<Leitor>() { sam }
                },
                new Livro
                {
                    Titulo = "Segunda Fundação",
                    DataDePublicacao = new DateTime(1953, 1, 1),
                    Autores = new List<Autor>() { isaacAsimov },
                    Categorias = new HashSet<Categoria>() { ficcao },
                    Leitores = new List<Leitor>() { sam }
                },
                new Livro
                {
                    Titulo = "Patterns of Enterprise Application Architecture",
                    DataDePublicacao = new DateTime(2002, 11, 15),
                    Autores = new List<Autor>() { martinFowler },
                    Categorias = new HashSet<Categoria>() { software },
                    Leitores = new List<Leitor>() { alice, tyler },
                    Reviews = new List<Review>() { pOfEaaReview }
                },
                new Livro
                {
                    Titulo = "The Mythical Man-Month",
                    DataDePublicacao = new DateTime(1975, 1, 1),
                    Autores = new List<Autor>() { frederickBrooks, martinFowler },
                    Categorias = new HashSet<Categoria>() { software, classico },
                    Leitores = new List<Leitor>() { sam, tyler },
                    Reviews = new List<Review>() { tmmReview }
                },
                new Livro
                {
                    Titulo = "A Metamorfose",
                    DataDePublicacao = new DateTime(1997, 1, 1),
                    Autores = new List<Autor>() { franzKafka },
                    Categorias = new HashSet<Categoria>() { novela, classico },
                    Leitores = new List<Leitor>() { alice }
                }
            };

            db.Livros.AddRange(books);
            db.SaveChanges();
        }
    }
}
