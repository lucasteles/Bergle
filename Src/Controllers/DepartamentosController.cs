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
    }
}
