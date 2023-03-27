using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EF_SQL.Models;

public partial class GeodataContext : DbContext
{
    public GeodataContext()
    {
    }

    public GeodataContext(DbContextOptions<GeodataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Parcel> Parcels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=geodata;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Parcel>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Other)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("other");
            entity.Property(e => e.Parcelid).HasColumnName("parcelid");
            entity.Property(e => e.Parcelname)
                .HasMaxLength(50)
                .HasColumnName("parcelname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
