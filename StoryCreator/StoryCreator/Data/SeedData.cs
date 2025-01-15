using StoryCreator.Models;

namespace StoryCreator.Data;

public class SeedData
{
    public static void Seed(ApplicationDbContext context)
    {
        if (!context.Stories.Any())
        {
            AppUser user1 = new AppUser { Name = "Admin" };
            context.AppUsers.Add(user1);
            context.SaveChanges();
            
            Story story1 = new Story
            {
                Title = "Story Test",
                Author = user1,
                Date = DateOnly.Parse("10/23/1991"),
                Series = "Test Series",
                StoryText = "This is a test story."
            };
            context.Stories.Add(story1);
            
            Character character1 = new Character
            {
                Name = "Test Character",
                Age = 18,
                Gender = "Nonbinary",
                Birthday = "10/23/1991",
                Description = "Tall and awkward with long hair and a short beard.",
                Story = story1
            };
            
            context.Characters.Add(character1);
            
            context.SaveChanges();
        }
    }
}