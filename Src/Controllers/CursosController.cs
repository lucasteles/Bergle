using System.Collections.Generic;
using System.Linq;
using Fadmin.Data;
using Fadmin.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Fadmin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CursosController : ControllerBase
    {
        private readonly ICursosRepo _cursos;

        public CursosController(IConfiguration configuration)
        {
            _cursos = new CursosRepo(configuration);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Curso>> ObterTodos()
        {
            var cursos = _cursos.ObterTodos();
     
            if (cursos.Any())
                return Ok(cursos);
            
            return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult<Curso> ObterPor(int id)
        {
            var curso = _cursos.ObterPor(id);

            if (curso is null)
                return NotFound();

            return Ok(curso);
        }

        [HttpGet("{id}/disciplinas")]
        public ActionResult<IEnumerable<Disciplina>> ObterTodasAsDisciplinasDoCurso(int id)
        {
            var disciplinas = new List<Disciplina>();
            return Ok(disciplinas);
        }
    }
}
