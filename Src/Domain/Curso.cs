namespace Fadmin.Domain
{
    public class Curso
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public Departamento Departamento { get; set; }
    }
}
