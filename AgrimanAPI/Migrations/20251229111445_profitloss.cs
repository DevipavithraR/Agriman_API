using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgrimanAPI.Migrations
{
    /// <inheritdoc />
    public partial class profitloss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction_Work_Details",
                table: "Transaction_Work_Details");

            migrationBuilder.DropPrimaryKey(
                name: "PK_transaction_things_details",
                table: "transaction_things_details");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PackingDetails",
                table: "PackingDetails");

            migrationBuilder.RenameTable(
                name: "Transaction_Work_Details",
                newName: "TransactionWorkDetails");

            migrationBuilder.RenameTable(
                name: "transaction_things_details",
                newName: "TransactionThingsDetails");

            migrationBuilder.RenameTable(
                name: "PackingDetails",
                newName: "packing_transactions");

            migrationBuilder.AlterColumn<decimal>(
                name: "amount_spend",
                table: "TransactionThingsDetails",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitAmount",
                table: "packing_transactions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionWorkDetails",
                table: "TransactionWorkDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionThingsDetails",
                table: "TransactionThingsDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_packing_transactions",
                table: "packing_transactions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "profit_loss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkId = table.Column<int>(type: "int", nullable: false),
                    ThingsId = table.Column<int>(type: "int", nullable: false),
                    WorkTotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ThingsTotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PackingTotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProfitOrLoss = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profit_loss", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "profit_loss");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionWorkDetails",
                table: "TransactionWorkDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionThingsDetails",
                table: "TransactionThingsDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_packing_transactions",
                table: "packing_transactions");

            migrationBuilder.RenameTable(
                name: "TransactionWorkDetails",
                newName: "Transaction_Work_Details");

            migrationBuilder.RenameTable(
                name: "TransactionThingsDetails",
                newName: "transaction_things_details");

            migrationBuilder.RenameTable(
                name: "packing_transactions",
                newName: "PackingDetails");

            migrationBuilder.AlterColumn<float>(
                name: "amount_spend",
                table: "transaction_things_details",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<float>(
                name: "UnitAmount",
                table: "PackingDetails",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction_Work_Details",
                table: "Transaction_Work_Details",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_transaction_things_details",
                table: "transaction_things_details",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PackingDetails",
                table: "PackingDetails",
                column: "Id");
        }
    }
}
