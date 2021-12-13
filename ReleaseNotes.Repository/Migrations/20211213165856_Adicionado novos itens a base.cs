using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReleaseNotes.Repository.Migrations
{
    public partial class Adicionadonovositensabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Releases",
                columns: new[] { "ReleaseId", "VersionNumber" },
                values: new object[] { 2L, "2.0" });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "ModuleId", "ModuleName", "Notes", "ReleaseId", "Title" },
                values: new object[,]
                {
                    { 4L, "Fiscal", "Correção na emissão", 2L, "NF Entrada" },
                    { 5L, "Financeiro", "Corrigido Bug", 2L, "Contas a receber" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "ModuleId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "ModuleId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Releases",
                keyColumn: "ReleaseId",
                keyValue: 2L);
        }
    }
}
