using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaApi.Migrations
{
    /// <inheritdoc />
    public partial class AddFKScheduledPurpose : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scheduled_Purpose_FromPurposeId",
                table: "Scheduled");

            migrationBuilder.DropIndex(
                name: "IX_Scheduled_FromPurposeId",
                table: "Scheduled");

            migrationBuilder.DropColumn(
                name: "FromPurposeId",
                table: "Scheduled");

            migrationBuilder.RenameColumn(
                name: "IdPurpose",
                table: "Scheduled",
                newName: "Purpose");

            migrationBuilder.CreateIndex(
                name: "IX_Scheduled_Purpose",
                table: "Scheduled",
                column: "Purpose");

            migrationBuilder.AddForeignKey(
                name: "FK_Scheduled_Purpose",
                table: "Scheduled",
                column: "Purpose",
                principalTable: "Purpose",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scheduled_Purpose",
                table: "Scheduled");

            migrationBuilder.DropIndex(
                name: "IX_Scheduled_Purpose",
                table: "Scheduled");

            migrationBuilder.RenameColumn(
                name: "Purpose",
                table: "Scheduled",
                newName: "IdPurpose");

            migrationBuilder.AddColumn<Guid>(
                name: "FromPurposeId",
                table: "Scheduled",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Scheduled_FromPurposeId",
                table: "Scheduled",
                column: "FromPurposeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scheduled_Purpose_FromPurposeId",
                table: "Scheduled",
                column: "FromPurposeId",
                principalTable: "Purpose",
                principalColumn: "Id");
        }
    }
}
