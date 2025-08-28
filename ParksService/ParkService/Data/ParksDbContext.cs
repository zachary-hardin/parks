using Microsoft.EntityFrameworkCore;
using ParksService.Models;

namespace ParksService.Data;

public class ParksDbContext : DbContext
{
    public ParksDbContext(DbContextOptions<ParksDbContext> options) : base(options)
    {
    }

    public DbSet<Park> Parks => Set<Park>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Park>(entity =>
        {
            entity.ToTable("Park");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);
        });
    }
}