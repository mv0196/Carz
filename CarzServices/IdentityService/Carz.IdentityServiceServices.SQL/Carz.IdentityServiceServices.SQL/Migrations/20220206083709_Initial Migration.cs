using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Carz.IdentityService.Services.SQL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdentityUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Blocked = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BlockedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DisablededAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnablededAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedPublished = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedPublished = table.Column<bool>(type: "bit", nullable: false),
                    BlockedPublished = table.Column<bool>(type: "bit", nullable: false),
                    DisabledPublished = table.Column<bool>(type: "bit", nullable: false),
                    EnabledPublished = table.Column<bool>(type: "bit", nullable: false),
                    PasswordChangedPublished = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentityUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityUserRoles_IdentityUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "IdentityUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdentityUserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserRoles_IdentityUserId",
                table: "IdentityUserRoles",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserRoles_RoleId",
                table: "IdentityUserRoles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityUserRoles");

            migrationBuilder.DropTable(
                name: "IdentityUsers");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
