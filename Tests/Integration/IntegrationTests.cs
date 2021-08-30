using Bergle.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace Tests.Integration
{
    public class IntegrationTests
    {
        [SetUp]
        public void Setup() {}

        [Test]
        public void Quando_um_leitor_colocar_um_livro_em_sua_estante__ambos_devem_ser_vinculados()
        {
            // Arrange
            var leitor = new Leitor(
                nome: "Zé"
            );

            var livro = new Livro(
                titulo: "1984",
                ano: 1949,
                autor: new Autor(nome: "George Orwell") 
            );

            // Act
            leitor.ColocarNaEstante(livro);

            // Assert
            leitor.Estante.Should().HaveCount(1);
            leitor.Estante.Should().Contain(livro);

            livro.Leitores.Should().HaveCount(1);
            livro.Leitores.Should().Contain(leitor);
        }
    }
}
