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
                name: "FK_Image_Posts_PostId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_AspNetUsers_UserId",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_Posts_PostId",
                table: "PostComments");

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
                    { "25f73449-f9e8-40b4-87ee-93fc6c242339", "4cb59b81-c23a-4f6d-adfd-dfc81adb19a1", "Client", "CLIENT" },
                    { "4033acf9-98f0-49e3-aafc-fd4fcb71c67e", "66609e63-f7f1-48ce-85df-a08ceb41d7e1", "Administrator", "ADMINISTRATOR" },
                    { "eed2d778-89cf-4c3c-a710-c8d61811f4c7", "66b01105-fced-4b05-83fd-9fd2b2b2ca01", "Constructor", "CONSTRUCTOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7125d323-7567-4f56-b27e-6b7044014a37", 0, "Petko DePetkov 71", "Kazanlak", "ed5956ee-84b5-4b5b-999b-9c67356ccace", "Bulgaria", "angel@mail.com", false, "Angel", "Momov", false, null, "ANGEL@MAIL.COM", "ANGEL", "AQAAAAEAACcQAAAAEIio/8pqmk6+qZXzt1zn5r++uUAJlvcjHID8rb+80c6kP+0kLK3RgD+SF0TttDw1cA==", "0888791001", false, "https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-profiles/avatar-1.webp", "0541244a-afab-4ac8-b90a-3d3ab833bfbc", false, "angel" },
                    { "ae724eb3-355b-48dd-bdaa-c1eaccf666c5", 0, "Edelvais 6 ", "Kazanlak", "3182caa0-5644-48c6-a4bc-c07daaa78abc", "Bulgaria", "kresa@mail.com", false, "Kresa", "Tsvetkova", false, null, "KRESA@MAIL.COM", "KRESA", "AQAAAAEAACcQAAAAEDYpC4qG2+gq8FDHpu50mHWgG2kk/87zBgCnvBKgMQ/EoL38FtOwaYPvy+NtO81H0w==", "0886121260", false, null, "c7003d3f-72c5-4062-8374-105e4f64d20f", false, "kresa" },
                    { "babdaf39-3545-48e1-877e-13d4bb4d597f", 0, "Graf Ignatiev 6 ", "Kazanlak", "f046694d-e1ee-4134-8c54-18706d4569d8", "Bulgaria", "nikol@mail.com", false, "Nikol", "Grueva", false, null, "NIKOL@MAIL.COM", "NIKOL", "AQAAAAEAACcQAAAAEOu821VL+z/pDtj+rwKWPfRSTQbHZ/STGVVaP71ItRss8f/tKlDlVFiM1LCj91jn5g==", "0886121261", false, null, "8052c67c-bf9d-4056-ad99-3555e2c7cb40", false, "nikol" }
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
                name: "FK_Image_Posts_PostId",
                table: "Image",
                column: "PostId",
                principalTable: "Posts",
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
                name: "FK_Image_Posts_PostId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_AspNetUsers_UserId",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_Posts_PostId",
                table: "PostComments");

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
                name: "FK_Image_Posts_PostId",
                table: "Image",
                column: "PostId",
                principalTable: "Posts",
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
