using System;
using System.Collections.Generic;
using Bergle.Domain;

namespace Bergle.Data
{
    public static class DbSeeder
    {
        public static void AdicionarLivros(this BergleContext db)
        {
            var isaacAsimov = new Autor { Nome = "Isaac Asimov" };
            var frederickBrooks = new Autor { Nome = "Frederick Brooks" };
            var franzKafka = new Autor { Nome = "Franz Kafka" };

            var alice = new Leitor("Alice");
            var tyler = new Leitor("Tyler");

            var livros = new List<Livro>
            {
                new Livro(
                    titulo: "Fundação",
                    ano: 1942,
                    autores: new HashSet<Autor>() { isaacAsimov },
                    leitores: new HashSet<Leitor>() { alice }
                ),
                new Livro(
                    titulo: "The Mythical Man-Month",
                    ano: 1975,
                    autores: new HashSet<Autor>() { frederickBrooks },
                    leitores: new HashSet<Leitor>() { alice, tyler }
                ),
                new Livro(
                    titulo: "A Metamorfose",
                    ano: 1997,
                    autores: new HashSet<Autor>() { franzKafka },
                    leitores: new HashSet<Leitor>() { tyler }
                )
            };

            db.Livros.AddRange(livros);
            db.SaveChanges();
            Console.WriteLine("Livros adicionados");
        }
    }
}
