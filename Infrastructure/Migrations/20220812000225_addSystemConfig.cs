using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Migrations
{
    public partial class addSystemConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbsentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    DaysCount = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbsentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TFSProject = table.Column<string>(type: "text", nullable: true),
                    TFSIterationPath = table.Column<string>(type: "text", nullable: true),
                    TFSCollectionUrl = table.Column<string>(type: "text", nullable: true),
                    TFSScrumStartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TFSScrumEndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TFSSprintName = table.Column<string>(type: "text", nullable: true),
                    TFSPAT = table.Column<string>(type: "text", nullable: true),
                    FullSiteURL = table.Column<string>(type: "text", nullable: true),
                    AmazonS3CDN = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemConfigs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbsentTypes");

            migrationBuilder.DropTable(
                name: "SystemConfigs");
        }
    }
}
