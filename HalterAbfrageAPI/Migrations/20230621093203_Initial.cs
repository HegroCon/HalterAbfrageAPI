using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HalterAbfrageAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stadt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    Bundesland = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    Vorname = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    StrasseHausnummer = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StadtId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personen_Stadt_StadtId",
                        column: x => x.StadtId,
                        principalTable: "Stadt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fahrzeuge",
                columns: table => new
                {
                    Kennzeichen = table.Column<string>(type: "varchar(15)", nullable: false),
                    Marke = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    Kategory = table.Column<string>(type: "varchar(50)", nullable: false),
                    Farbe = table.Column<string>(type: "varchar(100)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fahrzeuge", x => x.Kennzeichen);
                    table.ForeignKey(
                        name: "FK_Fahrzeuge_Personen_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Personen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fahrzeuge_PersonId",
                table: "Fahrzeuge",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Personen_StadtId",
                table: "Personen",
                column: "StadtId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fahrzeuge");

            migrationBuilder.DropTable(
                name: "Personen");

            migrationBuilder.DropTable(
                name: "Stadt");
        }
    }
}
