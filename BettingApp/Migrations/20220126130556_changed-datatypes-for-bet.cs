using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BettingApp.Migrations
{
    public partial class changeddatatypesforbet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Bets",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "BetID",
                table: "Bets");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Bets",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Bets",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "Bets",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bets",
                table: "Bets",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Bets",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "Bets");

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "Bets",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddColumn<int>(
                name: "BetID",
                table: "Bets",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bets",
                table: "Bets",
                column: "BetID");
        }
    }
}
