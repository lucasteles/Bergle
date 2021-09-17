using System;

namespace Bergle.Domain
{
    public class ExcecaoDeDominio : Exception
    {
        public ExcecaoDeDominio(string mensagem) : base(mensagem)
        {

        }

    }
}