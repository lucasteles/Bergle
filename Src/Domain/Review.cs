using System;
using System.Collections.Generic;

namespace Bergle.Domain
{
    public class Review
    {
        public int Id { get; set; }

        public Livro Livro { get; set; }

        public Leitor Leitor { get; set; }

        public byte Avaliacao { get; set; }

        public string Descricao { get; set; }

        public HashSet<Leitor> Apoiadores { get; set; }

        public DateTime Data { get; set; }

        public Review() {}

        public Review(
            Livro livro,
            Leitor leitor,
            byte avaliacao,
            string descricao
        ) {
            if (leitor.JahLeu(livro) && livro.AindaNaoFoiAvaliadoPelo(leitor))
            {
                if (1 <= avaliacao && avaliacao <= 5)
                {
                    Avaliacao = avaliacao;
                }

                if (10 <= descricao.Length && descricao.Length <= 1_000)
                {
                    Descricao = descricao;
                }

                Data = DateTime.Now;
            }
        }

        public void Adicionar(Leitor apoiador)
        {
            Apoiadores.Add(apoiador);
        }
    }
}
