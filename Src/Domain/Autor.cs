using System.Collections.Generic;

namespace Bergle.Domain
{
    public class Autor
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public IList<Livro> Livros { get; set; }
    }
}
