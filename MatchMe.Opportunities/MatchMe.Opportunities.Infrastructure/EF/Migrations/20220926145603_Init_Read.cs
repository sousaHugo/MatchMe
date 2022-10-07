using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchMe.Opportunities.Infrastructure.EF.Migrations
{
    public partial class Init_Read : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "opportunities");

            migrationBuilder.CreateTable(
                name: "Opportunity",
                schema: "opportunities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opportunity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpportunitySkill",
                schema: "opportunities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Min_Experience = table.Column<int>(type: "integer", nullable: false),
                    Max_Experience = table.Column<int>(type: "integer", nullable: false),
                    Mandatory = table.Column<bool>(type: "boolean", nullable: false),
                    OpportunityId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpportunitySkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpportunitySkill_Opportunity_OpportunityId",
                        column: x => x.OpportunityId,
                        principalSchema: "opportunities",
                        principalTable: "Opportunity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OpportunitySkill_OpportunityId",
                schema: "opportunities",
                table: "OpportunitySkill",
                column: "OpportunityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OpportunitySkill",
                schema: "opportunities");

            migrationBuilder.DropTable(
                name: "Opportunity",
                schema: "opportunities");
        }
    }
}
