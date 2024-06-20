using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Morrisone_Pet_Shop.Areas;

namespace Morrisone_Pet_Shop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Categories : Controller
    {
        private readonly DBContext _context;
        public Categories(DBContext context)
        {
            _context = context;

        }

        // GET: Categories
        public ActionResult Index()
        {
            var model=_context.Categories.ToList();  

            return View(model);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Create(Category category,IFormFile? Image)
        {
            try
            {
                if (Image is not null)
                {
                    string folder = Directory.GetCurrentDirectory() + "/wwwroot/ProjectImages/" + Image.FileName;
                    using var stream = new FileStream(folder, FileMode.Create);
                    Image.CopyTo(stream);
                    category.Image = Image.FileName;
                }
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
      
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _context.Categories.Find(id);
            return View(model);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Category category,IFormFile? Image)
        {
            if (id != category.Id)
            {

                return NotFound();
            }
            try
            {
                if (Image is not null)
                {
                    string folder = Directory.GetCurrentDirectory() + "/wwwroot/ProjectImages/" + Image.FileName;
                    using var stream = new FileStream(folder, FileMode.Create);
                    Image.CopyTo(stream);
                    category.Image = Image.FileName;
                }
                _context.Update(category);
                await _context.SaveChangesAsync();
               
            }
            catch
            {
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _context.Categories.Find(id);
            return View(model);
        }   

        // POST: Categories/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Category category)
        {
            try
            {
                 _context.Remove(category);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
