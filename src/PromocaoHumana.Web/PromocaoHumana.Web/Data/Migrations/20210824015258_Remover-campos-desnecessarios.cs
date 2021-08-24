using Microsoft.EntityFrameworkCore.Migrations;

namespace PromocaoHumana.Web.Data.Migrations
{
    public partial class Removercamposdesnecessarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Igreja_Endereco_EnderecoId",
                table: "Igreja");

            migrationBuilder.DropIndex(
                name: "IX_Igreja_EnderecoId",
                table: "Igreja");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Igreja");

            migrationBuilder.DropColumn(
                name: "Paroco",
                table: "Igreja");

            migrationBuilder.AlterColumn<bool>(
                name: "Ativa",
                table: "Familia",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Igreja",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Paroco",
                table: "Igreja",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Ativa",
                table: "Familia",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: true);

            migrationBuilder.CreateIndex(
                name: "IX_Igreja_EnderecoId",
                table: "Igreja",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Igreja_Endereco_EnderecoId",
                table: "Igreja",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
