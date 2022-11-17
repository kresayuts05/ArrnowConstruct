using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArrnowConstruct.Infrastructure.Migrations
{
    public partial class SeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7125d323-7567-4f56-b27e-6b7044014a37", 0, "Petko DePetkov 71", "Kazanlak", "a5ca711d-72a8-4638-a44b-c91b25b37c23", "Bulgaria", "guest@mail.com", false, "Angel", "Momov", false, null, "ANGEL@MAIL.COM", "ANGEL", "AQAAAAEAACcQAAAAELsa2KdlOmZb2kLzs4GsElCDfwMctt7nOQ6bJYzhuhSc4+BulSwYISerAf86gNgzRQ==", "0888791001", false, "40149396-1d18-464f-99d1-e4456a6718a2", false, "angel" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ae724eb3-355b-48dd-bdaa-c1eaccf666c5", 0, "Edelvais 6 ", "Kazanlak", "006b79c3-45c2-4327-bb8f-6dda8fc895cd", "Bulgaria", "kresa@mail.com", false, "Kresa", "Tsvetkova", false, null, "KRESA@MAIL.COM", "KRESA", "AQAAAAEAACcQAAAAEORhn/CltAnRH5TGXSnB/m2/u6KD1Bix/EUhXiCdmUa/ck/n1BoUJC/hXziiGBUGTw==", "0886121260", false, "1774bca4-d792-420f-b062-e5b0c8fdd78f", false, "kresa" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1, "ae724eb3-355b-48dd-bdaa-c1eaccf666c5" });

            migrationBuilder.InsertData(
                table: "Constructors",
                columns: new[] { "Id", "Salary", "UserId" },
                values: new object[] { 1, 1500m, "7125d323-7567-4f56-b27e-6b7044014a37" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Constructors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7125d323-7567-4f56-b27e-6b7044014a37");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae724eb3-355b-48dd-bdaa-c1eaccf666c5");
        }
    }
}
