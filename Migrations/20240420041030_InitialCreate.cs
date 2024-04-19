using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ShopApplication.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    itemsCount = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    totalAmount = table.Column<float>(type: "real", nullable: false),
                    subTotal = table.Column<float>(type: "real", nullable: false),
                    discount = table.Column<float>(type: "real", nullable: false),
                    shipmentPrice = table.Column<float>(type: "real", nullable: false),
                    paymentMethod = table.Column<string>(type: "text", nullable: false),
                    shippingMethod = table.Column<string>(type: "text", nullable: false),
                    fullName = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    region = table.Column<string>(type: "text", nullable: false),
                    postalCode = table.Column<string>(type: "text", nullable: false),
                    size = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    salePercentage = table.Column<float>(type: "real", nullable: false),
                    imageUrl = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    category = table.Column<string>(type: "text", nullable: false),
                    availableSize = table.Column<List<string>>(type: "text[]", nullable: false),
                    availableColor = table.Column<List<string>>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nameTag = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    edited = table.Column<bool>(type: "boolean", nullable: false),
                    commentText = table.Column<string>(type: "text", nullable: true),
                    productId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comments_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    url = table.Column<string>(type: "text", nullable: true),
                    width = table.Column<int>(type: "integer", nullable: false),
                    height = table.Column<int>(type: "integer", nullable: false),
                    createAT = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    producId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.id);
                    table.ForeignKey(
                        name: "FK_Images_Products_producId",
                        column: x => x.producId,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderToProduct",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    ProductName = table.Column<string>(type: "text", nullable: false),
                    amountItem = table.Column<int>(type: "integer", nullable: false),
                    ProductPrice = table.Column<float>(type: "real", nullable: false),
                    color = table.Column<string>(type: "text", nullable: false),
                    size = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderToProduct", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderToProduct_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderToProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTag",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    TagId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTag", x => new { x.ProductId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ProductTag_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_productId",
                table: "Comments",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_producId",
                table: "Images",
                column: "producId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderToProduct_ProductId",
                table: "OrderToProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTag_TagId",
                table: "ProductTag",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "OrderToProduct");

            migrationBuilder.DropTable(
                name: "ProductTag");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Tag");
        }
    }
}
