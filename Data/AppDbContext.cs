using Microsoft.EntityFrameworkCore;
using CaretakerStories.Models;

namespace CaretakerStories.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Story> Stories => Set<Story>();
}
