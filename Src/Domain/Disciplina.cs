using System;
using System.Collections.Generic;

namespace Fadmin.Domain
{
    public class Disciplina
    {
        private static byte CARGA_HORARIA_MINIMA = 3;

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public int CargaHoraria { get; set; }

        public Departamento Departamento { get; set; }

        public List<Curso> Cursos { get; set; }

        public List<Disciplina> PreRequisitos { get; set; }

        public Disciplina()
        {
            PreRequisitos = new List<Disciplina>();
        }

        public void AtalizarCargaHoraria(int novaCargaHoraria)
        {
            if (novaCargaHoraria < CARGA_HORARIA_MINIMA)
                throw new Exception($@"A carga horária mínima para uma disciplina é de {CARGA_HORARIA_MINIMA} horas.");

            CargaHoraria = novaCargaHoraria;    
        }

        public void AdicionarPreRequisito(Disciplina novoPreRequisito)
        {
            if (PreRequisitos.Contains(novoPreRequisito))
                return;

            if (novoPreRequisito.Equals(this))
                return;
            
            PreRequisitos.Add(novoPreRequisito);
        }

        public void AdicionarPreRequisitos(List<Disciplina> novosPreRequisitos)
        {
            novosPreRequisitos
                .ForEach(npr => AdicionarPreRequisito(npr));
        }

        public override bool Equals(Object obj)
        {
            if (obj is null)
                return false;

            return (this.Id == ((Disciplina) obj).Id);
        }

        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}
