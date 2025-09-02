using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeLibrary.Migrations
{
    /// <inheritdoc />
    public partial class updated_maxlength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Companies",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Companies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Companies",
                type: "nvarchar(600)",
                maxLength: 600,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Companies",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "CreatedOn", "Description", "Email", "IsActive", "Name", "PhoneNumber", "UpdatedOn" },
                values: new object[] { new Guid("47569087-1f5b-4702-acb3-91e5643fa27a"), "123 Main St, Thoraipakkam, Chennai", new DateTime(2025, 9, 2, 12, 12, 48, 316, DateTimeKind.Local).AddTicks(9205), "Zuci Systems is a leading software development company specializing in custom software solutions, mobile app development, and web application development. We are committed to delivering high-quality software products that meet the unique needs of our clients.", "zucisystems@zucisystems.com", true, "Zuci Systems", "1234567890", new DateTime(2025, 9, 2, 12, 12, 48, 316, DateTimeKind.Local).AddTicks(9220) });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "CompanyId", "CreatedOn", "DOB", "Email", "IsActive", "Name", "PhoneNumber", "Role", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("79fea8d2-1c63-480a-9786-a404fa1a1255"), "123 Annai Indira Nagar, Thoraipakkam, Chennai", new Guid("47569087-1f5b-4702-acb3-91e5643fa27a"), new DateTime(2025, 9, 2, 12, 12, 48, 316, DateTimeKind.Local).AddTicks(9457), new DateTime(2003, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "srinivasan@zucisystems.com", true, "Srinivasan Arumugam", "1234567890", "Developer", new DateTime(2025, 9, 2, 12, 12, 48, 316, DateTimeKind.Local).AddTicks(9458) },
                    { new Guid("ba336be5-5ea1-45cb-8262-27e1cd0f6074"), "123 Sai Baba PG, Thoraipakkam, Chennai", new Guid("47569087-1f5b-4702-acb3-91e5643fa27a"), new DateTime(2025, 9, 2, 12, 12, 48, 316, DateTimeKind.Local).AddTicks(9448), new DateTime(2003, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "bala@zucisystems.com", true, "Bala Venkata Rama Sai Immadisetty", "9876543210", "Developer", new DateTime(2025, 9, 2, 12, 12, 48, 316, DateTimeKind.Local).AddTicks(9450) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("79fea8d2-1c63-480a-9786-a404fa1a1255"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("ba336be5-5ea1-45cb-8262-27e1cd0f6074"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("47569087-1f5b-4702-acb3-91e5643fa27a"));

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Companies",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Companies",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Companies",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(600)",
                oldMaxLength: 600);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Companies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

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
    }
}
