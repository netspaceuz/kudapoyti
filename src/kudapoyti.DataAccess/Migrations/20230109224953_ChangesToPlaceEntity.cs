using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kudapoyti.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangesToPlaceEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Places",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Places");
        }
    }
}
