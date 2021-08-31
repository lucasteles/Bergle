using System;
using System.Collections.Generic;
using System.Linq;
using Bergle.Domain;

namespace Bergle.Data
{
    public static class DbSeeder
    {
        public static void AdicionarLivros(this BergleContext db)
        {
            var isaacAsimov = new Autor(nome: "Isaac Asimov");
            var frederickBrooks = new Autor(nome: "Frederick Brooks");
            var franzKafka = new Autor(nome: "Franz Kafka");

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
                    titulo: "A Metamorfose",
                    ano: 1997,
                    autores: new HashSet<Autor>() { franzKafka },
                    leitores: new HashSet<Leitor>() { tyler }
                ),
                new Livro(
                    titulo: "The Mythical Man-Month",
                    ano: 1975,
                    autores: new HashSet<Autor>() { frederickBrooks },
                    leitores: new HashSet<Leitor>() { alice, tyler }
                )
            };

            var review = new Review(
                livro: livros.First(),
                reviewer: alice,
                titulo: "Título da review",
                descricao: "Descrição da review",
                avaliacao: 5
            );

            db.Livros.AddRange(livros);
            db.Reviews.Add(review);
            db.SaveChanges();
            Console.WriteLine("Livros adicionados");
        }
    }
}
