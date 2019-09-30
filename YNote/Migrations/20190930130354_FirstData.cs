using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YNote.Migrations
{
    public partial class FirstData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Nickname", "Password", "SpaceEntityId", "Surname" },
                values: new object[] { new Guid("30fb2dd3-ea0e-4f05-b0db-ef6341a593f0"), "burtso.ab@gmail.com", "Andriy", "Shails", "SomePassword", null, "Burtso" });

            migrationBuilder.InsertData(
                table: "Spaces",
                columns: new[] { "Id", "AuthorId", "SpaceName" },
                values: new object[] { 1, new Guid("30fb2dd3-ea0e-4f05-b0db-ef6341a593f0"), "FirstSpace" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "GroupName", "SpaceId" },
                values: new object[] { 1, "FirstGroup", 1 });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "AssignedUserId", "CreationTime", "GroupId", "SpaceId" },
                values: new object[] { 1, new Guid("30fb2dd3-ea0e-4f05-b0db-ef6341a593f0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, null });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Description", "NoteId", "SumUp" },
                values: new object[] { 1, "A lot of text", 1, "Text" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Spaces",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("30fb2dd3-ea0e-4f05-b0db-ef6341a593f0"));
        }
    }
}
