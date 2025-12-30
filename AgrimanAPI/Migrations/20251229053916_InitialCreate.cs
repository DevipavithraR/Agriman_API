using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AgrimanAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgriThings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThingName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgriThings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AgriWorks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgriWorks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Packings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: false),
                    UnitAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "transaction_things_details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    things_id = table.Column<int>(type: "int", nullable: false),
                    things_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    thing_quantity = table.Column<int>(type: "int", nullable: false),
                    amount_spend = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaction_things_details", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AgriThings",
                columns: new[] { "Id", "ThingName" },
                values: new object[,]
                {
                    { 1, "Seeds" },
                    { 2, "Soil" },
                    { 3, "Water" },
                    { 4, "Fertilizer" },
                    { 5, "Manure" },
                    { 6, "Pesticide" },
                    { 7, "Form Machinery" },
                    { 8, "Irrigation systems" },
                    { 9, "Fungicide" },
                    { 10, "Bio Fertilizer" }
                });

            migrationBuilder.InsertData(
                table: "AgriWorks",
                columns: new[] { "Id", "WorkDescription", "WorkName" },
                values: new object[,]
                {
                    { 1, "Loosening and preparing the soil for cultivation", "Ploughing" },
                    { 2, "Planting seeds into the prepared soil", "Sowing" },
                    { 3, "Supplying water to crops at regular intervals", "Irrigation" },
                    { 4, "Applying nutrients to improve crop growth", "Fertilization" },
                    { 5, "Removing or controlling unwanted plants", "Weed Control" },
                    { 6, "Spraying chemicals to control weeds and pests", "Herbicide Spraying" },
                    { 7, "Collecting mature crops from the field", "Harvesting" },
                    { 8, "Storing harvested crops safely to prevent damage", "Storage" },
                    { 9, "Packing crops for transport or sale", "Packing" },
                    { 10, "Sending agricultural products to other regions or countries", "Export" }
                });

            migrationBuilder.InsertData(
                table: "Packings",
                columns: new[] { "Id", "PackingName", "Unit", "UnitAmount" },
                values: new object[,]
                {
                    { 1, "GunningBag", 1, 1000 },
                    { 2, "Kg", 1, 100 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgriThings");

            migrationBuilder.DropTable(
                name: "AgriWorks");

            migrationBuilder.DropTable(
                name: "Packings");

            migrationBuilder.DropTable(
                name: "transaction_things_details");
        }
    }
}
