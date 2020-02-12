using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KickDo.Migrations
{
    public partial class sss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Dob = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    VatNumber = table.Column<string>(fixedLength: true, maxLength: 9, nullable: true),
                    Budget = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PersonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Funding",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(nullable: true),
                    CompanyId = table.Column<int>(nullable: true),
                    Deposit = table.Column<decimal>(nullable: false),
                    DepositDate = table.Column<DateTime>(nullable: false),
                    BankName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funding", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funding_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Funding_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_PersonId",
                table: "Company",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_VatNumber",
                table: "Company",
                column: "VatNumber",
                unique: true,
                filter: "[VatNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Funding_CompanyId",
                table: "Funding",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Funding_PersonId",
                table: "Funding",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funding");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
