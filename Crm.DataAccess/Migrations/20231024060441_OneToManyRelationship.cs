using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Crm.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class OneToManyRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_order",
                table: "order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_client",
                table: "client");

            migrationBuilder.RenameColumn(
                name: "passport-number",
                table: "client",
                newName: "passport-name");

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "order",
                type: "DECIMAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "order",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<long>(
                name: "ClientId",
                table: "order",
                type: "bigint",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "client",
                type: "VARCHAR(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "client",
                type: "VARCHAR(64)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "middle-name",
                table: "client",
                type: "VARCHAR(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "last-name",
                table: "client",
                type: "VARCHAR(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "first-name",
                table: "client",
                type: "VARCHAR(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "client",
                type: "VARCHAR(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "age",
                table: "client",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "client",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "passport-name",
                table: "client",
                type: "VARCHAR(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "pk_order_id",
                table: "order",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_client_id",
                table: "client",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_order_ClientId",
                table: "order",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_order_client_ClientId",
                table: "order",
                column: "ClientId",
                principalTable: "client",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_client_ClientId",
                table: "order");

            migrationBuilder.DropPrimaryKey(
                name: "pk_id",
                table: "order");

            migrationBuilder.DropIndex(
                name: "IX_order_ClientId",
                table: "order");

            migrationBuilder.DropPrimaryKey(
                name: "pk_id",
                table: "client");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "order");

            migrationBuilder.RenameColumn(
                name: "passport-name",
                table: "client",
                newName: "passport-number");

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "order",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "order",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "client",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20)");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "client",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(64)");

            migrationBuilder.AlterColumn<string>(
                name: "middle-name",
                table: "client",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20)");

            migrationBuilder.AlterColumn<string>(
                name: "last-name",
                table: "client",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20)");

            migrationBuilder.AlterColumn<string>(
                name: "first-name",
                table: "client",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20)");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "client",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20)");

            migrationBuilder.AlterColumn<short>(
                name: "age",
                table: "client",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "client",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "SERIAL")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "passport-number",
                table: "client",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_order",
                table: "order",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_client",
                table: "client",
                column: "id");
        }
    }
}
