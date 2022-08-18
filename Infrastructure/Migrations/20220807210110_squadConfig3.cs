using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class squadConfig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TFSUsers_Squads_SquadId",
                table: "TFSUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TFSUsers_Squads_SquadId1",
                table: "TFSUsers");

            migrationBuilder.DropIndex(
                name: "IX_TFSUsers_SquadId1",
                table: "TFSUsers");

            migrationBuilder.DropColumn(
                name: "SquadId1",
                table: "TFSUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_TFSUsers_Squads_SquadId",
                table: "TFSUsers",
                column: "SquadId",
                principalTable: "Squads",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TFSUsers_Squads_SquadId",
                table: "TFSUsers");

            migrationBuilder.AddColumn<int>(
                name: "SquadId1",
                table: "TFSUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TFSUsers_SquadId1",
                table: "TFSUsers",
                column: "SquadId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TFSUsers_Squads_SquadId",
                table: "TFSUsers",
                column: "SquadId",
                principalTable: "Squads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TFSUsers_Squads_SquadId1",
                table: "TFSUsers",
                column: "SquadId1",
                principalTable: "Squads",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
