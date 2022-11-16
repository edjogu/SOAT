using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SOATSales.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CityName = table.Column<string>(maxLength: 100, nullable: false),
                    IsForSOAT = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    PolicyNumber = table.Column<string>(maxLength: 14, nullable: false),
                    DateOfIssue = table.Column<DateTimeOffset>(nullable: false),
                    DateOfStart = table.Column<DateTimeOffset>(nullable: false),
                    DateOfExpiration = table.Column<DateTimeOffset>(nullable: false),
                    LicencePlate = table.Column<string>(maxLength: 10, nullable: false),
                    CityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Policies_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityName", "IsForSOAT" },
                values: new object[,]
                {
                    { new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), "Bogota", true },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"), "Cartagena", true },
                    { new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"), "Barranquilla", false },
                    { new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"), "Medellin", true }
                });

            migrationBuilder.InsertData(
                table: "Policies",
                columns: new[] { "Id", "CityId", "DateOfExpiration", "DateOfIssue", "DateOfStart", "FirstName", "LastName", "LicencePlate", "PolicyNumber" },
                values: new object[,]
                {
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9888"), new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), new DateTimeOffset(new DateTime(2022, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)), "Raul", "Perez", "ABC547", "14575000853560" },
                    { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"), new DateTimeOffset(new DateTime(2023, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)), "Nancy", "Garcerant", "ABC888", "14579000853599" },
                    { new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"), new DateTimeOffset(new DateTime(2023, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)), "Pedro", "Pabon", "ABC999", "34579000850000" },
                    { new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"), new DateTimeOffset(new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)), "Arnold", "Hernandez", "ABC007", "88769000850022" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Policies_CityId",
                table: "Policies",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
