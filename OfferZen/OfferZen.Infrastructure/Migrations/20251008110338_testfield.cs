using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OfferZen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class testfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Product");
        }
    }
}
