using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Demo.Migrations
{
    /// <inheritdoc />
    public partial class PesonBaseEntityIndexRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "idx_first_name",
                schema: "ef",
                table: "Directors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "idx_first_name",
                schema: "ef",
                table: "Directors",
                column: "FirstName",
                unique: true);
        }
    }
}
