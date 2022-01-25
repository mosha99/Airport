using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airport.Migrations
{
    public partial class vol1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airplans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airplans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AirPorts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    X = table.Column<double>(type: "float", nullable: false),
                    Y = table.Column<double>(type: "float", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirPorts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pasengers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasengers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartLocationId = table.Column<int>(type: "int", nullable: true),
                    EndLocationId = table.Column<int>(type: "int", nullable: true),
                    AirplanId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_Airplans_AirplanId",
                        column: x => x.AirplanId,
                        principalTable: "Airplans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flights_AirPorts_EndLocationId",
                        column: x => x.EndLocationId,
                        principalTable: "AirPorts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flights_AirPorts_StartLocationId",
                        column: x => x.StartLocationId,
                        principalTable: "AirPorts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Flighpasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightId = table.Column<int>(type: "int", nullable: true),
                    PasengerId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flighpasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flighpasses_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flighpasses_Pasengers_PasengerId",
                        column: x => x.PasengerId,
                        principalTable: "Pasengers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FlightsInfo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pasengerId = table.Column<int>(type: "int", nullable: true),
                    FlightId = table.Column<int>(type: "int", nullable: true),
                    ArrivedOnPlane = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightsInfo", x => x.id);
                    table.ForeignKey(
                        name: "FK_FlightsInfo_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FlightsInfo_Pasengers_pasengerId",
                        column: x => x.pasengerId,
                        principalTable: "Pasengers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flighpasses_FlightId",
                table: "Flighpasses",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Flighpasses_PasengerId",
                table: "Flighpasses",
                column: "PasengerId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirplanId",
                table: "Flights",
                column: "AirplanId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_EndLocationId",
                table: "Flights",
                column: "EndLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_StartLocationId",
                table: "Flights",
                column: "StartLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightsInfo_FlightId",
                table: "FlightsInfo",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightsInfo_pasengerId",
                table: "FlightsInfo",
                column: "pasengerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flighpasses");

            migrationBuilder.DropTable(
                name: "FlightsInfo");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Pasengers");

            migrationBuilder.DropTable(
                name: "Airplans");

            migrationBuilder.DropTable(
                name: "AirPorts");
        }
    }
}
