using System;
using System.Collections.Generic;
using System.Linq;
using Fadmin.Domain;
using NUnit.Framework;

namespace Tests.Unit
{
    public class Tests
    {
        [SetUp]
        public void Setup() {}

        [Test]
        public void NaoDeveAtualizarACargaHoraria()
        {
            // Arrange
            var disciplina = new Disciplina();

            var novaCargaHoraria = 1;

            // Act / Assert
            Assert.Throws<Exception>(() => disciplina.AtalizarCargaHoraria(novaCargaHoraria));
        }

        [Test]
        public void DeveAtualizarACargaHoraria()
        {
            // Arrange
            var disciplina = new Disciplina();

            var novaCargaHoraria = 42;

            // Act
            disciplina.AtalizarCargaHoraria(novaCargaHoraria);

            // Assert
            Assert.AreEqual(novaCargaHoraria, disciplina.CargaHoraria);
        }

        [Test]
        public void DeveAdicionarUmNovoPreRequisito()
        {
            // Arrange
            var disciplina = new Disciplina() { Id = 42 };

            var preRequisito = new Disciplina() { Id = 41 };

            // Act
            disciplina.AdicionarPreRequisito(preRequisito);

            // Assert
            Assert.True(disciplina.PreRequisitos.Contains(preRequisito));
        }

        [Test]
        public void UmaDisciplinaNaoPodeSerPrerequisitoParaSePropria()
        {
            // Arrange
            var disciplina = new Disciplina() { Id = 42 };

            // Act
            disciplina.AdicionarPreRequisito(disciplina);

            // Assert
            Assert.True(!disciplina.PreRequisitos.Contains(disciplina));
        }

        [Test]
        public void DeveAdicionarNovosPreRequisitos()
        {
            // Arrange
            var disciplina = new Disciplina() { Id = 42 };

            var preRequisitos = new List<Disciplina>()
            {
                new Disciplina() { Id = 10 },
                new Disciplina() { Id = 20 },
                new Disciplina() { Id = 30 }
            };

            // Act
            disciplina.AdicionarPreRequisitos(preRequisitos);

            // Assert
            foreach (var preRequisito in preRequisitos)
            {   
                Assert.True(disciplina.PreRequisitos.Contains(preRequisito));
            }
        }

        [Test]
        public void NaoDeveDuplicarUmPreRequisito()
        {
            // Arrange
            var disciplina = new Disciplina() { Id = 42 };

            var preRequisitos = new List<Disciplina>()
            {
                new Disciplina() { Id = 10 },
                new Disciplina() { Id = 20 },
                new Disciplina() { Id = 30 }
            };

            disciplina.AdicionarPreRequisitos(preRequisitos);

            // Act
            disciplina.AdicionarPreRequisito(preRequisitos.First());

            // Assert
            foreach (var preRequisito in preRequisitos)
            {   
                Assert.True(disciplina.PreRequisitos.Contains(preRequisito));
            }
            Assert.AreEqual(preRequisitos.Count(), disciplina.PreRequisitos.Count());
        }
    }
}
