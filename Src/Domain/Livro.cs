using System;
using System.Collections.Generic;

namespace Bergle.Domain
{
    public class Livro
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public DateTime DataDePublicacao { get; set; }

        public IList<Autor> Autores { get; set; }

        public HashSet<Categoria> Categorias { get; set; }

        public IList<Leitor> Leitores { get; set; }

        public IList<Review> Reviews { get; set; }

        public bool AindaNaoFoiAvaliadoPelo(Leitor leitor)
        {
            return !Leitores.Contains(leitor);
        }

        public void Categorizar(Categoria categoria)
        {
            Categorias.Add(categoria);
        }
    }
}
