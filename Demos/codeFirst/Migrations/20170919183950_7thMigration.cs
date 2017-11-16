using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace codeFirst.Migrations
{
    public partial class _7thMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Users_UserId1",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_Users_MemberId",
                table: "Memberships");

            migrationBuilder.DropIndex(
                name: "IX_Groups_UserId1",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Groups");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "Memberships",
                newName: "UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Memberships_MemberId",
                table: "Memberships",
                newName: "IX_Memberships_UserId1");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Groups",
                newName: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_Users_UserId1",
                table: "Memberships",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_Users_UserId1",
                table: "Memberships");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "Memberships",
                newName: "MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Memberships_UserId1",
                table: "Memberships",
                newName: "IX_Memberships_MemberId");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Groups",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Groups",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                table: "Groups",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_UserId1",
                table: "Groups",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Users_UserId1",
                table: "Groups",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_Users_MemberId",
                table: "Memberships",
                column: "MemberId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
