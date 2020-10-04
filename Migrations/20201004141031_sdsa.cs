using Microsoft.EntityFrameworkCore.Migrations;

namespace TBSTech.Migrations
{
    public partial class sdsa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId1",
                table: "CourseTimes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseTimes_CourseId1",
                table: "CourseTimes",
                column: "CourseId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTimes_Courses_CourseId1",
                table: "CourseTimes",
                column: "CourseId1",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseTimes_Courses_CourseId1",
                table: "CourseTimes");

            migrationBuilder.DropIndex(
                name: "IX_CourseTimes_CourseId1",
                table: "CourseTimes");

            migrationBuilder.DropColumn(
                name: "CourseId1",
                table: "CourseTimes");
        }
    }
}
