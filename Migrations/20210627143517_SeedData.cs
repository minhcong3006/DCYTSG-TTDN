using Microsoft.EntityFrameworkCore.Migrations;

namespace Webtt.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4dc673b1-6c1a-41b9-ac20-d9bd63b6bb20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1211982-6498-44bd-8b4a-de9e816f8191");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "859055ce-8218-4303-aa3e-07f8ae236cc5", "7bfe2b71-4bc1-48d8-aa23-c9d49764307b", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8b50bc42-c765-4035-b12e-64229e8ed87f", "209cef50-94c6-44da-a2b8-f2ff1caf5c12", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "e1211982-6498-44bd-8b4a-de9e816f8191", "7a9caa01-f7d8-4074-9e79-2e43736e43ce", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4dc673b1-6c1a-41b9-ac20-d9bd63b6bb20", "c5ce30d5-b860-4c2b-bcf3-651dbe116553", "Administrator", "ADMINISTRATOR" });
        }
    }
}
