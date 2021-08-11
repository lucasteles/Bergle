using System.Collections.Generic;
using System.Data;
using Dapper;
using Bergle.Domain;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Bergle.Data
{
    public class LivrosRepo
    {
        private readonly IDbConnection _connection;

        public LivrosRepo(IConfiguration configuration)
        {
            _connection = new NpgsqlConnection(
                configuration.GetConnectionString("Connection")
            );
        }

        public IEnumerable<Livro> ObterTodos()
        {
            using (IDbConnection dbConnection = _connection)
            {
                dbConnection.Open();

                var sql = $@"
                    SELECT
                        id,
                        titulo
                    FROM
                        livros
                ";

                var livros = dbConnection.Query<Livro>(sql);

                return livros;
            }
        }
    }
}
