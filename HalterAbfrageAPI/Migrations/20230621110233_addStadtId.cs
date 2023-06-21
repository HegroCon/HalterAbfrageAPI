using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HalterAbfrageAPI.Migrations
{
    public partial class addStadtId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personen_Stadt_StadtPlz",
                table: "Personen");

            migrationBuilder.RenameColumn(
                name: "StadtPlz",
                table: "Personen",
                newName: "StadtId");

            migrationBuilder.RenameIndex(
                name: "IX_Personen_StadtPlz",
                table: "Personen",
                newName: "IX_Personen_StadtId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personen_Stadt_StadtId",
                table: "Personen",
                column: "StadtId",
                principalTable: "Stadt",
                principalColumn: "Plz",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personen_Stadt_StadtId",
                table: "Personen");

            migrationBuilder.RenameColumn(
                name: "StadtId",
                table: "Personen",
                newName: "StadtPlz");

            migrationBuilder.RenameIndex(
                name: "IX_Personen_StadtId",
                table: "Personen",
                newName: "IX_Personen_StadtPlz");

            migrationBuilder.AddForeignKey(
                name: "FK_Personen_Stadt_StadtPlz",
                table: "Personen",
                column: "StadtPlz",
                principalTable: "Stadt",
                principalColumn: "Plz",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
