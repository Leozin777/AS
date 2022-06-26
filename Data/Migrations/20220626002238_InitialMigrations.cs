using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 80, nullable: false),
                    phoneNumber = table.Column<string>(type: "VARCHAR", maxLength: 80, nullable: false),
                    CPF = table.Column<string>(type: "VARCHAR", maxLength: 80, nullable: false),
                    dateLastPurchase = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "payment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "VARCHAR", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "requestHistory",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status = table.Column<bool>(type: "BOOLEAN", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requestHistory", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "store",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 80, nullable: false),
                    phoneNumber = table.Column<string>(type: "VARCHAR", maxLength: 80, nullable: false),
                    address = table.Column<string>(type: "VARCHAR", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_store", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "request",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status = table.Column<string>(type: "VARCHAR", maxLength: 80, nullable: false),
                    amountItems = table.Column<double>(type: "DOUBLE", nullable: false),
                    requestDate = table.Column<int>(type: "SMALLDATETIME", nullable: false),
                    ClientId = table.Column<int>(type: "integer", nullable: false),
                    StoreId = table.Column<int>(type: "integer", nullable: false),
                    FK_Requests_Payment = table.Column<int>(type: "integer", nullable: false),
                    PaymentId = table.Column<int>(type: "integer", nullable: false),
                    RequestHistoryId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_request", x => x.id);
                    table.ForeignKey(
                        name: "FK_request_payment_FK_Requests_Payment",
                        column: x => x.FK_Requests_Payment,
                        principalTable: "payment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Client",
                        column: x => x.ClientId,
                        principalTable: "client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_RequestHistory",
                        column: x => x.RequestHistoryId,
                        principalTable: "requestHistory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Store",
                        column: x => x.StoreId,
                        principalTable: "store",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "item",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    amount = table.Column<int>(type: "INT", nullable: false),
                    price = table.Column<double>(type: "DOUBLE", nullable: false),
                    RequestId = table.Column<int>(type: "integer", nullable: false),
                    missing = table.Column<bool>(type: "BOOLEAN", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_Requests_Client",
                        column: x => x.RequestId,
                        principalTable: "request",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    price = table.Column<double>(type: "DOUBLE", nullable: false),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 80, nullable: false),
                    soldAmount = table.Column<int>(type: "INT", nullable: false),
                    quantityKgSold = table.Column<double>(type: "DOUBLE", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_Products_Item",
                        column: x => x.ItemId,
                        principalTable: "item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_item_RequestId",
                table: "item",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_product_ItemId",
                table: "product",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_request_ClientId",
                table: "request",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_request_FK_Requests_Payment",
                table: "request",
                column: "FK_Requests_Payment");

            migrationBuilder.CreateIndex(
                name: "IX_request_RequestHistoryId",
                table: "request",
                column: "RequestHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_request_StoreId",
                table: "request",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "item");

            migrationBuilder.DropTable(
                name: "request");

            migrationBuilder.DropTable(
                name: "payment");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "requestHistory");

            migrationBuilder.DropTable(
                name: "store");
        }
    }
}
