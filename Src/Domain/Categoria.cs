using System.Collections.Generic;

namespace Bergle.Domain
{
    public class Categoria
    {
        public int CriadorId { get; set; }

        public string Nome { get; set; }

        public HashSet<Livro> Livros { get; set; }

        public Leitor Criador { get; set; }
    }
}
