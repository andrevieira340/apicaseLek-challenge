using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseLEKSTIASPNETMVCSimplificado.Migrations
{
    public partial class includeStockTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovimentationsId = table.Column<int>(type: "int", nullable: false),
                    MovimentationId = table.Column<int>(type: "int", nullable: true),
                    TotalStock = table.Column<int>(type: "int", nullable: false),
                    QuantityEntry = table.Column<int>(type: "int", nullable: false),
                    QuantityExit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stock_Movimentations_MovimentationId",
                        column: x => x.MovimentationId,
                        principalTable: "Movimentations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stock_MovimentationId",
                table: "Stock",
                column: "MovimentationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stock");
        }
    }
}
