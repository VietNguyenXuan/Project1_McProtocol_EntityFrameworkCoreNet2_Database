using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WindowsFormsApp1.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    D3000 = table.Column<string>(type: "TEXT", nullable: true),
                    D3001 = table.Column<string>(type: "TEXT", nullable: true),
                    D3002 = table.Column<string>(type: "TEXT", nullable: true),
                    D3003 = table.Column<string>(type: "TEXT", nullable: true),
                    D3004 = table.Column<string>(type: "TEXT", nullable: true),
                    D3005 = table.Column<string>(type: "TEXT", nullable: true),
                    D3006 = table.Column<string>(type: "TEXT", nullable: true),
                    D3007 = table.Column<string>(type: "TEXT", nullable: true),
                    D3008 = table.Column<string>(type: "TEXT", nullable: true),
                    D3009 = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
