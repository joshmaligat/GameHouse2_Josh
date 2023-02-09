using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameHouse2_Josh.Server.Migrations
{
    public partial class newDB_Order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateIn",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba",
                column: "ConcurrencyStamp",
                value: "e69e8058-0b4c-4626-aab5-e4a916089e78");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb",
                column: "ConcurrencyStamp",
                value: "793af869-dd3f-4e0d-9789-1d9185e52ed0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6908a77-43da-4b93-8b0c-91977cfe1224", "AQAAAAEAACcQAAAAEDye8oSGho/rete653f6nb0ClvhnvXEz89C0FP6EvfkGYhFXdPCT4Lef1ATZlQ2rJw==", "f63afd40-e297-463c-a47f-c0f156ba77c0" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 2, 9, 20, 48, 44, 998, DateTimeKind.Local).AddTicks(287), new DateTime(2023, 2, 9, 20, 48, 44, 998, DateTimeKind.Local).AddTicks(6973) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 2, 9, 20, 48, 44, 998, DateTimeKind.Local).AddTicks(7565), new DateTime(2023, 2, 9, 20, 48, 44, 998, DateTimeKind.Local).AddTicks(7567) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 2, 9, 20, 48, 44, 999, DateTimeKind.Local).AddTicks(6069), new DateTime(2023, 2, 9, 20, 48, 44, 999, DateTimeKind.Local).AddTicks(6074) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 2, 9, 20, 48, 44, 999, DateTimeKind.Local).AddTicks(6078), new DateTime(2023, 2, 9, 20, 48, 44, 999, DateTimeKind.Local).AddTicks(6079) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateIn",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba",
                column: "ConcurrencyStamp",
                value: "74504843-ce82-4a8b-bbea-f42cff5bb276");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb",
                column: "ConcurrencyStamp",
                value: "b10640b5-0cbc-43b5-a7c9-0c1dd3dc9972");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c317f93-3142-4fb3-b85c-5b9c2b7267fe", "AQAAAAEAACcQAAAAEIE4TNArjfF4qYtWpGOcaLsf5CmklccgSPdR2mEgBLDSMwGFJlxKlOlWXhBzWpUrkQ==", "c6f26d01-2c71-4e28-88eb-335e4e775df9" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 2, 9, 17, 48, 56, 865, DateTimeKind.Local).AddTicks(3287), new DateTime(2023, 2, 9, 17, 48, 56, 865, DateTimeKind.Local).AddTicks(9280) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 2, 9, 17, 48, 56, 865, DateTimeKind.Local).AddTicks(9833), new DateTime(2023, 2, 9, 17, 48, 56, 865, DateTimeKind.Local).AddTicks(9836) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 2, 9, 17, 48, 56, 866, DateTimeKind.Local).AddTicks(8417), new DateTime(2023, 2, 9, 17, 48, 56, 866, DateTimeKind.Local).AddTicks(8422) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 2, 9, 17, 48, 56, 866, DateTimeKind.Local).AddTicks(8424), new DateTime(2023, 2, 9, 17, 48, 56, 866, DateTimeKind.Local).AddTicks(8426) });
        }
    }
}
