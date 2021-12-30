using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReleaseNotes.Repository.Migrations
{
    public partial class adddataatcall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Software",
                table: "Calls",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Calls",
                columns: new[] { "CallId", "Date", "Detail", "Email", "FeedbackId", "IsUrgent", "PriorityDegree", "Software", "Status", "Subject", "UserName" },
                values: new object[] { 1L, "quinta-feira, 30 de dezembro de 2021", "Isso é um teste", "desenvolvimento04@supercontrole.com", null, true, 0, 1, 1, "TESTE", "David Paulino" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "CallId",
                keyValue: 1L);

            migrationBuilder.DropColumn(
                name: "Software",
                table: "Calls");
        }
    }
}
