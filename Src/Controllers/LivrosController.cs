using System.Collections.Generic;
using System.Linq;
using Bergle.Data;
using Bergle.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bergle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivrosController : ControllerBase
    {
        private AppContext context;

        public LivrosController()
        {
            context = new AppContext();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Livro>> ObterTodos()
        {
            var livros = context.Livros
                .AsNoTracking()
                .Include(l => l.Autores)
                .Include(l => l.Categorias)
                .Include(l => l.Leitores)
                .Include(l => l.Reviews)
                .ToList();
            return Ok(livros);
        }
    }
}
