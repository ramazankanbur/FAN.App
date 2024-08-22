using FAN.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace FAN.Infrastructure.Persistence;

public sealed class FANContext : DbContext
{
    public FANContext(DbContextOptions<FANContext> options): base(options)
    {
        if (Database.CanConnect()) return;

        if (!Database.EnsureCreated())
            throw new Exception("Database was not created!");

    }

    public DbSet<Event> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
     
    }
}