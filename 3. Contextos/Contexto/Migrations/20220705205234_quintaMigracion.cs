using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contexto.Migrations
{
    public partial class quintaMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cuenta_usuario_UsuarioId",
                table: "cuenta");

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "cuenta",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_cuenta_usuario_UsuarioId",
                table: "cuenta",
                column: "UsuarioId",
                principalTable: "usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cuenta_usuario_UsuarioId",
                table: "cuenta");

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "cuenta",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_cuenta_usuario_UsuarioId",
                table: "cuenta",
                column: "UsuarioId",
                principalTable: "usuario",
                principalColumn: "UsuarioId");
        }
    }
}
