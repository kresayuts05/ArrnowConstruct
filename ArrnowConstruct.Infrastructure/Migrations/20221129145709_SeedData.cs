using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArrnowConstruct.Infrastructure.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryRequest_Categories_RoomsTypesId",
                table: "CategoryRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryRequest_Requests_RequestsId",
                table: "CategoryRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_CategorySite_Categories_RoomsTypesId",
                table: "CategorySite");

            migrationBuilder.DropForeignKey(
                name: "FK_CategorySite_Sites_SitesId",
                table: "CategorySite");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientConstructor_Clients_FollowersId",
                table: "ClientConstructor");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientConstructor_Constructors_FollowingId",
                table: "ClientConstructor");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_AspNetUsers_UserId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Constructors_AspNetUsers_UserId",
                table: "Constructors");

            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_AspNetUsers_UserId",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_Posts_PostId",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK_PostImages_Posts_PostId",
                table: "PostImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Sites_SiteId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_PostsLikes_AspNetUsers_UserId",
                table: "PostsLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_PostsLikes_Posts_PostId",
                table: "PostsLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Clients_ClientId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Constructors_ConstructorId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewComments_AspNetUsers_UserId",
                table: "ReviewComments");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewComments_Reviews_Reviewid",
                table: "ReviewComments");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewImages_Reviews_ReviewId",
                table: "ReviewImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Posts_PostId",
                table: "Reviews");

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
                    { "25f73449-f9e8-40b4-87ee-93fc6c242339", "7ebcfc94-85cf-43e3-9904-0f8d0eff06dd", "Client", "CLIENT" },
                    { "4033acf9-98f0-49e3-aafc-fd4fcb71c67e", "297be09d-65cf-448f-b85e-31cdbb8f9cee", "Administrator", "ADMINISTRATOR" },
                    { "eed2d778-89cf-4c3c-a710-c8d61811f4c7", "16b234c5-15e0-4824-be64-36e74722d4ff", "Constructor", "CONSTRUCTOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FirstName", "Image", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7125d323-7567-4f56-b27e-6b7044014a37", 0, "Petko DePetkov 71", "Kazanlak", "66a44a91-f467-4318-a376-b7eae9951588", "Bulgaria", "angel@mail.com", false, "Angel", null, "Momov", false, null, "ANGEL@MAIL.COM", "ANGEL", "AQAAAAEAACcQAAAAEFQr+vd3g65WUuzmBMAPZyXbdeYcTkheV/IP2xME0kmKcsA0XQ1L/xy3EUUI2ncB9Q==", "0888791001", false, "ac6ae98b-2ecc-46d6-9512-a51c44bc6d67", false, "angel" },
                    { "ae724eb3-355b-48dd-bdaa-c1eaccf666c5", 0, "Edelvais 6 ", "Kazanlak", "41c2334c-7968-43f4-9cc0-063ac8fc4ae6", "Bulgaria", "kresa@mail.com", false, "Kresa", null, "Tsvetkova", false, null, "KRESA@MAIL.COM", "KRESA", "AQAAAAEAACcQAAAAEIVp6QuyLIKumiLaZM6P1Jx15P+vE7sKZ1W4uj74F+75wzFGfCikwO4XpJs2UtgCPw==", "0886121260", false, "b27f14dd-3e09-42cb-b32d-78a27a8ddf36", false, "kresa" },
                    { "babdaf39-3545-48e1-877e-13d4bb4d597f", 0, "Graf Ignatiev 6 ", "Kazanlak", "cbb434ef-f64c-4506-ac66-be217372afbd", "Bulgaria", "nikol@mail.com", false, "Nikol", null, "Grueva", false, null, "NIKOL@MAIL.COM", "NIKOL", "AQAAAAEAACcQAAAAEDNT8l0sKFPxOKNarvRJW0egSec/2WGkvw4+bjpxVkkwNubh/4zpO5p/Aw/0/D9kWg==", "0886121261", false, "44a0a2d0-121a-4a3a-9ea5-68bbb4319385", false, "nikol" }
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
                values: new object[] { "4033acf9-98f0-49e3-aafc-fd4fcb71c67e", "ae724eb3-355b-48dd-bdaa-c1eaccf666c5" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1, "ae724eb3-355b-48dd-bdaa-c1eaccf666c5" });

            migrationBuilder.InsertData(
                table: "Constructors",
                columns: new[] { "Id", "Salary", "UserId" },
                values: new object[] { 1, 1500m, "7125d323-7567-4f56-b27e-6b7044014a37" });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryRequest_Categories_RoomsTypesId",
                table: "CategoryRequest",
                column: "RoomsTypesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryRequest_Requests_RequestsId",
                table: "CategoryRequest",
                column: "RequestsId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategorySite_Categories_RoomsTypesId",
                table: "CategorySite",
                column: "RoomsTypesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategorySite_Sites_SitesId",
                table: "CategorySite",
                column: "SitesId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientConstructor_Clients_FollowersId",
                table: "ClientConstructor",
                column: "FollowersId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientConstructor_Constructors_FollowingId",
                table: "ClientConstructor",
                column: "FollowingId",
                principalTable: "Constructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_AspNetUsers_UserId",
                table: "Clients",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Constructors_AspNetUsers_UserId",
                table: "Constructors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_AspNetUsers_UserId",
                table: "PostComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_Posts_PostId",
                table: "PostComments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostImages_Posts_PostId",
                table: "PostImages",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Sites_SiteId",
                table: "Posts",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostsLikes_AspNetUsers_UserId",
                table: "PostsLikes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostsLikes_Posts_PostId",
                table: "PostsLikes",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_ReviewComments_AspNetUsers_UserId",
                table: "ReviewComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewComments_Reviews_Reviewid",
                table: "ReviewComments",
                column: "Reviewid",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewImages_Reviews_ReviewId",
                table: "ReviewImages",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Posts_PostId",
                table: "Reviews",
                column: "PostId",
                principalTable: "Posts",
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
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryRequest_Categories_RoomsTypesId",
                table: "CategoryRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryRequest_Requests_RequestsId",
                table: "CategoryRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_CategorySite_Categories_RoomsTypesId",
                table: "CategorySite");

            migrationBuilder.DropForeignKey(
                name: "FK_CategorySite_Sites_SitesId",
                table: "CategorySite");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientConstructor_Clients_FollowersId",
                table: "ClientConstructor");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientConstructor_Constructors_FollowingId",
                table: "ClientConstructor");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_AspNetUsers_UserId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Constructors_AspNetUsers_UserId",
                table: "Constructors");

            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_AspNetUsers_UserId",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_Posts_PostId",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK_PostImages_Posts_PostId",
                table: "PostImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Sites_SiteId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_PostsLikes_AspNetUsers_UserId",
                table: "PostsLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_PostsLikes_Posts_PostId",
                table: "PostsLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Clients_ClientId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Constructors_ConstructorId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewComments_AspNetUsers_UserId",
                table: "ReviewComments");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewComments_Reviews_Reviewid",
                table: "ReviewComments");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewImages_Reviews_ReviewId",
                table: "ReviewImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Posts_PostId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Sites_Clients_ClientId",
                table: "Sites");

            migrationBuilder.DropForeignKey(
                name: "FK_Sites_Constructors_ConstructorId",
                table: "Sites");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25f73449-f9e8-40b4-87ee-93fc6c242339");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eed2d778-89cf-4c3c-a710-c8d61811f4c7");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4033acf9-98f0-49e3-aafc-fd4fcb71c67e", "ae724eb3-355b-48dd-bdaa-c1eaccf666c5" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "babdaf39-3545-48e1-877e-13d4bb4d597f");

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
                keyValue: "4033acf9-98f0-49e3-aafc-fd4fcb71c67e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7125d323-7567-4f56-b27e-6b7044014a37");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae724eb3-355b-48dd-bdaa-c1eaccf666c5");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryRequest_Categories_RoomsTypesId",
                table: "CategoryRequest",
                column: "RoomsTypesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryRequest_Requests_RequestsId",
                table: "CategoryRequest",
                column: "RequestsId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategorySite_Categories_RoomsTypesId",
                table: "CategorySite",
                column: "RoomsTypesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategorySite_Sites_SitesId",
                table: "CategorySite",
                column: "SitesId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientConstructor_Clients_FollowersId",
                table: "ClientConstructor",
                column: "FollowersId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientConstructor_Constructors_FollowingId",
                table: "ClientConstructor",
                column: "FollowingId",
                principalTable: "Constructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_AspNetUsers_UserId",
                table: "Clients",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Constructors_AspNetUsers_UserId",
                table: "Constructors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_AspNetUsers_UserId",
                table: "PostComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_Posts_PostId",
                table: "PostComments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostImages_Posts_PostId",
                table: "PostImages",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Sites_SiteId",
                table: "Posts",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostsLikes_AspNetUsers_UserId",
                table: "PostsLikes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostsLikes_Posts_PostId",
                table: "PostsLikes",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_ReviewComments_AspNetUsers_UserId",
                table: "ReviewComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewComments_Reviews_Reviewid",
                table: "ReviewComments",
                column: "Reviewid",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewImages_Reviews_ReviewId",
                table: "ReviewImages",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Posts_PostId",
                table: "Reviews",
                column: "PostId",
                principalTable: "Posts",
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
