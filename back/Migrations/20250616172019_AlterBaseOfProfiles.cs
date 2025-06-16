using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaApi.Migrations
{
    /// <inheritdoc />
    public partial class AlterBaseOfProfiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customar_Person",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Person",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "Person",
                table: "Employee",
                newName: "User");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_Person",
                table: "Employee",
                newName: "IX_Employee_User");

            migrationBuilder.RenameColumn(
                name: "Person",
                table: "Customer",
                newName: "User");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_Person",
                table: "Customer",
                newName: "IX_Customer_User");

            migrationBuilder.AddForeignKey(
                name: "FK_Customar_User",
                table: "Customer",
                column: "User",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_User",
                table: "Employee",
                column: "User",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customar_User",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_User",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "Employee",
                newName: "Person");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_User",
                table: "Employee",
                newName: "IX_Employee_Person");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "Customer",
                newName: "Person");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_User",
                table: "Customer",
                newName: "IX_Customer_Person");

            migrationBuilder.AddForeignKey(
                name: "FK_Customar_Person",
                table: "Customer",
                column: "Person",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Person",
                table: "Employee",
                column: "Person",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
