using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoeCareHistory.Migrations
{
    public partial class Update_20190430 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CareItem_CareBrand_CareBrandId",
                table: "CareItem");

            migrationBuilder.DropForeignKey(
                name: "FK_History_Shoe_ShoeId",
                table: "History");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ShoeMaker",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Shoe",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BreakInDate",
                table: "Shoe",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsSold",
                table: "Shoe",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Material",
                table: "Shoe",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShoeId",
                table: "History",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CareItemId",
                table: "History",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SealDate",
                table: "History",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CareItem",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CareBrandId",
                table: "CareItem",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "CareItem",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CareBrand",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CareItem_CareBrand_CareBrandId",
                table: "CareItem",
                column: "CareBrandId",
                principalTable: "CareBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_History_Shoe_ShoeId",
                table: "History",
                column: "ShoeId",
                principalTable: "Shoe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CareItem_CareBrand_CareBrandId",
                table: "CareItem");

            migrationBuilder.DropForeignKey(
                name: "FK_History_Shoe_ShoeId",
                table: "History");

            migrationBuilder.DropColumn(
                name: "BreakInDate",
                table: "Shoe");

            migrationBuilder.DropColumn(
                name: "IsSold",
                table: "Shoe");

            migrationBuilder.DropColumn(
                name: "Material",
                table: "Shoe");

            migrationBuilder.DropColumn(
                name: "CareItemId",
                table: "History");

            migrationBuilder.DropColumn(
                name: "SealDate",
                table: "History");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "CareItem");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ShoeMaker",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Shoe",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "ShoeId",
                table: "History",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CareItem",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "CareBrandId",
                table: "CareItem",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CareBrand",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_CareItem_CareBrand_CareBrandId",
                table: "CareItem",
                column: "CareBrandId",
                principalTable: "CareBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_History_Shoe_ShoeId",
                table: "History",
                column: "ShoeId",
                principalTable: "Shoe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
