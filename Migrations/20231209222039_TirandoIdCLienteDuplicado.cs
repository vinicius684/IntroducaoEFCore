using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoEFCore_.Migrations
{
    /// <inheritdoc />
    public partial class TirandoIdCLienteDuplicado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId",
                table: "Pedidos");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Produtos",
                type: "VARCHAR(60)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(60)");

            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "Pedidos",
                type: "VARCHAR(512)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(512)");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Pedidos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Clientes",
                type: "CHAR(11)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "CHAR(11)");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId",
                table: "Pedidos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId",
                table: "Pedidos");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Produtos",
                type: "VARCHAR(60)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(60)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "Pedidos",
                type: "VARCHAR(512)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(512)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Clientes",
                type: "CHAR(11)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "CHAR(11)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId",
                table: "Pedidos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
