using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoryCreator.Data;
using StoryCreator.Models;

namespace StoryCreator.Controllers
{
    public class StoryController : Controller
    {
        IStoryRepository _repo;

        public StoryController(IStoryRepository r)
        {
            _repo = r;
        }

        public async Task<IActionResult> Index()
        {
            List<Story> stories;
            stories = await _repo.Stories.ToListAsync<Story>();
            return View(stories);
        }

        /*
        public IActionResult Filter(string series, string title, string username)
        {
            var stories = _repo.GetStories()
                .Where(s => series == null || s.Series == series)
                .Where(t => title == null || t.Title == title)
                .Where(u => username == null || u.AppUser.Name == username)
                .ToList();
            return View("Index", stories);

        }
*/
    }
}
