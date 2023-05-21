using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPNetCore_EF_Attendances.Migrations
{
    public partial class PropertiesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Naam",
                table: "Students",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Naam",
                table: "Courses",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Students",
                newName: "Naam");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Courses",
                newName: "Naam");
        }
    }
}
