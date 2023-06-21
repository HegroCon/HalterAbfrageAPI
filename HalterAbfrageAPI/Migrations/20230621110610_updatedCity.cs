using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HalterAbfrageAPI.Migrations
{
    public partial class updatedCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personen_Stadt_StadtId",
                table: "Personen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stadt",
                table: "Stadt");

            migrationBuilder.DropIndex(
                name: "IX_Personen_StadtId",
                table: "Personen");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Stadt");

            migrationBuilder.DropColumn(
                name: "StadtId",
                table: "Personen");

            migrationBuilder.AddColumn<string>(
                name: "Plz",
                table: "Stadt",
                type: "varchar(5",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StadtPlz",
                table: "Personen",
                type: "varchar(5",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stadt",
                table: "Stadt",
                column: "Plz");

            migrationBuilder.CreateIndex(
                name: "IX_Personen_StadtPlz",
                table: "Personen",
                column: "StadtPlz");

            migrationBuilder.AddForeignKey(
                name: "FK_Personen_Stadt_StadtPlz",
                table: "Personen",
                column: "StadtPlz",
                principalTable: "Stadt",
                principalColumn: "Plz",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personen_Stadt_StadtPlz",
                table: "Personen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stadt",
                table: "Stadt");

            migrationBuilder.DropIndex(
                name: "IX_Personen_StadtPlz",
                table: "Personen");

            migrationBuilder.DropColumn(
                name: "Plz",
                table: "Stadt");

            migrationBuilder.DropColumn(
                name: "StadtPlz",
                table: "Personen");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Stadt",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "StadtId",
                table: "Personen",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stadt",
                table: "Stadt",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Personen_StadtId",
                table: "Personen",
                column: "StadtId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personen_Stadt_StadtId",
                table: "Personen",
                column: "StadtId",
                principalTable: "Stadt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
