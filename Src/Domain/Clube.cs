using System.Collections.Generic;

namespace Bergle.Domain
{
    public class Clube
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public HashSet<Leitor> Membros { get; set; }
    }
}
