using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApp.Migrations
{
    public partial class BoardsContentsChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Boards");

            migrationBuilder.AddColumn<string>(
                name: "Contents",
                table: "Boards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contents",
                table: "Boards");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Boards",
                nullable: false,
                defaultValue: "");
        }
    }
}
