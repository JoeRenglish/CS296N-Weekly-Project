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

        public async Task<IActionResult> Story(int id)
        {
            var story = await _repo.GetStoryByIdAsync(id);
            return View(story);
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

        [Authorize]
        public IActionResult Comment(int storyId)
        {
            var commentVM = new CommentVM { StoryId = storyId };
            return View(commentVM);
        }

        [HttpPost]
        public async Task<RedirectToActionResult> Comment(CommentVM commentVM)
        {
            var comment = new Comment { Text = commentVM.CommentText };
            comment.Date = DateTime.Now;
            if (_userManager != null)
            {
                comment.AppUser = await _userManager.GetUserAsync(User);
                
            }
            var story = await _repo.GetStoryByIdAsync(commentVM.StoryId);
            story.Comments.Add(comment);
            await _repo.StoreStoryAsync(story);
            return RedirectToAction("Index", new { storyId = comment.AppUser.Id });
            
        }
        
        public IActionResult DeleteStory(int id)
        {
            _repo.DeleteStory(id);
            return RedirectToAction("UserStories");

        }
    }
}
