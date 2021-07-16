using Microsoft.EntityFrameworkCore.Migrations;

namespace Webtt.Migrations
{
    public partial class CreatingIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "859055ce-8218-4303-aa3e-07f8ae236cc5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b50bc42-c765-4035-b12e-64229e8ed87f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1951467d-3fcb-40d5-804d-ff41929e256a", "90d207b5-4708-46c8-ac4c-b5d77e9fba8f", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dbd3e6b5-8299-4bb2-bdd3-6e9c7ee3c7c9", "2041a6f3-c154-4da5-8375-9d900770da74", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "859055ce-8218-4303-aa3e-07f8ae236cc5", "7bfe2b71-4bc1-48d8-aa23-c9d49764307b", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8b50bc42-c765-4035-b12e-64229e8ed87f", "209cef50-94c6-44da-a2b8-f2ff1caf5c12", "Administrator", "ADMINISTRATOR" });
        }
    }
}
