using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class PaymentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_request_payment_FK_Requests_Payment",
                table: "request");

            migrationBuilder.DropIndex(
                name: "IX_request_FK_Requests_Payment",
                table: "request");

            migrationBuilder.DropColumn(
                name: "FK_Requests_Payment",
                table: "request");

            migrationBuilder.CreateIndex(
                name: "IX_request_PaymentId",
                table: "request",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Payment",
                table: "request",
                column: "PaymentId",
                principalTable: "payment",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Payment",
                table: "request");

            migrationBuilder.DropIndex(
                name: "IX_request_PaymentId",
                table: "request");

            migrationBuilder.AddColumn<int>(
                name: "FK_Requests_Payment",
                table: "request",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_request_FK_Requests_Payment",
                table: "request",
                column: "FK_Requests_Payment");

            migrationBuilder.AddForeignKey(
                name: "FK_request_payment_FK_Requests_Payment",
                table: "request",
                column: "FK_Requests_Payment",
                principalTable: "payment",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
