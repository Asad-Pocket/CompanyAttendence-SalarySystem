using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTRTraining.Migrations
{
    public partial class attendance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attendence",
                columns: table => new
                {
                    ComId = table.Column<int>(type: "int", nullable: false),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    dtDate = table.Column<DateTime>(type: "date", nullable: false),
                    AttStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OutTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendence", x => new { x.ComId, x.EmpId, x.dtDate });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendence");
        }
    }
}
