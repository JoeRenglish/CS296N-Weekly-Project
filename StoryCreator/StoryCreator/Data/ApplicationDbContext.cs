using StoryCreator.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace StoryCreator.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    public DbSet<Story> Stories { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<StoryCreator.Models.Comment>? Comment { get; set; }
   
}