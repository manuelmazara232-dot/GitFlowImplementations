#nullable disable
using GitFlow.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Gitflow.DataAcces.context;

public partial class GitFlowContext : DbContext
{
    public GitFlowContext(DbContextOptions<GitFlowContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Person> People { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__People__3214EC27BC54DA53");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Birthdate).HasColumnName("BIRTHDATE");
            entity.Property(e => e.Dni)
                .HasMaxLength(50)
                .HasColumnName("DNI");
            entity.Property(e => e.Firstname)
                .HasMaxLength(200)
                .HasColumnName("FIRSTNAME");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("GENDER");
            entity.Property(e => e.Lastname)
                .HasMaxLength(200)
                .HasColumnName("LASTNAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}