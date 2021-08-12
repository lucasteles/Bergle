using Bergle.Domain;
using NUnit.Framework;

namespace Tests.Unit
{
    public class LivrosTests
    {
        [SetUp]
        public void Setup() {}

        [Test]
        public void TesteSemSentido()
        {
            // Arrange
            var livro = new Livro()
            {
                ISBN = new ISBN("978-8-550-80065-3"),
                Titulo = "O Guia do Mochileiro das Galáxias"
            };

            // Act
            livro.Ler();

            // Assert
            Assert.That(livro.FoiLido());
        }
    }
}
