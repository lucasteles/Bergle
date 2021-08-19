using System;
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
        private BergleContext context;

        public LivrosController()
        {
            context = new BergleContext();
        }

        [HttpGet]
        public ActionResult<List<Livro>> ObterTodos()
        {
            var livros = context.Livros
                .AsNoTracking();

            Console.WriteLine(livros.ToQueryString());
            
            return Ok(livros.ToList());
        }
    }
}
