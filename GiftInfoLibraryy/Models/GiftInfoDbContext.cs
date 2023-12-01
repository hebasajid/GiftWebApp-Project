using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GiftInfoLibraryy.Models;

public partial class GiftInfoDbContext : DbContext
{
    public GiftInfoDbContext()
    {
    }

    public GiftInfoDbContext(DbContextOptions<GiftInfoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GiftInfo> GiftInfos { get; set; }

    public virtual DbSet<ParentGift> ParentGifts { get; set; }

    public virtual DbSet<UserFavoriteGift> UserFavoriteGifts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=giftapi-sql.ci56eydvwqo6.ca-central-1.rds.amazonaws.com,1433;database=GiftInfoDB;TrustServerCertificate=True;User ID=Heba; Password=password123;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GiftInfo>(entity =>
        {
            entity.HasKey(e => e.GiftId).HasName("PK__GiftInfo__4A40E6057508383F");

            entity.ToTable("GiftInfo");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.GiftCategory).HasMaxLength(100);
            entity.Property(e => e.GiftGender).HasMaxLength(100);
            entity.Property(e => e.GiftName).HasMaxLength(255);
            entity.Property(e => e.GiftPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.GiftUrl)
                .HasMaxLength(600)
                .HasColumnName("GiftURL");
        });

        modelBuilder.Entity<ParentGift>(entity =>
        {
            entity.HasKey(e => e.PGiftId).HasName("PK__ParentGi__5734085B62D28A55");

            entity.Property(e => e.PGiftId).HasColumnName("PGiftId");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.GiftCategory).HasMaxLength(100);
            entity.Property(e => e.GiftName).HasMaxLength(255);
            entity.Property(e => e.GiftPrice).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<UserFavoriteGift>(entity =>
        {
            entity.HasKey(e => e.UserFavoriteGiftId).HasName("PK__UserFavo__07A538A86CD90900");

            entity.ToTable("UserFavoriteGift");

            entity.Property(e => e.PGiftId).HasColumnName("PGiftId");

            entity.HasOne(d => d.Gift).WithMany(p => p.UserFavoriteGifts)
                .HasForeignKey(d => d.GiftId)
                .HasConstraintName("FK__UserFavor__GiftI__3F466844");

            entity.HasOne(d => d.PGift).WithMany(p => p.UserFavoriteGifts)
                .HasForeignKey(d => d.PGiftId)
                .HasConstraintName("FK__UserFavor__PGift__3E52440B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
