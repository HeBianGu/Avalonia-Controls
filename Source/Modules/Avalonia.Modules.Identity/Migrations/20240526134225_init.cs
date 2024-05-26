﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Avalonia.Modules.Identity.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hi_dd_authors",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    author_name = table.Column<string>(type: "TEXT", nullable: false),
                    author_code = table.Column<string>(type: "TEXT", nullable: true),
                    CDATE = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UDATE = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ISENBLED = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hi_dd_authors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hi_dd_roles",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    role_name = table.Column<string>(type: "TEXT", nullable: false),
                    role_code = table.Column<string>(type: "TEXT", nullable: true),
                    CDATE = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UDATE = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ISENBLED = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hi_dd_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hi_dd_authorhi_dd_role",
                columns: table => new
                {
                    AuthorsID = table.Column<string>(type: "TEXT", nullable: false),
                    RolesID = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hi_dd_authorhi_dd_role", x => new { x.AuthorsID, x.RolesID });
                    table.ForeignKey(
                        name: "FK_hi_dd_authorhi_dd_role_hi_dd_authors_AuthorsID",
                        column: x => x.AuthorsID,
                        principalTable: "hi_dd_authors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hi_dd_authorhi_dd_role_hi_dd_roles_RolesID",
                        column: x => x.RolesID,
                        principalTable: "hi_dd_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hi_dd_users",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    user_name = table.Column<string>(type: "TEXT", nullable: false),
                    account = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    display = table.Column<string>(type: "TEXT", nullable: true),
                    enable = table.Column<bool>(type: "INTEGER", nullable: false),
                    mail = table.Column<string>(type: "TEXT", nullable: true),
                    last_login_time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    license_deadline = table.Column<DateTime>(type: "TEXT", nullable: false),
                    role_id = table.Column<string>(type: "TEXT", nullable: false),
                    CDATE = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UDATE = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ISENBLED = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hi_dd_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_hi_dd_users_hi_dd_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "hi_dd_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "hi_dd_authors",
                columns: new[] { "id", "author_code", "CDATE", "ISENBLED", "author_name", "UDATE" },
                values: new object[,]
                {
                    { "{63860D6B-BD59-4620-919D-0DE51877676F}", null, new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8762), 1, "用户管理", new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8762) },
                    { "{DE3B4992-A5BF-4AD2-80D8-2C9654C47A34}", null, new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8775), 1, "角色管理", new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8775) }
                });

            migrationBuilder.InsertData(
                table: "hi_dd_roles",
                columns: new[] { "id", "CDATE", "role_code", "ISENBLED", "role_name", "UDATE" },
                values: new object[,]
                {
                    { "{0E465AF1-4C5B-417B-B496-E74E8A0D7E5C}", new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8794), "02", 1, "普通用户", new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8794) },
                    { "{4360CE12-E5F4-4EA6-937C-9FDEA4DF06F6}", new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8790), "01", 1, "管理员", new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8790) }
                });

            migrationBuilder.InsertData(
                table: "hi_dd_users",
                columns: new[] { "id", "account", "CDATE", "display", "enable", "ISENBLED", "last_login_time", "license_deadline", "mail", "user_name", "password", "role_id", "UDATE" },
                values: new object[,]
                {
                    { "{A8EE1331-0DA7-42F1-80E2-CD2A20D62BC9}", "user", new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8804), null, false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HeBianGu", "123456", "{0E465AF1-4C5B-417B-B496-E74E8A0D7E5C}", new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8804) },
                    { "{E12E19D6-FDD9-4DCE-B211-55E58FAFC207}", "admin", new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8797), null, false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "超级用户", "123456", "{4360CE12-E5F4-4EA6-937C-9FDEA4DF06F6}", new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8797) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_hi_dd_authorhi_dd_role_RolesID",
                table: "hi_dd_authorhi_dd_role",
                column: "RolesID");

            migrationBuilder.CreateIndex(
                name: "IX_hi_dd_users_role_id",
                table: "hi_dd_users",
                column: "role_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hi_dd_authorhi_dd_role");

            migrationBuilder.DropTable(
                name: "hi_dd_users");

            migrationBuilder.DropTable(
                name: "hi_dd_authors");

            migrationBuilder.DropTable(
                name: "hi_dd_roles");
        }
    }
}
