using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

namespace testBlazor.Data;

public partial class HousingAndUtilitiesAppContext : DbContext
{
    public HousingAndUtilitiesAppContext()
    {
    }

    public HousingAndUtilitiesAppContext(DbContextOptions<HousingAndUtilitiesAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientAddress> ClientAddresses { get; set; }

    public virtual DbSet<MeterReading> MeterReadings { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseNpgsql("Host=localhost;Database=housing_and_utilities_app;Username=postgres;Password=12345");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("app_shema", "uuid-ossp");

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("client_pkey");

            entity.ToTable("client", "app_shema");

            entity.HasIndex(e => e.Email, "email_unique").IsUnique();

            entity.Property(e => e.ClientId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("client_id");
            entity.Property(e => e.ClientAddressId).HasColumnName("client_address_id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.OtpRequestedTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("otp_requested_time");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Patronymic).HasColumnName("patronymic");
            entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");
            entity.Property(e => e.Surname).HasColumnName("surname");
        });

        modelBuilder.Entity<ClientAddress>(entity =>
        {
            entity.HasKey(e => e.ClientAddressId).HasName("client_address_pkey");

            entity.ToTable("client_address", "app_shema");

            entity.HasIndex(e => e.ClientId, "fki_client_id");

            entity.Property(e => e.ClientAddressId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("client_address_id");
            entity.Property(e => e.Apartment).HasColumnName("apartment");
            entity.Property(e => e.Building).HasColumnName("building");
            entity.Property(e => e.City).HasColumnName("city");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.House).HasColumnName("house");
            entity.Property(e => e.Street).HasColumnName("street");

            entity.HasOne(d => d.Client).WithMany(p => p.ClientAddresses)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("client_id");
        });

        modelBuilder.Entity<MeterReading>(entity =>
        {
            entity.HasKey(e => e.MeterReadingsId).HasName("meter_readings_pkey");

            entity.ToTable("meter_readings", "app_shema");

            entity.Property(e => e.MeterReadingsId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("meter_readings_id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.Name);
            entity.HasOne(d => d.Client).WithMany(p => p.MeterReadings)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("client_id");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("request_pkey");

            entity.ToTable("request", "app_shema");

            entity.Property(e => e.RequestId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("request_id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.Date).
            HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.RequestNumber)
                .HasDefaultValueSql("nextval('app_shema.\"REQUEST_REQUEST_ID_seq\"'::regclass)")
                .HasColumnName("request_number");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Client).WithMany(p => p.Requests)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("client_id");
        });
        modelBuilder.HasSequence("CLIENT_CLIENT_ID_seq", "app_shema");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
