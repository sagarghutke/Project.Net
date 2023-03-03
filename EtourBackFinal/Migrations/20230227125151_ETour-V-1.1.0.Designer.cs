﻿// <auto-generated />
using System;
using EtourBackFinal.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EtourBackFinal.Migrations
{
    [DbContext(typeof(ETourContext))]
    [Migration("20230227125151_ETour-V-1.1.0")]
    partial class ETourV110
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EtourBackFinal.Model.Booking_Header", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"));

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("DepartureId")
                        .HasColumnType("int");

                    b.Property<int?>("MasterId")
                        .HasColumnType("int");

                    b.Property<int>("NoOfPassenger")
                        .HasColumnType("int");

                    b.Property<double>("Taxes")
                        .HasColumnType("float");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("float");

                    b.Property<double>("TourAmount")
                        .HasColumnType("float");

                    b.HasKey("BookingId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DepartureId");

                    b.HasIndex("MasterId");

                    b.ToTable("BookingHeader");
                });

            modelBuilder.Entity("EtourBackFinal.Model.Category_Master", b =>
                {
                    b.Property<int>("MasterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MasterId"));

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("CategoryImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("SubCategoryId")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<bool>("ToNewTab")
                        .HasColumnType("bit");

                    b.HasKey("MasterId");

                    b.ToTable("CategoryMaster");
                });

            modelBuilder.Entity("EtourBackFinal.Model.Cost_Master", b =>
                {
                    b.Property<int>("CostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CostId"));

                    b.Property<double>("ChildWithBed")
                        .HasColumnType("float");

                    b.Property<double>("ChildWithoutBed")
                        .HasColumnType("float");

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<double>("ExtraPersonCost")
                        .HasColumnType("float");

                    b.Property<int?>("MasterId")
                        .HasColumnType("int");

                    b.Property<double>("SinglePersonCost")
                        .HasColumnType("float");

                    b.Property<DateTime>("ValidFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ValidTo")
                        .HasColumnType("datetime2");

                    b.HasKey("CostId");

                    b.HasIndex("MasterId");

                    b.ToTable("CostMaster");
                });

            modelBuilder.Entity("EtourBackFinal.Model.Customer_Master", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("CountryCode")
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("IdVerificationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("CustomerId");

                    b.ToTable("CustomerMaster");
                });

            modelBuilder.Entity("EtourBackFinal.Model.Date_Master", b =>
                {
                    b.Property<int>("DepartureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartureId"));

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MasterId")
                        .HasColumnType("int");

                    b.Property<int>("NoOfDays")
                        .HasColumnType("int");

                    b.HasKey("DepartureId");

                    b.HasIndex("MasterId");

                    b.ToTable("DateMaster");
                });

            modelBuilder.Entity("EtourBackFinal.Model.Itnerary_Master", b =>
                {
                    b.Property<int>("ItneraryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItneraryId"));

                    b.Property<string>("Itnerarydetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MasterId")
                        .HasColumnType("int");

                    b.Property<int>("TourDuration")
                        .HasColumnType("int");

                    b.HasKey("ItneraryId");

                    b.HasIndex("MasterId");

                    b.ToTable("ItneraryMaster");
                });

            modelBuilder.Entity("EtourBackFinal.Model.Package_Master", b =>
                {
                    b.Property<int>("PackageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PackageId"));

                    b.Property<int?>("MasterId")
                        .HasColumnType("int");

                    b.Property<string>("PackageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PackageId");

                    b.HasIndex("MasterId");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("EtourBackFinal.Model.Passenger_Master", b =>
                {
                    b.Property<int>("PassengerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PassengerId"));

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DepartueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("PassengerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassengerType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PassengerId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("EtourBackFinal.Model.Booking_Header", b =>
                {
                    b.HasOne("EtourBackFinal.Model.Customer_Master", "CustomerMaster")
                        .WithMany("BookingHeaders")
                        .HasForeignKey("CustomerId");

                    b.HasOne("EtourBackFinal.Model.Date_Master", "DateMaster")
                        .WithMany("BookingHeaders")
                        .HasForeignKey("DepartureId");

                    b.HasOne("EtourBackFinal.Model.Category_Master", "CategoryMaster")
                        .WithMany("Bookings")
                        .HasForeignKey("MasterId");

                    b.Navigation("CategoryMaster");

                    b.Navigation("CustomerMaster");

                    b.Navigation("DateMaster");
                });

            modelBuilder.Entity("EtourBackFinal.Model.Cost_Master", b =>
                {
                    b.HasOne("EtourBackFinal.Model.Category_Master", "Category_Master")
                        .WithMany("Costs")
                        .HasForeignKey("MasterId");

                    b.Navigation("Category_Master");
                });

            modelBuilder.Entity("EtourBackFinal.Model.Date_Master", b =>
                {
                    b.HasOne("EtourBackFinal.Model.Category_Master", "CategoryMaster")
                        .WithMany("Dates")
                        .HasForeignKey("MasterId");

                    b.Navigation("CategoryMaster");
                });

            modelBuilder.Entity("EtourBackFinal.Model.Itnerary_Master", b =>
                {
                    b.HasOne("EtourBackFinal.Model.Category_Master", "CategoryMaster")
                        .WithMany("Itneraries")
                        .HasForeignKey("MasterId");

                    b.Navigation("CategoryMaster");
                });

            modelBuilder.Entity("EtourBackFinal.Model.Package_Master", b =>
                {
                    b.HasOne("EtourBackFinal.Model.Category_Master", "CategoryMaster")
                        .WithMany("Packages")
                        .HasForeignKey("MasterId");

                    b.Navigation("CategoryMaster");
                });

            modelBuilder.Entity("EtourBackFinal.Model.Passenger_Master", b =>
                {
                    b.HasOne("EtourBackFinal.Model.Customer_Master", "Customer")
                        .WithMany("Passengers")
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("EtourBackFinal.Model.Category_Master", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Costs");

                    b.Navigation("Dates");

                    b.Navigation("Itneraries");

                    b.Navigation("Packages");
                });

            modelBuilder.Entity("EtourBackFinal.Model.Customer_Master", b =>
                {
                    b.Navigation("BookingHeaders");

                    b.Navigation("Passengers");
                });

            modelBuilder.Entity("EtourBackFinal.Model.Date_Master", b =>
                {
                    b.Navigation("BookingHeaders");
                });
#pragma warning restore 612, 618
        }
    }
}
