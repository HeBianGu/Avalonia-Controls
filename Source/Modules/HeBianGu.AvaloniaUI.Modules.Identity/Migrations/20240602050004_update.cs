using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeBianGu.AvaloniaUI.Modules.Identity.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hi_dd_users_hi_dd_roles_role_id",
                table: "hi_dd_users");

            migrationBuilder.AlterColumn<string>(
                name: "role_id",
                table: "hi_dd_users",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "hi_dd_authors",
                keyColumn: "id",
                keyValue: "{63860D6B-BD59-4620-919D-0DE51877676F}",
                columns: new[] { "CDATE", "UDATE" },
                values: new object[] { new DateTime(2024, 6, 2, 13, 0, 4, 316, DateTimeKind.Local).AddTicks(5584), new DateTime(2024, 6, 2, 13, 0, 4, 316, DateTimeKind.Local).AddTicks(5584) });

            migrationBuilder.UpdateData(
                table: "hi_dd_authors",
                keyColumn: "id",
                keyValue: "{DE3B4992-A5BF-4AD2-80D8-2C9654C47A34}",
                columns: new[] { "CDATE", "UDATE" },
                values: new object[] { new DateTime(2024, 6, 2, 13, 0, 4, 316, DateTimeKind.Local).AddTicks(5598), new DateTime(2024, 6, 2, 13, 0, 4, 316, DateTimeKind.Local).AddTicks(5598) });

            migrationBuilder.UpdateData(
                table: "hi_dd_roles",
                keyColumn: "id",
                keyValue: "{0E465AF1-4C5B-417B-B496-E74E8A0D7E5C}",
                columns: new[] { "CDATE", "UDATE" },
                values: new object[] { new DateTime(2024, 6, 2, 13, 0, 4, 316, DateTimeKind.Local).AddTicks(5641), new DateTime(2024, 6, 2, 13, 0, 4, 316, DateTimeKind.Local).AddTicks(5641) });

            migrationBuilder.UpdateData(
                table: "hi_dd_roles",
                keyColumn: "id",
                keyValue: "{4360CE12-E5F4-4EA6-937C-9FDEA4DF06F6}",
                columns: new[] { "CDATE", "UDATE" },
                values: new object[] { new DateTime(2024, 6, 2, 13, 0, 4, 316, DateTimeKind.Local).AddTicks(5629), new DateTime(2024, 6, 2, 13, 0, 4, 316, DateTimeKind.Local).AddTicks(5629) });

            migrationBuilder.UpdateData(
                table: "hi_dd_users",
                keyColumn: "id",
                keyValue: "{A8EE1331-0DA7-42F1-80E2-CD2A20D62BC9}",
                columns: new[] { "CDATE", "UDATE" },
                values: new object[] { new DateTime(2024, 6, 2, 13, 0, 4, 316, DateTimeKind.Local).AddTicks(5651), new DateTime(2024, 6, 2, 13, 0, 4, 316, DateTimeKind.Local).AddTicks(5651) });

            migrationBuilder.UpdateData(
                table: "hi_dd_users",
                keyColumn: "id",
                keyValue: "{E12E19D6-FDD9-4DCE-B211-55E58FAFC207}",
                columns: new[] { "CDATE", "UDATE" },
                values: new object[] { new DateTime(2024, 6, 2, 13, 0, 4, 316, DateTimeKind.Local).AddTicks(5646), new DateTime(2024, 6, 2, 13, 0, 4, 316, DateTimeKind.Local).AddTicks(5646) });

            migrationBuilder.AddForeignKey(
                name: "FK_hi_dd_users_hi_dd_roles_role_id",
                table: "hi_dd_users",
                column: "role_id",
                principalTable: "hi_dd_roles",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hi_dd_users_hi_dd_roles_role_id",
                table: "hi_dd_users");

            migrationBuilder.AlterColumn<string>(
                name: "role_id",
                table: "hi_dd_users",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "hi_dd_authors",
                keyColumn: "id",
                keyValue: "{63860D6B-BD59-4620-919D-0DE51877676F}",
                columns: new[] { "CDATE", "UDATE" },
                values: new object[] { new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8762), new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8762) });

            migrationBuilder.UpdateData(
                table: "hi_dd_authors",
                keyColumn: "id",
                keyValue: "{DE3B4992-A5BF-4AD2-80D8-2C9654C47A34}",
                columns: new[] { "CDATE", "UDATE" },
                values: new object[] { new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8775), new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8775) });

            migrationBuilder.UpdateData(
                table: "hi_dd_roles",
                keyColumn: "id",
                keyValue: "{0E465AF1-4C5B-417B-B496-E74E8A0D7E5C}",
                columns: new[] { "CDATE", "UDATE" },
                values: new object[] { new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8794), new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8794) });

            migrationBuilder.UpdateData(
                table: "hi_dd_roles",
                keyColumn: "id",
                keyValue: "{4360CE12-E5F4-4EA6-937C-9FDEA4DF06F6}",
                columns: new[] { "CDATE", "UDATE" },
                values: new object[] { new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8790), new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8790) });

            migrationBuilder.UpdateData(
                table: "hi_dd_users",
                keyColumn: "id",
                keyValue: "{A8EE1331-0DA7-42F1-80E2-CD2A20D62BC9}",
                columns: new[] { "CDATE", "UDATE" },
                values: new object[] { new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8804), new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8804) });

            migrationBuilder.UpdateData(
                table: "hi_dd_users",
                keyColumn: "id",
                keyValue: "{E12E19D6-FDD9-4DCE-B211-55E58FAFC207}",
                columns: new[] { "CDATE", "UDATE" },
                values: new object[] { new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8797), new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8797) });

            migrationBuilder.AddForeignKey(
                name: "FK_hi_dd_users_hi_dd_roles_role_id",
                table: "hi_dd_users",
                column: "role_id",
                principalTable: "hi_dd_roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
