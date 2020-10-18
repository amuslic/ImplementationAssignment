﻿// <auto-generated />
using System;
using ImplementationAssignment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ImplementationAssignment.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201016075519_changeStringToIntInDaysInAWeek")]
    partial class changeStringToIntInDaysInAWeek
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0-rc.2.20475.6");

            modelBuilder.Entity("ImplementationAssignment.Models.DaysInAWeek", b =>
                {
                    b.Property<int>("DayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DayName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DayId");

                    b.ToTable("daysInAWeek");
                });

            modelBuilder.Entity("ImplementationAssignment.Models.NumOfSoldItemsPerDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DayId")
                        .HasColumnType("int");

                    b.Property<int>("NumOfItemsSold")
                        .HasColumnType("int");

                    b.Property<Guid>("SaleDataId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("numOfSoldItemsPerDay");
                });

            modelBuilder.Entity("ImplementationAssignment.Models.SaleData", b =>
                {
                    b.Property<Guid>("SaleDataId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ArticleNumber")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<double>("SalesPrice")
                        .HasColumnType("float");

                    b.HasKey("SaleDataId");

                    b.ToTable("saleDatas");
                });
#pragma warning restore 612, 618
        }
    }
}
