using System.Collections.Generic;

namespace Bergle.Domain
{
    public class Leitor
    {
        public int Id { get; private set; }

        public string Nome { get; private set; }

        public HashSet<Livro> Estante { get; private set; }

        public Leitor(
            string nome
        ) {
            Nome = nome;
        }
    }
}
