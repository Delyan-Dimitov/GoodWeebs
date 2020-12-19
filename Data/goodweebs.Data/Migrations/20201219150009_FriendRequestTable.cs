using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Goodweebs.Data.Migrations
{
    public partial class FriendRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "WantToReadMaps",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "WantToReadMaps",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "WantToReadMaps",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "WantToReadMaps",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "ReadMaps",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "ReadMaps",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ReadMaps",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "ReadMaps",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "CurrentlyReadingMaps",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "CurrentlyReadingMaps",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CurrentlyReadingMaps",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "CurrentlyReadingMaps",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FriendRequests",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    RequesterId = table.Column<string>(nullable: true),
                    RequesteeId = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FriendRequests_AspNetUsers_RequesteeId",
                        column: x => x.RequesteeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FriendRequests_AspNetUsers_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WantToReadMaps_IsDeleted",
                table: "WantToReadMaps",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ReadMaps_IsDeleted",
                table: "ReadMaps",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentlyReadingMaps_IsDeleted",
                table: "CurrentlyReadingMaps",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_IsDeleted",
                table: "FriendRequests",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_RequesteeId",
                table: "FriendRequests",
                column: "RequesteeId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_RequesterId",
                table: "FriendRequests",
                column: "RequesterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FriendRequests");

            migrationBuilder.DropIndex(
                name: "IX_WantToReadMaps_IsDeleted",
                table: "WantToReadMaps");

            migrationBuilder.DropIndex(
                name: "IX_ReadMaps_IsDeleted",
                table: "ReadMaps");

            migrationBuilder.DropIndex(
                name: "IX_CurrentlyReadingMaps_IsDeleted",
                table: "CurrentlyReadingMaps");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "WantToReadMaps");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "WantToReadMaps");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "WantToReadMaps");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "WantToReadMaps");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "ReadMaps");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "ReadMaps");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ReadMaps");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "ReadMaps");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "CurrentlyReadingMaps");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "CurrentlyReadingMaps");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CurrentlyReadingMaps");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "CurrentlyReadingMaps");
        }
    }
}
