using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Migrations
{
    public partial class squadConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TFSUsers_Squads_SquadsId",
                table: "TFSUsers");

            migrationBuilder.DropIndex(
                name: "IX_TFSUsers_SquadsId",
                table: "TFSUsers");

            migrationBuilder.DropColumn(
                name: "SquadsId",
                table: "TFSUsers");

            migrationBuilder.RenameColumn(
                name: "UserRole",
                table: "TFSUsers",
                newName: "UserRoleId");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "TFSUsers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TFSName",
                table: "TFSUsers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "TFSUsers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TFSUsers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "TFSUsers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SquadId1",
                table: "TFSUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SquadId2",
                table: "TFSUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TFSUsers_CreatedBy",
                table: "TFSUsers",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TFSUsers_Email",
                table: "TFSUsers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TFSUsers_SquadId",
                table: "TFSUsers",
                column: "SquadId");

            migrationBuilder.CreateIndex(
                name: "IX_TFSUsers_SquadId1",
                table: "TFSUsers",
                column: "SquadId1");

            migrationBuilder.CreateIndex(
                name: "IX_TFSUsers_UserName",
                table: "TFSUsers",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TFSUsers_UserRoleId",
                table: "TFSUsers",
                column: "UserRoleId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TFSUsers_TFSUsers_CreatedBy",
                table: "TFSUsers",
                column: "CreatedBy",
                principalTable: "TFSUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TFSUsers_UserRole_UserRoleId",
                table: "TFSUsers",
                column: "UserRoleId",
                principalTable: "UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TFSUsers_Squads_SquadId",
                table: "TFSUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TFSUsers_Squads_SquadId1",
                table: "TFSUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TFSUsers_TFSUsers_CreatedBy",
                table: "TFSUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TFSUsers_UserRole_UserRoleId",
                table: "TFSUsers");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_TFSUsers_CreatedBy",
                table: "TFSUsers");

            migrationBuilder.DropIndex(
                name: "IX_TFSUsers_Email",
                table: "TFSUsers");

            migrationBuilder.DropIndex(
                name: "IX_TFSUsers_SquadId",
                table: "TFSUsers");

            migrationBuilder.DropIndex(
                name: "IX_TFSUsers_SquadId1",
                table: "TFSUsers");

            migrationBuilder.DropIndex(
                name: "IX_TFSUsers_UserName",
                table: "TFSUsers");

            migrationBuilder.DropIndex(
                name: "IX_TFSUsers_UserRoleId",
                table: "TFSUsers");

            migrationBuilder.DropColumn(
                name: "SquadId1",
                table: "TFSUsers");

            migrationBuilder.DropColumn(
                name: "SquadId2",
                table: "TFSUsers");

            migrationBuilder.RenameColumn(
                name: "UserRoleId",
                table: "TFSUsers",
                newName: "UserRole");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "TFSUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "TFSName",
                table: "TFSUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "TFSUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TFSUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "TFSUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "SquadsId",
                table: "TFSUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TFSUsers_SquadsId",
                table: "TFSUsers",
                column: "SquadsId");

            migrationBuilder.AddForeignKey(
                name: "FK_TFSUsers_Squads_SquadsId",
                table: "TFSUsers",
                column: "SquadsId",
                principalTable: "Squads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
