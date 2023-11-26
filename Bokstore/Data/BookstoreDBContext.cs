using System;
using System.Collections.Generic;
using Bokstore.Models;
using Microsoft.EntityFrameworkCore;

namespace Bokstore.Data;

public partial class BookstoreDBContext : DbContext
{
    public BookstoreDBContext()
    {
    }

    public BookstoreDBContext(DbContextOptions<BookstoreDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Butiker> Butikers { get; set; }

    public virtual DbSet<Böcker> Böckers { get; set; }

    public virtual DbSet<Forfattare> Forfattares { get; set; }

    public virtual DbSet<Förlag> Förlags { get; set; }

    public virtual DbSet<Kunder> Kunders { get; set; }

    public virtual DbSet<LagerSaldo> LagerSaldos { get; set; }

    public virtual DbSet<LagerSaldoAvrgeNummer> LagerSaldoAvrgeNummers { get; set; }

    public virtual DbSet<Ordrar> Ordrars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Bokstore;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Butiker>(entity =>
        {
            entity.HasKey(e => e.ButikerId).HasName("PK__Butiker__F7FCE8F815DC62BC");

            entity.ToTable("Butiker");

            entity.Property(e => e.ButikerId).HasColumnName("ButikerID");
            entity.Property(e => e.Addressuppgifter).HasMaxLength(255);
            entity.Property(e => e.Butiksnamn).HasMaxLength(255);
        });

        modelBuilder.Entity<Böcker>(entity =>
        {
            entity.HasKey(e => e.Isbn).HasName("PK__böcker__447D36EB30717EC5");

            entity.ToTable("böcker");

            entity.Property(e => e.Isbn)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ISBN");
            entity.Property(e => e.Pris).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Sprak)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Titel)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Utgivningsdatum).HasColumnType("date");

            entity.HasOne(d => d.Forfattar).WithMany(p => p.Böckers)
                .HasForeignKey(d => d.ForfattarId)
                .HasConstraintName("FK__böcker__Forfatta__267ABA7A");
        });

        modelBuilder.Entity<Forfattare>(entity =>
        {
            entity.HasKey(e => e.ForfattareId).HasName("PK__forfatta__4F4417530992C80D");

            entity.ToTable("forfattare");

            entity.Property(e => e.ForfattareId).HasColumnName("ForfattareID");
            entity.Property(e => e.Efternamn).HasMaxLength(255);
            entity.Property(e => e.Fodelsedatum).HasColumnType("date");
            entity.Property(e => e.Fornamn).HasMaxLength(255);
        });

        modelBuilder.Entity<Förlag>(entity =>
        {
            entity.HasKey(e => e.FörlagId).HasName("PK__Förlag__DE6A852C402575D4");

            entity.ToTable("Förlag");

            entity.Property(e => e.FörlagId).HasColumnName("FörlagID");
            entity.Property(e => e.Adess).HasMaxLength(255);
            entity.Property(e => e.Namn).HasMaxLength(255);
        });

        modelBuilder.Entity<Kunder>(entity =>
        {
            entity.HasKey(e => e.KundId).HasName("PK__Kunder__F2B5DEACEF720D21");

            entity.ToTable("Kunder");

            entity.Property(e => e.KundId).HasColumnName("KundID");
            entity.Property(e => e.Efternamn).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Fornamn).HasMaxLength(255);
        });

        modelBuilder.Entity<LagerSaldo>(entity =>
        {
            entity.HasKey(e => e.LagerSaldoID).HasName("PK__LagerSal__188D2699F01F58A5");

            entity.ToTable("LagerSaldo");

            entity.Property(e => e.LagerSaldoID).HasColumnName("LagerSaldoID");
            entity.Property(e => e.ButikId).HasColumnName("ButikID");
            entity.Property(e => e.Isbn)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ISBN");

            entity.HasOne(d => d.Butik).WithMany(p => p.LagerSaldos)
                .HasForeignKey(d => d.ButikId)
                .HasConstraintName("FK__LagerSald__Butik__37A5467C");

            entity.HasOne(d => d.IsbnNavigation).WithMany(p => p.LagerSaldos)
                .HasForeignKey(d => d.Isbn)
                .HasConstraintName("FK__LagerSaldo__ISBN__38996AB5");
        });

        modelBuilder.Entity<LagerSaldoAvrgeNummer>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("LagerSaldo avrge nummer");

            entity.Property(e => e.Isbn)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ISBN");
        });

        modelBuilder.Entity<Ordrar>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Ordrar__C3905BAF6E79D69E");

            entity.ToTable("Ordrar");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Isbn)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ISBN");

            entity.HasOne(d => d.IsbnNavigation).WithMany(p => p.Ordrars)
                .HasForeignKey(d => d.Isbn)
                .HasConstraintName("FK__Ordrar__ISBN__403A8C7D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
