﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SEMSystem.Models;

namespace SEMSystem.Migrations
{
    [DbContext(typeof(SEMSystemContext))]
    [Migration("20210429075003_2")]
    partial class _2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SEMSystem.Models.Area", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("CompanyId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Status");

                    b.HasKey("ID");

                    b.HasIndex("CompanyId");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("SEMSystem.Models.Bicycle", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandName")
                        .IsRequired();

                    b.Property<string>("ContactNo");

                    b.Property<string>("IdentificationNo")
                        .IsRequired();

                    b.Property<string>("NameOwner")
                        .IsRequired();

                    b.Property<string>("Status");

                    b.HasKey("ID");

                    b.HasIndex("IdentificationNo", "Status")
                        .IsUnique()
                        .HasFilter("[Status] IS NOT NULL");

                    b.ToTable("Bicycles");
                });

            modelBuilder.Entity("SEMSystem.Models.BicycleEntryDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BicycleEntryHeaderId");

                    b.Property<string>("BrakeRemarks");

                    b.Property<int>("BrakeSafe");

                    b.Property<int>("BrakeUnSafe");

                    b.Property<string>("ChainRemarks");

                    b.Property<int>("ChainSafe");

                    b.Property<int>("ChainUnSafe");

                    b.Property<string>("CrankChainRemarks");

                    b.Property<int>("CrankChainSafe");

                    b.Property<int>("CrankChainUnSafe");

                    b.Property<string>("FrameRemarks");

                    b.Property<int>("FrameSafe");

                    b.Property<int>("FrameUnSafe");

                    b.Property<string>("FrontForkRemarks");

                    b.Property<int>("FrontForkSafe");

                    b.Property<int>("FrontForkUnSafe");

                    b.Property<string>("FrontRearRemarks");

                    b.Property<int>("FrontRearSafe");

                    b.Property<int>("FrontRearUnSafe");

                    b.Property<string>("HandlebarRemarks");

                    b.Property<int>("HandlebarSafe");

                    b.Property<int>("HandlebarUnSafe");

                    b.Property<string>("InspectedBy");

                    b.Property<string>("NotedBy");

                    b.Property<string>("SeatRemarks");

                    b.Property<int>("SeatSafe");

                    b.Property<int>("SeatUnSafe");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("BicycleEntryHeaderId");

                    b.ToTable("BicycleEntryDetails");
                });

            modelBuilder.Entity("SEMSystem.Models.BicycleEntryHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BicycleId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Status");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("BicycleId", "CreatedAt", "Status")
                        .IsUnique()
                        .HasFilter("[Status] IS NOT NULL");

                    b.ToTable("BicycleEntryHeaders");
                });

            modelBuilder.Entity("SEMSystem.Models.Company", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Status");

                    b.HasKey("ID");

                    b.ToTable("Companies");

                    b.HasData(
                        new { ID = 1, Code = "SLPGC", Name = "Southwest Luzon Power Gen Corporation", Status = "Active" },
                        new { ID = 2, Code = "SCPC", Name = "Sem-Calaca Power Corporation", Status = "Active" }
                    );
                });

            modelBuilder.Entity("SEMSystem.Models.Department", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("CompanyId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Status");

                    b.HasKey("ID");

                    b.HasIndex("CompanyId");

                    b.ToTable("Departments");

                    b.HasData(
                        new { ID = 1, Code = "NA", CompanyId = 1, Name = "NOTSET", Status = "Deleted" }
                    );
                });

            modelBuilder.Entity("SEMSystem.Models.EmergencyLightDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Battery");

                    b.Property<int>("Bulb");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("EmergencyLightHeaderId");

                    b.Property<string>("InspectedBy");

                    b.Property<int>("LocationEmergencyLightId");

                    b.Property<string>("NotedBy");

                    b.Property<string>("Remarks");

                    b.Property<string>("ReviewedBy");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.Property<int>("Usable");

                    b.HasKey("Id");

                    b.HasIndex("EmergencyLightHeaderId");

                    b.ToTable("EmergencyLightDetails");
                });

            modelBuilder.Entity("SEMSystem.Models.EmergencyLightHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AreaId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Status");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("AreaId", "CreatedAt", "Status")
                        .IsUnique()
                        .HasFilter("[Status] IS NOT NULL");

                    b.ToTable("EmergencyLightHeaders");
                });

            modelBuilder.Entity("SEMSystem.Models.FireExtinguisherDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("Cylinder");

                    b.Property<int>("FireExtinguisherHeaderId");

                    b.Property<int>("Gauge");

                    b.Property<int>("Hose");

                    b.Property<string>("InspectedBy");

                    b.Property<int>("Lever");

                    b.Property<int>("LocationFireExtinguisherId");

                    b.Property<string>("NotedBy");

                    b.Property<string>("Remarks");

                    b.Property<string>("ReviewedBy");

                    b.Property<int>("SafetySeal");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("FireExtinguisherHeaderId");

                    b.ToTable("FireExtinguisherDetails");
                });

            modelBuilder.Entity("SEMSystem.Models.FireExtinguisherHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AreaId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Status");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("AreaId", "CreatedAt", "Status")
                        .IsUnique()
                        .HasFilter("[Status] IS NOT NULL");

                    b.ToTable("FireExtinguisherHeaders");
                });

            modelBuilder.Entity("SEMSystem.Models.FireHydrantDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("FireHydrantHeaderId");

                    b.Property<int>("GlassCabinet");

                    b.Property<int>("Hanger");

                    b.Property<int>("Hose15");

                    b.Property<int>("Hose25");

                    b.Property<string>("InspectedBy");

                    b.Property<int>("LocationFireHydrantId");

                    b.Property<string>("NotedBy");

                    b.Property<int>("Nozzle15");

                    b.Property<int>("Nozzle25");

                    b.Property<string>("Remarks");

                    b.Property<string>("ReviewedBy");

                    b.Property<int>("SpecialTools");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("FireHydrantHeaderId");

                    b.ToTable("FireHydrantDetails");
                });

            modelBuilder.Entity("SEMSystem.Models.FireHydrantHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AreaId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Status");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.ToTable("FireHydrantHeaders");
                });

            modelBuilder.Entity("SEMSystem.Models.InergenTankDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("Cylinder");

                    b.Property<int>("Gauge");

                    b.Property<int>("Hose");

                    b.Property<int>("InergenTankHeaderId");

                    b.Property<string>("InspectedBy");

                    b.Property<int>("LocationInergenTankId");

                    b.Property<string>("NotedBy");

                    b.Property<int>("Pressure");

                    b.Property<string>("Remarks");

                    b.Property<string>("ReviewedBy");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("InergenTankHeaderId");

                    b.ToTable("InergenTankDetails");
                });

            modelBuilder.Entity("SEMSystem.Models.InergenTankHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AreaId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Status");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.ToTable("InergenTankHeaders");
                });

            modelBuilder.Entity("SEMSystem.Models.LocationEmergencyLight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AreaId");

                    b.Property<string>("Code");

                    b.Property<string>("Location");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("AreaId", "Code", "Status")
                        .IsUnique()
                        .HasFilter("[Code] IS NOT NULL AND [Status] IS NOT NULL");

                    b.ToTable("LocationEmergencyLights");
                });

            modelBuilder.Entity("SEMSystem.Models.LocationFireExtinguisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AreaId");

                    b.Property<string>("Capacity");

                    b.Property<string>("Code");

                    b.Property<string>("Location");

                    b.Property<string>("Status");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("AreaId", "Code", "Status")
                        .IsUnique()
                        .HasFilter("[Code] IS NOT NULL AND [Status] IS NOT NULL");

                    b.ToTable("LocationFireExtinguishers");
                });

            modelBuilder.Entity("SEMSystem.Models.LocationFireExtinguisherDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("DatePurchased");

                    b.Property<string>("ItemStatus");

                    b.Property<int?>("LocationFireExtinguisherDetailsId");

                    b.Property<int>("LocationFireExtinguisherId");

                    b.Property<string>("Status");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<int>("Warranty");

                    b.HasKey("Id");

                    b.HasIndex("LocationFireExtinguisherDetailsId");

                    b.ToTable("LocationFireExtinguisherDetails");
                });

            modelBuilder.Entity("SEMSystem.Models.LocationFireHydrant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AreaId");

                    b.Property<string>("Code");

                    b.Property<string>("Location");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("AreaId", "Code", "Status")
                        .IsUnique()
                        .HasFilter("[Code] IS NOT NULL AND [Status] IS NOT NULL");

                    b.ToTable("LocationFireHydrants");
                });

            modelBuilder.Entity("SEMSystem.Models.LocationInergenTank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Area");

                    b.Property<int>("AreaId");

                    b.Property<string>("Capacity");

                    b.Property<string>("Serial");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.ToTable("LocationInergenTanks");
                });

            modelBuilder.Entity("SEMSystem.Models.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Descriptions");

                    b.Property<string>("Status");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("SEMSystem.Models.NoSeries", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("LastNoUsed");

                    b.HasKey("Id");

                    b.ToTable("NoSeries");
                });

            modelBuilder.Entity("SEMSystem.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new { Id = 1, Name = "Admin", Status = "Active" },
                        new { Id = 2, Name = "User", Status = "Active" }
                    );
                });

            modelBuilder.Entity("SEMSystem.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyAccess");

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Domain");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<int>("RoleId");

                    b.Property<string>("Status");

                    b.Property<string>("UserType");

                    b.Property<string>("Username")
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("RoleId");

                    b.HasIndex("Username", "Status")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL AND [Status] IS NOT NULL");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = 1, CompanyAccess = "1", DepartmentId = 1, Domain = "SMCDACON", Email = "kcmalapit@semirarampc.com", FirstName = "Kristoffer", LastName = "Malapit", Name = "Kristoffer Malapit", Password = "", RoleId = 1, Status = "1", Username = "kcmalapit" }
                    );
                });

            modelBuilder.Entity("SEMSystem.Models.Area", b =>
                {
                    b.HasOne("SEMSystem.Models.Company", "Companies")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SEMSystem.Models.BicycleEntryDetail", b =>
                {
                    b.HasOne("SEMSystem.Models.BicycleEntryHeader", "BicycleHeaders")
                        .WithMany()
                        .HasForeignKey("BicycleEntryHeaderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SEMSystem.Models.BicycleEntryHeader", b =>
                {
                    b.HasOne("SEMSystem.Models.Bicycle", "Bicycles")
                        .WithMany()
                        .HasForeignKey("BicycleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SEMSystem.Models.Department", b =>
                {
                    b.HasOne("SEMSystem.Models.Company", "Companies")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SEMSystem.Models.EmergencyLightDetail", b =>
                {
                    b.HasOne("SEMSystem.Models.EmergencyLightHeader", "EmergencyLightHeaders")
                        .WithMany()
                        .HasForeignKey("EmergencyLightHeaderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SEMSystem.Models.EmergencyLightHeader", b =>
                {
                    b.HasOne("SEMSystem.Models.Area", "Areas")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SEMSystem.Models.FireExtinguisherDetail", b =>
                {
                    b.HasOne("SEMSystem.Models.FireExtinguisherHeader", "FireExtinguisherHeaders")
                        .WithMany()
                        .HasForeignKey("FireExtinguisherHeaderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SEMSystem.Models.FireExtinguisherHeader", b =>
                {
                    b.HasOne("SEMSystem.Models.Area", "Areas")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SEMSystem.Models.FireHydrantDetail", b =>
                {
                    b.HasOne("SEMSystem.Models.FireHydrantHeader", "FireHydrantHeaders")
                        .WithMany()
                        .HasForeignKey("FireHydrantHeaderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SEMSystem.Models.FireHydrantHeader", b =>
                {
                    b.HasOne("SEMSystem.Models.Area", "Areas")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SEMSystem.Models.InergenTankDetail", b =>
                {
                    b.HasOne("SEMSystem.Models.InergenTankHeader", "InergenTankHeaders")
                        .WithMany()
                        .HasForeignKey("InergenTankHeaderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SEMSystem.Models.InergenTankHeader", b =>
                {
                    b.HasOne("SEMSystem.Models.Area", "Areas")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SEMSystem.Models.LocationEmergencyLight", b =>
                {
                    b.HasOne("SEMSystem.Models.Area", "Areas")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SEMSystem.Models.LocationFireExtinguisher", b =>
                {
                    b.HasOne("SEMSystem.Models.Area", "Areas")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SEMSystem.Models.LocationFireExtinguisherDetail", b =>
                {
                    b.HasOne("SEMSystem.Models.LocationFireExtinguisherDetail", "LocationFireExtinguisherDetails")
                        .WithMany()
                        .HasForeignKey("LocationFireExtinguisherDetailsId");
                });

            modelBuilder.Entity("SEMSystem.Models.LocationFireHydrant", b =>
                {
                    b.HasOne("SEMSystem.Models.Area", "Areas")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SEMSystem.Models.LocationInergenTank", b =>
                {
                    b.HasOne("SEMSystem.Models.Area", "Areas")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SEMSystem.Models.User", b =>
                {
                    b.HasOne("SEMSystem.Models.Department", "Departments")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SEMSystem.Models.Role", "Roles")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
