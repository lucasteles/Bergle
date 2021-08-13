namespace Bergle.Domain
{
    public class Review
    {
        public int Id { get; set; }

        public Leitor Leitor { get; set; }  // Cada leitor pode fazer no máximo 1 review / livro

        public byte Avaliacao { get; set; }  // Min 1 | Máx 5 estrelas

        public string Descricao { get; set; }  // Min 10 | Máx 1000 caracteres
    }
}
