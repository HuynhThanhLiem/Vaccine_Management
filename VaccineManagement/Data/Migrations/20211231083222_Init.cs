using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VaccineManagement.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "UserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "UserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "UserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "UserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "RoleClaims");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "UserRoles",
                newName: "IX_UserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "UserLogins",
                newName: "IX_UserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "UserClaims",
                newName: "IX_UserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "RoleClaims",
                newName: "IX_RoleClaims_RoleId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "UserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "UserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "UserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTokens",
                table: "UserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLogins",
                table: "UserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserClaims",
                table: "UserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleClaims",
                table: "RoleClaims",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ANAMNESIS",
                columns: table => new
                {
                    anamnesisId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    anaphylaxis = table.Column<string>(maxLength: 10, nullable: false),
                    lowImmunity = table.Column<string>(maxLength: 10, nullable: false),
                    acuteIllness = table.Column<string>(maxLength: 10, nullable: false),
                    allergy = table.Column<string>(maxLength: 10, nullable: false),
                    older = table.Column<string>(maxLength: 10, nullable: false),
                    pregnancy = table.Column<string>(maxLength: 10, nullable: false),
                    bloodDisorder = table.Column<string>(maxLength: 10, nullable: false),
                    useInhibition = table.Column<string>(maxLength: 10, nullable: false),
                    developChronic = table.Column<string>(maxLength: 10, nullable: false),
                    curedChronic = table.Column<string>(maxLength: 10, nullable: false),
                    vaccineedHalfMonth = table.Column<string>(maxLength: 10, nullable: false),
                    covidSixMonths = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ANAMNESIS", x => x.anamnesisId);
                });

            migrationBuilder.CreateTable(
                name: "CITIZEN",
                columns: table => new
                {
                    citizenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCard = table.Column<string>(maxLength: 50, nullable: false),
                    fullName = table.Column<string>(maxLength: 50, nullable: false),
                    gender = table.Column<string>(maxLength: 5, nullable: false),
                    dateOfBirth = table.Column<DateTime>(nullable: false),
                    phoneNumber = table.Column<string>(maxLength: 50, nullable: false),
                    email = table.Column<string>(maxLength: 50, nullable: false),
                    address = table.Column<string>(maxLength: 300, nullable: false),
                    healthInsurance = table.Column<string>(maxLength: 50, nullable: false),
                    job = table.Column<string>(maxLength: 50, nullable: false),
                    company = table.Column<string>(maxLength: 50, nullable: false),
                    nation = table.Column<string>(maxLength: 50, nullable: false),
                    nationality = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CITIZEN", x => x.citizenId);
                });

            migrationBuilder.CreateTable(
                name: "CITY",
                columns: table => new
                {
                    cityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cityName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CITY", x => x.cityId);
                });

            migrationBuilder.CreateTable(
                name: "MEDICAL_STAFF",
                columns: table => new
                {
                    staffId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullName = table.Column<string>(maxLength: 50, nullable: false),
                    phoneNumber = table.Column<string>(maxLength: 50, nullable: false),
                    email = table.Column<string>(maxLength: 50, nullable: false),
                    assignment = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEDICAL_STAFF", x => x.staffId);
                });

            migrationBuilder.CreateTable(
                name: "VACCINE",
                columns: table => new
                {
                    vaccineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    origin = table.Column<string>(maxLength: 40, nullable: false),
                    maxRange = table.Column<int>(nullable: false),
                    expired = table.Column<int>(nullable: false),
                    doses = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VACCINE", x => x.vaccineId);
                });

            migrationBuilder.CreateTable(
                name: "HEALTH_DECLARATION",
                columns: table => new
                {
                    healthDeclarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    citizenId = table.Column<int>(nullable: false),
                    hasSymptom = table.Column<string>(maxLength: 10, nullable: false),
                    contactSymptom = table.Column<string>(maxLength: 10, nullable: false),
                    contactForeigner = table.Column<string>(maxLength: 10, nullable: false),
                    contactCovidPerson = table.Column<string>(maxLength: 10, nullable: false),
                    fromCovidPlace = table.Column<string>(maxLength: 10, nullable: false),
                    declaratedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HEALTH_DECLARATION", x => x.healthDeclarId);
                    table.ForeignKey(
                        name: "FK_HEALTH_DECLARATION_CITIZEN_citizenId",
                        column: x => x.citizenId,
                        principalTable: "CITIZEN",
                        principalColumn: "citizenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VACCINE_REGISTRATION",
                columns: table => new
                {
                    registrationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    citizenId = table.Column<int>(nullable: false),
                    anamnesisId = table.Column<int>(nullable: false),
                    agreement = table.Column<string>(maxLength: 10, nullable: false),
                    choiceInjections = table.Column<int>(nullable: false),
                    registratedDate = table.Column<DateTime>(nullable: false),
                    status = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VACCINE_REGISTRATION", x => x.registrationId);
                    table.ForeignKey(
                        name: "FK_VACCINE_REGISTRATION_ANAMNESIS_anamnesisId",
                        column: x => x.anamnesisId,
                        principalTable: "ANAMNESIS",
                        principalColumn: "anamnesisId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VACCINE_REGISTRATION_CITIZEN_citizenId",
                        column: x => x.citizenId,
                        principalTable: "CITIZEN",
                        principalColumn: "citizenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DISTRICT",
                columns: table => new
                {
                    districtId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cityId = table.Column<int>(nullable: false),
                    districtName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DISTRICT", x => x.districtId);
                    table.ForeignKey(
                        name: "FK_DISTRICT_CITY_cityId",
                        column: x => x.cityId,
                        principalTable: "CITY",
                        principalColumn: "cityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VACCINE_BATCH",
                columns: table => new
                {
                    batchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    batchName = table.Column<string>(maxLength: 50, nullable: false),
                    vaccineId = table.Column<int>(nullable: false),
                    importedDate = table.Column<DateTime>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    producedDate = table.Column<DateTime>(nullable: false),
                    expiredDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VACCINE_BATCH", x => x.batchId);
                    table.ForeignKey(
                        name: "FK_VACCINE_BATCH_VACCINE_vaccineId",
                        column: x => x.vaccineId,
                        principalTable: "VACCINE",
                        principalColumn: "vaccineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WARD",
                columns: table => new
                {
                    wardId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    districtId = table.Column<int>(nullable: false),
                    wardName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WARD", x => x.wardId);
                    table.ForeignKey(
                        name: "FK_WARD_DISTRICT_districtId",
                        column: x => x.districtId,
                        principalTable: "DISTRICT",
                        principalColumn: "districtId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BATCH_CITY",
                columns: table => new
                {
                    cityId = table.Column<int>(nullable: false),
                    batchId = table.Column<int>(nullable: false),
                    quantityVaccine = table.Column<int>(nullable: false),
                    shippedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BATCH_CITY", x => new { x.cityId, x.batchId });
                    table.ForeignKey(
                        name: "FK_BATCH_CITY_VACCINE_BATCH_batchId",
                        column: x => x.batchId,
                        principalTable: "VACCINE_BATCH",
                        principalColumn: "batchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BATCH_CITY_CITY_cityId",
                        column: x => x.cityId,
                        principalTable: "CITY",
                        principalColumn: "cityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VACCINATION",
                columns: table => new
                {
                    vaccinationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cityId = table.Column<int>(nullable: false),
                    registrationId = table.Column<int>(nullable: false),
                    staffId = table.Column<int>(nullable: false),
                    batchId = table.Column<int>(nullable: false),
                    vaccineedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VACCINATION", x => x.vaccinationId);
                    table.ForeignKey(
                        name: "FK_VACCINATION_VACCINE_BATCH_batchId",
                        column: x => x.batchId,
                        principalTable: "VACCINE_BATCH",
                        principalColumn: "batchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VACCINATION_CITY_cityId",
                        column: x => x.cityId,
                        principalTable: "CITY",
                        principalColumn: "cityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VACCINATION_VACCINE_REGISTRATION_registrationId",
                        column: x => x.registrationId,
                        principalTable: "VACCINE_REGISTRATION",
                        principalColumn: "registrationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VACCINATION_MEDICAL_STAFF_staffId",
                        column: x => x.staffId,
                        principalTable: "MEDICAL_STAFF",
                        principalColumn: "staffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BATCH_CITY_batchId",
                table: "BATCH_CITY",
                column: "batchId");

            migrationBuilder.CreateIndex(
                name: "IX_DISTRICT_cityId",
                table: "DISTRICT",
                column: "cityId");

            migrationBuilder.CreateIndex(
                name: "IX_HEALTH_DECLARATION_citizenId",
                table: "HEALTH_DECLARATION",
                column: "citizenId");

            migrationBuilder.CreateIndex(
                name: "IX_VACCINATION_batchId",
                table: "VACCINATION",
                column: "batchId");

            migrationBuilder.CreateIndex(
                name: "IX_VACCINATION_cityId",
                table: "VACCINATION",
                column: "cityId");

            migrationBuilder.CreateIndex(
                name: "IX_VACCINATION_registrationId",
                table: "VACCINATION",
                column: "registrationId");

            migrationBuilder.CreateIndex(
                name: "IX_VACCINATION_staffId",
                table: "VACCINATION",
                column: "staffId");

            migrationBuilder.CreateIndex(
                name: "IX_VACCINE_BATCH_vaccineId",
                table: "VACCINE_BATCH",
                column: "vaccineId");

            migrationBuilder.CreateIndex(
                name: "IX_VACCINE_REGISTRATION_anamnesisId",
                table: "VACCINE_REGISTRATION",
                column: "anamnesisId");

            migrationBuilder.CreateIndex(
                name: "IX_VACCINE_REGISTRATION_citizenId",
                table: "VACCINE_REGISTRATION",
                column: "citizenId");

            migrationBuilder.CreateIndex(
                name: "IX_WARD_districtId",
                table: "WARD",
                column: "districtId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaims_Roles_RoleId",
                table: "RoleClaims",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_Users_UserId",
                table: "UserClaims",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_Users_UserId",
                table: "UserLogins",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_Users_UserId",
                table: "UserTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaims_Roles_RoleId",
                table: "RoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_Users_UserId",
                table: "UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_Users_UserId",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_Users_UserId",
                table: "UserTokens");

            migrationBuilder.DropTable(
                name: "BATCH_CITY");

            migrationBuilder.DropTable(
                name: "HEALTH_DECLARATION");

            migrationBuilder.DropTable(
                name: "VACCINATION");

            migrationBuilder.DropTable(
                name: "WARD");

            migrationBuilder.DropTable(
                name: "VACCINE_BATCH");

            migrationBuilder.DropTable(
                name: "VACCINE_REGISTRATION");

            migrationBuilder.DropTable(
                name: "MEDICAL_STAFF");

            migrationBuilder.DropTable(
                name: "DISTRICT");

            migrationBuilder.DropTable(
                name: "VACCINE");

            migrationBuilder.DropTable(
                name: "ANAMNESIS");

            migrationBuilder.DropTable(
                name: "CITIZEN");

            migrationBuilder.DropTable(
                name: "CITY");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTokens",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLogins",
                table: "UserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserClaims",
                table: "UserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleClaims",
                table: "RoleClaims");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLogins_UserId",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserClaims_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleClaims_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
