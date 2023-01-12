using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseLEKSTIASPNETMVCSimplificado.Migrations
{
    public partial class AddMigrationMovimentations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovimentationsId",
                table: "Commodities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Movimentations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntryOrExitEnum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commodities_MovimentationsId",
                table: "Commodities",
                column: "MovimentationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commodities_Movimentations_MovimentationsId",
                table: "Commodities",
                column: "MovimentationsId",
                principalTable: "Movimentations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commodities_Movimentations_MovimentationsId",
                table: "Commodities");

            migrationBuilder.DropTable(
                name: "Movimentations");

            migrationBuilder.DropIndex(
                name: "IX_Commodities_MovimentationsId",
                table: "Commodities");

            migrationBuilder.DropColumn(
                name: "MovimentationsId",
                table: "Commodities");
        }
    }
}
