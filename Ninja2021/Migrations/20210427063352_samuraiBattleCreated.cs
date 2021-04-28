using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ninja2021.Migrations
{
    public partial class samuraiBattleCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Battles",
                columns: table => new
                {
                    battleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    startDate = table.Column<DateTime>(nullable: false),
                    endDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battles", x => x.battleId);
                });

            migrationBuilder.CreateTable(
                name: "SamuraisInBattle",
                columns: table => new
                {
                    samuraiId = table.Column<int>(nullable: false),
                    battleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SamuraisInBattle", x => new { x.samuraiId, x.battleId });
                    table.ForeignKey(
                        name: "FK_SamuraisInBattle_Battles_battleId",
                        column: x => x.battleId,
                        principalTable: "Battles",
                        principalColumn: "battleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SamuraisInBattle_Samurais_samuraiId",
                        column: x => x.samuraiId,
                        principalTable: "Samurais",
                        principalColumn: "samuraiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SamuraisInBattle_battleId",
                table: "SamuraisInBattle",
                column: "battleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SamuraisInBattle");

            migrationBuilder.DropTable(
                name: "Battles");
        }
    }
}
