using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArrnowConstruct.Infrastructure.Migrations
{
    public partial class SeedDatabaseigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Clients_ClientId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Constructors_ConstructorId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Sites_Clients_ClientId",
                table: "Sites");

            migrationBuilder.DropForeignKey(
                name: "FK_Sites_Constructors_ConstructorId",
                table: "Sites");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "25f73449-f9e8-40b4-87ee-93fc6c242339", "5b928bfd-04c6-4f29-ba14-c845d6cb9e72", "Client", "CLIENT" },
                    { "4033acf9-98f0-49e3-aafc-fd4fcb71c67e", "0d76fbc8-8c8f-4ef8-9324-8543039cf95d", "Administrator", "ADMINISTRATOR" },
                    { "eed2d778-89cf-4c3c-a710-c8d61811f4c7", "c1b75fde-3fdd-4b56-8a11-7e246d03f1b8", "Constructor", "CONSTRUCTOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7125d323-7567-4f56-b27e-6b7044014a37", 0, "Petko DePetkov 71", "Kazanlak", "8d9d5b9b-9c07-440e-aca2-cfdcf0da291a", "Bulgaria", "angel@gmail.com", false, "Angel", true, "Momov", false, null, "ANGEL@GMAIL.COM", "ANGEL", "AQAAAAEAACcQAAAAEDsTi2R46F8/sJmht7z9RFtgCM0MvGlgiokNAmapjqJIiA9oS4FFRT7nKBA7VQyj1A==", "0888791001", false, "http://res.cloudinary.com/dmv8nabul/image/upload/v1671314968/images/vymjt1vk8itzucplowxg.png", "49093e46-c875-42a6-8faf-4b0500d189af", false, "angel" },
                    { "ae724eb3-355b-48dd-bdaa-c1eaccf666c5", 0, "Edelvais 6 ", "Kazanlak", "1d61081d-e700-437d-aefc-c7bf6e0541f9", "Bulgaria", "kresa@mail.com", false, "Kresa", true, "Tsvetkova", false, null, "KRESA@MAIL.COM", "KRESA", "AQAAAAEAACcQAAAAEItR/AijuGtbdJTwdg5n+wI0BMEJ7tsJH9NL9CkB5mlpLg5n4nULl14gBwemAM7wRw==", "0886121260", false, "http://res.cloudinary.com/dmv8nabul/image/upload/v1671315197/images/sayxo7gbosyd1w5xd72r.png", "b92e1350-22eb-4f83-bfad-cdbd336507b9", false, "kresa" },
                    { "babdaf39-3545-48e1-877e-13d4bb4d597f", 0, "Graf Ignatiev 6 ", "Kazanlak", "798e8196-40fe-480b-91e0-b9ccfa1e1e24", "Bulgaria", "gogi@gmail.com", false, "Gogi", true, "Milkov", false, null, "GOGI@GMAIL.COM", "GOGI", "AQAAAAEAACcQAAAAELtJPh9gHdXWPnXziq5k/6VFbGngNAQi6B1q9rTlA3sm9lqplwU3Ekh51E1DeO65Uw==", "0886121261", false, "http://res.cloudinary.com/dmv8nabul/image/upload/v1671315120/images/tfcjhrtonc17iox0yoel.png", "92844926-829f-4fb3-9be0-86ae9cec786b", false, "gogi" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Kitchen" },
                    { 2, "Bathroom" },
                    { 3, "Bedroom" },
                    { 4, "LivingRoom" },
                    { 5, "DiningRoom" },
                    { 6, "Hall" },
                    { 7, "Office" },
                    { 8, "GameRoom" },
                    { 9, "Pantry" },
                    { 10, "Toilet" },
                    { 11, "UtilityRoom" },
                    { 12, "SpareRoom" },
                    { 13, "Cellar" },
                    { 14, "Attic" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "eed2d778-89cf-4c3c-a710-c8d61811f4c7", "7125d323-7567-4f56-b27e-6b7044014a37" },
                    { "4033acf9-98f0-49e3-aafc-fd4fcb71c67e", "ae724eb3-355b-48dd-bdaa-c1eaccf666c5" },
                    { "25f73449-f9e8-40b4-87ee-93fc6c242339", "babdaf39-3545-48e1-877e-13d4bb4d597f" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "IsActive", "UserId" },
                values: new object[] { 1, true, "babdaf39-3545-48e1-877e-13d4bb4d597f" });

            migrationBuilder.InsertData(
                table: "Constructors",
                columns: new[] { "Id", "IsActive", "Salary", "UserId" },
                values: new object[] { 1, true, 1500m, "7125d323-7567-4f56-b27e-6b7044014a37" });

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Clients_ClientId",
                table: "Requests",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Constructors_ConstructorId",
                table: "Requests",
                column: "ConstructorId",
                principalTable: "Constructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sites_Clients_ClientId",
                table: "Sites",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sites_Constructors_ConstructorId",
                table: "Sites",
                column: "ConstructorId",
                principalTable: "Constructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Clients_ClientId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Constructors_ConstructorId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Sites_Clients_ClientId",
                table: "Sites");

            migrationBuilder.DropForeignKey(
                name: "FK_Sites_Constructors_ConstructorId",
                table: "Sites");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eed2d778-89cf-4c3c-a710-c8d61811f4c7", "7125d323-7567-4f56-b27e-6b7044014a37" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4033acf9-98f0-49e3-aafc-fd4fcb71c67e", "ae724eb3-355b-48dd-bdaa-c1eaccf666c5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "25f73449-f9e8-40b4-87ee-93fc6c242339", "babdaf39-3545-48e1-877e-13d4bb4d597f" });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Constructors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25f73449-f9e8-40b4-87ee-93fc6c242339");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4033acf9-98f0-49e3-aafc-fd4fcb71c67e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eed2d778-89cf-4c3c-a710-c8d61811f4c7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7125d323-7567-4f56-b27e-6b7044014a37");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae724eb3-355b-48dd-bdaa-c1eaccf666c5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "babdaf39-3545-48e1-877e-13d4bb4d597f");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Clients_ClientId",
                table: "Requests",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Constructors_ConstructorId",
                table: "Requests",
                column: "ConstructorId",
                principalTable: "Constructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sites_Clients_ClientId",
                table: "Sites",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sites_Constructors_ConstructorId",
                table: "Sites",
                column: "ConstructorId",
                principalTable: "Constructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
