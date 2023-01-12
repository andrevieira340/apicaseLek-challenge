using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseLEKSTIASPNETMVCSimplificado.Migrations
{
    public partial class newIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commodities_Movimentations_MovimentationsId",
                table: "Commodities");

            migrationBuilder.DropIndex(
                name: "IX_Commodities_MovimentationsId",
                table: "Commodities");

            migrationBuilder.DropColumn(
                name: "MovimentationsId",
                table: "Commodities");

            migrationBuilder.AddColumn<string>(
                name: "Commodities",
                table: "Movimentations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Commodities",
                table: "Movimentations");

            migrationBuilder.AddColumn<int>(
                name: "MovimentationsId",
                table: "Commodities",
                type: "int",
                nullable: true);

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
    }
}
