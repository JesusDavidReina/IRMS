using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IRMS.Migrations
{
    /// <inheritdoc />
    public partial class H2OHero_03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Accion",
                columns: table => new
                {
                    AccionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreAccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DispositivoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accion", x => x.AccionId);
                });

            migrationBuilder.CreateTable(
                name: "Clima",
                columns: table => new
                {
                    ClimaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreClima = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EfectoClima = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clima", x => x.ClimaId);
                });

            migrationBuilder.CreateTable(
                name: "Cultivo",
                columns: table => new
                {
                    CultivoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CultivoNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NivelAgua = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DispositivoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cultivo", x => x.CultivoId);
                });

            migrationBuilder.CreateTable(
                name: "Dispositivo",
                columns: table => new
                {
                    DispositivoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreDispositivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDispositivoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispositivo", x => x.DispositivoId);
                });

            migrationBuilder.CreateTable(
                name: "Jugador",
                columns: table => new
                {
                    JugadorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugador", x => x.JugadorId);
                });

            migrationBuilder.CreateTable(
                name: "TipoDispositivo",
                columns: table => new
                {
                    TipoDispositivoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTipoDispositivo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDispositivo", x => x.TipoDispositivoId);
                });

            migrationBuilder.CreateTable(
                name: "Granja",
                columns: table => new
                {
                    GranjaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreGranja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CultvoId = table.Column<int>(type: "int", nullable: false),
                    CultivoId = table.Column<int>(type: "int", nullable: false),
                    ClimaId = table.Column<int>(type: "int", nullable: false),
                    SistemaRiego = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dificultad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Granja", x => x.GranjaId);
                    table.ForeignKey(
                        name: "FK_Granja_Clima_ClimaId",
                        column: x => x.ClimaId,
                        principalTable: "Clima",
                        principalColumn: "ClimaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Granja_Cultivo_CultivoId",
                        column: x => x.CultivoId,
                        principalTable: "Cultivo",
                        principalColumn: "CultivoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Partida",
                columns: table => new
                {
                    PartidaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GranjaId = table.Column<int>(type: "int", nullable: false),
                    Puntuacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaGuardado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PartidaEstado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JugadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partida", x => x.PartidaId);
                    table.ForeignKey(
                        name: "FK_Partida_Granja_GranjaId",
                        column: x => x.GranjaId,
                        principalTable: "Granja",
                        principalColumn: "GranjaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Partida_Jugador_JugadorId",
                        column: x => x.JugadorId,
                        principalTable: "Jugador",
                        principalColumn: "JugadorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccionXPartida",
                columns: table => new
                {
                    AccionPartidaId = table.Column<int>(type: "int", nullable: false),
                    AccionId = table.Column<int>(type: "int", nullable: false),
                    PartidaId = table.Column<int>(type: "int", nullable: false),
                    FechaAxP = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccionXPartida", x => new { x.AccionPartidaId, x.AccionId, x.PartidaId });
                    table.ForeignKey(
                        name: "FK_AccionXPartida_Accion_AccionId",
                        column: x => x.AccionId,
                        principalTable: "Accion",
                        principalColumn: "AccionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccionXPartida_Partida_PartidaId",
                        column: x => x.PartidaId,
                        principalTable: "Partida",
                        principalColumn: "PartidaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccionXPartida_AccionId",
                table: "AccionXPartida",
                column: "AccionId");

            migrationBuilder.CreateIndex(
                name: "IX_AccionXPartida_PartidaId",
                table: "AccionXPartida",
                column: "PartidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Granja_ClimaId",
                table: "Granja",
                column: "ClimaId");

            migrationBuilder.CreateIndex(
                name: "IX_Granja_CultivoId",
                table: "Granja",
                column: "CultivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_GranjaId",
                table: "Partida",
                column: "GranjaId");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_JugadorId",
                table: "Partida",
                column: "JugadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccionXPartida");

            migrationBuilder.DropTable(
                name: "Dispositivo");

            migrationBuilder.DropTable(
                name: "TipoDispositivo");

            migrationBuilder.DropTable(
                name: "Accion");

            migrationBuilder.DropTable(
                name: "Partida");

            migrationBuilder.DropTable(
                name: "Granja");

            migrationBuilder.DropTable(
                name: "Jugador");

            migrationBuilder.DropTable(
                name: "Clima");

            migrationBuilder.DropTable(
                name: "Cultivo");

            migrationBuilder.CreateTable(
                name: "Acciones",
                columns: table => new
                {
                    AccionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DispositivoId = table.Column<int>(type: "int", nullable: false),
                    NombreAccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acciones", x => x.AccionId);
                });

            migrationBuilder.CreateTable(
                name: "Climas",
                columns: table => new
                {
                    ClimaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EfectoClima = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreClima = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Climas", x => x.ClimaId);
                });

            migrationBuilder.CreateTable(
                name: "Cultivos",
                columns: table => new
                {
                    CultivoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CultivoNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DispositivoId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NivelAgua = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cultivos", x => x.CultivoId);
                });

            migrationBuilder.CreateTable(
                name: "Dispositivos",
                columns: table => new
                {
                    DispositivoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreDispositivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDispositivoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispositivos", x => x.DispositivoId);
                });

            migrationBuilder.CreateTable(
                name: "Jugadores",
                columns: table => new
                {
                    JugadorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    photo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugadores", x => x.JugadorId);
                });

            migrationBuilder.CreateTable(
                name: "TipoDispositivos",
                columns: table => new
                {
                    TipoDispositivoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTipoDispositivo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDispositivos", x => x.TipoDispositivoId);
                });

            migrationBuilder.CreateTable(
                name: "Granjas",
                columns: table => new
                {
                    GranjaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClimaId = table.Column<int>(type: "int", nullable: false),
                    CultivoId = table.Column<int>(type: "int", nullable: false),
                    CultvoId = table.Column<int>(type: "int", nullable: false),
                    Dificultad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreGranja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SistemaRiego = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Granjas", x => x.GranjaId);
                    table.ForeignKey(
                        name: "FK_Granjas_Climas_ClimaId",
                        column: x => x.ClimaId,
                        principalTable: "Climas",
                        principalColumn: "ClimaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Granjas_Cultivos_CultivoId",
                        column: x => x.CultivoId,
                        principalTable: "Cultivos",
                        principalColumn: "CultivoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Partidas",
                columns: table => new
                {
                    PartidaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GranjaId = table.Column<int>(type: "int", nullable: false),
                    JugadorId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaGuardado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PartidaEstado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Puntuacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidas", x => x.PartidaId);
                    table.ForeignKey(
                        name: "FK_Partidas_Granjas_GranjaId",
                        column: x => x.GranjaId,
                        principalTable: "Granjas",
                        principalColumn: "GranjaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Partidas_Jugadores_JugadorId",
                        column: x => x.JugadorId,
                        principalTable: "Jugadores",
                        principalColumn: "JugadorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccionXPartidas",
                columns: table => new
                {
                    AccionPartidaId = table.Column<int>(type: "int", nullable: false),
                    AccionId = table.Column<int>(type: "int", nullable: false),
                    PartidaId = table.Column<int>(type: "int", nullable: false),
                    FechaAxP = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccionXPartidas", x => new { x.AccionPartidaId, x.AccionId, x.PartidaId });
                    table.ForeignKey(
                        name: "FK_AccionXPartidas_Acciones_AccionId",
                        column: x => x.AccionId,
                        principalTable: "Acciones",
                        principalColumn: "AccionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccionXPartidas_Partidas_PartidaId",
                        column: x => x.PartidaId,
                        principalTable: "Partidas",
                        principalColumn: "PartidaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccionXPartidas_AccionId",
                table: "AccionXPartidas",
                column: "AccionId");

            migrationBuilder.CreateIndex(
                name: "IX_AccionXPartidas_PartidaId",
                table: "AccionXPartidas",
                column: "PartidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Granjas_ClimaId",
                table: "Granjas",
                column: "ClimaId");

            migrationBuilder.CreateIndex(
                name: "IX_Granjas_CultivoId",
                table: "Granjas",
                column: "CultivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidas_GranjaId",
                table: "Partidas",
                column: "GranjaId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidas_JugadorId",
                table: "Partidas",
                column: "JugadorId");
        }
    }
}
