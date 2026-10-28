using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication23.Models;

public partial class TaskmanagemntContext : DbContext
{
    public TaskmanagemntContext()
    {
    }

    public TaskmanagemntContext(DbContextOptions<TaskmanagemntContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Taske> Taskes { get; set; }

    public virtual DbSet<Usre> Usres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TASKMANAGEMNT;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ROLES__3214EC27F1F1D855");

            entity.ToTable("ROLES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code)
                .HasMaxLength(250)
                .HasColumnName("CODE");
        });

        modelBuilder.Entity<Taske>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TASKE__3214EC2786BF5229");

            entity.ToTable("TASKE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descriptions)
                .HasMaxLength(250)
                .HasColumnName("DESCRIPTIONS");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasColumnName("NAME");
            entity.Property(e => e.UsersId).HasColumnName("USERS_ID");

            entity.HasOne(d => d.Users).WithMany(p => p.Taskes)
                .HasForeignKey(d => d.UsersId)
                .HasConstraintName("FK__TASKE__USERS_ID__619B8048");
        });

        modelBuilder.Entity<Usre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__USRES__3214EC271A1DBAB5");

            entity.ToTable("USRES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Age).HasColumnName("AGE");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Imagepath).HasColumnName("IMAGEPATH");
            entity.Property(e => e.Isactive).HasColumnName("ISACTIVE");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasColumnName("NAME");
            entity.Property(e => e.RolesId).HasColumnName("ROLES_ID");

            entity.HasOne(d => d.Roles).WithMany(p => p.Usres)
                .HasForeignKey(d => d.RolesId)
                .HasConstraintName("FK__USRES__ROLES_ID__5EBF139D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
