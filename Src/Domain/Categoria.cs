using System.Collections.Generic;

namespace Bergle.Domain
{
    public class Categoria
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        
        public Leitor Leitor { get; set; }  // Conceito de Leitor Onisciente

        public HashSet<Livro> Livros { get; set; }
    }
}
