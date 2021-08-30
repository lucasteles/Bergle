using System.Collections.Generic;

namespace Bergle.Domain
{
    public class Autor
    {
        public int Id { get; private set; }

        public string Nome { get; private set; }

        public Biografia Biografia { get; private set; }

        public HashSet<Livro> Obras { get; private set; }

        public Autor(
            string nome
        ) {
            Nome = nome;
        }
    }
}
