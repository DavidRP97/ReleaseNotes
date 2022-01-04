using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReleaseNotes.Repository.Migrations
{
    public partial class Removefieldsfromemailsender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApiKey",
                table: "SenderEmailConfig");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "SenderEmailConfig");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "SenderEmailConfig");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApiKey",
                table: "SenderEmailConfig",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "SenderEmailConfig",
                type: "character varying(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "SenderEmailConfig",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
