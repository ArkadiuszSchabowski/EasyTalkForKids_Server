using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTalkForKids_Database.Migrations
{
    /// <inheritdoc />
    public partial class FixEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LandNumber",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "LessonNumber",
                table: "Words");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "PolishName");

            migrationBuilder.AddColumn<string>(
                name: "EnglishName",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnglishName",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "PolishName",
                table: "Categories",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "LandNumber",
                table: "Words",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LessonNumber",
                table: "Words",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
