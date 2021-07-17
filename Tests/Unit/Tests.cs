using Fadmin.Domain;
using NUnit.Framework;

namespace Tests.Unit
{
    public class Tests
    {
        [SetUp]
        public void Setup() {}

        [Test]
        public void StupidUnitTest()
        {
            var disciplina = new Disciplina();

            disciplina.CargaHoraria = 50;

            Assert.AreEqual(50, disciplina.CargaHoraria);
        }
    }
}
