using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B221210351.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.DistrictId);
                });

            migrationBuilder.CreateTable(
                name: "Neighbourhoods",
                columns: table => new
                {
                    NeighbourhoodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NeighbourhoodName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Neighbourhoods", x => x.NeighbourhoodId);
                });

            migrationBuilder.CreateTable(
                name: "Street",
                columns: table => new
                {
                    StreetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Street", x => x.StreetId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Policlinics",
                columns: table => new
                {
                    PoliclinicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliclinicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policlinics", x => x.PoliclinicId);
                    table.ForeignKey(
                        name: "FK_Policlinics_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    NeighbourhoodId = table.Column<int>(type: "int", nullable: false),
                    StreetId = table.Column<int>(type: "int", nullable: false),
                    ApartmentNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_Neighbourhoods_NeighbourhoodId",
                        column: x => x.NeighbourhoodId,
                        principalTable: "Neighbourhoods",
                        principalColumn: "NeighbourhoodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_Street_StreetId",
                        column: x => x.StreetId,
                        principalTable: "Street",
                        principalColumn: "StreetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthdayDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    PersonalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PoliclinicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                    table.ForeignKey(
                        name: "FK_Doctors_Policlinics_PoliclinicId",
                        column: x => x.PoliclinicId,
                        principalTable: "Policlinics",
                        principalColumn: "PoliclinicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_Patients_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDay = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    PersonalId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_People_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PoliclinicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Policlinics_PoliclinicId",
                        column: x => x.PoliclinicId,
                        principalTable: "Policlinics",
                        principalColumn: "PoliclinicId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[,]
                {
                    { 1, "İstanbul" },
                    { 2, "Kocaeli" },
                    { 3, "Sakarya" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "İç Hastalıkları Anabilim Dalı" },
                    { 2, "Kardiyoloji Anabilim Dalı" },
                    { 3, "Göğüs Hastalıkları Anabilim Dalı" },
                    { 4, "Çocuk Sağlığı ve Hastalıkları Anabilim Dalı" },
                    { 5, "Ruh Sağlığı ve Hastalıkları Anabilim Dalı" },
                    { 6, "Nöroloji Anabilim Dalı" },
                    { 7, "Deri ve Zührevi Anabilim Dalı" },
                    { 8, "Genel Cerrahi Anabilim Dalı" }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "DistrictId", "DistrictName" },
                values: new object[,]
                {
                    { 1, "Pendik" },
                    { 2, "Kartal" },
                    { 3, "Maltepe" }
                });

            migrationBuilder.InsertData(
                table: "Neighbourhoods",
                columns: new[] { "NeighbourhoodId", "NeighbourhoodName" },
                values: new object[,]
                {
                    { 1, "Güzelyalı" },
                    { 2, "Kaynarca" },
                    { 3, "Çamçeşme" }
                });

            migrationBuilder.InsertData(
                table: "Street",
                columns: new[] { "StreetId", "StreetName" },
                values: new object[,]
                {
                    { 1, "Yavuz Selim" },
                    { 2, "Teoman" },
                    { 3, "Toplum" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "ApartmentNo", "CityId", "DistrictId", "NeighbourhoodId", "StreetId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1, 1 },
                    { 2, 2, 1, 2, 2, 2 },
                    { 3, 3, 1, 3, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Policlinics",
                columns: new[] { "PoliclinicId", "DepartmentId", "PoliclinicName" },
                values: new object[,]
                {
                    { 1, 1, "Endokrinoloji ve Metabolizma Kliniği" },
                    { 2, 1, "Gastroenteroloji Kliniği" },
                    { 3, 2, "Kardiyoloji Kliniği" },
                    { 4, 3, "Göğüs Hastalıkları Kliniği" },
                    { 5, 4, "Çocuk Gastroenterolojisi Kliniği" },
                    { 6, 4, "Çocuk Kardiyolojisi Kliniği" },
                    { 7, 5, "Ruh Sağlığı ve Hastalıkları Kliniği" },
                    { 8, 6, "Nöroloji Kliniği" },
                    { 9, 7, "Deri ve Zührevi Hastalıklar Kliniği" },
                    { 10, 8, "Genel Cerrahi Kliniği" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "BirthdayDate", "Gender", "Name", "PersonalId", "PoliclinicId", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Local), true, "Asım", "123", 1, "Bar" },
                    { 2, new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Local), true, "Basım", "123", 2, "Bar" },
                    { 3, new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Local), true, "Casım", "123", 3, "Bar" },
                    { 4, new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Local), true, "Dasım", "123", 4, "Bar" },
                    { 5, new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Local), true, "Esim", "123", 5, "Bar" },
                    { 6, new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Local), true, "Fesim", "123", 6, "Bar" },
                    { 7, new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Local), true, "Kesim", "123", 7, "Bar" },
                    { 8, new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Local), true, "Lesim", "123", 8, "Bar" },
                    { 9, new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Local), true, "Tesim", "123", 9, "Bar" },
                    { 10, new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Local), true, "Resim", "123", 10, "Bar" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_DistrictId",
                table: "Addresses",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_NeighbourhoodId",
                table: "Addresses",
                column: "NeighbourhoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StreetId",
                table: "Addresses",
                column: "StreetId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PoliclinicId",
                table: "Appointments",
                column: "PoliclinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_PoliclinicId",
                table: "Doctors",
                column: "PoliclinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AddressId",
                table: "Patients",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_People_AddressId",
                table: "People",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Policlinics_DepartmentId",
                table: "Policlinics",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Policlinics");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Neighbourhoods");

            migrationBuilder.DropTable(
                name: "Street");
        }
    }
}
