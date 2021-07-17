using System.Collections.Generic;
using Fadmin.Domain;

namespace Fadmin.Data
{
    public interface ICursosRepo
    {
        IEnumerable<Curso> ObterTodos();

        Curso ObterPor(int id);
    }
}
