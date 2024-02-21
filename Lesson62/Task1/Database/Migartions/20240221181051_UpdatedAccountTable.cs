using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task1.Database.Migartions
{
    /// <inheritdoc />
    public partial class UpdatedAccountTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoneyInAccount",
                table: "Accounts");

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "Accounts",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Accounts");

            migrationBuilder.AddColumn<double>(
                name: "MoneyInAccount",
                table: "Accounts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
