using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiInventario.Migrations
{
    public partial class crearDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: " Equipments",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Marca = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ Equipments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: " Details",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idEquipo = table.Column<int>(nullable: false),
                    nombreEquipo = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ Details_ Equipments_idEquipo",
                        column: x => x.idEquipo,
                        principalSchema: "dbo",
                        principalTable: " Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ Details_idEquipo",
                schema: "dbo",
                table: " Details",
                column: "idEquipo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: " Details",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: " Equipments",
                schema: "dbo");
        }
    }
}
