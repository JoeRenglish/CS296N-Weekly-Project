using StoryCreator.Models;

namespace StoryCreator.Data;

public interface IStoryRepository
{   
    IQueryable<Story> Stories { get; }
    public Task<Story?> GetStoryByIdAsync(int id);
    public Task<int> StoreStoryAsync(Story model);

    public int DeleteStory(int id);

}