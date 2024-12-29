using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Demo.Migrations
{
    /// <inheritdoc />
    public partial class ActorEmailRemove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                schema: "ef",
                table: "Actors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                schema: "ef",
                table: "Actors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
