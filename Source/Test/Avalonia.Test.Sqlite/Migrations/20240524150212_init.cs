using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avalonia.Test.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mbc_dv_images",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    MediaType = table.Column<string>(type: "TEXT", nullable: false),
                    CaseType = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    TagTypes = table.Column<string>(type: "TEXT", nullable: false),
                    AreaType = table.Column<string>(type: "TEXT", nullable: false),
                    ExtendType = table.Column<string>(type: "TEXT", nullable: false),
                    ArticulationType = table.Column<string>(type: "TEXT", nullable: false),
                    Size = table.Column<long>(type: "INTEGER", nullable: false),
                    VipType = table.Column<string>(type: "TEXT", nullable: false),
                    FromType = table.Column<string>(type: "TEXT", nullable: false),
                    OrderNum = table.Column<string>(type: "TEXT", nullable: false),
                    PlayCount = table.Column<string>(type: "TEXT", nullable: false),
                    Score = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Resoluction = table.Column<string>(type: "TEXT", nullable: false),
                    Aspect = table.Column<string>(type: "TEXT", nullable: false),
                    CDATE = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UDATE = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ISENBLED = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mbc_dv_images", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mbc_dv_images");
        }
    }
}
