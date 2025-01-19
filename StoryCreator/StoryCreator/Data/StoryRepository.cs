using StoryCreator.Models;
using Microsoft.EntityFrameworkCore;


namespace StoryCreator.Data;

public class StoryRepository : IStoryRepository
{
    private ApplicationDbContext _context;

    public StoryRepository(ApplicationDbContext appDbContext)
    {
        _context = appDbContext;
    }

    
    public List<Story> GetStories()
    {
        var stories = _context.Stories
            .Include(story => story.Author)
            .ToList();
        return stories;
    }

    public Story GetStoryById(int id)
    {
        var story = _context.Stories
            .Include(story => story.Author)
            .SingleOrDefault(story => story.StoryId == id);
        return story;
    }

    public int StoreStory(Story model)
    {
        model.Date = DateOnly.FromDateTime(DateTime.Today);
        _context.Stories.Add(model);
        return _context.SaveChanges();
    }
}