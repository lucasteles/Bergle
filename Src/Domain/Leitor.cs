using System;
using System.Collections.Generic;
using System.Linq;

namespace Bergle.Domain
{
    public class Leitor
    {
        public int Id { get; }

        public string Nome { get; }

        public HashSet<Livro> Estante { get; }

        public HashSet<Categoria> Categorias { get; }  // Conceito de Leitor Onisciente

        public HashSet<Review> Reviews { get; }

        public HashSet<Review> Apoios { get; }

        public Leitor(
            string nome
        ) {
            Estante = new HashSet<Livro>();
            Categorias = new HashSet<Categoria>();
            Reviews = new HashSet<Review>();
            Apoios = new HashSet<Review>();
        }

        public bool JahLeu(Livro livro)
        {
            return Estante.Contains(livro);
        }

        public bool ColocarNaEstante(Livro livro)
        {
            return Estante.Add(livro);
        }

        public void Categorizar(Livro livro, Categoria categoria)
        {
            if (!Estante.Contains(livro))
            {
                throw new Exception("Você precisa adquirir um exemplar deste livro para poder categorizá-lo.");
            }

            Categorias.Add(categoria);

            Estante
                .Single(x => x.Id == livro.Id)
                .Categorizar(categoria);
        }

        public void Apoiar(Review review)
        {
            Apoios.Add(review);
        }

        public void Publicar(Review review)
        {
            Reviews.Add(review);
        }
    }
}
