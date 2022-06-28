using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    public partial class InitMigrationSecondary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Offerwithdrawal",
                schema: "dbo",
                table: "offer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                schema: "dbo",
                table: "offer",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId2",
                schema: "dbo",
                table: "offer",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_offer_UserId1",
                schema: "dbo",
                table: "offer",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_offer_UserId2",
                schema: "dbo",
                table: "offer",
                column: "UserId2");

            migrationBuilder.AddForeignKey(
                name: "FK_offer_user_UserId1",
                schema: "dbo",
                table: "offer",
                column: "UserId1",
                principalSchema: "dbo",
                principalTable: "user",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_offer_user_UserId2",
                schema: "dbo",
                table: "offer",
                column: "UserId2",
                principalSchema: "dbo",
                principalTable: "user",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_offer_user_UserId1",
                schema: "dbo",
                table: "offer");

            migrationBuilder.DropForeignKey(
                name: "FK_offer_user_UserId2",
                schema: "dbo",
                table: "offer");

            migrationBuilder.DropIndex(
                name: "IX_offer_UserId1",
                schema: "dbo",
                table: "offer");

            migrationBuilder.DropIndex(
                name: "IX_offer_UserId2",
                schema: "dbo",
                table: "offer");

            migrationBuilder.DropColumn(
                name: "Offerwithdrawal",
                schema: "dbo",
                table: "offer");

            migrationBuilder.DropColumn(
                name: "UserId1",
                schema: "dbo",
                table: "offer");

            migrationBuilder.DropColumn(
                name: "UserId2",
                schema: "dbo",
                table: "offer");
        }
    }
}
