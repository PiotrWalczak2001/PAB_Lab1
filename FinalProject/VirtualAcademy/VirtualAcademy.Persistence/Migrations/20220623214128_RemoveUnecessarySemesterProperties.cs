using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualAcademy.Persistence.Migrations
{
    public partial class RemoveUnecessarySemesterProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsClosed",
                table: "Semesters");

            migrationBuilder.DropColumn(
                name: "IsCurrent",
                table: "Semesters");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsClosed",
                table: "Semesters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCurrent",
                table: "Semesters",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
