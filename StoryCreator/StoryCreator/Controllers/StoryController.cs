using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoryCreator.Data;
using StoryCreator.Models;
using Microsoft.AspNetCore.Identity;

namespace StoryCreator.Controllers
{
    public class StoryController : Controller
    {
        IStoryRepository _repo;
        UserManager<AppUser> _userManager;

        public StoryController(IStoryRepository r, UserManager<AppUser> u)
        {
            _repo = r;
            _userManager = u;
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
        [Authorize]
        public async Task<IActionResult> UserStories(Story model)
        {
            if (_userManager != null)
            {
                model.AppUser = await _userManager.GetUserAsync(User);
            }
            List<Story> stories;
            stories = await (from r in _repo.Stories
                where r.AppUser == model.AppUser
                select r).ToListAsync<Story>();
            return View(stories);
        }
    }
}
