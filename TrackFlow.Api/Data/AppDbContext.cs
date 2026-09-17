using Microsoft.EntityFrameworkCore;
using TrackFlow.Api.Models;

namespace TrackFlow.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Asset> Assets => Set<Asset>();
}