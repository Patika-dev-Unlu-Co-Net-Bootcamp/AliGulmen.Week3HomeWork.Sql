using Microsoft.EntityFrameworkCore.Migrations;

namespace PatikaDev.Migrations
{
    public partial class coursetableupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "DurationWeek",
                table: "Courses",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationWeek",
                table: "Courses");
        }
    }
}
