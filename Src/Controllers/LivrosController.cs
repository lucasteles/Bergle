using System.Linq;
using Bergle.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            // Colocar todas as consultas organizadas aqui

            var livros = _context.Livros.ToList();
            var autores = _context.Autores.ToList();
            var leitores = _context.Leitores.ToList();
            var biografias = _context.Biografias.ToList();
            var categorias = _context.Categorias.ToList();
            var subcategorias = _context.Subcategorias.ToList();
            var editoras = _context.Editoras.ToList();
            var reviews = _context.Reviews.ToList();

            var clube = _context.Clubes.Include(x => x.Membros).First();

            var livrosDto = _context.Livros.Select(x => new {
                    Id = x.Id,
                    Titulo = x.Titulo,
                    Editora = x.Editora.Nome,
                    Autores = x.Autores.Select(a => a.Nome).ToList(),
                    Categorias = x.Categorias.Select(c => c.Nome).ToList(),
                    Reviews = x.Reviews.Select(r => new { 
                        Reviewer = r.Reviewer.Nome,
                        Titulo = r.Titulo,
                        Descricao = r.Descricao,
                        Avaliacao = r.Avaliacao,
                        Data = r.Data,
                        Likes = r.Apoiadores.Count
                    }).ToList()
                }
            ).ToList();

            return Ok(livrosDto);
        }
    }
}
