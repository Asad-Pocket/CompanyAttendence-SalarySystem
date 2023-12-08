using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTRTraining.Migrations
{
    public partial class attendancetype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "OutTime",
                table: "Attendence",
                type: "time",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "InTime",
                table: "Attendence",
                type: "time",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OutTime",
                table: "Attendence",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InTime",
                table: "Attendence",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);
        }
    }
}
