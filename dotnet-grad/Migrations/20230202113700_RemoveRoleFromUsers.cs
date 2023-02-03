using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnetgrad.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRoleFromUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "role",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "Users",
                type: "TEXT",
                nullable: true);
        }
    }
}
