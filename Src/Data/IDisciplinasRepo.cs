using System.Collections.Generic;
using Fadmin.Domain;

namespace Fadmin.Data
{
    public interface IDisciplinasRepo
    {
        IEnumerable<Disciplina> ObterTodas();

        Disciplina ObterPor(int id);

        IEnumerable<Disciplina> ObterPorDepartamento(int id);

        IEnumerable<Disciplina> ObterPorCurso(int id);
    }
}
