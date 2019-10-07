using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YNote.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupId = table.Column<int>(nullable: true),
                    SpaceId = table.Column<int>(nullable: true),
                    CreationTime = table.Column<DateTimeOffset>(nullable: false),
                    AssignedUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NoteId = table.Column<int>(nullable: false),
                    SumUp = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 300, nullable: true),
                    Status = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Notes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Notes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupName = table.Column<string>(nullable: true),
                    SpaceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Surname = table.Column<string>(maxLength: 50, nullable: false),
                    Nickname = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(maxLength: 30, nullable: false),
                    Password = table.Column<string>(maxLength: 16, nullable: false),
                    SpaceEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spaces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SpaceName = table.Column<string>(maxLength: 100, nullable: false),
                    AuthorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spaces_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Groups_SpaceId",
                table: "Groups",
                column: "SpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_AssignedUserId",
                table: "Notes",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_GroupId",
                table: "Notes",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_SpaceId",
                table: "Notes",
                column: "SpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Spaces_AuthorId",
                table: "Spaces",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_NoteId",
                table: "Tasks",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SpaceEntityId",
                table: "Users",
                column: "SpaceEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Spaces_SpaceId",
                table: "Notes",
                column: "SpaceId",
                principalTable: "Spaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Users_AssignedUserId",
                table: "Notes",
                column: "AssignedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Groups_GroupId",
                table: "Notes",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Spaces_SpaceId",
                table: "Groups",
                column: "SpaceId",
                principalTable: "Spaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Spaces_SpaceEntityId",
                table: "Users",
                column: "SpaceEntityId",
                principalTable: "Spaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Spaces_SpaceEntityId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Spaces");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
