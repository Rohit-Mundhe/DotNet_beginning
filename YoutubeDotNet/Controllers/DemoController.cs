using Microsoft.AspNetCore.Mvc;

namespace YoutubeDotNet.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
