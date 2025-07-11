using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAppAuth.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicialModeloCategoriaLaptop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorria",
                table: "Categorria");

            migrationBuilder.RenameTable(
                name: "Categorria",
                newName: "Categoria");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria");

            migrationBuilder.RenameTable(
                name: "Categoria",
                newName: "Categorria");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorria",
                table: "Categorria",
                column: "Id");
        }
    }
}
