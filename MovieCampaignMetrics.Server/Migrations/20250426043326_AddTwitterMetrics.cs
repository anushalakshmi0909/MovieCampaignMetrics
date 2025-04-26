using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieCampaignMetrics.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddTwitterMetrics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TwitterMetrics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TweetId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LikeCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RetweetCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReplyCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FetchedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TwitterMetrics", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TwitterMetrics");
        }
    }
}
