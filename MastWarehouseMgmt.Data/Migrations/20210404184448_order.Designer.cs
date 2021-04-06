﻿// <auto-generated />
using System;
using MastWarehouseMgmt.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MastWarehouseMgmt.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210404184448_order")]
    partial class order
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MastWarehouseMgmt.Data.Entities.Material", b =>
                {
                    b.Property<int>("MaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("MaterialId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("MastWarehouseMgmt.Data.Entities.MaterialHistory", b =>
                {
                    b.Property<int>("MaterialHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("MaterialHistoryId");

                    b.HasIndex("MaterialId");

                    b.ToTable("MaterialHistories");
                });

            modelBuilder.Entity("MastWarehouseMgmt.Data.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Customer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MastWarehouseMgmt.Data.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MastWarehouseMgmt.Data.Entities.ProductionHistory", b =>
                {
                    b.Property<int>("ProductionHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Acronal")
                        .HasColumnType("float");

                    b.Property<double>("C3")
                        .HasColumnType("float");

                    b.Property<double>("CR400")
                        .HasColumnType("float");

                    b.Property<double>("Cement")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Glue")
                        .HasColumnType("float");

                    b.Property<double>("Gypsum")
                        .HasColumnType("float");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<double>("Lithium")
                        .HasColumnType("float");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("Sand")
                        .HasColumnType("float");

                    b.Property<double>("Soda")
                        .HasColumnType("float");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductionHistoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductionHistories");
                });

            modelBuilder.Entity("MastWarehouseMgmt.Data.Entities.SaleHistory", b =>
                {
                    b.Property<int>("SaleHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Customer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("SaleHistoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("SaleHistories");
                });

            modelBuilder.Entity("MastWarehouseMgmt.Data.Entities.MaterialHistory", b =>
                {
                    b.HasOne("MastWarehouseMgmt.Data.Entities.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");
                });

            modelBuilder.Entity("MastWarehouseMgmt.Data.Entities.Order", b =>
                {
                    b.HasOne("MastWarehouseMgmt.Data.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MastWarehouseMgmt.Data.Entities.ProductionHistory", b =>
                {
                    b.HasOne("MastWarehouseMgmt.Data.Entities.Product", "Product")
                        .WithMany("ProductionHistories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MastWarehouseMgmt.Data.Entities.SaleHistory", b =>
                {
                    b.HasOne("MastWarehouseMgmt.Data.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MastWarehouseMgmt.Data.Entities.Product", b =>
                {
                    b.Navigation("ProductionHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
