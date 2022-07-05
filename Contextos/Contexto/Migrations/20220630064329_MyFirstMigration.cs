using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contexto.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Edad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContraseñaWeb = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "cuenta",
                columns: table => new
                {
                    CuentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroCuenta = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    MonedaCuenta = table.Column<int>(type: "int", maxLength: 150, nullable: false),
                    TipoCuenta = table.Column<int>(type: "int", nullable: false),
                    Linea = table.Column<double>(type: "float", nullable: false),
                    Saldo = table.Column<double>(type: "float", nullable: true),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cuenta", x => x.CuentaId);
                    table.ForeignKey(
                        name: "FK_cuenta_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "movimiento",
                columns: table => new
                {
                    MovimientoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CuentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Monto = table.Column<double>(type: "float", maxLength: 150, nullable: false),
                    Origen = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimiento", x => x.MovimientoId);
                    table.ForeignKey(
                        name: "FK_movimiento_cuenta_CuentaId",
                        column: x => x.CuentaId,
                        principalTable: "cuenta",
                        principalColumn: "CuentaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tarjeta",
                columns: table => new
                {
                    TarjetaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CuentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroTarjeta = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Año = table.Column<int>(type: "int", nullable: false),
                    CVV = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    PIN = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tarjeta", x => x.TarjetaId);
                    table.ForeignKey(
                        name: "FK_tarjeta_cuenta_CuentaId",
                        column: x => x.CuentaId,
                        principalTable: "cuenta",
                        principalColumn: "CuentaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tarjeta_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cuenta_UsuarioId",
                table: "cuenta",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_movimiento_CuentaId",
                table: "movimiento",
                column: "CuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_tarjeta_CuentaId",
                table: "tarjeta",
                column: "CuentaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tarjeta_UsuarioId",
                table: "tarjeta",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movimiento");

            migrationBuilder.DropTable(
                name: "tarjeta");

            migrationBuilder.DropTable(
                name: "cuenta");

            migrationBuilder.DropTable(
                name: "usuario");
        }
    }
}
