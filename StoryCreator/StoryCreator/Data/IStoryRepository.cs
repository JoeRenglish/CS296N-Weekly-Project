using StoryCreator.Models;

namespace StoryCreator.Data;

public interface IStoryRepository
{   
    public List<Story> GetStories();
    public Story GetStoryById(int id);
    public int StoreStory(Story model);
    
}