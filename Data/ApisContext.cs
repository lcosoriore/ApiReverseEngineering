using System;
using System.Collections.Generic;
using ApiReverseEngineering.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiReverseEngineering.Data;

public partial class ApisContext : DbContext
{
    public ApisContext()
    {
    }

    public ApisContext(DbContextOptions<ApisContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<UserApi> UserApis { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    if(optionsBuilder.IsConfigured)
    //    {
    //        optionsBuilder.UseSqlServer(sqlcon);

    //    }
    //    base.OnConfiguring(optionsBuilder);
    //}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("Client");

            entity.Property(e => e.ClientId).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserApi>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UserApi");

            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.User)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
