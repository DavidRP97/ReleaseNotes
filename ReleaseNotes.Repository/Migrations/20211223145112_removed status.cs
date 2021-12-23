﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReleaseNotes.Repository.Migrations
{
    public partial class removedstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ModulePDVs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Modules",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "ModulePDVs",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ModulePDVs",
                keyColumn: "ModuleId",
                keyValue: 1L,
                column: "Status",
                value: "Alterações a Serem Feitas");

            migrationBuilder.UpdateData(
                table: "ModulePDVs",
                keyColumn: "ModuleId",
                keyValue: 2L,
                column: "Status",
                value: "Estável");

            migrationBuilder.UpdateData(
                table: "ModulePDVs",
                keyColumn: "ModuleId",
                keyValue: 3L,
                column: "Status",
                value: "Estável");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "ModuleId",
                keyValue: 1L,
                column: "Status",
                value: "Estável");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "ModuleId",
                keyValue: 2L,
                column: "Status",
                value: "Retornar para Desenvolvimento");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "ModuleId",
                keyValue: 3L,
                column: "Status",
                value: "Estável");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "ModuleId",
                keyValue: 4L,
                column: "Status",
                value: "Alterações a Serem Feitas");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "ModuleId",
                keyValue: 5L,
                column: "Status",
                value: "Estável");
        }
    }
}
