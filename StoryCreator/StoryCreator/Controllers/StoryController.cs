using Microsoft.AspNetCore.Mvc;

namespace StoryCreator.Controllers
{
    public class StoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
