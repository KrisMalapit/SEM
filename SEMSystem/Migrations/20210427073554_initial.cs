using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SEMSystem.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bicycles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameOwner = table.Column<string>(nullable: false),
                    ContactNo = table.Column<string>(nullable: true),
                    BrandName = table.Column<string>(nullable: false),
                    IdentificationNo = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bicycles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LocationFireExtinguisherDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationFireExtinguisherId = table.Column<int>(nullable: false),
                    LocationFireExtinguisherDetailsId = table.Column<int>(nullable: true),
                    DatePurchased = table.Column<DateTime>(nullable: false),
                    Warranty = table.Column<int>(nullable: false),
                    ItemStatus = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationFireExtinguisherDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationFireExtinguisherDetails_LocationFireExtinguisherDetails_LocationFireExtinguisherDetailsId",
                        column: x => x.LocationFireExtinguisherDetailsId,
                        principalTable: "LocationFireExtinguisherDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descriptions = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NoSeries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    LastNoUsed = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoSeries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BicycleEntryHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BicycleId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BicycleEntryHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BicycleEntryHeaders_Bicycles_BicycleId",
                        column: x => x.BicycleId,
                        principalTable: "Bicycles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Areas_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Departments_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BicycleEntryDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BicycleEntryHeaderId = table.Column<int>(nullable: false),
                    FrameSafe = table.Column<int>(nullable: false),
                    FrameUnSafe = table.Column<int>(nullable: false),
                    FrameRemarks = table.Column<string>(nullable: true),
                    FrontForkSafe = table.Column<int>(nullable: false),
                    FrontForkUnSafe = table.Column<int>(nullable: false),
                    FrontForkRemarks = table.Column<string>(nullable: true),
                    HandlebarSafe = table.Column<int>(nullable: false),
                    HandlebarUnSafe = table.Column<int>(nullable: false),
                    HandlebarRemarks = table.Column<string>(nullable: true),
                    SeatSafe = table.Column<int>(nullable: false),
                    SeatUnSafe = table.Column<int>(nullable: false),
                    SeatRemarks = table.Column<string>(nullable: true),
                    FrontRearSafe = table.Column<int>(nullable: false),
                    FrontRearUnSafe = table.Column<int>(nullable: false),
                    FrontRearRemarks = table.Column<string>(nullable: true),
                    BrakeSafe = table.Column<int>(nullable: false),
                    BrakeUnSafe = table.Column<int>(nullable: false),
                    BrakeRemarks = table.Column<string>(nullable: true),
                    CrankChainSafe = table.Column<int>(nullable: false),
                    CrankChainUnSafe = table.Column<int>(nullable: false),
                    CrankChainRemarks = table.Column<string>(nullable: true),
                    ChainSafe = table.Column<int>(nullable: false),
                    ChainUnSafe = table.Column<int>(nullable: false),
                    ChainRemarks = table.Column<string>(nullable: true),
                    InspectedBy = table.Column<string>(nullable: true),
                    NotedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BicycleEntryDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BicycleEntryDetails_BicycleEntryHeaders_BicycleEntryHeaderId",
                        column: x => x.BicycleEntryHeaderId,
                        principalTable: "BicycleEntryHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyLightHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyLightHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmergencyLightHeaders_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FireExtinguisherHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireExtinguisherHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FireExtinguisherHeaders_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FireHydrantHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireHydrantHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FireHydrantHeaders_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InergenTankHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InergenTankHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InergenTankHeaders_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationEmergencyLights",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Location = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    AreaId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationEmergencyLights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationEmergencyLights_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationFireExtinguishers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Location = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Capacity = table.Column<string>(nullable: true),
                    AreaId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationFireExtinguishers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationFireExtinguishers_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationFireHydrants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Location = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    AreaId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationFireHydrants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationFireHydrants_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationInergenTanks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Capacity = table.Column<string>(nullable: true),
                    Serial = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    AreaId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationInergenTanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationInergenTanks_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: false),
                    Domain = table.Column<string>(nullable: true),
                    CompanyAccess = table.Column<string>(nullable: true),
                    UserType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyLightDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationEmergencyLightId = table.Column<int>(nullable: false),
                    Battery = table.Column<int>(nullable: false),
                    Bulb = table.Column<int>(nullable: false),
                    Usable = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EmergencyLightHeaderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyLightDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmergencyLightDetails_EmergencyLightHeaders_EmergencyLightHeaderId",
                        column: x => x.EmergencyLightHeaderId,
                        principalTable: "EmergencyLightHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FireExtinguisherDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationFireExtinguisherId = table.Column<int>(nullable: false),
                    Cylinder = table.Column<int>(nullable: false),
                    Lever = table.Column<int>(nullable: false),
                    Gauge = table.Column<int>(nullable: false),
                    SafetySeal = table.Column<int>(nullable: false),
                    Hose = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    FireExtinguisherHeaderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireExtinguisherDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FireExtinguisherDetails_FireExtinguisherHeaders_FireExtinguisherHeaderId",
                        column: x => x.FireExtinguisherHeaderId,
                        principalTable: "FireExtinguisherHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FireHydrantDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationFireHydrantId = table.Column<int>(nullable: false),
                    GlassCabinet = table.Column<int>(nullable: false),
                    Hanger = table.Column<int>(nullable: false),
                    Hose15 = table.Column<int>(nullable: false),
                    Nozzle15 = table.Column<int>(nullable: false),
                    Hose25 = table.Column<int>(nullable: false),
                    Nozzle25 = table.Column<int>(nullable: false),
                    SpecialTools = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    FireHydrantHeaderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireHydrantDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FireHydrantDetails_FireHydrantHeaders_FireHydrantHeaderId",
                        column: x => x.FireHydrantHeaderId,
                        principalTable: "FireHydrantHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InergenTankDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationInergenTankId = table.Column<int>(nullable: false),
                    Cylinder = table.Column<int>(nullable: false),
                    Gauge = table.Column<int>(nullable: false),
                    Hose = table.Column<int>(nullable: false),
                    Pressure = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    InergenTankHeaderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InergenTankDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InergenTankDetails_InergenTankHeaders_InergenTankHeaderId",
                        column: x => x.InergenTankHeaderId,
                        principalTable: "InergenTankHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "ID", "Code", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "SLPGC", "Southwest Luzon Power Gen Corporation", "Active" },
                    { 2, "SCPC", "Sem-Calaca Power Corporation", "Active" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "Admin", "Active" },
                    { 2, "User", "Active" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "ID", "Code", "CompanyId", "Name", "Status" },
                values: new object[] { 1, "NA", 1, "NOTSET", "Deleted" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CompanyAccess", "DepartmentId", "Domain", "Email", "FirstName", "LastName", "Name", "Password", "RoleId", "Status", "UserType", "Username" },
                values: new object[] { 1, "1", 1, "SMCDACON", "kcmalapit@semirarampc.com", "Kristoffer", "Malapit", "Kristoffer Malapit", "", 1, "1", null, "kcmalapit" });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_CompanyId",
                table: "Areas",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_BicycleEntryDetails_BicycleEntryHeaderId",
                table: "BicycleEntryDetails",
                column: "BicycleEntryHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_BicycleEntryHeaders_BicycleId_CreatedAt_Status",
                table: "BicycleEntryHeaders",
                columns: new[] { "BicycleId", "CreatedAt", "Status" },
                unique: true,
                filter: "[Status] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bicycles_IdentificationNo_Status",
                table: "Bicycles",
                columns: new[] { "IdentificationNo", "Status" },
                unique: true,
                filter: "[Status] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CompanyId",
                table: "Departments",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyLightDetails_EmergencyLightHeaderId",
                table: "EmergencyLightDetails",
                column: "EmergencyLightHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyLightHeaders_AreaId_CreatedAt_Status",
                table: "EmergencyLightHeaders",
                columns: new[] { "AreaId", "CreatedAt", "Status" },
                unique: true,
                filter: "[Status] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FireExtinguisherDetails_FireExtinguisherHeaderId",
                table: "FireExtinguisherDetails",
                column: "FireExtinguisherHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_FireExtinguisherHeaders_AreaId_CreatedAt_Status",
                table: "FireExtinguisherHeaders",
                columns: new[] { "AreaId", "CreatedAt", "Status" },
                unique: true,
                filter: "[Status] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FireHydrantDetails_FireHydrantHeaderId",
                table: "FireHydrantDetails",
                column: "FireHydrantHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_FireHydrantHeaders_AreaId",
                table: "FireHydrantHeaders",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_InergenTankDetails_InergenTankHeaderId",
                table: "InergenTankDetails",
                column: "InergenTankHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_InergenTankHeaders_AreaId",
                table: "InergenTankHeaders",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationEmergencyLights_AreaId_Code_Status",
                table: "LocationEmergencyLights",
                columns: new[] { "AreaId", "Code", "Status" },
                unique: true,
                filter: "[Code] IS NOT NULL AND [Status] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LocationFireExtinguisherDetails_LocationFireExtinguisherDetailsId",
                table: "LocationFireExtinguisherDetails",
                column: "LocationFireExtinguisherDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationFireExtinguishers_AreaId_Code_Status",
                table: "LocationFireExtinguishers",
                columns: new[] { "AreaId", "Code", "Status" },
                unique: true,
                filter: "[Code] IS NOT NULL AND [Status] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LocationFireHydrants_AreaId_Code_Status",
                table: "LocationFireHydrants",
                columns: new[] { "AreaId", "Code", "Status" },
                unique: true,
                filter: "[Code] IS NOT NULL AND [Status] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LocationInergenTanks_AreaId",
                table: "LocationInergenTanks",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentId",
                table: "Users",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username_Status",
                table: "Users",
                columns: new[] { "Username", "Status" },
                unique: true,
                filter: "[Username] IS NOT NULL AND [Status] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BicycleEntryDetails");

            migrationBuilder.DropTable(
                name: "EmergencyLightDetails");

            migrationBuilder.DropTable(
                name: "FireExtinguisherDetails");

            migrationBuilder.DropTable(
                name: "FireHydrantDetails");

            migrationBuilder.DropTable(
                name: "InergenTankDetails");

            migrationBuilder.DropTable(
                name: "LocationEmergencyLights");

            migrationBuilder.DropTable(
                name: "LocationFireExtinguisherDetails");

            migrationBuilder.DropTable(
                name: "LocationFireExtinguishers");

            migrationBuilder.DropTable(
                name: "LocationFireHydrants");

            migrationBuilder.DropTable(
                name: "LocationInergenTanks");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "NoSeries");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BicycleEntryHeaders");

            migrationBuilder.DropTable(
                name: "EmergencyLightHeaders");

            migrationBuilder.DropTable(
                name: "FireExtinguisherHeaders");

            migrationBuilder.DropTable(
                name: "FireHydrantHeaders");

            migrationBuilder.DropTable(
                name: "InergenTankHeaders");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Bicycles");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
