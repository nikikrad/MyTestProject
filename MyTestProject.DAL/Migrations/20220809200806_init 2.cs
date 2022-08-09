using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTestProject.DAL.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_PCs_PCId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_PCId",
                table: "Players");

            migrationBuilder.AlterColumn<int>(
                name: "PCId",
                table: "Players",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PCId",
                table: "Players",
                column: "PCId",
                unique: true,
                filter: "[PCId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_PCs_PCId",
                table: "Players",
                column: "PCId",
                principalTable: "PCs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_PCs_PCId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_PCId",
                table: "Players");

            migrationBuilder.AlterColumn<int>(
                name: "PCId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_PCId",
                table: "Players",
                column: "PCId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_PCs_PCId",
                table: "Players",
                column: "PCId",
                principalTable: "PCs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
