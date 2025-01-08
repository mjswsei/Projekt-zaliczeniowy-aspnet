using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt_zaliczeniowy_aspnet.Migrations
{
    /// <inheritdoc />
    public partial class lecturer_setup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lecturer",
                table: "Lecture");

            migrationBuilder.AddColumn<Guid>(
                name: "LecturerId",
                table: "Lecture",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Lecturer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturer", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lecture_LecturerId",
                table: "Lecture",
                column: "LecturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lecture_Lecturer_LecturerId",
                table: "Lecture",
                column: "LecturerId",
                principalTable: "Lecturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lecture_Lecturer_LecturerId",
                table: "Lecture");

            migrationBuilder.DropTable(
                name: "Lecturer");

            migrationBuilder.DropIndex(
                name: "IX_Lecture_LecturerId",
                table: "Lecture");

            migrationBuilder.DropColumn(
                name: "LecturerId",
                table: "Lecture");

            migrationBuilder.AddColumn<string>(
                name: "Lecturer",
                table: "Lecture",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
