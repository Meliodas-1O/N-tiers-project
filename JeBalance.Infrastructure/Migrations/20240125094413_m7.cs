using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JeBalance.Infrastructure.Migrations
{
    public partial class m7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reponses_Denonciations_Id",
                table: "Reponses");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Reponses",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "DenonciationId",
                table: "Reponses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReponseId",
                table: "Denonciations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Denonciations_ReponseId",
                table: "Denonciations",
                column: "ReponseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Denonciations_Reponses_ReponseId",
                table: "Denonciations",
                column: "ReponseId",
                principalTable: "Reponses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Denonciations_Reponses_ReponseId",
                table: "Denonciations");

            migrationBuilder.DropIndex(
                name: "IX_Denonciations_ReponseId",
                table: "Denonciations");

            migrationBuilder.DropColumn(
                name: "DenonciationId",
                table: "Reponses");

            migrationBuilder.DropColumn(
                name: "ReponseId",
                table: "Denonciations");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Reponses",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reponses_Denonciations_Id",
                table: "Reponses",
                column: "Id",
                principalTable: "Denonciations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
