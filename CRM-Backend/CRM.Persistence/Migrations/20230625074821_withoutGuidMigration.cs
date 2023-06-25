using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class withoutGuidMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                schema: "dbo",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                schema: "dbo",
                table: "Sector",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                schema: "dbo",
                table: "Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                schema: "dbo",
                table: "Position",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                schema: "dbo",
                table: "Customer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                schema: "dbo",
                table: "Sector");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                schema: "dbo",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                schema: "dbo",
                table: "Position");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                schema: "dbo",
                table: "Customer");
        }
    }
}
