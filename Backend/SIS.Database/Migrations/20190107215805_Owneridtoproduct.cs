using Microsoft.EntityFrameworkCore.Migrations;

namespace PrimePaper.Database.Migrations
{
    public partial class Owneridtoproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "ProductTableAccess",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "ProductTableAccess");
        }
    }
}
