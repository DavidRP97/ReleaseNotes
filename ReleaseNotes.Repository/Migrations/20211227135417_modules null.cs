using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReleaseNotes.Repository.Migrations
{
    public partial class modulesnull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ReleasePDVs",
                keyColumn: "ReleaseId",
                keyValue: 1L,
                column: "VersionDate",
                value: "27/12/2021");

            migrationBuilder.UpdateData(
                table: "Releases",
                keyColumn: "ReleaseId",
                keyValue: 1L,
                column: "VersionDate",
                value: "27/12/2021");

            migrationBuilder.UpdateData(
                table: "Releases",
                keyColumn: "ReleaseId",
                keyValue: 2L,
                column: "VersionDate",
                value: "27/12/2021");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ReleasePDVs",
                keyColumn: "ReleaseId",
                keyValue: 1L,
                column: "VersionDate",
                value: "23/12/2021");

            migrationBuilder.UpdateData(
                table: "Releases",
                keyColumn: "ReleaseId",
                keyValue: 1L,
                column: "VersionDate",
                value: "23/12/2021");

            migrationBuilder.UpdateData(
                table: "Releases",
                keyColumn: "ReleaseId",
                keyValue: 2L,
                column: "VersionDate",
                value: "23/12/2021");
        }
    }
}
