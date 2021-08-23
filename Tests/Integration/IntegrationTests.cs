using Bergle.Domain;
using NUnit.Framework;

namespace Tests.Integration
{
    public class IntegrationTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var leitor = new Leitor("Zaqueu");

            var livro = new Livro();

            leitor.ColocarNaEstante(livro);

            Assert.That(leitor.JahLeu(livro));
        }
    }
}
