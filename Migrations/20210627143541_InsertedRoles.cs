using Microsoft.EntityFrameworkCore.Migrations;

namespace Webtt.Migrations
{
    public partial class InsertedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1951467d-3fcb-40d5-804d-ff41929e256a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbd3e6b5-8299-4bb2-bdd3-6e9c7ee3c7c9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d201bea5-589d-45fa-88d9-71bc74377878", "055f08f8-689e-40bc-ade3-c377f0798268", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a4c95d57-6de8-418c-b140-8777f2d50030", "8eb06036-8e92-4de9-a6d0-390ac2a82261", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4c95d57-6de8-418c-b140-8777f2d50030");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d201bea5-589d-45fa-88d9-71bc74377878");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1951467d-3fcb-40d5-804d-ff41929e256a", "90d207b5-4708-46c8-ac4c-b5d77e9fba8f", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dbd3e6b5-8299-4bb2-bdd3-6e9c7ee3c7c9", "2041a6f3-c154-4da5-8375-9d900770da74", "Administrator", "ADMINISTRATOR" });
        }
    }
}
