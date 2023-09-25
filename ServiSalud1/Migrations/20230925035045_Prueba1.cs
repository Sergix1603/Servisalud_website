using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServiSalud1.Migrations
{
    /// <inheritdoc />
    public partial class Prueba1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clinica",
                columns: table => new
                {
                    IdClinica = table.Column<int>(name: "Id_Clinica", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombreclinica = table.Column<string>(name: "Nombre_clinica", type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinica", x => x.IdClinica);
                });

            migrationBuilder.CreateTable(
                name: "Equipo_produccion",
                columns: table => new
                {
                    Idequipo = table.Column<int>(name: "Id_equipo", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombreequipo = table.Column<string>(name: "Nombre_equipo", type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipo_produccion", x => x.Idequipo);
                });

            migrationBuilder.CreateTable(
                name: "Especialidad",
                columns: table => new
                {
                    Idespecialidad = table.Column<int>(name: "Id_especialidad", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Especialidadnombre = table.Column<string>(name: "Especialidad_nombre", type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidad", x => x.Idespecialidad);
                });

            migrationBuilder.CreateTable(
                name: "Historial_Clinico",
                columns: table => new
                {
                    Idhistorial = table.Column<int>(name: "Id_historial", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fechaingreso = table.Column<DateTime>(name: "Fecha_ingreso", type: "datetime2", nullable: false),
                    Alergias = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UltimoritocardiacoXminuto = table.Column<int>(name: "Ultimo_rito_cardiaco_X_minuto", type: "int", nullable: false),
                    Estadocardiaco = table.Column<string>(name: "Estado_cardiaco", type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historial_Clinico", x => x.Idhistorial);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    Idserv = table.Column<int>(name: "Id_serv", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nomserv = table.Column<string>(name: "Nom_serv", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Idequipo = table.Column<int>(name: "Id_equipo", type: "int", nullable: false),
                    EquipoProduccionIdequipo = table.Column<int>(name: "Equipo_ProduccionId_equipo", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.Idserv);
                    table.ForeignKey(
                        name: "FK_Servicios_Equipo_produccion_Equipo_ProduccionId_equipo",
                        column: x => x.EquipoProduccionIdequipo,
                        principalTable: "Equipo_produccion",
                        principalColumn: "Id_equipo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Idempleado = table.Column<int>(name: "Id_empleado", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombreempleado = table.Column<string>(name: "Nombre_empleado", type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Apellidoempleado = table.Column<string>(name: "Apellido_empleado", type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Idespecialidad = table.Column<int>(name: "Id_especialidad", type: "int", nullable: false),
                    IdClinica = table.Column<int>(name: "Id_Clinica", type: "int", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Idempleado);
                    table.ForeignKey(
                        name: "FK_Empleados_Clinica_Id_Clinica",
                        column: x => x.IdClinica,
                        principalTable: "Clinica",
                        principalColumn: "Id_Clinica",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Empleados_Especialidad_Id_especialidad",
                        column: x => x.Idespecialidad,
                        principalTable: "Especialidad",
                        principalColumn: "Id_especialidad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Idpacientes = table.Column<int>(name: "Id_pacientes", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<int>(type: "int", maxLength: 9, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Idhistorial = table.Column<int>(name: "Id_historial", type: "int", nullable: false),
                    HistorialClinicoIdhistorial = table.Column<int>(name: "Historial_ClinicoId_historial", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Idpacientes);
                    table.ForeignKey(
                        name: "FK_Pacientes_Historial_Clinico_Historial_ClinicoId_historial",
                        column: x => x.HistorialClinicoIdhistorial,
                        principalTable: "Historial_Clinico",
                        principalColumn: "Id_historial",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clinica_servicios",
                columns: table => new
                {
                    IdClinicaservicios = table.Column<int>(name: "Id_Clinica_servicios", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Idclinica = table.Column<int>(name: "Id_clinica", type: "int", nullable: false),
                    Idserv = table.Column<int>(name: "Id_serv", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinica_servicios", x => x.IdClinicaservicios);
                    table.ForeignKey(
                        name: "FK_Clinica_servicios_Clinica_Id_clinica",
                        column: x => x.Idclinica,
                        principalTable: "Clinica",
                        principalColumn: "Id_Clinica",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clinica_servicios_Servicios_Id_serv",
                        column: x => x.Idserv,
                        principalTable: "Servicios",
                        principalColumn: "Id_serv",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    Idcitas = table.Column<int>(name: "Id_citas", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fechascitas = table.Column<DateTime>(name: "Fechas_citas", type: "datetime2", nullable: false),
                    Idempleado = table.Column<int>(name: "Id_empleado", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.Idcitas);
                    table.ForeignKey(
                        name: "FK_Citas_Empleados_Id_empleado",
                        column: x => x.Idempleado,
                        principalTable: "Empleados",
                        principalColumn: "Id_empleado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Historial_citas",
                columns: table => new
                {
                    IDHistorialcitas = table.Column<int>(name: "ID_Historial_citas", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Idhistorial = table.Column<int>(name: "Id_historial", type: "int", nullable: false),
                    HistorialClinicoIdhistorial = table.Column<int>(name: "Historial_ClinicoId_historial", type: "int", nullable: false),
                    Idcitas = table.Column<int>(name: "Id_citas", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historial_citas", x => x.IDHistorialcitas);
                    table.ForeignKey(
                        name: "FK_Historial_citas_Citas_Id_citas",
                        column: x => x.Idcitas,
                        principalTable: "Citas",
                        principalColumn: "Id_citas",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Historial_citas_Historial_Clinico_Historial_ClinicoId_historial",
                        column: x => x.HistorialClinicoIdhistorial,
                        principalTable: "Historial_Clinico",
                        principalColumn: "Id_historial",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clinica",
                columns: new[] { "Id_Clinica", "Nombre_clinica", "Ubicacion" },
                values: new object[,]
                {
                    { 101, "SERVISALUD CESPEDES", "Tomaykichwa" },
                    { 102, "SERVISALUD CESPEDES", "Lima" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_Id_empleado",
                table: "Citas",
                column: "Id_empleado");

            migrationBuilder.CreateIndex(
                name: "IX_Clinica_servicios_Id_clinica",
                table: "Clinica_servicios",
                column: "Id_clinica");

            migrationBuilder.CreateIndex(
                name: "IX_Clinica_servicios_Id_serv",
                table: "Clinica_servicios",
                column: "Id_serv");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_Id_Clinica",
                table: "Empleados",
                column: "Id_Clinica");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_Id_especialidad",
                table: "Empleados",
                column: "Id_especialidad");

            migrationBuilder.CreateIndex(
                name: "IX_Historial_citas_Historial_ClinicoId_historial",
                table: "Historial_citas",
                column: "Historial_ClinicoId_historial");

            migrationBuilder.CreateIndex(
                name: "IX_Historial_citas_Id_citas",
                table: "Historial_citas",
                column: "Id_citas");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_Historial_ClinicoId_historial",
                table: "Pacientes",
                column: "Historial_ClinicoId_historial");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_Equipo_ProduccionId_equipo",
                table: "Servicios",
                column: "Equipo_ProduccionId_equipo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clinica_servicios");

            migrationBuilder.DropTable(
                name: "Historial_citas");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Historial_Clinico");

            migrationBuilder.DropTable(
                name: "Equipo_produccion");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Clinica");

            migrationBuilder.DropTable(
                name: "Especialidad");
        }
    }
}
