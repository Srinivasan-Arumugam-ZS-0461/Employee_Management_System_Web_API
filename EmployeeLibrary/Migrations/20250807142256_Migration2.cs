using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeLibrary.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Companies",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Description",
                table: "Companies");
        }
    }
}
