using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ReleaseNotes.Repository.Migrations
{
    public partial class CreatedPowerPDVSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReleasePDVs",
                columns: table => new
                {
                    ReleaseId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VersionNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleasePDVs", x => x.ReleaseId);
                });

            migrationBuilder.CreateTable(
                name: "ModulePDVs",
                columns: table => new
                {
                    ModuleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ModuleName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    ReleaseId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModulePDVs", x => x.ModuleId);
                    table.ForeignKey(
                        name: "FK_ModulePDVs_ReleasePDVs_ReleaseId",
                        column: x => x.ReleaseId,
                        principalTable: "ReleasePDVs",
                        principalColumn: "ReleaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ReleasePDVs",
                columns: new[] { "ReleaseId", "VersionNumber" },
                values: new object[] { 1L, "1.0" });

            migrationBuilder.InsertData(
                table: "ModulePDVs",
                columns: new[] { "ModuleId", "ModuleName", "Notes", "ReleaseId", "Title" },
                values: new object[,]
                {
                    { 1L, "Comercial", "Criado novas funcionalidades", 1L, "Vendas por pedido" },
                    { 2L, "Financeiro", "Adicionado novos meios de pagamento", 1L, "Contas a pagar" },
                    { 3L, "Integrações", "Implementado", 1L, "Scanntech" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModulePDVs_ReleaseId",
                table: "ModulePDVs",
                column: "ReleaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModulePDVs");

            migrationBuilder.DropTable(
                name: "ReleasePDVs");
        }
    }
}
