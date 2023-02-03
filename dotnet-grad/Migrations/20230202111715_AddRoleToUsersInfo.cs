using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnetgrad.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleToUsersInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "UserInfo",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "UserInfo");
        }
    }
}
