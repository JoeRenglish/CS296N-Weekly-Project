namespace StoryCreator.Models;

public class Character
{
    public string Name { get; set; }
    public string Age { get; set; }
    public string Gender { get; set; }
    public string Birthday { get; set; }
    public string Description { get; set; }
    public Story Story { get; set; }
}