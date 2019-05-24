using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiTodoList.Application.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Photo = table.Column<byte[]>(nullable: true),
                    Age = table.Column<uint>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoGroups",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Red = table.Column<byte>(nullable: false),
                    Green = table.Column<byte>(nullable: false),
                    Blue = table.Column<byte>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoGroups", x => x.Name);
                    table.ForeignKey(
                        name: "FK_TodoGroups_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    IsComplited = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Complited = table.Column<DateTime>(nullable: false),
                    GroupName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Todos_TodoGroups_GroupName",
                        column: x => x.GroupName,
                        principalTable: "TodoGroups",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoGroups_UserId",
                table: "TodoGroups",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Todos_GroupName",
                table: "Todos",
                column: "GroupName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todos");

            migrationBuilder.DropTable(
                name: "TodoGroups");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
