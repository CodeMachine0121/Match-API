using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESportsMatchTracker.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class modify_table_structure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "MatchDetails");

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    game = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    teams_json = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    start_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tournament_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stream_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    format = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    map_pool_json = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    overall_score_json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    map_scores_json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    current_map = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    winner_team_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.CreateTable(
                name: "MatchDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Format = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MapPoolJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchDetailsId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentMap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Game = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MapScoresJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ScoreJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreamUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamsJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tournament = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Winner = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_MatchDetails_MatchDetailsId",
                        column: x => x.MatchDetailsId,
                        principalTable: "MatchDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Match_MatchDetailsId",
                table: "Match",
                column: "MatchDetailsId");
        }
    }
}
