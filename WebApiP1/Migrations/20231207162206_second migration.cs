using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiP1.Migrations
{
    /// <inheritdoc />
    public partial class secondmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TeName",
                table: "Teachers",
                newName: "TeacherName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TeacherName",
                table: "Teachers",
                newName: "TeName");
        }
    }
}
