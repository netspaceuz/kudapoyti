using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kudapoyti.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class nimadr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Admins",
                newName: "PasswordHash");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Admins",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsHead",
                table: "Admins",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "IsHead",
                table: "Admins");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Admins",
                newName: "Password");
        }
    }
}
