using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class InitialStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "app");

            migrationBuilder.CreateTable(
                name: "archivo",
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
                    table.PrimaryKey("PK_archivo", x => x.fileId);
                });

            migrationBuilder.CreateTable(
                name: "Requerimiento",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requerimiento", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TipoProyecto",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProyecto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Proyecto",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    creadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipoProyectoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyecto", x => x.id);
                    table.ForeignKey(
                        name: "FK_Proyecto_TipoProyecto_tipoProyectoId",
                        column: x => x.tipoProyectoId,
                        principalTable: "TipoProyecto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequerimientoTipo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    obligatorio = table.Column<bool>(type: "bit", nullable: false),
                    tipoProyectoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    requerimientoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequerimientoTipo", x => x.id);
                    table.ForeignKey(
                        name: "FK_RequerimientoTipo_Requerimiento_requerimientoId",
                        column: x => x.requerimientoId,
                        principalTable: "Requerimiento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequerimientoTipo_TipoProyecto_tipoProyectoId",
                        column: x => x.tipoProyectoId,
                        principalTable: "TipoProyecto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequisitoProyecto",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    archivoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    requerimientoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    proyectoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitoProyecto", x => x.id);
                    table.ForeignKey(
                        name: "FK_RequisitoProyecto_Proyecto_proyectoId",
                        column: x => x.proyectoId,
                        principalTable: "Proyecto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequisitoProyecto_Requerimiento_requerimientoId",
                        column: x => x.requerimientoId,
                        principalTable: "Requerimiento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequisitoProyecto_archivo_archivoId",
                        column: x => x.archivoId,
                        principalSchema: "app",
                        principalTable: "archivo",
                        principalColumn: "fileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proyecto_tipoProyectoId",
                table: "Proyecto",
                column: "tipoProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_RequerimientoTipo_requerimientoId",
                table: "RequerimientoTipo",
                column: "requerimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_RequerimientoTipo_tipoProyectoId",
                table: "RequerimientoTipo",
                column: "tipoProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitoProyecto_archivoId",
                table: "RequisitoProyecto",
                column: "archivoId");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitoProyecto_proyectoId",
                table: "RequisitoProyecto",
                column: "proyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitoProyecto_requerimientoId",
                table: "RequisitoProyecto",
                column: "requerimientoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequerimientoTipo");

            migrationBuilder.DropTable(
                name: "RequisitoProyecto");

            migrationBuilder.DropTable(
                name: "Proyecto");

            migrationBuilder.DropTable(
                name: "Requerimiento");

            migrationBuilder.DropTable(
                name: "archivo",
                schema: "app");

            migrationBuilder.DropTable(
                name: "TipoProyecto");
        }
    }
}
