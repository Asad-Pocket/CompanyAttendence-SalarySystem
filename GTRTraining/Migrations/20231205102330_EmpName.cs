using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTRTraining.Migrations
{
    public partial class EmpName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmpName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpName",
                table: "Employees");
        }
    }
}
