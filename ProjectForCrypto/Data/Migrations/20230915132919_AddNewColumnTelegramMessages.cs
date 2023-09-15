using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewColumnTelegramMessages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TelegramGroupUsername",
                table: "TelegramMessages",
                newName: "telegram_group_username");

            migrationBuilder.RenameColumn(
                name: "TelegramGroupId",
                table: "TelegramMessages",
                newName: "telegram_group_id");

            migrationBuilder.RenameColumn(
                name: "SenderUsername",
                table: "TelegramMessages",
                newName: "sender_username");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "TelegramMessages",
                newName: "sender_id");

            migrationBuilder.RenameColumn(
                name: "LinkForMessage",
                table: "TelegramMessages",
                newName: "link_for_message");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "TelegramMessages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "telegram_group_username",
                table: "TelegramMessages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "sender_username",
                table: "TelegramMessages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "link_for_message",
                table: "TelegramMessages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "TelegramMessages",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "TelegramMessages");

            migrationBuilder.RenameColumn(
                name: "telegram_group_username",
                table: "TelegramMessages",
                newName: "TelegramGroupUsername");

            migrationBuilder.RenameColumn(
                name: "telegram_group_id",
                table: "TelegramMessages",
                newName: "TelegramGroupId");

            migrationBuilder.RenameColumn(
                name: "sender_username",
                table: "TelegramMessages",
                newName: "SenderUsername");

            migrationBuilder.RenameColumn(
                name: "sender_id",
                table: "TelegramMessages",
                newName: "SenderId");

            migrationBuilder.RenameColumn(
                name: "link_for_message",
                table: "TelegramMessages",
                newName: "LinkForMessage");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "TelegramMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TelegramGroupUsername",
                table: "TelegramMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SenderUsername",
                table: "TelegramMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LinkForMessage",
                table: "TelegramMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
