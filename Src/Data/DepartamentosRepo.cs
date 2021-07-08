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

        public Departamento Obter(int id)
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
                    WHERE
                        id = @Id
                ";

                var departamento = dbConnection.QueryFirstOrDefault<Departamento>(sql, new { Id = id });

                return departamento;
            }
        }

        public int Inserir(Departamento departamento)
        {
            using (IDbConnection dbConnection = _connection)
            {
                dbConnection.Open();

                var sql = $@"
                    INSERT INTO 
                        departamentos (nome)
                    VALUES
                        (@Nome)
                ";

                var linhasAfetadas = dbConnection.Execute(sql, new { Nome = departamento.Nome });

                return linhasAfetadas;
            }
        }

        public int Atualizar(Departamento departamento)
        {
            using (IDbConnection dbConnection = _connection)
            {
                dbConnection.Open();

                var sql = $@"
                    UPDATE 
                        departamentos
                    SET
                        nome = @Nome
                    WHERE
                        id = @Id
                ";

                var parametros = new {
                    Id = departamento.Id,
                    Nome = departamento.Nome
                };

                var linhasAfetadas = dbConnection.Execute(sql, parametros);

                return linhasAfetadas;
            }
        }

        public int Deletar(int id)
        {
            using (IDbConnection dbConnection = _connection)
            {
                dbConnection.Open();

                var sql = $@"
                    DELETE FROM
                        departamentos
                    WHERE
                        id = @Id
                ";

                var linhasAfetadas = dbConnection.Execute(sql, new { Id = id });

                return linhasAfetadas;
            }
        }
    }
}
