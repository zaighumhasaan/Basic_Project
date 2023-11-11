using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Basic_Project.Models;

public partial class InventoryManagementContext : DbContext
{
    public InventoryManagementContext()
    {
    }

    public InventoryManagementContext(DbContextOptions<InventoryManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-ID1N12D\\SQLEXPRESS;Database=Inventory_Management;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3213E83F4B511891");

            entity.ToTable("Product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ExpDate)
                .HasColumnType("date")
                .HasColumnName("exp_date");
            entity.Property(e => e.MfgDate)
                .HasColumnType("date")
                .HasColumnName("mfg_date");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("product_name");
            entity.Property(e => e.ProductQnty).HasColumnName("product_qnty");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Purchase__3213E83F05C3CDAB");

            entity.ToTable("Purchase");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductExpDate)
                .HasColumnType("date")
                .HasColumnName("product_exp_date");
            entity.Property(e => e.ProductMdfDate)
                .HasColumnType("date")
                .HasColumnName("product_mdf_date");
            entity.Property(e => e.PurchaseDate)
                .HasColumnType("date")
                .HasColumnName("purchase_date");
            entity.Property(e => e.PurchaseProduct)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("purchase_product");
            entity.Property(e => e.PurchaseQnty).HasColumnName("purchase_qnty");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sale__3213E83F3C885FE1");

            entity.ToTable("Sale");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.SaleDate)
                .HasColumnType("date")
                .HasColumnName("sale_date");
            entity.Property(e => e.SaleProduct)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sale_product");
            entity.Property(e => e.SaleQnty).HasColumnName("sale_qnty");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
