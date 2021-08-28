using Microsoft.EntityFrameworkCore.Migrations;

namespace PromocaoHumana.Web.Data.Migrations
{
    public partial class ajustefks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doacao_Familia_FamiliaId",
                table: "Doacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Doacao_Igreja_LocalRetiradaId",
                table: "Doacao");

            migrationBuilder.DropIndex(
                name: "IX_Doacao_MesRetirada_FamiliaId_LocalRetiradaId",
                table: "Doacao");

            migrationBuilder.AlterColumn<int>(
                name: "LocalRetiradaId",
                table: "Doacao",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FamiliaId",
                table: "Doacao",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doacao_MesRetirada_FamiliaId_LocalRetiradaId",
                table: "Doacao",
                columns: new[] { "MesRetirada", "FamiliaId", "LocalRetiradaId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Doacao_Familia_FamiliaId",
                table: "Doacao",
                column: "FamiliaId",
                principalTable: "Familia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doacao_Igreja_LocalRetiradaId",
                table: "Doacao",
                column: "LocalRetiradaId",
                principalTable: "Igreja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doacao_Familia_FamiliaId",
                table: "Doacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Doacao_Igreja_LocalRetiradaId",
                table: "Doacao");

            migrationBuilder.DropIndex(
                name: "IX_Doacao_MesRetirada_FamiliaId_LocalRetiradaId",
                table: "Doacao");

            migrationBuilder.AlterColumn<int>(
                name: "LocalRetiradaId",
                table: "Doacao",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FamiliaId",
                table: "Doacao",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Doacao_MesRetirada_FamiliaId_LocalRetiradaId",
                table: "Doacao",
                columns: new[] { "MesRetirada", "FamiliaId", "LocalRetiradaId" },
                unique: true,
                filter: "[FamiliaId] IS NOT NULL AND [LocalRetiradaId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Doacao_Familia_FamiliaId",
                table: "Doacao",
                column: "FamiliaId",
                principalTable: "Familia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doacao_Igreja_LocalRetiradaId",
                table: "Doacao",
                column: "LocalRetiradaId",
                principalTable: "Igreja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
