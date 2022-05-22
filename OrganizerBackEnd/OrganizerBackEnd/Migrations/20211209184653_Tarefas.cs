using Microsoft.EntityFrameworkCore.Migrations;

namespace OrganizerBackEnd.Migrations
{
    public partial class Tarefas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Listas_ListaId",
                table: "Tarefas");

            migrationBuilder.AlterColumn<int>(
                name: "ListaId",
                table: "Tarefas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Listas_ListaId",
                table: "Tarefas",
                column: "ListaId",
                principalTable: "Listas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Listas_ListaId",
                table: "Tarefas");

            migrationBuilder.AlterColumn<int>(
                name: "ListaId",
                table: "Tarefas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Listas_ListaId",
                table: "Tarefas",
                column: "ListaId",
                principalTable: "Listas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
