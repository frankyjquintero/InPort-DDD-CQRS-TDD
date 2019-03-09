using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InPort.Infra.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CountryName = table.Column<string>(nullable: true),
                    CountryISOCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeasurentUnitType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, defaultValue: 1),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurentUnitType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, defaultValue: 1),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RawPhoto = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StoredEvent",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Action = table.Column<string>(type: "varchar(100)", nullable: true),
                    AggregateId = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Data = table.Column<string>(nullable: true),
                    User = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoredEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeasurentUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MeasurentUnitTypeId1 = table.Column<int>(nullable: true),
                    MeasurentUnitTypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurentUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeasurentUnits_MeasurentUnitType_MeasurentUnitTypeId",
                        column: x => x.MeasurentUnitTypeId,
                        principalTable: "MeasurentUnitType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeasurentUnits_MeasurentUnitType_MeasurentUnitTypeId1",
                        column: x => x.MeasurentUnitTypeId1,
                        principalTable: "MeasurentUnitType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address_City = table.Column<string>(nullable: true),
                    Address_ZipCode = table.Column<string>(nullable: true),
                    Address_AddressLine1 = table.Column<string>(nullable: true),
                    Address_AddressLine2 = table.Column<string>(nullable: true),
                    IsEnabled = table.Column<bool>(nullable: false),
                    CountryId = table.Column<Guid>(nullable: false),
                    PictureId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_Picture_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Picture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductMeasurentUnit",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    MeasurentUnitId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMeasurentUnit", x => new { x.ProductId, x.MeasurentUnitId });
                    table.ForeignKey(
                        name: "FK_ProductMeasurentUnit_MeasurentUnits_MeasurentUnitId",
                        column: x => x.MeasurentUnitId,
                        principalTable: "MeasurentUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductMeasurentUnit_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderIncomes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    MainSupportDocument = table.Column<string>(nullable: true),
                    SecondarySupportDocument = table.Column<string>(nullable: true),
                    Observation = table.Column<string>(nullable: true),
                    CustomerId = table.Column<Guid>(nullable: false),
                    CustomerId1 = table.Column<Guid>(nullable: true),
                    OrderIncomeStatusId1 = table.Column<int>(nullable: true),
                    OrderIncomeStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderIncomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderIncomes_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderIncomes_Customers_CustomerId1",
                        column: x => x.CustomerId1,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderIncomes_OrderStatus_OrderIncomeStatusId",
                        column: x => x.OrderIncomeStatusId,
                        principalTable: "OrderStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderIncomes_OrderStatus_OrderIncomeStatusId1",
                        column: x => x.OrderIncomeStatusId1,
                        principalTable: "OrderStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderIncomeLines",
                columns: table => new
                {
                    OrderIncomeLineId = table.Column<Guid>(nullable: false),
                    OrderIncomeId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    ProductName = table.Column<string>(nullable: false),
                    MeasurentUnitId = table.Column<Guid>(nullable: false),
                    MeasurentUnitName = table.Column<string>(nullable: false),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderIncomeLines", x => x.OrderIncomeLineId);
                    table.ForeignKey(
                        name: "FK_OrderIncomeLines_MeasurentUnits_MeasurentUnitId",
                        column: x => x.MeasurentUnitId,
                        principalTable: "MeasurentUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderIncomeLines_OrderIncomes_OrderIncomeId",
                        column: x => x.OrderIncomeId,
                        principalTable: "OrderIncomes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderIncomeLines_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CountryId",
                table: "Customers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PictureId",
                table: "Customers",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurentUnits_MeasurentUnitTypeId",
                table: "MeasurentUnits",
                column: "MeasurentUnitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurentUnits_MeasurentUnitTypeId1",
                table: "MeasurentUnits",
                column: "MeasurentUnitTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderIncomeLines_MeasurentUnitId",
                table: "OrderIncomeLines",
                column: "MeasurentUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderIncomeLines_OrderIncomeId",
                table: "OrderIncomeLines",
                column: "OrderIncomeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderIncomeLines_ProductId",
                table: "OrderIncomeLines",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderIncomes_CustomerId",
                table: "OrderIncomes",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderIncomes_CustomerId1",
                table: "OrderIncomes",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderIncomes_OrderIncomeStatusId",
                table: "OrderIncomes",
                column: "OrderIncomeStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderIncomes_OrderIncomeStatusId1",
                table: "OrderIncomes",
                column: "OrderIncomeStatusId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMeasurentUnit_MeasurentUnitId",
                table: "ProductMeasurentUnit",
                column: "MeasurentUnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderIncomeLines");

            migrationBuilder.DropTable(
                name: "ProductMeasurentUnit");

            migrationBuilder.DropTable(
                name: "StoredEvent");

            migrationBuilder.DropTable(
                name: "OrderIncomes");

            migrationBuilder.DropTable(
                name: "MeasurentUnits");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "MeasurentUnitType");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Picture");
        }
    }
}
