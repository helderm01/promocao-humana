using Microsoft.EntityFrameworkCore.Migrations;

namespace PromocaoHumana.Web.Data.Migrations
{
    public partial class ajusteunique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Doacao_MesRetirada_FamiliaId_LocalRetiradaId",
                table: "Doacao");

            migrationBuilder.CreateIndex(
                name: "IX_Doacao_MesRetirada_FamiliaId",
                table: "Doacao",
                columns: new[] { "MesRetirada", "FamiliaId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Doacao_MesRetirada_FamiliaId",
                table: "Doacao");

            migrationBuilder.CreateIndex(
                name: "IX_Doacao_MesRetirada_FamiliaId_LocalRetiradaId",
                table: "Doacao",
                columns: new[] { "MesRetirada", "FamiliaId", "LocalRetiradaId" },
                unique: true);
        }
    }
}
