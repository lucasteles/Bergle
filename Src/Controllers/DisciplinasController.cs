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
    public class DisciplinasController : ControllerBase
    {
        private readonly IDisciplinasRepo _disciplinas;

        public DisciplinasController(IConfiguration configuration)
        {
            _disciplinas = new DisciplinasRepo(configuration);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Disciplina>> ObterTodas()
        {
            var disciplinas = _disciplinas.ObterTodas();
     
            if (disciplinas.Any())
                return Ok(disciplinas);
            
            return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult<Disciplina> ObterPor(int id)
        {
            var disciplina = _disciplinas.ObterPor(id);

            if (disciplina is null)
                return NotFound();

            return Ok(disciplina);
        }

        [HttpGet]
        [Route("departamento/{id}")]
        public ActionResult<IEnumerable<Disciplina>> ObterPorDepartamento(int id)
        {
            var disciplinas = _disciplinas.ObterPorDepartamento(id);

            if (disciplinas.Any())
                return Ok(disciplinas);
            
            return NotFound();
        }

        [HttpGet]
        [Route("curso/{id}")]
        public ActionResult<IEnumerable<Disciplina>> ObterPorCurso(int id)
        {
            var disciplinas = _disciplinas.ObterPorCurso(id);

            if (disciplinas.Any())
                return Ok(disciplinas);
            
            return NotFound();
        }
    }
}
