using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArrnowConstruct.Infrastructure.Migrations
{
    public partial class SeedAdministration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25f73449-f9e8-40b4-87ee-93fc6c242339",
                column: "ConcurrencyStamp",
                value: "fc39adaa-2fd1-4fc1-a827-c921afac7b1c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eed2d778-89cf-4c3c-a710-c8d61811f4c7",
                column: "ConcurrencyStamp",
                value: "905f661e-3505-4e8f-be38-c7b3d5ea25e5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4033acf9-98f0-49e3-aafc-fd4fcb71c67e", "b529f3d0-c1a4-4aac-9163-11a51bb7b5ae", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7125d323-7567-4f56-b27e-6b7044014a37",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c1e00fe-f3ad-4e69-9a7d-d05e048796c3", "AQAAAAEAACcQAAAAEK+h/GdMG5uxdxRr1CkRJaKodA+DO1WFcNgkgp2bBfuhJOvQAaUjGhN1oCcsQ+6lzw==", "bd5e641a-69f8-4e5a-8431-ac90e779384c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae724eb3-355b-48dd-bdaa-c1eaccf666c5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cce6e70d-449b-416c-86ca-89b96371de79", "AQAAAAEAACcQAAAAEMNEMfGYQziPY9uq/BCXsUtm5aCTLJWwLfX0dSM6ieyzIVtCw0hlILoTVIvb6pH6rw==", "e968a69a-cc32-412c-be8d-f9de5bfee52d" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "babdaf39-3545-48e1-877e-13d4bb4d597f", 0, "Graf Ignatiev 6 ", "Kazanlak", "4a4428b0-14d4-4309-93db-5367cbb9b826", "Bulgaria", "nikol@mail.com", false, "Nikol", "Grueva", false, null, "NIKOL@MAIL.COM", "NIKOL", "AQAAAAEAACcQAAAAEPviDj6PsVaePn/YGafjm+ZNfT8kJSeOuGGXE4MRwq5UHupWgbYGVCynB9SacC7CwA==", "0886121261", false, "17ac489a-6631-404c-a24e-320a8c7bd95f", false, "nikol" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4033acf9-98f0-49e3-aafc-fd4fcb71c67e", "ae724eb3-355b-48dd-bdaa-c1eaccf666c5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4033acf9-98f0-49e3-aafc-fd4fcb71c67e", "ae724eb3-355b-48dd-bdaa-c1eaccf666c5" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "babdaf39-3545-48e1-877e-13d4bb4d597f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4033acf9-98f0-49e3-aafc-fd4fcb71c67e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25f73449-f9e8-40b4-87ee-93fc6c242339",
                column: "ConcurrencyStamp",
                value: "cfd3abbd-a746-43b4-ba87-cf021971dbe0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eed2d778-89cf-4c3c-a710-c8d61811f4c7",
                column: "ConcurrencyStamp",
                value: "df10b537-ee5e-4812-8d53-4f6d9aeafbda");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7125d323-7567-4f56-b27e-6b7044014a37",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "13746876-3591-42fe-8b7c-9e68ddd4ea04", "AQAAAAEAACcQAAAAELM9BlFOWM6hk3lB6X/zTElG5t1cGbddIOIqiWObLLUuCOi/KMuKjamGMXbOAfdLAg==", "64c14286-88e4-4aa4-810d-d8139974ad5b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae724eb3-355b-48dd-bdaa-c1eaccf666c5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7076861f-d0c7-4f3b-b053-b23671446677", "AQAAAAEAACcQAAAAEG+5xjHHka/SUmoIg+p/7XVLgMPUANISqREsQwBm6NoAsYr3IF+hk39NzJYdDVlUKw==", "5ea2876f-f536-45c6-aff6-16346c322b2e" });
        }
    }
}
