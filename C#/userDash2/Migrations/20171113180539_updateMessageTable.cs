using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace userDash2.Migrations
{
    public partial class updateMessageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostedOn",
                table: "Messages",
                type: "int4",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostedOn",
                table: "Messages");
        }
    }
}
