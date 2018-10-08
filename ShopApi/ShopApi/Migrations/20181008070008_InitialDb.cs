using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopApi.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Shop");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "Shop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "NVARCHAR", maxLength: 255, nullable: false),
                    ParentId = table.Column<int>(type: "INT", nullable: false),
                    InsertedAt = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coupons",
                schema: "Shop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "NVARCHAR", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Active = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true),
                    Value = table.Column<int>(type: "INT", nullable: false),
                    Multiple = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    StartDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    EndDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    InsertedAt = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductStatuses",
                schema: "Shop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "NVARCHAR", maxLength: 255, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Shop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "NVARCHAR", maxLength: 255, nullable: false),
                    InsertedAt = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                schema: "Shop",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Data = table.Column<string>(type: "TEXT", nullable: true),
                    InsertedAt = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                schema: "Shop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "NVARCHAR", maxLength: 255, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Shop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "VARCHAR", maxLength: 255, nullable: false),
                    FirstName = table.Column<string>(type: "NVARCHAR", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "NVARCHAR", maxLength: 255, nullable: false),
                    Active = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true),
                    InsertedAt = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Shop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sku = table.Column<string>(type: "NVARCHAR", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ProductStatusIdId = table.Column<int>(nullable: true),
                    RegularPrice = table.Column<int>(type: "INT", nullable: false, defaultValue: 0),
                    DiscountPrice = table.Column<int>(type: "INT", nullable: false, defaultValue: 0),
                    Quantity = table.Column<int>(type: "INT", nullable: false, defaultValue: 0),
                    Tex = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    InsertedAt = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductStatuses_ProductStatusIdId",
                        column: x => x.ProductStatusIdId,
                        principalSchema: "Shop",
                        principalTable: "ProductStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrders",
                schema: "Shop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Total = table.Column<int>(type: "INT", nullable: false),
                    CouponIdId = table.Column<int>(nullable: true),
                    SessionIdId = table.Column<string>(nullable: true),
                    UserIdId = table.Column<int>(nullable: true),
                    InsertedAt = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesOrders_Coupons_CouponIdId",
                        column: x => x.CouponIdId,
                        principalSchema: "Shop",
                        principalTable: "Coupons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrders_Sessions_SessionIdId",
                        column: x => x.SessionIdId,
                        principalSchema: "Shop",
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrders_Users_UserIdId",
                        column: x => x.UserIdId,
                        principalSchema: "Shop",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "Shop",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    InsertedAt = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Shop",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Shop",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                schema: "Shop",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    InsertedAt = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Shop",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Shop",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTags",
                schema: "Shop",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTags", x => new { x.ProductId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ProductTags_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Shop",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTags_Tags_TagId",
                        column: x => x.TagId,
                        principalSchema: "Shop",
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CcTransactions",
                schema: "Shop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "NVARCHAR", maxLength: 255, nullable: true),
                    OrderIdId = table.Column<int>(nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Processor = table.Column<string>(type: "NVARCHAR", maxLength: 255, nullable: false),
                    ProcessorTransactionId = table.Column<string>(type: "NVARCHAR", maxLength: 255, nullable: false),
                    Amount = table.Column<int>(type: "INT", nullable: false),
                    CcNum = table.Column<string>(type: "NVARCHAR", maxLength: 255, nullable: true),
                    CcType = table.Column<string>(type: "NVARCHAR", maxLength: 255, nullable: true),
                    Response = table.Column<string>(type: "TEXT", nullable: true),
                    InsertedAt = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CcTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CcTransactions_SalesOrders_OrderIdId",
                        column: x => x.OrderIdId,
                        principalSchema: "Shop",
                        principalTable: "SalesOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                schema: "Shop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderIdId = table.Column<int>(nullable: true),
                    Sku = table.Column<string>(type: "NVARCHAR", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<int>(type: "INT", nullable: false),
                    Quantity = table.Column<int>(type: "INT", nullable: false),
                    SubTotal = table.Column<int>(type: "INT", nullable: false),
                    InsertedAt = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProducts_SalesOrders_OrderIdId",
                        column: x => x.OrderIdId,
                        principalSchema: "Shop",
                        principalTable: "SalesOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CcTransactions_OrderIdId",
                schema: "Shop",
                table: "CcTransactions",
                column: "OrderIdId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderIdId",
                schema: "Shop",
                table: "OrderProducts",
                column: "OrderIdId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                schema: "Shop",
                table: "ProductCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductStatusIdId",
                schema: "Shop",
                table: "Products",
                column: "ProductStatusIdId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTags_TagId",
                schema: "Shop",
                table: "ProductTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_CouponIdId",
                schema: "Shop",
                table: "SalesOrders",
                column: "CouponIdId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_SessionIdId",
                schema: "Shop",
                table: "SalesOrders",
                column: "SessionIdId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_UserIdId",
                schema: "Shop",
                table: "SalesOrders",
                column: "UserIdId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "Shop",
                table: "UserRoles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CcTransactions",
                schema: "Shop");

            migrationBuilder.DropTable(
                name: "OrderProducts",
                schema: "Shop");

            migrationBuilder.DropTable(
                name: "ProductCategories",
                schema: "Shop");

            migrationBuilder.DropTable(
                name: "ProductTags",
                schema: "Shop");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "Shop");

            migrationBuilder.DropTable(
                name: "SalesOrders",
                schema: "Shop");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "Shop");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Shop");

            migrationBuilder.DropTable(
                name: "Tags",
                schema: "Shop");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Shop");

            migrationBuilder.DropTable(
                name: "Coupons",
                schema: "Shop");

            migrationBuilder.DropTable(
                name: "Sessions",
                schema: "Shop");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Shop");

            migrationBuilder.DropTable(
                name: "ProductStatuses",
                schema: "Shop");
        }
    }
}
