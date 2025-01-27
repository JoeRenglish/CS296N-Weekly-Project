using Microsoft.AspNetCore.Identity;

namespace StoryCreator.Models;

public class UserVM
{
    public IEnumerable<AppUser> Users { get; set; } = null!;
    public IEnumerable<IdentityRole> Roles { get; set; } = null!;
}