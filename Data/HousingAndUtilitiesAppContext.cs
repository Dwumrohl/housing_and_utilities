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


    public virtual DbSet<ClientMeterReading> ClientMeterReadings { get; set; }

    public virtual DbSet<HaClient> HaClients { get; set; }

    public virtual DbSet<HomeownersAssociation> HomeownersAssociations { get; set; }

    public virtual DbSet<MeterReading> MeterReadings { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<RequestClient> RequestClients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("client_pkey");

            entity.ToTable("client", "app_shema");

            entity.Property(e => e.ClientId)
                .HasDefaultValueSql("nextval('app_shema.\"CLIENT_CLIENT_ID_seq\"'::regclass)")
                .HasColumnName("client_id");
            entity.Property(e => e.ClientAddressId).HasColumnName("client_address_id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.OtpRequestedTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("otp_requested_time");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Patronymic).HasColumnName("patronymic");
            entity.Property(e => e.PhoneNumber)
                .HasColumnType("char")
                .HasColumnName("phone_number");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.Surname).HasColumnName("surname");
        });

        modelBuilder.Entity<ClientAddress>(entity =>
        {
            entity.HasKey(e => e.ClientAddressId).HasName("client_address_pkey");

            entity.ToTable("client_address", "app_shema");

            entity.Property(e => e.ClientAddressId)
                .HasDefaultValueSql("nextval('app_shema.\"CLIENT_ADRESS_CLIENT_ADRESS_ID_seq\"'::regclass)")
                .HasColumnName("client_address_id");
            entity.Property(e => e.Apartment).HasColumnName("apartment");
            entity.Property(e => e.Building).HasColumnName("building");
            entity.Property(e => e.City)
                .HasColumnType("string")
                .HasColumnName("city");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.House)
                .HasColumnType("string")
                .HasColumnName("house");
            entity.Property(e => e.Street)
                .HasColumnType("string")
                .HasColumnName("street");

            entity.HasOne(d => d.Client).WithMany(p => p.ClientAddresses)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("client_id");
        });

        modelBuilder.Entity<ClientMeterReading>(entity =>
        {
            entity.HasKey(e => e.ClientMeterReadingsId).HasName("client_meter_readings_pkey");

            entity.ToTable("client_meter_readings", "app_shema");

            entity.Property(e => e.ClientMeterReadingsId)
                .HasDefaultValueSql("nextval('app_shema.\"CLIENT_METER_READINGS_CLIENT_METER_READINGS_ID_seq\"'::regclass)")
                .HasColumnName("client_meter_readings_id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.MeterReadingsId).HasColumnName("meter_readings_id");

            entity.HasOne(d => d.Client).WithMany(p => p.ClientMeterReadings)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("client_id");

            entity.HasOne(d => d.MeterReadings).WithMany(p => p.ClientMeterReadings)
                .HasForeignKey(d => d.MeterReadingsId)
                .HasConstraintName("request_id");
        });

        modelBuilder.Entity<HaClient>(entity =>
        {
            entity.HasKey(e => e.HaClientId).HasName("ha_client_pkey");

            entity.ToTable("ha_client", "app_shema");

            entity.Property(e => e.HaClientId)
                .HasDefaultValueSql("nextval('app_shema.\"HA_CLIENT_HA_CLIENT_ID_seq\"'::regclass)")
                .HasColumnName("ha_client_id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.HaId).HasColumnName("ha_id");

            entity.HasOne(d => d.Client).WithMany(p => p.HaClients)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("client_id");

            entity.HasOne(d => d.Ha).WithMany(p => p.HaClients)
                .HasForeignKey(d => d.HaId)
                .HasConstraintName("homeowners_association");
        });

        modelBuilder.Entity<HomeownersAssociation>(entity =>
        {
            entity.HasKey(e => e.HaId).HasName("ha_key");

            entity.ToTable("homeowners_association", "app_shema");

            entity.Property(e => e.HaId)
                .HasDefaultValueSql("nextval('app_shema.\"HOMEOWNERS_ASSOCIATION_HA_ID_seq\"'::regclass)")
                .HasColumnName("ha_id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.LegalAddress).HasColumnName("legal_address");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasColumnType("char")
                .HasColumnName("phone_number");
        });

        modelBuilder.Entity<MeterReading>(entity =>
        {
            entity.HasKey(e => e.MeterReadingsId).HasName("meter_readings_pkey");

            entity.ToTable("meter_readings", "app_shema");

            entity.Property(e => e.MeterReadingsId)
                .HasDefaultValueSql("nextval('app_shema.\"METER_READINGS_METER_READINGS_ID_seq\"'::regclass)")
                .HasColumnName("meter_readings_id");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.Name)
                .HasColumnType("char")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("request_pkey");

            entity.ToTable("request", "app_shema");

            entity.Property(e => e.RequestId)
                .HasDefaultValueSql("nextval('app_shema.\"REQUEST_REQUEST_ID_seq\"'::regclass)")
                .HasColumnName("request_id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Type).HasColumnName("type");
        });

        modelBuilder.Entity<RequestClient>(entity =>
        {
            entity.HasKey(e => e.RequestClientId).HasName("request_client_pkey");

            entity.ToTable("request_client", "app_shema");

            entity.Property(e => e.RequestClientId)
                .HasDefaultValueSql("nextval('app_shema.\"REQUEST_CLIENT_REQUEST_CLIENT_ID_seq\"'::regclass)")
                .HasColumnName("request_client_id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.RequestId).HasColumnName("request_id");

            entity.HasOne(d => d.Client).WithMany(p => p.RequestClients)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("client_id");

            entity.HasOne(d => d.Request).WithMany(p => p.RequestClients)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("request_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
