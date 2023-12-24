using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B221210351.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PatientBirthDay", "PatientGender", "PatientName", "PatientPersonalId", "PatientSurname", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, 1, "725a0033-67af-4788-9711-d3d1c985dc79", "enesburak@gmail.com", false, false, null, null, null, null, new DateTime(2023, 12, 24, 16, 26, 26, 869, DateTimeKind.Local).AddTicks(7689), true, "Enes", 100, "Burak", null, false, "5c7e7550-3968-4641-95aa-7c4be8d55e2d", false, null },
                    { "2", 0, 2, "ec534ae5-36cf-43bb-82e2-0e8acfd56766", "ogun@gmail.com", false, false, null, null, null, null, new DateTime(2023, 12, 24, 16, 26, 26, 869, DateTimeKind.Local).AddTicks(7710), true, "Ogün", 101, "Şanlısoy", null, false, "8ce0990b-3bd4-41ee-a38d-f4b9b2ce6bd9", false, null },
                    { "3", 0, 3, "cea305f0-22af-4f48-9d50-156eefbcbfec", "winston@gmail.com", false, false, null, null, null, null, new DateTime(2023, 12, 24, 16, 26, 26, 869, DateTimeKind.Local).AddTicks(7738), true, "Winston", 102, "Churchill", null, false, "b934c5fd-f7f1-4574-91fd-3125f372db74", false, null },
                    { "4", 0, 2, "571b0a88-6ad3-4aa6-a958-7ee758e1ee0c", "goat@gmail.com", false, false, null, null, null, null, new DateTime(2023, 12, 24, 16, 26, 26, 869, DateTimeKind.Local).AddTicks(7744), true, "Emanuel", 103, "İcardi", null, false, "7c8c57a9-7d16-40c9-b754-e262e8da23a7", false, null },
                    { "5", 0, 1, "4978dd12-5942-4831-9f9e-25eafea92da3", "bulent@gmail.com", false, false, null, null, null, null, new DateTime(2023, 12, 24, 16, 26, 26, 869, DateTimeKind.Local).AddTicks(7753), true, "Bülent", 104, "Ersoy", null, false, "c15939db-abef-4763-b1dd-1ddda936121c", false, null },
                    { "6", 0, 3, "2d586903-686a-4464-8606-2eb80e18b959", "senar@gmail.com", false, false, null, null, null, null, new DateTime(2023, 12, 24, 16, 26, 26, 869, DateTimeKind.Local).AddTicks(7759), true, "Muazzez", 105, "Senar", null, false, "7834a612-4f36-4698-8df4-f160c7bdc827", false, null },
                    { "7", 0, 2, "e77d6cd1-bd2c-437d-a649-a64a939c46ba", "gogh@gmail.com", false, false, null, null, null, null, new DateTime(2023, 12, 24, 16, 26, 26, 869, DateTimeKind.Local).AddTicks(7764), true, "Vincent", 106, "Van Gogh", null, false, "71ceef8e-102a-4ed8-881f-c16b59ba7c65", false, null },
                    { "8", 0, 1, "a47878ef-fdf4-478c-8650-9a0c940cc473", "heisenberg@gmail.com", false, false, null, null, null, null, new DateTime(2023, 12, 24, 16, 26, 26, 869, DateTimeKind.Local).AddTicks(7772), true, "Werner", 107, "Heisenberg", null, false, "164421ee-90bb-477f-a248-0d4689ab116e", false, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8");
        }
    }
}
