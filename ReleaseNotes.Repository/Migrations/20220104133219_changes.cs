using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReleaseNotes.Repository.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receivers_SenderEmailConfig_ReceiverId",
                table: "Receivers");

            migrationBuilder.DropForeignKey(
                name: "FK_SenderEmailConfig_Senders_SenderId",
                table: "SenderEmailConfig");

            migrationBuilder.DropIndex(
                name: "IX_Senders_SenderEmailConfigId",
                table: "Senders");

            migrationBuilder.DropIndex(
                name: "IX_SenderEmailConfig_SenderId",
                table: "SenderEmailConfig");

            migrationBuilder.DropIndex(
                name: "IX_Receivers_ReceiverId",
                table: "Receivers");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "SenderEmailConfig");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "SenderEmailConfig");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Receivers");

            migrationBuilder.CreateIndex(
                name: "IX_Senders_SenderEmailConfigId",
                table: "Senders",
                column: "SenderEmailConfigId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Senders_SenderEmailConfigId",
                table: "Senders");

            migrationBuilder.AddColumn<long>(
                name: "ReceiverId",
                table: "SenderEmailConfig",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SenderId",
                table: "SenderEmailConfig",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ReceiverId",
                table: "Receivers",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Senders_SenderEmailConfigId",
                table: "Senders",
                column: "SenderEmailConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_SenderEmailConfig_SenderId",
                table: "SenderEmailConfig",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Receivers_ReceiverId",
                table: "Receivers",
                column: "ReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receivers_SenderEmailConfig_ReceiverId",
                table: "Receivers",
                column: "ReceiverId",
                principalTable: "SenderEmailConfig",
                principalColumn: "SenderConfigId");

            migrationBuilder.AddForeignKey(
                name: "FK_SenderEmailConfig_Senders_SenderId",
                table: "SenderEmailConfig",
                column: "SenderId",
                principalTable: "Senders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
