using StoryCreator.Models;
using Microsoft.AspNetCore.Identity;

namespace StoryCreator.Data;

public class SeedData
{
    public static void Seed(ApplicationDbContext context, IServiceProvider provider)
    {
        var userManager = provider.GetRequiredService<UserManager<AppUser>>();
        
        if (!context.Stories.Any())
        {
            const string SECRET_PASSWORD = "Secret!123";
            AppUser user1 = new AppUser { UserName = "https://github.com/JoeRenglish/GreetingsAdmin" };
            var result = userManager.CreateAsync(user1, SECRET_PASSWORD);
            
           
            
            Story story1 = new Story
            {
                Title = "Story Test",
                AppUser = user1,
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
                AppUser = user1
            };
            
            context.Characters.Add(character1);
            
            context.SaveChanges();
        }
    }
}