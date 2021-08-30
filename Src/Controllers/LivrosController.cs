using System.Collections.Generic;
using System.Linq;
using Bergle.Data;
using Bergle.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Bergle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly BergleContext _context;

        public LivrosController(BergleContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult ObterTodos()
        {
            var livros = _context.Livros
                .Select(l => new {
                    Id = l.Id,
                    Titulo = l.Titulo,
                    Ano = l.Ano}             
                )
                .ToList();

            return Ok(livros);
        }
    }
}
