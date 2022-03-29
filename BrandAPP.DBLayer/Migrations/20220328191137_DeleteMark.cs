using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrandAPP.DBLayer.Migrations
{
    public partial class DeleteMark : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Brands",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Brands");
        }
    }
}
