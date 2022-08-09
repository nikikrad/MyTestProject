using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTestProject.DAL.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PCs_OSs_OSId",
                table: "PCs");

            migrationBuilder.AlterColumn<int>(
                name: "OSId",
                table: "PCs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PCs_OSs_OSId",
                table: "PCs",
                column: "OSId",
                principalTable: "OSs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PCs_OSs_OSId",
                table: "PCs");

            migrationBuilder.AlterColumn<int>(
                name: "OSId",
                table: "PCs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PCs_OSs_OSId",
                table: "PCs",
                column: "OSId",
                principalTable: "OSs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
