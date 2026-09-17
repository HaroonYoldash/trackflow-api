using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TrackFlow.Api.Models;

namespace TrackFlow.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // This creates an "Assets" table in the database
    public DbSet<Asset> Assets => Set<Asset>();
}