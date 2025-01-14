using Microsoft.AspNetCore.Mvc;

namespace StoryCreator.Controllers
{
    public class CreateController : Controller
    {
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
