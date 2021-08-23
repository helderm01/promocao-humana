using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PromocaoHumana.Web.Data.Migrations
{
    public partial class initialdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cep = table.Column<string>(type: "nvarchar", maxLength: 8, nullable: false),
                    Logradouro = table.Column<string>(type: "varchar", maxLength: 200, nullable: false),
                    Numero = table.Column<string>(type: "varchar", maxLength: 5, nullable: true),
                    Complemento = table.Column<string>(type: "varchar", maxLength: 50, nullable: true),
                    Bairro = table.Column<string>(type: "varchar", maxLength: 80, nullable: false),
                    Cidade = table.Column<string>(type: "varchar", maxLength: 150, nullable: false),
                    Uf = table.Column<string>(type: "nchar", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Igreja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar", maxLength: 150, nullable: false),
                    Paroco = table.Column<string>(type: "varchar", maxLength: 60, nullable: true),
                    Cnpj = table.Column<string>(type: "nvarchar", maxLength: 14, nullable: false),
                    EnderecoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Igreja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Igreja_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Familia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    Ativa = table.Column<bool>(nullable: false),
                    NomeResponsavel = table.Column<string>(type: "varchar", maxLength: 150, nullable: false),
                    CpfResponsavel = table.Column<string>(type: "nvarchar", maxLength: 12, nullable: false),
                    NomeConjuge = table.Column<string>(type: "varchar", maxLength: 150, nullable: true),
                    QuantidadeFilhos = table.Column<int>(nullable: false, defaultValue: 0),
                    EnderecoId = table.Column<int>(nullable: true),
                    ParoquiaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Familia_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Familia_Igreja_ParoquiaId",
                        column: x => x.ParoquiaId,
                        principalTable: "Igreja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataRetirada = table.Column<DateTime>(type: "datetime", nullable: false),
                    Descricao = table.Column<string>(type: "varchar", maxLength: 150, nullable: false),
                    FamiliaId = table.Column<int>(nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    QuemRetirou = table.Column<string>(type: "varchar", maxLength: 150, nullable: false),
                    LocalRetiradaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doacao_Familia_FamiliaId",
                        column: x => x.FamiliaId,
                        principalTable: "Familia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doacao_Igreja_LocalRetiradaId",
                        column: x => x.LocalRetiradaId,
                        principalTable: "Igreja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doacao_FamiliaId",
                table: "Doacao",
                column: "FamiliaId");

            migrationBuilder.CreateIndex(
                name: "IX_Doacao_LocalRetiradaId",
                table: "Doacao",
                column: "LocalRetiradaId");

            migrationBuilder.CreateIndex(
                name: "IX_Familia_EnderecoId",
                table: "Familia",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Familia_ParoquiaId",
                table: "Familia",
                column: "ParoquiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Igreja_EnderecoId",
                table: "Igreja",
                column: "EnderecoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doacao");

            migrationBuilder.DropTable(
                name: "Familia");

            migrationBuilder.DropTable(
                name: "Igreja");

            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
