using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AirCompany.Domain.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "aircraft",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    model = table.Column<string>(type: "text", nullable: true),
                    capacity = table.Column<double>(type: "double precision", nullable: true),
                    performance = table.Column<double>(type: "double precision", nullable: true),
                    max_passengers = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aircraft", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    passport_number = table.Column<string>(type: "text", nullable: true),
                    full_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "flight",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<string>(type: "text", nullable: true),
                    departure_point = table.Column<string>(type: "text", nullable: true),
                    arrival_point = table.Column<string>(type: "text", nullable: true),
                    departure_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    arrival_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AircraftTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flight", x => x.id);
                    table.ForeignKey(
                        name: "FK_flight_aircraft_AircraftTypeId",
                        column: x => x.AircraftTypeId,
                        principalTable: "aircraft",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "registered_passenger",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<string>(type: "text", nullable: true),
                    seat_number = table.Column<string>(type: "text", nullable: true),
                    luggage_weight = table.Column<double>(type: "double precision", nullable: true),
                    FlightId = table.Column<int>(type: "integer", nullable: false),
                    PassengerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registered_passenger", x => x.id);
                    table.ForeignKey(
                        name: "FK_registered_passenger_Passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passengers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_registered_passenger_flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "flight",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_flight_AircraftTypeId",
                table: "flight",
                column: "AircraftTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_registered_passenger_FlightId",
                table: "registered_passenger",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_registered_passenger_PassengerId",
                table: "registered_passenger",
                column: "PassengerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "registered_passenger");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "flight");

            migrationBuilder.DropTable(
                name: "aircraft");
        }
    }
}
