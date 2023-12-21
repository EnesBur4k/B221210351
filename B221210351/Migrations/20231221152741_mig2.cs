using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B221210351.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_City_CityId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_District_DistrictId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Neighbourhood_NeighbourhoodId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Street_StreetId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_District_City_CityId",
                table: "District");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Address_AddressId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Neighbourhood_District_DistrictId",
                table: "Neighbourhood");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Address_AddressId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Policlinics_Department_DepartmentId",
                table: "Policlinics");

            migrationBuilder.DropForeignKey(
                name: "FK_Street_Neighbourhood_NeighbourhoodId",
                table: "Street");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Neighbourhood",
                table: "Neighbourhood");

            migrationBuilder.DropPrimaryKey(
                name: "PK_District",
                table: "District");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Neighbourhood",
                newName: "Neighbourhoods");

            migrationBuilder.RenameTable(
                name: "District",
                newName: "Districts");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Departments");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "Cities");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_Neighbourhood_DistrictId",
                table: "Neighbourhoods",
                newName: "IX_Neighbourhoods_DistrictId");

            migrationBuilder.RenameIndex(
                name: "IX_District_CityId",
                table: "Districts",
                newName: "IX_Districts_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_StreetId",
                table: "Addresses",
                newName: "IX_Addresses_StreetId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_NeighbourhoodId",
                table: "Addresses",
                newName: "IX_Addresses_NeighbourhoodId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_DistrictId",
                table: "Addresses",
                newName: "IX_Addresses_DistrictId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_CityId",
                table: "Addresses",
                newName: "IX_Addresses_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Neighbourhoods",
                table: "Neighbourhoods",
                column: "NeighbourhoodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Districts",
                table: "Districts",
                column: "DistrictId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "AddressId");

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
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

            migrationBuilder.CreateIndex(
                name: "IX_People_AddressId",
                table: "People",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Cities_CityId",
                table: "Addresses",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Districts_DistrictId",
                table: "Addresses",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "DistrictId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Neighbourhoods_NeighbourhoodId",
                table: "Addresses",
                column: "NeighbourhoodId",
                principalTable: "Neighbourhoods",
                principalColumn: "NeighbourhoodId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Street_StreetId",
                table: "Addresses",
                column: "StreetId",
                principalTable: "Street",
                principalColumn: "StreetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Districts_Cities_CityId",
                table: "Districts",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Addresses_AddressId",
                table: "Doctors",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Neighbourhoods_Districts_DistrictId",
                table: "Neighbourhoods",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Addresses_AddressId",
                table: "Patients",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Policlinics_Departments_DepartmentId",
                table: "Policlinics",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Street_Neighbourhoods_NeighbourhoodId",
                table: "Street",
                column: "NeighbourhoodId",
                principalTable: "Neighbourhoods",
                principalColumn: "NeighbourhoodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Cities_CityId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Districts_DistrictId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Neighbourhoods_NeighbourhoodId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Street_StreetId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Districts_Cities_CityId",
                table: "Districts");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Addresses_AddressId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Neighbourhoods_Districts_DistrictId",
                table: "Neighbourhoods");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Addresses_AddressId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Policlinics_Departments_DepartmentId",
                table: "Policlinics");

            migrationBuilder.DropForeignKey(
                name: "FK_Street_Neighbourhoods_NeighbourhoodId",
                table: "Street");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Neighbourhoods",
                table: "Neighbourhoods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Districts",
                table: "Districts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Neighbourhoods",
                newName: "Neighbourhood");

            migrationBuilder.RenameTable(
                name: "Districts",
                newName: "District");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Department");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "City");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_Neighbourhoods_DistrictId",
                table: "Neighbourhood",
                newName: "IX_Neighbourhood_DistrictId");

            migrationBuilder.RenameIndex(
                name: "IX_Districts_CityId",
                table: "District",
                newName: "IX_District_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_StreetId",
                table: "Address",
                newName: "IX_Address_StreetId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_NeighbourhoodId",
                table: "Address",
                newName: "IX_Address_NeighbourhoodId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_DistrictId",
                table: "Address",
                newName: "IX_Address_DistrictId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_CityId",
                table: "Address",
                newName: "IX_Address_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Neighbourhood",
                table: "Neighbourhood",
                column: "NeighbourhoodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_District",
                table: "District",
                column: "DistrictId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_City_CityId",
                table: "Address",
                column: "CityId",
                principalTable: "City",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_District_DistrictId",
                table: "Address",
                column: "DistrictId",
                principalTable: "District",
                principalColumn: "DistrictId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Neighbourhood_NeighbourhoodId",
                table: "Address",
                column: "NeighbourhoodId",
                principalTable: "Neighbourhood",
                principalColumn: "NeighbourhoodId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Street_StreetId",
                table: "Address",
                column: "StreetId",
                principalTable: "Street",
                principalColumn: "StreetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_District_City_CityId",
                table: "District",
                column: "CityId",
                principalTable: "City",
                principalColumn: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Address_AddressId",
                table: "Doctors",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Neighbourhood_District_DistrictId",
                table: "Neighbourhood",
                column: "DistrictId",
                principalTable: "District",
                principalColumn: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Address_AddressId",
                table: "Patients",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Policlinics_Department_DepartmentId",
                table: "Policlinics",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Street_Neighbourhood_NeighbourhoodId",
                table: "Street",
                column: "NeighbourhoodId",
                principalTable: "Neighbourhood",
                principalColumn: "NeighbourhoodId");
        }
    }
}
