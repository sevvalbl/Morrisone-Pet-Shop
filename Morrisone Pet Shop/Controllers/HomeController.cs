using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Morrisone_Pet_Shop.Areas;
using System.Diagnostics;

namespace Morrisone_Pet_Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DBContext _context;

        public HomeController(ILogger<HomeController> logger, DBContext context)
        {
            _logger = logger;
            _context = context; 
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

       


        // GET: Admin/Products
        public async Task<IActionResult> UserViewProduct()
        {
            var dBContext = _context.Products.Include(p => p.Category);
            return View(await dBContext.ToListAsync());
        }









        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
