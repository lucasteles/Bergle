using System;
using System.Collections.Generic;

namespace Bergle.Domain
{
    public class Review
    {
        public int Id { get; private set; }

        public Livro Livro { get; private set; }

        public Leitor Reviewer { get; private set; }

        public HashSet<Leitor> Apoiadores { get; private set; }

        public byte Avaliacao { get; private set; }

        public string Titulo { get; private set; }

        public string Descricao { get; private set; }

        public DateTime Data { get; private set; }

        public Review() {}

        public Review(
            Livro livro,
            Leitor reviewer,
            string titulo,
            string descricao,
            byte avaliacao
        ) {
            Livro = livro;
            Reviewer = reviewer;
            Titulo = titulo;

            if (descricao.Length is >= 10 and <= 1_000)
            {
                Descricao = descricao;
            }
            else
            {
                throw new Exception($"Descricao vazia...");
            }

            SetarAvaliacao(avaliacao);

            Data = DateTime.Now;
        }

        public void Adicionar(Leitor apoiador)
        {
            if (Apoiadores is null)
                Apoiadores = new HashSet<Leitor>();
            Apoiadores.Add(apoiador);
        }

        private void SetarAvaliacao(byte avaliacao)
        {
            if (avaliacao >= 1 && avaliacao <= 5)
                Avaliacao = avaliacao;
            else
                throw new Exception($"Avaliação ({avaliacao}) inválida. Deve estar entre 1 e 5 estrelas.");
        }
    }
}
