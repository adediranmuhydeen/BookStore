using BookStore.Web.Data;
using BookStore.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            return RedirectToAction("Index");
        }

        //Get
        public async Task<IActionResult> Edit(int? Id)
        {
            if(Id==null || Id==0) 
            {
                return NotFound();
            }
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == Id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        //Pust
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category obj)
        {            
            if (ModelState.IsValid)
            {
                _context.Categories.Update(obj);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == Id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        //Pust
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Id)
        {
            var obj = await _context.Categories.FindAsync(Id);
            if (obj == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(obj);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
