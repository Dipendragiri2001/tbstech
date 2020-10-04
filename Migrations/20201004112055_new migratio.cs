using Microsoft.EntityFrameworkCore.Migrations;

namespace TBSTech.Migrations
{
    public partial class newmigratio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseEndTime",
                table: "CourseTimes");

            migrationBuilder.DropColumn(
                name: "CourseStartTime",
                table: "CourseTimes");

            migrationBuilder.AddColumn<string>(
                name: "DayCourse",
                table: "CourseTimes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EveningCourse",
                table: "CourseTimes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MorningCourse",
                table: "CourseTimes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayCourse",
                table: "CourseTimes");

            migrationBuilder.DropColumn(
                name: "EveningCourse",
                table: "CourseTimes");

            migrationBuilder.DropColumn(
                name: "MorningCourse",
                table: "CourseTimes");

            migrationBuilder.AddColumn<string>(
                name: "CourseEndTime",
                table: "CourseTimes",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseStartTime",
                table: "CourseTimes",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
