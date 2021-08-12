using System.Text.RegularExpressions;

namespace Bergle.Domain
{
    public class ISBN
    {
        private string _numero;

        public ISBN(string numero)
        {
            _numero = numero;
        }

        public static bool EhValido(string numero)
        {
            string digitos = Regex.Replace(numero, "[^0-9]", "");
            int soma = 0;
            
            for (int i=1; i<digitos.Length; i++)
            {
                int multiplicador = (i%2 == 0) ? 3 : 1;
                soma += int.Parse(digitos[i-1].ToString()) * multiplicador;
            }

            int resto = soma%10;

            int digitoVerificador = (resto == 0) ? 0 : 10-resto;

            return digitoVerificador == int.Parse(digitos[digitos.Length-1].ToString());
        }
    }
}
