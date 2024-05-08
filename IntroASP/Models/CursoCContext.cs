using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IntroASP.Models;

public partial class CursoCContext : DbContext
{
    public CursoCContext()
    {
    }

    public CursoCContext(DbContextOptions<CursoCContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Beer> Beers { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-B2MIOQ0\\SQLEXPRESS; Database=CursoC#; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Beer>(entity =>
        {
            entity.HasKey(e => e.idBeer).HasName("PK__Beer__D3DAA56AC59B9383");

            entity.ToTable("Beer");

            entity.Property(e => e.idBeer).HasColumnName("idBeer");
            entity.Property(e => e.idBrand).HasColumnName("idBrand");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.IdBrandNavigation).WithMany(p => p.Beers)
                .HasForeignKey(d => d.idBeer)
                .HasConstraintName("FK__Beer__idBrand__398D8EEE");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.idBrand).HasName("PK__Brand__E353A48E1DD6A864");

            entity.ToTable("Brand");

            entity.Property(e => e.idBrand).HasColumnName("idBrand");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
