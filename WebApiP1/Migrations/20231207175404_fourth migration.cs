using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiP1.Migrations
{
    /// <inheritdoc />
    public partial class fourthmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Branches_BranchId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_BranchId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Teachers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BranchId",
                table: "Teachers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_BranchId",
                table: "Teachers",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Branches_BranchId",
                table: "Teachers",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
