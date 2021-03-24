using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpirePersonellLedger.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrooperTypes",
                columns: table => new
                {
                    TypeName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Speciality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weapon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrooperTypes", x => x.TypeName);
                });

            migrationBuilder.CreateTable(
                name: "Troopers",
                columns: table => new
                {
                    TrooperId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperatingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcquisitionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrooperTypeTypeName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Troopers", x => x.TrooperId);
                    table.ForeignKey(
                        name: "FK_Troopers_TrooperTypes_TrooperTypeTypeName",
                        column: x => x.TrooperTypeTypeName,
                        principalTable: "TrooperTypes",
                        principalColumn: "TypeName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Troopers_TrooperTypeTypeName",
                table: "Troopers",
                column: "TrooperTypeTypeName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Troopers");

            migrationBuilder.DropTable(
                name: "TrooperTypes");
        }
    }
}
