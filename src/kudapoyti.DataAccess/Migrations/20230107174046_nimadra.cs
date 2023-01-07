using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kudapoyti.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class nimadra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TelegramContact",
                table: "Admins",
                newName: "TelegramLink");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Admins",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Admins",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Admins");

            migrationBuilder.RenameColumn(
                name: "TelegramLink",
                table: "Admins",
                newName: "TelegramContact");
        }
    }
}
