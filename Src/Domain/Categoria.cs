using System.Collections.Generic;

namespace Bergle.Domain
{
    public class Categoria
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        
        public Leitor Leitor { get; set; }

        public HashSet<Livro> Livros { get; set; }
    }
}
