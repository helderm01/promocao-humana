using Microsoft.EntityFrameworkCore.Migrations;

namespace PromocaoHumana.Web.Data.Migrations
{
    public partial class ajustedoacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Doacao");

            migrationBuilder.AddColumn<string>(
                name: "MesRetirada",
                table: "Doacao",
                maxLength: 7,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Familia_CpfResponsavel",
                table: "Familia",
                column: "CpfResponsavel",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doacao_MesRetirada_FamiliaId_LocalRetiradaId",
                table: "Doacao",
                columns: new[] { "MesRetirada", "FamiliaId", "LocalRetiradaId" },
                unique: true,
                filter: "[FamiliaId] IS NOT NULL AND [LocalRetiradaId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Familia_CpfResponsavel",
                table: "Familia");

            migrationBuilder.DropIndex(
                name: "IX_Doacao_MesRetirada_FamiliaId_LocalRetiradaId",
                table: "Doacao");

            migrationBuilder.DropColumn(
                name: "MesRetirada",
                table: "Doacao");

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Doacao",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
