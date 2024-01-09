using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Crm.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DeliveryEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DeliveryId",
                table: "order",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "delivery",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    deliverytype = table.Column<int>(name: "delivery-type", type: "integer", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    deliverydate = table.Column<DateTime>(name: "delivery-date", type: "timestamp with time zone", nullable: false),
                    OrderId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_id", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_order_DeliveryId",
                table: "order",
                column: "DeliveryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_order_delivery_DeliveryId",
                table: "order",
                column: "DeliveryId",
                principalTable: "delivery",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_delivery_DeliveryId",
                table: "order");

            migrationBuilder.DropTable(
                name: "delivery");

            migrationBuilder.DropIndex(
                name: "IX_order_DeliveryId",
                table: "order");

            migrationBuilder.DropColumn(
                name: "DeliveryId",
                table: "order");
        }
    }
}
