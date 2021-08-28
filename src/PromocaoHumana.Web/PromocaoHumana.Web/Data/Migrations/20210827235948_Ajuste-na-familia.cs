using Microsoft.EntityFrameworkCore.Migrations;

namespace PromocaoHumana.Web.Data.Migrations
{
    public partial class Ajustenafamilia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Familia_Endereco_EnderecoId",
                table: "Familia");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Familia_EnderecoId",
                table: "Familia");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Familia");

            migrationBuilder.AlterColumn<bool>(
                name: "Ativa",
                table: "Familia",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Familia",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Familia",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Familia",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "Familia",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Familia",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Familia",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Uf",
                table: "Familia",
                maxLength: 2,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Familia");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Familia");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Familia");

            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "Familia");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Familia");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Familia");

            migrationBuilder.DropColumn(
                name: "Uf",
                table: "Familia");

            migrationBuilder.AlterColumn<bool>(
                name: "Ativa",
                table: "Familia",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Familia",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bairro = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Logradouro = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Uf = table.Column<string>(type: "nchar", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Familia_EnderecoId",
                table: "Familia",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Familia_Endereco_EnderecoId",
                table: "Familia",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
