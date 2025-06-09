using Microsoft.EntityFrameworkCore;
using UserSyncApp.Domain.Entities;

namespace UserSyncApp.Infrastructure.Peritence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
}