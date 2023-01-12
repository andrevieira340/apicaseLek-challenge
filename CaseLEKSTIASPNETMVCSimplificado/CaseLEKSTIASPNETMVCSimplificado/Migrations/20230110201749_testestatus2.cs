using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseLEKSTIASPNETMVCSimplificado.Migrations
{
    public partial class testestatus2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimentations_EntryOrExitStatus_EntryOrExitStatusId",
                table: "Movimentations");

            migrationBuilder.DropTable(
                name: "EntryOrExitStatus");

            migrationBuilder.DropIndex(
                name: "IX_Movimentations_EntryOrExitStatusId",
                table: "Movimentations");

            migrationBuilder.DropColumn(
                name: "EntryOrExitStatusId",
                table: "Movimentations");

            migrationBuilder.AddColumn<string>(
                name: "EntryOrExitStatus",
                table: "Movimentations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntryOrExitStatus",
                table: "Movimentations");

            migrationBuilder.AddColumn<int>(
                name: "EntryOrExitStatusId",
                table: "Movimentations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EntryOrExitStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryOrExitStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movimentations_EntryOrExitStatusId",
                table: "Movimentations",
                column: "EntryOrExitStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentations_EntryOrExitStatus_EntryOrExitStatusId",
                table: "Movimentations",
                column: "EntryOrExitStatusId",
                principalTable: "EntryOrExitStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
