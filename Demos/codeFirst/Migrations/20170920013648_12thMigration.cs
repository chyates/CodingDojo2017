using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace codeFirst.Migrations
{
    public partial class _12thMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_Groups_GroupId",
                table: "Memberships");

            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_Users_UserId1",
                table: "Memberships");

            migrationBuilder.DropIndex(
                name: "IX_Memberships_UserId1",
                table: "Memberships");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Memberships");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Memberships",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Memberships",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_UserId",
                table: "Memberships",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_Groups_GroupId",
                table: "Memberships",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_Users_UserId",
                table: "Memberships",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_Groups_GroupId",
                table: "Memberships");

            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_Users_UserId",
                table: "Memberships");

            migrationBuilder.DropIndex(
                name: "IX_Memberships_UserId",
                table: "Memberships");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Memberships",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Memberships",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                table: "Memberships",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_UserId1",
                table: "Memberships",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_Groups_GroupId",
                table: "Memberships",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_Users_UserId1",
                table: "Memberships",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
