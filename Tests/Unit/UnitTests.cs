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
                id: 42,
                titulo: "O Guia do Mochileiro das Galáxias",
                ano: 2020
            );

            // Act

            // Assert
            livro.Ano.Should().Be(6, "Porque o valor tá fora do range.");
        }
    }
}
