using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API.core.DbModels;

public partial class Db1Context : DbContext
{
    public Db1Context()
    {
    }

    public Db1Context(DbContextOptions<Db1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<MaterialMaster> MaterialMasters { get; set; }

    public virtual DbSet<PritemDetail> PritemDetails { get; set; }

    public virtual DbSet<PurchaseRequest> PurchaseRequests { get; set; }

    public virtual DbSet<PurchaseType> PurchaseTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=db1;Integrated Security=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MaterialMaster>(entity =>
        {
            entity.HasKey(e => e.MatId).HasName("PK__material__FCB3E52775C16220");

            entity.ToTable("material_master");

            entity.Property(e => e.MatId).HasColumnName("mat_id");
            entity.Property(e => e.MatDesc)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("mat_desc");
            entity.Property(e => e.MatPoText)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("mat_Po_Text");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
        });

        modelBuilder.Entity<PritemDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PRItem_D__3213E83F90F434BA");

            entity.ToTable("PRItem_Details");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AvailableQuantity).HasColumnName("available_quantity");
            entity.Property(e => e.CurrentStatus)
                .HasMaxLength(255)
                .HasColumnName("current_status");
            entity.Property(e => e.DeliveryDate)
                .HasColumnType("datetime")
                .HasColumnName("delivery_date");
            entity.Property(e => e.MatId).HasColumnName("mat_id");
            entity.Property(e => e.PrId).HasColumnName("pr_id");

            entity.HasOne(d => d.MatCodeNavigation).WithMany(p => p.PritemDetails)
                .HasForeignKey(d => d.MatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PRItem_De__mat_i__36B12243");

            entity.HasOne(d => d.Pr).WithMany(p => p.PritemDetails)
                .HasForeignKey(d => d.PrId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PRItem_De__pr_id__35BCFE0A");
        });

        modelBuilder.Entity<PurchaseRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__purchase__3213E83F97F7A472");

            entity.ToTable("purchase_request");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Company)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("company");
            entity.Property(e => e.Currency).HasColumnName("currency");
            entity.Property(e => e.PrComsumed)
                .HasMaxLength(255)
                .HasColumnName("pr_comsumed");
            entity.Property(e => e.Prtype).HasColumnName("prtype");
            entity.Property(e => e.RefNum).HasColumnName("ref_num");
            entity.Property(e => e.Remarks)
                .HasMaxLength(255)
                .HasColumnName("remarks");

            entity.HasOne(d => d.PrtypeNavigation).WithMany(p => p.PurchaseRequests)
                .HasForeignKey(d => d.Prtype)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__purchase___prtyp__32E0915F");
        });

        modelBuilder.Entity<PurchaseType>(entity =>
        {
            entity.HasKey(e => e.PrtypeId).HasName("PK__purchase__092C2311E330E28D");

            entity.ToTable("purchase_type");

            entity.Property(e => e.PrtypeId)
                .ValueGeneratedNever()
                .HasColumnName("prtype_id");
            entity.Property(e => e.TypeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
