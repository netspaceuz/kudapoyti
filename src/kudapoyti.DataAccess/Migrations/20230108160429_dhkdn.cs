using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kudapoyti.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class dhkdn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHead",
                table: "Admins");

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Description", "Email", "FullName", "PasswordHash", "PhoneNumber", "Role", "Salt", "TelegramLink" },
                values: new object[] { 1L, " ", "Kudapayti@gmail.com", "Kudapayti", "$2a$11$pUC4LQVORynSuk0xn/Wl9ujn3e8NVGIa9rs8WUliW4USW5FY/BhOG", "+998999909090", 0, "f1fd3ecc-32c8-430d-ae6d-288eb2753c43", "https://t.me/Shoxrux_Husenov" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.AddColumn<bool>(
                name: "IsHead",
                table: "Admins",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
