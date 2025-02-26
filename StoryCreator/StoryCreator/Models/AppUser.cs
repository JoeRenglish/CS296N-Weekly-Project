using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace StoryCreator.Models;

public class AppUser : IdentityUser
{
  
    public string? Name { get; set; }
    public DateTime SignUpDate { get; set; }
    [NotMapped] 
    public IList<string> RoleNames { get; set; } = null!;
}