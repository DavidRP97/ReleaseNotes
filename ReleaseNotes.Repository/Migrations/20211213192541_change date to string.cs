using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReleaseNotes.Repository.Migrations
{
    public partial class changedatetostring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VersionDate",
                table: "Releases",
                type: "text",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "VersionDate",
                table: "ReleasePDVs",
                type: "text",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.UpdateData(
                table: "ReleasePDVs",
                keyColumn: "ReleaseId",
                keyValue: 1L,
                column: "VersionDate",
                value: "13/12/2021");

            migrationBuilder.UpdateData(
                table: "Releases",
                keyColumn: "ReleaseId",
                keyValue: 1L,
                column: "VersionDate",
                value: "13/12/2021");

            migrationBuilder.UpdateData(
                table: "Releases",
                keyColumn: "ReleaseId",
                keyValue: 2L,
                column: "VersionDate",
                value: "13/12/2021");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "VersionDate",
                table: "Releases",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "VersionDate",
                table: "ReleasePDVs",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "ReleasePDVs",
                keyColumn: "ReleaseId",
                keyValue: 1L,
                column: "VersionDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Releases",
                keyColumn: "ReleaseId",
                keyValue: 1L,
                column: "VersionDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Releases",
                keyColumn: "ReleaseId",
                keyValue: 2L,
                column: "VersionDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
