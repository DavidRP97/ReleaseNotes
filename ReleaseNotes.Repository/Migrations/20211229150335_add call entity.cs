using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ReleaseNotes.Repository.Migrations
{
    public partial class addcallentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CallId",
                table: "Feedbacks",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OpenCall",
                table: "Feedbacks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Calls",
                columns: table => new
                {
                    CallId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FeedbackId = table.Column<long>(type: "bigint", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Detail = table.Column<string>(type: "text", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calls", x => x.CallId);
                    table.ForeignKey(
                        name: "FK_Calls_Feedbacks_FeedbackId",
                        column: x => x.FeedbackId,
                        principalTable: "Feedbacks",
                        principalColumn: "FeedbackId");
                });

            migrationBuilder.UpdateData(
                table: "ReleasePDVs",
                keyColumn: "ReleaseId",
                keyValue: 1L,
                column: "VersionDate",
                value: "29/12/2021");

            migrationBuilder.UpdateData(
                table: "Releases",
                keyColumn: "ReleaseId",
                keyValue: 1L,
                column: "VersionDate",
                value: "29/12/2021");

            migrationBuilder.UpdateData(
                table: "Releases",
                keyColumn: "ReleaseId",
                keyValue: 2L,
                column: "VersionDate",
                value: "29/12/2021");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_CallId",
                table: "Feedbacks",
                column: "CallId");

            migrationBuilder.CreateIndex(
                name: "IX_Calls_FeedbackId",
                table: "Calls",
                column: "FeedbackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Calls_CallId",
                table: "Feedbacks",
                column: "CallId",
                principalTable: "Calls",
                principalColumn: "CallId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Calls_CallId",
                table: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Calls");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_CallId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "CallId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "OpenCall",
                table: "Feedbacks");

            migrationBuilder.UpdateData(
                table: "ReleasePDVs",
                keyColumn: "ReleaseId",
                keyValue: 1L,
                column: "VersionDate",
                value: "28/12/2021");

            migrationBuilder.UpdateData(
                table: "Releases",
                keyColumn: "ReleaseId",
                keyValue: 1L,
                column: "VersionDate",
                value: "28/12/2021");

            migrationBuilder.UpdateData(
                table: "Releases",
                keyColumn: "ReleaseId",
                keyValue: 2L,
                column: "VersionDate",
                value: "28/12/2021");
        }
    }
}
