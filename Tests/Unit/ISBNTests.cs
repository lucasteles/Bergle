using Bergle.Domain;
using NUnit.Framework;

namespace Tests.Unit
{
    public class ISBNTests
    {
        [SetUp]
        public void Setup() {}

        [Test]
        [TestCase("978-0-306-40615-7")]
        [TestCase("978-8-550-80065-3")]
        [TestCase("978-0-132-10069-4")]
        [Parallelizable(ParallelScope.All)]
        public void IsnbValidos(string numero)
        {
            Assert.That(ISBN.EhValido(numero));
        }

        [Test]
        [TestCase("978-0-306-40615-8")]
        [TestCase("978-8-550-80065-4")]
        [TestCase("978-0-132-10069-5")]
        [Parallelizable(ParallelScope.All)]
        public void IsnbInvalidos(string numero)
        {
            Assert.False(ISBN.EhValido(numero));
        }
    }
}
