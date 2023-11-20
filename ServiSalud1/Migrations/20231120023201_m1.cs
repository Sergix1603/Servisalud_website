using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServiSalud1.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
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
                    Nombreclinica = table.Column<string>(name: "Nombre_clinica", type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Ubicacion = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
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
                    Nombreequipo = table.Column<string>(name: "Nombre_equipo", type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                    Especialidadnombre = table.Column<string>(name: "Especialidad_nombre", type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                    Alergias = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historial_Clinico", x => x.Idhistorial);
                });

            migrationBuilder.CreateTable(
                name: "Login_Empleado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login_Empleado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Login_Paciente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login_Paciente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<string>(name: "Id_Usuario", type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    Idserv = table.Column<int>(name: "Id_serv", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nomserv = table.Column<string>(name: "Nom_serv", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Idequipo = table.Column<int>(name: "Id_equipo", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.Idserv);
                    table.ForeignKey(
                        name: "FK_Servicios_Equipo_produccion_Id_equipo",
                        column: x => x.Idequipo,
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
                    Nombreempleado = table.Column<string>(name: "Nombre_empleado", type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Idespecialidad = table.Column<int>(name: "Id_especialidad", type: "int", nullable: false),
                    IdClinica = table.Column<int>(name: "Id_Clinica", type: "int", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Citas",
                columns: table => new
                {
                    Idcitas = table.Column<int>(name: "Id_citas", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fechascitas = table.Column<DateTime>(name: "Fechas_citas", type: "datetime2", nullable: false),
                    Idespecialidad = table.Column<int>(name: "Id_especialidad", type: "int", nullable: false),
                    Idhistorial = table.Column<int>(name: "Id_historial", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.Idcitas);
                    table.ForeignKey(
                        name: "FK_Citas_Especialidad_Id_especialidad",
                        column: x => x.Idespecialidad,
                        principalTable: "Especialidad",
                        principalColumn: "Id_especialidad",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citas_Historial_Clinico_Id_historial",
                        column: x => x.Idhistorial,
                        principalTable: "Historial_Clinico",
                        principalColumn: "Id_historial",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Idpacientes = table.Column<int>(name: "Id_pacientes", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: false),
                    Altura = table.Column<double>(type: "float", nullable: false),
                    Antecedentes = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: true),
                    Idhistorial = table.Column<int>(name: "Id_historial", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Idpacientes);
                    table.ForeignKey(
                        name: "FK_Pacientes_Historial_Clinico_Id_historial",
                        column: x => x.Idhistorial,
                        principalTable: "Historial_Clinico",
                        principalColumn: "Id_historial",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clinica_servicios",
                columns: table => new
                {
                    Idclinica = table.Column<int>(name: "Id_clinica", type: "int", nullable: false),
                    Idserv = table.Column<int>(name: "Id_serv", type: "int", nullable: false),
                    IdClinicaservicios = table.Column<int>(name: "Id_Clinica_servicios", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinica_servicios", x => new { x.Idclinica, x.Idserv });
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

            migrationBuilder.InsertData(
                table: "Clinica",
                columns: new[] { "Id_Clinica", "Nombre_clinica", "Ubicacion" },
                values: new object[,]
                {
                    { 101, "SERVISALUD CESPEDES", "Tomaykichwa" },
                    { 102, "SERVISALUD CESPEDES", "Lima" }
                });

            migrationBuilder.InsertData(
                table: "Equipo_produccion",
                columns: new[] { "Id_equipo", "Nombre_equipo" },
                values: new object[,]
                {
                    { 220, "Esfingomanometro" },
                    { 221, "Termostato" },
                    { 222, "Rayos X" },
                    { 223, "Guantes Latex" },
                    { 224, "Ultra sonido" },
                    { 225, "Estetoscopio" },
                    { 226, "Tensiometro Aneroide" },
                    { 227, "Sillones reclinables" },
                    { 228, "Computadora" },
                    { 229, "Bascula" }
                });

            migrationBuilder.InsertData(
                table: "Especialidad",
                columns: new[] { "Id_especialidad", "Especialidad_nombre" },
                values: new object[,]
                {
                    { 4120, "Reumatología" },
                    { 4121, "Dermatología" },
                    { 4122, "Enfermería" },
                    { 4123, "Cardiología" },
                    { 4124, "Nutrición" },
                    { 4125, "Endocrinología" },
                    { 4126, "Neurología" },
                    { 4127, "Traumatología" },
                    { 4128, "Terapia" },
                    { 4129, "Psicología" }
                });

            migrationBuilder.InsertData(
                table: "Historial_Clinico",
                columns: new[] { "Id_historial", "Alergias", "Fecha_ingreso" },
                values: new object[,]
                {
                    { 851, "Aines", new DateTime(2023, 11, 19, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 852, "-", new DateTime(2023, 11, 19, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id_Usuario", "Apellido", "Contra", "Nombre", "TipoUsuario" },
                values: new object[,]
                {
                    { "admin", "Cornejo", "admin", "Adrian", "Administrador" },
                    { "LQuispe", "Quispe", "12345", "Luis", "Empleado" },
                    { "Spiderman", "Parker", "12345", "Peter", "Paciente" }
                });

            migrationBuilder.InsertData(
                table: "Citas",
                columns: new[] { "Id_citas", "Fechas_citas", "Id_especialidad", "Id_historial" },
                values: new object[] { 9621, new DateTime(2023, 1, 25, 14, 30, 0, 0, DateTimeKind.Unspecified), 4121, 851 });

            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "Id_empleado", "Id_Clinica", "Id_especialidad", "Nacimiento", "Nombre_empleado", "Sexo", "Telefono" },
                values: new object[,]
                {
                    { 202001, 102, 4121, new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carlos Vasquez", "M", 941449558 },
                    { 202002, 101, 4120, new DateTime(1981, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luis Quispe", "M", 941449544 },
                    { 202003, 102, 4122, new DateTime(1975, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ernesto Vargas", "M", 941446411 },
                    { 202004, 102, 4123, new DateTime(1980, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan Contreras", "M", 941449542 },
                    { 202005, 101, 4124, new DateTime(1971, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ruben Hurtado", "M", 941449526 }
                });

            migrationBuilder.InsertData(
                table: "Pacientes",
                columns: new[] { "Id_pacientes", "Altura", "Antecedentes", "Apellido", "Correo", "DNI", "Direccion", "Id_historial", "Nacimiento", "Nombre", "Peso", "Sexo", "Telefono" },
                values: new object[] { 15020, 1.6499999999999999, "Cancer", "Burga", "sergioB@gmail.com", "73255963", "Calle La Libertad 124, La Molina", 851, new DateTime(2004, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergio", 80.5, "M", "987654321" });

            migrationBuilder.InsertData(
                table: "Servicios",
                columns: new[] { "Id_serv", "Id_equipo", "Nom_serv" },
                values: new object[,]
                {
                    { 7001, 220, "Urgencias" },
                    { 7002, 221, "Pediatria" },
                    { 7003, 222, "Radiografias" },
                    { 7004, 223, "Dermatologia" },
                    { 7005, 224, "Terapia" },
                    { 7006, 225, "Medicina General" },
                    { 7007, 226, "Ambulancias" },
                    { 7008, 227, "Psicologia" },
                    { 7009, 228, "Ventanilla" },
                    { 7010, 229, "Triaje" }
                });

            migrationBuilder.InsertData(
                table: "Clinica_servicios",
                columns: new[] { "Id_clinica", "Id_serv", "Id_Clinica_servicios" },
                values: new object[,]
                {
                    { 101, 7001, 111 },
                    { 101, 7002, 112 },
                    { 101, 7005, 113 },
                    { 101, 7006, 114 },
                    { 101, 7007, 115 },
                    { 101, 7009, 116 },
                    { 101, 7010, 117 },
                    { 102, 7001, 118 },
                    { 102, 7002, 129 },
                    { 102, 7003, 120 },
                    { 102, 7004, 121 },
                    { 102, 7005, 122 },
                    { 102, 7006, 123 },
                    { 102, 7007, 124 },
                    { 102, 7008, 125 },
                    { 102, 7009, 126 },
                    { 102, 7010, 127 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_Id_especialidad",
                table: "Citas",
                column: "Id_especialidad");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_Id_historial",
                table: "Citas",
                column: "Id_historial");

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
                name: "IX_Pacientes_Id_historial",
                table: "Pacientes",
                column: "Id_historial",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_Id_equipo",
                table: "Servicios",
                column: "Id_equipo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Clinica_servicios");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Login_Empleado");

            migrationBuilder.DropTable(
                name: "Login_Paciente");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Clinica");

            migrationBuilder.DropTable(
                name: "Especialidad");

            migrationBuilder.DropTable(
                name: "Historial_Clinico");

            migrationBuilder.DropTable(
                name: "Equipo_produccion");
        }
    }
}
