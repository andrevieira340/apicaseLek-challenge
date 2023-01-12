using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseLEKSTIASPNETMVCSimplificado.Migrations
{
    public partial class testeEntryOrExit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EntryOrExitStatus",
                table: "Movimentations",
                newName: "EntryOrExit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EntryOrExit",
                table: "Movimentations",
                newName: "EntryOrExitStatus");
        }
    }
}
