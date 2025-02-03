using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoryCreator.Models;
using StoryCreator.Data;

namespace StoryCreator.Controllers
{
    [Authorize]
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

        public IActionResult StoryCreator()
        {
            return View();
        }
    }
}
