using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopping.CartAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedcolumnpasswordhash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "UserDetails",
                type: "BLOB",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "UserDetails",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "UserDetails");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "UserDetails",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "BLOB");
        }
    }
}
