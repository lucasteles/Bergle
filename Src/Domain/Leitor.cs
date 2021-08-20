using System;
using System.Collections.Generic;
using System.Linq;

namespace Bergle.Domain
{
    public class Leitor
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public HashSet<Livro> Estante { get; set; }

        public HashSet<Categoria> Categorias { get; set; }  // Conceito de Leitor Onisciente

        public HashSet<Review> Reviews { get; set; }

        public HashSet<Review> Apoios { get; set; }

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
