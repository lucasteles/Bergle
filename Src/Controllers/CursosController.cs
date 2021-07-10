using System.Collections.Generic;
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
            return Ok(cursos);
        }

        [HttpGet("{id}")]
        public ActionResult<Curso> ObterPor(int id)
        {
            var curso = _cursos.ObterPor(id);

            if (curso is null)
                return NotFound();

            return Ok(curso);
        }

        [HttpGet]
        [Route("departamento/{id}")]
        public ActionResult<IEnumerable<Curso>> ObterPorDepartamento(int id)
        {
            var cursos = _cursos.ObterPorDepartamento(id);
            return Ok(cursos);
        }
    }
}
