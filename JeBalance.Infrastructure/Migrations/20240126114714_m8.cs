using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JeBalance.Infrastructure.Migrations
{
    public partial class m8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Denonciations_Reponses_ReponseId",
                table: "Denonciations");

            migrationBuilder.AlterColumn<int>(
                name: "ReponseId",
                table: "Denonciations",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Denonciations_Reponses_ReponseId",
                table: "Denonciations",
                column: "ReponseId",
                principalTable: "Reponses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Denonciations_Reponses_ReponseId",
                table: "Denonciations");

            migrationBuilder.AlterColumn<int>(
                name: "ReponseId",
                table: "Denonciations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Denonciations_Reponses_ReponseId",
                table: "Denonciations",
                column: "ReponseId",
                principalTable: "Reponses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
