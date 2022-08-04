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
            if(obj.DisplayOrder == 0) {
                ModelState.AddModelError("Custom Error", "Display order cannot be 0");
            }
            if (ModelState.IsValid)
            {
                _db.categories.Add(obj);
                _db.SaveChanges();
                TempData["success"]="Category Created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
            
        }

        //Editing Category
        public IActionResult Edit(int? id)
        {
            if(id ==null || id == 0)
            {
                return NotFound();
            }
            var CategoryFound = _db.categories.Find(id);
            /*var CategoryFirst = _db.categories.FirstOrDefault(x=>x.Id == id);
            var CategorySingle = _db.categories.SingleOrDefault(u => u.Id == id);*/
            if (CategoryFound == null)
            {
                return NotFound();
            }
            return View(CategoryFound);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.DisplayOrder == 0)
            {
                ModelState.AddModelError("Custom Error", "Display order cannot be 0");
            }
            if (ModelState.IsValid)
            {
                _db.categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        // Deleting Category
        public IActionResult Delete(int? id)
        {
            
            var CategoryFound = _db.categories.Find(id);
            return View(CategoryFound);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(Category obj)
        {
           
            _db.categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted successfully";

            return RedirectToAction("Index");
            

        }
    }
}
