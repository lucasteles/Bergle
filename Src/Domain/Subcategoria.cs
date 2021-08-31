using System.Collections.Generic;

namespace Bergle.Domain
{
    public class Subcategoria
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public Leitor Criador { get; set; }

        public HashSet<Livro> Livros { get; set; }
    }
}
