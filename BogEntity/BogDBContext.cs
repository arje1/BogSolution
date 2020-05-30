using System;
using System.Collections.Generic;
using System.Linq;
using BogEntity.Entities.StoredProcedureEntities;
using BogEntity.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BogEntity.Entities
{
    public partial class BogDBContext : DbContext
    {
        public BogDBContext()
        {
        }

        public BogDBContext(DbContextOptions<BogDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Consultant> Consultant { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductSale> ProductSale { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consultant>(entity =>
            {
                entity.ToTable("Consultant", "Sales");

                entity.HasIndex(e => e.Id)
                    .HasName("IX_Unique_Consultant_Code")
                    .IsUnique();

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PrivateNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Recommendator)
                    .WithMany(p => p.InverseRecommendator)
                    .HasForeignKey(d => d.RecommendatorId)
                    .HasConstraintName("FK_Consultant_Consultant");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product", "Sales");

                entity.HasIndex(e => e.Code)
                    .HasName("IX_Unique_Product_Code")
                    .IsUnique();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ProductSale>(entity =>
            {
                entity.ToTable("ProductSale", "Sales");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductSale)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductSale_Product");

                entity.HasOne(d => d.Sale)
                    .WithMany(p => p.ProductSale)
                    .HasForeignKey(d => d.SaleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductSale_Sale");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("Sale", "Sales");

                entity.HasIndex(e => e.Code)
                    .HasName("IX_Unique_Sale_Code")
                    .IsUnique();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OperationDate).HasColumnType("datetime");

                entity.HasOne(d => d.Consultant)
                    .WithMany(p => p.Sale)
                    .HasForeignKey(d => d.ConsultantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sale_Consultant");
            });


            modelBuilder.Entity<spGetSales_BasedOnConsultants>().HasNoKey().ToView(null);
            modelBuilder.Entity<spGetSales_BasedOnProductPriceRange>().HasNoKey().ToView(null).ToView(null);
            modelBuilder.Entity<spGetSales_BasedOnFrequentProductsByConsultants>().HasNoKey().ToView(null);
            modelBuilder.Entity<spGetSales_BasedOnSalesSumByConsultants>().HasNoKey().ToView(null);
            modelBuilder.Entity<spGetSales_BasedOnFrequentAndProfitableProductsByConsultants>().HasNoKey().ToView(null);

        }



    }
}
