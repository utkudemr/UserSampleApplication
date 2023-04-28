using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserSample.Data.Service.Migrations
{
    /// <inheritdoc />
    public partial class userinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TCKNumber = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "ModifiedDate", "IsActive", "Name", "Surname", "TCKNumber" },
                values: new object[,]
                {
                    { new Guid("1681c8df-61c0-4899-8535-b3ed5b40ca35"), new DateTime(2023, 4, 28, 21, 52, 31, 819, DateTimeKind.Local).AddTicks(914), new DateTime(2023, 4, 28, 21, 52, 31, 819, DateTimeKind.Local).AddTicks(914), true, "test", "test", 1111111111L },
                    { new Guid("3c315d0d-5186-4df4-90cf-b7527f70f308"), new DateTime(2023, 4, 28, 21, 52, 31, 819, DateTimeKind.Local).AddTicks(917), new DateTime(2023, 4, 28, 21, 52, 31, 819, DateTimeKind.Local).AddTicks(917), true, "test1", "test1", 1111111112L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
