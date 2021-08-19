using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Src.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "autores",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_autores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categorias", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "leitores",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_leitores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "livros",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    titulo = table.Column<string>(type: "text", nullable: true),
                    data_de_publicacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_livros", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "autor_livro",
                columns: table => new
                {
                    autores_id = table.Column<int>(type: "integer", nullable: false),
                    livros_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_autor_livro", x => new { x.autores_id, x.livros_id });
                    table.ForeignKey(
                        name: "fk_autor_livro_autores_autores_id",
                        column: x => x.autores_id,
                        principalTable: "autores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_autor_livro_livros_livros_id",
                        column: x => x.livros_id,
                        principalTable: "livros",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "categoria_livro",
                columns: table => new
                {
                    categorias_id = table.Column<int>(type: "integer", nullable: false),
                    livros_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categoria_livro", x => new { x.categorias_id, x.livros_id });
                    table.ForeignKey(
                        name: "fk_categoria_livro_categorias_categorias_id",
                        column: x => x.categorias_id,
                        principalTable: "categorias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_categoria_livro_livros_livros_id",
                        column: x => x.livros_id,
                        principalTable: "livros",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "leitor_livro",
                columns: table => new
                {
                    leitores_id = table.Column<int>(type: "integer", nullable: false),
                    livros_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_leitor_livro", x => new { x.leitores_id, x.livros_id });
                    table.ForeignKey(
                        name: "fk_leitor_livro_leitores_leitores_id",
                        column: x => x.leitores_id,
                        principalTable: "leitores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_leitor_livro_livros_livros_id",
                        column: x => x.livros_id,
                        principalTable: "livros",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    leitor_id = table.Column<int>(type: "integer", nullable: true),
                    avaliacao = table.Column<byte>(type: "smallint", nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: true),
                    livro_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reviews", x => x.id);
                    table.ForeignKey(
                        name: "fk_reviews_leitores_leitor_id",
                        column: x => x.leitor_id,
                        principalTable: "leitores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_reviews_livros_livro_id",
                        column: x => x.livro_id,
                        principalTable: "livros",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_autor_livro_livros_id",
                table: "autor_livro",
                column: "livros_id");

            migrationBuilder.CreateIndex(
                name: "ix_categoria_livro_livros_id",
                table: "categoria_livro",
                column: "livros_id");

            migrationBuilder.CreateIndex(
                name: "ix_leitor_livro_livros_id",
                table: "leitor_livro",
                column: "livros_id");

            migrationBuilder.CreateIndex(
                name: "ix_reviews_leitor_id",
                table: "reviews",
                column: "leitor_id");

            migrationBuilder.CreateIndex(
                name: "ix_reviews_livro_id",
                table: "reviews",
                column: "livro_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "autor_livro");

            migrationBuilder.DropTable(
                name: "categoria_livro");

            migrationBuilder.DropTable(
                name: "leitor_livro");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "autores");

            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropTable(
                name: "leitores");

            migrationBuilder.DropTable(
                name: "livros");
        }
    }
}
