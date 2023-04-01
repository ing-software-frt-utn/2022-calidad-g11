using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebControlShoes.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colours",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodigoColor = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colours", x => x.Id);
                    table.UniqueConstraint("AK_Colours_CodigoColor", x => x.CodigoColor);
                });

            migrationBuilder.CreateTable(
                name: "LineasProduccion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nrolinea = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineasProduccion", x => x.Id);
                    table.UniqueConstraint("AK_LineasProduccion_Nrolinea", x => x.Nrolinea);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sku = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Denominacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LimiteInferiorObservado = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    LimiteInferiorReproceso = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    LimiteSuperiorObservado = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    LimiteSuperiorReproceso = table.Column<int>(type: "int", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.Id);
                    table.UniqueConstraint("AK_Modelos_Sku", x => x.Sku);
                });

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HoraInicio = table.Column<int>(type: "int", nullable: false),
                    HoraFin = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdenesProduccion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodigoOP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: true),
                    FechaFin = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: true),
                    LineaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModeloId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColourId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Estado = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesProduccion", x => x.Id);
                    table.UniqueConstraint("AK_OrdenesProduccion_CodigoOP", x => x.CodigoOP);
                    table.ForeignKey(
                        name: "FK_OrdenesProduccion_Colours_ColourId",
                        column: x => x.ColourId,
                        principalTable: "Colours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenesProduccion_LineasProduccion_LineaId",
                        column: x => x.LineaId,
                        principalTable: "LineasProduccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenesProduccion_Modelos_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "Modelos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alertas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reinicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LimiteAviso = table.Column<DateTime>(type: "datetime2", maxLength: 255, nullable: false),
                    Tipo = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    OrdenProduccionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alertas", x => x.Id);
                    table.UniqueConstraint("AK_Alertas_Reinicio", x => x.Reinicio);
                    table.ForeignKey(
                        name: "FK_Alertas_OrdenesProduccion_OrdenProduccionId",
                        column: x => x.OrdenProduccionId,
                        principalTable: "OrdenesProduccion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JornadasLaborales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", maxLength: 255, nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", maxLength: 255, nullable: false),
                    TurnoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodigoOP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPrimera = table.Column<int>(type: "int", nullable: false),
                    TotalSegunda = table.Column<int>(type: "int", nullable: false),
                    IdTurno = table.Column<int>(type: "int", nullable: false),
                    OrdenProduccionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JornadasLaborales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JornadasLaborales_OrdenesProduccion_OrdenProduccionId",
                        column: x => x.OrdenProduccionId,
                        principalTable: "OrdenesProduccion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JornadasLaborales_Turnos_TurnoId",
                        column: x => x.TurnoId,
                        principalTable: "Turnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rol = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    OrdenProduccionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.UniqueConstraint("AK_Usuarios_NameUsuario", x => x.NameUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_OrdenesProduccion_OrdenProduccionId",
                        column: x => x.OrdenProduccionId,
                        principalTable: "OrdenesProduccion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Incidencia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Hora = table.Column<int>(type: "int", nullable: false),
                    Pie = table.Column<int>(type: "int", nullable: false),
                    JornadaLaboralId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incidencia_JornadasLaborales_JornadaLaboralId",
                        column: x => x.JornadaLaboralId,
                        principalTable: "JornadasLaborales",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Primeras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Hora = table.Column<int>(type: "int", nullable: false),
                    JornadaLaboralId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Primeras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Primeras_JornadasLaborales_JornadaLaboralId",
                        column: x => x.JornadaLaboralId,
                        principalTable: "JornadasLaborales",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Defectos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDefecto = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    IncidenciaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defectos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Defectos_Incidencia_IncidenciaId",
                        column: x => x.IncidenciaId,
                        principalTable: "Incidencia",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alertas_OrdenProduccionId",
                table: "Alertas",
                column: "OrdenProduccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Defectos_IncidenciaId",
                table: "Defectos",
                column: "IncidenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencia_JornadaLaboralId",
                table: "Incidencia",
                column: "JornadaLaboralId");

            migrationBuilder.CreateIndex(
                name: "IX_JornadasLaborales_OrdenProduccionId",
                table: "JornadasLaborales",
                column: "OrdenProduccionId");

            migrationBuilder.CreateIndex(
                name: "IX_JornadasLaborales_TurnoId",
                table: "JornadasLaborales",
                column: "TurnoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesProduccion_ColourId",
                table: "OrdenesProduccion",
                column: "ColourId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesProduccion_LineaId",
                table: "OrdenesProduccion",
                column: "LineaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesProduccion_ModeloId",
                table: "OrdenesProduccion",
                column: "ModeloId");

            migrationBuilder.CreateIndex(
                name: "IX_Primeras_JornadaLaboralId",
                table: "Primeras",
                column: "JornadaLaboralId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_OrdenProduccionId",
                table: "Usuarios",
                column: "OrdenProduccionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alertas");

            migrationBuilder.DropTable(
                name: "Defectos");

            migrationBuilder.DropTable(
                name: "Primeras");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Incidencia");

            migrationBuilder.DropTable(
                name: "JornadasLaborales");

            migrationBuilder.DropTable(
                name: "OrdenesProduccion");

            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.DropTable(
                name: "Colours");

            migrationBuilder.DropTable(
                name: "LineasProduccion");

            migrationBuilder.DropTable(
                name: "Modelos");
        }
    }
}
