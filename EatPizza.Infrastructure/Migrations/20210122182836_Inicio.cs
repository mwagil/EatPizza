using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EatPizza.Infrastructure.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Flavor = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<int>(nullable: true),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDeliveries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    ZipCode = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDeliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDeliveries_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    SplitPie = table.Column<bool>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    PizzaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItemSplits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderItemId = table.Column<int>(nullable: false),
                    PizzaId = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemSplits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItemSplits_OrderItems_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItemSplits_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address1", "Address2", "City", "Country", "District", "FirstName", "LastName", "Number", "Password", "State", "UserName", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Rua Massaharo Kanesaki", "Apto 23 Bloco 2", "Indaiatuba", "Brasil", "Jardim Sevilha", "João", "Silva", "260", "123", "São Paulo", "joao", "13339-575" },
                    { 2, "Rua João Batista Ferrari", null, "Indaiatuba", "Brasil", "Jardim Bom Princípio", "José", "Oliveira", "122", "321", "São Paulo", "jose", "13345-686" }
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Flavor", "Price" },
                values: new object[,]
                {
                    { 1, "3 Queijos", 50.0 },
                    { 2, "Frango com requeijão", 59.990000000000002 },
                    { 3, "Mussarela", 42.5 },
                    { 4, "Calabresa", 42.5 },
                    { 5, "Pepperoni", 55.0 },
                    { 6, "Portuguesa", 45.0 },
                    { 7, "Veggie", 59.990000000000002 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "Date", "Total" },
                values: new object[] { 1, 1, new DateTime(2020, 8, 13, 2, 59, 6, 772, DateTimeKind.Local).AddTicks(9595), 50.0 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "Date", "Total" },
                values: new object[] { 2, 2, new DateTime(2020, 8, 14, 2, 59, 6, 774, DateTimeKind.Local).AddTicks(7060), 55.0 });

            migrationBuilder.InsertData(
                table: "OrderDeliveries",
                columns: new[] { "Id", "Address1", "Address2", "City", "Country", "District", "Number", "OrderId", "State", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Rua Massaharo Kanesaki", "Apartamento 23 Bloco 2", "Indaiatuba", "Brasil", "Jardim Sevilha", "260", 1, "São Paulo", "13339-575" },
                    { 2, "Mário de Almeida", null, "Indaiatuba", "Brasil", "Vila Brizolla", "295", 2, "São Paulo", "13343-510" }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "OrderId", "PizzaId", "Quantity", "SplitPie", "Total" },
                values: new object[,]
                {
                    { 1, 1, null, 1, true, 50.0 },
                    { 2, 2, null, 1, false, 55.0 }
                });

            migrationBuilder.InsertData(
                table: "OrderItemSplits",
                columns: new[] { "Id", "OrderItemId", "PizzaId", "Price" },
                values: new object[] { 1, 1, 5, 27.5 });

            migrationBuilder.InsertData(
                table: "OrderItemSplits",
                columns: new[] { "Id", "OrderItemId", "PizzaId", "Price" },
                values: new object[] { 2, 1, 6, 22.5 });

            migrationBuilder.InsertData(
                table: "OrderItemSplits",
                columns: new[] { "Id", "OrderItemId", "PizzaId", "Price" },
                values: new object[] { 3, 2, 5, 55.0 });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDeliveries_OrderId",
                table: "OrderDeliveries",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_PizzaId",
                table: "OrderItems",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemSplits_OrderItemId",
                table: "OrderItemSplits",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemSplits_PizzaId",
                table: "OrderItemSplits",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDeliveries");

            migrationBuilder.DropTable(
                name: "OrderItemSplits");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
