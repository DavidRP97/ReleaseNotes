using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ReleaseNotes.Repository.Migrations
{
    public partial class addattachments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "CallId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ModulePDVs",
                keyColumn: "ModuleId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ModulePDVs",
                keyColumn: "ModuleId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ModulePDVs",
                keyColumn: "ModuleId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "ModuleId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "ModuleId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "ModuleId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "ModuleId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "ModuleId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Receivers",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Receivers",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Senders",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ReleasePDVs",
                keyColumn: "ReleaseId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Releases",
                keyColumn: "ReleaseId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Releases",
                keyColumn: "ReleaseId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "SenderEmailConfig",
                keyColumn: "SenderConfigId",
                keyValue: 1L);

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    File = table.Column<string>(type: "text", nullable: false),
                    CallId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_Calls_CallId",
                        column: x => x.CallId,
                        principalTable: "Calls",
                        principalColumn: "CallId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_CallId",
                table: "Attachments",
                column: "CallId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.InsertData(
                table: "Calls",
                columns: new[] { "CallId", "Date", "Detail", "Email", "FeedbackId", "IsUrgent", "PriorityDegree", "Software", "Status", "Subject", "UserName" },
                values: new object[] { 1L, "terça-feira, 4 de janeiro de 2022", "Isso é um teste", "desenvolvimento04@supercontrole.com", null, true, 1, 1, 2, "TESTE", "David Paulino" });

            migrationBuilder.InsertData(
                table: "ReleasePDVs",
                columns: new[] { "ReleaseId", "VersionDate", "VersionNumber" },
                values: new object[] { 1L, "04/01/2022", "1.0" });

            migrationBuilder.InsertData(
                table: "Releases",
                columns: new[] { "ReleaseId", "VersionDate", "VersionNumber" },
                values: new object[,]
                {
                    { 1L, "04/01/2022", "1.0" },
                    { 2L, "04/01/2022", "2.0" }
                });

            migrationBuilder.InsertData(
                table: "SenderEmailConfig",
                column: "SenderConfigId",
                value: 1L);

            migrationBuilder.InsertData(
                table: "ModulePDVs",
                columns: new[] { "ModuleId", "ModuleName", "Notes", "ReleaseId", "Title" },
                values: new object[,]
                {
                    { 1L, "Comercial", "Criado novas funcionalidades", 1L, "Vendas por pedido" },
                    { 2L, "Financeiro", "Adicionado novos meios de pagamento", 1L, "Contas a pagar" },
                    { 3L, "Integrações", "Implementado", 1L, "Scanntech" }
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "ModuleId", "ModuleName", "Notes", "ReleaseId", "Title" },
                values: new object[,]
                {
                    { 1L, "Comercial", "Criado novas funcionalidades", 1L, "Vendas por pedido" },
                    { 2L, "Financeiro", "Adicionado novos meios de pagamento", 1L, "Contas a pagar" },
                    { 3L, "Integrações", "Implementado", 1L, "Scanntech" },
                    { 4L, "Fiscal", "Correção na emissão", 2L, "NF Entrada" },
                    { 5L, "Financeiro", "Corrigido Bug", 2L, "Contas a receber" }
                });

            migrationBuilder.InsertData(
                table: "Receivers",
                columns: new[] { "Id", "Email", "Name", "SenderEmailConfigId" },
                values: new object[,]
                {
                    { 1L, "d.rodrigues0505@gmail.com", "David Rodrigues", 1L },
                    { 2L, "analise@supercontrole.com", "Rogério Trevisan", 1L }
                });

            migrationBuilder.InsertData(
                table: "Senders",
                columns: new[] { "Id", "Email", "Name", "SenderEmailConfigId" },
                values: new object[] { 1L, "desenvolvimento04@supercontrole.com", "SuperControle Chamados", 1L });
        }
    }
}
