using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaApi.Migrations
{
    /// <inheritdoc />
    public partial class AlterTabbleSecretaryFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Secretary_FromEmployee",
                table: "Secretary");

            migrationBuilder.AddForeignKey(
                name: "FK_Secretary_Employee",
                table: "Secretary",
                column: "Employee",
                principalTable: "Employee",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Secretary_Employee",
                table: "Secretary");

            migrationBuilder.AddForeignKey(
                name: "FK_Secretary_FromEmployee",
                table: "Secretary",
                column: "Employee",
                principalTable: "Person",
                principalColumn: "Id");
        }
    }
}
