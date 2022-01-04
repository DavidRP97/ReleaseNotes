using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReleaseNotes.Repository.Migrations
{
    public partial class populatedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Receivers",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Receivers",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Senders",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "SenderEmailConfig",
                keyColumn: "SenderConfigId",
                keyValue: 1L);
        }
    }
}
