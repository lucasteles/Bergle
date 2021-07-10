using System.Collections.Generic;

namespace Fadmin.Domain
{
    public class Disciplina
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public int CargaHoraria { get; set; }

        public Departamento Departamento { get; set; }

        public List<Curso> Cursos { get; set; }

        public List<Disciplina> PreRequisitos { get; set; }
    }
}
