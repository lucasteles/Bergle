using System;
using System.Linq;
using System.Threading.Tasks;
using Bergle.Data;
using Bergle.Domain;
using Bergle.Domain.DTOs;
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

        [HttpPost]
        public async Task<IActionResult> Post(LivroDTO dto)
        {
            var author = await _context.Autores.FindAsync(dto.AutorId);
            if (author is null)
                return BadRequest();

           // if (dto.Ano is >= 1445 and <= 2021)
           //   return BadRequest();

            var livro = new Livro(dto.Titulo, dto.Ano, author);
            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();

            return Created("/", new { livro.Id});
        }

        [HttpGet]
        public async Task<ActionResult> ObterTodos()
        {
            // Colocar todas as consultas organizadas aqui
            var livros2 =
                await _context
                    .Livros
                    .Include(x => x.Autores)
                    .ToListAsync();

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
