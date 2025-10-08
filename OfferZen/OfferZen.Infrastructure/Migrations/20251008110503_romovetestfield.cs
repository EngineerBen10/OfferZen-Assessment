using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OfferZen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class romovetestfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Product");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
