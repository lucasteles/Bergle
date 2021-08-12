using System.Collections.Generic;
using Bergle.Data;
using Bergle.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Bergle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly LivrosRepo _livros;

        public LivrosController(IConfiguration configuration)
        {
            _livros = new LivrosRepo(configuration);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Livro>> ObterTodos()
        {
            return Ok(_livros.ObterTodos());
        }
    }
}
