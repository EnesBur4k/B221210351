using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B221210351.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "DoctorId", "DoctorName", "DoctorSurname", "Gender", "PoliclinicId" },
                values: new object[,]
                {
                    { 1, "Asım", "Bar", true, 1 },
                    { 2, "Basım", "Bar", true, 2 },
                    { 3, "Casım", "Bar", true, 3 },
                    { 4, "Dasım", "Bar", true, 4 },
                    { 5, "Esim", "Bar", true, 5 },
                    { 6, "Fesim", "Bar", true, 6 },
                    { 7, "Kesim", "Bar", true, 7 },
                    { 8, "Lesim", "Bar", true, 8 },
                    { 9, "Tesim", "Bar", true, 9 },
                    { 10, "Resim", "Bar", true, 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "DistrictId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "DistrictId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "DistrictId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Neighbourhoods",
                keyColumn: "NeighbourhoodId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Neighbourhoods",
                keyColumn: "NeighbourhoodId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Neighbourhoods",
                keyColumn: "NeighbourhoodId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Policlinics",
                keyColumn: "PoliclinicId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Policlinics",
                keyColumn: "PoliclinicId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Policlinics",
                keyColumn: "PoliclinicId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Policlinics",
                keyColumn: "PoliclinicId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Policlinics",
                keyColumn: "PoliclinicId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Policlinics",
                keyColumn: "PoliclinicId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Policlinics",
                keyColumn: "PoliclinicId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Policlinics",
                keyColumn: "PoliclinicId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Policlinics",
                keyColumn: "PoliclinicId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Policlinics",
                keyColumn: "PoliclinicId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Street",
                keyColumn: "StreetId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Street",
                keyColumn: "StreetId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Street",
                keyColumn: "StreetId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 8);
        }
    }
}
