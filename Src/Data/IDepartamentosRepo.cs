using System.Collections.Generic;
using Fadmin.Domain;

namespace Fadmin.Data
{
    public interface IDepartamentosRepo
    {
        IEnumerable<Departamento> ObterTodos();
    }
}
