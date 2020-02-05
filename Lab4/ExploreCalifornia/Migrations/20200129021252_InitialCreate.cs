using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ExploreCalifornia.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tour",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Length = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Rating = table.Column<string>(nullable: true),
                    IncludesMeals = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour", x => x.Id);
                });

            migrationBuilder.CreateTable(
               name: "Booking",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                   TourID = table.Column<int>(nullable: false),
                   TourName = table.Column<string>(nullable: true),
                   ClientID = table.Column<int>(nullable: true),
                   DepartureDate = table.Column<DateTime>(nullable: false),
                   NumberOfPeople = table.Column<int>(nullable: true),
                   FullName = table.Column<string>(nullable: true),
                   Email = table.Column<string>(nullable: true),
                   ContactNo = table.Column<string>(nullable: true),
                   SpecialRequest = table.Column<string>(nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Booking", x => x.Id);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tour");
            migrationBuilder.DropTable(
            name: "Booking");
        }
    }
}
