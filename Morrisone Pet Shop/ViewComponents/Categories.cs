using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Morrisone_Pet_Shop.Areas;
namespace Morrisone_Pet_Shop.ViewComponents
{
    public class Categories:ViewComponent
    {
        private readonly DBContext _dbContext;

        public Categories(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _dbContext.Categories.ToListAsync());
        }
    }
}
