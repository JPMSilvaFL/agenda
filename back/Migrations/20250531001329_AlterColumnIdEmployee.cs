using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaApi.Migrations
{
    /// <inheritdoc />
    public partial class AlterColumnIdEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Available_Employee",
                table: "Available");

            migrationBuilder.AddForeignKey(
                name: "FK_Available_Employee",
                table: "Available",
                column: "Employee",
                principalTable: "Employee",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Available_Employee",
                table: "Available");

            migrationBuilder.AddForeignKey(
                name: "FK_Available_Employee",
                table: "Available",
                column: "Employee",
                principalTable: "Person",
                principalColumn: "Id");
        }
    }
}
