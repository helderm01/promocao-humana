using Microsoft.EntityFrameworkCore.Migrations;

namespace PromocaoHumana.Web.Data.Migrations
{
    public partial class removerparoquiafamilia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Familia_Igreja_ParoquiaId",
                table: "Familia");

            migrationBuilder.DropIndex(
                name: "IX_Familia_ParoquiaId",
                table: "Familia");

            migrationBuilder.DropColumn(
                name: "ParoquiaId",
                table: "Familia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParoquiaId",
                table: "Familia",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Familia_ParoquiaId",
                table: "Familia",
                column: "ParoquiaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Familia_Igreja_ParoquiaId",
                table: "Familia",
                column: "ParoquiaId",
                principalTable: "Igreja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
