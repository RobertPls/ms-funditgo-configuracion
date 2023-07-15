using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.EntityFramework.Migrations
{
    public partial class InitialStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "app");

            migrationBuilder.CreateTable(
                name: "applicationFile",
                schema: "app",
                columns: table => new
                {
                    fileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fileName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    location = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    extension = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    mimeType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    uploadedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    timesUsed = table.Column<int>(type: "int", nullable: false),
                    isTemp = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicationFile", x => x.fileId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "applicationFile",
                schema: "app");
        }
    }
}
