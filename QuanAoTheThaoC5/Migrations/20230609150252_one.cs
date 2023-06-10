using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanAoTheThaoC5.Migrations
{
<<<<<<<< Updated upstream:QuanAoTheThaoC5/Migrations/20230527003311_Dung_20833.cs
    public partial class Dung_20833 : Migration
========
    public partial class one : Migration
>>>>>>>> Stashed changes:QuanAoTheThaoC5/Migrations/20230609150252_one.cs
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColerCode = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductMaterials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMaterials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    SizeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SizeName = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.SizeId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupllierCode = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Descripton = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    VoucherCode = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDRole = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Roles_IDRole",
                        column: x => x.IDRole,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDCategory = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDSupplier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDSize = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_IDCategory",
                        column: x => x.IDCategory,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Sizes_IDSize",
                        column: x => x.IDSize,
                        principalTable: "Sizes",
                        principalColumn: "SizeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_IDSupplier",
                        column: x => x.IDSupplier,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDUser = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDVoucher = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TotalMoney = table.Column<double>(type: "float", nullable: false),
                    TransportFee = table.Column<double>(type: "float", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_User_IDUser",
                        column: x => x.IDUser,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bills_Vouchers_IDVoucher",
                        column: x => x.IDVoucher,
                        principalTable: "Vouchers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_User_User_ID",
                        column: x => x.User_ID,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColorDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColorDetails_Colors_ColorID",
                        column: x => x.ColorID,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColorDetails_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImgs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDProduct = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    URl = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImgs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImgs_Products_IDProduct",
                        column: x => x.IDProduct,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductMaterialDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDProductMaterial = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDProduct = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMaterialDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductMaterialDetails_ProductMaterials_IDProductMaterial",
                        column: x => x.IDProductMaterial,
                        principalTable: "ProductMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductMaterialDetails_Products_IDProduct",
                        column: x => x.IDProduct,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillDetails",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDBill = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDProduct = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BillDetails_Bills_IDBill",
                        column: x => x.IDBill,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillDetails_Products_IDProduct",
                        column: x => x.IDProduct,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Product_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cart_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartDetails_Carts_Cart_ID",
                        column: x => x.Cart_ID,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartDetails_Products_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillDetails_IDBill",
                table: "BillDetails",
                column: "IDBill");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetails_IDProduct",
                table: "BillDetails",
                column: "IDProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_IDUser",
                table: "Bills",
                column: "IDUser");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_IDVoucher",
                table: "Bills",
                column: "IDVoucher");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_Cart_ID",
                table: "CartDetails",
                column: "Cart_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_Product_ID",
                table: "CartDetails",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_User_ID",
                table: "Carts",
                column: "User_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ColorDetails_ColorID",
                table: "ColorDetails",
                column: "ColorID");

            migrationBuilder.CreateIndex(
                name: "IX_ColorDetails_ProductID",
                table: "ColorDetails",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImgs_IDProduct",
                table: "ProductImgs",
                column: "IDProduct");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMaterialDetails_IDProduct",
                table: "ProductMaterialDetails",
                column: "IDProduct");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMaterialDetails_IDProductMaterial",
                table: "ProductMaterialDetails",
                column: "IDProductMaterial");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IDCategory",
                table: "Products",
                column: "IDCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IDSize",
                table: "Products",
                column: "IDSize");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IDSupplier",
                table: "Products",
                column: "IDSupplier");

            migrationBuilder.CreateIndex(
                name: "IX_User_IDRole",
                table: "User",
                column: "IDRole");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillDetails");

            migrationBuilder.DropTable(
                name: "CartDetails");

            migrationBuilder.DropTable(
                name: "ColorDetails");

            migrationBuilder.DropTable(
                name: "ProductImgs");

            migrationBuilder.DropTable(
                name: "ProductMaterialDetails");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "ProductMaterials");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
