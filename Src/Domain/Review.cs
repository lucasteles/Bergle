using System;
using System.Collections.Generic;

namespace Bergle.Domain
{
    public class Review
    {
        public int Id { get; set; }

        public Livro Livro { get; set; }

        public Leitor Leitor { get; set; }

        public Avaliacao Avaliacao { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public HashSet<Leitor> Apoiadores { get; set; }

        public DateTime Data { get; set; }

        public Review() {}

        public Review(
            Livro livro,
            Leitor leitor,
            Avaliacao avaliacao,
            string descricao
        ) {
            Avaliacao = avaliacao;

            if (10 <= descricao.Length && descricao.Length <= 1_000)
            {
                Descricao = descricao;
            }

            Data = DateTime.Now;
        }

        public void Adicionar(Leitor apoiador)
        {
            Apoiadores.Add(apoiador);
        }
    }

    public enum Avaliacao
    {
        UmaEstrela = 1,
        DuasEstrelas = 2,
        TresEstrelas = 3,
        QuatroEstrelas = 4,
        CincoEstrelas = 5,
    }
}
