using Microsoft.AspNetCore.Mvc;
using StoryCreator.Data;

namespace StoryCreator.Controllers
{
    public class StoryController : Controller
    {
        IStoryRepository _repo;

        public StoryController(IStoryRepository r)
        {
            _repo = r;
        }

        public IActionResult Index()
        {
            var stories = _repo.GetStories();
            return View(stories);
        }

        public IActionResult Filter(string series, string title, string username)
        {
            var stories = _repo.GetStories()
                .Where(s => series == null || s.Series == series)
                .Where(t => title == null || t.Title == title)
                .Where(u => username == null || u.AppUser.Name == username)
                .ToList();
            return View("Index", stories);

        }

    }
}
