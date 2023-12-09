using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanyAndContactAndCountryToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Industry = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    JobTitle = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contact_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "CompanyName", "Industry" },
                values: new object[,]
                {
                    { 1, "ABC Corporation", 0 },
                    { 2, "XYZ Ltd", 1 },
                    { 3, "TechFab Solutions", 2 },
                    { 4, "RoadMasters Automotive", 3 }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "CountryName" },
                values: new object[,]
                {
                    { 1, "Germany" },
                    { 2, "France" },
                    { 3, "Poland" },
                    { 4, "Swedan" }
                });

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "Id", "CompanyId", "ContactName", "CountryId", "JobTitle" },
                values: new object[,]
                {
                    { 1, 1, "John Doe", 2, 0 },
                    { 2, 2, "Jane Smith", 1, 3 },
                    { 3, 3, "Bob Johnson", 4, 1 },
                    { 4, 4, "Martin Peterson", 3, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_CompanyId",
                table: "Contact",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_CountryId",
                table: "Contact",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
