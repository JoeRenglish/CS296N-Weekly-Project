using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoryCreator.Models;
using StoryCreator.Data;

namespace StoryCreator.Controllers
{
 
    public class CreateController : Controller
    {
        IStoryRepository _repo;
        UserManager<AppUser> _userManager;

        public CreateController(IStoryRepository r, UserManager<AppUser> userM)
        {
            _repo = r;
            _userManager = userM;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CharacterCreator()
        {
            return View();
        }
        
        [Authorize]
        public IActionResult StoryCreator()
        {
            return View();
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> StoryCreator(Story model)
        {
            // Get the AppUser object for the currently logged in user
            // For unit testing, UserManager will be null so accomodate that
            if (_userManager != null)
            {
                model.AppUser = await _userManager.GetUserAsync(User);
            }
            if (await _repo.StoreStoryAsync(model) > 0)
            {
                return RedirectToAction("Index", new { storyId = model.StoryId });
            }
            else
            {
                return View();  // TODO: Send an error message to the view
            }

        }
    }
}
