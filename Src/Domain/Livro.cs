namespace Bergle.Domain
{
    public class Livro
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        private bool _lido;

        public void Ler()
        {
            var page = 0;
            while (page < 442)
            {
                page++;
            }
            _lido = true;
        }

        public bool FoiLido()
        {
            return _lido;
        }
    }
}
