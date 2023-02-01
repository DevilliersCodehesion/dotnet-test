using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnetgrad.Migrations
{
    /// <inheritdoc />
    public partial class AddUserInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "registration_number",
                table: "Organisations");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Organisations",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "logo",
                table: "Organisations",
                newName: "Logo");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Organisations",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "AdressModelid",
                table: "Organisations",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationNumber",
                table: "Organisations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    email = table.Column<string>(type: "TEXT", nullable: true),
                    password = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Organisations_AdressModelid",
                table: "Organisations",
                column: "AdressModelid");

            migrationBuilder.AddForeignKey(
                name: "FK_Organisations_Addresses_AdressModelid",
                table: "Organisations",
                column: "AdressModelid",
                principalTable: "Addresses",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organisations_Addresses_AdressModelid",
                table: "Organisations");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropIndex(
                name: "IX_Organisations_AdressModelid",
                table: "Organisations");

            migrationBuilder.DropColumn(
                name: "AdressModelid",
                table: "Organisations");

            migrationBuilder.DropColumn(
                name: "RegistrationNumber",
                table: "Organisations");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Organisations",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Logo",
                table: "Organisations",
                newName: "logo");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Organisations",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "registration_number",
                table: "Organisations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
