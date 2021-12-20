using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReleaseNotes.Repository.Migrations
{
    public partial class Addidentityroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c25e65a7-6732-4559-acaf-76d85d245a99", "37ab6981-1f6d-4993-a499-d60b855f7066", "Cliente", "CLIENTE" },
                    { "d0f84d32-c450-4ee6-a50f-9ff0d29e3b9a", "c7f0bbbe-aad6-45f6-bf9d-963b2d97fa11", "Admin", "ADMIN" },
                    { "f6d54e90-9fe4-4aa2-a1ce-287a5aea33a2", "bd21d0c9-38cb-43ce-824f-0a3fd81f5e76", "Usuario", "USUARIO" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c25e65a7-6732-4559-acaf-76d85d245a99");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0f84d32-c450-4ee6-a50f-9ff0d29e3b9a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6d54e90-9fe4-4aa2-a1ce-287a5aea33a2");
        }
    }
}
