using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internship2023_backend.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserPhone",
                table: "Users",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "UserPassword",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserEmail",
                table: "Users",
                newName: "IX_Users_Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Users",
                newName: "UserPhone");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "UserPassword");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "UserEmail");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Email",
                table: "Users",
                newName: "IX_Users_UserEmail");
        }
    }
}
