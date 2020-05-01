using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspnetCoreBasicArchitecture.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DiteTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "DiteTime", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("e92864cb-3da6-413d-9a75-45142bcd9e09"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product1", 12.3 },
                    { new Guid("bf57cbbc-a26c-43bd-900c-ebd12c174590"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product2", 45.8 },
                    { new Guid("7d69b489-a490-4317-be90-a2d411a65077"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product3", 36.9 },
                    { new Guid("afe5525a-b40b-4ff4-9640-784df6852b6b"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product4", 24.7 },
                    { new Guid("17e713a8-05f1-4694-a054-09375882c520"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product5", 13.9 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
