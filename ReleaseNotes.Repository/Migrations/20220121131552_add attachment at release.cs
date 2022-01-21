using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ReleaseNotes.Repository.Migrations
{
    public partial class addattachmentatrelease : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ZipFilesPdv",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FilePath = table.Column<string>(type: "text", nullable: false),
                    ReleasePdvId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZipFilesPdv", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZipFilesPdv_ReleasePDVs_ReleasePdvId",
                        column: x => x.ReleasePdvId,
                        principalTable: "ReleasePDVs",
                        principalColumn: "ReleaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZipFilesPowerServer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FilePath = table.Column<string>(type: "text", nullable: false),
                    ReleasePowerServerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZipFilesPowerServer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZipFilesPowerServer_Releases_ReleasePowerServerId",
                        column: x => x.ReleasePowerServerId,
                        principalTable: "Releases",
                        principalColumn: "ReleaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZipFilesPdv_ReleasePdvId",
                table: "ZipFilesPdv",
                column: "ReleasePdvId");

            migrationBuilder.CreateIndex(
                name: "IX_ZipFilesPowerServer_ReleasePowerServerId",
                table: "ZipFilesPowerServer",
                column: "ReleasePowerServerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZipFilesPdv");

            migrationBuilder.DropTable(
                name: "ZipFilesPowerServer");
        }
    }
}
