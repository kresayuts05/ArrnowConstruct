using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArrnowConstruct.Infrastructure.Migrations
{
    public partial class SeedingRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "25f73449-f9e8-40b4-87ee-93fc6c242339", "e6f93910-6cd0-4cfb-94cd-e2f7bf98c794", "Client", "CLIENT" },
                    { "eed2d778-89cf-4c3c-a710-c8d61811f4c7", "7068c662-1ae0-4141-81f2-1a0fbb9ed5c3", "Constructor", "CONSTRUCTOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7125d323-7567-4f56-b27e-6b7044014a37",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7c9da8a-e6fd-4b2c-bed3-9b30f0fa91de", "AQAAAAEAACcQAAAAELXkOHEmQYevpLYeiyEvDpA9WJG3M45puVuQpR+WXg80HwNlJdtBoqoDGk0nTYL16g==", "101555f3-9ee2-4f69-9f63-ebf3f8b80e62" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae724eb3-355b-48dd-bdaa-c1eaccf666c5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe0d10ef-2de8-46bf-9df9-b94e927f631d", "AQAAAAEAACcQAAAAEGcH8Is7hAyBcv7HAa4+MYB2PyNUcjD1jlLmLD8IeoDko+abhIYdk3mO8zTCkTerKg==", "078c3d76-8396-40d7-a0d4-4743328961ff" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25f73449-f9e8-40b4-87ee-93fc6c242339");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eed2d778-89cf-4c3c-a710-c8d61811f4c7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7125d323-7567-4f56-b27e-6b7044014a37",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5ca711d-72a8-4638-a44b-c91b25b37c23", "AQAAAAEAACcQAAAAELsa2KdlOmZb2kLzs4GsElCDfwMctt7nOQ6bJYzhuhSc4+BulSwYISerAf86gNgzRQ==", "40149396-1d18-464f-99d1-e4456a6718a2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae724eb3-355b-48dd-bdaa-c1eaccf666c5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "006b79c3-45c2-4327-bb8f-6dda8fc895cd", "AQAAAAEAACcQAAAAEORhn/CltAnRH5TGXSnB/m2/u6KD1Bix/EUhXiCdmUa/ck/n1BoUJC/hXziiGBUGTw==", "1774bca4-d792-420f-b062-e5b0c8fdd78f" });
        }
    }
}
