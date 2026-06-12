using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudyAbroadApi.Data
{
    /// <inheritdoc />
    public partial class SecondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
