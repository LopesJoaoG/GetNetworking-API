using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GetNetworkingAPI.Data.Migrations
{
    public partial class TerceiraMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    IdCategoria = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCategoria = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Filme",
                columns: table => new
                {
                    IdFilme = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFilme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataLancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duracao = table.Column<int>(type: "int", nullable: false),
                    VezesAssistidos = table.Column<int>(type: "int", nullable: false),
                    IsCurta = table.Column<bool>(type: "bit", nullable: false),
                    CaminhoFilme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaminhoPoster = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoriaIdCategoria = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filme", x => x.IdFilme);
                    table.ForeignKey(
                        name: "FK_Filme_Categoria_CategoriaIdCategoria",
                        column: x => x.CategoriaIdCategoria,
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Serie",
                columns: table => new
                {
                    IdSerie = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataLancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VezesAssistido = table.Column<int>(type: "int", nullable: false),
                    Temporadas = table.Column<int>(type: "int", nullable: false),
                    Episodios = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaminhoPoster = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoriaIdCategoria = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serie", x => x.IdSerie);
                    table.ForeignKey(
                        name: "FK_Serie_Categoria_CategoriaIdCategoria",
                        column: x => x.CategoriaIdCategoria,
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Episodio",
                columns: table => new
                {
                    IdEpisodio = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duracao = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Temporada = table.Column<int>(type: "int", nullable: false),
                    CaminhoImagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaminhoEpisodio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerieIdSerie = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodio", x => x.IdEpisodio);
                    table.ForeignKey(
                        name: "FK_Episodio_Serie_SerieIdSerie",
                        column: x => x.SerieIdSerie,
                        principalTable: "Serie",
                        principalColumn: "IdSerie",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Episodio_SerieIdSerie",
                table: "Episodio",
                column: "SerieIdSerie");

            migrationBuilder.CreateIndex(
                name: "IX_Filme_CategoriaIdCategoria",
                table: "Filme",
                column: "CategoriaIdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Serie_CategoriaIdCategoria",
                table: "Serie",
                column: "CategoriaIdCategoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Episodio");

            migrationBuilder.DropTable(
                name: "Filme");

            migrationBuilder.DropTable(
                name: "Serie");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
