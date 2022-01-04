using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ReleaseNotes.Repository.Migrations
{
    public partial class CreatedEmailConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Receivers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    SenderEmailConfigId = table.Column<long>(type: "bigint", nullable: false),
                    ReceiverId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SenderEmailConfig",
                columns: table => new
                {
                    SenderConfigId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApiKey = table.Column<string>(type: "text", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    SenderId = table.Column<long>(type: "bigint", nullable: false),
                    ReceiverId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SenderEmailConfig", x => x.SenderConfigId);
                });

            migrationBuilder.CreateTable(
                name: "Senders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    SenderEmailConfigId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Senders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Senders_SenderEmailConfig_SenderEmailConfigId",
                        column: x => x.SenderEmailConfigId,
                        principalTable: "SenderEmailConfig",
                        principalColumn: "SenderConfigId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Calls",
                keyColumn: "CallId",
                keyValue: 1L,
                columns: new[] { "Date", "PriorityDegree", "Status" },
                values: new object[] { "terça-feira, 4 de janeiro de 2022", 1, 2 });

            migrationBuilder.UpdateData(
                table: "ReleasePDVs",
                keyColumn: "ReleaseId",
                keyValue: 1L,
                column: "VersionDate",
                value: "04/01/2022");

            migrationBuilder.UpdateData(
                table: "Releases",
                keyColumn: "ReleaseId",
                keyValue: 1L,
                column: "VersionDate",
                value: "04/01/2022");

            migrationBuilder.UpdateData(
                table: "Releases",
                keyColumn: "ReleaseId",
                keyValue: 2L,
                column: "VersionDate",
                value: "04/01/2022");

            migrationBuilder.CreateIndex(
                name: "IX_Receivers_ReceiverId",
                table: "Receivers",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Receivers_SenderEmailConfigId",
                table: "Receivers",
                column: "SenderEmailConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_SenderEmailConfig_SenderId",
                table: "SenderEmailConfig",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Senders_SenderEmailConfigId",
                table: "Senders",
                column: "SenderEmailConfigId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receivers_SenderEmailConfig_ReceiverId",
                table: "Receivers",
                column: "ReceiverId",
                principalTable: "SenderEmailConfig",
                principalColumn: "SenderConfigId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receivers_SenderEmailConfig_SenderEmailConfigId",
                table: "Receivers",
                column: "SenderEmailConfigId",
                principalTable: "SenderEmailConfig",
                principalColumn: "SenderConfigId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SenderEmailConfig_Senders_SenderId",
                table: "SenderEmailConfig",
                column: "SenderId",
                principalTable: "Senders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Senders_SenderEmailConfig_SenderEmailConfigId",
                table: "Senders");

            migrationBuilder.DropTable(
                name: "Receivers");

            migrationBuilder.DropTable(
                name: "SenderEmailConfig");

            migrationBuilder.DropTable(
                name: "Senders");

            migrationBuilder.UpdateData(
                table: "Calls",
                keyColumn: "CallId",
                keyValue: 1L,
                columns: new[] { "Date", "PriorityDegree", "Status" },
                values: new object[] { "quinta-feira, 30 de dezembro de 2021", 0, 1 });

            migrationBuilder.UpdateData(
                table: "ReleasePDVs",
                keyColumn: "ReleaseId",
                keyValue: 1L,
                column: "VersionDate",
                value: "30/12/2021");

            migrationBuilder.UpdateData(
                table: "Releases",
                keyColumn: "ReleaseId",
                keyValue: 1L,
                column: "VersionDate",
                value: "30/12/2021");

            migrationBuilder.UpdateData(
                table: "Releases",
                keyColumn: "ReleaseId",
                keyValue: 2L,
                column: "VersionDate",
                value: "30/12/2021");
        }
    }
}
