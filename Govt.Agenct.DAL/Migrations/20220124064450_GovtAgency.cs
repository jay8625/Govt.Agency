using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Govt.Agency.DAL.Migrations
{
    public partial class GovtAgency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgencyInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PostalCode = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    OfficePhone = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    GovtImage = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    JurisdictionalBoundaries = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Broucher = table.Column<bool>(nullable: false),
                    AidOrganization = table.Column<bool>(nullable: false),
                    BroucherCopy = table.Column<bool>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    Notify = table.Column<string>(nullable: true),
                    DocumentAttachment = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgencyInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgencyInfo");
        }
    }
}
