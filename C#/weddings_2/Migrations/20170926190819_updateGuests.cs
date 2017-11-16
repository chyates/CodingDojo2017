using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace weddings_2.Migrations
{
    public partial class updateGuests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Guest");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Guest",
                type: "int4",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Guest");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Guest",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Guest",
                nullable: true);
        }
    }
}
