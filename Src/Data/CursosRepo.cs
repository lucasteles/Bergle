using System.Collections.Generic;
using System.Data;
using System.Linq;
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
                        curso.id,
                        curso.nome,
                        departamento.id,
                        departamento.nome
                    FROM
                        cursos curso
                    LEFT JOIN
                        departamentos departamento ON curso.departamento_id = departamento.id
                ";

                var cursos = dbConnection.Query<Curso, Departamento, Curso>(sql, 
                    (curso, departamento) => 
                    {
                        curso.Departamento = departamento;
                        return curso;
                    },
                    splitOn: "id, id"
                );

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
                        curso.id,
                        curso.nome,
                        departamento.id,
                        departamento.nome
                    FROM
                        cursos curso
                    LEFT JOIN
                        departamentos departamento ON curso.departamento_id = departamento.id
                    WHERE
                        curso.id = @Id
                ";

                var curso = dbConnection.Query<Curso, Departamento, Curso>(sql, 
                    (curso, departamento) => 
                    {
                        curso.Departamento = departamento;
                        return curso;
                    },
                    new { Id = id },
                    splitOn: "id, id"
                ).FirstOrDefault();

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
                        curso.id,
                        curso.nome,
                        departamento.id,
                        departamento.nome
                    FROM
                        cursos curso
                    LEFT JOIN
                        departamentos departamento ON curso.departamento_id = departamento.id
                    WHERE
                        departamento.id = @Id
                ";

                var cursos = dbConnection.Query<Curso, Departamento, Curso>(sql, 
                    (curso, departamento) => 
                    {
                        curso.Departamento = departamento;
                        return curso;
                    },
                    new { Id = id },
                    splitOn: "id, id"
                );

                return cursos;
            }
        }
    }
}
