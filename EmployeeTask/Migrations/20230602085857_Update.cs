using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeTask.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresss_Employees_EmployeeModelId",
                table: "Addresss");

            migrationBuilder.DropIndex(
                name: "IX_Addresss_EmployeeModelId",
                table: "Addresss");

            migrationBuilder.DropColumn(
                name: "EmployeeModelId",
                table: "Addresss");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Addresss",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Addresss_EmployeeId",
                table: "Addresss",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresss_Employees_EmployeeId",
                table: "Addresss",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresss_Employees_EmployeeId",
                table: "Addresss");

            migrationBuilder.DropIndex(
                name: "IX_Addresss_EmployeeId",
                table: "Addresss");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Addresss");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeModelId",
                table: "Addresss",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresss_EmployeeModelId",
                table: "Addresss",
                column: "EmployeeModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresss_Employees_EmployeeModelId",
                table: "Addresss",
                column: "EmployeeModelId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
