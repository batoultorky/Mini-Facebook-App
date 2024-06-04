using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace miniFacebook.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "photo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "changePasswordModel",
                columns: table => new
                {
                    oldPassword = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    newPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    confirmNewPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_changePasswordModel", x => x.oldPassword);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "changePasswordModel");

            migrationBuilder.AlterColumn<string>(
                name: "photo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
