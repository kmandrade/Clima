using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Climates",
                columns: table => new
                {
                    IdClima = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCidade = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Climates", x => x.IdClima);
                });

            migrationBuilder.CreateTable(
                name: "Temp",
                columns: table => new
                {
                    IdTemp = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    temp_min = table.Column<double>(nullable: false),
                    temp_max = table.Column<double>(nullable: false),
                    humidity = table.Column<int>(nullable: true),
                    pressure = table.Column<int>(nullable: true),
                    IdClima = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temp", x => x.IdTemp);
                    table.ForeignKey(
                        name: "FK_Temp_Climates_IdClima",
                        column: x => x.IdClima,
                        principalTable: "Climates",
                        principalColumn: "IdClima",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Temp_IdClima",
                table: "Temp",
                column: "IdClima");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Temp");

            migrationBuilder.DropTable(
                name: "Climates");
        }
    }
}
