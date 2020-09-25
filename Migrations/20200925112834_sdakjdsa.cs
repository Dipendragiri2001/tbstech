using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TBSTech.Migrations
{
    public partial class sdakjdsa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CourseName = table.Column<string>(nullable: true),
                    CourseLink = table.Column<string>(nullable: true),
                    CourseDescription = table.Column<string>(nullable: true),
                    CourseStartTime = table.Column<DateTime>(nullable: false),
                    CourseEndTime = table.Column<DateTime>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MemberName = table.Column<string>(nullable: true),
                    imageUrl = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CourseDescription = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CourseEndTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CourseLink = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CourseName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CourseStartTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.Id);
                });
        }
    }
}
