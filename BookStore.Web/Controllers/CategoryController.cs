using BookStore.Web.Data;
using BookStore.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            return View( _context.Categories);
        }


        //Get
        public IActionResult Create()
        {
            return View();
        }


        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                await _context.Categories.AddAsync(obj);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
