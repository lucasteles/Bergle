using System.Collections.Generic;
using System.Data;
using Dapper;
using Fadmin.Domain;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Fadmin.Data
{
    public class CursosRepo : ICursosRepo
    {
        private readonly IDbConnection _connection;

        public CursosRepo(IConfiguration configuration)
        {
            _connection = new NpgsqlConnection(
                configuration.GetConnectionString("Connection")
            );
        }

        public IEnumerable<Curso> ObterTodos()
        {
            using (IDbConnection dbConnection = _connection)
            {
                dbConnection.Open();

                var sql = $@"
                    SELECT
                        id,
                        nome
                    FROM
                        cursos
                ";

                var cursos = dbConnection.Query<Curso>(sql);

                return cursos;
            }
        }

        public Curso ObterPor(int id)
        {
            using (IDbConnection dbConnection = _connection)
            {
                dbConnection.Open();

                var sql = $@"
                    SELECT
                        id,
                        nome
                    FROM
                        cursos
                    WHERE
                        id = @Id
                ";

                var curso = dbConnection.QueryFirstOrDefault<Curso>(sql, new { Id = id });

                return curso;
            }
        }

        public IEnumerable<Curso> ObterPorDepartamento(int id)
        {
            using (IDbConnection dbConnection = _connection)
            {
                dbConnection.Open();

                var sql = $@"
                    SELECT
                        id,
                        nome
                    FROM
                        cursos
                    WHERE
                        departamento_id = @Id
                ";

                var cursos = dbConnection.Query<Curso>(sql, new { Id = id });

                return cursos;
            }
        }
    }
}
