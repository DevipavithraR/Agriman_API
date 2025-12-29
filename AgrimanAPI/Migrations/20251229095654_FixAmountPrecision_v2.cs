using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AgrimanAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixAmountPrecision_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Packings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Packings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "PackingName",
                table: "Packings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "PackingDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackingId = table.Column<int>(type: "int", nullable: false),
                    PackingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfUnits = table.Column<int>(type: "int", nullable: false),
                    UnitAmount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackingDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PackingsEntity",
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
                    table.PrimaryKey("PK_PackingsEntity", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PackingsEntity",
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
                name: "PackingDetails");

            migrationBuilder.DropTable(
                name: "PackingsEntity");

            migrationBuilder.AlterColumn<string>(
                name: "PackingName",
                table: "Packings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Packings",
                columns: new[] { "Id", "PackingName", "Unit", "UnitAmount" },
                values: new object[,]
                {
                    { 1, "GunningBag", 1, 1000 },
                    { 2, "Kg", 1, 100 }
                });
        }
    }
}
