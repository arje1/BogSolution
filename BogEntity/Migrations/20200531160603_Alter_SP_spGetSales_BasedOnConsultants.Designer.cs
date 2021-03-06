﻿// <auto-generated />
using System;
using BogEntity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BogEntity.Migrations
{
    [DbContext(typeof(BogDBContext))]
    [Migration("20200531160603_Alter_SP_spGetSales_BasedOnConsultants")]
    partial class Alter_SP_spGetSales_BasedOnConsultants
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BogEntity.Entities.Consultant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PrivateNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("RecommendatorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasName("IX_Unique_Consultant_Code");

                    b.HasIndex("RecommendatorId");

                    b.ToTable("Consultant","Sales");
                });

            modelBuilder.Entity("BogEntity.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasName("IX_Unique_Product_Code");

                    b.ToTable("Product","Sales");
                });

            modelBuilder.Entity("BogEntity.Entities.ProductSale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("PricePerUnit")
                        .HasColumnType("float");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductUnit")
                        .HasColumnType("int");

                    b.Property<int>("SaleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SaleId");

                    b.ToTable("ProductSale","Sales");
                });

            modelBuilder.Entity("BogEntity.Entities.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("ConsultantId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OperationDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasName("IX_Unique_Sale_Code");

                    b.HasIndex("ConsultantId");

                    b.ToTable("Sale","Sales");
                });

            modelBuilder.Entity("BogEntity.Entities.Consultant", b =>
                {
                    b.HasOne("BogEntity.Entities.Consultant", "Recommendator")
                        .WithMany("InverseRecommendator")
                        .HasForeignKey("RecommendatorId")
                        .HasConstraintName("FK_Consultant_Consultant");
                });

            modelBuilder.Entity("BogEntity.Entities.ProductSale", b =>
                {
                    b.HasOne("BogEntity.Entities.Product", "Product")
                        .WithMany("ProductSale")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_ProductSale_Product")
                        .IsRequired();

                    b.HasOne("BogEntity.Entities.Sale", "Sale")
                        .WithMany("ProductSale")
                        .HasForeignKey("SaleId")
                        .HasConstraintName("FK_ProductSale_Sale")
                        .IsRequired();
                });

            modelBuilder.Entity("BogEntity.Entities.Sale", b =>
                {
                    b.HasOne("BogEntity.Entities.Consultant", "Consultant")
                        .WithMany("Sale")
                        .HasForeignKey("ConsultantId")
                        .HasConstraintName("FK_Sale_Consultant")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
