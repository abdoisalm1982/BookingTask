using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

           

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                   
                    Email = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR(Max)", nullable: false),
           
                    CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user", x => x.UserId);
                   
                });
            migrationBuilder.CreateTable(
               name: "Trips",
               columns: table => new
               {
                   TripId = table.Column<int>(type: "INT", nullable: false),
                   Name = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                   CityName = table.Column<string>(type: "NVARCHAR(Max)", nullable: false),
                   ImageUrl = table.Column<string>(type: "NVARCHAR(Max)", nullable: false),
                   CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                   ModifiedDate = table.Column<DateTime>(type: "DATETIME", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("pk_Trip", x => x.TripId);

               });
            migrationBuilder.CreateTable(
            name: "Reservations",
            columns: table => new
            {
                ReservedId = table.Column<int>(type: "INT", nullable: false),
                
                ReservedBy = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                CustomerName = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                TripId = table.Column<int>(type: "INT", nullable: false),
                ReservationDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                Notes = table.Column<string>(type: "NVARCHAR(Max)", nullable: false),
                CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                ModifiedDate = table.Column<DateTime>(type: "DATETIME", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_Reservation", x => x.ReservedId);

            });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.DropTable(
                name: "Users");
            migrationBuilder.DropTable(
                name: "Trips");
            migrationBuilder.DropTable(
              name: "Reservations");


        }
    }
}
