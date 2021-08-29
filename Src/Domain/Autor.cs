using System.Collections.Generic;

namespace Bergle.Domain
{
    public class Autor
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Biografia { get; set; }

        public HashSet<Livro> Livros { get; set; }
    }
}
