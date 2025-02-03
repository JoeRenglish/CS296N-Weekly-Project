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

    public IQueryable<Story> Stories
    {
        get
        {
            return _context.Stories.Include(story => story.AppUser);

        }
    }
    

    public Story GetStoryById(int id)
    {
        var story = _context.Stories
            .Include(story => story.AppUser)
            .Where(story => story.StoryId == id)
            .SingleOrDefault(story => story.StoryId == id);
        return story;
    }
    

    public async Task<int>StoreStoryAsync(Story model)
    {
        model.Date = DateOnly.FromDateTime(DateTime.Today);
        _context.Stories.Add(model);
        
        Task<int> task = _context.SaveChangesAsync();
        int result = await task;
        
        return result;
    }
}