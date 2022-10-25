using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchMe.Candidates.Infrastructure.EF.Migrations
{
    public partial class AddVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "candidates",
                table: "Candidate",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                schema: "candidates",
                table: "Candidate");
        }
    }
}
