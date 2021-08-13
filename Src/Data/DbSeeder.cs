using System;
using System.Collections.Generic;
using Bergle.Domain;

namespace Bergle.Data
{
    public static class DbSeeder
    {
        public static bool SemearBanco()
        {
            using (var db = new AppContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                AdicionarLivros(db);
                Console.WriteLine("Livros adicionados");
            }

            return true;
        }

        public static void AdicionarLivros(this AppContext db)
        {
            var martinFowler = new Autor
            {
                Nome = "Martin Fowler"
            };

            var books = new List<Livro>
            {
                new Livro
                {
                    Titulo = "Refactoring - Improving the design of existing code",
                    DataDePublicacao = new DateTime(1999, 7, 8),
                    Autores = new List<Autor>() {martinFowler}
                },
                new Livro
                {
                    Titulo = "Patterns of Enterprise Application Architecture",
                    DataDePublicacao = new DateTime(2002, 11, 15),
                    Autores = new List<Autor>() {martinFowler}
                },
                new Livro
                {
                    Titulo = "Domain-Driven Design",
                    DataDePublicacao = new DateTime(2003, 8, 30),
                    Autores = new List<Autor>() { new Autor { Nome = "Eric Evans"} }
                }
            };

            db.Livros.AddRange(books);
            db.SaveChanges();
        }
    }
}
