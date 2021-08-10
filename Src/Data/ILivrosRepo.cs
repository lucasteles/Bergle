using System.Collections.Generic;
using Bergle.Domain;

namespace Bergle.Data
{
    public interface ILivrosRepo
    {
        IEnumerable<Livro> ObterTodos();
    }
}
