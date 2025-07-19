using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESportsMatchTracker.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class modify_table_column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "Match",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_on",
                table: "Match",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<string>(
                name: "modified_by",
                table: "Match",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "modified_on",
                table: "Match",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_by",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "created_on",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "modified_by",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "modified_on",
                table: "Match");
        }
    }
}
