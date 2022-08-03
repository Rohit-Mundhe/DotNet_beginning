using Microsoft.AspNetCore.Mvc;
using YoutubeDotNet.Data;
using YoutubeDotNet.Models;

namespace YoutubeDotNet.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //var ObjectCategoryList = _db.categories.ToList();
            //return View();
            IEnumerable<Category> objCategoryList = _db.categories;
            return View(objCategoryList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            return View();
        }
    }
}
