using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUD.API.Dev.Migrations
{
    public partial class DocumentMigraion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ressources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Number = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Title = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DocPath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    EffectiveDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Doctype = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ressources", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ressources");
        }
    }
}
