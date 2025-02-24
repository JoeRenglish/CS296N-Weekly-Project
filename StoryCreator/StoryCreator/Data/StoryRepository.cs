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
            return _context.Stories
                .Include(s => s.AppUser)
                .Include(s => s.Comments)
                .ThenInclude(c => c.AppUser);
        }
    }
    

    public async Task<Story?> GetStoryByIdAsync(int id)
    {
        return await Stories.Where(s => s.StoryId == id).FirstOrDefaultAsync();
    }
    

    public async Task<int>StoreStoryAsync(Story model)
    {
        model.Date = DateOnly.FromDateTime(DateTime.Today);
        _context.Stories.Update(model);
        
        Task<int> task = _context.SaveChangesAsync();
        int result = await task;
        
        return result;
    }

    public int DeleteStory(int id)
    {
        Story story = GetStoryByIdAsync(id).Result;
        _context.Stories.Remove(story);
        return _context.SaveChanges();

    }
}