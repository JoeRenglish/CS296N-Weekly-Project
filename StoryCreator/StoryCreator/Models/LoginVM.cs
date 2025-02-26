using System.ComponentModel.DataAnnotations;

namespace StoryCreator.Models;

public class LoginVM
{
    public string Username { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
    public string ReturnUrl { get; set; } = String.Empty;
    public bool RememberMe { get; set; }
}