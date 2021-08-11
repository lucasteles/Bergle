using Bergle.Domain;
using NUnit.Framework;

namespace Tests.Unit
{
    public class Tests
    {
        [SetUp]
        public void Setup() {}

        [Test]
        public void TesteSemSentido()
        {
            // Arrange
            var livro = new Livro()
            {
                Id = 42,
                Titulo = "O Guia do Mochileiro das Galáxias"
            };

            // Act
            livro.Ler();

            // Assert
            Assert.That(livro.FoiLido());
        }
    }
}
