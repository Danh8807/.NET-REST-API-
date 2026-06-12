using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudyAbroadApi.Data
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    HighSchool = table.Column<string>(type: "TEXT", nullable: false),
                    GPA = table.Column<double>(type: "REAL", nullable: false),
                    SATScore = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<string>(type: "TEXT", nullable: false),
                    AcceptanceRate = table.Column<string>(type: "TEXT", nullable: false),
                    MinGPA = table.Column<double>(type: "REAL", nullable: false),
                    MinSAT = table.Column<int>(type: "INTEGER", nullable: false),
                    Major = table.Column<string>(type: "TEXT", nullable: false),
                    Tier = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "AcceptanceRate", "Major", "MinGPA", "MinSAT", "Name", "State", "Tier" },
                values: new object[,]
                {
                    { 1, "4%", "Engineering, Computer Science", 3.8999999999999999, 1500, "MIT", "Massachusetts", "Ivy+" },
                    { 2, "4%", "Technology, Business", 3.8999999999999999, 1500, "Stanford University", "California", "Ivy+" },
                    { 3, "5%", "Liberal Arts, Law, Medicine", 3.8999999999999999, 1500, "Harvard University", "Massachusetts", "Ivy+" },
                    { 4, "14%", "Engineering, Business", 3.7000000000000002, 1400, "UC Berkeley", "California", "Top 20" },
                    { 5, "17%", "Engineering, Business", 3.7000000000000002, 1360, "University of Michigan", "Michigan", "Top 20" },
                    { 6, "21%", "Business, Arts, Law", 3.6000000000000001, 1350, "NYU", "New York", "Top 30" },
                    { 7, "31%", "Engineering, Business", 3.5, 1300, "University of Texas at Austin", "Texas", "Top 50" },
                    { 8, "49%", "Engineering, Agriculture", 3.2999999999999998, 1250, "Purdue University", "Indiana", "Top 50" },
                    { 9, "64%", "Business, Engineering, Journalism", 3.0, 1150, "Arizona State University", "Arizona", "Top 100" },
                    { 10, "41%", "Engineering, Business, Hospitality", 3.0, 1160, "University of Central Florida", "Florida", "Top 100" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Universities");
        }
    }
}
