namespace StoryCreator.Models;

public class Comment
{
    public int CommentId { get; set; }
    public AppUser AppUser { get; set; } = new();
    public string Text { get; set; } = String.Empty;
    public DateTime Date { get; set; }
    public int StoryId { get; set; }
}   