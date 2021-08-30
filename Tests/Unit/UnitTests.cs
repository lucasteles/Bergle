using System.Collections.Generic;
using Bergle.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace Tests.Unit
{
    public class UnitTests
    {
        [SetUp]
        public void Setup() {}

        [Test]
        public void O_ano_de_publicacao_do_livro_deve_estar_dentro_do_intervalo_permitido()
        {
            // Arrange
            var livro = new Livro(
                titulo: "O Guia do Mochileiro das Galáxias",
                ano: 2020,
                autores: new HashSet<Autor>(),
                leitores: new HashSet<Leitor>()
            );

            // Act

            // Assert
            livro.Ano.Should().Be(2020);
        }
    }
}
