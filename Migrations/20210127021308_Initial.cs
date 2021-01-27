using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ObjectsLoaneds.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObjectsLoaneds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamePeopleLoaned = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameObjectLoaned = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateLoanedObject = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LimitDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectsLoaneds", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObjectsLoaneds");
        }
    }
}
