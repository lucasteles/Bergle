using System.Collections.Generic;
using System.Data;
using Dapper;
using Fadmin.Domain;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Fadmin.Data
{
    public class DisciplinasRepo : IDisciplinasRepo
    {
        private readonly IDbConnection _connection;

        public DisciplinasRepo(IConfiguration configuration)
        {
            _connection = new NpgsqlConnection(
                configuration.GetConnectionString("Connection")
            );

            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        public IEnumerable<Disciplina> ObterTodas()
        {
            using (IDbConnection dbConnection = _connection)
            {
                dbConnection.Open();

                var sql = $@"
                    SELECT
                        id,
                        nome,
                        descricao,
                        carga_horaria
                    FROM
                        disciplinas
                ";

                var disciplinas = dbConnection.Query<Disciplina>(sql);

                return disciplinas;
            }
        }

        public Disciplina ObterPor(int id)
        {
            using (IDbConnection dbConnection = _connection)
            {
                dbConnection.Open();

                var sql = $@"
                    SELECT
                        id,
                        nome,
                        descricao,
                        carga_horaria
                    FROM
                        disciplinas
                    WHERE
                        id = @Id
                ";

                var disciplina = dbConnection.QueryFirstOrDefault<Disciplina>(sql, new { Id = id });

                return disciplina;
            }
        }
    }
}
