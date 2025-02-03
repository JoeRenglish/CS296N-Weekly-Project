using StoryCreator.Models;

namespace StoryCreator.Data;

public interface IStoryRepository
{   
    IQueryable<Story> Stories { get; }
    public Story GetStoryById(int id);
    public Task<int> StoreStoryAsync(Story model);
    
}