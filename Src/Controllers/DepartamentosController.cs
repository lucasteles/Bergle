using System.Collections.Generic;
using Fadmin.Data;
using Fadmin.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Fadmin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartamentosController : ControllerBase
    {
        private readonly IDepartamentosRepo _departamentos;

        public DepartamentosController(IConfiguration configuration)
        {
            _departamentos = new DepartamentosRepo(configuration);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Departamento>> ObterTodos()
        {
            var departamentos = _departamentos.ObterTodos();
            return Ok(departamentos);
        }

        [HttpGet("{id}")]
        public ActionResult<Departamento> ObterPor(int id)
        {
            var departamento = _departamentos.ObterPor(id);

            if (departamento is null)
                return NotFound();

            return Ok(departamento);
        }

        [HttpGet("{id}/cursos")]
        public ActionResult<IEnumerable<Curso>> ObterTodosOsCursosDoDepartamento(int id)
        {
            var cursos = new List<Curso>();
            return Ok(cursos);
        }

        [HttpGet("{id}/disciplinas")]
        public ActionResult<IEnumerable<Disciplina>> ObterTodasAsDisciplinasDoDepartamento(int id)
        {
            var disciplinas = new List<Disciplina>();
            return Ok(disciplinas);
        }

        [HttpPost]
        public int Inserir(Departamento departamento)
        {
            var linhasAfetadas = _departamentos.Inserir(departamento);
            return linhasAfetadas;
        }

        [HttpPut("{id}")]
        public int Atualizar(int id, Departamento departamento)
        {
            var linhasAfetadas = _departamentos.Atualizar(departamento);
            return linhasAfetadas;
        }

        [HttpDelete("{id}")]
        public int Deletar(int id)
        {
            var linhasAfetadas = _departamentos.Deletar(id);
            return linhasAfetadas;
        }
    }
}
