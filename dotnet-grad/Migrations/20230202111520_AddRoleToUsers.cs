using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnetgrad.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "password",
                table: "UserInfo",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "UserInfo",
                newName: "Email");

            migrationBuilder.AlterColumn<string>(
                name: "id_number",
                table: "Users",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "Users",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "role",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "UserInfo",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "UserInfo",
                newName: "email");

            migrationBuilder.AlterColumn<int>(
                name: "id_number",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
