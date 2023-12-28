using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostOffice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Location_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location_BuildingNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostOffice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentMark",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipmentConstraint = table.Column<int>(type: "int", nullable: false),
                    PriceCoef = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentMark", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parcel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    OfficeFromId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfficeToId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcel_Client_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parcel_Client_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parcel_PostOffice_OfficeFromId",
                        column: x => x.OfficeFromId,
                        principalTable: "PostOffice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parcel_PostOffice_OfficeToId",
                        column: x => x.OfficeToId,
                        principalTable: "PostOffice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostOfficeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staff_PostOffice_PostOfficeId",
                        column: x => x.PostOfficeId,
                        principalTable: "PostOffice",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CategoryMark",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MarkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryMark", x => new { x.CategoryId, x.MarkId });
                    table.ForeignKey(
                        name: "FK_CategoryMark_ItemCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ItemCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade,
                        onUpdate: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryMark_ShipmentMark_MarkId",
                        column: x => x.MarkId,
                        principalTable: "ShipmentMark",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade,
                        onUpdate: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParcelItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Characteristics_Width = table.Column<int>(type: "int", nullable: false),
                    Characteristics_Height = table.Column<int>(type: "int", nullable: false),
                    Characteristics_Depth = table.Column<int>(type: "int", nullable: false),
                    Characteristics_Weight = table.Column<double>(type: "float", nullable: false),
                    ItemCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParcelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParcelItem_ItemCategory_ItemCategoryId",
                        column: x => x.ItemCategoryId,
                        principalTable: "ItemCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade,
                        onUpdate: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParcelItem_Parcel_ParcelId",
                        column: x => x.ParcelId,
                        principalTable: "Parcel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade,
                        onUpdate: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParcelStatusHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ChangesTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParcelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelStatusHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParcelStatusHistory_Parcel_ParcelId",
                        column: x => x.ParcelId,
                        principalTable: "Parcel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade,
                        onUpdate: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryMark_MarkId",
                table: "CategoryMark",
                column: "MarkId");

            migrationBuilder.CreateIndex(
                name: "Client_fullname",
                table: "Client",
                columns: new[] { "Name", "Surname" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Client_phone_number",
                table: "Client",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Category_name",
                table: "ItemCategory",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_OfficeFromId",
                table: "Parcel",
                column: "OfficeFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_OfficeToId",
                table: "Parcel",
                column: "OfficeToId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_ReceiverId",
                table: "Parcel",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_SenderId",
                table: "Parcel",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelItem_ItemCategoryId",
                table: "ParcelItem",
                column: "ItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelItem_ParcelId",
                table: "ParcelItem",
                column: "ParcelId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelStatusHistory_ParcelId",
                table: "ParcelStatusHistory",
                column: "ParcelId");

            migrationBuilder.CreateIndex(
                name: "Office_zip",
                table: "PostOffice",
                column: "Zip",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Shipment_constraint_type",
                table: "ShipmentMark",
                column: "ShipmentConstraint",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Staff_PostOfficeId",
                table: "Staff",
                column: "PostOfficeId");

            migrationBuilder.CreateIndex(
                name: "Staff_fullname",
                table: "Staff",
                columns: new[] { "Name", "Surname" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Staff_phone_number",
                table: "Staff",
                column: "PhoneNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryMark");

            migrationBuilder.DropTable(
                name: "ParcelItem");

            migrationBuilder.DropTable(
                name: "ParcelStatusHistory");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "ShipmentMark");

            migrationBuilder.DropTable(
                name: "ItemCategory");

            migrationBuilder.DropTable(
                name: "Parcel");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "PostOffice");
        }
    }
}
