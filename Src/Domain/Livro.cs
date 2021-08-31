using System;
using System.Collections.Generic;

namespace Bergle.Domain
{
    public class Livro
    {
        public int Id { get; private set; }

        public string Titulo { get; private set; }

        public string Sinopse { get; private set; }

        public int? Edicao { get; private set; }

        public int Ano { get; private set; }

        public Capa? Capa { get; private set; }

        public Editora Editora { get; private set; }

        public HashSet<Autor> Autores { get; private set; }

        public HashSet<Leitor> Leitores { get; private set; }

        public HashSet<Categoria> Categorias { get; private set; }

        public HashSet<Subcategoria> Subcategorias { get; private set; }

        public HashSet<Review> Reviews { get; private set; }

        private Livro() {}

        public Livro(
            string titulo,
            int ano,
            Autor autor
        ) {
            Titulo = titulo;
            SetarAno(ano);
            Autores = new HashSet<Autor>() { autor };
        }

        public Livro(
            string titulo,
            int ano,
            HashSet<Autor> autores,
            HashSet<Leitor> leitores
        ) {
            Titulo = titulo;
            SetarAno(ano);
            Autores = autores;
            Leitores = leitores;
        }

        private void SetarAno(int ano)
        {
            if (ano >= AnoMin && ano <= AnoMax)
                Ano = ano;
            else
                throw new Exception($"Ano ({ano}) inválido. Deve estar entre {AnoMin} e {AnoMax}.");
        }

        private void SetarEdicao(int edicao)
        {
            if (edicao > 0)
                Edicao = edicao;
            else
                throw new Exception($"Edição ({edicao}) inválida. Deve ser um inteiro positivo.");
        }

        public void AdicionarLeitor(Leitor leitor)
        {
            if (Leitores is null)
                Leitores = new HashSet<Leitor>();

            Leitores.Add(leitor);
        }

        public static readonly int AnoMin = 1445; 
        public static readonly int AnoMax = DateTime.Now.Year; 
    }

    public enum Capa
    {
        Comum = 1,
        Dura = 2
    }
}
