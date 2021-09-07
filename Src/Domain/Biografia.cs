using System;

namespace Bergle.Domain
{
    public class Biografia
    {
        public int AutorId { get; set; }

        public Autor Autor { get; set; }

        public string Descricao { get; set; }

        public DateTime Nascimento { get; set; }

        public DateTime? Falecimento { get; set; }
    }
}
