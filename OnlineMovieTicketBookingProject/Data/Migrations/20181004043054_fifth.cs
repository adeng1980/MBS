using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnlineMovieTicketBookingProject.Data.Migrations
{
    public partial class fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingTable_MovieDetails_MovieDetailsId",
                table: "BookingTable");

            migrationBuilder.DropIndex(
                name: "IX_BookingTable_MovieDetailsId",
                table: "BookingTable");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BookingTable_MovieDetailsId",
                table: "BookingTable",
                column: "MovieDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingTable_MovieDetails_MovieDetailsId",
                table: "BookingTable",
                column: "MovieDetailsId",
                principalTable: "MovieDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
