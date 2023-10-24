using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crm.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class dataAnnotation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "order",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "order",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "order",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "MyOrderState",
                table: "order",
                newName: "order-state");

            migrationBuilder.RenameColumn(
                name: "DeliveryType",
                table: "order",
                newName: "delivery-type");

            migrationBuilder.RenameColumn(
                name: "DeliveryAddress",
                table: "order",
                newName: "delivery-address");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "order",
                newName: "create-at");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "client",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "client",
                newName: "age");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "client",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserPhone",
                table: "client",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "UserPassword",
                table: "client",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "client",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "PassportNumber",
                table: "client",
                newName: "passport-number");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "client",
                newName: "middle-name");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "client",
                newName: "last-name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "client",
                newName: "first-name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "price",
                table: "order",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "order",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "order",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "order-state",
                table: "order",
                newName: "MyOrderState");

            migrationBuilder.RenameColumn(
                name: "delivery-type",
                table: "order",
                newName: "DeliveryType");

            migrationBuilder.RenameColumn(
                name: "delivery-address",
                table: "order",
                newName: "DeliveryAddress");

            migrationBuilder.RenameColumn(
                name: "create-at",
                table: "order",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "client",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "age",
                table: "client",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "client",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "client",
                newName: "UserPhone");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "client",
                newName: "UserPassword");

            migrationBuilder.RenameColumn(
                name: "passport-number",
                table: "client",
                newName: "PassportNumber");

            migrationBuilder.RenameColumn(
                name: "middle-name",
                table: "client",
                newName: "MiddleName");

            migrationBuilder.RenameColumn(
                name: "last-name",
                table: "client",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first-name",
                table: "client",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "client",
                newName: "UserEmail");
        }
    }
}
