using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Allatmenhely_API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gondozoks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ContactInfo = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gondozoks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orokbefogadasoks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AdoptionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AnimalId = table.Column<int>(type: "INTEGER", nullable: false),
                    AdopterName = table.Column<string>(type: "TEXT", nullable: false),
                    AdopterContactInfo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orokbefogadasoks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Allatoks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Species = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HealthStatus = table.Column<string>(type: "TEXT", nullable: false),
                    IsAdopted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CareTaker = table.Column<int>(type: "INTEGER", nullable: true),
                    OrokbefogadasokId = table.Column<int>(type: "INTEGER", nullable: false),
                    GondozokId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allatoks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Allatoks_Gondozoks_GondozokId",
                        column: x => x.GondozokId,
                        principalTable: "Gondozoks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Allatoks_Orokbefogadasoks_OrokbefogadasokId",
                        column: x => x.OrokbefogadasokId,
                        principalTable: "Orokbefogadasoks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allatoks_GondozokId",
                table: "Allatoks",
                column: "GondozokId");

            migrationBuilder.CreateIndex(
                name: "IX_Allatoks_OrokbefogadasokId",
                table: "Allatoks",
                column: "OrokbefogadasokId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allatoks");

            migrationBuilder.DropTable(
                name: "Gondozoks");

            migrationBuilder.DropTable(
                name: "Orokbefogadasoks");
        }
    }
}
