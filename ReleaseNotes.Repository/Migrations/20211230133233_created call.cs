using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReleaseNotes.Repository.Migrations
{
    public partial class createdcall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUrgent",
                table: "Calls",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PriorityDegree",
                table: "Calls",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Calls",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUrgent",
                table: "Calls");

            migrationBuilder.DropColumn(
                name: "PriorityDegree",
                table: "Calls");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Calls");

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
        }
    }
}
