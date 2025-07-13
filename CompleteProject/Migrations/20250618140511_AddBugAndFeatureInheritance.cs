using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompleteProject.Migrations
{
    /// <inheritdoc />
    public partial class AddBugAndFeatureInheritance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoItems",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "TodoItems");

            migrationBuilder.RenameTable(
                name: "TodoItems",
                newName: "TodoItem");

            migrationBuilder.AlterColumn<string>(
                name: "Severity",
                table: "TodoItem",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "AffectedVersion",
                table: "TodoItem",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "AffectedUsers",
                table: "TodoItem",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "AttachedBugId",
                table: "TodoItem",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AttachedFeatureId",
                table: "TodoItem",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "TodoItem",
                type: "TEXT",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "TodoItem",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "TodoItem",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScreenshotUrl",
                table: "TodoItem",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoItem",
                table: "TodoItem",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TodoItem_AttachedBugId",
                table: "TodoItem",
                column: "AttachedBugId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoItem_AttachedFeatureId",
                table: "TodoItem",
                column: "AttachedFeatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItem_TodoItem_AttachedBugId",
                table: "TodoItem",
                column: "AttachedBugId",
                principalTable: "TodoItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItem_TodoItem_AttachedFeatureId",
                table: "TodoItem",
                column: "AttachedFeatureId",
                principalTable: "TodoItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItem_TodoItem_AttachedBugId",
                table: "TodoItem");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoItem_TodoItem_AttachedFeatureId",
                table: "TodoItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoItem",
                table: "TodoItem");

            migrationBuilder.DropIndex(
                name: "IX_TodoItem_AttachedBugId",
                table: "TodoItem");

            migrationBuilder.DropIndex(
                name: "IX_TodoItem_AttachedFeatureId",
                table: "TodoItem");

            migrationBuilder.DropColumn(
                name: "AttachedBugId",
                table: "TodoItem");

            migrationBuilder.DropColumn(
                name: "AttachedFeatureId",
                table: "TodoItem");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "TodoItem");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "TodoItem");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "TodoItem");

            migrationBuilder.DropColumn(
                name: "ScreenshotUrl",
                table: "TodoItem");

            migrationBuilder.RenameTable(
                name: "TodoItem",
                newName: "TodoItems");

            migrationBuilder.AlterColumn<string>(
                name: "Severity",
                table: "TodoItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AffectedVersion",
                table: "TodoItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AffectedUsers",
                table: "TodoItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "TodoItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoItems",
                table: "TodoItems",
                column: "Id");
        }
    }
}
