using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRUD_app.Models;

public partial class MyDatabaseContext : DbContext
{
    public MyDatabaseContext()
    {
    }

    public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // leave empty, EF Core will get it from Program.cs / Startup.cs
        }

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("customers");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.Score).HasColumnName("score");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("orders");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("order_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");
            entity.Property(e => e.Sales).HasColumnName("sales");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__students__3213E83F2210594E");

            entity.ToTable("students");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.FatherName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("father_name");
            entity.Property(e => e.Standard).HasColumnName("standard");
            entity.Property(e => e.StudentGender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("student_gender");
            entity.Property(e => e.StudentName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("student_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
