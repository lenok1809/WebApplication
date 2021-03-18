﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApplication1
{
    public partial class TourAgencyContext : DbContext
    {
        public TourAgencyContext()
        {
        }

        public TourAgencyContext(DbContextOptions<TourAgencyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }
        public virtual DbSet<Tourist> Tourists { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= LENANB; Database=TourAgency; Trusted_Connection=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.Id).HasColumnName("Id");
                //entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_City_Country");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.CountryName).HasColumnType("ntext");

                entity.Property(e => e.InfoVisa).HasColumnType("ntext");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.ToTable("Hotel");

                entity.Property(e => e.Id).HasColumnName("Id");

                //entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.HotelName).HasColumnType("ntext");

                entity.Property(e => e.RoomType).HasColumnType("ntext");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Hotels)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Hotel_City");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.ToTable("Manager");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasColumnType("ntext");

                entity.Property(e => e.FirstName).HasColumnType("ntext");

                entity.Property(e => e.LastName).HasColumnType("ntext");

                entity.Property(e => e.SurName).HasColumnType("ntext");
            });

            modelBuilder.Entity<Tour>(entity =>
            {
                entity.ToTable("Tour");

                entity.Property(e => e.Id).HasColumnName("Id");

                //entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.TourName).HasColumnType("ntext");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Tours)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK_Tour_Hotel1");

                entity.HasOne(d => d.Maneger)
                    .WithMany(p => p.Tours)
                    .HasForeignKey(d => d.ManegerId)
                    .HasConstraintName("FK_Tour_Manager");
            });

            modelBuilder.Entity<Tourist>(entity =>
            {
                entity.ToTable("Tourist");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasColumnType("ntext");

                entity.Property(e => e.BirthDay).HasColumnType("date");

                entity.Property(e => e.FirstName).HasColumnType("ntext");

                entity.Property(e => e.LastName).HasColumnType("ntext");

                entity.Property(e => e.SurName).HasColumnType("ntext");
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.ToTable("Voucher");

                entity.Property(e => e.Id).HasColumnName("Id");

                //entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BuyDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.Vouchers)
                    .HasForeignKey(d => d.TourId)
                    .HasConstraintName("FK_Voucher_Tour");

                entity.HasOne(d => d.Tourist)
                    .WithMany(p => p.Vouchers)
                    .HasForeignKey(d => d.TouristId)
                    .HasConstraintName("FK_Voucher_Tourist");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
