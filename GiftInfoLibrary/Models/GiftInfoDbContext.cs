using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GiftInfoLibrary.Models;

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

    public virtual DbSet<UserFavoriteGift> UserFavoriteGifts { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GiftInfoDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GiftInfo>(entity =>
        {
            entity.HasKey(e => e.GiftId).HasName("PK__GiftInfo__4A40E605C6837DFC");

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

        modelBuilder.Entity<UserFavoriteGift>(entity =>
        {
            entity.HasKey(e => e.UserFavoriteGiftId).HasName("PK__UserFavo__07A538A813C41098");

            entity.ToTable("UserFavoriteGift");

            entity.HasOne(d => d.Gift).WithMany(p => p.UserFavoriteGifts)
                .HasForeignKey(d => d.GiftId)
                .HasConstraintName("FK__UserFavor__GiftI__29572725");

            entity.HasOne(d => d.User).WithMany(p => p.UserFavoriteGifts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserFavor__UserI__286302EC");
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserInfo__1788CC4C50E4D1CA");

            entity.ToTable("UserInfo");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.UserName).HasMaxLength(100);
            entity.Property(e => e.UserPass).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
