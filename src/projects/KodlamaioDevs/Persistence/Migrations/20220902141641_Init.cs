﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DevelopmentLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevelopmentLanguages", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DevelopmentLanguages",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Java" });

            migrationBuilder.InsertData(
                table: "DevelopmentLanguages",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "C#" });

            migrationBuilder.InsertData(
                table: "DevelopmentLanguages",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Python" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DevelopmentLanguages");
        }
    }
}
