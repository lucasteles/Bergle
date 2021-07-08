using System.Collections.Generic;
using System.Data;
using Dapper;
using Fadmin.Domain;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Fadmin.Data
{
    public class DepartamentosRepo : IDepartamentosRepo
    {
        private readonly IDbConnection _connection;

        public DepartamentosRepo(IConfiguration configuration)
        {
            _connection = new NpgsqlConnection(
                configuration.GetConnectionString("Connection")
            );
        }

        public IEnumerable<Departamento> ObterTodos()
        {
            using (IDbConnection dbConnection = _connection)
            {
                dbConnection.Open();

                var sql = $@"
                    SELECT
                        id,
                        nome
                    FROM
                        departamentos
                ";

                var departamentos = dbConnection.Query<Departamento>(sql);

                return departamentos;
            }
        }
    }
}
