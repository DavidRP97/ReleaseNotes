using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReleaseNotes.Web.Migrations
{
    public partial class addpropertis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21c32123-2d21-4963-9983-5ddd5f82c96a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5eae44e8-3c67-47a4-a9d0-d93ecaddc880");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8be427dd-8c25-477f-a67a-8bbfe806a791");

            migrationBuilder.AddColumn<bool>(
                name: "FirstAccess",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3675be63-61a7-4c22-8c91-6a2fe64878f5", "93f2885f-4ca0-4063-92bb-1e892cce76b5", "Usuario", "USUARIO" },
                    { "bb662d67-194c-4881-a3fb-ff976c6074b8", "5aca7af8-29fd-4882-9463-eb4b808fb911", "Admin", "ADMIN" },
                    { "dfe00b00-3c0f-468b-8a2c-db9a50724195", "19502e1c-cf12-4f1a-ad02-6bfdaaf7b791", "Cliente", "CLIENTE" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3675be63-61a7-4c22-8c91-6a2fe64878f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb662d67-194c-4881-a3fb-ff976c6074b8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfe00b00-3c0f-468b-8a2c-db9a50724195");

            migrationBuilder.DropColumn(
                name: "FirstAccess",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "21c32123-2d21-4963-9983-5ddd5f82c96a", "38f0110c-94bd-46aa-a255-740de42c3158", "Usuario", "USUARIO" },
                    { "5eae44e8-3c67-47a4-a9d0-d93ecaddc880", "de883039-d587-4e12-8151-c589b2db8a5e", "Admin", "ADMIN" },
                    { "8be427dd-8c25-477f-a67a-8bbfe806a791", "83e06703-c670-473e-9ef3-177225ead517", "Cliente", "CLIENTE" }
                });
        }
    }
}
