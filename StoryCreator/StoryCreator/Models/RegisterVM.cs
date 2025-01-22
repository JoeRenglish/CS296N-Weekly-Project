using System.ComponentModel.DataAnnotations;

namespace StoryCreator.Models;

public class RegisterVM
{
    public string Username { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
    public string ConfirmPassword { get; set; } = String.Empty;
}