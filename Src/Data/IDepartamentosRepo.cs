using System.Collections.Generic;
using Fadmin.Domain;

namespace Fadmin.Data
{
    public interface IDepartamentosRepo
    {
        IEnumerable<Departamento> ObterTodos();

        Departamento ObterPor(int id);

        int Inserir(Departamento departamento);

        int Atualizar(Departamento departamento);

        int Deletar(int id);
    }
}
