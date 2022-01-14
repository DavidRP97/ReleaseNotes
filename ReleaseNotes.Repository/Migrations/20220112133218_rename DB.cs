using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ReleaseNotes.Repository.Migrations
{
    public partial class renameDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReleasePDVs",
                columns: table => new
                {
                    ReleaseId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VersionDate = table.Column<string>(type: "text", nullable: false),
                    VersionNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleasePDVs", x => x.ReleaseId);
                });

            migrationBuilder.CreateTable(
                name: "Releases",
                columns: table => new
                {
                    ReleaseId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VersionNumber = table.Column<string>(type: "text", nullable: false),
                    VersionDate = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Releases", x => x.ReleaseId);
                });

            migrationBuilder.CreateTable(
                name: "SenderEmailConfig",
                columns: table => new
                {
                    SenderConfigId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SenderEmailConfig", x => x.SenderConfigId);
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

            migrationBuilder.CreateTable(
                name: "Modules",
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
                    table.PrimaryKey("PK_Modules", x => x.ModuleId);
                    table.ForeignKey(
                        name: "FK_Modules_Releases_ReleaseId",
                        column: x => x.ReleaseId,
                        principalTable: "Releases",
                        principalColumn: "ReleaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receivers",
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
                    table.PrimaryKey("PK_Receivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receivers_SenderEmailConfig_SenderEmailConfigId",
                        column: x => x.SenderEmailConfigId,
                        principalTable: "SenderEmailConfig",
                        principalColumn: "SenderConfigId",
                        onDelete: ReferentialAction.Cascade);
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
                });

            migrationBuilder.CreateTable(
                name: "Calls",
                columns: table => new
                {
                    CallId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FeedbackId = table.Column<long>(type: "bigint", nullable: true),
                    IsUrgent = table.Column<bool>(type: "boolean", nullable: false),
                    PriorityDegree = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Software = table.Column<int>(type: "integer", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Detail = table.Column<string>(type: "text", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calls", x => x.CallId);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    FeedbackId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FeedbackDate = table.Column<string>(type: "text", nullable: true),
                    FeedbackFrom = table.Column<int>(type: "integer", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Details = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    FeedbackPositive = table.Column<bool>(type: "boolean", nullable: false),
                    OpenCall = table.Column<bool>(type: "boolean", nullable: false),
                    CallId = table.Column<long>(type: "bigint", nullable: true),
                    ModulePdvId = table.Column<long>(type: "bigint", nullable: true),
                    ModulePowerServerId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Calls_CallId",
                        column: x => x.CallId,
                        principalTable: "Calls",
                        principalColumn: "CallId");
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

            migrationBuilder.InsertData(
                table: "SenderEmailConfig",
                column: "SenderConfigId",
                value: 1L);

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

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_CallId",
                table: "Attachments",
                column: "CallId");

            migrationBuilder.CreateIndex(
                name: "IX_Calls_FeedbackId",
                table: "Calls",
                column: "FeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_CallId",
                table: "Feedbacks",
                column: "CallId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ModulePdvId",
                table: "Feedbacks",
                column: "ModulePdvId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ModulePowerServerId",
                table: "Feedbacks",
                column: "ModulePowerServerId");

            migrationBuilder.CreateIndex(
                name: "IX_ModulePDVs_ReleaseId",
                table: "ModulePDVs",
                column: "ReleaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_ReleaseId",
                table: "Modules",
                column: "ReleaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Receivers_SenderEmailConfigId",
                table: "Receivers",
                column: "SenderEmailConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_Senders_SenderEmailConfigId",
                table: "Senders",
                column: "SenderEmailConfigId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Calls_CallId",
                table: "Attachments",
                column: "CallId",
                principalTable: "Calls",
                principalColumn: "CallId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_Feedbacks_FeedbackId",
                table: "Calls",
                column: "FeedbackId",
                principalTable: "Feedbacks",
                principalColumn: "FeedbackId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Calls_CallId",
                table: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "Receivers");

            migrationBuilder.DropTable(
                name: "Senders");

            migrationBuilder.DropTable(
                name: "SenderEmailConfig");

            migrationBuilder.DropTable(
                name: "Calls");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "ModulePDVs");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "ReleasePDVs");

            migrationBuilder.DropTable(
                name: "Releases");
        }
    }
}
