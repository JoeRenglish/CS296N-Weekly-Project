namespace StoryCreator.Models;

public class Story
{
    public int StoryId { get; set; }
    public AppUser? AppUser { get; set; }
    public string? Title { get; set; }
    public string? Series { get; set; }
    public string? StoryText { get; set; }
    public DateOnly Date { get; set; }
}