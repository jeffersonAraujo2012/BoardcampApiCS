using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardcampApiCS.Migrations
{
    /// <inheritdoc />
    public partial class UniqueConstraintAddedToCpfFromCustomers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Customers_Cpf",
                table: "Customers",
                column: "Cpf",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_Cpf",
                table: "Customers");
        }
    }
}
