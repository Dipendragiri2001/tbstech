using Microsoft.EntityFrameworkCore.Migrations;

namespace TBSTech.Migrations
{
    public partial class addedcourseduration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourseDuration",
                table: "Courses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseDuration",
                table: "Courses");
        }
    }
}
