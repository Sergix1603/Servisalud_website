using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                    Nombreclinica = table.Column<string>(name: "Nombre_clinica", type: "nvarchar(max)", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinica", x => x.IdClinica);
                });

            migrationBuilder.CreateTable(
                name: "Especialidad",
                columns: table => new
                {
                    Idespecialidad = table.Column<int>(name: "Id_especialidad", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Especialidadnombre = table.Column<string>(name: "Especialidad_nombre", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidad", x => x.Idespecialidad);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Idempleado = table.Column<int>(name: "Id_empleado", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombreempleado = table.Column<string>(name: "Nombre_empleado", type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Apellidoempleado = table.Column<string>(name: "Apellido_empleado", type: "nvarchar(60)", maxLength: 60, nullable: false),
                    IdEspecialidad = table.Column<int>(name: "Id_Especialidad", type: "int", nullable: false),
                    Idclinica = table.Column<int>(name: "Id_clinica", type: "int", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Idempleado);
                    table.ForeignKey(
                        name: "FK_Empleados_Clinica_Id_clinica",
                        column: x => x.Idclinica,
                        principalTable: "Clinica",
                        principalColumn: "Id_Clinica",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Empleados_Especialidad_Id_Especialidad",
                        column: x => x.IdEspecialidad,
                        principalTable: "Especialidad",
                        principalColumn: "Id_especialidad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_Id_clinica",
                table: "Empleados",
                column: "Id_clinica");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_Id_Especialidad",
                table: "Empleados",
                column: "Id_Especialidad");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Clinica");

            migrationBuilder.DropTable(
                name: "Especialidad");
        }
    }
}
