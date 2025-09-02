using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeLibrary.Migrations
{
    /// <inheritdoc />
    public partial class Migration_V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Companies_CompanyId1",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CompanyId1",
                table: "Employees");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("9af76444-2bc7-4e01-b4cd-aa6b02b8924c"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("fdf99112-7e80-4185-bd3d-69e866d9400f"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("3055d53d-e691-4e74-8180-26fc4189f898"));

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "CreatedOn", "Description", "Email", "IsActive", "Name", "PhoneNumber", "UpdatedOn" },
                values: new object[] { new Guid("e2780185-d9ee-4067-958f-30565ae77673"), "123 Main St, Thoraipakkam, Chennai", new DateTime(2025, 8, 11, 18, 34, 47, 469, DateTimeKind.Local).AddTicks(8313), "Zuci Systems is a leading software development company specializing in custom software solutions, mobile app development, and web application development. We are committed to delivering high-quality software products that meet the unique needs of our clients.", "zucisystems@zucisystems.com", true, "Zuci Systems", "1234567890", new DateTime(2025, 8, 11, 18, 34, 47, 469, DateTimeKind.Local).AddTicks(8342) });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "CompanyId", "CreatedOn", "DOB", "Email", "IsActive", "Name", "PhoneNumber", "Role", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("0ecb31b4-5610-4652-8205-5a05d52bafcb"), "123 Annai Indira Nagar, Thoraipakkam, Chennai", new Guid("e2780185-d9ee-4067-958f-30565ae77673"), new DateTime(2025, 8, 11, 18, 34, 47, 469, DateTimeKind.Local).AddTicks(8837), new DateTime(2003, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "srinivasan@zucisystems.com", true, "Srinivasan Arumugam", "1234567890", "Developer", new DateTime(2025, 8, 11, 18, 34, 47, 469, DateTimeKind.Local).AddTicks(8839) },
                    { new Guid("95476122-af29-42a3-beaa-e0075b01120f"), "123 Sai Baba PG, Thoraipakkam, Chennai", new Guid("e2780185-d9ee-4067-958f-30565ae77673"), new DateTime(2025, 8, 11, 18, 34, 47, 469, DateTimeKind.Local).AddTicks(8822), new DateTime(2003, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "bala@zucisystems.com", true, "Bala Venkata Rama Sai Immadisetty", "9876543210", "Developer", new DateTime(2025, 8, 11, 18, 34, 47, 469, DateTimeKind.Local).AddTicks(8825) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("0ecb31b4-5610-4652-8205-5a05d52bafcb"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("95476122-af29-42a3-beaa-e0075b01120f"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("e2780185-d9ee-4067-958f-30565ae77673"));

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId1",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "CreatedOn", "Description", "Email", "IsActive", "Name", "PhoneNumber", "UpdatedOn" },
                values: new object[] { new Guid("3055d53d-e691-4e74-8180-26fc4189f898"), "123 Main St, Thoraipakkam, Chennai", new DateTime(2025, 8, 7, 19, 52, 55, 891, DateTimeKind.Local).AddTicks(6915), "Zuci Systems is a leading software development company specializing in custom software solutions, mobile app development, and web application development. We are committed to delivering high-quality software products that meet the unique needs of our clients.", "zucisystems@zucisystems.com", true, "Zuci Systems", "1234567890", new DateTime(2025, 8, 7, 19, 52, 55, 891, DateTimeKind.Local).AddTicks(6936) });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "CompanyId", "CompanyId1", "CreatedOn", "DOB", "Email", "IsActive", "Name", "PhoneNumber", "Role", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("9af76444-2bc7-4e01-b4cd-aa6b02b8924c"), "123 Sai Baba PG, Thoraipakkam, Chennai", new Guid("3055d53d-e691-4e74-8180-26fc4189f898"), null, new DateTime(2025, 8, 7, 19, 52, 55, 891, DateTimeKind.Local).AddTicks(7202), new DateTime(2003, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "bala@zucisystems.com", true, "Bala Venkata Rama Sai Immadisetty", "9876543210", "Developer", new DateTime(2025, 8, 7, 19, 52, 55, 891, DateTimeKind.Local).AddTicks(7203) },
                    { new Guid("fdf99112-7e80-4185-bd3d-69e866d9400f"), "123 Annai Indira Nagar, Thoraipakkam, Chennai", new Guid("3055d53d-e691-4e74-8180-26fc4189f898"), null, new DateTime(2025, 8, 7, 19, 52, 55, 891, DateTimeKind.Local).AddTicks(7211), new DateTime(2003, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "srinivasan@zucisystems.com", true, "Srinivasan Arumugam", "1234567890", "Developer", new DateTime(2025, 8, 7, 19, 52, 55, 891, DateTimeKind.Local).AddTicks(7213) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId1",
                table: "Employees",
                column: "CompanyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Companies_CompanyId1",
                table: "Employees",
                column: "CompanyId1",
                principalTable: "Companies",
                principalColumn: "Id");
        }
    }
}
