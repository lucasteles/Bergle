using System.Collections.Generic;

namespace Bergle.Domain
{
    public class Leitor
    {
        public int Id { get; private set; }

        public string Nome { get; private set; }

        public HashSet<Livro> Estante { get; private set; }

        public HashSet<Subcategoria> Subcategorias { get; private set; }

        public HashSet<Review> Reviews { get; private set; }

        public HashSet<Review> Apoios { get; private set; }

        public HashSet<Clube> Clubes { get; set; }

        public Leitor(
            string nome
        ) {
            Nome = nome;
        }

        public void ColocarNaEstante(Livro livro)
        {
            if (Estante is null)
                Estante = new HashSet<Livro>();

            Estante.Add(livro);

            livro.AdicionarLeitor(this);
        }
    }
}
