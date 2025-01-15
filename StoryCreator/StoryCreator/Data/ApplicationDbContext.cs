using StoryCreator.Models;
using Microsoft.EntityFrameworkCore;

namespace StoryCreator.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    public DbSet<Story> Stories { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<AppUser> AppUsers { get; set; }
}