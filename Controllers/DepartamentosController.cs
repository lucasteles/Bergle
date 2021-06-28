using System.Collections.Generic;
using Fadmin.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Fadmin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartamentosController : ControllerBase
    {
        private static readonly Departamento[] Departamentos = new[]
        {
            new Departamento {Id = 1, Nome = "Computação"},
            new Departamento {Id = 2, Nome = "Física"},
            new Departamento {Id = 3, Nome = "Matemática"},
            new Departamento {Id = 4, Nome = "Artes"}
        };
 
        public DepartamentosController() {}

        [HttpGet]
        public IEnumerable<Departamento> Get()
        {
            return Departamentos;
        }
    }
}
