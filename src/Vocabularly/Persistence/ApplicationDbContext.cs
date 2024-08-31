using Microsoft.EntityFrameworkCore;
using Vocabularly.Domain;

namespace Vocabularly.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users{ get; set; }

    public DbSet<Word> Words { get; set; }
}