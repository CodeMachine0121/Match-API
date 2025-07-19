using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESportsMatchTracker.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class remove_columns_of_action_log_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecordId",
                table: "ActionLogs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ActionLogs");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "ActionLogs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecordId",
                table: "ActionLogs",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ActionLogs",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "ActionLogs",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");
        }
    }
}
