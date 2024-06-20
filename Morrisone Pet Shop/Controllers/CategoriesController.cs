using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Morrisone_Pet_Shop.Areas;

namespace Morrisone_Pet_Shop.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly DBContext _context;
        public CategoriesController(DBContext context) { 
        _context = context; 
        }
        public IActionResult Index(int id)
        {
            var model = _context.Categories.Include(p => p.Products).FirstOrDefault(c => c.Id == id);


            return View(model);
        }
    }
}
