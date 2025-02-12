namespace StoryCreator.Models;

public class Story
{
    private readonly List<Comment> _comments = new();
    public int StoryId { get; set; }
    public AppUser? AppUser { get; set; }
    public string? Title { get; set; }
    public string? Series { get; set; }
    public string? StoryText { get; set; }
    public DateOnly Date { get; set; }
    
    public ICollection<Comment> Comments => _comments;
}