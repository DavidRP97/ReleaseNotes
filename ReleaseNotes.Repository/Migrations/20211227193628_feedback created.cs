using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ReleaseNotes.Repository.Migrations
{
    public partial class feedbackcreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    FeedbackId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FeedbackFrom = table.Column<int>(type: "integer", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Details = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    FeedbackPositive = table.Column<bool>(type: "boolean", nullable: false),
                    ModulePowerServerId = table.Column<long>(type: "bigint", nullable: true),
                    ModulePdvId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_Feedbacks_ModulePDVs_ModulePdvId",
                        column: x => x.ModulePdvId,
                        principalTable: "ModulePDVs",
                        principalColumn: "ModuleId");
                    table.ForeignKey(
                        name: "FK_Feedbacks_Modules_ModulePowerServerId",
                        column: x => x.ModulePowerServerId,
                        principalTable: "Modules",
                        principalColumn: "ModuleId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ModulePdvId",
                table: "Feedbacks",
                column: "ModulePdvId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ModulePowerServerId",
                table: "Feedbacks",
                column: "ModulePowerServerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");
        }
    }
}
