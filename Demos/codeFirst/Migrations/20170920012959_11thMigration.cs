using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace codeFirst.Migrations
{
    public partial class _11thMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_Groups_GroupId",
                table: "Memberships");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Memberships",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_Groups_GroupId",
                table: "Memberships",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_Groups_GroupId",
                table: "Memberships");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Memberships",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_Groups_GroupId",
                table: "Memberships",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
