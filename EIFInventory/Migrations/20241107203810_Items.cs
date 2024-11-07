using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EIFInventory.Migrations
{
    /// <inheritdoc />
    public partial class Items : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01H6N7NV18JWC8MYPXCVZR9WZW", null, "Faculty", "FACULTY" },
                    { "01H6N7NV1JHYY7N2NFDYX4ATAP", null, "Deputy", "DEPUTY" },
                    { "01H6N7NV1KTPB9QDZ7FYDJ3HHK", null, "Admin", "ADMIN" },
                    { "01H6N7NV1MHQDXGNYH2HQT34V9", null, "Department", "DEPARTMENT" },
                    { "01H6N7NV1YTMCV8YPZC7QQGGG7", null, "Lecturer", "LECTURER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "01H6N7NV2P1KCVKY7F6EJH0FAF", 0, "ef53ce9b-de9a-445c-85ba-c43eb8959df6", "admin@viko.lt", true, false, null, "ADMIN@VIKO.LT", "ADMIN@VIKO.LT", "AQAAAAIAAYagAAAAEF557YKkYOJVO+3Y64qkciIGL4F8ZwVCsyo8bXiu0IVRWdudPbbk0Qe7SARwCuU+eQ==", null, false, "4f8aea47-d61a-457e-914c-ed5db14381df", false, "admin@viko.lt" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "01H6N7NV1KTPB9QDZ7FYDJ3HHK", "01H6N7NV2P1KCVKY7F6EJH0FAF" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01H6N7NV18JWC8MYPXCVZR9WZW");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01H6N7NV1JHYY7N2NFDYX4ATAP");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01H6N7NV1MHQDXGNYH2HQT34V9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01H6N7NV1YTMCV8YPZC7QQGGG7");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "01H6N7NV1KTPB9QDZ7FYDJ3HHK", "01H6N7NV2P1KCVKY7F6EJH0FAF" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01H6N7NV1KTPB9QDZ7FYDJ3HHK");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "01H6N7NV2P1KCVKY7F6EJH0FAF");
        }
    }
}
