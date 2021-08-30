using System.Collections.Generic;

namespace Bergle.Domain
{
    public class Editora
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public HashSet<Livro> Publicacoes { get; set; }
    }
}
