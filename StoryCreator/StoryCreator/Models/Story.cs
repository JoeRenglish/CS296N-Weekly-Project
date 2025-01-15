namespace StoryCreator.Models;

public class Story
{
    public AppUser Author { get; set; }
    public string Title { get; set; }
    public string Series { get; set; }
    public string StoryText { get; set; }
    public DateOnly Date { get; set; }
}